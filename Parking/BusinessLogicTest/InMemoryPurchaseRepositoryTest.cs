using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;

namespace BusinessLogicTest
{

    [TestClass]
    public class InMemoryPurchaseRepositoryTest
    {
        InMemoryPurchaseRepository purchases;
        Sms sms;

        [TestInitialize]
        public void TestInitialize()
        {
            purchases = new InMemoryPurchaseRepository();
            sms = new Sms();
        }


        [TestMethod]
        public void AddPurchaseTrueTest()
        {
            DateTime hourForTest = DateTime.Now.AddMinutes(1);
            string sms = $"ABC 1234 120 {hourForTest.ToString("HH:mm")}";
            Account account = new Account("098 712 712", 200);
            purchases.AddPurchase(account, sms);
            Assert.IsTrue(purchases.PurchasesRecord.Count == 1);
        }

        [TestMethod]
        public void AddPurchaseFalseNoBalanceTest()
        {
            string sms = "ABC 1234 120 16:00";
            Account account = new Account("098 712 712");
            purchases.AddPurchase(account, sms);
            Assert.IsFalse(purchases.PurchasesRecord.Count == 1);
        }

        [TestMethod]
        public void ThereAreRecordedPurchasesTrueTest()
        {
            DateTime hourForTest = DateTime.Now.AddMinutes(1);
            string sms = $"ABC 1234 120 {hourForTest.ToString("HH:mm")}";
            Account account = new Account("098 712 712", 200);
            purchases.AddPurchase(account, sms);
            Assert.IsTrue(purchases.ThereAreRecordedPurchases());
        }

        [TestMethod]
        public void ThereAreRecordedPurchasesFalseTest()
        {
            Assert.IsFalse(purchases.ThereAreRecordedPurchases());
        }


        [TestMethod]
        public void AnyPurchaseMatchesAndHourPlateTrueTest()
        {
            DateTime hourForTest = DateTime.Now.AddMinutes(1);
            string sms = $"ABC 1234 120 {hourForTest.ToString("HH:mm")}";
            Account account = new Account("098 712 712", 200);
            purchases.AddPurchase(account, sms);
            Assert.IsTrue(purchases.AnyPurchaseMatchesPlateAndDateTime("ABC1234", "17:00"));
        }

        [TestMethod]
        public void AnyPurchaseMatchesPlateFalseTest()
        {
            string sms = "ABC 1234 120 16:00";
            Account account = new Account("098 712 712", 200);
            purchases.AddPurchase(account, sms);
            Assert.IsFalse(purchases.AnyPurchaseMatchesPlateAndDateTime("JCV1234", "17:00"));
        }


        [TestMethod]
        public void AnyPurchaseMatchesHourFalseTest()
        {
            string sms = "ABC 1234 120 15:00";
            Account account = new Account("098 712 712", 200);
            purchases.AddPurchase(account, sms);
            Assert.IsFalse(purchases.AnyPurchaseMatchesPlateAndDateTime("ABC1234", "18:00"));
        }
    }
}
