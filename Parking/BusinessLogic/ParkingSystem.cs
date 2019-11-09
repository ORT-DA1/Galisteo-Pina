using Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entities;

namespace BusinessLogic
{
    public class ParkingSystem
    {
        public IUnitOfWork UnitOfWork { get; set; }
        public Country CurrentCountry { get; set; } 
        public List<Country> CountriesInMemory { get; set; }

        public ParkingSystem()
        {
            AdjustParkingCostPerMinute(1);
            UnitOfWork = new UnitOfWork();
            InitializeCountriesInSystem();
            LoadCountriesInMemory();
            SetInitialCountry();
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
            Notification notification = UnitOfWork.Purchases.AddPurchase(purchase);
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
            Sms purchaseSms = new Sms();
            purchaseSms.Initialize(sms);
            return purchaseSms;
        }
        public string FormatPhoneNumber(string cellPhoneToFormat)
        {
            CellPhoneValidator cellPhoneValidator = new CellPhoneValidator();
            return cellPhoneValidator.StandarPhoneNumber(cellPhoneToFormat);
        }
        public Notification ValidateSms(Sms smsToValidate)
        {
            SmsValidator smsValidator = new SmsValidator(smsToValidate);
            return smsValidator.Validate();
        }
        public Notification ValidatePhoneNumber(string cellPhoneToValidate)
        {
            CellPhoneValidator cellPhoneValidator = new CellPhoneValidator(cellPhoneToValidate);
            Notification notification = cellPhoneValidator.Validate();
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
            ParkingCost.CostPerMinute = newCostPerMinute;
            Notification notification = new Notification();
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

        public void SetInitialCountry()
        {
            this.CurrentCountry = this.CountriesInMemory.First(c => c.Name == Country.CountriesInSystem.URUGUAY.ToString());
        }
        public IEnumerable<Country> GetCountries()
        {
            return UnitOfWork.Countries.GetCountries();
        }

    }
}