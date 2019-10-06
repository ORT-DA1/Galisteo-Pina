using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class BalanceValidator
    {

        public BalanceValidator()
        {
        }

        public bool BalanceIsIntegerNumber(string balance)
        {
            int integerNumber;
            return Int32.TryParse(balance, out integerNumber);
        }

        public int NormalizedBalance(string balance)
        {
            return int.Parse(balance);
        }

        public bool BalanceIsPositiveNumber(string balance)
        {
            int normalizedBalance = this.NormalizedBalance(balance);
            return (normalizedBalance >= 0) ? true : false;
        }
    }
}
