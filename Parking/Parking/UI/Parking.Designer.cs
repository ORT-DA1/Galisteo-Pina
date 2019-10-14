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
            this.menuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuPanel
            // 
            this.menuPanel.Controls.Add(this.checkPurchase);
            this.menuPanel.Controls.Add(this.purchaseMethodBtn);
            this.menuPanel.Controls.Add(this.addBalanceBtn);
            this.menuPanel.Controls.Add(this.addUserBtn);
            this.menuPanel.Controls.Add(this.homeBtn);
            this.menuPanel.Location = new System.Drawing.Point(12, 12);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(449, 1178);
            this.menuPanel.TabIndex = 0;
            // 
            // checkPurchase
            // 
            this.checkPurchase.Location = new System.Drawing.Point(3, 551);
            this.checkPurchase.Name = "checkPurchase";
            this.checkPurchase.Size = new System.Drawing.Size(443, 131);
            this.checkPurchase.TabIndex = 4;
            this.checkPurchase.Text = "CONSULTAR COMPRA";
            this.checkPurchase.UseVisualStyleBackColor = true;
            this.checkPurchase.Click += new System.EventHandler(this.CheckPurchase_Click);
            // 
            // purchaseMethodBtn
            // 
            this.purchaseMethodBtn.Location = new System.Drawing.Point(3, 414);
            this.purchaseMethodBtn.Name = "purchaseMethodBtn";
            this.purchaseMethodBtn.Size = new System.Drawing.Size(443, 131);
            this.purchaseMethodBtn.TabIndex = 3;
            this.purchaseMethodBtn.Text = "PROCESAR COMPRA";
            this.purchaseMethodBtn.UseVisualStyleBackColor = true;
            this.purchaseMethodBtn.Click += new System.EventHandler(this.PurchaseMethodBtn_Click);
            // 
            // addBalanceBtn
            // 
            this.addBalanceBtn.Location = new System.Drawing.Point(3, 277);
            this.addBalanceBtn.Name = "addBalanceBtn";
            this.addBalanceBtn.Size = new System.Drawing.Size(443, 131);
            this.addBalanceBtn.TabIndex = 2;
            this.addBalanceBtn.Text = "AGREGAR SALDO";
            this.addBalanceBtn.UseVisualStyleBackColor = true;
            this.addBalanceBtn.Click += new System.EventHandler(this.AddBalanceBtn_Click);
            // 
            // addUserBtn
            // 
            this.addUserBtn.Location = new System.Drawing.Point(3, 140);
            this.addUserBtn.Name = "addUserBtn";
            this.addUserBtn.Size = new System.Drawing.Size(443, 131);
            this.addUserBtn.TabIndex = 1;
            this.addUserBtn.Text = "REGISTRO USUARIO";
            this.addUserBtn.UseVisualStyleBackColor = true;
            this.addUserBtn.Click += new System.EventHandler(this.AddUserBtn_Click);
            // 
            // homeBtn
            // 
            this.homeBtn.Location = new System.Drawing.Point(3, 3);
            this.homeBtn.Name = "homeBtn";
            this.homeBtn.Size = new System.Drawing.Size(443, 131);
            this.homeBtn.TabIndex = 0;
            this.homeBtn.Text = "HOME";
            this.homeBtn.UseVisualStyleBackColor = true;
            this.homeBtn.Click += new System.EventHandler(this.HomeBtn_Click);
            // 
            // controlPanel
            // 
            this.controlPanel.Location = new System.Drawing.Point(465, 15);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(1361, 1175);
            this.controlPanel.TabIndex = 1;
            // 
            // Parking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1838, 1202);
            this.Controls.Add(this.controlPanel);
            this.Controls.Add(this.menuPanel);
            this.Name = "Parking";
            this.Text = "Form1";
            this.menuPanel.ResumeLayout(false);
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
    }
}

