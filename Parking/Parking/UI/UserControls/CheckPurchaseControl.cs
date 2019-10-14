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
        private Action<int, Dictionary<string, int>> doNavigation;
        ParkingSystem parkingSystem;
        public CheckPurchaseControl(Action<int, Dictionary<string, int>> doNavigation, ParkingSystem system)
        {
            InitializeComponent();
            this.doNavigation = doNavigation;
            this.parkingSystem = system;
        }

        private void CheckPurchaseBtn_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD

=======
>>>>>>> ce6a78cd05691a01fb43f166e548493e0d97dbc1
        }
    }
}
