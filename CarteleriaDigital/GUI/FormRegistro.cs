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
    public partial class FormRegistro : Form
    {
        public FormRegistro()
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

        private void FormRegistro_Load(object sender, EventArgs e)
        {
            Utilidades.AllTextBoxPlaceHolder(this);
        }


        private void btnRegistrar_Click(object sender, EventArgs e)
        {

        }
    }
}
