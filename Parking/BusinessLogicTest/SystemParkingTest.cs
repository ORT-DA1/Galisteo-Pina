using System;
using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogicTest
{
    [TestClass]
    public class SystemParkingTest
    {
        [TestMethod]
        public void AddAccountTest()
        {
            SystemParking system = new SystemParking();
            Account userAccount = new Account();
            userAccount.AccountCellPhoneNumber = "098960505";
            bool success = system.addAccount(userAccount);
            Assert.IsTrue(success);
        }
    }
}
