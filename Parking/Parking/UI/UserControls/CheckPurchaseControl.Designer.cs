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
            this.checkPurchaseLbl = new System.Windows.Forms.Label();
            this.userPlateLbl = new System.Windows.Forms.Label();
            this.userPlateTxtBox = new System.Windows.Forms.TextBox();
            this.userTimeLbl = new System.Windows.Forms.Label();
            this.userTimeTxtBox = new System.Windows.Forms.TextBox();
            this.checkPurchaseBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkPurchaseLbl
            // 
            this.checkPurchaseLbl.AutoSize = true;
            this.checkPurchaseLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkPurchaseLbl.Location = new System.Drawing.Point(493, 76);
            this.checkPurchaseLbl.Name = "checkPurchaseLbl";
            this.checkPurchaseLbl.Size = new System.Drawing.Size(320, 42);
            this.checkPurchaseLbl.TabIndex = 3;
            this.checkPurchaseLbl.Text = "Consultar Compra";
            // 
            // userPlateLbl
            // 
            this.userPlateLbl.AutoSize = true;
            this.userPlateLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userPlateLbl.Location = new System.Drawing.Point(180, 196);
            this.userPlateLbl.Name = "userPlateLbl";
            this.userPlateLbl.Size = new System.Drawing.Size(365, 31);
            this.userPlateLbl.TabIndex = 4;
            this.userPlateLbl.Text = "Ingrese numero de matricula:";
            // 
            // userPlateTxtBox
            // 
            this.userPlateTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userPlateTxtBox.Location = new System.Drawing.Point(551, 193);
            this.userPlateTxtBox.Name = "userPlateTxtBox";
            this.userPlateTxtBox.Size = new System.Drawing.Size(521, 38);
            this.userPlateTxtBox.TabIndex = 7;
            // 
            // userTimeLbl
            // 
            this.userTimeLbl.AutoSize = true;
            this.userTimeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userTimeLbl.Location = new System.Drawing.Point(180, 267);
            this.userTimeLbl.Name = "userTimeLbl";
            this.userTimeLbl.Size = new System.Drawing.Size(350, 31);
            this.userTimeLbl.TabIndex = 8;
            this.userTimeLbl.Text = "Ingrese horario de consulta:";
            // 
            // userTimeTxtBox
            // 
            this.userTimeTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userTimeTxtBox.Location = new System.Drawing.Point(551, 264);
            this.userTimeTxtBox.Name = "userTimeTxtBox";
            this.userTimeTxtBox.Size = new System.Drawing.Size(521, 38);
            this.userTimeTxtBox.TabIndex = 9;
            // 
            // checkPurchaseBtn
            // 
            this.checkPurchaseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkPurchaseBtn.Location = new System.Drawing.Point(519, 357);
            this.checkPurchaseBtn.Name = "checkPurchaseBtn";
            this.checkPurchaseBtn.Size = new System.Drawing.Size(263, 61);
            this.checkPurchaseBtn.TabIndex = 10;
            this.checkPurchaseBtn.Text = "Consultar Compra";
            this.checkPurchaseBtn.UseVisualStyleBackColor = true;
            this.checkPurchaseBtn.Click += new System.EventHandler(this.CheckPurchaseBtn_Click);
            // 
            // CheckPurchaseControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkPurchaseBtn);
            this.Controls.Add(this.userTimeTxtBox);
            this.Controls.Add(this.userTimeLbl);
            this.Controls.Add(this.userPlateTxtBox);
            this.Controls.Add(this.userPlateLbl);
            this.Controls.Add(this.checkPurchaseLbl);
            this.Name = "CheckPurchaseControl";
            this.Size = new System.Drawing.Size(1300, 960);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label checkPurchaseLbl;
        private System.Windows.Forms.Label userPlateLbl;
        private System.Windows.Forms.TextBox userPlateTxtBox;
        private System.Windows.Forms.Label userTimeLbl;
        private System.Windows.Forms.TextBox userTimeTxtBox;
        private System.Windows.Forms.Button checkPurchaseBtn;
    }
}
