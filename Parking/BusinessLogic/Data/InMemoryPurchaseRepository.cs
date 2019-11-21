using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
   public class InMemoryPurchaseRepository:IPurchaseRepository
    {
        public List<Purchase> PurchasesRecord { get; set; }

        public InMemoryPurchaseRepository()
        {
            PurchasesRecord = new List<Purchase>();
        }

        public Notification AddPurchase(Purchase purchase)
        {
            Notification notification;
            int costOfMinutesUsed = purchase.CalculateCostForMinutesUsed();
            AccountTransactionValidator accountTransactionValidator = new AccountTransactionValidator(purchase.Account, costOfMinutesUsed);
            notification = accountTransactionValidator.Validate();

            if (!notification.HasErrors())
            {
                PurchasesRecord.Add(purchase);
                purchase.SubstractMoneyFromAccount(costOfMinutesUsed);
                notification.AddSuccess("Compra efectuada con éxito");

            }
            return notification;
        }

        public bool ThereAreRecordedPurchases()
        {
            return this.PurchasesRecord.Count > 0;
        }

        public bool AnyPurchaseMatchesPlateAndDateTime(string plates, string dateToCompare)
        {
            try {

                DateTime date = DateTime.Parse(dateToCompare.Trim());
                return PurchasesRecord.Any(purchase => purchase.Sms.Plates.Trim() == plates &&
                        (purchase.Sms.StartingHour <= date && purchase.Sms.EndingHour >= date));
            }
            catch (FormatException ex)
            {
                throw ex;
            }
        }


    }
}
