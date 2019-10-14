using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.UserControls
{
    public partial class HomeControl : UserControl
    {
        private Action<int, Dictionary<string, int>> doNavigation;
        public HomeControl(Action<int, Dictionary<string, int>> doNavigation)
        {
            InitializeComponent();
            this.doNavigation = doNavigation;
        }

        private void HomeControl_Load(object sender, EventArgs e)
        {

        }
    }
}
