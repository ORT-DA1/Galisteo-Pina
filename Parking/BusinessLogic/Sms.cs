using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Sms:IRequestDevice
    {

        public string Plates { get; set; }

        public string Minutes { get; set; }

        public DateTime StartingHour { get; set; }

        public DateTime EndingHour { get; set; }

        public DateTime LowerHourLimit { get; set; }

        public DateTime UpperHourLimit { get; set; }

        public Sms()
        {
            this.Plates = "";
            this.Minutes = "";
            this.StartingHour = DateTime.MinValue;
            this.EndingHour = DateTime.MinValue;
            this.LowerHourLimit = DateTime.Parse("10:00");
            this.UpperHourLimit = DateTime.Parse("18:00");
        }

        public Sms(DateTime LowerHourLimit, DateTime UpperHourLimit) 
        {
            this.Plates = "";
            this.Minutes = "";
            this.StartingHour =  DateTime.MinValue;
            this.EndingHour = DateTime.MinValue;
            this.LowerHourLimit = LowerHourLimit;
            this.UpperHourLimit = UpperHourLimit;
        }


        public void Initialize(string smsMessageText)
        {
            string smsMessageTextNormalized = NormalizeMessagePlate(smsMessageText);
            string[] splitSmsMessage = TrimAndSplitMessage(smsMessageTextNormalized);
            this.Plates = ExtractPlates(splitSmsMessage);
            this.Minutes = ExtractMinutes(splitSmsMessage);
            this.StartingHour = SetStartingHour(splitSmsMessage);
            this.EndingHour = SetEndingHour();
        }


        public string NormalizeMessagePlate(string messageWithPlateToNormalize)
        {

            return Regex.Replace(messageWithPlateToNormalize, @"(?<=[A-Za-z])\s", "");

        }

        public string[] TrimAndSplitMessage(string messageToSplit)
        {
            return Regex.Split(messageToSplit.Trim(), @"\s+");
        }

        public bool SmsHasStartingHour(string[] splitSmsMessage)
        {
            return splitSmsMessage.Length > 2;
        }

        public string Extract(string[] splitMessage, string regexPattern)
        {
            return splitMessage.First(s => Regex.IsMatch(s, regexPattern));
        }

        public string ExtractPlates(string[] splitMessage)
        {
            return Extract(splitMessage, "[A-Za-z]{3}[0-9]{4}");
        }

        public string ExtractMinutes(string[] splitMessage)
        {
            return Extract(splitMessage, @"^(\d{3}|\d{2})$");
        }

        public DateTime SetStartingHour(string[] splitSmsMessage)
        {
            if (SmsHasStartingHour(splitSmsMessage))
                return ExtractStartingHour(splitSmsMessage);
            return DateTime.Now;
        }

        public DateTime ExtractStartingHour(string[] splitMessage)
        {
            DateTime parseResult;
             DateTime.TryParse(Extract(splitMessage, "[:]"), out parseResult);
            return parseResult;
        }

        public Notification Validate(DateTime timeOfValidation)
        {
            Notification notification = new Notification();

            if (MissingInput(this.Plates))
                notification.AddError("Number Plate is missing");
            if (MissingInput(this.Minutes))
                notification.AddError("Ammount of minutes is missing");
            if (!ValidateMinutes())
                notification.AddError("Ammount of minutes has to be a positive number and a multiple of 30");
            if (!IsValidHourFormat())
                notification.AddError("Invalid date format. Should be: HH:mm");
            if (!IsWithinRangeOfHours())
                notification.AddError("Invalid range of hours. Should be between 10:00 and 18:00");
            if (!IsHourForToday(timeOfValidation))
                notification.AddError("It is only possible to buy parking hours for the current day");
            return notification;
        }

        public bool MissingInput(string input)
        {
            return input == string.Empty;
        }

        public bool ValidateMinutes()
        {
            return IsAnInteger() && IsPositive() && IsMultipleOf30();
        }

        public bool IsMultipleOf30()
        {
            return (Convert.ToInt32(this.Minutes) % 30 == 0);
        }

        public bool IsAnInteger()
        {
            return !(this.Minutes.Contains("."));
        }

        public bool IsPositive()
        {
            return (Convert.ToInt32(this.Minutes) > 0);
        }

        public bool IsValidHourFormat()
        {
            return !CouldNotParseDate() && Regex.IsMatch(this.StartingHour.ToString("HH:mm"), "^([0-9]{2}[:][0-9]{2})$");
        }

        public bool CouldNotParseDate()
        {
            return this.StartingHour.Equals(DateTime.MinValue);
        }
        public bool IsWithinRangeOfHours()
        {
            return this.StartingHour >= this.LowerHourLimit && this.StartingHour <= this.UpperHourLimit;
        }

        public bool IsHourForToday(DateTime toCompare)
        {
            DateTime toCompareAccountForTransactionTime = AdjustTimeToAccountForTransactionTime(toCompare);
            return toCompare <= this.StartingHour;
        }

        public DateTime AdjustTimeToAccountForTransactionTime(DateTime toAdjust)
        {
            return toAdjust.AddSeconds(-10);
        }


        public string InputPlate()
        {
            return this.Plates;
        }

        public string InputMinutes()
        {
            return this.Minutes;
        }

        public string InputSartingHour()
        {
            return this.StartingHour;
        }

        public DateTime SetEndingHour()
        {
            var startingHourPlusMinutes = this.StartingHour.AddMinutes(Double.Parse(this.Minutes));
            var maxEndingHour = this.UpperHourLimit;
            var endingHour = startingHourPlusMinutes > maxEndingHour ? maxEndingHour : startingHourPlusMinutes;
            return endingHour;
        }



    }
}



