using Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entities;
using Entities.Validation;
using System.Data.Entity;

namespace BusinessLogic
{
    public class ParkingSystem
    {
        public IUnitOfWork UnitOfWork { get; set; }
        public Country CurrentCountry { get; set; } 
        public List<Country> CountriesInMemory { get; set; }
        public List<Purchase> Purchases { get; set; } 
        public ParkingSystem(IUnitOfWork unitOfWork)
        {
   
            UnitOfWork = unitOfWork;
            InitializeCountriesInSystem();
            LoadCountriesInMemory();
            SetInitialCountry();
            Purchases = UnitOfWork.Purchases.GetAll().ToList();
        }

        public Notification AddAccount(string cellPhoneNumber)
        {
            Account account = new Account(cellPhoneNumber, CurrentCountry);
            Notification notification = UnitOfWork.Accounts.AddAccount(account);
            if (!notification.HasErrors())
            {
                UnitOfWork.Save();
            }
            return notification;

        }

        public Notification AddAmmountToBalance(string cellPhoneNumber, string ammountToAdd)
        {
            BalanceValidator balanceValidator = new BalanceValidator(ammountToAdd);
            Notification notification = balanceValidator.Validate();
            Account account = UnitOfWork.Accounts.FindAccountByCellPhoneNumber(cellPhoneNumber);

            if (account != null && !notification.HasErrors())
                {
                    account.AddMoneyToBalance(ammountToAdd);
                UnitOfWork.Save();
                notification.AddSuccess("Saldo agregado con exito");
                }

            return notification;
        }

        public Notification AddPurchase(Purchase purchase)
        {
            Notification notification = UnitOfWork.Purchases.AddPurchase(purchase, CurrentCountry.CostPerMinut);
            if (!notification.HasErrors())
            {
                UnitOfWork.Save();
            }
            return notification;
        }

        public Account GetAccountByPhoneNumber(string cellPhoneNumber)
        {
            return UnitOfWork.Accounts.FindAccountByCellPhoneNumber(cellPhoneNumber);
        }

        public Sms FormatSmsForPurchase(string sms)
        {
            ISmsValidator smsValidator = Sms.GetSmsValidator(CurrentCountry);
            return smsValidator.GetInitializedSms(sms);
        }
        public string FormatPhoneNumber(string cellPhoneToFormat)
        {
            ICellPhoneValidator cellPhoneValidator = Account.GetCellPhoneValidator(CurrentCountry);
            return cellPhoneValidator.StandarizePhoneNumber(cellPhoneToFormat);

        }
        public Notification ValidateSms(Sms smsToValidate)
        {
            ISmsValidator smsValidator = Sms.GetSmsValidator(CurrentCountry);
            return smsValidator.ValidateSms(smsToValidate);
        }
        public Notification ValidatePhoneNumber(string cellPhoneToValidate)
        {
            ICellPhoneValidator cellPhoneValidator = Account.GetCellPhoneValidator(CurrentCountry);
            Notification notification = cellPhoneValidator.ValidateCellPhone(cellPhoneToValidate);
            return notification;
        }
        public Notification ValidateExistingAccountForAddingAccount(string cellPhoneNumber)
        {
            Notification notification = new Notification();
            Account account = new Account(cellPhoneNumber);
            if (UnitOfWork.Accounts.AccountAlreadyExists(account))
                notification.AddError("La cuenta ya existe en el sistema");
            return notification;

        }
        public Notification ValidateExistingAccountForAccountTransaction(string cellPhoneNumber)
        {
            Notification notification = new Notification();
            Account account = new Account(cellPhoneNumber);
            List<Account> asd = UnitOfWork.Accounts.GetAll().ToList();
            if (!UnitOfWork.Accounts.AccountAlreadyExists(account))
                notification.AddError("Móvil no registrado");
            return notification;

        }
        public Notification AnyPurchaseMatchesPlateAndHour(string plates, string dateToCompare)
        {
            Notification notification = new Notification();
            if (UnitOfWork.Purchases.AnyPurchaseMatchesPlateAndDateTime(plates, dateToCompare))
                notification.AddSuccess("Existe una compra de estacionamiento vigente para esa matrícula y hora");
            else
                notification.AddError("Ningún resultado encontrado para la consulta");

            return notification;
        }
        public Notification AdjustParkingCostPerMinute(int newCostPerMinute)
        {
            CurrentCountry.CostPerMinut = newCostPerMinute;
            Notification notification = new Notification();
            UnitOfWork.Save();
            notification.AddSuccess("Costo del estacionamiento cambiado con éxito");
            return notification;
        }
        public void InitializeCountriesInSystem()
        {
            UnitOfWork.Countries.AddCountries(Country.GetCountriesInSystem());
            UnitOfWork.Save();
        }
        public void LoadCountriesInMemory()
        {
            this.CountriesInMemory = GetCountries() as List<Country>;
        }
        public IEnumerable<Country> GetCountries()
        {
            return UnitOfWork.Countries.GetCountries();
        }
        public void SetInitialCountry()
        {
            this.CurrentCountry = this.CountriesInMemory.First(c => c.Name == Country.CountriesInSystem.ARGENTINA.ToString());
        }


        public List<Purchase> GetMatchingPurchases(DateTime startinHour, DateTime endingHour, string plates, Country filterCountry = null)
        {
            return UnitOfWork.Purchases.GetPurchasesMatchDateAndCountry(startinHour, endingHour, plates, filterCountry).ToList();
        }

}
}
