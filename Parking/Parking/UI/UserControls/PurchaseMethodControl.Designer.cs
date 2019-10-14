namespace UI.UserControls
{
    partial class PurchaseMethodControl
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
            this.processPurchaseLbl = new System.Windows.Forms.Label();
            this.userAccountLbl = new System.Windows.Forms.Label();
            this.purchaseMessageLbl = new System.Windows.Forms.Label();
            this.userAccountTxtBox = new System.Windows.Forms.TextBox();
            this.messagePurchaseTxt = new System.Windows.Forms.TextBox();
            this.processPurchaseBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // processPurchaseLbl
            // 
            this.processPurchaseLbl.AutoSize = true;
            this.processPurchaseLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.processPurchaseLbl.Location = new System.Drawing.Point(493, 76);
            this.processPurchaseLbl.Name = "processPurchaseLbl";
            this.processPurchaseLbl.Size = new System.Drawing.Size(310, 42);
            this.processPurchaseLbl.TabIndex = 2;
            this.processPurchaseLbl.Text = "Procesar Compra";
            // 
            // userAccountLbl
            // 
            this.userAccountLbl.AutoSize = true;
            this.userAccountLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userAccountLbl.Location = new System.Drawing.Point(180, 196);
            this.userAccountLbl.Name = "userAccountLbl";
            this.userAccountLbl.Size = new System.Drawing.Size(352, 31);
            this.userAccountLbl.TabIndex = 3;
            this.userAccountLbl.Text = "Ingrese numero de telefono:";
            // 
            // purchaseMessageLbl
            // 
            this.purchaseMessageLbl.AutoSize = true;
            this.purchaseMessageLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.purchaseMessageLbl.Location = new System.Drawing.Point(180, 267);
            this.purchaseMessageLbl.Name = "purchaseMessageLbl";
            this.purchaseMessageLbl.Size = new System.Drawing.Size(356, 31);
            this.purchaseMessageLbl.TabIndex = 5;
            this.purchaseMessageLbl.Text = "Ingrese mensaje de compra:";
            // 
            // userAccountTxtBox
            // 
            this.userAccountTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userAccountTxtBox.Location = new System.Drawing.Point(538, 193);
            this.userAccountTxtBox.Name = "userAccountTxtBox";
            this.userAccountTxtBox.Size = new System.Drawing.Size(534, 38);
            this.userAccountTxtBox.TabIndex = 6;
            // 
            // messagePurchaseTxt
            // 
            this.messagePurchaseTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messagePurchaseTxt.Location = new System.Drawing.Point(538, 264);
            this.messagePurchaseTxt.Name = "messagePurchaseTxt";
            this.messagePurchaseTxt.Size = new System.Drawing.Size(534, 38);
            this.messagePurchaseTxt.TabIndex = 7;
            // 
            // processPurchaseBtn
            // 
            this.processPurchaseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.processPurchaseBtn.Location = new System.Drawing.Point(519, 357);
            this.processPurchaseBtn.Name = "processPurchaseBtn";
            this.processPurchaseBtn.Size = new System.Drawing.Size(263, 61);
            this.processPurchaseBtn.TabIndex = 8;
            this.processPurchaseBtn.Text = "Procesar Compra";
            this.processPurchaseBtn.UseVisualStyleBackColor = true;
            this.processPurchaseBtn.Click += new System.EventHandler(this.ProcessPurchaseBtn_Click);
            // 
            // PurchaseMethodControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.processPurchaseBtn);
            this.Controls.Add(this.messagePurchaseTxt);
            this.Controls.Add(this.userAccountTxtBox);
            this.Controls.Add(this.purchaseMessageLbl);
            this.Controls.Add(this.userAccountLbl);
            this.Controls.Add(this.processPurchaseLbl);
            this.Name = "PurchaseMethodControl";
            this.Size = new System.Drawing.Size(1300, 960);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label processPurchaseLbl;
        private System.Windows.Forms.Label userAccountLbl;
        private System.Windows.Forms.Label purchaseMessageLbl;
        private System.Windows.Forms.TextBox userAccountTxtBox;
        private System.Windows.Forms.TextBox messagePurchaseTxt;
        private System.Windows.Forms.Button processPurchaseBtn;
    }
}
