using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ALGORITMI_FORMS.UI
{
    public partial class InvertiStringa : Form
    {
        public InvertiStringa()
        {
            InitializeComponent();
            InizializzaForm();
        }

        private void InizializzaForm()
        {
            // Aggiungi il gestore per l'evento KeyPress
            txtFraseDaInvertire.KeyPress += new KeyPressEventHandler(txtFraseDaInvertire_KeyPress);

            // Imposta il focus iniziale sulla textbox
            txtFraseDaInvertire.Focus();

            // Pulisci la label del risultato all'avvio
            lblFraseInvertita.Text = "";
            lblFraseInvertita.ForeColor = Color.Black;

            // Imposta il titolo della finestra se non è già impostato
            if (string.IsNullOrEmpty(this.Text))
                this.Text = "Inversione Stringa";
        }

        private void txtFraseDaInvertire_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica se il tasto premuto è il tasto INVIO
            if (e.KeyChar == (char)Keys.Enter)
            {
                InvertiStringaMetodo();
                e.Handled = true;
            }
        }

        private void btnInverti_Click(object sender, EventArgs e)
        {
            InvertiStringaMetodo();
        }

        private void InvertiStringaMetodo()
        {
            try
            {
                string input = txtFraseDaInvertire.Text;

                // Validazione input
                if (!ValidaInput(input))
                    return;

                // Esegui l'inversione
                string risultato = EseguiInversione(input);

                // Visualizza il risultato
                MostraRisultato(input, risultato);

                // Imposta focus per la prossima operazione
                txtFraseDaInvertire.SelectAll();
                txtFraseDaInvertire.Focus();
            }
            catch (Exception ex)
            {
                MostraErrore($"Errore durante l'inversione: {ex.Message}");
            }
        }

        /// <summary>
        /// Valida l'input dell'utente
        /// </summary>
        /// <param name="input">Stringa da validare</param>
        /// <returns>True se l'input è valido, False altrimenti</returns>
        private bool ValidaInput(string input)
        {
            // Controlla se la stringa è null, vuota o contiene solo spazi
            if (string.IsNullOrWhiteSpace(input))
            {
                MostraErrore("Inserire una frase o una parola da invertire");
                return false;
            }

            // Controlla la lunghezza massima (opzionale)
            if (input.Length > 1000)
            {
                MostraErrore("La frase è troppo lunga (massimo 1000 caratteri)");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Esegue l'inversione della stringa con diversi metodi
        /// </summary>
        /// <param name="input">Stringa da invertire</param>
        /// <returns>Stringa invertita</returns>
        private string EseguiInversione(string input)
        {
            // Metodo 1: Usando Array.Reverse (metodo originale)
            char[] caratteri = input.ToCharArray();
            Array.Reverse(caratteri);
            return new string(caratteri);

            // Metodo alternativo 2: Usando LINQ
            // return new string(input.Reverse().ToArray());

            // Metodo alternativo 3: Usando StringBuilder (più efficiente per stringhe molto lunghe)
            // StringBuilder sb = new StringBuilder(input.Length);
            // for (int i = input.Length - 1; i >= 0; i--)
            // {
            //     sb.Append(input[i]);
            // }
            // return sb.ToString();
        }

        /// <summary>
        /// Mostra il risultato dell'inversione
        /// </summary>
        /// <param name="originale">Stringa originale</param>
        /// <param name="invertita">Stringa invertita</param>
        private void MostraRisultato(string originale, string invertita)
        {
            // Visualizza il risultato con informazioni aggiuntive
            lblFraseInvertita.Text = invertita;
            lblFraseInvertita.ForeColor = Color.Blue;

            // Controlla se la stringa è un palindromo
            if (ControllaSeEPalindromo(originale))
            {
                lblFraseInvertita.ForeColor = Color.Green;
                // Opzionale: mostra un messaggio per i palindromi
                // MessageBox.Show("La frase è un palindromo!", "Informazione", 
                //     MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Controlla se una stringa è un palindromo
        /// </summary>
        /// <param name="input">Stringa da controllare</param>
        /// <returns>True se è un palindromo, False altrimenti</returns>
        private bool ControllaSeEPalindromo(string input)
        {
            // Normalizza la stringa (rimuove spazi e converte in minuscolo)
            string normalizzata = input.Replace(" ", "").ToLower();

            // Confronta con la versione invertita
            string invertita = new string(normalizzata.Reverse().ToArray());

            return normalizzata == invertita;
        }

        /// <summary>
        /// Mostra un messaggio di errore
        /// </summary>
        /// <param name="messaggio">Messaggio da visualizzare</param>
        private void MostraErrore(string messaggio)
        {
            MessageBox.Show(messaggio, "Attenzione!",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);

            // Pulisci la label del risultato
            lblFraseInvertita.Text = "";

            // Imposta il focus sulla textbox
            txtFraseDaInvertire.SelectAll();
            txtFraseDaInvertire.Focus();
        }

        // Metodo opzionale per aggiungere un pulsante "Pulisci"
        private void btnPulisci_Click(object sender, EventArgs e)
        {
            PulisciForm();
        }

        private void PulisciForm()
        {
            txtFraseDaInvertire.Clear();
            lblFraseInvertita.Text = "";
            lblFraseInvertita.ForeColor = Color.Black;
            txtFraseDaInvertire.Focus();
        }

        // Metodo per copiare il risultato negli appunti
        private void btnCopia_Click(object sender, EventArgs e)
        {
            CopiaRisultato();
        }

        private void CopiaRisultato()
        {
            if (!string.IsNullOrEmpty(lblFraseInvertita.Text))
            {
                try
                {
                    Clipboard.SetText(lblFraseInvertita.Text);
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

        // Metodo per invertire solo le parole mantenendo l'ordine
        private void btnInvertiParole_Click(object sender, EventArgs e)
        {
            InvertiSoloParole();
        }

        private void InvertiSoloParole()
        {
            try
            {
                string input = txtFraseDaInvertire.Text;

                if (!ValidaInput(input))
                    return;

                // Divide in parole e inverte ogni parola singolarmente
                string[] parole = input.Split(' ');
                for (int i = 0; i < parole.Length; i++)
                {
                    if (!string.IsNullOrWhiteSpace(parole[i]))
                    {
                        char[] caratteriParola = parole[i].ToCharArray();
                        Array.Reverse(caratteriParola);
                        parole[i] = new string(caratteriParola);
                    }
                }

                string risultato = string.Join(" ", parole);
                lblFraseInvertita.Text = risultato;
                lblFraseInvertita.ForeColor = Color.Purple;

                txtFraseDaInvertire.SelectAll();
                txtFraseDaInvertire.Focus();
            }
            catch (Exception ex)
            {
                MostraErrore($"Errore durante l'inversione delle parole: {ex.Message}");
            }
        }

        // Mostra statistiche sulla stringa (opzionale)
        private void MostraStatistiche()
        {
            string input = txtFraseDaInvertire.Text;

            if (string.IsNullOrWhiteSpace(input))
            {
                MostraErrore("Inserire una frase per visualizzare le statistiche");
                return;
            }

            int caratteriTotali = input.Length;
            int caratteriSenzaSpazi = input.Replace(" ", "").Length;
            int parole = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
            int vocali = input.ToLower().Count(c => "aeiouàèéìíîòóù".Contains(c));
            int consonanti = input.ToLower().Count(c => char.IsLetter(c) && !"aeiouàèéìíîòóù".Contains(c));

            string statistiche = $"Statistiche della frase:\n\n" +
                               $"Caratteri totali: {caratteriTotali}\n" +
                               $"Caratteri senza spazi: {caratteriSenzaSpazi}\n" +
                               $"Numero di parole: {parole}\n" +
                               $"Vocali: {vocali}\n" +
                               $"Consonanti: {consonanti}\n" +
                               $"È palindromo: {(ControllaSeEPalindromo(input) ? "Sì" : "No")}";

            MessageBox.Show(statistiche, "Statistiche",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}