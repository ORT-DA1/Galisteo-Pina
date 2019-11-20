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
        private ParkingContext context;
        private IAccountRepository accountRepository;
        private ICountryRepository countryRepository;
        private IPurchaseRepository purchaseRepository;

        public UnitOfWork(ParkingContext parkingContext)
        {
            context = parkingContext;
        }

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

        public ICountryRepository Countries
        {
            get
            {

                if (this.countryRepository == null)
                {
                    this.countryRepository = new OrmCountryRepository(context);
                }
                return countryRepository;
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
