using System;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogicTest
{
    [TestClass]
    public class UyCellPhoneValidatorTest

    {
        [TestMethod]
        public void PhoneNumberNotEmptyTrueTest()
        {
            UyCellPhoneValidator cellPhoneNumberControl = new UyCellPhoneValidator();
            Assert.IsTrue(cellPhoneNumberControl.PhoneNumberNotEmpty("098765432"));
        }

        [TestMethod]
        public void PhoneNumberNotEmptyFalseTest()
        {
            UyCellPhoneValidator cellPhoneNumberControl = new UyCellPhoneValidator();
            Assert.IsFalse(cellPhoneNumberControl.PhoneNumberNotEmpty(""));
        }

        [TestMethod]
        public void PhoneNumberCorrectFormatWithZeroTrueTest()
        {
            UyCellPhoneValidator cellPhoneNumberControl = new UyCellPhoneValidator();
            Assert.IsTrue(cellPhoneNumberControl.PhoneNumberCorrectFormat("098765432"));
        }

        [TestMethod]
        public void PhoneNumberCorrectFormatWithoutZeroTrueTest()
        {
            UyCellPhoneValidator cellPhoneNumberControl = new UyCellPhoneValidator();
            Assert.IsTrue(cellPhoneNumberControl.PhoneNumberCorrectFormat("098765432"));
        }

        [TestMethod]
        public void PhoneNumberCorrectFormatFalseTest()
        {
            UyCellPhoneValidator cellPhoneNumberControl = new UyCellPhoneValidator();
            Assert.IsFalse(cellPhoneNumberControl.PhoneNumberCorrectFormat("09876532"));
        }

        [TestMethod]
        public void NormalizePhoneNumberTest()
        {
            string cellPhoneNumberToNormalize = "098 765 432";
            UyCellPhoneValidator cellPhoneValidator = new UyCellPhoneValidator();
            Assert.AreEqual(cellPhoneValidator.NormalizePhoneNumber(cellPhoneNumberToNormalize), "098765432");
        }


        [TestMethod]
        public void PhoneNumberStartWithNineTrueTest()
        {
            UyCellPhoneValidator cellPhoneNumberControl = new UyCellPhoneValidator();
            Assert.IsTrue(cellPhoneNumberControl.PhoneNumberStartWithNine("98765432"));
        }

        [TestMethod]
        public void PhoneNumberStartWithNineFalseTest()
        {
            UyCellPhoneValidator cellPhoneNumberControl = new UyCellPhoneValidator();
            Assert.IsFalse(cellPhoneNumberControl.PhoneNumberStartWithNine("098765432"));
        }

        [TestMethod]
        public void StandarPhoneNumberTest()
        {
            UyCellPhoneValidator cellPhoneNumberControl = new UyCellPhoneValidator();
            Assert.AreEqual(cellPhoneNumberControl.StandarizePhoneNumber("98765432"), "098765432");
        }
    }
}
