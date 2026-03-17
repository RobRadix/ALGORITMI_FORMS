using ALGORITMI_FORMS.UI;
using System;
using System.Windows.Forms;

namespace ALGORITMI_FORMS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InizializzaForm();
        }

        private void InizializzaForm()
        {
            this.Text = "Menu Algoritmi - Seleziona un'operazione";
            this.StartPosition = FormStartPosition.CenterScreen;

            // Abilita la cattura degli eventi tastiera sulla form
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
            this.FormClosing += Form1_FormClosing;
        }

        private void btnSomma_Click(object sender, EventArgs e)
        {
            ApriForm<SOMMA_UI>();
        }

        private void btnMoltiplicazione_Click(object sender, EventArgs e)
        {
            ApriForm<MOLTIPLICAZIONE_UI>();
        }

        private void btnPariDispari_Click(object sender, EventArgs e)
        {
            ApriForm<PARIDISPARI_UI>();
        }

        private void btnInvertiStringa_Click(object sender, EventArgs e)
        {
            ApriForm<InvertiStringa>();
        }

        private void ApriForm<T>() where T : Form, new()
        {
            using (T form = new T())
            {
                form.StartPosition = FormStartPosition.CenterParent;
                form.ShowDialog(this);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1: ApriForm<SOMMA_UI>(); break;
                case Keys.F2: ApriForm<MOLTIPLICAZIONE_UI>(); break;
                case Keys.F3: ApriForm<PARIDISPARI_UI>(); break;
                case Keys.F4: ApriForm<InvertiStringa>(); break;
                case Keys.Escape: this.Close(); break;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Sei sicuro di voler chiudere l'applicazione?",
                "Conferma chiusura",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
                e.Cancel = true;
        }
    }
}
