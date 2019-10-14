//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using BusinessLogic;

//namespace BusinessLogicTest
//{
//    [TestClass]
//    public class BalanceValidatorTest
//    {
//        [TestMethod]
//        public void BalanceIsIntegerNumber()
//        {
//            BalanceValidator phoneBalance = new BalanceValidator();
//            string balance = "10";
//            Assert.IsTrue(phoneBalance.BalanceIsIntegerNumber(balance));
//        }

//        [TestMethod]
//        public void BalanceIsNotIntegerNumber()
//        {
//            BalanceValidator phoneBalance = new BalanceValidator();
//            string balance = "10.10";
//            Assert.IsFalse(phoneBalance.BalanceIsIntegerNumber(balance));
//        }

//        [TestMethod]
//        public void BalanceIsNormalized()
//        {
//            BalanceValidator phoneBalance = new BalanceValidator();
//            string balance = "10";
//            Assert.AreEqual(10, phoneBalance.NormalizedBalance(balance));
//        }

//        [TestMethod]
//        public void BalanceIsPositiveNumber()
//        {
//            BalanceValidator phoneBalance = new BalanceValidator();
//            string balance = "10";
//            Assert.IsTrue(phoneBalance.BalanceIsPositiveNumber(balance));
//        }

//        [TestMethod]
//        public void BalanceIsNotPositiveNumber()
//        {
//            BalanceValidator phoneBalance = new BalanceValidator();
//            string balance = "-10";
//            Assert.IsFalse(phoneBalance.BalanceIsPositiveNumber(balance));
//        }

//        [TestMethod]
//        public void BalanceIsCorrectTest()
//        {
//            BalanceValidator phoneBalance = new BalanceValidator();
//            string balance = "10";
//            Assert.IsTrue(phoneBalance.BalanceIsCorrect(balance));
//        }

//    }
//}
