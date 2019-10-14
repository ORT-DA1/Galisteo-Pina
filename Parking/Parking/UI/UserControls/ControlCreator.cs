using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.UserControls
{
    public class ControlCreator
    {
        public static UserControl CreateUserControl(int userControlCode, Dictionary<string, int> additionalParameters, Action<int, Dictionary<string, int>> doNavigation, ParkingSystem system)
        {
            switch (userControlCode)
            {
                case NavigationOptions.MAIN_MENU:
                    return new HomeControl(doNavigation, system);
                case NavigationOptions.ADD_ACCOUNT:
                    return new RegisterAccountControl(doNavigation, system);
                case NavigationOptions.ADD_BALANCE:
                    return new AccountBalanceControl(doNavigation, system);
                case NavigationOptions.CHECK_PURCHASE:
                    return new CheckPurchaseControl(doNavigation, system);
                case NavigationOptions.PURCHASE_METHOD:
                    return new PurchaseControl(doNavigation, system);
                default:
                    return new HomeControl(doNavigation, system);
            }
        }
    }
}
