using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLogic
{
    
    public class CellPhoneValidator: Validator, IValidation
    {
       public string CellPhoneNumberToValidate { get; set; }

        public CellPhoneValidator()
        {
        }

        public CellPhoneValidator(string cellPhoneNumber)
        {
            this.CellPhoneNumberToValidate = cellPhoneNumber;
        }

        public Notification Validate()
        {
            Notification notification = new Notification();
            if (!PhoneNumberNotEmpty())
                notification.AddError("No se ha indicado un número de celular");
            if (!PhoneNumberCorrectFormat())
                notification.AddError("Formato de celular incorrecto");

            return notification;
        }


        public bool PhoneNumberNotEmpty()
        {
            return NotEmpty(this.CellPhoneNumberToValidate);
        }

        public bool PhoneNumberCorrectFormat()
        {
            var cellPhoneNumber = this.NormalizePhoneNumber(this.CellPhoneNumberToValidate);
            if (PhoneNumberNotEmpty())
            {
                return Regex.IsMatch(cellPhoneNumber, "[0][9][0-9]{7}")  ||
                        Regex.IsMatch(cellPhoneNumber, "[9][0-9]{7}");
            }
            return false;
        }

        public bool PhoneNumberStartWithNine(string cellPhoneNumber)
        {
            if (PhoneNumberNotEmpty())
            {
                return Regex.IsMatch(cellPhoneNumber, "^([9][0-9]{7})$");
            }
                return false;
        }

        public string NormalizePhoneNumber(string cellPhoneNumber)
        {
            return cellPhoneNumber.Replace(" ", "");
        }

        public string StandarPhoneNumber(string cellPhoneNumber)
        {
            cellPhoneNumber = NormalizePhoneNumber(cellPhoneNumber);
            if (PhoneNumberStartWithNine(cellPhoneNumber))
            {
                cellPhoneNumber = $"{0}{cellPhoneNumber}";
            }
            return cellPhoneNumber;
        }
        
    }
}
