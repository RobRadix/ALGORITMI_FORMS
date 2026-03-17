using System.Drawing;
using System.Windows.Forms;

namespace ALGORITMI_FORMS.UI
{
    public partial class PARIDISPARI_UI : BaseForm
    {
        public PARIDISPARI_UI()
        {
            InitializeComponent();
            txtNumero1.KeyPress += txtNumero1_KeyPress;
            InizializzaForm();
        }

        private void InizializzaForm()
        {
            txtNumero1.Focus();
            lblRisultato.Text = "";
        }

        private void txtNumero1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                CalcolaRisultato();
                e.Handled = true;
            }
        }

        private void btnRisultato_Click_1(object sender, System.EventArgs e)
        {
            CalcolaRisultato();
        }

        private void CalcolaRisultato()
        {
            string input = txtNumero1.Text.Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                MostraErrore("Inserire un numero valido", txtNumero1, lblRisultato);
                return;
            }

            if (!int.TryParse(input, out int numero))
            {
                MostraErrore("Inserire solo numeri interi", txtNumero1, lblRisultato);
                return;
            }

            bool isPari = (numero % 2 == 0);
            lblRisultato.Text = $"Il numero {numero} è {(isPari ? "PARI" : "DISPARI")}";
            lblRisultato.ForeColor = isPari ? Color.Blue : Color.Red;

            txtNumero1.SelectAll();
            txtNumero1.Focus();
        }
    }
}
