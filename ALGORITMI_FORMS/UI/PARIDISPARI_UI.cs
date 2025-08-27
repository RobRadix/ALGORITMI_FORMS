using System;
using System.Drawing;
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

            // Inizializza lo stato della form
            InizializzaForm();
        }

        private void InizializzaForm()
        {
            // Imposta il focus iniziale sulla textbox
            txtNumero1.Focus();

            // Pulisci la label del risultato all'avvio
            lblRisultato.Text = "";
            lblRisultato.ForeColor = Color.Black;
        }

        private void txtNumero1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica se il tasto premuto è il tasto INVIO
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
            // Pulisci eventuali spazi dall'input
            string input = txtNumero1.Text.Trim();

            // Verifica se l'input è vuoto o contiene solo spazi
            if (string.IsNullOrWhiteSpace(input))
            {
                MostraErrore("Inserire un numero valido");
                return;
            }

            // Verifica se l'input è un numero intero valido
            if (!int.TryParse(input, out int numero1))
            {
                MostraErrore("Inserire solo numeri interi");
                return;
            }

            // Verifica se il numero è maggiore di zero
            if (numero1 <= 0)
            {
                MostraErrore("Inserire un numero maggiore di zero");
                return;
            }

            // Calcolo del risultato: pari o dispari
            bool isPari = (numero1 % 2 == 0);
            string risultato = isPari ? "PARI" : "DISPARI";

            // Visualizza il risultato con colori diversi
            lblRisultato.Text = $"Il numero {numero1} è {risultato}";
            lblRisultato.ForeColor = isPari ? Color.Blue : Color.Red;

            // Seleziona tutto il testo e riporta il focus sulla textbox
            txtNumero1.SelectAll();
            txtNumero1.Focus();
        }

        private void MostraErrore(string messaggio)
        {
            // Mostra il messaggio di errore
            MessageBox.Show(messaggio, "Attenzione!",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);

            // Pulisci la label del risultato in caso di errore
            lblRisultato.Text = "";

            // Seleziona tutto il testo e riporta il focus sulla textbox
            txtNumero1.SelectAll();
            txtNumero1.Focus();
        }

        // Metodo opzionale per aggiungere un pulsante "Pulisci"
        private void btnPulisci_Click(object sender, EventArgs e)
        {
            PulisciForm();
        }

        private void PulisciForm()
        {
            txtNumero1.Clear();
            lblRisultato.Text = "";
            lblRisultato.ForeColor = Color.Black;
            txtNumero1.Focus();
        }

        // Metodo per permettere solo l'inserimento di numeri nella textbox
        // (opzionale - da collegare all'evento KeyPress se desiderato)
        private void txtNumero1_KeyPress_SoloNumeri(object sender, KeyPressEventArgs e)
        {
            // Permetti solo numeri, backspace e il tasto INVIO
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Enter)
            {
                e.Handled = true;
            }

            // Se è stato premuto INVIO, calcola il risultato
            if (e.KeyChar == (char)Keys.Enter)
            {
                CalcolaRisultato();
                e.Handled = true;
            }
        }
    }
}