//using System;
//using BusinessLogic;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace BusinessLogicTest
//{
//    [TestClass]
//    public class AccountValidatorTest
//    {
//        [TestMethod]
//        public void AccountCellPhoneNumberIsNotEmptyTest()
//        {
//            Account userAccount = new Account("098960505", 0);
//            Assert.IsTrue(userAccount.AccountCellPhoneNumberIsEmpty());
//        }

//        [TestMethod]
//        public void AccountCellPhoneNumberIsEmptyTest()
//        {
//            Account userAccount = new Account("", 0);
//            Assert.IsFalse(userAccount.AccountCellPhoneNumberIsEmpty());
//        }

//        [TestMethod]
//        public void AccountCellPhoneNumberFormatIsCorrectTest()
//        {
//            Account userAccount = new Account("098960505", 0);
//            Assert.IsTrue(userAccount.AccountCellPhoneNumberFormatIsCorrect());
//        }

//        [TestMethod]
//        public void AccountCellPhoneNumberFormatIsIncorrectTest()
//        {
//            Account userAccount = new Account("0928960505", 0);
//            Assert.IsFalse(userAccount.AccountCellPhoneNumberFormatIsCorrect());
//        }

//        [TestMethod]
//        public void AccountBalanceIsPositiveTest()
//        {
//            Account userAccount = new Account("098960505", 0);
//            Assert.IsTrue(userAccount.AccountBalanceIsPositive());
//        }

//        [TestMethod]
//        public void AccountBalanceAddMoneyTest()
//        {
//            int moneyToAdd = 10;
//            Account userAccount = new Account("098960505", 0);
//            userAccount.AddMoneyToBalance(moneyToAdd);
//            Assert.AreEqual(moneyToAdd, userAccount.AccountBalance);
//        }

//        [TestMethod]
//        public void AccountBalanceSustractMoneyTest()
//        {
//            int moneyToSustract = 10;
//            Account userAccount = new Account("098960505", 0);
//            userAccount.AccountBalance = 10;
//            Assert.IsTrue(userAccount.SustractMoneyToBalance(moneyToSustract));
//            Assert.AreEqual(0, userAccount.AccountBalance);
//        }
//    }
//}
