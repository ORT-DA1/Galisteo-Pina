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
    public partial class AccountBalanceControl : UserControl
    {
        private Action<int, Dictionary<string, int>> doNavigation;
        ParkingSystem parkingSystem;
        public AccountBalanceControl(Action<int, Dictionary<string, int>> doNavigation, ParkingSystem system)
        {
            InitializeComponent();
            this.doNavigation = doNavigation;
            this.parkingSystem = system;
        }

        private void AddBalanceBtn_Click(object sender, EventArgs e)
        {
            Notification status = new Notification();
            string userPhoneNumber = this.userAccountTxtBox.Text;
            string balanceToAdd = this.userBalanceTxtBox.Text;
            status = parkingSystem.AddAmmountToBalance(userPhoneNumber, balanceToAdd);
            if (status.HasErrors())
            {
                this.outputErrorLbl.Text = "Error: " + status.ErrorMessage();
                this.outputErrorLbl.ForeColor = Color.Red;
            }
            else if (status.HasSuccess())
            {
                this.outputErrorLbl.Text = "Saldo agregado a la cuenta: " + userPhoneNumber;
                this.outputErrorLbl.ForeColor = Color.Green;
            }
        }
    }
}
