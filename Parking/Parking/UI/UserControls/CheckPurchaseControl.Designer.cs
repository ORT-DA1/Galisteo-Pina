namespace UI.UserControls
{
    partial class CheckPurchaseControl
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
            this.smsLbl = new System.Windows.Forms.Label();
            this.userPlateTxtBox = new System.Windows.Forms.TextBox();
            this.checkPurchaseBtn = new System.Windows.Forms.Button();
            this.outputErrorLbl = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // accountRegisterLbl
            // 
            this.accountRegisterLbl.AutoSize = true;
            this.accountRegisterLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountRegisterLbl.Location = new System.Drawing.Point(480, 81);
            this.accountRegisterLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.accountRegisterLbl.Name = "accountRegisterLbl";
            this.accountRegisterLbl.Size = new System.Drawing.Size(320, 42);
            this.accountRegisterLbl.TabIndex = 4;
            this.accountRegisterLbl.Text = "Consultar Compra";
            // 
            // userAccountLbl
            // 
            this.userAccountLbl.AutoSize = true;
            this.userAccountLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userAccountLbl.Location = new System.Drawing.Point(180, 196);
            this.userAccountLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.userAccountLbl.Name = "userAccountLbl";
            this.userAccountLbl.Size = new System.Drawing.Size(230, 31);
            this.userAccountLbl.TabIndex = 5;
            this.userAccountLbl.Text = "Ingrese matricula:";
            // 
            // smsLbl
            // 
            this.smsLbl.AutoSize = true;
            this.smsLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smsLbl.Location = new System.Drawing.Point(180, 277);
            this.smsLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.smsLbl.Name = "smsLbl";
            this.smsLbl.Size = new System.Drawing.Size(269, 31);
            this.smsLbl.TabIndex = 8;
            this.smsLbl.Text = "Ingrese fecha y hora:";
            // 
            // userPlateTxtBox
            // 
            this.userPlateTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userPlateTxtBox.Location = new System.Drawing.Point(560, 190);
            this.userPlateTxtBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.userPlateTxtBox.Name = "userPlateTxtBox";
            this.userPlateTxtBox.Size = new System.Drawing.Size(534, 38);
            this.userPlateTxtBox.TabIndex = 9;
            // 
            // checkPurchaseBtn
            // 
            this.checkPurchaseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkPurchaseBtn.Location = new System.Drawing.Point(506, 367);
            this.checkPurchaseBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkPurchaseBtn.Name = "checkPurchaseBtn";
            this.checkPurchaseBtn.Size = new System.Drawing.Size(264, 62);
            this.checkPurchaseBtn.TabIndex = 11;
            this.checkPurchaseBtn.Text = "Consultar Compra";
            this.checkPurchaseBtn.UseVisualStyleBackColor = true;
            this.checkPurchaseBtn.Click += new System.EventHandler(this.CheckPurchaseBtn_Click);
            // 
            // outputErrorLbl
            // 
            this.outputErrorLbl.AutoSize = true;
            this.outputErrorLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputErrorLbl.Location = new System.Drawing.Point(180, 463);
            this.outputErrorLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.outputErrorLbl.Name = "outputErrorLbl";
            this.outputErrorLbl.Size = new System.Drawing.Size(171, 31);
            this.outputErrorLbl.TabIndex = 12;
            this.outputErrorLbl.Text = "Output Error:";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker.Location = new System.Drawing.Point(560, 277);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(534, 31);
            this.dateTimePicker.TabIndex = 13;
            // 
            // CheckPurchaseControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.outputErrorLbl);
            this.Controls.Add(this.checkPurchaseBtn);
            this.Controls.Add(this.userPlateTxtBox);
            this.Controls.Add(this.smsLbl);
            this.Controls.Add(this.userAccountLbl);
            this.Controls.Add(this.accountRegisterLbl);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "CheckPurchaseControl";
            this.Size = new System.Drawing.Size(1300, 960);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label accountRegisterLbl;
        private System.Windows.Forms.Label userAccountLbl;
        private System.Windows.Forms.Label smsLbl;
        private System.Windows.Forms.TextBox userPlateTxtBox;
        private System.Windows.Forms.Button checkPurchaseBtn;
        private System.Windows.Forms.Label outputErrorLbl;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
    }
}
