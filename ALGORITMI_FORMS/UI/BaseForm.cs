using System.Drawing;
using System.Windows.Forms;

namespace ALGORITMI_FORMS.UI
{
    /// <summary>
    /// Classe base per tutte le form dell'applicazione.
    /// Contiene metodi di utilità condivisi per evitare duplicazioni.
    /// </summary>
    public class BaseForm : Form
    {
        /// <summary>
        /// Mostra un messaggio di errore e opzionalmente reimposta la label risultato
        /// e il focus sulla textbox indicata.
        /// </summary>
        protected void MostraErrore(string messaggio, TextBox textBoxFocus = null, Label labelDaPulire = null)
        {
            MessageBox.Show(messaggio, "Attenzione!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if (labelDaPulire != null)
            {
                labelDaPulire.Text = "";
                labelDaPulire.ForeColor = Color.Black;
            }

            if (textBoxFocus != null)
            {
                textBoxFocus.SelectAll();
                textBoxFocus.Focus();
            }
        }
    }
}
