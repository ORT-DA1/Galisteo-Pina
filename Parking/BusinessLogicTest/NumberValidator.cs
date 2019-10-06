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
            CellPhoneValidator user = new CellPhoneValidator();
            user.CellPhoneNumber = "098960505";
            Assert.IsTrue(user.PhoneNumberNotEmpty());
        }

        [TestMethod]
        public void CellPhoneNumberEmpty()
        {
            CellPhoneValidator user = new CellPhoneValidator();
            user.CellPhoneNumber = "";
            Assert.IsFalse(user.PhoneNumberNotEmpty());
        }

        [TestMethod]
        public void CellPhoneNumberStartsWhitZeroNine()
        {
            CellPhoneValidator user = new CellPhoneValidator();
            user.CellPhoneNumber = "098960505";
            Assert.IsTrue(user.PhoneNumberStartWhitZeroNine());
        }

        [TestMethod]
        public void CellPhoneNumberNoStartsWithZeroNine()
        {
            CellPhoneValidator user = new CellPhoneValidator();
            user.CellPhoneNumber = "98960505";
            Assert.IsFalse(user.PhoneNumberStartWhitZeroNine());
        }

        [TestMethod]
        public void CellPhoneNumberStartsWithNine()
        {
            CellPhoneValidator user = new CellPhoneValidator();
            user.CellPhoneNumber = "98960505";
            Assert.IsTrue(user.PhoneNumberStartWhitNine());
        }

        [TestMethod]
        public void CellPhoneNumberNoStartsWithNine()
        {
            CellPhoneValidator user = new CellPhoneValidator();
            user.CellPhoneNumber = "098960505";
            Assert.IsFalse(user.PhoneNumberStartWhitNine());
        }

        [TestMethod]
        public void CellPhoneNumberLenghtIsCorrect()
        {
            CellPhoneValidator user = new CellPhoneValidator();
            user.CellPhoneNumber = "098960505";
            Assert.IsTrue(user.PhoneNumberLenghtIsCorrect());
        }

        [TestMethod]
        public void CellPhoneNumberZeroNineCorrectFormat()
        {
            CellPhoneValidator user = new CellPhoneValidator();
            user.CellPhoneNumber = "098960505";
            Assert.IsTrue(user.PhoneNumberCorrectFormat());
        }

        [TestMethod]
        public void CellPhoneNumberNineCorrectFormat()
        {
            CellPhoneValidator user = new CellPhoneValidator();
            user.CellPhoneNumber = "98960505";
            Assert.IsTrue(user.PhoneNumberCorrectFormat());
        }

        [TestMethod]
        public void CellPhoneNumberIncorrectFormat()
        {
            CellPhoneValidator user = new CellPhoneValidator();
            user.CellPhoneNumber = "998960505";
            Assert.IsFalse(user.PhoneNumberCorrectFormat());
        }

        [TestMethod]
        public void CellPhoneNumberWithSpaceCorrectFormat()
        {
            CellPhoneValidator user = new CellPhoneValidator();
            user.CellPhoneNumber = "098 960 505";
            Assert.IsTrue(user.PhoneNumberCorrectFormat());
        }

        [TestMethod]
        public void CellPhoneNumberWithSpaceIncorrectFormat()
        {
            CellPhoneValidator user = new CellPhoneValidator();
            user.CellPhoneNumber = "898 960 505";
            Assert.IsFalse(user.PhoneNumberCorrectFormat());
        }
    }
}
