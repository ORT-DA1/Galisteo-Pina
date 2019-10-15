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
            Sms purchaseSms = new Sms();
            purchaseSms.Initialize(sms);
            SmsValidator smsValidator = new SmsValidator(purchaseSms);
            Notification notification = smsValidator.Validate();
            Purchase purchase = new Purchase(purchaseSms, purchaseAccount);
            int costOfMinutesUsed = purchase.CalculateCostForMinutesUsed();
            AccountTransactionValidator accountTransactionValidator = new AccountTransactionValidator(purchaseAccount, costOfMinutesUsed);
            notification.AppendNotificationErrors(accountTransactionValidator.Validate());

            if (!notification.HasErrors())
            {
                PurchasesRecord.Add(purchase);
                purchaseAccount.SustractMoneyToBalance(costOfMinutesUsed);
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
            return PurchasesRecord.Any(purchase => purchase.Sms.Plates == plates && 
                    (purchase.Sms.StartingHour <= date && purchase.Sms.EndingHour >= date));
        }


    }
}
