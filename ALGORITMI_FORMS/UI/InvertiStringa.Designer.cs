namespace ALGORITMI_FORMS.UI
{
    partial class InvertiStringa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtFrase = new System.Windows.Forms.Label();
            this.txtFraseDaInvertire = new System.Windows.Forms.TextBox();
            this.btnInverti = new System.Windows.Forms.Button();
            this.lblFraseInvertita = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtFrase
            // 
            this.txtFrase.AutoSize = true;
            this.txtFrase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFrase.Location = new System.Drawing.Point(63, 28);
            this.txtFrase.Name = "txtFrase";
            this.txtFrase.Size = new System.Drawing.Size(234, 25);
            this.txtFrase.TabIndex = 3;
            this.txtFrase.Text = "INSERISCI UNA FRASE:";
            // 
            // txtFraseDaInvertire
            // 
            this.txtFraseDaInvertire.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFraseDaInvertire.Location = new System.Drawing.Point(68, 73);
            this.txtFraseDaInvertire.Name = "txtFraseDaInvertire";
            this.txtFraseDaInvertire.Size = new System.Drawing.Size(694, 36);
            this.txtFraseDaInvertire.TabIndex = 4;
            // 
            // btnInverti
            // 
            this.btnInverti.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInverti.Location = new System.Drawing.Point(68, 136);
            this.btnInverti.Name = "btnInverti";
            this.btnInverti.Size = new System.Drawing.Size(250, 54);
            this.btnInverti.TabIndex = 5;
            this.btnInverti.Text = "INVERTI LA FRASE";
            this.btnInverti.UseVisualStyleBackColor = true;
            this.btnInverti.Click += new System.EventHandler(this.btnInverti_Click);
            // 
            // lblFraseInvertita
            // 
            this.lblFraseInvertita.AutoSize = true;
            this.lblFraseInvertita.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFraseInvertita.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFraseInvertita.ForeColor = System.Drawing.Color.Black;
            this.lblFraseInvertita.Location = new System.Drawing.Point(68, 236);
            this.lblFraseInvertita.Name = "lblFraseInvertita";
            this.lblFraseInvertita.Size = new System.Drawing.Size(2, 31);
            this.lblFraseInvertita.TabIndex = 6;
            // 
            // InvertiStringa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblFraseInvertita);
            this.Controls.Add(this.btnInverti);
            this.Controls.Add(this.txtFraseDaInvertire);
            this.Controls.Add(this.txtFrase);
            this.Name = "InvertiStringa";
            this.Text = "InvertiStringa";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtFrase;
        private System.Windows.Forms.TextBox txtFraseDaInvertire;
        private System.Windows.Forms.Button btnInverti;
        private System.Windows.Forms.Label lblFraseInvertita;
    }
}