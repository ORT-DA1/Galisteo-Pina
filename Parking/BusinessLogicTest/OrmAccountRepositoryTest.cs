using System;
using System.Data.Entity;
using Data;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BusinessLogicTest
{
    [TestClass]
    public class OrmAccountRepositoryTest
    {
        Account TestAccount { get; set; }
        ParkingContext ParkingContext { get; set; }
        OrmAccountRepository ormAccountRepository;

        [TestInitialize]
        public void Initialize()
        {
            Country country = new Country("URUGUAY");
            TestAccount = new Account("099730280", country);
            ParkingContext = new ParkingContext("ParkingContextTest", new DropCreateDatabaseAlways<ParkingContext>());
            ormAccountRepository = new OrmAccountRepository(ParkingContext);
            
        }

        [TestMethod]
        public void AddAccountTestPass()
        {
            Assert.IsFalse(ormAccountRepository.AddAccount(TestAccount).HasErrors());
            ParkingContext.SaveChanges();
        }

        [TestMethod]
        public void AccountAlreadyExistsTestPass()
        {
            ormAccountRepository.AddAccount(TestAccount);
            ParkingContext.SaveChanges();
            Assert.IsTrue(ormAccountRepository.AccountAlreadyExists(TestAccount));
        }

        [TestMethod]
        public void FindAccountByCellPhoneNumberTestPass()
        {
            ormAccountRepository.AddAccount(TestAccount);
            ParkingContext.SaveChanges();
            Assert.IsTrue(ormAccountRepository.FindAccountByCellPhoneNumber("099730280").Equals(TestAccount));
        }

        [TestCleanup]
        public void CleanUp()
        {
                ParkingContext.Database.Delete();            
        }

    }
}
