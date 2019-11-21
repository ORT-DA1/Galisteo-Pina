using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class SmsValidator: Validator, IValidation
    {
        public Sms SmsToValidate { get; set; }

        public SmsValidator(Sms smsToValidate)
        {
            SmsToValidate = smsToValidate;
        }

        public Notification Validate()
        {
            Notification notification = new Notification();

            bool validSms = !MissingInput(SmsToValidate.Plates) &&
                !MissingInput(SmsToValidate.Minutes)
                && ValidateMinutes() && IsValidHourFormat()
                && IsValidHourFormat() && IsHourForToday() && IsWithinRangeOfHours();
            if (!validSms) notification.AddError("Mensaje incorrecto.Ej: ABC 1234 60 10:00");

            return notification;
        }

        public bool MissingInput(string input)
        {
            return input == string.Empty;
        }

        public bool ValidateMinutes()
        {
            return IsItAnInteger() && IsPositive() && IsMultipleOf30();
        }

        public bool IsMultipleOf30()
        {
            return (Convert.ToInt32(SmsToValidate.Minutes) % 30 == 0);
        }

        public bool IsItAnInteger()
        {
            return IsAnInteger(SmsToValidate.Minutes);
        }

        public bool IsPositive()
        {
            return (Convert.ToInt32(SmsToValidate.Minutes) > 0);
        }

        public bool IsValidHourFormat()
        {
            return !CouldNotParseDate() && Regex.IsMatch(SmsToValidate.StartingHour.ToString("HH:mm"), "^([0-9]{2}[:][0-9]{2})$");
        }

        public bool CouldNotParseDate()
        {
            return SmsToValidate.StartingHour.Equals(DateTime.MinValue);
        }
        public bool IsWithinRangeOfHours()
        {
            return SmsToValidate.StartingHour >= SmsToValidate.LowerHourLimit && SmsToValidate.StartingHour <= SmsToValidate.UpperHourLimit;
        }

        public bool IsHourForToday()
        {
            return DateTime.Now <= SmsToValidate.StartingHour.AddMinutes(1);
        }



    }
}
