using Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface IUnitOfWork
    {
        IAccountRepository Accounts { get; }
        IPurchaseRepository Purchases { get; }
        int Save();
    }
}
