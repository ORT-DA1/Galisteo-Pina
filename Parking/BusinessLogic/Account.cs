using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Account
    {
        public string AccountCellPhoneNumber { get; set; }
        public int AccountBalance { get; set; }

        public Account()
        {
            this.AccountCellPhoneNumber = "";
            this.AccountBalance = 0;
        }

        public Account(string cellPhoneNumber, int balance)
        {
            this.AccountCellPhoneNumber = cellPhoneNumber;
            this.AccountBalance = balance;
        }

        public bool AccountCellPhoneNumberIsEmpty()
        {
            return this.AccountCellPhoneNumber.Length == 0;
        }

        public bool AccountCellPhoneNumberFormatIsCorrect()
        {
            CellPhoneValidator phoneNumberValidator = new CellPhoneValidator();
            return phoneNumberValidator.PhoneNumberCorrectFormat(this.AccountCellPhoneNumber);
        }

        public bool AccountBalanceIsPositive()
        {
            return this.AccountBalance >= 0;
        }

        public void AddMoneyToBalance(int moneyToAdd)
        {
            this.AccountBalance += moneyToAdd;
        }

        public bool SustractMoneyToBalance(int moneyToSustract)
        {
            bool success = false;
            if(this.AccountBalance - moneyToSustract >= 0)
            {
                this.AccountBalance -= moneyToSustract;
                success = true;
            }
            return success;
        }

    }
}
