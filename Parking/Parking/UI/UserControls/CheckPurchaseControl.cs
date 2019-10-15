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
    public partial class CheckPurchaseControl : UserControl
    {
        private ParkingSystem systemParking;
        private Action<int, Dictionary<string, int>> doNavigation;
        public CheckPurchaseControl(Action<int, Dictionary<string, int>> doNavigation, ParkingSystem system)
        {
            InitializeComponent();
            this.doNavigation = doNavigation;
            this.systemParking = system;
            this.outputErrorLbl.Text = "";
        }

        private void CheckPurchaseBtn_Click(object sender, EventArgs e)
        {
            Notification status;
            string userPlate = this.userPlateTxtBox.Text;
            string hourToCheck = this.dateTimePicker.Value.ToString();
            status = systemParking.AnyPurchaseMatchesPlateAndHour(userPlate, hourToCheck);
            if (status.HasErrors())
            {
                this.outputErrorLbl.Text = "Error: " + status.ErrorMessage();
                this.outputErrorLbl.ForeColor = Color.Red;
            }
            else if (status.HasSuccess())
            {
                this.outputErrorLbl.Text = status.SuccessMessage();
                this.outputErrorLbl.ForeColor = Color.Green;
            }
        }
    }
}
