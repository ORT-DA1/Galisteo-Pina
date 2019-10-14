using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic;

namespace UI.UserControls
{
    public partial class PurchaseMethodControl : UserControl
    {
        private Action<int, Dictionary<string, int>> doNavigation;
        ParkingSystem parkingSystem;
        public PurchaseMethodControl(Action<int, Dictionary<string, int>> doNavigation, ParkingSystem system)
        {
            InitializeComponent();
            this.doNavigation = doNavigation;
            this.parkingSystem = system;
        }

        private void ProcessPurchaseBtn_Click(object sender, EventArgs e)
        {
            Notification status;
            string userPhoneNumber = this.userAccountTxtBox.Text;
            string message = this.messagePurchaseTxt.Text;
            status = parkingSystem.AddPurchase(userPhoneNumber, message);
        }
    }
}
