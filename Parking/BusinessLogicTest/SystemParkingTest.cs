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
            system.AddAcount(userAccount);
            Assert.IsFalse(system.NoAccountInSystem());
        }

        [TestMethod]
        public void SystemAddCorrectAccountTest()
        {
            ParkingSystem system = new ParkingSystem();
            Assert.IsTrue(system.NoAccountInSystem());
        }
    }
}
