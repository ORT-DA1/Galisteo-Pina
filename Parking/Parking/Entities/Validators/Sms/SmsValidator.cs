﻿using Entities.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Entities.Country;

namespace Entities
{
    public abstract class SmsValidator: Validator, ISmsValidator
    {
        public abstract CountriesInSystem SmsValidatorCountry{ get; set; }


        public SmsValidator()
        {
        }

        public Notification ValidateSms(Sms smsToValidate)
        {
            Notification notification = new Notification();
            if (!IsCorrectFormat(smsToValidate)) notification.AddError("Mensaje incorrecto.Ej: ABC 1234 60 10:00");
            return notification;
        }

        public abstract bool IsCorrectFormat(Sms smsToValidate);

        public abstract Sms GetInitializedSms(string smsToInitialize);

        public bool MissingInput(string input)
        {
            return input == string.Empty;
        }

        public virtual bool ValidateMinutes(Sms smsToValidate)
        {
            return IsItAnInteger(smsToValidate) && IsPositive(smsToValidate);
        }


        public bool IsItAnInteger(Sms smsToValidate)
        {
            return IsAnInteger(smsToValidate.Minutes);
        }

        public bool IsPositive(Sms smsToValidate)
        {
            return (Convert.ToInt32(smsToValidate.Minutes) > 0);
        }

        public bool IsValidHourFormat(Sms smsToValidate)
        {
            return !CouldNotParseDate(smsToValidate) && Regex.IsMatch(smsToValidate.StartingHour.ToString("HH:mm"), "^([0-9]{2}[:][0-9]{2})$");
        }

        public bool CouldNotParseDate(Sms smsToValidate)
        {
            return smsToValidate.StartingHour.Equals(DateTime.MinValue);
        }
        public bool IsWithinRangeOfHours(Sms smsToValidate)
        {
            return smsToValidate.StartingHour >= smsToValidate.LowerHourLimit && smsToValidate.StartingHour <= smsToValidate.UpperHourLimit;
        }

        public bool IsHourForToday(Sms smsToValidate)
        {
            return DateTime.Now <= smsToValidate.StartingHour.AddMinutes(1);
        }



    }
}
