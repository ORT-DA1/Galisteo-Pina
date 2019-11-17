using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Entities.Repositories;
using Entities.Validation;

namespace Data
{
    public class OrmAccountRepository: Repository<Account>, IAccountRepository
    {
        public ParkingContext ParkingContext
        {
            get { return Context as ParkingContext; }
        }

        public OrmAccountRepository(ParkingContext context) : base(context)
        {
        }

        public Notification AddAccount(Account account)
        {
            Notification notification;
            ICellPhoneValidator cellPhoneValidator = Account.GetCellPhoneValidator(account.AccountCountry);
            notification = cellPhoneValidator.ValidateCellPhone(account.AccountCellPhoneNumber);
            if (!notification.HasErrors())
            {
                Add(account);
                notification.AddSuccess("Cuenta creada con éxito");
            }
            return notification;
        }



        public Account FindAccountByCellPhoneNumber(string cellPhoneNumberToMatch)
        {
            //ICellPhoneValidator cellPhoneValidator = Account.GetCellPhoneValidator(account.AccountCountry);
            //cellPhoneNumberToMatch = cellPhoneValidator.StandarPhoneNumber(cellPhoneNumberToMatch);
            return ParkingContext.Accounts.FirstOrDefault(account => account.AccountCellPhoneNumber == cellPhoneNumberToMatch);
        }

        public bool AccountAlreadyExists(Account account)
        {
            //ICellPhoneValidator cellPhoneValidator = Account.GetCellPhoneValidator(account.AccountCountry);
            //string cellPhoneNumber = cellPhoneValidator.StandarPhoneNumber(account.AccountCellPhoneNumber);
            return ParkingContext.Accounts.Any(a => a.AccountCellPhoneNumber == account.AccountCellPhoneNumber);
        }
    }
}
