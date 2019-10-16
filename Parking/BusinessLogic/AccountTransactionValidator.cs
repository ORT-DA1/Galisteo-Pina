using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class AccountTransactionValidator:Validator, IValidation
    {
        public Account AccountToValidate { get; set; }
        public int TransactionSum { get; set; }

        public AccountTransactionValidator(Account accountToValidate, int transactionSum)
        {
            this.AccountToValidate = accountToValidate;
            this.TransactionSum = transactionSum;
        }

        public Notification Validate()
        {
            Notification notification = new Notification();
            if (!AccountHasBalanceForTransaction())
                notification.AddError("Saldo insuficiente");

            return notification;
        }

        public bool AccountHasBalanceForTransaction()
        {
            return AccountToValidate.AccountBalance - TransactionSum >= 0;
        }
    }

}
