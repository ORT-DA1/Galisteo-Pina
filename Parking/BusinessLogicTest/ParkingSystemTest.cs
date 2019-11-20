using System;
using System.Linq;
using BusinessLogic;
using Entities;
using Entities.Validation;
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
        ISmsValidator smsValidator;
        IUnitOfWork unitOfWork;

        [TestInitialize]
        public void Initialize()
        {
            system = new ParkingSystem(ParkingSystemInitializer.GetUnitOfWorkToInject(Enviroment.TEST));
            unitOfWork = system.UnitOfWork;
            notification = new Notification();
            account = new Account("098960505");
            account.AddMoneyToBalance("200");
            string smsMessage = $"ABC 1234 120 {DateTime.Now.AddMinutes(10).ToString(("HH:mm"))}";
            smsValidator = new UySmsValidator();
            sms = smsValidator.GetInitializedSms(smsMessage);
            sms.SetHourBounds(DateTime.Now, DateTime.Now.AddHours(8));
            purchase = new Purchase(sms, account);

        }

        [TestMethod]
        public void AddAccountTest()
        {
            system.AddAccount("099270471");
            account = new Account("099270471");
            Assert.IsTrue(unitOfWork.Accounts.AccountAlreadyExists(account));
        }

        [TestMethod]
        public void SystemAddBalanceTest()
        {
            system.AddAccount("098960505");
            system.AddAmmountToBalance("098960505", "100");
            Account account = unitOfWork.Accounts.FindAccountByCellPhoneNumber("098960505");
            Assert.IsTrue(account.AccountBalance == 100);
        }

        [TestMethod]
        public void SystemAddBalanceZeroTest()
        {
            system.AddAccount("098123123");
            system.AddAmmountToBalance("098123123", "");
            Account account = unitOfWork.Accounts.FindAccountByCellPhoneNumber("098123123");
            Assert.IsTrue(account.AccountBalance == 0);
        }

        [TestMethod]
        public void SystemAddBalanceNegativeTest()
        {
            system.AddAccount("098745745");
            system.AddAmmountToBalance("098745745", "-100");
            Account account = unitOfWork.Accounts.FindAccountByCellPhoneNumber("098745745");
            Assert.IsTrue(account.AccountBalance == 0);
        }


        [TestMethod]
        public void AddPurchaseTrueTest()
        {
            system.AddPurchase(purchase);
            Assert.AreEqual(unitOfWork.Purchases.GetAll().ToList().Count, 1);
        }

        [TestMethod]
        public void AddPurchaseNoBalanceFalseTest()
        {
            account = new Account("098960505");
            string smsMessage = "ABC 1234 120";
            sms = smsValidator.GetInitializedSms(smsMessage);
            sms.SetHourBounds(DateTime.Now, DateTime.Now.AddHours(8));
            purchase = new Purchase(sms, account);
            system.AddPurchase(purchase);
            Assert.AreNotEqual(unitOfWork.Purchases.GetAll().ToList().Count, 1);

        }

        [TestMethod]
        public void FormatSmsForPurchaseTest()
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
        public void FormatPhoneNumberTest()
        {
            string phoneNumberToFormat = "98125342";
            Assert.AreEqual(system.FormatPhoneNumber(phoneNumberToFormat), "098125342");
        }

        [TestMethod]
        public void FormatPhoneNumberNoChangesTest()
        {
            string phoneNumberToFormat = "098125342";
            Assert.AreEqual(system.FormatPhoneNumber(phoneNumberToFormat), "098125342");
        }

        [TestMethod]
        public void ValidateSmsTest()
        {
            Assert.IsFalse(system.ValidateSms(sms).HasErrors());
        }

        [TestMethod]
        public void ValidatePhoneNumberTest()
        {
            string phoneNumber = "098960505";
            Assert.IsTrue(!system.ValidatePhoneNumber(phoneNumber).HasErrors());
        }

        [TestMethod]
        public void ValidatePhoneNumberEmptyTest()
        {
            string phoneNumber = "";
            Assert.IsTrue(system.ValidatePhoneNumber(phoneNumber).HasErrors());
        }

        [TestMethod]
        public void ValidatePhoneNumberWrongFormatTest()
        {
            string phoneNumber = "989605";
            Assert.IsTrue(system.ValidatePhoneNumber(phoneNumber).HasErrors());
        }

        [TestMethod]
        public void ValidateExistingAccountForTransactionAccountAlreadyExistsTest()
        {
            system.AddAccount("098960505");
            Assert.IsTrue(!system.ValidateExistingAccountForAccountTransaction("098960505").HasErrors());
        }

        [TestMethod]
        public void ValidateExistingAccountForTransactionDoesNotExistTest()
        {
            Assert.IsTrue(system.ValidateExistingAccountForAccountTransaction("098655655").HasErrors());
        }

        [TestMethod]
        public void ValidateExistingAccountForAddingAccountDoesNotExistTest()
        {
            Assert.IsTrue(!system.ValidateExistingAccountForAddingAccount("0989605").HasErrors());
        }

        [TestMethod]
        public void ValidateExistingAccountForAddingAccountAlreadyExistsTest()
        {
            system.AddAccount("098960505");
            Assert.IsTrue(system.ValidateExistingAccountForAddingAccount("098960505").HasErrors());
        }

        [TestMethod]
        public void GetAccountByPhoneNumberTrueTest()
        {
            system.AddAccount("098125342");
            Assert.IsTrue(system.GetAccountByPhoneNumber("098125342").AccountCellPhoneNumber == "098125342");
        }

        [TestMethod]
        public void GetAccountByPhoneNumberNotExistsTest()
        {
            system.AddAccount("098125342");
            Assert.IsTrue(system.GetAccountByPhoneNumber("098111222") == null);
        }


        [TestMethod]
        public void AnyPurchaseMatchesPlatesAndHourTrueTest()
        {
            system.AddPurchase(purchase);
            Assert.IsTrue(system.AnyPurchaseMatchesPlateAndHour("ABC1234", DateTime.Now.AddMinutes(10).ToString("HH:mm")).HasSuccess());

        }

        [TestMethod]
        public void AnyPurchaseMatchesPlatesAndHourWrongPlateFalseTest()
        {
            system.AddPurchase(purchase);
            Assert.IsFalse(system.AnyPurchaseMatchesPlateAndHour("JVC5432", DateTime.Now.AddMinutes(10).ToString("HH:mm")).HasSuccess());

        }

        [TestMethod]
        public void AnyPurchaseMatchesEmptyPlatesFalseTest()
        {
            system.AddPurchase(purchase);
            Assert.IsFalse(system.AnyPurchaseMatchesPlateAndHour("", DateTime.Now.AddMinutes(10).ToString("HH:mm")).HasSuccess());

        }

        [TestMethod]
        public void AnyPurchaseMatchesEmptyHourFalseTest()
        {
            system.AddPurchase(purchase);
            Assert.ThrowsException<FormatException>(() => system.AnyPurchaseMatchesPlateAndHour("ABC1234", "").HasSuccess());

        }

        //        [TestMethod]
        //        public void AdjustParkingCostPerMinuteTest()
        //        {
        //            system.AdjustParkingCostPerMinute(2);
        //            Assert.AreEqual(ParkingCost.CostPerMinute, 2);
        //        }
    }
}

