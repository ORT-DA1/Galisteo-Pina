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

    public class ArgCellPhoneValidator : CellPhoneValidator, ICellPhoneValidator
    {
        public override CountriesInSystem CellPhoneValidatorCountry { get; set; } = CountriesInSystem.ARGENTINA;

        public const int MIN_LENGTH_WITH_HYPHEN = 7;

        public override bool PhoneNumberCorrectFormat(string cellPhoneNumberToValidate)
        {
            var cellPhoneNumber = this.NormalizePhoneNumber(cellPhoneNumberToValidate);
            if (PhoneNumberNotEmpty(cellPhoneNumberToValidate))
            {
                return Regex.IsMatch(cellPhoneNumber, "^([0-9]{6,8})$");
            }
            return false;
        }

        public bool NoHyphensOnFirstOrLastCharacter(string cellPhoneNumber)
        {
            return cellPhoneNumber[0] != '-' && cellPhoneNumber[cellPhoneNumber.Length - 1] != '-';
        }

        public string NormalizePhoneNumber(string cellPhoneNumber)
        {
            if (cellPhoneNumber.Length >= MIN_LENGTH_WITH_HYPHEN && NoHyphensOnFirstOrLastCharacter(cellPhoneNumber))
                cellPhoneNumber = cellPhoneNumber.Replace("-", "");
            return cellPhoneNumber;
        }
         
        public override string StandarizePhoneNumber(string cellPhoneNumber)
        {
            if (cellPhoneNumber.Length >= MIN_LENGTH_WITH_HYPHEN && NoHyphensOnFirstOrLastCharacter(cellPhoneNumber))
                cellPhoneNumber = cellPhoneNumber.Replace("-", "");
            return cellPhoneNumber;
        }

    }
}
