using Entities;
using Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UnitOfWork: IUnitOfWork
    {
        private ParkingContext context = new ParkingContext(new DropCreateDatabaseIfModelChanges<ParkingContext>());
        private IAccountRepository accountRepository;
        private IPurchaseRepository purchaseRepository;

        public IAccountRepository Accounts
        {
            get
            {

                if (this.accountRepository == null)
                {
                    this.accountRepository = new OrmAccountRepository(context);
                }
                return accountRepository;
            }
        }

        public IPurchaseRepository Purchases
        {
            get
            {

                if (this.purchaseRepository == null)
                {
                    this.purchaseRepository = new OrmPurchaseRepository(context);
                }
                return purchaseRepository;
            }
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            } 

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
