using System;
using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogicTest
{
    [TestClass]
    public class InMemoryAccountRepositoryTest
    {
        InMemoryAccountRepository accountRepository;

        [TestInitialize]
        public void Initialize()
        {
            accountRepository = new InMemoryAccountRepository();
        }

        [TestMethod]
        public void AddAccountTest()
        {
            Assert.IsTrue(accountRepository.AddAccount("099222111").HasSuccess());
        }

        [TestMethod]
        public void AddAccountAlreadyExistsTest()
        {
            accountRepository.AddAccount("099222111");
            Assert.IsTrue(accountRepository.AddAccount("099222111").HasErrors());
        }

        [TestMethod]
        public void FindAccountByCellphoneNumberTest()
        {
            accountRepository.AddAccount("099222111");
            Assert.IsTrue(accountRepository.FindAccountByCellPhoneNumber("099222111").AccountCellPhoneNumber == "099222111");
        }

        [TestMethod]
        public void FindAccountByCellphoneNumberNotFoundTest()
        {
            Assert.IsTrue(accountRepository.FindAccountByCellPhoneNumber("099222111") == null);
        }

        [TestMethod]
        public void ThereAreRecordedAccountsTest()
        {
            accountRepository.AddAccount("099222111");
            Assert.IsTrue(accountRepository.ThereAreRecordedAccounts());
        }

        [TestMethod]
        public void ThereAreRecordedAccountsFalseTest()
        {
            Assert.IsFalse(accountRepository.ThereAreRecordedAccounts());
        }

        [TestMethod]
        public void AccountAlreadyExistsTest()
        {
            accountRepository.AddAccount("099222111");
            Assert.IsTrue(accountRepository.AccountAlreadyExists("099222111"));
        }

        [TestMethod]
        public void AccountAlreadyExistsFalseTest()
        {
            accountRepository.AddAccount("099222111");
            Assert.IsFalse(accountRepository.AccountAlreadyExists("099123123"));
        }
    }
}
