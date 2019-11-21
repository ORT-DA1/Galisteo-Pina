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
    
    public class UyCellPhoneValidator: CellPhoneValidator, ICellPhoneValidator
    {
        public override CountriesInSystem CellPhoneValidatorCountry { get; set; } = CountriesInSystem.URUGUAY;

        public override bool PhoneNumberCorrectFormat(string cellPhoneNumberToValidate)
        {
            var cellPhoneNumber = this.NormalizePhoneNumber(cellPhoneNumberToValidate);
            if (PhoneNumberNotEmpty(cellPhoneNumberToValidate))
            {
                return Regex.IsMatch(cellPhoneNumber, "[0][9][0-9]{7}")  ||
                        Regex.IsMatch(cellPhoneNumber, "[9][0-9]{7}");
            }
            return false;
        }

        public bool PhoneNumberStartWithNine(string cellPhoneNumber)
        {
            if (PhoneNumberNotEmpty(cellPhoneNumber))
            {
                return Regex.IsMatch(cellPhoneNumber, "^([9][0-9]{7})$");
            }
                return false;
        }

        public string NormalizePhoneNumber(string cellPhoneNumber)
        {
            return cellPhoneNumber.Replace(" ", "");
        }

        public override string StandarizePhoneNumber(string cellPhoneNumber)
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
