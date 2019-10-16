using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;

namespace BusinessLogicTest
{

    [TestClass]
    public class AccountTest
    {

        [TestMethod]
        public void AccountBalanceIsPositiveTrueTest()
        {
            Account account = new Account("099720720");
            account.AccountBalance = 200;
            Assert.IsTrue(account.AccountBalanceIsPositive());
        }

        [TestMethod]
        public void AccountBalanceIsPositiveZeroTrueTest()
        {
            Account account = new Account("099720720");
            account.AccountBalance = 0;
            Assert.IsTrue(account.AccountBalanceIsPositive());
        }

        [TestMethod]
        public void AccountBalanceIsPositiveFalseTest()
        {
            Account account = new Account("099720720");
            account.AccountBalance = -200;
            Assert.IsFalse(account.AccountBalanceIsPositive());
        }
        [TestMethod]
        public void AddMoneyToBalanceTest()
        {
            Account account = new Account("099720720");
            account.AccountBalance = 200;
            account.AddMoneyToBalance("200");
            Assert.IsTrue(account.AccountBalance == 400);
        }

        [TestMethod]
        public void AddMoneyToBalanceFromZeroTest()
        {
            Account account = new Account("099720720");
            account.AddMoneyToBalance("200");
            Assert.IsTrue(account.AccountBalance == 200);
        }

        [TestMethod]
        public void SubstractMoneyFromBalanceTest()
        {
            Account account = new Account("099720720");
            account.AddMoneyToBalance("200");
            account.SubstractMoneyFromBalance(200);
            Assert.IsTrue(account.AccountBalance == 0);
        }

        [TestMethod]
        public void SubstractMoneyFromBalanceSubstractZeroTest()
        {
            Account account = new Account("099720720");
            account.AddMoneyToBalance("200");
            account.SubstractMoneyFromBalance(0);
            Assert.IsTrue(account.AccountBalance == 200);
        }

        [TestMethod]
        public void SubstractMoneyFromBalanceSubstractNegativeTest()
        {
            Account account = new Account("099720720");
            account.AddMoneyToBalance("200");
            Assert.IsFalse(account.SubstractMoneyFromBalance(400));
        }

    }
}
