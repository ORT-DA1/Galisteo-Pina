using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class ParkingSystem
    {
        public IAccountRepository AccountRepository { get; set; }
        public IPurchaseRepository PurchaseRepository { get; set; }

        public ParkingSystem()
        {
            AdjustParkingCostPerMinute(1);
            AccountRepository = new InMemoryAccountRepository();
            PurchaseRepository = new InMemoryPurchaseRepository();
        }

        public Notification AddAccount(string cellPhoneNumber)
        {
            Notification notification = AccountRepository.AddAccount(cellPhoneNumber);
            return notification;
        }
        public Notification AddAmmountToBalance(string cellPhoneNumber, string ammountToAdd)
        {
            Notification notification = AccountRepository.AddBalanceToAccount(cellPhoneNumber, ammountToAdd);
            return notification;
        }
        public Notification AddPurchase(Purchase purchase)
        {
            Notification notification = new Notification();
            notification = PurchaseRepository.AddPurchase(purchase);
            return notification;
        }
        public Account GetAccountByPhoneNumber(string cellPhoneNumber)
        {
            return AccountRepository.FindAccountByCellPhoneNumber(cellPhoneNumber);
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
            if (AccountRepository.AccountAlreadyExists(cellPhoneNumber))
                notification.AddError("La cuenta ya existe en el sistema");
            return notification;

        }
        public Notification ValidateExistingAccountForAccountTransaction(string cellPhoneNumber)
        {
            Notification notification = new Notification();
            if (!AccountRepository.AccountAlreadyExists(cellPhoneNumber))
                notification.AddError("Móvil no registrado");
            return notification;

        }
        public Notification AnyPurchaseMatchesPlateAndHour(string plates, string dateToCompare)
        {
            Notification notification = new Notification();
            if (PurchaseRepository.AnyPurchaseMatchesPlateAndDateTime(plates, dateToCompare))
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

    }
}