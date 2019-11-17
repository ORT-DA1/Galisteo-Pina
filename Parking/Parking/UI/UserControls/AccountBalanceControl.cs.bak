using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;

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
            this.outputErrorLbl.Text = "";
        }

        private void AddBalanceBtn_Click(object sender, EventArgs e)
        {
            Notification status;
            string userPhoneNumber = this.userAccountTxtBox.Text;
            userPhoneNumber = parkingSystem.FormatPhoneNumber(userPhoneNumber);
            string balanceToAdd = this.userBalanceTxtBox.Text;
            status = parkingSystem.ValidatePhoneNumber(userPhoneNumber);
            status.AppendNotificationMessages(parkingSystem.ValidateExistingAccountForAccountTransaction(userPhoneNumber));

            if (!status.HasErrors())
            {
                status.AppendNotificationMessages(parkingSystem.AddAmmountToBalance(userPhoneNumber, balanceToAdd));

            }
            this.outputErrorLbl.Text = status.HasErrors()?$"Error: { status.Message()}":status.Message();
            this.outputErrorLbl.ForeColor = status.HasErrors()?Color.Red: Color.Green;
            }
        } 

    
}
