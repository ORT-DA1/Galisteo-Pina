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

        public string NormalizeMessagePlate(string messageWithPlateToNormalize)
        {

            return Regex.Replace(messageWithPlateToNormalize, @"(?<=[A-Za-z])\s", "");

        }

        public string[] TrimAndSplitMessage(string messageToSplit)
        {
            return Regex.Split(messageToSplit.Trim(), @"\s+");
        }

        public string Extract(string[] splitMessage, string regexPattern)
        {
            string extractedText = "";
            try
            {
                extractedText = splitMessage.First(s => Regex.IsMatch(s, regexPattern));
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
            return extractedText;
        }

        public string ExtractPlates(string[] splitMessage)
        {
            return Extract(splitMessage, "[A-Za-z]{3}[0-9]{4}");
        }

        public string ExtractMinutes(string[] splitMessage)
        {
            return Extract(splitMessage, @"^(\d{3}|\d{2})$");
        }

        public DateTime ExtractStartingHour(string[] splitMessage)
        {
            DateTime parseResult;
            DateTime.TryParse(Extract(splitMessage, "[:]"), out parseResult);
            return parseResult;
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


        public bool SmsHasStartingHour(string[] splitSmsMessage)
        {
            return splitSmsMessage.Any(s => s.Contains(":"));
        }


        public DateTime GetStartingHour(string[] splitSmsMessage)
        {
            if (SmsHasStartingHour(splitSmsMessage))
                return ExtractStartingHour(splitSmsMessage);
            return DateTime.Now;
        }

    }
}
