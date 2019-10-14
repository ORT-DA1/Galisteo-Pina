namespace UI.UserControls
{
    partial class PurchaseControl
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
            this.userAccountLbl = new System.Windows.Forms.Label();
            this.accountRegisterLbl = new System.Windows.Forms.Label();
            this.userAccountTxtBox = new System.Windows.Forms.TextBox();
            this.purchaseMethodBtn = new System.Windows.Forms.Button();
            this.outputErrorLbl = new System.Windows.Forms.Label();
            this.smsLbl = new System.Windows.Forms.Label();
            this.smsTxtBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // userAccountLbl
            // 
            this.userAccountLbl.AutoSize = true;
            this.userAccountLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userAccountLbl.Location = new System.Drawing.Point(90, 102);
            this.userAccountLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.userAccountLbl.Name = "userAccountLbl";
            this.userAccountLbl.Size = new System.Drawing.Size(186, 17);
            this.userAccountLbl.TabIndex = 2;
            this.userAccountLbl.Text = "Ingrese numero de telefono:";
            // 
            // accountRegisterLbl
            // 
            this.accountRegisterLbl.AutoSize = true;
            this.accountRegisterLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountRegisterLbl.Location = new System.Drawing.Point(240, 42);
            this.accountRegisterLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.accountRegisterLbl.Name = "accountRegisterLbl";
            this.accountRegisterLbl.Size = new System.Drawing.Size(157, 24);
            this.accountRegisterLbl.TabIndex = 3;
            this.accountRegisterLbl.Text = "Procesar Compra";
            // 
            // userAccountTxtBox
            // 
            this.userAccountTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userAccountTxtBox.Location = new System.Drawing.Point(280, 99);
            this.userAccountTxtBox.Margin = new System.Windows.Forms.Padding(2);
            this.userAccountTxtBox.Name = "userAccountTxtBox";
            this.userAccountTxtBox.Size = new System.Drawing.Size(269, 23);
            this.userAccountTxtBox.TabIndex = 4;
            // 
            // purchaseMethodBtn
            // 
            this.purchaseMethodBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.purchaseMethodBtn.Location = new System.Drawing.Point(253, 191);
            this.purchaseMethodBtn.Margin = new System.Windows.Forms.Padding(2);
            this.purchaseMethodBtn.Name = "purchaseMethodBtn";
            this.purchaseMethodBtn.Size = new System.Drawing.Size(132, 32);
            this.purchaseMethodBtn.TabIndex = 5;
            this.purchaseMethodBtn.Text = "Procesar Compra";
            this.purchaseMethodBtn.UseVisualStyleBackColor = true;
            // 
            // outputErrorLbl
            // 
            this.outputErrorLbl.AutoSize = true;
            this.outputErrorLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputErrorLbl.Location = new System.Drawing.Point(90, 241);
            this.outputErrorLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.outputErrorLbl.Name = "outputErrorLbl";
            this.outputErrorLbl.Size = new System.Drawing.Size(91, 17);
            this.outputErrorLbl.TabIndex = 6;
            this.outputErrorLbl.Text = "Output Error:";
            // 
            // smsLbl
            // 
            this.smsLbl.AutoSize = true;
            this.smsLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smsLbl.Location = new System.Drawing.Point(90, 144);
            this.smsLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.smsLbl.Name = "smsLbl";
            this.smsLbl.Size = new System.Drawing.Size(170, 17);
            this.smsLbl.TabIndex = 7;
            this.smsLbl.Text = "Ingrese mensaje de texto:";
            // 
            // smsTxtBox
            // 
            this.smsTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smsTxtBox.Location = new System.Drawing.Point(280, 141);
            this.smsTxtBox.Margin = new System.Windows.Forms.Padding(2);
            this.smsTxtBox.Name = "smsTxtBox";
            this.smsTxtBox.Size = new System.Drawing.Size(269, 23);
            this.smsTxtBox.TabIndex = 8;
            // 
            // PurchaseControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.smsTxtBox);
            this.Controls.Add(this.smsLbl);
            this.Controls.Add(this.outputErrorLbl);
            this.Controls.Add(this.purchaseMethodBtn);
            this.Controls.Add(this.userAccountTxtBox);
            this.Controls.Add(this.accountRegisterLbl);
            this.Controls.Add(this.userAccountLbl);
            this.Name = "PurchaseControl";
            this.Size = new System.Drawing.Size(650, 499);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label userAccountLbl;
        private System.Windows.Forms.Label accountRegisterLbl;
        private System.Windows.Forms.TextBox userAccountTxtBox;
        private System.Windows.Forms.Button purchaseMethodBtn;
        private System.Windows.Forms.Label outputErrorLbl;
        private System.Windows.Forms.Label smsLbl;
        private System.Windows.Forms.TextBox smsTxtBox;
    }
}
