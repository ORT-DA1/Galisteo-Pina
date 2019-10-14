using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class InMemoryAccountRepository:IAccountRepository
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

            if(!notification.HasErrors())
            {
                AccountsRecord.Add(new Account(cellPhoneNumber));
                notification.AddSuccess("Account was successfully created.");
            }

            return notification;
        }

        public Notification AddBalanceToAccount(string cellPhoneNumber, string ammount)
        {
            Notification notification = new Notification();
            Account account = FindAccountByCellPhoneNumber(cellPhoneNumber);
            if (account == null)
            {
                notification.AddError("Account not found");
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
                notification.AddSuccess("Balance successfully added");
            }
            return notification;
        }

        public Account FindAccountByCellPhoneNumber(string cellPhoneNumberToMatch)
        {
            return AccountsRecord.First(account => account.AccountCellPhoneNumber == cellPhoneNumberToMatch);
        }

        public bool ThereAreRecordedAccounts()
        {
            return AccountsRecord.Count > 0;
        }

    }
}
