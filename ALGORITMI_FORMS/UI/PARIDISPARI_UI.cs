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
        }

        private void btnRisultato_Click_1(object sender, EventArgs e)
        {
            this.CalcolaRisultato();
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

            //siamo sicuri che arriviamo qui se la texBox > 0

            if (numero1 %2 == 0)
            {
                lblRisultato.Text = "PARO";
                txtNumero1 .SelectAll();
                txtNumero1.Focus ();
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
