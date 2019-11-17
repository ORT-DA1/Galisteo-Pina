using Entities;
using Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Notification AddPurchase(Purchase purchase)
        {
            Notification notification;
            int costOfMinutesUsed = purchase.CalculateCostForMinutesUsed();
            AccountTransactionValidator accountTransactionValidator = new AccountTransactionValidator(purchase.Account, costOfMinutesUsed);
            notification = accountTransactionValidator.Validate();

            if (!notification.HasErrors())
            {
                ParkingContext.Purchases.Add(purchase);
                purchase.SubstractMoneyFromAccount(costOfMinutesUsed);
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

    }
}
