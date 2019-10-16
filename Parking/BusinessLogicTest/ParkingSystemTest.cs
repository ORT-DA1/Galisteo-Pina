using System;
using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace BusinessLogicTest
{
    [TestClass]
    public class ParkingSystemTest
    {
        ParkingSystem system;
        Notification notification;
        Purchase purchase;
        Sms sms;
        Account account;
        DateTime hourForTest;
        DateTime lowerLimit;
        DateTime upperLimit;

        [TestInitialize]
        public void Initialize()
        {
            system = new ParkingSystem();
            notification = new Notification();
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
        public void AddAccountTest()
        {
            system.AddAccount("099270471");
            Assert.IsTrue(system.AccountRepository.ThereAreRecordedAccounts());
        }

        [TestMethod]
        public void AddAccountFalseWrongCellphoneFormatTest()
        {
            system.AddAccount("9270471");
            Assert.IsFalse(system.AccountRepository.ThereAreRecordedAccounts());
        }


        [TestMethod]
        public void SystemAddBalanceTest()
        {
            system.AddAccount("098960505");
            system.AddAmmountToBalance("098960505", "100");
            Account account = system.AccountRepository.FindAccountByCellPhoneNumber("098960505");
            Assert.IsTrue(account.AccountBalance == 100);
        }

        [TestMethod]
        public void SystemAddBalanceZeroTest()
        {
            system.AddAccount("098960505");
            system.AddAmmountToBalance("098960505", "");
            Account account = system.AccountRepository.FindAccountByCellPhoneNumber("098960505");
            Assert.IsTrue(account.AccountBalance == 0);
        }

        [TestMethod]
        public void SystemAddBalanceNegativeTest()
        {
            system.AddAccount("098960505");
            system.AddAmmountToBalance("098960505", "-100");
            Account account = system.AccountRepository.FindAccountByCellPhoneNumber("098960505");
            Assert.IsTrue(account.AccountBalance == 0);
        }


        [TestMethod]
        public void AddPurchaseTrueTest()
        {
            system.AddPurchase(purchase);
            Assert.IsTrue(system.PurchaseRepository.ThereAreRecordedPurchases());
        }

        [TestMethod]
        public void AddPurchaseNoStartingHourTrueTest()
        {
            string smsMessage = "ABC 1234 120";
            sms.Initialize(smsMessage);
            purchase = new Purchase(sms, account);
            system.AddPurchase(purchase);
            Assert.IsTrue(system.PurchaseRepository.ThereAreRecordedPurchases());
        }

        [TestMethod]
        public void AddPurchaseNoBalanceFalseTest()
        {
            account = new Account("098960505");
            string smsMessage = "ABC 1234 120";
            sms.Initialize(smsMessage);
            purchase = new Purchase(sms, account);
            system.AddPurchase(purchase);
            Assert.IsFalse(system.PurchaseRepository.ThereAreRecordedPurchases());

        }

        [TestMethod]
        public void FormatSmsForPurchase()
        {
            string smsMessage = $"ABC 1234 120 14:00";
            Sms sms = system.FormatSmsForPurchase(smsMessage);
            Sms smsToCompare = new Sms();
            smsToCompare.Plates = "ABC1234";
            smsToCompare.Minutes = "120";
            smsToCompare.StartingHour = DateTime.Parse("14:00");
            smsToCompare.EndingHour = DateTime.Parse("16:00");
            Assert.AreEqual(sms, smsToCompare);
        }

        [TestMethod]
        public void ValidateSmsTest()
        {
            Assert.IsFalse(system.ValidateSms(sms).HasErrors());
        }

        [TestMethod]
        public void IsRegisteredNumberTrueTest()
        {
            system.AddAccount("098125342");
            notification = system.IsRegisteredNumber("098125342");
            Assert.IsTrue(!notification.HasErrors());
        }

        [TestMethod]
        public void IsRegisteredNumberFalseTest()
        {
            system.AddAccount("098125342");
            notification = system.IsRegisteredNumber("098888888");
            Assert.IsTrue(notification.HasErrors());
        }

        [TestMethod]
        public void IsRegisteredNumberNoAccountsInSystemFalseTest()
        {
            notification = system.IsRegisteredNumber("098888888");
            Assert.IsTrue(notification.HasErrors());
        }

        [TestMethod]
        public void GetAccountByPhoneNumberTrueTest()
        {
            system.AddAccount("098125342");
            Assert.IsTrue(system.GetAccountByPhoneNumber("098125342").AccountCellPhoneNumber == "098125342");
        }

        [TestMethod]
        public void GetAccountByPhoneNumberTest()
        {
            system.AddAccount("098125342");
            Assert.IsTrue(system.GetAccountByPhoneNumber("098111222") == null);
        }


        [TestMethod]
        public void AnyPurchaseMatchesPlatesAndHourTrueTest()
        {
            system.AddPurchase(purchase);
            Assert.IsTrue(system.AnyPurchaseMatchesPlateAndHour("ABC1234", hourForTest.ToString("HH:mm")).HasSuccess());

        }

        [TestMethod]
        public void AnyPurchaseMatchesPlatesAndHourWrongPlateFalseTest()
        {
            system.AddPurchase(purchase);
            Assert.IsFalse(system.AnyPurchaseMatchesPlateAndHour("JVC5432", hourForTest.ToString("HH:mm")).HasSuccess());

        }

        [TestMethod]
        public void AnyPurchaseMatchesEmptyPlatesFalseTest()
        {
            system.AddPurchase(purchase);
            Assert.IsFalse(system.AnyPurchaseMatchesPlateAndHour("", hourForTest.ToString("HH:mm")).HasSuccess());

        }

        [TestMethod]
        public void AnyPurchaseMatchesEmptyHourFalseTest()
        {
            system.AddPurchase(purchase);
            Assert.ThrowsException<FormatException>(() => system.AnyPurchaseMatchesPlateAndHour("ABC1234", "").HasSuccess());

        }

        [TestMethod]
        public void AdjustParkingCostPerMinuteTest()
        {
            system.AdjustParkingCostPerMinute(2);
            Assert.AreEqual(ParkingCost.CostPerMinute, 2);
        }
    }
}

