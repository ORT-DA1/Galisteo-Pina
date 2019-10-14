using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            bool correctFormat = false;
            if (PhoneNumberNotEmpty())
            {
                return (PhoneNumberStartWhithZeroNine(cellPhoneNumber) && PhoneNumberLenghtIsCorrect(cellPhoneNumber)) ||
                       (PhoneNumberStartWhithNine(cellPhoneNumber) && PhoneNumberLenghtIsCorrect(cellPhoneNumber));
            }
            return correctFormat;
        }

        public string NormalizePhoneNumber(string cellPhoneNumber)
        {
            return cellPhoneNumber.Replace(" ", "");
        }
        public bool PhoneNumberStartWhithZeroNine(string cellPhoneNumber)
        {
            int stringPositionZero = 0;
            return (cellPhoneNumber.ElementAt(stringPositionZero)== '0');
        }

        public bool PhoneNumberStartWhithNine(string cellPhoneNumber)
        {
            int stringPositionZero = 0;
            return (cellPhoneNumber.ElementAt(stringPositionZero) == '9');
        }

        public bool PhoneNumberLenghtIsCorrect(string cellPhoneNumber)
        {
            bool correctLenght = false;
            if (PhoneNumberStartWhithZeroNine(cellPhoneNumber))
            {
                if (cellPhoneNumber.Length == 9)
                    correctLenght = true;
            }
            else if (PhoneNumberStartWhithNine(cellPhoneNumber))
            {
                if (cellPhoneNumber.Length == 8)
                    correctLenght = true;
            }
            return correctLenght;
        }
    }
}
