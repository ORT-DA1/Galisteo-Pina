using Entities.Validation;
using System.Text.RegularExpressions;
using static Entities.Country;

namespace Entities
{
    public class ArgSmsValidator : SmsValidator, ISmsValidator
    {
        public const int NUMBER_OF_PLATE_COMPONENTS = 3;
        public const int PLATE_POSITION = 0;
        public const int STARTING_HOUR_POSITION = 1;
        public const int MINUTES_POSITION = 2;
        public override CountriesInSystem SmsValidatorCountry { get; set; } = CountriesInSystem.ARGENTINA;

        public override bool IsCorrectFormat(Sms smsToValidate)
        {
            return !MissingInput(smsToValidate.Plates) && !MissingInput(smsToValidate.Minutes) 
                && !MissingInput(smsToValidate.StartingHour.ToString()) && ValidateMinutes(smsToValidate) 
                && IsValidHourFormat(smsToValidate) && IsValidHourFormat(smsToValidate) 
                && IsHourForToday(smsToValidate) && IsWithinRangeOfHours(smsToValidate);
        }

         
        public bool CorrectOrder(string[] splitMessage)
        {
            if (splitMessage.Length < NUMBER_OF_PLATE_COMPONENTS)
                return false;
            bool platesFirst = Regex.IsMatch(splitMessage[PLATE_POSITION], "[A-Za-z]{3}[0-9]{4}");
            bool startingHourSecond = Regex.IsMatch(splitMessage[STARTING_HOUR_POSITION], "[0-9]{2}[:][0-9]{2}");
            bool minutesThird = Regex.IsMatch(splitMessage[MINUTES_POSITION], @"^(\d{3}|\d{2})$");
            return platesFirst && startingHourSecond && minutesThird;
        }

        public override Sms GetInitializedSms(string smsMessageText)
        {
            Sms sms = new Sms();
            string smsMessageTextNormalized = base.NormalizeMessagePlate(smsMessageText);
            string[] splitSmsMessage = TrimAndSplitMessage(smsMessageTextNormalized);
            if(CorrectOrder(splitSmsMessage))
            { 
            sms.Plates = ExtractPlates(splitSmsMessage);
            sms.Minutes = ExtractMinutes(splitSmsMessage);
            sms.StartingHour = GetStartingHour(splitSmsMessage);
            sms.EndingHour = GetEndingHour(sms);
            }
            return sms;
        }
    }
}


