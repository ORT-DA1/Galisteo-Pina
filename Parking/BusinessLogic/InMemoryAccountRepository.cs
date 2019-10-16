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
            CellPhoneValidator cellPhoneValidator = new CellPhoneValidator(cellPhoneNumber);
            Notification notification = cellPhoneValidator.Validate();
            cellPhoneNumber = cellPhoneValidator.StandarPhoneNumber(cellPhoneNumber);

            if (!notification.HasErrors())
            {
                if (!AccountAlreadyExists(cellPhoneNumber))
                {
                    AccountsRecord.Add(new Account(cellPhoneNumber));
                    notification.AddSuccess("Cuenta creada con éxito");
                }
                else
                {
                    notification.AddError("La cuenta ya existe en el sistema");
                }
            }

            return notification;
        }

        public Notification AddBalanceToAccount(string cellPhoneNumber, string ammount)
        {
            Notification notification = new Notification();
            CellPhoneValidator cellPhoneValidator = new CellPhoneValidator(cellPhoneNumber);
            notification = cellPhoneValidator.Validate();
            cellPhoneNumber = cellPhoneValidator.StandarPhoneNumber(cellPhoneNumber);
            Account account = FindAccountByCellPhoneNumber(cellPhoneNumber);
            if (account == null)
            {
                notification.AddError("Cuenta no encontrada");
                return notification;
            }
            return AddBalanceToExistingAccount(account, ammount);
        }

        public Notification AddBalanceToExistingAccount(Account existingAccount, string ammount)
        {
            CellPhoneValidator cellPhoneValidator = new CellPhoneValidator(existingAccount.AccountCellPhoneNumber);
            BalanceValidator balanceValidator = new BalanceValidator(ammount);
            Notification notification = cellPhoneValidator.Validate();
            notification.AppendNotificationErrors(balanceValidator.Validate());

            if (!notification.HasErrors())
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
