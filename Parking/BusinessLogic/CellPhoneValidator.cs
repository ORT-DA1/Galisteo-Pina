using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Account
    {
        public string CellPhoneNumber { get; set; }

        public Account()
        {
            CellPhoneNumber = "";
        }

        public bool PhoneNumberNotEmpty()
        {
            return (this.CellPhoneNumber.Length == 0) ? false : true;
        }

        public bool PhoneNumberStartWhitZeroNine()
        {
            int stringPositionZero = 0;
            return (this.CellPhoneNumber.ElementAt(stringPositionZero)== '0') ? true : false;
        }

        public bool PhoneNumberStartWhitNine()
        {
            int stringPositionZero = 0;
            return (this.CellPhoneNumber.ElementAt(stringPositionZero) == '9') ? true : false;
        }

        public bool PhoneNumberLenghtIsCorrect()
        {
            bool correctLenght = false;
            if (PhoneNumberStartWhitZeroNine())
            {
                if (this.CellPhoneNumber.Length == 9)
                    correctLenght = true;
            }
            else if (PhoneNumberStartWhitNine())
            {
                if (this.CellPhoneNumber.Length == 8)
                    correctLenght = true;
            }
            return correctLenght;
        }

        public void NormalizePhoneNumber()
        {
            this.CellPhoneNumber = this.CellPhoneNumber.Replace(" ", "");
        }

        public bool PhoneNumberCorrectFormat()
        {
            this.NormalizePhoneNumber();
            bool correctFormat = false;
            if (PhoneNumberNotEmpty())
            {
                if (PhoneNumberStartWhitZeroNine() && PhoneNumberLenghtIsCorrect())
                {
                    correctFormat = true;
                }
                else if(PhoneNumberStartWhitNine() && PhoneNumberLenghtIsCorrect())
                { 
                    correctFormat = true;
                }
            }
            return correctFormat;
        }

        
    }
}
