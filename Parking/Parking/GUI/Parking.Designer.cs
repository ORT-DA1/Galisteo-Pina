namespace GUI
{
    partial class Parking
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.CheckPurchaseBtn = new System.Windows.Forms.Button();
            this.PurchaseMethodBtn = new System.Windows.Forms.Button();
            this.AddBalanceBtn = new System.Windows.Forms.Button();
            this.AddUserBtn = new System.Windows.Forms.Button();
            this.AddAccountPanel = new System.Windows.Forms.Panel();
            this.AddBalancePanel = new System.Windows.Forms.Panel();
            this.PurchaseMethodPanel = new System.Windows.Forms.Panel();
            this.OutputErrorLbl = new System.Windows.Forms.Label();
            this.InputSmsBtn = new System.Windows.Forms.TextBox();
            this.InputSmsLbl = new System.Windows.Forms.Label();
            this.AddSmsMethodBtn = new System.Windows.Forms.Button();
            this.InputAccountPurchaseLbl = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.InputBalanceTxtBox = new System.Windows.Forms.TextBox();
            this.InputBalanceLbl = new System.Windows.Forms.Label();
            this.InputBalanceBtn = new System.Windows.Forms.Button();
            this.InputAccountLbl = new System.Windows.Forms.Label();
            this.InputAccountTxtBox = new System.Windows.Forms.TextBox();
            this.AddBalanceLbl = new System.Windows.Forms.Label();
            this.AddUserProcessBtn = new System.Windows.Forms.Button();
            this.AccountNumberPhoneLbl = new System.Windows.Forms.Label();
            this.AccountNumberTxtBox = new System.Windows.Forms.TextBox();
            this.RegistrarCuentaLabel = new System.Windows.Forms.Label();
            this.CheckPurchasePanel = new System.Windows.Forms.Panel();
            this.checkResultLbl = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.DataTimeLbl = new System.Windows.Forms.Label();
            this.checkBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.MenuPanel.SuspendLayout();
            this.AddAccountPanel.SuspendLayout();
            this.AddBalancePanel.SuspendLayout();
            this.PurchaseMethodPanel.SuspendLayout();
            this.CheckPurchasePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuPanel
            // 
            this.MenuPanel.Controls.Add(this.CheckPurchaseBtn);
            this.MenuPanel.Controls.Add(this.PurchaseMethodBtn);
            this.MenuPanel.Controls.Add(this.AddBalanceBtn);
            this.MenuPanel.Controls.Add(this.AddUserBtn);
            this.MenuPanel.Location = new System.Drawing.Point(12, 12);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(526, 520);
            this.MenuPanel.TabIndex = 0;
            // 
            // CheckPurchaseBtn
            // 
            this.CheckPurchaseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckPurchaseBtn.Location = new System.Drawing.Point(0, 345);
            this.CheckPurchaseBtn.Name = "CheckPurchaseBtn";
            this.CheckPurchaseBtn.Size = new System.Drawing.Size(526, 109);
            this.CheckPurchaseBtn.TabIndex = 3;
            this.CheckPurchaseBtn.Text = "Consultar Compra";
            this.CheckPurchaseBtn.UseCompatibleTextRendering = true;
            this.CheckPurchaseBtn.UseVisualStyleBackColor = true;
            this.CheckPurchaseBtn.Click += new System.EventHandler(this.CheckPurchaseBtn_Click);
            // 
            // PurchaseMethodBtn
            // 
            this.PurchaseMethodBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PurchaseMethodBtn.Location = new System.Drawing.Point(0, 230);
            this.PurchaseMethodBtn.Name = "PurchaseMethodBtn";
            this.PurchaseMethodBtn.Size = new System.Drawing.Size(526, 109);
            this.PurchaseMethodBtn.TabIndex = 2;
            this.PurchaseMethodBtn.Text = "Procesar Compra";
            this.PurchaseMethodBtn.UseCompatibleTextRendering = true;
            this.PurchaseMethodBtn.UseVisualStyleBackColor = true;
            this.PurchaseMethodBtn.Click += new System.EventHandler(this.PurchaseMethodBtn_Click);
            // 
            // AddBalanceBtn
            // 
            this.AddBalanceBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddBalanceBtn.Location = new System.Drawing.Point(0, 115);
            this.AddBalanceBtn.Name = "AddBalanceBtn";
            this.AddBalanceBtn.Size = new System.Drawing.Size(526, 109);
            this.AddBalanceBtn.TabIndex = 1;
            this.AddBalanceBtn.Text = "Agregar Saldo";
            this.AddBalanceBtn.UseCompatibleTextRendering = true;
            this.AddBalanceBtn.UseVisualStyleBackColor = true;
            this.AddBalanceBtn.Click += new System.EventHandler(this.AddBalanceBtn_Click);
            // 
            // AddUserBtn
            // 
            this.AddUserBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddUserBtn.Location = new System.Drawing.Point(0, 0);
            this.AddUserBtn.Name = "AddUserBtn";
            this.AddUserBtn.Size = new System.Drawing.Size(526, 109);
            this.AddUserBtn.TabIndex = 0;
            this.AddUserBtn.Text = "Registrar Cuenta";
            this.AddUserBtn.UseCompatibleTextRendering = true;
            this.AddUserBtn.UseVisualStyleBackColor = true;
            this.AddUserBtn.Click += new System.EventHandler(this.AddUserBtn_Click);
            // 
            // AddAccountPanel
            // 
            this.AddAccountPanel.Controls.Add(this.AddBalancePanel);
            this.AddAccountPanel.Controls.Add(this.AddUserProcessBtn);
            this.AddAccountPanel.Controls.Add(this.AccountNumberPhoneLbl);
            this.AddAccountPanel.Controls.Add(this.AccountNumberTxtBox);
            this.AddAccountPanel.Controls.Add(this.RegistrarCuentaLabel);
            this.AddAccountPanel.Location = new System.Drawing.Point(544, 12);
            this.AddAccountPanel.Name = "AddAccountPanel";
            this.AddAccountPanel.Size = new System.Drawing.Size(1157, 521);
            this.AddAccountPanel.TabIndex = 1;
            // 
            // AddBalancePanel
            // 
            this.AddBalancePanel.Controls.Add(this.PurchaseMethodPanel);
            this.AddBalancePanel.Controls.Add(this.InputBalanceTxtBox);
            this.AddBalancePanel.Controls.Add(this.InputBalanceLbl);
            this.AddBalancePanel.Controls.Add(this.InputBalanceBtn);
            this.AddBalancePanel.Controls.Add(this.InputAccountLbl);
            this.AddBalancePanel.Controls.Add(this.InputAccountTxtBox);
            this.AddBalancePanel.Controls.Add(this.AddBalanceLbl);
            this.AddBalancePanel.Location = new System.Drawing.Point(871, 412);
            this.AddBalancePanel.Name = "AddBalancePanel";
            this.AddBalancePanel.Size = new System.Drawing.Size(1157, 526);
            this.AddBalancePanel.TabIndex = 4;
            // 
            // PurchaseMethodPanel
            // 
            this.PurchaseMethodPanel.Controls.Add(this.CheckPurchasePanel);
            this.PurchaseMethodPanel.Controls.Add(this.OutputErrorLbl);
            this.PurchaseMethodPanel.Controls.Add(this.InputSmsBtn);
            this.PurchaseMethodPanel.Controls.Add(this.InputSmsLbl);
            this.PurchaseMethodPanel.Controls.Add(this.AddSmsMethodBtn);
            this.PurchaseMethodPanel.Controls.Add(this.InputAccountPurchaseLbl);
            this.PurchaseMethodPanel.Controls.Add(this.textBox2);
            this.PurchaseMethodPanel.Controls.Add(this.label3);
            this.PurchaseMethodPanel.ForeColor = System.Drawing.Color.Black;
            this.PurchaseMethodPanel.Location = new System.Drawing.Point(887, 386);
            this.PurchaseMethodPanel.Name = "PurchaseMethodPanel";
            this.PurchaseMethodPanel.Size = new System.Drawing.Size(1157, 524);
            this.PurchaseMethodPanel.TabIndex = 6;
            // 
            // OutputErrorLbl
            // 
            this.OutputErrorLbl.AutoSize = true;
            this.OutputErrorLbl.ForeColor = System.Drawing.Color.Red;
            this.OutputErrorLbl.Location = new System.Drawing.Point(282, 429);
            this.OutputErrorLbl.Name = "OutputErrorLbl";
            this.OutputErrorLbl.Size = new System.Drawing.Size(140, 25);
            this.OutputErrorLbl.TabIndex = 6;
            this.OutputErrorLbl.Text = "Output Errors";
            // 
            // InputSmsBtn
            // 
            this.InputSmsBtn.Location = new System.Drawing.Point(530, 221);
            this.InputSmsBtn.Name = "InputSmsBtn";
            this.InputSmsBtn.Size = new System.Drawing.Size(352, 31);
            this.InputSmsBtn.TabIndex = 5;
            // 
            // InputSmsLbl
            // 
            this.InputSmsLbl.AutoSize = true;
            this.InputSmsLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputSmsLbl.Location = new System.Drawing.Point(281, 218);
            this.InputSmsLbl.Name = "InputSmsLbl";
            this.InputSmsLbl.Size = new System.Drawing.Size(178, 31);
            this.InputSmsLbl.TabIndex = 4;
            this.InputSmsLbl.Text = "Ingrese SMS:";
            // 
            // AddSmsMethodBtn
            // 
            this.AddSmsMethodBtn.Location = new System.Drawing.Point(496, 309);
            this.AddSmsMethodBtn.Name = "AddSmsMethodBtn";
            this.AddSmsMethodBtn.Size = new System.Drawing.Size(180, 60);
            this.AddSmsMethodBtn.TabIndex = 3;
            this.AddSmsMethodBtn.Text = "Procesar SMS";
            this.AddSmsMethodBtn.UseVisualStyleBackColor = true;
            // 
            // InputAccountPurchaseLbl
            // 
            this.InputAccountPurchaseLbl.AutoSize = true;
            this.InputAccountPurchaseLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputAccountPurchaseLbl.Location = new System.Drawing.Point(281, 154);
            this.InputAccountPurchaseLbl.Name = "InputAccountPurchaseLbl";
            this.InputAccountPurchaseLbl.Size = new System.Drawing.Size(206, 31);
            this.InputAccountPurchaseLbl.TabIndex = 2;
            this.InputAccountPurchaseLbl.Text = "Ingrese Celular:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(530, 154);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(352, 31);
            this.textBox2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(457, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(310, 42);
            this.label3.TabIndex = 0;
            this.label3.Text = "Procesar Compra";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InputBalanceTxtBox
            // 
            this.InputBalanceTxtBox.Location = new System.Drawing.Point(530, 221);
            this.InputBalanceTxtBox.Name = "InputBalanceTxtBox";
            this.InputBalanceTxtBox.Size = new System.Drawing.Size(352, 31);
            this.InputBalanceTxtBox.TabIndex = 5;
            // 
            // InputBalanceLbl
            // 
            this.InputBalanceLbl.AutoSize = true;
            this.InputBalanceLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputBalanceLbl.Location = new System.Drawing.Point(281, 218);
            this.InputBalanceLbl.Name = "InputBalanceLbl";
            this.InputBalanceLbl.Size = new System.Drawing.Size(195, 31);
            this.InputBalanceLbl.TabIndex = 4;
            this.InputBalanceLbl.Text = "Ingrese Monto:";
            // 
            // InputBalanceBtn
            // 
            this.InputBalanceBtn.Location = new System.Drawing.Point(496, 309);
            this.InputBalanceBtn.Name = "InputBalanceBtn";
            this.InputBalanceBtn.Size = new System.Drawing.Size(180, 60);
            this.InputBalanceBtn.TabIndex = 3;
            this.InputBalanceBtn.Text = "Ingresar Saldo";
            this.InputBalanceBtn.UseVisualStyleBackColor = true;
            // 
            // InputAccountLbl
            // 
            this.InputAccountLbl.AutoSize = true;
            this.InputAccountLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputAccountLbl.Location = new System.Drawing.Point(281, 154);
            this.InputAccountLbl.Name = "InputAccountLbl";
            this.InputAccountLbl.Size = new System.Drawing.Size(206, 31);
            this.InputAccountLbl.TabIndex = 2;
            this.InputAccountLbl.Text = "Ingrese Celular:";
            // 
            // InputAccountTxtBox
            // 
            this.InputAccountTxtBox.Location = new System.Drawing.Point(530, 154);
            this.InputAccountTxtBox.Name = "InputAccountTxtBox";
            this.InputAccountTxtBox.Size = new System.Drawing.Size(352, 31);
            this.InputAccountTxtBox.TabIndex = 1;
            // 
            // AddBalanceLbl
            // 
            this.AddBalanceLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddBalanceLbl.AutoSize = true;
            this.AddBalanceLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddBalanceLbl.Location = new System.Drawing.Point(457, 27);
            this.AddBalanceLbl.Name = "AddBalanceLbl";
            this.AddBalanceLbl.Size = new System.Drawing.Size(257, 42);
            this.AddBalanceLbl.TabIndex = 0;
            this.AddBalanceLbl.Text = "Agregar Saldo";
            this.AddBalanceLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AddUserProcessBtn
            // 
            this.AddUserProcessBtn.Location = new System.Drawing.Point(508, 257);
            this.AddUserProcessBtn.Name = "AddUserProcessBtn";
            this.AddUserProcessBtn.Size = new System.Drawing.Size(180, 60);
            this.AddUserProcessBtn.TabIndex = 3;
            this.AddUserProcessBtn.Text = "Ingresar Cuenta";
            this.AddUserProcessBtn.UseVisualStyleBackColor = true;
            this.AddUserProcessBtn.Click += new System.EventHandler(this.AddUserProcessBtn_Click);
            // 
            // AccountNumberPhoneLbl
            // 
            this.AccountNumberPhoneLbl.AutoSize = true;
            this.AccountNumberPhoneLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountNumberPhoneLbl.Location = new System.Drawing.Point(281, 154);
            this.AccountNumberPhoneLbl.Name = "AccountNumberPhoneLbl";
            this.AccountNumberPhoneLbl.Size = new System.Drawing.Size(206, 31);
            this.AccountNumberPhoneLbl.TabIndex = 2;
            this.AccountNumberPhoneLbl.Text = "Ingrese Celular:";
            this.AccountNumberPhoneLbl.Click += new System.EventHandler(this.Label1_Click);
            // 
            // AccountNumberTxtBox
            // 
            this.AccountNumberTxtBox.Location = new System.Drawing.Point(530, 154);
            this.AccountNumberTxtBox.Name = "AccountNumberTxtBox";
            this.AccountNumberTxtBox.Size = new System.Drawing.Size(352, 31);
            this.AccountNumberTxtBox.TabIndex = 1;
            // 
            // RegistrarCuentaLabel
            // 
            this.RegistrarCuentaLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RegistrarCuentaLabel.AutoSize = true;
            this.RegistrarCuentaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegistrarCuentaLabel.Location = new System.Drawing.Point(405, 27);
            this.RegistrarCuentaLabel.Name = "RegistrarCuentaLabel";
            this.RegistrarCuentaLabel.Size = new System.Drawing.Size(359, 42);
            this.RegistrarCuentaLabel.TabIndex = 0;
            this.RegistrarCuentaLabel.Text = "Registro de Cuentas\r\n";
            this.RegistrarCuentaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CheckPurchasePanel
            // 
            this.CheckPurchasePanel.Controls.Add(this.checkResultLbl);
            this.CheckPurchasePanel.Controls.Add(this.textBox1);
            this.CheckPurchasePanel.Controls.Add(this.DataTimeLbl);
            this.CheckPurchasePanel.Controls.Add(this.checkBtn);
            this.CheckPurchasePanel.Controls.Add(this.label4);
            this.CheckPurchasePanel.Controls.Add(this.textBox3);
            this.CheckPurchasePanel.Controls.Add(this.label5);
            this.CheckPurchasePanel.ForeColor = System.Drawing.Color.Black;
            this.CheckPurchasePanel.Location = new System.Drawing.Point(1059, 420);
            this.CheckPurchasePanel.Name = "CheckPurchasePanel";
            this.CheckPurchasePanel.Size = new System.Drawing.Size(1157, 520);
            this.CheckPurchasePanel.TabIndex = 7;
            // 
            // checkResultLbl
            // 
            this.checkResultLbl.AutoSize = true;
            this.checkResultLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkResultLbl.ForeColor = System.Drawing.Color.Black;
            this.checkResultLbl.Location = new System.Drawing.Point(282, 429);
            this.checkResultLbl.Name = "checkResultLbl";
            this.checkResultLbl.Size = new System.Drawing.Size(100, 31);
            this.checkResultLbl.TabIndex = 6;
            this.checkResultLbl.Text = "Result:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(596, 221);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(352, 31);
            this.textBox1.TabIndex = 5;
            // 
            // DataTimeLbl
            // 
            this.DataTimeLbl.AutoSize = true;
            this.DataTimeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataTimeLbl.Location = new System.Drawing.Point(256, 218);
            this.DataTimeLbl.Name = "DataTimeLbl";
            this.DataTimeLbl.Size = new System.Drawing.Size(304, 31);
            this.DataTimeLbl.TabIndex = 4;
            this.DataTimeLbl.Text = "Ingrese Fecha y Hoario:";
            // 
            // checkBtn
            // 
            this.checkBtn.Location = new System.Drawing.Point(496, 309);
            this.checkBtn.Name = "checkBtn";
            this.checkBtn.Size = new System.Drawing.Size(180, 60);
            this.checkBtn.TabIndex = 3;
            this.checkBtn.Text = "Procesar SMS";
            this.checkBtn.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(256, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(206, 31);
            this.label4.TabIndex = 2;
            this.label4.Text = "Ingrese Celular:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(596, 154);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(352, 31);
            this.textBox3.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(444, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(320, 42);
            this.label5.TabIndex = 0;
            this.label5.Text = "Consultar Compra";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Parking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1710, 544);
            this.Controls.Add(this.AddAccountPanel);
            this.Controls.Add(this.MenuPanel);
            this.Name = "Parking";
            this.Text = "Parking";
            this.MenuPanel.ResumeLayout(false);
            this.AddAccountPanel.ResumeLayout(false);
            this.AddAccountPanel.PerformLayout();
            this.AddBalancePanel.ResumeLayout(false);
            this.AddBalancePanel.PerformLayout();
            this.PurchaseMethodPanel.ResumeLayout(false);
            this.PurchaseMethodPanel.PerformLayout();
            this.CheckPurchasePanel.ResumeLayout(false);
            this.CheckPurchasePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MenuPanel;
        private System.Windows.Forms.Button CheckPurchaseBtn;
        private System.Windows.Forms.Button PurchaseMethodBtn;
        private System.Windows.Forms.Button AddBalanceBtn;
        private System.Windows.Forms.Button AddUserBtn;
        private System.Windows.Forms.Panel AddAccountPanel;
        private System.Windows.Forms.Label AccountNumberPhoneLbl;
        private System.Windows.Forms.TextBox AccountNumberTxtBox;
        private System.Windows.Forms.Label RegistrarCuentaLabel;
        private System.Windows.Forms.Panel AddBalancePanel;
        private System.Windows.Forms.Button InputBalanceBtn;
        private System.Windows.Forms.Label InputAccountLbl;
        private System.Windows.Forms.TextBox InputAccountTxtBox;
        private System.Windows.Forms.Label AddBalanceLbl;
        private System.Windows.Forms.Button AddUserProcessBtn;
        private System.Windows.Forms.TextBox InputBalanceTxtBox;
        private System.Windows.Forms.Label InputBalanceLbl;
        private System.Windows.Forms.Panel PurchaseMethodPanel;
        private System.Windows.Forms.Panel CheckPurchasePanel;
        private System.Windows.Forms.Label checkResultLbl;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label DataTimeLbl;
        private System.Windows.Forms.Button checkBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label OutputErrorLbl;
        private System.Windows.Forms.TextBox InputSmsBtn;
        private System.Windows.Forms.Label InputSmsLbl;
        private System.Windows.Forms.Button AddSmsMethodBtn;
        private System.Windows.Forms.Label InputAccountPurchaseLbl;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
    }
}

