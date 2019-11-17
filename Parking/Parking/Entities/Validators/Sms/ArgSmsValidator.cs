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
    public class ArgSmsValidator : SmsValidator, ISmsValidator
    {
        public override CountriesInSystem SmsValidatorCountry { get; set; } = CountriesInSystem.ARGENTINA;
        public override bool IsCorrectFormat(Sms smsToValidate)
        {
            return true;
        }

        public override bool ValidateMinutes(Sms smsToValidate)
        {
            return true;
        }
        public bool IsMultipleOf30(Sms smsToValidate)
        {
            return (Convert.ToInt32(smsToValidate.Minutes) % 30 == 0);
        }

        public override Sms GetInitializedSms(string smsMessageText)
        {
            return new Sms();
        }


      

    }
}

