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

        private void AccountRegisterLbl_Click(object sender, EventArgs e)
        {

        }

        private void UserBalanceLbl_Click(object sender, EventArgs e)
        {

        }

        private void AccountBalanceControl_Load(object sender, EventArgs e)
        {

        }
    }
}
