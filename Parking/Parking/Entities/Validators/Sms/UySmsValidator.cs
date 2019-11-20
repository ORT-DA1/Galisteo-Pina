using Entities.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Entities.Country;

namespace Entities
{
    public class UySmsValidator : SmsValidator, ISmsValidator
    {
        public override CountriesInSystem SmsValidatorCountry { get; set; } = CountriesInSystem.URUGUAY;
        public override bool IsCorrectFormat(Sms smsToValidate)
        {
            return !MissingInput(smsToValidate.Plates) &&
                !MissingInput(smsToValidate.Minutes)
                && ValidateMinutes(smsToValidate) && IsValidHourFormat(smsToValidate)
                && IsValidHourFormat(smsToValidate) && IsHourForToday(smsToValidate) && IsWithinRangeOfHours(smsToValidate);
        }


        public override bool ValidateMinutes(Sms smsToValidate)
        {
            return base.ValidateMinutes(smsToValidate) && IsMultipleOf30(smsToValidate);
        }

        public bool IsMultipleOf30(Sms smsToValidate)
        {
            return (Convert.ToInt32(smsToValidate.Minutes) % 30 == 0);
        }


        public override Sms GetInitializedSms(string smsMessageText)
        {
            Sms sms = new Sms();
            string smsMessageTextNormalized = NormalizeMessagePlate(smsMessageText);
            string[] splitSmsMessage = TrimAndSplitMessage(smsMessageTextNormalized);
            sms.Plates = ExtractPlates(splitSmsMessage);
            sms.Minutes = ExtractMinutes(splitSmsMessage);
            sms.StartingHour = GetStartingHour(splitSmsMessage);
            sms.EndingHour = GetEndingHour(sms);
            return sms;
        }


       

        public bool SmsHasStartingHour(string[] splitSmsMessage)
        {
            return splitSmsMessage.Length > 2;
        }


        public DateTime GetStartingHour(string[] splitSmsMessage)
        {
            if (SmsHasStartingHour(splitSmsMessage))
                return ExtractStartingHour(splitSmsMessage);
            return DateTime.Now;
        }



        public DateTime GetEndingHour(Sms sms)
        {
            DateTime endingHour = DateTime.MinValue;
            if (sms.Minutes != null)
            {
                var startingHourPlusMinutes = sms.StartingHour.AddMinutes(Double.Parse(sms.Minutes));
                var maxEndingHour = sms.UpperHourLimit;
                endingHour = startingHourPlusMinutes > maxEndingHour ? maxEndingHour : startingHourPlusMinutes;
            }
            return endingHour;
        }
    }
}
