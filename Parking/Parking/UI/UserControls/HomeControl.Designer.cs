namespace UI.UserControls
{
    partial class HomeControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.parkingValorTxt = new System.Windows.Forms.TextBox();
            this.parkingValorBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(360, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(563, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "Diseño de Aplicaciones 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(516, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 42);
            this.label2.TabIndex = 1;
            this.label2.Text = "Obligatorio 1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(476, 518);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(282, 37);
            this.label3.TabIndex = 2;
            this.label3.Text = "Joel Piña - 228901";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(476, 566);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(246, 37);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ignacio Galisteo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(87, 830);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(505, 37);
            this.label5.TabIndex = 4;
            this.label5.Text = "Configurar costo estacionamiento:";
            // 
            // parkingValorTxt
            // 
            this.parkingValorTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.parkingValorTxt.Location = new System.Drawing.Point(598, 827);
            this.parkingValorTxt.Name = "parkingValorTxt";
            this.parkingValorTxt.Size = new System.Drawing.Size(325, 44);
            this.parkingValorTxt.TabIndex = 5;
            // 
            // parkingValorBtn
            // 
            this.parkingValorBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.parkingValorBtn.Location = new System.Drawing.Point(959, 827);
            this.parkingValorBtn.Name = "parkingValorBtn";
            this.parkingValorBtn.Size = new System.Drawing.Size(263, 61);
            this.parkingValorBtn.TabIndex = 9;
            this.parkingValorBtn.Text = "Cambiar Valor";
            this.parkingValorBtn.UseVisualStyleBackColor = true;
            // 
            // HomeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.parkingValorBtn);
            this.Controls.Add(this.parkingValorTxt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "HomeControl";
            this.Size = new System.Drawing.Size(1300, 960);
            this.Load += new System.EventHandler(this.HomeControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox parkingValorTxt;
        private System.Windows.Forms.Button parkingValorBtn;
    }
}
