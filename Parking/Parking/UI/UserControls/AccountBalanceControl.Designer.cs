﻿namespace UI.UserControls
{
    partial class AccountBalanceControl
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.addBalanceLbl = new System.Windows.Forms.Label();
            this.userAccountLbl = new System.Windows.Forms.Label();
            this.userAccountTxtBox = new System.Windows.Forms.TextBox();
            this.userBalanceLbl = new System.Windows.Forms.Label();
            this.userBalanceTxtBox = new System.Windows.Forms.TextBox();
            this.addBalanceBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addBalanceLbl
            // 
            this.addBalanceLbl.AutoSize = true;
            this.addBalanceLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBalanceLbl.Location = new System.Drawing.Point(525, 76);
            this.addBalanceLbl.Name = "addBalanceLbl";
            this.addBalanceLbl.Size = new System.Drawing.Size(257, 42);
            this.addBalanceLbl.TabIndex = 1;
            this.addBalanceLbl.Text = "Agregar Saldo";
            this.addBalanceLbl.Click += new System.EventHandler(this.AccountRegisterLbl_Click);
            // 
            // userAccountLbl
            // 
            this.userAccountLbl.AutoSize = true;
            this.userAccountLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userAccountLbl.Location = new System.Drawing.Point(180, 196);
            this.userAccountLbl.Name = "userAccountLbl";
            this.userAccountLbl.Size = new System.Drawing.Size(352, 31);
            this.userAccountLbl.TabIndex = 2;
            this.userAccountLbl.Text = "Ingrese numero de telefono:";
            // 
            // userAccountTxtBox
            // 
            this.userAccountTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userAccountTxtBox.Location = new System.Drawing.Point(538, 193);
            this.userAccountTxtBox.Name = "userAccountTxtBox";
            this.userAccountTxtBox.Size = new System.Drawing.Size(534, 38);
            this.userAccountTxtBox.TabIndex = 3;
            // 
            // userBalanceLbl
            // 
            this.userBalanceLbl.AutoSize = true;
            this.userBalanceLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userBalanceLbl.Location = new System.Drawing.Point(180, 267);
            this.userBalanceLbl.Name = "userBalanceLbl";
            this.userBalanceLbl.Size = new System.Drawing.Size(189, 31);
            this.userBalanceLbl.TabIndex = 4;
            this.userBalanceLbl.Text = "Ingrese Saldo:";
            this.userBalanceLbl.Click += new System.EventHandler(this.UserBalanceLbl_Click);
            // 
            // userBalanceTxtBox
            // 
            this.userBalanceTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userBalanceTxtBox.Location = new System.Drawing.Point(538, 264);
            this.userBalanceTxtBox.Name = "userBalanceTxtBox";
            this.userBalanceTxtBox.Size = new System.Drawing.Size(534, 38);
            this.userBalanceTxtBox.TabIndex = 5;
            // 
            // addBalanceBtn
            // 
            this.addBalanceBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBalanceBtn.Location = new System.Drawing.Point(519, 357);
            this.addBalanceBtn.Name = "addBalanceBtn";
            this.addBalanceBtn.Size = new System.Drawing.Size(263, 61);
            this.addBalanceBtn.TabIndex = 6;
            this.addBalanceBtn.Text = "Agregar Saldo";
            this.addBalanceBtn.UseVisualStyleBackColor = true;
            // 
            // AccountBalanceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.addBalanceBtn);
            this.Controls.Add(this.userBalanceTxtBox);
            this.Controls.Add(this.userBalanceLbl);
            this.Controls.Add(this.userAccountTxtBox);
            this.Controls.Add(this.userAccountLbl);
            this.Controls.Add(this.addBalanceLbl);
            this.Name = "AccountBalanceControl";
            this.Size = new System.Drawing.Size(1300, 960);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label addBalanceLbl;
        private System.Windows.Forms.Label userAccountLbl;
        private System.Windows.Forms.TextBox userAccountTxtBox;
        private System.Windows.Forms.Label userBalanceLbl;
        private System.Windows.Forms.TextBox userBalanceTxtBox;
        private System.Windows.Forms.Button addBalanceBtn;
    }
}
