namespace UI
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
            this.menuPanel = new System.Windows.Forms.Panel();
            this.checkPurchase = new System.Windows.Forms.Button();
            this.purchaseMethodBtn = new System.Windows.Forms.Button();
            this.addBalanceBtn = new System.Windows.Forms.Button();
            this.addUserBtn = new System.Windows.Forms.Button();
            this.homeBtn = new System.Windows.Forms.Button();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.menuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuPanel
            // 
            this.menuPanel.Controls.Add(this.comboBox1);
            this.menuPanel.Controls.Add(this.label1);
            this.menuPanel.Controls.Add(this.checkPurchase);
            this.menuPanel.Controls.Add(this.purchaseMethodBtn);
            this.menuPanel.Controls.Add(this.addBalanceBtn);
            this.menuPanel.Controls.Add(this.addUserBtn);
            this.menuPanel.Controls.Add(this.homeBtn);
            this.menuPanel.Location = new System.Drawing.Point(6, 6);
            this.menuPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(224, 613);
            this.menuPanel.TabIndex = 0;
            // 
            // checkPurchase
            // 
            this.checkPurchase.Location = new System.Drawing.Point(2, 287);
            this.checkPurchase.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkPurchase.Name = "checkPurchase";
            this.checkPurchase.Size = new System.Drawing.Size(222, 68);
            this.checkPurchase.TabIndex = 4;
            this.checkPurchase.Text = "CONSULTAR COMPRA";
            this.checkPurchase.UseVisualStyleBackColor = true;
            this.checkPurchase.Click += new System.EventHandler(this.CheckPurchase_Click);
            // 
            // purchaseMethodBtn
            // 
            this.purchaseMethodBtn.Location = new System.Drawing.Point(2, 215);
            this.purchaseMethodBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.purchaseMethodBtn.Name = "purchaseMethodBtn";
            this.purchaseMethodBtn.Size = new System.Drawing.Size(222, 68);
            this.purchaseMethodBtn.TabIndex = 3;
            this.purchaseMethodBtn.Text = "PROCESAR COMPRA";
            this.purchaseMethodBtn.UseVisualStyleBackColor = true;
            this.purchaseMethodBtn.Click += new System.EventHandler(this.PurchaseMethodBtn_Click);
            // 
            // addBalanceBtn
            // 
            this.addBalanceBtn.Location = new System.Drawing.Point(2, 144);
            this.addBalanceBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addBalanceBtn.Name = "addBalanceBtn";
            this.addBalanceBtn.Size = new System.Drawing.Size(222, 68);
            this.addBalanceBtn.TabIndex = 2;
            this.addBalanceBtn.Text = "AGREGAR SALDO";
            this.addBalanceBtn.UseVisualStyleBackColor = true;
            this.addBalanceBtn.Click += new System.EventHandler(this.AddBalanceBtn_Click);
            // 
            // addUserBtn
            // 
            this.addUserBtn.Location = new System.Drawing.Point(2, 73);
            this.addUserBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addUserBtn.Name = "addUserBtn";
            this.addUserBtn.Size = new System.Drawing.Size(222, 68);
            this.addUserBtn.TabIndex = 1;
            this.addUserBtn.Text = "REGISTRO USUARIO";
            this.addUserBtn.UseVisualStyleBackColor = true;
            this.addUserBtn.Click += new System.EventHandler(this.AddUserBtn_Click);
            // 
            // homeBtn
            // 
            this.homeBtn.Location = new System.Drawing.Point(2, 2);
            this.homeBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.homeBtn.Name = "homeBtn";
            this.homeBtn.Size = new System.Drawing.Size(222, 68);
            this.homeBtn.TabIndex = 0;
            this.homeBtn.Text = "HOME";
            this.homeBtn.UseVisualStyleBackColor = true;
            this.homeBtn.Click += new System.EventHandler(this.HomeBtn_Click);
            // 
            // controlPanel
            // 
            this.controlPanel.Location = new System.Drawing.Point(232, 8);
            this.controlPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(680, 611);
            this.controlPanel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label1.Location = new System.Drawing.Point(3, 369);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "País seleccionado:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(3, 389);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(215, 21);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.ComboBox1_SelectionChangeCommitted);
            // 
            // Parking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 552);
            this.Controls.Add(this.controlPanel);
            this.Controls.Add(this.menuPanel);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Parking";
            this.Text = "Form1";
            this.menuPanel.ResumeLayout(false);
            this.menuPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Button checkPurchase;
        private System.Windows.Forms.Button purchaseMethodBtn;
        private System.Windows.Forms.Button addBalanceBtn;
        private System.Windows.Forms.Button addUserBtn;
        private System.Windows.Forms.Button homeBtn;
        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
    }
}

