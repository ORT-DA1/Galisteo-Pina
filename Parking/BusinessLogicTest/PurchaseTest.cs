using System;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogicTest
{
    [TestClass]
    public class PurchaseTest
    {
        [TestMethod]
        public void CalculateCostForMinutesUsedTest()
        {
            Sms sms = new Sms();
            sms.StartingHour = DateTime.Parse("14:00");
            sms.EndingHour = DateTime.Parse("15:00");
            Purchase purchase = new Purchase();
            purchase.Sms = sms;
            Assert.IsTrue(purchase.CalculateCostForMinutesUsed(1) == 60);
        }

        [TestMethod]
        public void SubstractMoneyFromAccountTrueTest()
        {
            Sms sms = new Sms();
            Account account = new Account("099727232", 200);
            Purchase purchase = new Purchase(sms, account);
            Assert.IsTrue(purchase.SubstractMoneyFromAccount(200));
        }

        [TestMethod]
        public void SubstractMoneyFromAccountFalseTest()
        {
            Sms sms = new Sms();
            Account account = new Account("099727232");
            Purchase purchase = new Purchase(sms, account);
            Assert.IsFalse(purchase.SubstractMoneyFromAccount(200));
        }

    }
}
