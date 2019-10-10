using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;

namespace BusinessLogicTest
{

    [TestClass]
    public class NotificationTest
    {
        Notification notification;
        string error;

    [TestInitialize]
        public  void TestInitialize()
        {
            notification = new Notification(); 
            error = "An error occurred";
        }


        [TestMethod]
        public void AddErrorTest()
        {
            notification.AddError(error);
            CollectionAssert.Contains(notification.Errors, error);
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
        public void ErrorMessage()
        {
            string error1 = "I am error number 1";
            string error2 = "And i am error number 2";
            notification.AddError(error1);
            notification.AddError(error2);
            Assert.AreEqual(notification.ErrorMessage(), $"{error1}.{error2}");
        }
    }
}
