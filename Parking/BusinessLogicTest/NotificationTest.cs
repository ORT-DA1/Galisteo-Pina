using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities;

namespace BusinessLogicTest
{

    [TestClass]
    public class NotificationTest
    {
        Notification notification;
        string error;
        string success;

        [TestInitialize]
        public void TestInitialize()
        {
            notification = new Notification();
            error = "An error occurred";
            success = "Success";
        }
        [TestMethod]
        public void AddErrorTest()
        {
            notification.AddError(error);
            CollectionAssert.Contains(notification.Errors, error);
        }

        [TestMethod]
        public void AddSuccessTest()
        {
            notification.AddSuccess(success);
            CollectionAssert.Contains(notification.Success, success);
        }

        [TestMethod]
        public void HasErrorsTest()
        {
            notification.AddError(error);
            Assert.IsTrue(notification.HasErrors());
        }

        [TestMethod]
        public void HasErrorsFalseTest()
        {
            Assert.IsFalse(notification.HasErrors());
        }

        [TestMethod]
        public void HasSuccessTest()
        {
            notification.AddSuccess(success);
            Assert.IsTrue(notification.HasSuccess());
        }

        [TestMethod]
        public void FornatMessagesTest()
        {
            List<string> messages = new List<string>();
            messages.Add("hola");
            messages.Add("hola de nuevo");
            Assert.AreEqual(notification.FormatMessages(messages), $"hola.\nhola de nuevo");
        }

        [TestMethod]
        public void MessageReturnErrorMessagesTest()
        {
            string error = "I am an error";
            notification.AddError(error);
            Assert.AreEqual(notification.Message(), notification.ErrorMessage());
        }

        [TestMethod]
        public void AppendNotificationMessagesTest()
        {
            Notification notification2 = new Notification();
            notification2.AddError("nay");
            notification2.AddSuccess("yay");
            notification.AppendNotificationMessages(notification2);
            Assert.IsTrue(notification2.ErrorMessage() == "nay" && notification2.SuccessMessage() == "yay");
        }

        [TestMethod]
        public void MessageReturnSuccessMessagesTest()
        {
            string success = "I am a success";
            notification.AddSuccess(success);
            Assert.AreEqual(notification.Message(), notification.SuccessMessage());
        }

        [TestMethod]
        public void ErrorMessageTest()
        {
            string error1 = "I am error number 1";
            string error2 = "And i am error number 2";
            notification.AddError(error1);
            notification.AddError(error2);
            Assert.AreEqual(notification.ErrorMessage(), $"{error1}.\n{error2}");
        }

        [TestMethod]
        public void SuccessMessageTest()
        {
            string success1 = "I am success number 1";
            string success2 = "And i am success number 2";
            notification.AddSuccess(success1);
            notification.AddSuccess(success2);
            Assert.AreEqual(notification.SuccessMessage(), $"{success1}.\n{success2}");
        }

    }
}
