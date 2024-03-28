namespace ALGORITMI_FORMS
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSomma = new System.Windows.Forms.Button();
            this.btnMoltiplicazione = new System.Windows.Forms.Button();
            this.btnPariDispari = new System.Windows.Forms.Button();
            this.btnInvertiStringa = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSomma
            // 
            this.btnSomma.Location = new System.Drawing.Point(89, 51);
            this.btnSomma.Name = "btnSomma";
            this.btnSomma.Size = new System.Drawing.Size(356, 70);
            this.btnSomma.TabIndex = 0;
            this.btnSomma.Text = "SOMMA";
            this.btnSomma.UseVisualStyleBackColor = true;
            this.btnSomma.Click += new System.EventHandler(this.btnSomma_Click);
            // 
            // btnMoltiplicazione
            // 
            this.btnMoltiplicazione.Location = new System.Drawing.Point(89, 139);
            this.btnMoltiplicazione.Name = "btnMoltiplicazione";
            this.btnMoltiplicazione.Size = new System.Drawing.Size(356, 70);
            this.btnMoltiplicazione.TabIndex = 1;
            this.btnMoltiplicazione.Text = "MOLTIPLICAZIONE";
            this.btnMoltiplicazione.UseVisualStyleBackColor = true;
            this.btnMoltiplicazione.Click += new System.EventHandler(this.btnMoltiplicazione_Click);
            // 
            // btnPariDispari
            // 
            this.btnPariDispari.Location = new System.Drawing.Point(89, 231);
            this.btnPariDispari.Name = "btnPariDispari";
            this.btnPariDispari.Size = new System.Drawing.Size(356, 70);
            this.btnPariDispari.TabIndex = 2;
            this.btnPariDispari.Text = "PARI O DISPARI?";
            this.btnPariDispari.UseVisualStyleBackColor = true;
            this.btnPariDispari.Click += new System.EventHandler(this.btnPariDispari_Click);
            // 
            // btnInvertiStringa
            // 
            this.btnInvertiStringa.Location = new System.Drawing.Point(89, 327);
            this.btnInvertiStringa.Name = "btnInvertiStringa";
            this.btnInvertiStringa.Size = new System.Drawing.Size(356, 70);
            this.btnInvertiStringa.TabIndex = 3;
            this.btnInvertiStringa.Text = "INVERTI STRINGA";
            this.btnInvertiStringa.UseVisualStyleBackColor = true;
            this.btnInvertiStringa.Click += new System.EventHandler(this.btnInvertiStringa_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnInvertiStringa);
            this.Controls.Add(this.btnPariDispari);
            this.Controls.Add(this.btnMoltiplicazione);
            this.Controls.Add(this.btnSomma);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSomma;
        private System.Windows.Forms.Button btnMoltiplicazione;
        private System.Windows.Forms.Button btnPariDispari;
        private System.Windows.Forms.Button btnInvertiStringa;
    }
}

