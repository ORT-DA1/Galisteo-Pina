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

        public bool AddAcount(Account userAccount)
        {
            bool success = false;
            if (CorrectAccountCellPhone(userAccount) && (CorrectAccountBalance(userAccount)))
            {
                AccountList.Add(userAccount);
                success = true;
            }
            return success;
        }
    }
}
