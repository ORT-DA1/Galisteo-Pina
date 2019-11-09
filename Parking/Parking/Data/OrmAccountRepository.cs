using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Entities.Repositories;

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
            CellPhoneValidator cellPhoneValidator = new CellPhoneValidator(account.AccountCellPhoneNumber);
            notification = cellPhoneValidator.Validate();
            if (!notification.HasErrors())
            {
                Add(account);
                notification.AddSuccess("Cuenta creada con éxito");
            }
            return notification;
        }



        public Account FindAccountByCellPhoneNumber(string cellPhoneNumberToMatch)
        {
            CellPhoneValidator cellPhoneValidator = new CellPhoneValidator(cellPhoneNumberToMatch);
            cellPhoneNumberToMatch = cellPhoneValidator.StandarPhoneNumber(cellPhoneNumberToMatch);
            return ParkingContext.Accounts.FirstOrDefault(account => account.AccountCellPhoneNumber == cellPhoneNumberToMatch);
        }

        public bool AccountAlreadyExists(Account account)
        {
            CellPhoneValidator cellPhoneValidator = new CellPhoneValidator();
            string cellPhoneNumber = cellPhoneValidator.StandarPhoneNumber(account.AccountCellPhoneNumber);
            return ParkingContext.Accounts.Any(a => a.AccountCellPhoneNumber == cellPhoneNumber);
        }
    }
}
