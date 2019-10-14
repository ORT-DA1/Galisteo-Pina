﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Purchase
    {
        public Sms Sms { get; set; }

        public int PurchaseCost { get; set; }
        public Account Account { get; set; }

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
            return minutesUsed;
        }


    }
}
