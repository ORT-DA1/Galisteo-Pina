//using System;
//using System.Text;
//using System.Collections.Generic;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using BusinessLogic;

//namespace BusinessLogicTest
//{

//    [TestClass]
//    public class SmsTest
//    {

//        Sms sms;

//        [TestInitialize]
//        public void TestInitialize()
//        {
//            DateTime lowerLimit = DateTime.Parse("10:00");
//            DateTime upperLimit = DateTime.Parse("18:00");
//            sms = new Sms(lowerLimit, upperLimit);
       
//        }


//        [TestMethod]
//        public void NormalizeMessagePlateTest()
//        {
//            string smsMessage = "XXX 1234 120";
//            Assert.AreEqual(sms.NormalizeMessagePlate(smsMessage), "XXX1234 120");
//        }

//        [TestMethod]
//        public void NormalizeMessagePlateTestNoSpaceTest()
//        {

//            string smsMessage = "XXX1234 120";
//            Assert.AreEqual(sms.NormalizeMessagePlate(smsMessage), "XXX1234 120");
//        }

//        [TestMethod]
//        public void SplitMessageTest()
//        {
//            string smsMessagePreSplit = "XXX1234 120";
//            string[] smsMessageAfterSplit = { "XXX1234", "120" };
//            CollectionAssert.AreEqual(sms.TrimAndSplitMessage(smsMessagePreSplit), smsMessageAfterSplit);
//        }

//        [TestMethod]
//        public void SplitMessageMoreThanOneSpaceTest()
//        {
//            string smsMessagePreSplit = "XXX1234    120  ";
//            string[] smsMessageAfterSplit = { "XXX1234", "120" };
//            CollectionAssert.AreEqual(sms.TrimAndSplitMessage(smsMessagePreSplit), smsMessageAfterSplit);
//        }

//        [TestMethod]
//        public void SmsHasStartingHourTrueTest()
//        {
//            string[] splitMessage = { "XXX1234", "120", "16:10" };
//            Assert.IsTrue(sms.SmsHasStartingHour(splitMessage));
//        }

//        [TestMethod]
//        public void SmsHasStartingHourFalseTest()
//        {
//            string[] splitMessage = { "XXX1234", "120" };
//            Assert.IsFalse(sms.SmsHasStartingHour(splitMessage));
//        }

//        [TestMethod]
//        public void ExtractFromSplitMessageTest()
//        {
//            string regexPattern = "ABC";
//            string[] splitMessage = { "ABC", "CBD" };
//            Assert.AreEqual(sms.Extract(splitMessage, regexPattern), "ABC");
//        }


//        [TestMethod]
//        public void ExtractPlatesFromSplitMessageTest()
//        {
//            string[] splitMessage = { "XXX1234", "120" };
//            Assert.AreEqual(sms.ExtractPlates(splitMessage), "XXX1234");
//        }

//        [TestMethod]
//        public void ExtractMinutesFromSplitMessageTest()
//        {
//            string[] splitMessage = { "XXX1234", "120" };
//            Assert.AreEqual(sms.ExtractMinutes(splitMessage), "120");
//        }

//        [TestMethod]
//        public void ExtractStartingHourFromSplitMessageTest()
//        {
//            string[] splitMessage = { "XXX1234", "120", "16:20" };
//            Assert.AreEqual(sms.ExtractStartingHour(splitMessage), DateTime.Parse("16:20"));
//        }

//        [TestMethod]
//        public void Initialize()
//        {
//            string message = "ABC 1234 120 16:00";
//            sms.Initialize(message);
//            Assert.IsTrue(sms.Plates == "ABC1234" && sms.Minutes == "120"
//                && sms.StartingHour == DateTime.Parse("16:00")
//                && sms.EndingHour == DateTime.Parse("18:00"));
//        }


//        [TestMethod]
//        public void ValidateCorrectTest()
//        {
//            Notification notification;
//            string message = $"ABC 1234 120 16:00";
//            sms.Initialize(message);
//            notification = sms.Validate(DateTime.Parse("14:00"));
//            Assert.IsFalse(notification.HasErrors());
//        }

//        [TestMethod]
//        public void ValidateCorrectNoHourTest()
//        {
//            Notification notification;
//            string message = $"ABC 1234 60";
//            double minutes = 120;
//            DateTime lowerLimitForTest = DateTime.Parse("10:00");
//            DateTime upperLimitForTest = DateTime.Now.AddMinutes(minutes);
//            Sms sms = new Sms(lowerLimitForTest, upperLimitForTest);
//            sms.Initialize(message);
//            notification = sms.Validate(DateTime.Now);
//            Assert.IsFalse(notification.HasErrors());
//        }

//        [TestMethod]
//        public void MissingInputTest()
//        {
//            string input = "";
//            Assert.IsTrue(sms.MissingInput(input));
//        }

//        [TestMethod]
//        public void ValidateMinutesNotMultipleOf30Test()
//        {
//            string minutes = "70";
//            sms.Minutes = minutes;
//            Assert.IsFalse(sms.ValidateMinutes());
//        }

//        [TestMethod]
//        public void ValidateMinutesIsMultipleOf30Test()
//        {
//            string minutes = "60";
//            sms.Minutes = minutes;
//            Assert.IsTrue(sms.ValidateMinutes());
//        }

//        [TestMethod]
//        public void ValidateMinutesIsNotIntegerTest()
//        {
//            string minutes = "60.1";
//            sms.Minutes = minutes;
//            Assert.IsFalse(sms.ValidateMinutes());
//        }

//        [TestMethod]
//        public void ValidateMinutesIsNotNegativeTest()
//        {
//            string minutes = "-60";
//            sms.Minutes = minutes;
//            Assert.IsFalse(sms.ValidateMinutes());
//        }

//        [TestMethod]
//        public void IsValidateStartingHourFormatTrueTest()
//        {
//            string[] startingHour = { "12:15" };
//            sms.StartingHour = sms.ExtractStartingHour(startingHour);
//            Assert.IsTrue(sms.IsValidHourFormat());
//        }

//        [TestMethod]
//        public void IsValidateStartingHourFormatFalseTest()
//        {
//            string [] startingHour = { "120:15" };
//            sms.StartingHour = sms.ExtractStartingHour(startingHour);
//            Assert.IsFalse(sms.IsValidHourFormat());
//        }

//        [TestMethod]
//        public void IsWithinRangeOfHoursTrueTest()
//        {
//            string startingHour = "10:30";
//            sms.StartingHour = DateTime.Parse(startingHour);
//            Assert.IsTrue(sms.IsWithinRangeOfHours());
//        }

//        [TestMethod]
//        public void IsWithinRangeOfHoursFalseTest()
//        {
//            string startingHour = "09:30";
//            sms.StartingHour = DateTime.Parse(startingHour);
//            Assert.IsFalse(sms.IsWithinRangeOfHours());
//        }

//        [TestMethod]
//        public void StartingHourIsForTodayTrueTest()
//        {

//            string startingHour = "12:00";
//            sms.StartingHour = DateTime.Parse(startingHour);
//            Assert.IsTrue(sms.IsHourForToday(DateTime.Parse("11:00")));

//        }

//        [TestMethod]
//        public void StartingHourIsForTodayFalseTest()
//        {
//            string startingHour = "10:30";
//            sms.StartingHour = DateTime.Parse(startingHour);
//            DateTime dt = DateTime.Parse("11:00");
//            Assert.IsFalse(sms.IsHourForToday(DateTime.Parse("11:00")));
//        }

//        [TestMethod]
//        public void SetEndingHourTest()
//        {
//            sms.Minutes = "60";
//            sms.StartingHour = DateTime.Parse("10:00");
//            sms.EndingHour = sms.SetEndingHour();

//            Assert.AreEqual(sms.EndingHour, DateTime.Parse("11:00"));
//        }

//        [TestMethod]
//        public void SetEndingHourEndsLaterThanMaxEndingHourTest()
//        { 
//            sms.Minutes = "60";
//            sms.StartingHour = DateTime.Parse("17:30");
//            sms.EndingHour = sms.SetEndingHour();
        
//            Assert.AreEqual(sms.EndingHour, DateTime.Parse("18:00"));
//        }


//    }
//}
