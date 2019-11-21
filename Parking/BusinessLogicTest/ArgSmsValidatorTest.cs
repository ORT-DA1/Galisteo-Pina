using System;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogicTest
{
    [TestClass]
    public class ArgSmsValidatorTest
    {
        Sms sms;
        ArgSmsValidator smsValidator;
        DateTime lowerLimit;
        DateTime upperLimit;

        [TestInitialize]
        public void TestInitialize()
        {
            sms = new Sms();
            smsValidator = new ArgSmsValidator();
            lowerLimit = DateTime.Now;
            upperLimit = lowerLimit.AddHours(8);
        }

        [TestMethod]
        public void TestIsCorrectFormatTrueTest()
        {
            string[] smsComponents = new string[]
            {
                "sbi7508",
                "12:30",
                "60"
            };
            Assert.IsTrue(smsValidator.CorrectOrder(smsComponents));

        }

        [TestMethod]
        public void TestCorrectOrderTrueTest()
        {
            string[] smsComponents = new string[]
            {
                "sbi7508",
                "12:30",
                "60"
            };
            Assert.IsTrue(smsValidator.CorrectOrder(smsComponents));

        }

        [TestMethod]
        public void TestCorrectOrderFalseTest()
        {
            string[] smsComponents = new string[]
            {
                "sbi7508",
                "60",
                "12:30",

            };
            Assert.IsFalse(smsValidator.CorrectOrder(smsComponents));

        }


        [TestMethod]
        public void TestCorrectOrderMissingOneFalseTest()
        {
            string[] smsComponents = new string[]
            {
                "sbi7508",
                "60",

            };
            Assert.IsFalse(smsValidator.CorrectOrder(smsComponents));

        }


        [TestMethod]
        public void ValidateSmsCorrectOrderTest()
        {
            Notification notification;
            DateTime hourForTest = DateTime.Now.AddMinutes(5);
            string message = $"ABC 1234  {hourForTest.ToString("HH:mm")} 120";
            sms = smsValidator.GetInitializedSms(message);
            sms.SetHourBounds(lowerLimit, upperLimit);
            notification = smsValidator.ValidateSms(sms);
            Assert.IsFalse(notification.HasErrors());
        }

        [TestMethod]
        public void ValidateSmsIsCorrectOrderFalseTest()
        {
            Notification notification;
            DateTime hourForTest = DateTime.Now.AddMinutes(5);
            string message = $"ABC 1234 120 {hourForTest.ToString("HH:mm")}";
            sms = smsValidator.GetInitializedSms(message);
            sms.SetHourBounds(lowerLimit, upperLimit);
            notification = smsValidator.ValidateSms(sms);
            Assert.IsTrue(notification.HasErrors());
        }

        [TestMethod]
        public void ValidateSmsMissingHourFalseTest()
        {
            Notification notification;
            DateTime hourForTest = DateTime.Now.AddMinutes(5);
            string message = $"ABC 1234 120";
            sms = smsValidator.GetInitializedSms(message);
            sms.SetHourBounds(lowerLimit, upperLimit);
            notification = smsValidator.ValidateSms(sms);
            Assert.IsTrue(notification.HasErrors());
        }

        [TestMethod]
        public void GetInitializedSmsTest()
        {
            string message = "ABC 1234 16:00 120 ";
            sms = smsValidator.GetInitializedSms(message);
            Assert.IsTrue(sms.Plates == "ABC1234" && sms.Minutes == "120"
                && sms.StartingHour == DateTime.Parse("16:00")
                && sms.EndingHour == DateTime.Parse("18:00"));
        }

        [TestMethod]
        public void GetInitializedSmsWrongOrderTest()
        {
            string message = "ABC 1234 120 16:00";
            sms = smsValidator.GetInitializedSms(message);
            Assert.IsFalse(sms.Plates == "ABC1234" && sms.Minutes == "120"
                && sms.StartingHour == DateTime.Parse("16:00")
                && sms.EndingHour == DateTime.Parse("18:00"));
        }
        



    }
}
