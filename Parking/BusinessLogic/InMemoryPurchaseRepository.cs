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

        public void AddPurchase(Purchase purchase)
        {
            this.PurchasesRecord.Add(purchase);
        }

        public bool ThereAreRecordedPurchases()
        {
            return this.PurchasesRecord.Count > 0;
        }

        public bool AnyPurchaseMatchesPlateAndDateTime(string plates, string dateToCompare)
        {
            DateTime date = DateTime.Parse(dateToCompare);
            Purchase purchase = PurchasesRecord[0];
            bool asd1 = purchase.Sms.Plates == plates;
            bool asd2 = purchase.Sms.StartingHour <= date;
            bool asd3 = purchase.Sms.EndingHour >= date;
            bool asd4 = purchase.Sms.StartingHour <= date && purchase.Sms.EndingHour >= date;
            bool asd5 = PurchasesRecord.Any(purchasex => purchase.Sms.Plates == plates && purchase.Sms.StartingHour <= date && purchase.Sms.EndingHour >= date);
            return PurchasesRecord.Any(purchasex => purchase.Sms.Plates == plates && (purchase.Sms.StartingHour <= date && purchase.Sms.EndingHour >= date));
        }


    }
}
