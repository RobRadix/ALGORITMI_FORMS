using System;
using System.Drawing;
using System.Windows.Forms;

namespace ALGORITMI_FORMS.UI
{
    public partial class SOMMA_UI : Form
    {
        public SOMMA_UI()
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

            // Imposta il titolo della finestra se non è già impostato
            if (string.IsNullOrEmpty(this.Text))
                this.Text = "Calcolo Somma";
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
            try
            {
                // Validazione primo numero
                if (!ValidaInput(txtNumero1, "primo numero", out int numero1))
                    return;

                // Validazione secondo numero
                if (!ValidaInput(txtNumero2, "secondo numero", out int numero2))
                    return;

                // Calcolo con controllo overflow
                long risultato = (long)numero1 + numero2;

                // Verifica se il risultato supera i limiti di int
                if (risultato > int.MaxValue || risultato < int.MinValue)
                {
                    MostraErrore("Il risultato è troppo grande per essere visualizzato", txtNumero1);
                    return;
                }

                // Visualizza il risultato con formattazione
                MostraRisultato(numero1, numero2, (int)risultato);

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

            // Opzionale: rimuovi questa condizione se vuoi permettere lo zero
            if (numero == 0)
            {
                MostraErrore($"Il {nomeNumero} non può essere zero", textBox);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Mostra il risultato della somma con formattazione
        /// </summary>
        /// <param name="numero1">Primo numero</param>
        /// <param name="numero2">Secondo numero</param>
        /// <param name="risultato">Risultato della somma</param>
        private void MostraRisultato(int numero1, int numero2, int risultato)
        {
            // Formattazione del risultato con l'operazione completa
            lblRisultato.Text = $"{numero1:N0} + {numero2:N0} = {risultato:N0}";

            // Colore diverso in base al risultato
            if (risultato > 0)
                lblRisultato.ForeColor = Color.Green;
            else if (risultato < 0)
                lblRisultato.ForeColor = Color.Red;
            else
                lblRisultato.ForeColor = Color.Orange;
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
        private void btnCopia_Click(object sender, EventArgs e)
        {
            CopiaRisultato();
        }

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
            else
            {
                MessageBox.Show("Nessun risultato da copiare", "Attenzione",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Metodo per calcolare operazioni multiple (opzionale)
        private void CalcolaOperazioniMultiple()
        {
            if (!ValidaInput(txtNumero1, "primo numero", out int numero1) ||
                !ValidaInput(txtNumero2, "secondo numero", out int numero2))
                return;

            try
            {
                long somma = (long)numero1 + numero2;
                long differenza = (long)numero1 - numero2;
                long prodotto = (long)numero1 * numero2;
                string divisione = numero2 != 0 ? ((double)numero1 / numero2).ToString("F2") : "N/A";

                string risultati = $"Operazioni tra {numero1} e {numero2}:\n\n" +
                                 $"Somma: {somma:N0}\n" +
                                 $"Differenza: {differenza:N0}\n" +
                                 $"Prodotto: {prodotto:N0}\n" +
                                 $"Divisione: {divisione}";

                MessageBox.Show(risultati, "Tutte le operazioni",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MostraErrore($"Errore nel calcolo: {ex.Message}", txtNumero1);
            }
        }

        // Validazione alternativa che permette lo zero (se necessario)
        private bool ValidaInputConZero(TextBox textBox, string nomeNumero, out int numero)
        {
            numero = 0;
            string input = textBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                MostraErrore($"Inserire un valore per il {nomeNumero}", textBox);
                return false;
            }

            if (!int.TryParse(input, out numero))
            {
                MostraErrore($"Inserire un numero intero valido per il {nomeNumero}", textBox);
                return false;
            }

            return true; // Permette anche lo zero
        }
    }
}