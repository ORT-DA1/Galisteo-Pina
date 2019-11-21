using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Validator
    {

        public bool NotEmpty(string isItEmpty)
        {
            return isItEmpty != string.Empty;
        }

        public bool IsAnInteger(string isItInteger)
        {
            int integerNumber;
            return Int32.TryParse(isItInteger, out integerNumber);
        }

        public bool IsPositive(string isItPositive)
        {
            Decimal decimalNumber;
            return (Decimal.TryParse(isItPositive, out decimalNumber) && decimalNumber > 0);
        }
    }
}
