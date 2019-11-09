﻿namespace UI.UserControls
{
    partial class RegisterAccountControl
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
            this.accountRegisterLbl = new System.Windows.Forms.Label();
            this.userAccountLbl = new System.Windows.Forms.Label();
            this.userAccountTxtBox = new System.Windows.Forms.TextBox();
            this.addAccountBtn = new System.Windows.Forms.Button();
            this.outputErrorLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // accountRegisterLbl
            // 
            this.accountRegisterLbl.AutoSize = true;
            this.accountRegisterLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountRegisterLbl.Location = new System.Drawing.Point(240, 42);
            this.accountRegisterLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.accountRegisterLbl.Name = "accountRegisterLbl";
            this.accountRegisterLbl.Size = new System.Drawing.Size(171, 24);
            this.accountRegisterLbl.TabIndex = 0;
            this.accountRegisterLbl.Text = "Registro de Cuenta";
            // 
            // userAccountLbl
            // 
            this.userAccountLbl.AutoSize = true;
            this.userAccountLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userAccountLbl.Location = new System.Drawing.Point(90, 102);
            this.userAccountLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.userAccountLbl.Name = "userAccountLbl";
            this.userAccountLbl.Size = new System.Drawing.Size(186, 17);
            this.userAccountLbl.TabIndex = 1;
            this.userAccountLbl.Text = "Ingrese numero de telefono:";
            // 
            // userAccountTxtBox
            // 
            this.userAccountTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userAccountTxtBox.Location = new System.Drawing.Point(280, 99);
            this.userAccountTxtBox.Margin = new System.Windows.Forms.Padding(2);
            this.userAccountTxtBox.Name = "userAccountTxtBox";
            this.userAccountTxtBox.Size = new System.Drawing.Size(269, 23);
            this.userAccountTxtBox.TabIndex = 2;
            // 
            // addAccountBtn
            // 
            this.addAccountBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addAccountBtn.Location = new System.Drawing.Point(262, 147);
            this.addAccountBtn.Margin = new System.Windows.Forms.Padding(2);
            this.addAccountBtn.Name = "addAccountBtn";
            this.addAccountBtn.Size = new System.Drawing.Size(132, 32);
            this.addAccountBtn.TabIndex = 3;
            this.addAccountBtn.Text = "Registrar Cuenta";
            this.addAccountBtn.UseVisualStyleBackColor = true;
            this.addAccountBtn.Click += new System.EventHandler(this.AddAccountBtn_Click);
            // 
            // outputErrorLbl
            // 
            this.outputErrorLbl.AutoSize = true;
            this.outputErrorLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputErrorLbl.Location = new System.Drawing.Point(93, 194);
            this.outputErrorLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.outputErrorLbl.Name = "outputErrorLbl";
            this.outputErrorLbl.Size = new System.Drawing.Size(91, 17);
            this.outputErrorLbl.TabIndex = 4;
            this.outputErrorLbl.Text = "Output Error:";
            // 
            // RegisterAccountControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.outputErrorLbl);
            this.Controls.Add(this.addAccountBtn);
            this.Controls.Add(this.userAccountTxtBox);
            this.Controls.Add(this.userAccountLbl);
            this.Controls.Add(this.accountRegisterLbl);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "RegisterAccountControl";
            this.Size = new System.Drawing.Size(500, 499);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label accountRegisterLbl;
        private System.Windows.Forms.Label userAccountLbl;
        private System.Windows.Forms.TextBox userAccountTxtBox;
        private System.Windows.Forms.Button addAccountBtn;
        private System.Windows.Forms.Label outputErrorLbl;
    }
}
