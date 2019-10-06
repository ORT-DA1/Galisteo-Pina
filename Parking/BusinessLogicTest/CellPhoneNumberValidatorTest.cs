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
            cellPhoneNumberControl.CellPhoneNumber = "098960505";
            Assert.IsTrue(cellPhoneNumberControl.PhoneNumberNotEmpty());
        }

        [TestMethod]
        public void CellPhoneNumberEmpty()
        {
            CellPhoneValidator cellPhoneNumberControl = new CellPhoneValidator();
            cellPhoneNumberControl.CellPhoneNumber = "";
            Assert.IsFalse(cellPhoneNumberControl.PhoneNumberNotEmpty());
        }

        [TestMethod]
        public void CellPhoneNumberStartsWhitZeroNine()
        {
            CellPhoneValidator cellPhoneNumberControl = new CellPhoneValidator();
            cellPhoneNumberControl.CellPhoneNumber = "098960505";
            Assert.IsTrue(cellPhoneNumberControl.PhoneNumberStartWhitZeroNine());
        }

        [TestMethod]
        public void CellPhoneNumberNoStartsWithZeroNine()
        {
            CellPhoneValidator cellPhoneNumberControl = new CellPhoneValidator();
            cellPhoneNumberControl.CellPhoneNumber = "98960505";
            Assert.IsFalse(cellPhoneNumberControl.PhoneNumberStartWhitZeroNine());
        }

        [TestMethod]
        public void CellPhoneNumberStartsWithNine()
        {
            CellPhoneValidator cellPhoneNumberControl = new CellPhoneValidator();
            cellPhoneNumberControl.CellPhoneNumber = "98960505";
            Assert.IsTrue(cellPhoneNumberControl.PhoneNumberStartWhitNine());
        }

        [TestMethod]
        public void CellPhoneNumberNoStartsWithNine()
        {
            CellPhoneValidator cellPhoneNumberControl = new CellPhoneValidator();
            cellPhoneNumberControl.CellPhoneNumber = "098960505";
            Assert.IsFalse(cellPhoneNumberControl.PhoneNumberStartWhitNine());
        }

        [TestMethod]
        public void CellPhoneNumberLenghtIsCorrect()
        {
            CellPhoneValidator cellPhoneNumberControl = new CellPhoneValidator();
            cellPhoneNumberControl.CellPhoneNumber = "098960505";
            Assert.IsTrue(cellPhoneNumberControl.PhoneNumberLenghtIsCorrect());
        }

        [TestMethod]
        public void CellPhoneNumberZeroNineCorrectFormat()
        {
            CellPhoneValidator cellPhoneNumberControl = new CellPhoneValidator();
            cellPhoneNumberControl.CellPhoneNumber = "098960505";
            Assert.IsTrue(cellPhoneNumberControl.PhoneNumberCorrectFormat());
        }

        [TestMethod]
        public void CellPhoneNumberNineCorrectFormat()
        {
            CellPhoneValidator cellPhoneNumberControl = new CellPhoneValidator();
            cellPhoneNumberControl.CellPhoneNumber = "98960505";
            Assert.IsTrue(cellPhoneNumberControl.PhoneNumberCorrectFormat());
        }

        [TestMethod]
        public void CellPhoneNumberIncorrectFormat()
        {
            CellPhoneValidator cellPhoneNumberControl = new CellPhoneValidator();
            cellPhoneNumberControl.CellPhoneNumber = "998960505";
            Assert.IsFalse(cellPhoneNumberControl.PhoneNumberCorrectFormat());
        }

        [TestMethod]
        public void CellPhoneNumberWithSpaceCorrectFormat()
        {
            CellPhoneValidator cellPhoneNumberControl = new CellPhoneValidator();
            cellPhoneNumberControl.CellPhoneNumber = "098 960 505";
            Assert.IsTrue(cellPhoneNumberControl.PhoneNumberCorrectFormat());
        }

        [TestMethod]
        public void CellPhoneNumberWithSpaceIncorrectFormat()
        {
            CellPhoneValidator cellPhoneNumberControl = new CellPhoneValidator();
            cellPhoneNumberControl.CellPhoneNumber = "898 960 505";
            Assert.IsFalse(cellPhoneNumberControl.PhoneNumberCorrectFormat());
        }
 
    }
}
