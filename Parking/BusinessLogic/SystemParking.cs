using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class SystemParking
    {
        public List<Account> UserAccountsList { get; set; }

        public SystemParking()
        {
            UserAccountsList = new List<Account>();
        }

        public bool addAccount(Account accountToAdd)
        {
            bool success = false;
            if (accountToAdd.AccountCellPhoneNumberFormatIsCorrect())
            {
                this.UserAccountsList.Add(accountToAdd);
                success = true;
            }
            return success;
        }
    }
}
