﻿using BusinessLogic;
using Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.UserControls;

namespace UI
{
    public partial class Parking : Form
    {
        ParkingSystem parkingSystem;
        public Parking()
        {
            InitializeComponent();
            parkingSystem = new ParkingSystem(ParkingSystemInitializer.GetUnitOfWorkToInject(Enviroment.DEVELOP));
            PopulateComboBox(this.comboBox1, parkingSystem.CountriesInMemory);
            DoNavigation(NavigationOptions.MAIN_MENU);

        }
        public void DoNavigation(int userControlCode, Dictionary<string,int> additionalParameters = null)
        {
            this.controlPanel.Controls.Clear();
            UserControl currenUserControl = ControlCreator.CreateUserControl(userControlCode, additionalParameters, this.DoNavigation, parkingSystem);
            this.controlPanel.Controls.Add(currenUserControl);
        }
        private void HomeBtn_Click(object sender, EventArgs e)
        {
            DoNavigation(NavigationOptions.MAIN_MENU);
        }

        private void AddUserBtn_Click(object sender, EventArgs e)
        {
            DoNavigation(NavigationOptions.ADD_ACCOUNT);
        }

        private void AddBalanceBtn_Click(object sender, EventArgs e)
        {
            DoNavigation(NavigationOptions.ADD_BALANCE);
        }

        private void PurchaseMethodBtn_Click(object sender, EventArgs e)
        {
            DoNavigation(NavigationOptions.PURCHASE_METHOD);
        }

        private void CheckPurchase_Click(object sender, EventArgs e)
        {
            DoNavigation(NavigationOptions.CHECK_PURCHASE);
        }
        private void PopulateComboBox<T>(ComboBox comboBox, IEnumerable<T> dataSource) 
        {
            comboBox.DisplayMember = "Name";
            comboBox.ValueMember = "Name";
            comboBox.DataSource = dataSource as List<Country>;

        }

        private void ComboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            parkingSystem.CurrentCountry = comboBox1.SelectedItem as Country;
        }

        private void PurchaseGrid_Click(object sender, EventArgs e)
        {
            DoNavigation(NavigationOptions.PURCHASE_GRID);
        }
    }
}
