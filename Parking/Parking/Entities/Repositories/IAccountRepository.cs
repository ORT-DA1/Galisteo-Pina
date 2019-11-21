using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories
{
    public interface IAccountRepository:IRepository<Account>
    {
        Notification AddAccount(Account account);
        bool AccountAlreadyExists(Account account);
        Account FindAccountByCellPhoneNumber(string cellPhoneNumber);
    }
}
