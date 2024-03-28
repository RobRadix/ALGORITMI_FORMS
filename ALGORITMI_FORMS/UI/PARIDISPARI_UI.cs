using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALGORITMI_FORMS.UI
{
    public partial class PARIDISPARI_UI : Form
    {
        public PARIDISPARI_UI()
        {
            InitializeComponent();
            // Aggiungi un gestore per l'evento KeyPress della casella di testo txtNumero1
            txtNumero1.KeyPress += new KeyPressEventHandler(txtNumero1_KeyPress);
        }

        private void txtNumero1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica se il tasto premuto è il tasto INVIO (codice 13)
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Esegui il calcolo quando viene premuto INVIO
                CalcolaRisultato();
                // Impedisci al tasto INVIO di generare un suono di avviso
                e.Handled = true;
            }
        }

        private void btnRisultato_Click_1(object sender, EventArgs e)
        {
            // Esegui il calcolo quando viene premuto il pulsante btnRisultato
            CalcolaRisultato();
        }

        private void CalcolaRisultato()
        {
            int numero1 = 0;
            if (Int32.TryParse(txtNumero1.Text, out numero1) == false
                || numero1 <= 0)
            {
                MessageBox.Show("Inserire un numero maggiore di zero",
                    "Attenzione!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNumero1.SelectAll();
                txtNumero1.Focus();
                return;
            }

            // Siamo sicuri che arriviamo qui se la textBox > 0

            if (numero1 % 2 == 0)
            {
                lblRisultato.Text = "PARO";
                txtNumero1.SelectAll();
                txtNumero1.Focus();
            }
            else
            {
                lblRisultato.Text = "DISPARO";
                txtNumero1.SelectAll();
                txtNumero1.Focus();
            }
        }
    }



}
