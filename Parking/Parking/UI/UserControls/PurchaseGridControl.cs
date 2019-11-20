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
using Entities;

namespace UI.UserControls
{
    public partial class PurchaseGridControl : UserControl
    {
        private ParkingSystem systemParking;
        private Action<int, Dictionary<string, int>> doNavigation;
        public PurchaseGridControl(Action<int, Dictionary<string, int>> doNavigation, ParkingSystem system)
        {
            InitializeComponent();
            this.doNavigation = doNavigation;
            this.systemParking = system;
            startingDatePicker.Format = DateTimePickerFormat.Custom;
            startingDatePicker.CustomFormat = "MM/dd/yyyy HH:mm";
            endingDatePicker.Format = DateTimePickerFormat.Custom;
            endingDatePicker.CustomFormat = "MM/dd/yyyy HH:mm";
            PopulateComboBox(this.comboBox1, system.CountriesInMemory);
            InitializeDataGrid();
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            Country countryFilter = null;
            DateTime startingDate = startingDatePicker.Value;
            DateTime endingDate = endingDatePicker.Value;
            if (comboBox1.SelectedIndex != 0)
                countryFilter = comboBox1.SelectedItem as Country;
            dataGridView1.DataSource = systemParking.GetMatchingPurchases(startingDate, endingDate, textBox1.Text, countryFilter);
        }

        public void InitializeDataGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Add("AccountCellPhoneNumber", "Celular");
            dataGridView1.Columns.Add("Plates", "Matrícula");
            dataGridView1.Columns.Add("StartingHour", "Inicio");
            dataGridView1.Columns.Add("EndingHour", "Fin");
            dataGridView1.Columns["AccountCellPhoneNumber"].DataPropertyName = "AccountCellPhone";
            dataGridView1.Columns["Plates"].DataPropertyName = "Plates";
            dataGridView1.Columns["StartingHour"].DataPropertyName = "StartingHour";
            dataGridView1.Columns["EndingHour"].DataPropertyName = "EndingHour";

        }

        private void PopulateComboBox<T>(ComboBox comboBox, IEnumerable<T> dataSource)
        {
            comboBox1.Items.Insert(0, new Country("TODOS"));
            comboBox1.Items.Insert(1, new Country("ARGENTINA"));
            comboBox1.Items.Insert(2, new Country("URUGUAY"));
            comboBox.DisplayMember = "Name";
            comboBox.ValueMember = "Name";
            comboBox1.SelectedIndex = 0;
        }
    }
}
