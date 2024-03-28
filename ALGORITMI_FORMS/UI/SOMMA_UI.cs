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
    public partial class SOMMA_UI : Form
    {
        public SOMMA_UI()
        {
            InitializeComponent();
        }

        private void btnRisultato_Click(object sender, EventArgs e)
        {
            this.CalcolaRisultato();
        }

        private void CalcolaRisultato()
        {
            int numero1 = 0;
            if (Int32.TryParse(txtNumero1.Text, out numero1) == false
                || numero1 == 0 ) 
            {
                MessageBox.Show("Inserire un numero maggiore di zero",
                    "Attenzione!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNumero1.SelectAll(); 
                txtNumero1.Focus();
                return;
            }

            int numero2 = 0;
            if (Int32.TryParse(txtNumero2.Text, out numero2) == false
                || numero2 == 0)
            {
                MessageBox.Show("Inserire un numero maggiore di zero",
                    "Attenzione!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNumero2.SelectAll();
                txtNumero2.Focus();
                return;
            }
            //siamo sicuri che arriviamo qui se entrambe le texBox > 0

            lblRisultato.Text = (numero1 + numero2).ToString();
            txtNumero1.SelectAll();
            txtNumero2.SelectAll();
            txtNumero1.Focus();
        }

        
    }
}
