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

    public abstract class CellPhoneValidator : Validator, ICellPhoneValidator
    {
       public abstract CountriesInSystem CellPhoneValidatorCountry {get; set;}
        
           
        public CellPhoneValidator()
        {
        }

        public Notification ValidateCellPhone(string cellPhoneNumberToValidate)
        {
            Notification notification = new Notification();
            if (!PhoneNumberNotEmpty(cellPhoneNumberToValidate))
                notification.AddError("No se ha indicado un número de celular");
            if (!PhoneNumberCorrectFormat(cellPhoneNumberToValidate))
                notification.AddError("Formato de celular incorrecto");
            return notification;
        }


        public bool PhoneNumberNotEmpty(string cellPhoneNumberToValidate)
        {
            return NotEmpty(cellPhoneNumberToValidate);
        }

        public abstract bool PhoneNumberCorrectFormat(string cellPhoneNumberToValidate);
        public abstract string StandarizePhoneNumber(string cellPhoneNumberToStandarize);
    }
}
