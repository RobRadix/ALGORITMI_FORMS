using System;
using System.Drawing;
using System.Windows.Forms;

namespace ALGORITMI_FORMS.UI
{
    public partial class MOLTIPLICAZIONE_UI : Form
    {
        public MOLTIPLICAZIONE_UI()
        {
            InitializeComponent();
            InizializzaForm();
        }

        private void InizializzaForm()
        {
            // Aggiungi gestori di eventi per entrambe le textbox
            txtNumero1.KeyPress += new KeyPressEventHandler(txtNumero_KeyPress);
            txtNumero2.KeyPress += new KeyPressEventHandler(txtNumero_KeyPress);

            // Imposta il focus iniziale sulla prima textbox
            txtNumero1.Focus();

            // Pulisci la label del risultato all'avvio
            lblRisultato.Text = "";
            lblRisultato.ForeColor = Color.Black;
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnRisultato_Click(object sender, EventArgs e)
        {
            CalcolaRisultato();
        }

        private void CalcolaRisultato()
        {
            // Validazione primo numero
            if (!ValidaInput(txtNumero1, "primo numero", out int numero1))
                return;

            // Validazione secondo numero
            if (!ValidaInput(txtNumero2, "secondo numero", out int numero2))
                return;

            try
            {
                // Calcolo con controllo overflow
                long risultato = (long)numero1 * numero2;

                // Verifica se il risultato supera i limiti di int
                if (risultato > int.MaxValue || risultato < int.MinValue)
                {
                    MostraErrore("Il risultato è troppo grande per essere visualizzato", txtNumero1);
                    return;
                }

                // Visualizza il risultato con formattazione
                lblRisultato.Text = $"{numero1} × {numero2} = {risultato:N0}";
                lblRisultato.ForeColor = Color.Green;

                // Seleziona tutto il testo nella prima textbox e riporta il focus
                txtNumero1.SelectAll();
                txtNumero1.Focus();
            }
            catch (OverflowException)
            {
                MostraErrore("Il risultato è troppo grande per essere calcolato", txtNumero1);
            }
            catch (Exception ex)
            {
                MostraErrore($"Errore durante il calcolo: {ex.Message}", txtNumero1);
            }
        }

        /// <summary>
        /// Valida l'input di una textbox
        /// </summary>
        /// <param name="textBox">La textbox da validare</param>
        /// <param name="nomeNumero">Nome del numero per i messaggi di errore</param>
        /// <param name="numero">Il numero validato (output)</param>
        /// <returns>True se la validazione è riuscita, False altrimenti</returns>
        private bool ValidaInput(TextBox textBox, string nomeNumero, out int numero)
        {
            numero = 0;
            string input = textBox.Text.Trim();

            // Verifica se l'input è vuoto
            if (string.IsNullOrWhiteSpace(input))
            {
                MostraErrore($"Inserire un valore per il {nomeNumero}", textBox);
                return false;
            }

            // Verifica se l'input è un numero valido
            if (!int.TryParse(input, out numero))
            {
                MostraErrore($"Inserire un numero intero valido per il {nomeNumero}", textBox);
                return false;
            }

            // Verifica se il numero è diverso da zero
            if (numero == 0)
            {
                MostraErrore($"Il {nomeNumero} non può essere zero", textBox);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Mostra un messaggio di errore e imposta il focus sulla textbox specificata
        /// </summary>
        /// <param name="messaggio">Messaggio da visualizzare</param>
        /// <param name="textBox">TextBox su cui impostare il focus</param>
        private void MostraErrore(string messaggio, TextBox textBox)
        {
            MessageBox.Show(messaggio, "Attenzione!",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);

            // Pulisci la label del risultato in caso di errore
            lblRisultato.Text = "";

            // Seleziona tutto il testo e riporta il focus sulla textbox
            textBox.SelectAll();
            textBox.Focus();
        }

        // Metodo opzionale per aggiungere un pulsante "Pulisci"
        private void btnPulisci_Click(object sender, EventArgs e)
        {
            PulisciForm();
        }

        private void PulisciForm()
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            lblRisultato.Text = "";
            lblRisultato.ForeColor = Color.Black;
            txtNumero1.Focus();
        }

        // Metodo per permettere solo l'inserimento di numeri e segno negativo
        private void txtNumero_KeyPress_SoloNumeri(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Permetti numeri, backspace, INVIO e segno negativo
            if (!char.IsDigit(e.KeyChar) &&
                e.KeyChar != (char)Keys.Back &&
                e.KeyChar != (char)Keys.Enter &&
                e.KeyChar != '-')
            {
                e.Handled = true;
                return;
            }

            // Permetti il segno negativo solo all'inizio
            if (e.KeyChar == '-' && (textBox.SelectionStart != 0 || textBox.Text.Contains("-")))
            {
                e.Handled = true;
                return;
            }

            // Se è stato premuto INVIO, calcola il risultato
            if (e.KeyChar == (char)Keys.Enter)
            {
                CalcolaRisultato();
                e.Handled = true;
            }
        }

        // Gestore per il cambio di focus automatico tra le textbox
        private void txtNumero1_Leave(object sender, EventArgs e)
        {
            // Quando si esce dalla prima textbox, vai alla seconda se è valida
            if (ValidaInput(txtNumero1, "primo numero", out _))
            {
                txtNumero2.Focus();
            }
        }

        // Metodo per copiare il risultato negli appunti (opzionale)
        private void CopiaRisultato()
        {
            if (!string.IsNullOrEmpty(lblRisultato.Text))
            {
                try
                {
                    Clipboard.SetText(lblRisultato.Text);
                    MessageBox.Show("Risultato copiato negli appunti!", "Informazione",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Errore nella copia: {ex.Message}", "Errore",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}