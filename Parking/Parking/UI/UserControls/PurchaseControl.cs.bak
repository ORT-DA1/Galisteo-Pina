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
    public partial class PurchaseControl : UserControl
    {
        private ParkingSystem systemParking;
        private Action<int, Dictionary<string, int>> doNavigation;
        public PurchaseControl(Action<int, Dictionary<string, int>> doNavigation, ParkingSystem system)
        {
            InitializeComponent();
            this.doNavigation = doNavigation;
            this.systemParking = system;
            this.outputErrorLbl.Text = "";
        }

        private void PurchaseMethodBtn_Click(object sender, EventArgs e)
        {
            Notification status;
            Sms purchaseSms;
            string userPhoneNumber = this.userAccountTxtBox.Text;
            string userSms = this.smsTxtBox.Text;
            try

            {
                userPhoneNumber = systemParking.FormatPhoneNumber(userPhoneNumber);
                purchaseSms = systemParking.FormatSmsForPurchase(userSms);
                status = systemParking.ValidateSms(purchaseSms);
                status.AppendNotificationMessages(systemParking.ValidateExistingAccountForAccountTransaction(userPhoneNumber));

                if (!status.HasErrors())
                {
                    Account purchaseAccount = systemParking.GetAccountByPhoneNumber(userPhoneNumber);
                    status = systemParking.AddPurchase(new Purchase(purchaseSms, purchaseAccount));
                }
                this.outputErrorLbl.Text = status.HasErrors()?$"Error: {status.Message()}":status.Message();
                this.outputErrorLbl.ForeColor = status.HasErrors()? Color.Red:Color.Green;

            }
            catch(InvalidOperationException ex)
            {
                this.outputErrorLbl.Text = "Error: " + ex.Message;
                this.outputErrorLbl.ForeColor = Color.Red;
            }
        }
    }
}
