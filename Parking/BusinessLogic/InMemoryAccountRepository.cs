using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class InMemoryAccountRepository : IAccountRepository
    {
        protected List<Account> AccountsRecord { get; set; }

        public InMemoryAccountRepository()
        {
            AccountsRecord = new List<Account>();
        }

        public Notification AddAccount(string cellPhoneNumber)
        {
            Notification notification = new Notification();
            AccountsRecord.Add(new Account(cellPhoneNumber));
            notification.AddSuccess("Cuenta creada con éxito");
            return notification;
        }

        public Notification AddBalanceToAccount(string cellPhoneNumber, string ammount)
        {
            Notification notification = new Notification();
            BalanceValidator balanceValidator = new BalanceValidator(ammount);
            notification = balanceValidator.Validate();
            if (account != null && !notification.HasErrors())
            {
                existingAccount.AddMoneyToBalance(ammount);
                notification.AddSuccess("Saldo agregado con exito");
            }
            return notification;
        }

        public Account FindAccountByCellPhoneNumber(string cellPhoneNumberToMatch)
        {
            CellPhoneValidator cellPhoneValidator = new CellPhoneValidator(cellPhoneNumberToMatch);
            cellPhoneNumberToMatch = cellPhoneValidator.StandarPhoneNumber(cellPhoneNumberToMatch);
            return AccountsRecord.FirstOrDefault(account => account.AccountCellPhoneNumber == cellPhoneNumberToMatch);
        }

        public bool ThereAreRecordedAccounts()
        {
            return AccountsRecord.Count > 0;
        }

        public bool AccountAlreadyExists(string cellPhoneNumberToMatch)
        {
            CellPhoneValidator cellPhoneValidator = new CellPhoneValidator(cellPhoneNumberToMatch);
            cellPhoneNumberToMatch = cellPhoneValidator.StandarPhoneNumber(cellPhoneNumberToMatch);
            return AccountsRecord.Exists(account => account.AccountCellPhoneNumber == cellPhoneNumberToMatch);
        }

    }
}
