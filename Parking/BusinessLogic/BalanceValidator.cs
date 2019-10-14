using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class BalanceValidator : Validator, IValidation
    {
        public string AmmountToValidate { get; set; }

        public BalanceValidator(string ammountToValidate)
        {
            this.AmmountToValidate = ammountToValidate;
        }

        public Notification Validate()
        {
            Notification notification = new Notification();
            if (!IsAnInteger(this.AmmountToValidate))
                notification.AddError("Ammount has to be an integer");
            if (!IsPositive(this.AmmountToValidate))
                notification.AddError("Ammount has to be a positive number");
            return notification;
        }


    }
}