using System;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogicTest
{
    [TestClass]
    public class ArgCellPhoneValidatorTest
    {
        [TestMethod]
        public void PhoneNumberNotEmptyTrueTest()
        {
            ArgCellPhoneValidator cellPhoneNumberControl = new ArgCellPhoneValidator();
            Assert.IsTrue(cellPhoneNumberControl.PhoneNumberNotEmpty("123456"));
        }

        [TestMethod]
        public void PhoneNumberNotEmptyFalseTest()
        {
            ArgCellPhoneValidator cellPhoneNumberControl = new ArgCellPhoneValidator();
            Assert.IsFalse(cellPhoneNumberControl.PhoneNumberNotEmpty(""));
        }

        [TestMethod]
        public void PhoneNumberCorrectFormatEmptyFalseTest()
        {
            ArgCellPhoneValidator cellPhoneNumberControl = new ArgCellPhoneValidator();
            Assert.IsFalse(cellPhoneNumberControl.PhoneNumberCorrectFormat(""));
        }

        [TestMethod]
        public void PhoneNumberCorrectFormatWithSixDigitsTrueTest()
        {
            ArgCellPhoneValidator cellPhoneNumberControl = new ArgCellPhoneValidator();
            Assert.IsTrue(cellPhoneNumberControl.PhoneNumberCorrectFormat("123456"));
        }

        [TestMethod]
        public void PhoneNumberCorrectFormatWithSevenDigitsTrueTest()
        {
            ArgCellPhoneValidator cellPhoneNumberControl = new ArgCellPhoneValidator();
            Assert.IsTrue(cellPhoneNumberControl.PhoneNumberCorrectFormat("1234567"));
        }

        [TestMethod]
        public void PhoneNumberCorrectFormatWithEigthDigitsTrueTest()
        {
            ArgCellPhoneValidator cellPhoneNumberControl = new ArgCellPhoneValidator();
            Assert.IsTrue(cellPhoneNumberControl.PhoneNumberCorrectFormat("12345678"));
        }


        [TestMethod]
        public void PhoneNumberCorrectFormatStartsWithHyphenFalseTest()
        {
            ArgCellPhoneValidator cellPhoneNumberControl = new ArgCellPhoneValidator();
            Assert.IsFalse(cellPhoneNumberControl.PhoneNumberCorrectFormat("-2345678"));
        }


        [TestMethod]
        public void PhoneNumberCorrectFormatEndsWithHyphenFalseTest()
        {
            ArgCellPhoneValidator cellPhoneNumberControl = new ArgCellPhoneValidator();
            Assert.IsFalse(cellPhoneNumberControl.PhoneNumberCorrectFormat("2345678-"));
        }

        [TestMethod]
        public void PhoneNumberCorrectFormatStartsAndEndsWithHyphenFalseTest()
        {
            ArgCellPhoneValidator cellPhoneNumberControl = new ArgCellPhoneValidator();
            Assert.IsFalse(cellPhoneNumberControl.PhoneNumberCorrectFormat("-345678-"));
        }

        [TestMethod]
        public void PhoneNumberCorrectFormatInnerHyphenCorrectLengthTrueTest()
        {
            ArgCellPhoneValidator cellPhoneNumberControl = new ArgCellPhoneValidator();
            Assert.IsTrue(cellPhoneNumberControl.PhoneNumberCorrectFormat("134-5678"));
        }

        [TestMethod]
        public void PhoneNumberCorrectFormatInnerHyphenWrongLengthFalseTest()
        {
            ArgCellPhoneValidator cellPhoneNumberControl = new ArgCellPhoneValidator();
            Assert.IsFalse(cellPhoneNumberControl.PhoneNumberCorrectFormat("134-56"));
        }

        [TestMethod]
        public void PhoneNumberCorrectFormatSeveralInnerHyphensTrueTest()
        {
            ArgCellPhoneValidator cellPhoneNumberControl = new ArgCellPhoneValidator();
            Assert.IsTrue(cellPhoneNumberControl.PhoneNumberCorrectFormat("134---567"));
        }

        [TestMethod]
        public void PhoneNumberCorrectFormatInnerSpacesFalseTest()
        {
            ArgCellPhoneValidator cellPhoneNumberControl = new ArgCellPhoneValidator();
            Assert.IsFalse(cellPhoneNumberControl.PhoneNumberCorrectFormat("134  567"));
        }

    }
}
