using System;
using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogicTest
{
    [TestClass]
    public class CellPhoneNumberValidatorTest
    {
        [TestMethod]
        public void CellPhoneNumberNotEmpty()
        {
            CellPhoneValidator cellPhoneNumberControl = new CellPhoneValidator();
            string cellPhoneNumber = "098960505";
            Assert.IsTrue(cellPhoneNumberControl.PhoneNumberNotEmpty(cellPhoneNumber));
        }

        [TestMethod]
        public void CellPhoneNumberEmpty()
        {
            CellPhoneValidator cellPhoneNumberControl = new CellPhoneValidator();
            string cellPhoneNumber = "";
            Assert.IsFalse(cellPhoneNumberControl.PhoneNumberNotEmpty(cellPhoneNumber));
        }

        [TestMethod]
        public void CellPhoneNumberStartsWhitZeroNine()
        {
            CellPhoneValidator cellPhoneNumberControl = new CellPhoneValidator();
            string cellPhoneNumber = "098960505";
            Assert.IsTrue(cellPhoneNumberControl.PhoneNumberStartWhitZeroNine(cellPhoneNumber));
        }

        [TestMethod]
        public void CellPhoneNumberNoStartsWithZeroNine()
        {
            CellPhoneValidator cellPhoneNumberControl = new CellPhoneValidator();
            string cellPhoneNumber = "98960505";
            Assert.IsFalse(cellPhoneNumberControl.PhoneNumberStartWhitZeroNine(cellPhoneNumber));
        }

        [TestMethod]
        public void CellPhoneNumberStartsWithNine()
        {
            CellPhoneValidator cellPhoneNumberControl = new CellPhoneValidator();
            string cellPhoneNumber = "98960505";
            Assert.IsTrue(cellPhoneNumberControl.PhoneNumberStartWhitNine(cellPhoneNumber));
        }

        [TestMethod]
        public void CellPhoneNumberNoStartsWithNine()
        {
            CellPhoneValidator cellPhoneNumberControl = new CellPhoneValidator();
            string cellPhoneNumber = "098960505";
            Assert.IsFalse(cellPhoneNumberControl.PhoneNumberStartWhitNine(cellPhoneNumber));
        }

        [TestMethod]
        public void CellPhoneNumberLenghtIsCorrect()
        {
            CellPhoneValidator cellPhoneNumberControl = new CellPhoneValidator();
            string cellPhoneNumber = "098960505";
            Assert.IsTrue(cellPhoneNumberControl.PhoneNumberLenghtIsCorrect(cellPhoneNumber));
        }

        [TestMethod]
        public void CellPhoneNumberZeroNineCorrectFormat()
        {
            CellPhoneValidator cellPhoneNumberControl = new CellPhoneValidator();
            string cellPhoneNumber = "098960505";
            Assert.IsTrue(cellPhoneNumberControl.PhoneNumberCorrectFormat(cellPhoneNumber));
        }

        [TestMethod]
        public void CellPhoneNumberNineCorrectFormat()
        {
            CellPhoneValidator cellPhoneNumberControl = new CellPhoneValidator();
            string cellPhoneNumber = "098960505";
            Assert.IsTrue(cellPhoneNumberControl.PhoneNumberCorrectFormat(cellPhoneNumber));
        }

        [TestMethod]
        public void CellPhoneNumberIncorrectFormat()
        {
            CellPhoneValidator cellPhoneNumberControl = new CellPhoneValidator();
            string cellPhoneNumber = "8960505";
            Assert.IsFalse(cellPhoneNumberControl.PhoneNumberCorrectFormat(cellPhoneNumber));
        }

        [TestMethod]
        public void CellPhoneNumberWithSpaceCorrectFormat()
        {
            CellPhoneValidator cellPhoneNumberControl = new CellPhoneValidator();
            string cellPhoneNumber = "098 960 505";
            Assert.IsTrue(cellPhoneNumberControl.PhoneNumberCorrectFormat(cellPhoneNumber));
        }

        [TestMethod]
        public void CellPhoneNumberWithSpaceIncorrectFormat()
        {
            CellPhoneValidator cellPhoneNumberControl = new CellPhoneValidator();
            string cellPhoneNumber = "998 960 505";
            Assert.IsFalse(cellPhoneNumberControl.PhoneNumberCorrectFormat(cellPhoneNumber));
        }

    }
}
