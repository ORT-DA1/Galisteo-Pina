using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities;

namespace BusinessLogicTest
{

    [TestClass]
    public class UySmsValidatorTest
    {
        Sms sms;
        UySmsValidator smsValidator;
        DateTime lowerLimit;
        DateTime upperLimit;

        [TestInitialize]
        public void TestInitialize()
        {
            sms = new Sms();
            smsValidator = new UySmsValidator();
            lowerLimit = DateTime.Now;
            upperLimit = lowerLimit.AddHours(8);
        }

        [TestMethod]
        public void ValidateSmsCorrectTest()
        {
            Notification notification;
            DateTime hourForTest = DateTime.Now.AddMinutes(5);
            string message = $"ABC 1234 120 {hourForTest.ToString("HH:mm")}";
            sms = smsValidator.GetInitializedSms(message);
            sms.SetHourBounds(lowerLimit, upperLimit);
            notification = smsValidator.ValidateSms(sms);
            Assert.IsFalse(notification.HasErrors());
        }

        [TestMethod]
        public void ValidateCorrectNoHourTest()
        {
            Notification notification;
            DateTime hourForTest = DateTime.Now.AddMinutes(5);
            string message = "ABC 1234 60";
            sms = smsValidator.GetInitializedSms(message);
            sms.SetHourBounds(lowerLimit, upperLimit);
            notification = smsValidator.ValidateSms(sms);
            Assert.IsFalse(notification.HasErrors());
        }

        [TestMethod]
        public void MissingInputTest()
        {
            string input = "";
            Assert.IsTrue(smsValidator.MissingInput(input));
        }

        [TestMethod]
        public void ValidateMinutesNotMultipleOf30Test()
        {
            string minutes = "70";
            sms.Minutes = minutes;
            Assert.IsFalse(smsValidator.ValidateMinutes(sms));
        }

        [TestMethod]
        public void ValidateMinutesIsMultipleOf30Test()
        {
            string minutes = "60";
            sms.Minutes = minutes;
            Assert.IsTrue(smsValidator.ValidateMinutes(sms));
        }

        [TestMethod]
        public void ValidateMinutesIsNotIntegerTest()
        {
            string minutes = "60.1";
            sms.Minutes = minutes;
            Assert.IsFalse(smsValidator.ValidateMinutes(sms));
        }

        [TestMethod]
        public void ValidateMinutesIsNotNegativeTest()
        {
            string minutes = "-60";
            sms.Minutes = minutes;
            Assert.IsFalse(smsValidator.ValidateMinutes(sms));
        }

        [TestMethod]
        public void IsValidateStartingHourFormatTrueTest()
        {
            string[] startingHour = { "12:15" };
            sms.StartingHour = smsValidator.ExtractStartingHour(startingHour);
            Assert.IsTrue(smsValidator.IsValidHourFormat(sms));
        }

        [TestMethod]
        public void IsValidateStartingHourFormatFalseTest()
        {
            string[] startingHour = { "120:15" };
            sms.StartingHour = smsValidator.ExtractStartingHour(startingHour);
            Assert.IsFalse(smsValidator.IsValidHourFormat(sms));
        }

        [TestMethod]
        public void IsWithinRangeOfHoursTrueTest()
        {
            sms.SetHourBounds(lowerLimit, upperLimit);
            sms.StartingHour = DateTime.Now.AddMinutes(5);
            Assert.IsTrue(smsValidator.IsWithinRangeOfHours(sms));
        }

        [TestMethod]
        public void IsWithinRangeOfHoursFalseTest()
        {
            sms.SetHourBounds(lowerLimit, upperLimit);
            sms.StartingHour = DateTime.Now.AddMinutes(-5);
            Assert.IsFalse(smsValidator.IsWithinRangeOfHours(sms));
        }

        [TestMethod]
        public void StartingHourIsForTodayTrueTest()
        {
            DateTime startingHour = DateTime.Now;
            sms.StartingHour = startingHour;
            Assert.IsTrue(smsValidator.IsHourForToday(sms));
        }

        [TestMethod]
        public void StartingHourIsForTodayFalseTest()
        {
            TimeSpan timeSpan = new TimeSpan(0, 5, 0);
            DateTime startingHour = DateTime.Now.Subtract(timeSpan);
            sms.StartingHour = startingHour;
            Assert.IsFalse(smsValidator.IsHourForToday(sms));
        }

        [TestMethod]
        public void NormalizeMessagePlateTest()
        {
            string smsMessage = "XXX 1234 120";
            Assert.AreEqual(smsValidator.NormalizeMessagePlate(smsMessage), "XXX1234 120");
        }

        [TestMethod]
        public void NormalizeMessagePlateTestNoSpaceTest()
        {

            string smsMessage = "XXX1234 120";
            Assert.AreEqual(smsValidator.NormalizeMessagePlate(smsMessage), "XXX1234 120");
        }

        [TestMethod]
        public void SplitMessageTest()
        {
            string smsMessagePreSplit = "XXX1234 120";
            string[] smsMessageAfterSplit = { "XXX1234", "120" };
            CollectionAssert.AreEqual(smsValidator.TrimAndSplitMessage(smsMessagePreSplit), smsMessageAfterSplit);
        }

        [TestMethod]
        public void SplitMessageMoreThanOneSpaceTest()
        {
            string smsMessagePreSplit = "XXX1234    120  ";
            string[] smsMessageAfterSplit = { "XXX1234", "120" };
            CollectionAssert.AreEqual(smsValidator.TrimAndSplitMessage(smsMessagePreSplit), smsMessageAfterSplit);
        }

        [TestMethod]
        public void SmsHasStartingHourTrueTest()
        {
            string[] splitMessage = { "XXX1234", "120", "16:10" };
            Assert.IsTrue(smsValidator.SmsHasStartingHour(splitMessage));
        }

        [TestMethod]
        public void SmsHasStartingHourFalseTest()
        {
            string[] splitMessage = { "XXX1234", "120" };
            Assert.IsFalse(smsValidator.SmsHasStartingHour(splitMessage));
        }

        [TestMethod]
        public void ExtractTest()
        {
            string regexPattern = "123";
            string[] splitMessage = { "ABC", "123" };
            Assert.AreEqual(smsValidator.Extract(splitMessage, regexPattern), "123");
        }

        [TestMethod]
        public void ExtractEmptyTest()
        {
            string regexPattern = "ABC";
            string[] splitMessage = { "" };
            Assert.ThrowsException<InvalidOperationException>(() => smsValidator.Extract(splitMessage, regexPattern));
        }

        [TestMethod]
        public void ExtractFromSplitMessageTest()
        {
            string regexPattern = "ABC";
            string[] splitMessage = { "ABC", "CBD" };
            Assert.AreEqual(smsValidator.Extract(splitMessage, regexPattern), "ABC");
        }


        [TestMethod]
        public void ExtractPlatesFromSplitMessageTest()
        {
            string[] splitMessage = { "XXX1234", "120" };
            Assert.AreEqual(smsValidator.ExtractPlates(splitMessage), "XXX1234");
        }

        [TestMethod]
        public void ExtractMinutesFromSplitMessageTest()
        {
            string[] splitMessage = { "XXX1234", "120" };
            Assert.AreEqual(smsValidator.ExtractMinutes(splitMessage), "120");
        }

        [TestMethod]
        public void ExtractStartingHourFromSplitMessageTest()
        {
            string[] splitMessage = { "XXX1234", "120", "16:20" };
            Assert.AreEqual(smsValidator.ExtractStartingHour(splitMessage), DateTime.Parse("16:20"));
        }

        [TestMethod]
        public void Initialize()
        {
            string message = "ABC 1234 120 16:00";
            sms = smsValidator.GetInitializedSms(message);
            Assert.IsTrue(sms.Plates == "ABC1234" && sms.Minutes == "120"
                && sms.StartingHour == DateTime.Parse("16:00")
                && sms.EndingHour == DateTime.Parse("18:00"));
        }

        [TestMethod]
        public void SetEndingHourTest()
        {
            sms.Minutes = "60";
            sms.StartingHour = DateTime.Parse("10:00");
            sms.EndingHour = smsValidator.GetEndingHour(sms);

            Assert.AreEqual(sms.EndingHour, DateTime.Parse("11:00"));
        }

        [TestMethod]
        public void SetEndingHourEndsLaterThanMaxEndingHourTest()
        {
            sms.Minutes = "60";
            sms.StartingHour = DateTime.Parse("21:30");
            sms.EndingHour = smsValidator.GetEndingHour(sms);
            Assert.AreEqual(sms.EndingHour, DateTime.Parse("22:00"));
        }



    }
}
