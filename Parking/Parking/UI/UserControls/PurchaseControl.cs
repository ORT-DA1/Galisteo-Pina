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
            string userPhoneNumber = this.userAccountTxtBox.Text;
            string userSms = this.smsTxtBox.Text;
            try
            {
                status = systemParking.AddPurchase(userPhoneNumber, userSms);
                if (status.HasErrors())
                {
                    this.outputErrorLbl.Text = "Error: " + status.ErrorMessage();
                    this.outputErrorLbl.ForeColor = Color.Red;
                }
                if (status.HasSuccess())
                {
                    this.outputErrorLbl.Text = status.SuccessMessage();
                    this.outputErrorLbl.ForeColor = Color.Green;
                }
            }
            catch(InvalidOperationException ex)
            {
                this.outputErrorLbl.Text = "Error: " + ex.Message;
                this.outputErrorLbl.ForeColor = Color.Red;
            }
        }
    }
}
