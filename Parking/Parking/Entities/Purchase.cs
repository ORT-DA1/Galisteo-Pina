using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Purchase
    {
   
        public int PurchaseId { get; set; }
        public int PurchaseCost { get; set; }
        public virtual Sms Sms { get; set; }
        public virtual Account Account { get; set; }

        public Purchase() { }
        public Purchase(Sms sms, Account account)
        {
            this.Sms = sms;
            this.Account = account;
        }
        public int CalculateCostForMinutesUsed()
        {
            TimeSpan parkingTimeUsed = Sms.EndingHour.Subtract(Sms.StartingHour);
            int minutesUsed = Convert.ToInt32(parkingTimeUsed.TotalMinutes);
            return minutesUsed * ParkingCost.CostPerMinute;
        }
          
        public bool SubstractMoneyFromAccount(int moneyToSubstract)

        {
            return this.Account.SubstractMoneyFromBalance(moneyToSubstract);
        }

        public string AccountCellPhone { get { return this.Account.AccountCellPhoneNumber; } }

        public string Plates { get { return this.Sms.Plates; } }

        public string StartingHour { get { return this.Sms.StartingHour.ToString("HH:mm"); } }

        public string EndingHour { get { return this.Sms.EndingHour.ToString("HH:mm"); } }
    }
}
