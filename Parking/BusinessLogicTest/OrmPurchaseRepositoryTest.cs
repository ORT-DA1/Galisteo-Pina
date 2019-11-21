using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
            ParkingContext = new ParkingContext("ParkingContextTest", new DropCreateDatabaseAlways<ParkingContext>());
            ormPurchaseRepository = new OrmPurchaseRepository(ParkingContext);
            hourForTest = DateTime.Now.AddMinutes(5);
            string smsMessage = $"ABC 1234 120 {hourForTest.ToString("HH:mm")}";
            sms = new UySmsValidator().GetInitializedSms(smsMessage);
            sms.LowerHourLimit = DateTime.Now;
            sms.UpperHourLimit = sms.LowerHourLimit.AddHours(8);
            account = new Account("098960505");
            account.AddMoneyToBalance("200");
            TestPurchase = new Purchase(sms, account);
        }

        [TestMethod]
        public void AddPurchaseTestPass()
        {
            Assert.IsFalse(ormPurchaseRepository.AddPurchase(TestPurchase, 1).HasErrors());

        }

        [TestMethod]
        public void FindAccountByCellPhoneNumberTestPass()
        {
            ormPurchaseRepository.AddPurchase(TestPurchase, 1);
            ParkingContext.SaveChanges();
            Assert.IsTrue(ormPurchaseRepository.AnyPurchaseMatchesPlateAndDateTime("ABC1234", hourForTest.ToString("HH:mm")));
        }

        [TestMethod]
        public void GetPurchasesMatchDateAndCountryTest()
        {
            ormPurchaseRepository.AddPurchase(TestPurchase, 1);
            ParkingContext.SaveChanges();
            IEnumerable<Purchase> matchingPurchases = ormPurchaseRepository.GetPurchasesMatchDateAndCountry(TestPurchase.Sms.StartingHour, TestPurchase.Sms.EndingHour, "ABC1234");
            Assert.AreEqual(matchingPurchases.ToList().Count, 1);
        }

        [TestMethod]
        public void GetPurchasesMatchDateAndCountryWithCountryParamTest()
        {
            Country country = new Country("PARAGUAY");
            TestPurchase.Account.AccountCountry = country;
            ormPurchaseRepository.AddPurchase(TestPurchase, 1);
            ParkingContext.SaveChanges();
            IEnumerable<Purchase> matchingPurchases = ormPurchaseRepository.GetPurchasesMatchDateAndCountry(TestPurchase.Sms.StartingHour, TestPurchase.Sms.EndingHour, "ABC1234", country);
            Assert.AreEqual(matchingPurchases.ToList().Count, 1);
        }

        [TestMethod]
        public void GetPurchasesMatchDateAndCountryWithWrongDatesFalseTest()
        {
            Country country = new Country("PARAGUAY");
            TestPurchase.Account.AccountCountry = country;
            ormPurchaseRepository.AddPurchase(TestPurchase, 1);
            ParkingContext.SaveChanges();
            IEnumerable<Purchase> matchingPurchases = ormPurchaseRepository
                .GetPurchasesMatchDateAndCountry(TestPurchase.Sms.StartingHour.AddHours(2),
                TestPurchase.Sms.EndingHour.AddHours(2), "ABC1234", country);
            Assert.AreNotEqual(matchingPurchases.ToList().Count, 1);
        }

        [TestMethod]
        public void GetPurchasesMatchDateAndCountryWithCountryParamFalseTest()
        {
            Country country = new Country("NICARAGUA");
            Country country2 = new Country("CAMBODIA");
            TestPurchase.Account.AccountCountry = country;
            ormPurchaseRepository.AddPurchase(TestPurchase, 1);
            ParkingContext.SaveChanges();
            IEnumerable<Purchase> matchingPurchases = ormPurchaseRepository.GetPurchasesMatchDateAndCountry(TestPurchase.Sms.StartingHour, TestPurchase.Sms.EndingHour, "ABC1234", country2);
            Assert.AreNotEqual(matchingPurchases.ToList().Count, 1);
        }


        [TestCleanup]
        public void CleanUp()
        {
            ParkingContext.Database.Delete();
        }
    }
}
