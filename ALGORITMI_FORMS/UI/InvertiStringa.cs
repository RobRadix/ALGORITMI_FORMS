using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ALGORITMI_FORMS.UI
{
    public partial class InvertiStringa : BaseForm
    {
        public InvertiStringa()
        {
            InitializeComponent();
            InizializzaForm();
        }

        private void InizializzaForm()
        {
            txtFraseDaInvertire.KeyPress += txtFraseDaInvertire_KeyPress;
            txtFraseDaInvertire.Focus();
            lblFraseInvertita.Text = "";
        }

        private void txtFraseDaInvertire_KeyPress(object sender, KeyPressEventArgs e)
        {
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
            string input = txtFraseDaInvertire.Text;

            if (string.IsNullOrWhiteSpace(input))
            {
                MostraErrore("Inserire una frase o una parola da invertire", txtFraseDaInvertire, lblFraseInvertita);
                return;
            }

            if (input.Length > 1000)
            {
                MostraErrore("La frase è troppo lunga (massimo 1000 caratteri)", txtFraseDaInvertire, lblFraseInvertita);
                return;
            }

            char[] caratteri = input.ToCharArray();
            Array.Reverse(caratteri);
            string risultato = new string(caratteri);

            lblFraseInvertita.Text = risultato;
            lblFraseInvertita.ForeColor = EsaminaPalindromo(input) ? Color.Green : Color.Blue;

            txtFraseDaInvertire.SelectAll();
            txtFraseDaInvertire.Focus();
        }

        private bool EsaminaPalindromo(string input)
        {
            string normalizzata = input.Replace(" ", "").ToLower();
            return normalizzata == new string(normalizzata.Reverse().ToArray());
        }
    }
}
