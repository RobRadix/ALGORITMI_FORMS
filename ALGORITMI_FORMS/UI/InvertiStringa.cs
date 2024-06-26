﻿using System;
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
    public partial class InvertiStringa : Form
    {
        public InvertiStringa()
        {
            InitializeComponent();
            txtFraseDaInvertire.KeyPress += new KeyPressEventHandler(txtFraseDaInvertire_KeyPress);
        }
        private void txtFraseDaInvertire_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica se il tasto premuto è il tasto INVIO (codice 13)
            if (e.KeyChar == (char)Keys.Enter)
            {
                string input = txtFraseDaInvertire.Text;
                InvertiStringaMetod(input);
                e.Handled = true;
            }
        }
        private void btnInverti_Click(object sender, EventArgs e)
        {
            string input = txtFraseDaInvertire.Text;
            InvertiStringaMetod(input);
        }

        private void InvertiStringaMetod(string input)
        {
            
            if (!string.IsNullOrEmpty(input))
            {
                char[] caratteri = input.ToCharArray();
                Array.Reverse(caratteri);
                lblFraseInvertita.Text = new string(caratteri); ;
                txtFraseDaInvertire.SelectAll();
                txtFraseDaInvertire.Focus();
            }
            else
            {
                MessageBox.Show("Inserire una frase",
                    "Attenzione!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFraseDaInvertire.SelectAll();
                txtFraseDaInvertire.Focus();
            }
            
        }

    }
}
