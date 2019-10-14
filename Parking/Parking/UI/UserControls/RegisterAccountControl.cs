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
        }

        private void AddAccountBtn_Click(object sender, EventArgs e)
        {

        }

        private void RegisterAccountControl_Load(object sender, EventArgs e)
        {

        }
    }
}
