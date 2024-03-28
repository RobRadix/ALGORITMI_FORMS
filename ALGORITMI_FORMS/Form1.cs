using ALGORITMI_FORMS.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALGORITMI_FORMS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSomma_Click(object sender, EventArgs e)
        {
            SOMMA_UI form = new SOMMA_UI();
            form.ShowDialog();
        }

        private void btnMoltiplicazione_Click(object sender, EventArgs e)
        {
            MOLTIPLICAZIONE_UI form = new MOLTIPLICAZIONE_UI();
            form.ShowDialog();
        }

        private void btnPariDispari_Click(object sender, EventArgs e)
        {
            PARIDISPARI_UI form = new PARIDISPARI_UI();
            form.ShowDialog();
        }

        private void btnInvertiStringa_Click(object sender, EventArgs e)
        {
            InvertiStringa form = new InvertiStringa();
            form.ShowDialog();
        }
    }
}
