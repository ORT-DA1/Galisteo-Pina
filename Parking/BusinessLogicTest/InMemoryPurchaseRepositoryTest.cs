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
        public void AddPurchaseTest()
        {
            Purchase purchase = new Purchase();
            purchases.AddPurchase(purchase);
            Assert.IsTrue(purchases.PurchasesRecord.Count == 1);
        }


        [TestMethod]
        public void ThereAreRecordedPurchasesTrueTest()
        {
            Purchase purchase = new Purchase();
            purchases.AddPurchase(purchase);
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
            Purchase purchase = new Purchase();
            sms.StartingHour = DateTime.Parse("14:00");
            sms.Plates = "ABC5555";
            purchase.Sms = sms;
            purchase.Sms.Minutes = "120";
            purchase.Sms.EndingHour = sms.SetEndingHour();
            purchases.AddPurchase(purchase);
            Assert.IsTrue(purchases.AnyPurchaseMatchesPlateAndDateTime("ABC5555", "15:00"));
        }

        [TestMethod]
        public void AnyPurchaseMatchesPlateFalseTest()
        {
            Purchase purchase = new Purchase();
            sms.StartingHour = DateTime.Parse("14:00");
            sms.Plates = "ABC5555";
            purchase.Sms = sms;
            purchase.Sms.Minutes = "120";
            purchase.Sms.EndingHour = sms.SetEndingHour();
            purchases.AddPurchase(purchase);
            Assert.IsFalse(purchases.AnyPurchaseMatchesPlateAndDateTime("JCV5555", "14:30"));
        }


        [TestMethod]
        public void AnyPurchaseMatchesHourFalseTest()
        {
            Purchase purchase = new Purchase();
            sms.StartingHour = DateTime.Parse("14:00");
            sms.Plates = "ABC5555";
            purchase.Sms = sms;
            purchase.Sms.Minutes = "120";
            purchase.Sms.EndingHour = sms.SetEndingHour();
            purchases.AddPurchase(purchase);
            Assert.IsFalse(purchases.AnyPurchaseMatchesPlateAndDateTime("ABC5555", "17:00"));
        }
    }
}
