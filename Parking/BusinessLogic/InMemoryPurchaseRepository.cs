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

        public Notification AddPurchase(Account purchaseAccount, string sms)
        {
            Purchase purchase;
            Sms purchaseSms = new Sms();
            purchaseSms.Initialize(sms);
            SmsValidator smsValidator = new SmsValidator(purchaseSms);
            Notification notification = smsValidator.Validate();
            if (!purchaseAccount.AccountBalanceIsPositive())
            {
                notification.AddError("Insufficient balance");
            }
            if (!notification.HasErrors())
            {
                purchase = new Purchase(purchaseSms, purchaseAccount);
                PurchasesRecord.Add(purchase);
                notification.AddSuccess("Purchase was successfull");
            }
            return notification;
        }

        public bool ThereAreRecordedPurchases()
        {
            return this.PurchasesRecord.Count > 0;
        }

        public bool AnyPurchaseMatchesPlateAndDateTime(string plates, string dateToCompare)
        {
            DateTime date = DateTime.Parse(dateToCompare);
            return PurchasesRecord.Any(purchase => purchase.Sms.Plates == plates && (purchase.Sms.StartingHour <= date && purchase.Sms.EndingHour >= date));
        }


    }
}
