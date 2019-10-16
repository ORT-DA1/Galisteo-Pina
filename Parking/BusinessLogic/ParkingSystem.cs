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

        public Notification IsRegisteredNumber(string cellPhoneNumber)
        {
            Notification notification = new Notification();
            if (!AccountRepository.AccountAlreadyExists(cellPhoneNumber))
                notification.AddError("Móvil no registrado");
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

        public Notification ValidateSms(Sms smsToValidate)
        {
            SmsValidator smsValidator = new SmsValidator(smsToValidate);
            return smsValidator.Validate();
        }

        public Notification AnyPurchaseMatchesPlateAndHour(string plates, string dateToCompare)
        {
            Notification notification = new Notification();
            if (PurchaseRepository.AnyPurchaseMatchesPlateAndDateTime(plates, dateToCompare))
                notification.AddSuccess("There is an existing parking purchase for that plate and hour");
            else
                notification.AddError("No result found");
            return notification;
        }

        public Notification AdjustParkingCostPerMinute(int newCostPerMinute)
        {
            ParkingCost.CostPerMinute = newCostPerMinute;
            Notification notification = new Notification();
            notification.AddSuccess("Parking cost was changed successfully ");
            return notification;
        }

    }
}