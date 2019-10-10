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

        public string StartingHour { get; set; }

        public Sms()
        {
            this.Plates = "";
            this.Minutes = "";
            this.StartingHour = DateTime.Now.ToString("HH:mm");
        }


        public void Initialize(string smsMessageText)
        {
            string smsMessageTextNormalized = NormalizeMessagePlate(smsMessageText);
            string[] splitSmsMessage = TrimAndSplitMessage(smsMessageTextNormalized);
            this.Plates = ExtractPlates(splitSmsMessage);
            this.Minutes = ExtractMinutes(splitSmsMessage);
            if (SmsHasStartingHour(splitSmsMessage)) this.StartingHour = ExtractStartingHour(splitSmsMessage);

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

        public string ExtractStartingHour(string[] splitMessage)
        {
            return Extract(splitMessage, "[:]");
        }

        public Notification Validate()
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
            if (!IsHourForToday(DateTime.Now))
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
            return Regex.IsMatch(this.StartingHour, "^([0-9]{2}[:][0-9]{2})$");
        }

        public bool IsWithinRangeOfHours()
        {
            return Regex.IsMatch(this.StartingHour, "[1][0-8][:][0-5][0-9]");
        }

        public bool IsHourForToday(DateTime toCompare)
        {
            return DateTime.Compare(DateTime.Parse(this.StartingHour), toCompare) >= 0;
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
    }
}

