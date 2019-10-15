using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;

namespace BusinessLogicTest
{
    [TestClass]
    public class BalanceValidatorTest
    {
        [TestMethod]
        public void ValidateTrueTest()
        {
            string balance = "10";
            BalanceValidator phoneBalance = new BalanceValidator(balance);
            Assert.IsTrue(!phoneBalance.Validate().HasErrors());
        }

        [TestMethod]
        public void ValidateEmptyTest()
        {
            string balance = "";
            BalanceValidator phoneBalance = new BalanceValidator(balance);
            Assert.IsTrue(phoneBalance.Validate().HasErrors());
        }

        [TestMethod]
        public void ValidateIntegerFalseTest()
        {
            string balance = "10.10";
            BalanceValidator phoneBalance = new BalanceValidator(balance);
            Assert.IsTrue(phoneBalance.Validate().HasErrors());
        }

    }
}
