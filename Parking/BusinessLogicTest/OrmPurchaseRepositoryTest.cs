using System;
using System.Data.Entity;
using Data;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogicTest
{
    [TestClass]
    public class OrmPurchaseRepositoryTest
    {
        Purchase TestPurchase { get; set; }
        ParkingContext ParkingContext { get; set; }
        OrmPurchaseRepository ormPurchaseRepository;
        Sms sms;
        Account account;
        DateTime hourForTest;
        DateTime lowerLimit;
        DateTime upperLimit;

        [TestInitialize]
        public void Initialize()
        {
            TestPurchase = new Purchase();
            ParkingContext = new ParkingContext(new DropCreateDatabaseAlways<ParkingContext>());
            ormPurchaseRepository = new OrmPurchaseRepository(ParkingContext);
            lowerLimit = DateTime.Now;
            upperLimit = lowerLimit.AddHours(8);
            sms = new Sms(lowerLimit, upperLimit);
            account = new Account("098960505");
            account.AddMoneyToBalance("200");
            hourForTest = DateTime.Now.AddMinutes(5);
            string smsMessage = $"ABC 1234 120 {hourForTest.ToString("HH:mm")}";
            sms.Initialize(smsMessage);
            TestPurchase = new Purchase(sms, account);
        }

        [TestMethod]
        public void AddPurchaseTestPass()
        {
            Assert.IsFalse(ormPurchaseRepository.AddPurchase(TestPurchase).HasErrors());

        }

        [TestMethod]
        public void FindAccountByCellPhoneNumberTestPass()
        {
            ormPurchaseRepository.AddPurchase(TestPurchase);
            ParkingContext.SaveChanges();
            Assert.IsTrue(ormPurchaseRepository.AnyPurchaseMatchesPlateAndDateTime("ABC1234", hourForTest.ToString("HH:mm")));
        }

        [TestCleanup]
        public void CleanUp()
        {
            ParkingContext.Database.Delete();
        }
    }
}
