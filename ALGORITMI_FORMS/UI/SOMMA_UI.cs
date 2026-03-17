using System.Drawing;
using System.Windows.Forms;

namespace ALGORITMI_FORMS.UI
{
    public partial class SOMMA_UI : BaseForm
    {
        public SOMMA_UI()
        {
            InitializeComponent();
            InizializzaForm();
        }

        private void InizializzaForm()
        {
            txtNumero1.KeyPress += txtNumero_KeyPress;
            txtNumero2.KeyPress += txtNumero_KeyPress;
            txtNumero1.Focus();
            lblRisultato.Text = "";
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                CalcolaRisultato();
                e.Handled = true;
            }
        }

        private void btnRisultato_Click(object sender, System.EventArgs e)
        {
            CalcolaRisultato();
        }

        private void CalcolaRisultato()
        {
            if (!ValidaInput(txtNumero1, "primo numero", out int numero1)) return;
            if (!ValidaInput(txtNumero2, "secondo numero", out int numero2)) return;

            long risultato = (long)numero1 + numero2;

            if (risultato > int.MaxValue || risultato < int.MinValue)
            {
                MostraErrore("Il risultato supera i limiti consentiti", txtNumero1, lblRisultato);
                return;
            }

            lblRisultato.Text = $"{numero1:N0} + {numero2:N0} = {risultato:N0}";
            lblRisultato.ForeColor = risultato > 0 ? Color.Green : risultato < 0 ? Color.Red : Color.Orange;

            txtNumero1.SelectAll();
            txtNumero1.Focus();
        }

        private bool ValidaInput(TextBox textBox, string nomeNumero, out int numero)
        {
            numero = 0;
            string input = textBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                MostraErrore($"Inserire un valore per il {nomeNumero}", textBox, lblRisultato);
                return false;
            }

            if (!int.TryParse(input, out numero))
            {
                MostraErrore($"Inserire un numero intero valido per il {nomeNumero}", textBox, lblRisultato);
                return false;
            }

            return true;
        }
    }
}
