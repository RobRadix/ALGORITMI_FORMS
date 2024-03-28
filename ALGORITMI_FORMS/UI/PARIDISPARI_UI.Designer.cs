namespace ALGORITMI_FORMS.UI
{
    partial class PARIDISPARI_UI
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
            this.txtNumero1 = new System.Windows.Forms.TextBox();
            this.txtNu = new System.Windows.Forms.Label();
            this.lblRisultato = new System.Windows.Forms.Label();
            this.btnRisultato = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNumero1
            // 
            this.txtNumero1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumero1.Location = new System.Drawing.Point(334, 79);
            this.txtNumero1.Name = "txtNumero1";
            this.txtNumero1.Size = new System.Drawing.Size(100, 30);
            this.txtNumero1.TabIndex = 3;
            // 
            // txtNu
            // 
            this.txtNu.AutoSize = true;
            this.txtNu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNu.Location = new System.Drawing.Point(76, 82);
            this.txtNu.Name = "txtNu";
            this.txtNu.Size = new System.Drawing.Size(235, 25);
            this.txtNu.TabIndex = 2;
            this.txtNu.Text = "INSERISCI UN NUMERO";
            // 
            // lblRisultato
            // 
            this.lblRisultato.AutoSize = true;
            this.lblRisultato.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRisultato.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRisultato.Location = new System.Drawing.Point(76, 259);
            this.lblRisultato.Name = "lblRisultato";
            this.lblRisultato.Size = new System.Drawing.Size(2, 31);
            this.lblRisultato.TabIndex = 6;
            // 
            // btnRisultato
            // 
            this.btnRisultato.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRisultato.Location = new System.Drawing.Point(81, 153);
            this.btnRisultato.Name = "btnRisultato";
            this.btnRisultato.Size = new System.Drawing.Size(353, 50);
            this.btnRisultato.TabIndex = 7;
            this.btnRisultato.Text = "Pari o Dispari";
            this.btnRisultato.UseVisualStyleBackColor = true;
            this.btnRisultato.Click += new System.EventHandler(this.btnRisultato_Click_1);
            // 
            // PARIDISPARI_UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRisultato);
            this.Controls.Add(this.lblRisultato);
            this.Controls.Add(this.txtNumero1);
            this.Controls.Add(this.txtNu);
            this.Name = "PARIDISPARI_UI";
            this.Text = "PARIDISPARI_UI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNumero1;
        private System.Windows.Forms.Label txtNu;
        private System.Windows.Forms.Label lblRisultato;
        private System.Windows.Forms.Button btnRisultato;
    }
}