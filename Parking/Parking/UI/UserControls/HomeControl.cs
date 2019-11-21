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
using BusinessLogic;

namespace UI.UserControls
{
    public partial class HomeControl : UserControl
    {
        private Action<int, Dictionary<string, int>> doNavigation;
        ParkingSystem parkingSystem;
        public HomeControl(Action<int, Dictionary<string, int>> doNavigation, ParkingSystem system)
        {
            InitializeComponent();
            this.doNavigation = doNavigation;
            this.parkingSystem = system;
            this.outPutLbl.Text = "";
        }

        private void ParkingValorBtn_Click(object sender, EventArgs e)
        {
            int stringParsed;
            if (Int32.TryParse(this.parkingValorTxt.Text, out stringParsed) && stringParsed >= 0)
            {
                parkingSystem.AdjustParkingCostPerMinute(stringParsed);
                this.outPutLbl.Text = "Costo de parking modificado con exito.";
                this.outPutLbl.ForeColor = Color.Green;
            }
            else
            {
                this.outPutLbl.Text = "Error: Ingrese un numero entero positivo por favor.";
                this.outPutLbl.ForeColor = Color.Red;
            }
            
        }
    }
}
