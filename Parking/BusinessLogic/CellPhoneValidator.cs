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

        public CellPhoneValidator(string cellPhoneNumber)
        {
            this.CellPhoneNumberToValidate = cellPhoneNumber;
        }

        public Notification Validate()
        {
            Notification notification = new Notification();
            if (!PhoneNumberNotEmpty())
                notification.AddError("Phone number is empty");
            if (!PhoneNumberCorrectFormat())
                notification.AddError("Phone number does not have the correct format");
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

        public bool PhoneNumberStartWithNine()
        {
            var cellPhoneNumber = this.CellPhoneNumberToValidate;
            if (PhoneNumberNotEmpty())
            {
                return Regex.IsMatch(cellPhoneNumber, "[9][0-9]{7}");
            }
            else
                return false;
        }

        public string NormalizePhoneNumber(string cellPhoneNumber)
        {
            if (PhoneNumberStartWithNine())
            {
                cellPhoneNumber.Insert(0, "0");
            }
            return cellPhoneNumber.Replace(" ", "");
        }
        
    }
}
