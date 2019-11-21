using System;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogicTest
{
    [TestClass]
    public class AccountTransactionValidatorTest
    {
        [TestMethod]
        public void AccountHasBalanceForTransactionTrueTest()
        {
            Account userAccount = new Account("098960505", 150);
            AccountTransactionValidator accountTransactionValidator = new AccountTransactionValidator(userAccount, 100);
            Assert.IsTrue(accountTransactionValidator.AccountHasBalanceForTransaction());
        }
        
        [TestMethod]
        public void AccountHasBalanceForTransactionFalseTest()
        {
            Account userAccount = new Account("098960505", 150);
            AccountTransactionValidator accountTransactionValidator = new AccountTransactionValidator(userAccount, 250);
            Assert.IsFalse(accountTransactionValidator.AccountHasBalanceForTransaction());
        }

        [TestMethod]
        public void ValidateNoErrorsTest()
        {
            Account userAccount = new Account("098960505", 350);
            AccountTransactionValidator accountTransactionValidator = new AccountTransactionValidator(userAccount, 250);
            Assert.IsFalse(accountTransactionValidator.Validate().HasErrors());
        }

        [TestMethod]
        public void ValidateNoErrorsFalseTest()
        {
            Account userAccount = new Account("098960505", 150);
            AccountTransactionValidator accountTransactionValidator = new AccountTransactionValidator(userAccount, 300 );
            Assert.IsTrue(accountTransactionValidator.Validate().HasErrors());
        }
    }
}
