using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarteleriaDigital.Extras;

namespace CarteleriaDigital.GUI
{
    public partial class FormAgregarModificarBanner : Form
    {
        public FormAgregarModificarBanner()
        {
            InitializeComponent();
        }

        private void pboxCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pboxMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void HabilitarCampo()
        {
            if (radioTextoFijo.Checked)
            {
                radioTextoFijo.ForeColor = Color.White;
                radioFuenteRSS.ForeColor = Color.Gainsboro;
                txtTextoFijo.Enabled = true;
                comboFuenteRSS.Enabled = false;
               
            }
            else if (radioFuenteRSS.Checked)
            {
                radioTextoFijo.ForeColor = Color.Gainsboro;
                radioFuenteRSS.ForeColor = Color.White;
                txtTextoFijo.Enabled = false;
                comboFuenteRSS.Enabled = true;
            }
        }

        private void radioTextoFijo_CheckedChanged(object sender, EventArgs e)
        {
            HabilitarCampo();
        }

        private void radioFuenteRSS_CheckedChanged(object sender, EventArgs e)
        {
            HabilitarCampo();
        }

        private void FormAgregarModificarBanner_Load(object sender, EventArgs e)
        {
            Utilidades.AllTextBoxPlaceHolder(this);
            radioTextoFijo.Checked = true;
        }

        private void tbarIntervalo_Scroll(object sender, EventArgs e)
        {
            lbValorIntervalo.Text = tbarIntervalo.Value.ToString() + " seg.";
        }
    }
}
