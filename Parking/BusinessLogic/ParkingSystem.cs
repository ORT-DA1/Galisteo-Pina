using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class ParkingSystem
    {
        public List<Account> AccountList { get; set; }

        public ParkingSystem()
        {
            AccountList = new List<Account>();
        }

        public bool NoAccountInSystem()
        {
            return AccountList.Count == 0;
        }

        public bool CorrectAccountCellPhone(Account userAccount)
        {
            CellPhoneValidator cellPhoneControl = new CellPhoneValidator();
            return cellPhoneControl.PhoneNumberCorrectFormat(userAccount.AccountCellPhoneNumber);
        }

        public bool CorrectAccountBalance(Account userAccount)
        {
            BalanceValidator accountBalance = new BalanceValidator();
            return (accountBalance.BalanceCorrectFormat(userAccount.AccountBalance));
        }

        public bool AddAccount(Account userAccount)
        {
            bool success = false;
            if (CorrectAccountCellPhone(userAccount) && (CorrectAccountBalance(userAccount)))
            {
                AccountList.Add(userAccount);
                success = true;
            }
            return success;
        }

        public bool RemoveAccount(Account userAccount)
        {
            return this.AccountList.Remove(userAccount);
        }

        public Account SelectAccountFromAccountList(Account userAccount)
        {
            Account userAccountInList = null;
            for (int listPosition = 0; listPosition < this.AccountList.Count; listPosition++)
            {
                if (this.AccountList[listPosition] == userAccount)
                {
                    userAccountInList = this.AccountList[listPosition];
                }
            }
            return userAccountInList;
        }

        public bool AddBalance(Account userAccount, int balanceToAdd)
        {
            BalanceValidator balanceControl = new BalanceValidator();
            bool success = false;
            if (balanceControl.BalanceCorrectFormat(balanceToAdd) && balanceToAdd >= 0)
            {
                SelectAccountFromAccountList(userAccount).AddMoneyToBalance(balanceToAdd);
                success = true;
            }
            return success;
        }

        public bool SustractBalance(Account userAccount, int balanceToSustract)
        {
            return SelectAccountFromAccountList(userAccount).SustractMoneyToBalance(balanceToSustract);
        }
    }
}
