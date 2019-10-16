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
    public partial class RegisterAccountControl : UserControl
    {
        private Action<int, Dictionary<string, int>> doNavigation;
        private ParkingSystem systemParking;
        public RegisterAccountControl(Action<int, Dictionary<string, int>> doNavigation, ParkingSystem system)
        {
            InitializeComponent();
            this.doNavigation = doNavigation;
            this.systemParking = system;
            this.outputErrorLbl.Text = "";
        }

        private void AddAccountBtn_Click(object sender, EventArgs e)
        {
            Notification status;
            string cellPhoneNumber = this.userAccountTxtBox.Text;
            cellPhoneNumber = systemParking.FormatPhoneNumber(cellPhoneNumber);
            status = systemParking.ValidateExistingAccountForAddingAccount(cellPhoneNumber);
            if (!status.HasErrors())
            {
                status.AppendNotificationMessages(systemParking.AddAccount(cellPhoneNumber));
            }

            this.outputErrorLbl.Text = status.HasErrors() ? $"Error: {status.Message()}" : status.Message();
            this.outputErrorLbl.ForeColor = status.HasErrors() ? Color.Red : Color.Green;
        }
    }
}
