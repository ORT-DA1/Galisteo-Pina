using System;
using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogicTest
{
    [TestClass]
    public class SystemParkingTest
    {
        [TestMethod]
        public void SystemWithNoAccountTest()
        {
            ParkingSystem system = new ParkingSystem();
            Assert.IsTrue(system.NoAccountInSystem());
        }

        [TestMethod]
        public void SystemWithAccountsTest()
        {
            ParkingSystem system = new ParkingSystem();
            Account userAccount = new Account();
            userAccount.AccountCellPhoneNumber = "098 960 505";
            system.AddAcount(userAccount);
            Assert.IsFalse(system.NoAccountInSystem());
        }

        [TestMethod]
        public void SystemAddCorrectAccountTest()
        {
            ParkingSystem system = new ParkingSystem();
            Account userAccount = new Account();
            userAccount.AccountCellPhoneNumber = "098960505";
            Assert.IsTrue(system.AddAcount(userAccount));
        }

        [TestMethod]
        public void SystemAddIncorrectAccountTest()
        {
            ParkingSystem system = new ParkingSystem();
            Account userAccount = new Account();
            Assert.IsFalse(system.AddAcount(userAccount));
        }
    }
}
