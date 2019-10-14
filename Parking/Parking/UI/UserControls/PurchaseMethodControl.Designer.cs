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
<<<<<<< HEAD
            this.messagePurchaseTxt = new System.Windows.Forms.TextBox();
=======
            this.userSmsTxtBox = new System.Windows.Forms.TextBox();
>>>>>>> ce6a78cd05691a01fb43f166e548493e0d97dbc1
            this.processPurchaseBtn = new System.Windows.Forms.Button();
            this.outputErrorLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // processPurchaseLbl
            // 
            this.processPurchaseLbl.AutoSize = true;
            this.processPurchaseLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.processPurchaseLbl.Location = new System.Drawing.Point(246, 40);
            this.processPurchaseLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.processPurchaseLbl.Name = "processPurchaseLbl";
            this.processPurchaseLbl.Size = new System.Drawing.Size(157, 24);
            this.processPurchaseLbl.TabIndex = 2;
            this.processPurchaseLbl.Text = "Procesar Compra";
            // 
            // userAccountLbl
            // 
            this.userAccountLbl.AutoSize = true;
            this.userAccountLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userAccountLbl.Location = new System.Drawing.Point(90, 102);
            this.userAccountLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.userAccountLbl.Name = "userAccountLbl";
            this.userAccountLbl.Size = new System.Drawing.Size(186, 17);
            this.userAccountLbl.TabIndex = 3;
            this.userAccountLbl.Text = "Ingrese numero de telefono:";
            // 
            // purchaseMessageLbl
            // 
<<<<<<< HEAD
            this.purchaseMessageLbl.AutoSize = true;
            this.purchaseMessageLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.purchaseMessageLbl.Location = new System.Drawing.Point(180, 267);
            this.purchaseMessageLbl.Name = "purchaseMessageLbl";
            this.purchaseMessageLbl.Size = new System.Drawing.Size(356, 31);
            this.purchaseMessageLbl.TabIndex = 5;
            this.purchaseMessageLbl.Text = "Ingrese mensaje de compra:";
=======
            this.userBalanceLbl.AutoSize = true;
            this.userBalanceLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userBalanceLbl.Location = new System.Drawing.Point(90, 139);
            this.userBalanceLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.userBalanceLbl.Name = "userBalanceLbl";
            this.userBalanceLbl.Size = new System.Drawing.Size(187, 17);
            this.userBalanceLbl.TabIndex = 5;
            this.userBalanceLbl.Text = "Ingrese mensaje de compra:";
>>>>>>> ce6a78cd05691a01fb43f166e548493e0d97dbc1
            // 
            // userAccountTxtBox
            // 
            this.userAccountTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userAccountTxtBox.Location = new System.Drawing.Point(280, 99);
            this.userAccountTxtBox.Margin = new System.Windows.Forms.Padding(2);
            this.userAccountTxtBox.Name = "userAccountTxtBox";
            this.userAccountTxtBox.Size = new System.Drawing.Size(269, 23);
            this.userAccountTxtBox.TabIndex = 6;
            // 
<<<<<<< HEAD
            // messagePurchaseTxt
            // 
            this.messagePurchaseTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messagePurchaseTxt.Location = new System.Drawing.Point(538, 264);
            this.messagePurchaseTxt.Name = "messagePurchaseTxt";
            this.messagePurchaseTxt.Size = new System.Drawing.Size(534, 38);
            this.messagePurchaseTxt.TabIndex = 7;
=======
            // userSmsTxtBox
            // 
            this.userSmsTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userSmsTxtBox.Location = new System.Drawing.Point(280, 136);
            this.userSmsTxtBox.Margin = new System.Windows.Forms.Padding(2);
            this.userSmsTxtBox.Name = "userSmsTxtBox";
            this.userSmsTxtBox.Size = new System.Drawing.Size(269, 23);
            this.userSmsTxtBox.TabIndex = 7;
>>>>>>> ce6a78cd05691a01fb43f166e548493e0d97dbc1
            // 
            // processPurchaseBtn
            // 
            this.processPurchaseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.processPurchaseBtn.Location = new System.Drawing.Point(260, 186);
            this.processPurchaseBtn.Margin = new System.Windows.Forms.Padding(2);
            this.processPurchaseBtn.Name = "processPurchaseBtn";
            this.processPurchaseBtn.Size = new System.Drawing.Size(132, 32);
            this.processPurchaseBtn.TabIndex = 8;
            this.processPurchaseBtn.Text = "Procesar Compra";
            this.processPurchaseBtn.UseVisualStyleBackColor = true;
            this.processPurchaseBtn.Click += new System.EventHandler(this.ProcessPurchaseBtn_Click);
<<<<<<< HEAD
=======
            // 
            // outputErrorLbl
            // 
            this.outputErrorLbl.AutoSize = true;
            this.outputErrorLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputErrorLbl.Location = new System.Drawing.Point(90, 236);
            this.outputErrorLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.outputErrorLbl.Name = "outputErrorLbl";
            this.outputErrorLbl.Size = new System.Drawing.Size(91, 17);
            this.outputErrorLbl.TabIndex = 9;
            this.outputErrorLbl.Text = "Output Error:";
>>>>>>> ce6a78cd05691a01fb43f166e548493e0d97dbc1
            // 
            // PurchaseMethodControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.outputErrorLbl);
            this.Controls.Add(this.processPurchaseBtn);
<<<<<<< HEAD
            this.Controls.Add(this.messagePurchaseTxt);
=======
            this.Controls.Add(this.userSmsTxtBox);
>>>>>>> ce6a78cd05691a01fb43f166e548493e0d97dbc1
            this.Controls.Add(this.userAccountTxtBox);
            this.Controls.Add(this.purchaseMessageLbl);
            this.Controls.Add(this.userAccountLbl);
            this.Controls.Add(this.processPurchaseLbl);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PurchaseMethodControl";
<<<<<<< HEAD
            this.Size = new System.Drawing.Size(1300, 960);
=======
            this.Size = new System.Drawing.Size(650, 499);
>>>>>>> ce6a78cd05691a01fb43f166e548493e0d97dbc1
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label processPurchaseLbl;
        private System.Windows.Forms.Label userAccountLbl;
        private System.Windows.Forms.Label purchaseMessageLbl;
        private System.Windows.Forms.TextBox userAccountTxtBox;
<<<<<<< HEAD
        private System.Windows.Forms.TextBox messagePurchaseTxt;
=======
        private System.Windows.Forms.TextBox userSmsTxtBox;
>>>>>>> ce6a78cd05691a01fb43f166e548493e0d97dbc1
        private System.Windows.Forms.Button processPurchaseBtn;
        private System.Windows.Forms.Label outputErrorLbl;
    }
}
