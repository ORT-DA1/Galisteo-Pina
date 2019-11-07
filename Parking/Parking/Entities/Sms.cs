using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entities
{
    public class Sms
    {
        [ForeignKey("Purchase")]
        public int SmsId { get; set; }
        public string Plates { get; set; }

        public string Minutes { get; set; }

        public DateTime StartingHour { get; set; }

        public DateTime EndingHour { get; set; }

        public DateTime LowerHourLimit { get; set; }

        public DateTime UpperHourLimit { get; set; }

        public virtual Purchase Purchase { get; set; }

        public Sms()
        {
            this.Plates = "";
            this.Minutes = "";
            this.StartingHour = DateTime.MinValue;
            this.EndingHour = DateTime.MinValue;
            this.LowerHourLimit = DateTime.Parse("10:00");
            this.UpperHourLimit = DateTime.Parse("22:00");
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

        public DateTime SetEndingHour()
        {
            DateTime endingHour = DateTime.MinValue;
            if(this.Minutes != null)
            {
                var startingHourPlusMinutes = this.StartingHour.AddMinutes(Double.Parse(this.Minutes));
                var maxEndingHour = this.UpperHourLimit;
                endingHour = startingHourPlusMinutes > maxEndingHour ? maxEndingHour : startingHourPlusMinutes;
            }
            return endingHour;
        }

        public override bool Equals(object obj)
        {
            var sms = obj as Sms;
            if (sms == null)
                return false;
            return this.Plates == sms.Plates && this.Minutes == sms.Minutes && this.StartingHour == sms.StartingHour;
        }

        public override int GetHashCode()
        {
            var hash = 11;
            hash = (hash * 11) + this.Plates.GetHashCode();
            hash = (hash * 11) + this.Minutes.GetHashCode();
            return hash;
        }

    }
}



