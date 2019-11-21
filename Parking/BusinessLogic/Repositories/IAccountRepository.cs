using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repositories
{
    public interface IAccountRepository:IRepository<Account>
    {
        Notification AddAccount(Account account);
        bool AccountAlreadyExists(Account account);
        Account FindAccountByCellPhoneNumber(string cellPhoneNumber);
        bool ThereAreRecordedAccounts();
        bool AddBalanceToAccount(string cell, string balance);
    }
}
