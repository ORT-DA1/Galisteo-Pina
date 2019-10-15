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

        public Notification AddPurchase(string cellPhoneNumber, string sms)
        {
            Account account = AccountRepository.FindAccountByCellPhoneNumber(cellPhoneNumber);
            Notification notification = new Notification();
            if (account == null)
            {
                notification.AddError("The account does not exist");
                return notification;
            }
                notification = PurchaseRepository.AddPurchase(account, sms);
            return notification;
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

        public Notification AdjustParkingCostPerMinute(int newCostPerMinute) //Validar
        {
            ParkingCost.CostPerMinute = newCostPerMinute;
            Notification notification = new Notification();
            notification.AddSuccess("Parking cost was changed successfully ");
            return notification;
        }

    }
}