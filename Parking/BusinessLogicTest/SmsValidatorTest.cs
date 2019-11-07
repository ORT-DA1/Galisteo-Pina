using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities;

namespace BusinessLogicTest
{

    [TestClass]
    public class SmsValidatorTest
    {
        Sms sms;
        SmsValidator smsValidator;

        [TestInitialize]
        public void TestInitialize()
        {
            DateTime lowerLimit = DateTime.Now;
            DateTime upperLimit = lowerLimit.AddHours(8);
            sms = new Sms(lowerLimit, upperLimit);
        }

        [TestMethod]
        public void ValidateCorrectTest()
        {
            Notification notification;
            DateTime hourForTest = DateTime.Now.AddMinutes(5);
            string message = $"ABC 1234 120 {hourForTest.ToString("HH:mm")}";
            sms.Initialize(message);
            smsValidator = new SmsValidator(sms);
            notification = smsValidator.Validate();
            Assert.IsFalse(notification.HasErrors());
        }

        [TestMethod]
        public void ValidateCorrectNoHourTest()
        {
            Notification notification;
            string message = "ABC 1234 60";
            double minutes = 120;
            DateTime lowerLimitForTest = DateTime.Now;
            DateTime upperLimitForTest = DateTime.Now.AddMinutes(minutes);
            Sms sms = new Sms(lowerLimitForTest, upperLimitForTest);
            sms.Initialize(message);
            smsValidator = new SmsValidator(sms);
            notification = smsValidator.Validate();
            Assert.IsFalse(notification.HasErrors());
        }

        [TestMethod]
        public void MissingInputTest()
        {
            string input = "";
            smsValidator = new SmsValidator(sms);
            Assert.IsTrue(smsValidator.MissingInput(input));
        }

        [TestMethod]
        public void ValidateMinutesNotMultipleOf30Test()
        {
            string minutes = "70";
            sms.Minutes = minutes;
            smsValidator = new SmsValidator(sms);
            Assert.IsFalse(smsValidator.ValidateMinutes());
        }

        [TestMethod]
        public void ValidateMinutesIsMultipleOf30Test()
        {
            string minutes = "60";
            sms.Minutes = minutes;
            smsValidator = new SmsValidator(sms);
            Assert.IsTrue(smsValidator.ValidateMinutes());
        }

        [TestMethod]
        public void ValidateMinutesIsNotIntegerTest()
        {
            string minutes = "60.1";
            sms.Minutes = minutes;
            smsValidator = new SmsValidator(sms);
            Assert.IsFalse(smsValidator.ValidateMinutes());
        }

        [TestMethod]
        public void ValidateMinutesIsNotNegativeTest()
        {
            string minutes = "-60";
            sms.Minutes = minutes;
            smsValidator = new SmsValidator(sms);
            Assert.IsFalse(smsValidator.ValidateMinutes());
        }

        [TestMethod]
        public void IsValidateStartingHourFormatTrueTest()
        {
            string[] startingHour = { "12:15" };
            sms.StartingHour = sms.ExtractStartingHour(startingHour);
            smsValidator = new SmsValidator(sms);
            Assert.IsTrue(smsValidator.IsValidHourFormat());
        }

        [TestMethod]
        public void IsValidateStartingHourFormatFalseTest()
        {
            string[] startingHour = { "120:15" };
            sms.StartingHour = sms.ExtractStartingHour(startingHour);
            smsValidator = new SmsValidator(sms);
            Assert.IsFalse(smsValidator.IsValidHourFormat());
        }

        [TestMethod]
        public void IsWithinRangeOfHoursTrueTest()
        {
            sms.StartingHour = DateTime.Now.AddMinutes(5);
            smsValidator = new SmsValidator(sms);
            Assert.IsTrue(smsValidator.IsWithinRangeOfHours());
        }

        [TestMethod]
        public void IsWithinRangeOfHoursFalseTest()
        {
            sms.StartingHour = DateTime.Now.AddMinutes(-5);
            smsValidator = new SmsValidator(sms);
            Assert.IsFalse(smsValidator.IsWithinRangeOfHours());
        }

        [TestMethod]
        public void StartingHourIsForTodayTrueTest()
        {

            DateTime startingHour = DateTime.Now;
            sms.StartingHour = startingHour;
            smsValidator = new SmsValidator(sms);
            Assert.IsTrue(smsValidator.IsHourForToday());

        }

        [TestMethod]
        public void StartingHourIsForTodayFalseTest()
        {
            TimeSpan timeSpan = new TimeSpan(0,5,0);
            DateTime startingHour = DateTime.Now.Subtract(timeSpan);
            sms.StartingHour = startingHour;
            smsValidator = new SmsValidator(sms);
            Assert.IsFalse(smsValidator.IsHourForToday());
        }
    }
}
