﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Entities;
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
            this.outputErrorLbl.Text = status.HasErrors() ? $"Error: {status.Message()}" : status.Message();
            this.outputErrorLbl.ForeColor = status.HasErrors() ? Color.Red : Color.Green;
        }
    }
}
