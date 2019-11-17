using Entities.Validation;
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
        public static List<ISmsValidator> SmsValidators { get; set; } = InitializeSmsValidators();
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

        public static List<ISmsValidator> InitializeCellPhoneValidators()
        {
            List<ISmsValidator> smsValidators = new List<ISmsValidator>();
            smsValidators.Add(new UySmsValidator());
            smsValidators.Add(new ArgSmsValidator());
            return smsValidators;
        }

        public static List<ISmsValidator> InitializeSmsValidators()
        {
            List<ISmsValidator> smsValidators = new List<ISmsValidator>();
            smsValidators.Add(new UySmsValidator());
            smsValidators.Add(new ArgSmsValidator());
            return smsValidators;
        }

        public static ISmsValidator GetSmsValidator(Country country)
        {
            return SmsValidators.Find(s => s.SmsValidatorCountry.ToString() == country.Name);
        }

        public void SetHourBounds(DateTime lowerBound, DateTime upperBound)
        {
            this.LowerHourLimit = lowerBound;
            this.UpperHourLimit = upperBound;
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



