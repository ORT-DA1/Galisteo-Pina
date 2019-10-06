using System;
using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogicTest
{
    [TestClass]
    public class NumberValidator
    {
        [TestMethod]
        public void CellPhoneNumberNotEmpty()
        {
            Account user = new Account();
            user.CellPhoneNumber = "098960505";
            Assert.IsTrue(user.PhoneNumberNotEmpty());
        }

        [TestMethod]
        public void CellPhoneNumberEmpty()
        {
            Account user = new Account();
            user.CellPhoneNumber = "";
            Assert.IsFalse(user.PhoneNumberNotEmpty());
        }

        [TestMethod]
        public void CellPhoneNumberStartsWhitZeroNine()
        {
            Account user = new Account();
            user.CellPhoneNumber = "098960505";
            Assert.IsTrue(user.PhoneNumberStartWhitZeroNine());
        }

        [TestMethod]
        public void CellPhoneNumberNoStartsWithZeroNine()
        {
            Account user = new Account();
            user.CellPhoneNumber = "98960505";
            Assert.IsFalse(user.PhoneNumberStartWhitZeroNine());
        }

        [TestMethod]
        public void CellPhoneNumberStartsWithNine()
        {
            Account user = new Account();
            user.CellPhoneNumber = "98960505";
            Assert.IsTrue(user.PhoneNumberStartWhitNine());
        }

        [TestMethod]
        public void CellPhoneNumberNoStartsWithNine()
        {
            Account user = new Account();
            user.CellPhoneNumber = "098960505";
            Assert.IsFalse(user.PhoneNumberStartWhitNine());
        }

        [TestMethod]
        public void CellPhoneNumberLenghtIsCorrect()
        {
            Account user = new Account();
            user.CellPhoneNumber = "098960505";
            Assert.IsTrue(user.PhoneNumberLenghtIsCorrect());
        }

        [TestMethod]
        public void CellPhoneNumberZeroNineCorrectFormat()
        {
            Account user = new Account();
            user.CellPhoneNumber = "098960505";
            Assert.IsTrue(user.PhoneNumberCorrectFormat());
        }

        [TestMethod]
        public void CellPhoneNumberNineCorrectFormat()
        {
            Account user = new Account();
            user.CellPhoneNumber = "98960505";
            Assert.IsTrue(user.PhoneNumberCorrectFormat());
        }

        [TestMethod]
        public void CellPhoneNumberIncorrectFormat()
        {
            Account user = new Account();
            user.CellPhoneNumber = "998960505";
            Assert.IsFalse(user.PhoneNumberCorrectFormat());
        }

        [TestMethod]
        public void CellPhoneNumberWithSpaceCorrectFormat()
        {
            Account user = new Account();
            user.CellPhoneNumber = "098 960 505";
            Assert.IsTrue(user.PhoneNumberCorrectFormat());
        }

        [TestMethod]
        public void CellPhoneNumberWithSpaceIncorrectFormat()
        {
            Account user = new Account();
            user.CellPhoneNumber = "898 960 505";
            Assert.IsFalse(user.PhoneNumberCorrectFormat());
        }
    }
}
