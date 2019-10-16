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

            if (MissingInput(SmsToValidate.Plates))
                notification.AddError("Matricula no ingresada");
            if (MissingInput(SmsToValidate.Minutes))
                notification.AddError("Minutos no ingresados");
            if (!ValidateMinutes())
                notification.AddError("Los minutos deben ser un numero positivo y multiplo de 30");
            if (!IsValidHourFormat())
                notification.AddError("Formato de hora invalido. Debe ser: HH:mm");
            if (!IsWithinRangeOfHours())
                notification.AddError("Rango invalido de horas. Debe ser entre 10:00 y 18:00");
            if (!IsHourForToday())
                notification.AddError("Solo es posible comprar horas de parking para el dia corriente");
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
            return DateTime.Now <= SmsToValidate.StartingHour;
        }



    }
}
