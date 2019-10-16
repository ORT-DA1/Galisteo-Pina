using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;

namespace BusinessLogicTest
{

    [TestClass]
    public class SmsTest
    {

        Sms sms;

        [TestInitialize]
        public void TestInitialize()
        {
            DateTime lowerLimit = DateTime.Parse("10:00");
            DateTime upperLimit = DateTime.Parse("18:00");
            sms = new Sms(lowerLimit, upperLimit);
        }


        [TestMethod]
        public void NormalizeMessagePlateTest()
        {
            string smsMessage = "XXX 1234 120";
            Assert.AreEqual(sms.NormalizeMessagePlate(smsMessage), "XXX1234 120");
        }

        [TestMethod]
        public void NormalizeMessagePlateTestNoSpaceTest()
        {

            string smsMessage = "XXX1234 120";
            Assert.AreEqual(sms.NormalizeMessagePlate(smsMessage), "XXX1234 120");
        }

        [TestMethod]
        public void SplitMessageTest()
        {
            string smsMessagePreSplit = "XXX1234 120";
            string[] smsMessageAfterSplit = { "XXX1234", "120" };
            CollectionAssert.AreEqual(sms.TrimAndSplitMessage(smsMessagePreSplit), smsMessageAfterSplit);
        }

        [TestMethod]
        public void SplitMessageMoreThanOneSpaceTest()
        {
            string smsMessagePreSplit = "XXX1234    120  ";
            string[] smsMessageAfterSplit = { "XXX1234", "120" };
            CollectionAssert.AreEqual(sms.TrimAndSplitMessage(smsMessagePreSplit), smsMessageAfterSplit);
        }

        [TestMethod]
        public void SmsHasStartingHourTrueTest()
        {
            string[] splitMessage = { "XXX1234", "120", "16:10" };
            Assert.IsTrue(sms.SmsHasStartingHour(splitMessage));
        }

        [TestMethod]
        public void SmsHasStartingHourFalseTest()
        {
            string[] splitMessage = { "XXX1234", "120" };
            Assert.IsFalse(sms.SmsHasStartingHour(splitMessage));
        }

        [TestMethod]
        public void ExtractTest()
        {
            string regexPattern = "123";
            string[] splitMessage = { "ABC", "123" };
            Assert.AreEqual(sms.Extract(splitMessage, regexPattern), "123");
        }

        [TestMethod]
        public void ExtractEmptyTest()
        {
            string regexPattern = "ABC";
            string[] splitMessage = { "" };
            Assert.ThrowsException<InvalidOperationException>(() => sms.Extract(splitMessage, regexPattern));
        }

        [TestMethod]
        public void ExtractFromSplitMessageTest()
        {
            string regexPattern = "ABC";
            string[] splitMessage = { "ABC", "CBD" };
            Assert.AreEqual(sms.Extract(splitMessage, regexPattern), "ABC");
        }


        [TestMethod]
        public void ExtractPlatesFromSplitMessageTest()
        {
            string[] splitMessage = { "XXX1234", "120" };
            Assert.AreEqual(sms.ExtractPlates(splitMessage), "XXX1234");
        }

        [TestMethod]
        public void ExtractMinutesFromSplitMessageTest()
        {
            string[] splitMessage = { "XXX1234", "120" };
            Assert.AreEqual(sms.ExtractMinutes(splitMessage), "120");
        }

        [TestMethod]
        public void ExtractStartingHourFromSplitMessageTest()
        {
            string[] splitMessage = { "XXX1234", "120", "16:20" };
            Assert.AreEqual(sms.ExtractStartingHour(splitMessage), DateTime.Parse("16:20"));
        }

        [TestMethod]
        public void Initialize()
        {
            string message = "ABC 1234 120 16:00";
            sms.Initialize(message);
            Assert.IsTrue(sms.Plates == "ABC1234" && sms.Minutes == "120"
                && sms.StartingHour == DateTime.Parse("16:00")
                && sms.EndingHour == DateTime.Parse("18:00"));
        }

        [TestMethod]
        public void SetEndingHourTest()
        {
            sms.Minutes = "60";
            sms.StartingHour = DateTime.Parse("10:00");
            sms.EndingHour = sms.SetEndingHour();

            Assert.AreEqual(sms.EndingHour, DateTime.Parse("11:00"));
        }

        [TestMethod]
        public void SetEndingHourEndsLaterThanMaxEndingHourTest()
        {
            sms.Minutes = "60";
            sms.StartingHour = DateTime.Parse("17:30");
            sms.EndingHour = sms.SetEndingHour();

            Assert.AreEqual(sms.EndingHour, DateTime.Parse("18:00"));
        }


    }
}
