using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic;

namespace GUI
{
    public partial class Parking : Form
    {
        SystemParking parking;

        public Parking()
        {
            InitializeComponent();
            parking = new SystemParking();
            AddAccountPanel.Visible = false;
            AddBalancePanel.Visible = false;
            CheckPurchasePanel.Visible = false;
            PurchaseMethodPanel.Visible = false;
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void AddUserBtn_Click(object sender, EventArgs e)
        {
            AddAccountPanel.Visible = true;
            AddBalancePanel.Visible = false;
            CheckPurchasePanel.Visible = false;
            PurchaseMethodPanel.Visible = false;
        }

        private void AddBalanceBtn_Click(object sender, EventArgs e)
        {
            AddAccountPanel.Visible = true;
            AddBalancePanel.Visible = true;
            CheckPurchasePanel.Visible = false;
            PurchaseMethodPanel.Visible = false;
        }

        private void PurchaseMethodBtn_Click(object sender, EventArgs e)
        {
            AddAccountPanel.Visible = true;
            AddBalancePanel.Visible = true;
            CheckPurchasePanel.Visible = false;
            PurchaseMethodPanel.Visible = true;
        }

        private void CheckPurchaseBtn_Click(object sender, EventArgs e)
        {
            AddAccountPanel.Visible = true;
            AddBalancePanel.Visible = true;
            CheckPurchasePanel.Visible = true;
            PurchaseMethodPanel.Visible = false;
        }

        private void AddUserProcessBtn_Click(object sender, EventArgs e)
        {
            CellPhoneValidator mobileValidator = new CellPhoneValidator();
            string phoneNumber = this.AccountNumberTxtBox.Text;
            int balance = 0;
            if (mobileValidator.PhoneNumberCorrectFormat(phoneNumber))
            {
                Account userAccount = new Account(phoneNumber, balance);
                parking.addAccount(userAccount);
                MessageBox.Show("Cuenta ingresada correctamente", "Parking", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Error en el formato del telefono, ingrese un numero valido", "Telefono no valido", MessageBoxButtons.OK);
            }
        }
    }
}
