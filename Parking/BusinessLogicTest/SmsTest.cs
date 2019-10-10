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

        [TestMethod]
        public void NormalizeMessagePlateTest()
        {
            Sms sms = new Sms();
            string smsMessage = "XXX 1234 120";
            Assert.AreEqual(sms.NormalizeMessagePlate(smsMessage), "XXX1234 120");
        }

        [TestMethod]
        public void NormalizeMessagePlateTestNoSpaceTest()
        {
            Sms sms = new Sms();
            string smsMessage = "XXX1234 120";
            Assert.AreEqual(sms.NormalizeMessagePlate(smsMessage), "XXX1234 120");
        }

        [TestMethod]
        public void SplitMessageTest()
        {
            Sms sms = new Sms();
            string smsMessagePreSplit = "XXX1234 120";
            string[] smsMessageAfterSplit = { "XXX1234", "120" };
            CollectionAssert.AreEqual(sms.TrimAndSplitMessage(smsMessagePreSplit), smsMessageAfterSplit);
        }

        [TestMethod]
        public void SplitMessageMoreThanOneSpaceTest()
        {
            Sms sms = new Sms();
            string smsMessagePreSplit = "XXX1234    120  ";
            string[] smsMessageAfterSplit = { "XXX1234", "120" };
            CollectionAssert.AreEqual(sms.TrimAndSplitMessage(smsMessagePreSplit), smsMessageAfterSplit);
        }

        [TestMethod]
        public void SmsHasStartingHourTrueTest()
        {
            Sms sms = new Sms();
            string[] splitMessage = { "XXX1234", "120", "16:10" };
            Assert.IsTrue(sms.SmsHasStartingHour(splitMessage));
        }

        [TestMethod]
        public void SmsHasStartingHourFalseTest()
        {
            Sms sms = new Sms();
            string[] splitMessage = { "XXX1234", "120" };
            Assert.IsFalse(sms.SmsHasStartingHour(splitMessage));
        }

        [TestMethod]
        public void ExtractFromSplitMessageTest()
        {
            Sms sms = new Sms();
            string regexPattern = "ABC";
            string[] splitMessage = { "ABC", "CBD" };
            Assert.AreEqual(sms.Extract(splitMessage, regexPattern), "ABC");
        }


        [TestMethod]
        public void ExtractPlatesFromSplitMessageTest()
        {
            Sms sms = new Sms();
            string[] splitMessage = { "XXX1234", "120" };
            Assert.AreEqual(sms.ExtractPlates(splitMessage), "XXX1234");
        }

        [TestMethod]
        public void ExtractMinutesFromSplitMessageTest()
        {
            Sms sms = new Sms();
            string[] splitMessage = { "XXX1234", "120" };
            Assert.AreEqual(sms.ExtractMinutes(splitMessage), "120");
        }

        [TestMethod]
        public void ExtractStartingHourFromSplitMessageTest()
        {
            Sms sms = new Sms();
            string[] splitMessage = { "XXX1234", "120", "16:20" };
            Assert.AreEqual(sms.ExtractStartingHour(splitMessage), "16:20");
        }

        [TestMethod]
        public void MissingInputTest()
        {
            Sms sms = new Sms();
            string input = "";
            Assert.IsTrue(sms.MissingInput(input));
        }

        [TestMethod]
        public void ValidateMinutesNotMultipleOf30Test()
        {
            Sms sms = new Sms();
            string minutes = "70";
            sms.Minutes = minutes;
            Assert.IsFalse(sms.ValidateMinutes());
        }

        [TestMethod]
        public void ValidateMinutesIsMultipleOf30Test()
        {
            Sms sms = new Sms();
            string minutes = "60";
            sms.Minutes = minutes;
            Assert.IsTrue(sms.ValidateMinutes());
        }

        [TestMethod]
        public void ValidateMinutesIsNotIntegerTest()
        {
            Sms sms = new Sms();
            string minutes = "60.1";
            sms.Minutes = minutes;
            Assert.IsFalse(sms.ValidateMinutes());
        }

        [TestMethod]
        public void ValidateMinutesIsNotNegativeTest()
        {
            Sms sms = new Sms();
            string minutes = "-60";
            sms.Minutes = minutes;
            Assert.IsFalse(sms.ValidateMinutes());
        }

        [TestMethod]
        public void IsValidateStartingHourFormatTrueTest()
        {
            Sms sms = new Sms();
            string startingHour = "12:15";
            sms.StartingHour = startingHour;
            Assert.IsTrue(sms.IsValidHourFormat());
        }

        [TestMethod]
        public void IsValidateStartingHourFormatFalseTest()
        {
            Sms sms = new Sms();
            string startingHour = "120:15";
            sms.StartingHour = startingHour;
            Assert.IsFalse(sms.IsValidHourFormat());
        }

        [TestMethod]
        public void IsWithinRangeOfHoursTrueTest()
        {
            Sms sms = new Sms();
            string startingHour = "10:30";
            sms.StartingHour = startingHour;
            Assert.IsTrue(sms.IsWithinRangeOfHours());
        }

        [TestMethod]
        public void IsWithinRangeOfHoursFalseTest()
        {
            Sms sms = new Sms();
            string startingHour = "09:30";
            sms.StartingHour = startingHour;
            Assert.IsFalse(sms.IsWithinRangeOfHours());
        }

        [TestMethod]
        public void StartingHourIsForTodayTrueTest()
        {
            Sms sms = new Sms();
            string startingHour = "12:00";
            sms.StartingHour = startingHour;
            Assert.IsTrue(sms.IsHourForToday(DateTime.Parse("11:00")));

        }

        [TestMethod]
        public void StartingHourIsForTodayFalseTest()
        {
            Sms sms = new Sms();
            string startingHour = "10:30";
            sms.StartingHour = startingHour;
            Assert.IsFalse(sms.IsHourForToday(DateTime.Parse("11:00")));
        }


    }
}
