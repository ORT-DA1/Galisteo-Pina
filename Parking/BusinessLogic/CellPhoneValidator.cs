using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class CellPhoneValidator
    {
        public CellPhoneValidator()
        {
        }

        public bool PhoneNumberNotEmpty(string cellPhoneNumber)
        {
            return (cellPhoneNumber.Length == 0) ? false : true;
        }

        public bool PhoneNumberStartWhitZeroNine(string cellPhoneNumber)
        {
            int stringPositionZero = 0;
            return (cellPhoneNumber.ElementAt(stringPositionZero)== '0') ? true : false;
        }

        public bool PhoneNumberStartWhitNine(string cellPhoneNumber)
        {
            int stringPositionZero = 0;
            return (cellPhoneNumber.ElementAt(stringPositionZero) == '9') ? true : false;
        }

        public bool PhoneNumberLenghtIsCorrect(string cellPhoneNumber)
        {
            bool correctLenght = false;
            if (PhoneNumberStartWhitZeroNine(cellPhoneNumber))
            {
                if (cellPhoneNumber.Length == 9)
                    correctLenght = true;
            }
            else if (PhoneNumberStartWhitNine(cellPhoneNumber))
            {
                if (cellPhoneNumber.Length == 8)
                    correctLenght = true;
            }
            return correctLenght;
        }

        public string NormalizePhoneNumber(string cellPhoneNumber)
        {
            return cellPhoneNumber.Replace(" ", "");
        }

        public bool PhoneNumberCorrectFormat(string cellPhoneNumber)
        {
            cellPhoneNumber = this.NormalizePhoneNumber(cellPhoneNumber);
            bool correctFormat = false;
            if (PhoneNumberNotEmpty(cellPhoneNumber))
            {
                if (PhoneNumberStartWhitZeroNine(cellPhoneNumber) && PhoneNumberLenghtIsCorrect(cellPhoneNumber))
                {
                    correctFormat = true;
                }
                else if(PhoneNumberStartWhitNine(cellPhoneNumber) && PhoneNumberLenghtIsCorrect(cellPhoneNumber))
                { 
                    correctFormat = true;
                }
            }
            return correctFormat;
        }
    }
}
