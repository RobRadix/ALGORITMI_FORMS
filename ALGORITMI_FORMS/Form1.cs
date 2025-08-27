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
            // Imposta il titolo della finestra principale
            this.Text = "Menu Algoritmi - Seleziona un'operazione";

            // Centra la finestra sullo schermo
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnSomma_Click(object sender, EventArgs e)
        {
            ApriForm<SOMMA_UI>("Calcolo Somma");
        }

        private void btnMoltiplicazione_Click(object sender, EventArgs e)
        {
            ApriForm<MOLTIPLICAZIONE_UI>("Calcolo Moltiplicazione");
        }

        private void btnPariDispari_Click(object sender, EventArgs e)
        {
            ApriForm<PARIDISPARI_UI>("Verifica Pari/Dispari");
        }

        private void btnInvertiStringa_Click(object sender, EventArgs e)
        {
            ApriForm<InvertiStringa>("Inverti Stringa");
        }

        /// <summary>
        /// Metodo generico per aprire forme con gestione degli errori
        /// </summary>
        /// <typeparam name="T">Tipo della form da aprire</typeparam>
        /// <param name="nomeOperazione">Nome dell'operazione per i messaggi di errore</param>
        private void ApriForm<T>(string nomeOperazione) where T : Form, new()
        {
            try
            {
                using (T form = new T())
                {
                    // Centra la finestra figlia rispetto alla finestra padre
                    form.StartPosition = FormStartPosition.CenterParent;

                    // Apre la finestra in modalità dialog
                    form.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Errore nell'apertura della finestra '{nomeOperazione}':\n{ex.Message}",
                    "Errore",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Gestore per la chiusura dell'applicazione
        /// </summary>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Sei sicuro di voler chiudere l'applicazione?",
                "Conferma chiusura",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Metodo per gestire l'evento KeyDown per shortcuts da tastiera
        /// </summary>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Shortcuts da tastiera per aprire rapidamente le forme
            switch (e.KeyCode)
            {
                case Keys.F1:
                    btnSomma_Click(sender, e);
                    break;
                case Keys.F2:
                    btnMoltiplicazione_Click(sender, e);
                    break;
                case Keys.F3:
                    btnPariDispari_Click(sender, e);
                    break;
                case Keys.F4:
                    btnInvertiStringa_Click(sender, e);
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        /// <summary>
        /// Metodo per creare dinamicamente un menu (opzionale)
        /// </summary>
        private void CreaMenuStrip()
        {
            MenuStrip menuStrip = new MenuStrip();

            // Menu Operazioni
            ToolStripMenuItem menuOperazioni = new ToolStripMenuItem("Operazioni");
            menuOperazioni.DropDownItems.Add("Somma (F1)", null, btnSomma_Click);
            menuOperazioni.DropDownItems.Add("Moltiplicazione (F2)", null, btnMoltiplicazione_Click);
            menuOperazioni.DropDownItems.Add("Pari/Dispari (F3)", null, btnPariDispari_Click);
            menuOperazioni.DropDownItems.Add("Inverti Stringa (F4)", null, btnInvertiStringa_Click);
            menuOperazioni.DropDownItems.Add(new ToolStripSeparator());
            menuOperazioni.DropDownItems.Add("Esci", null, (s, e) => this.Close());

            // Menu Aiuto
            ToolStripMenuItem menuAiuto = new ToolStripMenuItem("Aiuto");
            menuAiuto.DropDownItems.Add("Informazioni", null, MostraInformazioni);

            menuStrip.Items.Add(menuOperazioni);
            menuStrip.Items.Add(menuAiuto);

            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);
        }

        /// <summary>
        /// Mostra le informazioni sull'applicazione
        /// </summary>
        private void MostraInformazioni(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Applicazione: Menu Algoritmi\n" +
                "Versione: 1.0\n" +
                "Sviluppata in C# Windows Forms\n\n" +
                "Shortcuts:\n" +
                "F1 - Somma\n" +
                "F2 - Moltiplicazione\n" +
                "F3 - Pari/Dispari\n" +
                "F4 - Inverti Stringa\n" +
                "ESC - Chiudi applicazione",
                "Informazioni",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        /// <summary>
        /// Metodo per aggiungere un pulsante "Esci" se necessario
        /// </summary>
        private void btnEsci_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}