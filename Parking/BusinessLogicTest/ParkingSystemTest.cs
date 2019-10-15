using System;
using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace BusinessLogicTest
{
    [TestClass]
    public class ParkingSystemTest
    {

        Notification notification;

        [TestInitialize]
        public void Initialize()
        {
            notification = new Notification();
        }

        [TestMethod]
        public void AddAccountTest()
        {
            ParkingSystem system = new ParkingSystem();
            system.AddAccount("099270471");
            Assert.IsTrue(system.AccountRepository.ThereAreRecordedAccounts());
        }

        [TestMethod]
        public void AddAccountFalseWrongCellphoneFormatTest()
        {
            ParkingSystem system = new ParkingSystem();
            system.AddAccount("9270471");
            Assert.IsFalse(system.AccountRepository.ThereAreRecordedAccounts());
        }


        [TestMethod]
        public void SystemAddBalanceTest()
        {
            ParkingSystem system = new ParkingSystem();
            system.AddAccount("098960505");
            system.AddAmmountToBalance("098960505", "100");
            Account account = system.AccountRepository.FindAccountByCellPhoneNumber("098960505");
            Assert.IsTrue(account.AccountBalance == 100);
        }

        [TestMethod]
        public void SystemAddBalanceZeroTest()
        {
            ParkingSystem system = new ParkingSystem();
            system.AddAccount("098960505");
            system.AddAmmountToBalance("098960505", "");
            Account account = system.AccountRepository.FindAccountByCellPhoneNumber("098960505");
            Assert.IsTrue(account.AccountBalance == 0);
        }

        [TestMethod]
        public void SystemAddBalanceNegativeTest()
        {
            ParkingSystem system = new ParkingSystem();
            system.AddAccount("098960505");
            system.AddAmmountToBalance("098960505", "-100");
            Account account = system.AccountRepository.FindAccountByCellPhoneNumber("098960505");
            Assert.IsTrue(account.AccountBalance == 0);
        }


        [TestMethod]
        public void AddPurchaseTrueTest()
        {
            ParkingSystem system = new ParkingSystem();
            system.AddAccount("098960505");
            system.AddAmmountToBalance("098960505", "200");
            DateTime hourForTest = DateTime.Now.AddMinutes(1);
            string sms = $"ABC 1234 120 {hourForTest.ToString("HH:mm")}";
            system.AddPurchase("098960505", sms);
            Assert.IsTrue(system.PurchaseRepository.ThereAreRecordedPurchases());
        }

        [TestMethod]
        public void AddPurchaseNoStartingHourTrueTest()
        {
            ParkingSystem system = new ParkingSystem();
            system.AddAccount("098960505");
            system.AddAmmountToBalance("098960505", "200");
            system.AddPurchase("098960505", "ABC 1234 120");
            Assert.IsTrue(system.PurchaseRepository.ThereAreRecordedPurchases());

        }

        [TestMethod]
        public void AddPurchaseNoBalanceFalseTest()
        {
            ParkingSystem system = new ParkingSystem();
            system.AddAccount("098960505");
            DateTime hourForTest = DateTime.Now.AddMinutes(1);
            string sms = $"ABC 1234 120 {hourForTest.ToString("HH:mm")}";
            system.AddPurchase("098960505", sms);
            Assert.IsFalse(system.PurchaseRepository.ThereAreRecordedPurchases());

        }

        [TestMethod]
        public void AddPurchaseWrongHourFalseTest()
        {
            ParkingSystem system = new ParkingSystem();
            system.AddAccount("098960505");
            system.AddAmmountToBalance("098960505", "200");
            DateTime hourForTest = DateTime.Now.AddMinutes(-1);
            string sms = $"ABC 1234 120 {hourForTest.ToString("HH:mm")}";
            system.AddPurchase("098960505", sms);
            Assert.IsFalse(system.PurchaseRepository.ThereAreRecordedPurchases());

        }

        [TestMethod]
        public void AnyPurchaseMatchesPlatesAndHourTrueTest()
        {
            ParkingSystem system = new ParkingSystem();
            system.AddAccount("098960505");
            system.AddAmmountToBalance("098960505", "200");
            DateTime hourForTest = DateTime.Now.AddMinutes(1);
            string sms = $"ABC 1234 120 {hourForTest.ToString("HH:mm")}";
            system.AddPurchase("098960505", sms);
            Assert.IsTrue(system.AnyPurchaseMatchesPlateAndHour("ABC1234", hourForTest.ToString("HH:mm")).HasSuccess());

        }

        [TestMethod]
        public void AnyPurchaseMatchesPlatesAndHourWrongPlateFalseTest()
        {
            ParkingSystem system = new ParkingSystem();
            system.AddAccount("098960505");
            system.AddAmmountToBalance("098960505", "200");
            DateTime hourForTest = DateTime.Now.AddMinutes(1);
            string sms = $"ABC 1234 120 {hourForTest.ToString("HH:mm")}";
            system.AddPurchase("098960505", sms);
            Assert.IsFalse(system.AnyPurchaseMatchesPlateAndHour("JVC1234", hourForTest.ToString("HH:mm")).HasSuccess());

        }

        [TestMethod]
        public void AnyPurchaseMatchesEmptyPlatesFalseTest()
        {
            ParkingSystem system = new ParkingSystem();
            system.AddAccount("098960505");
            system.AddAmmountToBalance("098960505", "200");
            DateTime hourForTest = DateTime.Now.AddMinutes(1);
            string sms = $"ABC 1234 120 {hourForTest.ToString("HH:mm")}";
            system.AddPurchase("098960505", sms);
            Assert.IsFalse(system.AnyPurchaseMatchesPlateAndHour("", hourForTest.ToString("HH:mm")).HasSuccess());

        }

        [TestMethod]
        public void AnyPurchaseMatchesEmptyHourFalseTest()
        {
            ParkingSystem system = new ParkingSystem();
            system.AddAccount("098960505");
            system.AddAmmountToBalance("098960505", "200");
            DateTime hourForTest = DateTime.Now.AddMinutes(1);
            string sms = $"ABC 1234 120 {hourForTest.ToString("HH:mm")}";
            system.AddPurchase("098960505", sms);
            Assert.ThrowsException<FormatException>(() => system.AnyPurchaseMatchesPlateAndHour("ABC1234", "").HasSuccess());
     
        }
    }
}

