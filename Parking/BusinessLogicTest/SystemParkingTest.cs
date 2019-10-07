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
            system.AddAccount(userAccount);
            Assert.IsFalse(system.NoAccountInSystem());
        }

        [TestMethod]
        public void SystemAddCorrectAccountTest()
        {
            ParkingSystem system = new ParkingSystem();
            Account userAccount = new Account();
            userAccount.AccountCellPhoneNumber = "098960505";
            Assert.IsTrue(system.AddAccount(userAccount));
        }

        [TestMethod]
        public void SystemAddIncorrectAccountTest()
        {
            ParkingSystem system = new ParkingSystem();
            Account userAccount = new Account();
            Assert.IsFalse(system.AddAccount(userAccount));
        }

        [TestMethod]
        public void SystemRemoveAccountTest()
        {
            ParkingSystem system = new ParkingSystem();
            Account userAccount = new Account();
            userAccount.AccountCellPhoneNumber = "098960505";
            system.AddAccount(userAccount);
            Assert.IsTrue(system.RemoveAccount(userAccount));
        }

        [TestMethod]
        public void SystemRemoveAccountErrorTest()
        {
            ParkingSystem system = new ParkingSystem();
            Account userAccount = new Account();
            userAccount.AccountCellPhoneNumber = "098960505";
            Assert.IsFalse(system.RemoveAccount(userAccount));
        }

        [TestMethod]
        public void SystemAddBalanceTest()
        {
            ParkingSystem system = new ParkingSystem();
            Account userAccount = new Account();
            userAccount.AccountCellPhoneNumber = "098960505";
            system.AddAccount(userAccount);
            Assert.IsTrue(system.AddBalance(userAccount, 100));
        }

        [TestMethod]
        public void SystemAddBalanceErrorTest()
        {
            ParkingSystem system = new ParkingSystem();
            Account userAccount = new Account();
            userAccount.AccountCellPhoneNumber = "098960505";
            system.AddAccount(userAccount);
            Assert.IsFalse(system.AddBalance(userAccount, -100)); 
        }

        [TestMethod]
        public void SystemSustractBalanceTest()
        {
            ParkingSystem system = new ParkingSystem();
            Account userAccount = new Account();
            userAccount.AccountCellPhoneNumber = "098960505";
            system.AddAccount(userAccount);
            system.AddBalance(userAccount, 100);
            Assert.IsTrue(system.SustractBalance(userAccount, -100));
        }
    }
}
