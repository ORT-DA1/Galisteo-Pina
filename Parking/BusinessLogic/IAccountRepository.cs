using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface IAccountRepository
    {
        Notification AddAccount(string cellPhoneNumber);
        Notification AddBalanceToAccount(string cellPhoneNumber, string ammount);
        bool ThereAreRecordedAccounts();
        Account FindAccountByCellPhoneNumber(string plateToMatch);
  
    }
}
