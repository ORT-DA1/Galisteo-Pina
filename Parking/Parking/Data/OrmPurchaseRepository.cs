using Entities;
using Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Data
{
    public class OrmPurchaseRepository : Repository<Purchase>, IPurchaseRepository
    {
        public ParkingContext ParkingContext
        {
            get { return Context as ParkingContext; }
        }
        public OrmPurchaseRepository(ParkingContext context) : base(context)
        {
        }

        public Notification AddPurchase(Purchase purchase, int costPerMinute)
        {
            Notification notification;
            int costOfMinutesUsed = purchase.CalculateCostForMinutesUsed(costPerMinute);
            AccountTransactionValidator accountTransactionValidator = new AccountTransactionValidator(purchase.Account, costOfMinutesUsed);
            notification = accountTransactionValidator.Validate();

            if (!notification.HasErrors())
            {
                ParkingContext.Purchases.Add(purchase);
                purchase.PurchaseCost = costOfMinutesUsed;
                purchase.SubstractMoneyFromAccount(purchase.PurchaseCost);
                notification.AddSuccess("Compra efectuada con éxito");

            }
            return notification;
        }

        public bool AnyPurchaseMatchesPlateAndDateTime(string plates, string dateToCompare)
        {
            try
            {
                DateTime date = DateTime.Parse(dateToCompare.Trim());
                return ParkingContext.Purchases.Any(purchase => purchase.Sms.Plates.Trim() == plates &&
                        (purchase.Sms.StartingHour <= date && purchase.Sms.EndingHour >= date));
            }
            catch (FormatException ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Purchase> GetPurchasesMatchDateAndCountry(DateTime startingDate, DateTime endingDate, string plates, Country purchaseCountry = null)
        {
            var matchingPurchases = this.GetAll();
            matchingPurchases = matchingPurchases.Where(p => p.Sms.StartingHour >= startingDate && p.Sms.EndingHour <= endingDate);
            if(plates != string.Empty)
                matchingPurchases = matchingPurchases.Where(p => p.Sms.Plates == plates);
            if (purchaseCountry != null)
                matchingPurchases = matchingPurchases.Where(p => p.Account.AccountCountry.Name == purchaseCountry.Name);
            return matchingPurchases as IEnumerable<Purchase>;
        }
    }
}
