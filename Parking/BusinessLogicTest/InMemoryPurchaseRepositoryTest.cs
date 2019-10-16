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
        Purchase purchase;
        Sms sms;
        Account account;
        DateTime hourForTest;
        DateTime lowerLimit;
        DateTime upperLimit;

        [TestInitialize]
        public void Initialize()
        {
            purchases = new InMemoryPurchaseRepository();
            lowerLimit = DateTime.Now;
            upperLimit = lowerLimit.AddHours(8);
            sms = new Sms(lowerLimit, upperLimit);
            account = new Account("098960505");
            account.AddMoneyToBalance("200");
            hourForTest = DateTime.Now.AddMinutes(5);
            string smsMessage = $"ABC 1234 120 {hourForTest.ToString("HH:mm")}";
            sms.Initialize(smsMessage);
            purchase = new Purchase(sms, account);
        }

        [TestMethod]
        public void AddPurchaseTrueTest()
        {
            purchases.AddPurchase(purchase);
            Assert.IsTrue(purchases.PurchasesRecord.Count == 1);
        }


        [TestMethod]
        public void ThereAreRecordedPurchasesTrueTest()
        {
            purchases.AddPurchase(purchase);
            Assert.IsTrue(purchases.ThereAreRecordedPurchases());
        }

        [TestMethod]
        public void ThereAreRecordedPurchasesFalseTest()
        {
            purchases = new InMemoryPurchaseRepository();
            Assert.IsFalse(purchases.ThereAreRecordedPurchases());
        }


        [TestMethod]
        public void AnyPurchaseMatchesAndHourPlateTrueTest()
        {
            purchases.AddPurchase(purchase);
            Assert.IsTrue(purchases.AnyPurchaseMatchesPlateAndDateTime("ABC1234", hourForTest.ToString("HH:mm")));
        }

        [TestMethod]
        public void AnyPurchaseMatchesPlateFalseTest()
        {
            purchases.AddPurchase(purchase);
            Assert.IsFalse(purchases.AnyPurchaseMatchesPlateAndDateTime("JCV1515", hourForTest.ToString("HH:mm")));
        }


        [TestMethod]
        public void AnyPurchaseMatchesHourFalseTest()
        {
            purchases.AddPurchase(purchase);
            Assert.IsFalse(purchases.AnyPurchaseMatchesPlateAndDateTime("ABC1234", lowerLimit.AddMinutes(-10).ToString("HH:mm")));
        }

        [TestMethod]
        public void AnyPurchaseMatchesEmptyPlatesTest()
        {
            purchases.AddPurchase(purchase);
            Assert.IsFalse(purchases.AnyPurchaseMatchesPlateAndDateTime("", lowerLimit.AddMinutes(-10).ToString("HH:mm")));
        }

        [TestMethod]
        public void AnyPurchaseMatchesEmptyHourTest()
        {
            purchases.AddPurchase(purchase);
            Assert.ThrowsException<FormatException>(() => purchases.AnyPurchaseMatchesPlateAndDateTime("", ""));
        }
    }
}
