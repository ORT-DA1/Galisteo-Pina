using System;
using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace BusinessLogicTest
{
    [TestClass]
    public class ParkingSystemTest
    {
        [TestMethod]
        public void AddAccountTest()
        {
            ParkingSystem system = new ParkingSystem();
            Notification notification = system.AddAccount("098960505");
            Assert.IsTrue(notification.HasSuccess());
         }

        [TestMethod]
        public void AddAmmountToBalanceSuccessTest()
        {
            ParkingSystem system = new ParkingSystem();
            system.AddAccount("098960505");
            Notification notification = system.AddAmmountToBalance("098960505", "200");
            Account asd = system.AccountRepository.FindAccountByCellPhoneNumber("098960505");
            Assert.IsTrue(notification.HasSuccess());
        }

        [TestMethod]
       public void AddAmmountToBalanceErrorTest()
        {
            ParkingSystem system = new ParkingSystem();
            system.AddAccount("098960505");
            Notification notification = system.AddAmmountToBalance("098960505", "-200,5");
            Account asd = system.AccountRepository.FindAccountByCellPhoneNumber("098960505");
            Assert.IsTrue(notification.HasErrors());
        }

        ////public void systemwithnoaccounttest()
        ////{
        ////    parkingsystem system = new parkingsystem();
        ////    assert.istrue(system.noaccountinsystem());
        ////}

        ////[testmethod]
        ////public void systemwithaccountstest()
        ////{
        ////    parkingsystem system = new parkingsystem();
        ////    account useraccount = new account("098960505", 0);
        ////    system.addaccount(useraccount);
        ////    assert.isfalse(system.noaccountinsystem());
        ////}

        ////[testmethod]
        ////public void systemaddcorrectaccounttest()
        ////{
        ////    parkingsystem system = new parkingsystem();
        ////    account useraccount = new account("098960505", 0);
        ////    assert.istrue(system.addaccount(useraccount));
        ////}

        ////[testmethod]
        ////public void systemaddincorrectaccounttest()
        ////{
        ////    parkingsystem system = new parkingsystem();
        ////    account useraccount = new account("", 0);
        ////    assert.isfalse(system.addaccount(useraccount));
        ////}

        ////[testmethod]
        ////public void systemremoveaccounttest()
        ////{
        ////    parkingsystem system = new parkingsystem();
        ////    account useraccount = new account("098960505", 0);
        ////    system.addaccount(useraccount);
        ////    assert.istrue(system.removeaccount(useraccount));
        ////}

        ////[testmethod]
        ////public void systemremoveaccounterrortest()
        ////{
        ////    parkingsystem system = new parkingsystem();
        ////    account useraccount = new account("098960505", 0);
        ////    assert.isfalse(system.removeaccount(useraccount));
        ////}



        ////[testmethod]
        ////public void systemaddbalanceerrortest()
        ////{
        ////    parkingsystem system = new parkingsystem();
        ////    account useraccount = new account("098960505", 0);
        ////    system.addaccount(useraccount);
        ////    assert.isfalse(system.addbalance(useraccount, -100)); 
        ////}

        ////[testmethod]
        ////public void systemsustractbalancetest()
        ////{
        ////    parkingsystem system = new parkingsystem();
        ////    account useraccount = new account("098960505", 0);
        ////    system.addaccount(useraccount);
        ////    system.addbalance(useraccount, 100);
        ////    assert.istrue(system.sustractbalance(useraccount, -100));
        ////}
    }
}

