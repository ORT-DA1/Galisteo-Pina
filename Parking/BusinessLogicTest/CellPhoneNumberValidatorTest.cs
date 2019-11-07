using System;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogicTest
{
    [TestClass]
    public class CellPhoneNumberValidatorTest

        {
        [TestMethod]
        public void PhoneNumberNotEmptyTrueTest()
        {
            CellPhoneValidator cellPhoneNumberControl = new CellPhoneValidator("098960505");
            Assert.IsTrue(cellPhoneNumberControl.PhoneNumberNotEmpty());
        }

    [TestMethod]
        public void PhoneNumberNotEmptyFalseTest()
        {
            CellPhoneValidator cellPhoneNumberControl = new CellPhoneValidator("");
            Assert.IsFalse(cellPhoneNumberControl.PhoneNumberNotEmpty());
        }

        [TestMethod]
        public void PhoneNumberCorrectFormatWithZeroTrueTest()
        {
            CellPhoneValidator cellPhoneNumberControl = new CellPhoneValidator("098765432");
            Assert.IsTrue(cellPhoneNumberControl.PhoneNumberCorrectFormat());
        }

        [TestMethod]
        public void PhoneNumberCorrectFormatWithoutZeroTrueTest()
        {
            CellPhoneValidator cellPhoneNumberControl = new CellPhoneValidator("98765432");
            Assert.IsTrue(cellPhoneNumberControl.PhoneNumberCorrectFormat());
        }

        [TestMethod]
        public void PhoneNumberCorrectFormatFalseTest()
        {
            CellPhoneValidator cellPhoneNumberControl = new CellPhoneValidator("");
            Assert.IsFalse(cellPhoneNumberControl.PhoneNumberCorrectFormat());
        }

        [TestMethod]
        public void NormalizePhoneNumberTest()
        {
            string cellPhoneNumberToNormalize = "098 765 432";
            CellPhoneValidator cellPhoneValidator= new CellPhoneValidator();
            Assert.AreEqual(cellPhoneValidator.NormalizePhoneNumber(cellPhoneNumberToNormalize), "098765432");
        }


        [TestMethod]
        public void PhoneNumberStartWithNineTrueTest()
        {
            CellPhoneValidator cellPhoneNumberControl = new CellPhoneValidator();
            Assert.IsTrue(cellPhoneNumberControl.PhoneNumberStartWithNine("98765432"));
        }

        [TestMethod]
        public void PhoneNumberStartWithNineFalseTest()
        {
            CellPhoneValidator cellPhoneNumberControl = new CellPhoneValidator();
            Assert.IsFalse(cellPhoneNumberControl.PhoneNumberStartWithNine("098765432"));
        }

        [TestMethod]
        public void StandarPhoneNumberTest()
        {
            CellPhoneValidator cellPhoneNumberControl = new CellPhoneValidator();
            Assert.AreEqual(cellPhoneNumberControl.StandarPhoneNumber("98765432"), "098765432");
        }
    }
}
