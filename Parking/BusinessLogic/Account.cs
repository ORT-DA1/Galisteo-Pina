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

        public Account(string mobileNumber, int balance = 0)
        {
            this.AccountCellPhoneNumber = mobileNumber;
            this.AccountBalance = balance;
        }

        public bool AccountBalanceIsPositive()
        {
            return this.AccountBalance >= 0;
        }

        public void AddMoneyToBalance(string moneyToAdd)
        {
            this.AccountBalance += Convert.ToInt32(moneyToAdd);
        }


        public bool SubstractMoneyFromBalance(int moneyToSustract)
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
