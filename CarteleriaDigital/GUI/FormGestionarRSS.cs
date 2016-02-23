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
    public partial class FormGestionarRSS : Form
    {
        public FormGestionarRSS()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Toggle();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Toggle();
        }

        private void pboxMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pboxCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        // REVISAR: AGREGAR EL PARAMETRO DE LA FUENTE RSS
        private void Toggle(String pTitulo = "")
        {
            lbAgregarModificar.Text = pTitulo + " fuente RSS";

            if (!panelAgregar.Visible)
            {
                this.Size = new Size(523, 340);
                panelAgregar.Visible = true;
                btnAgregarRSS.Enabled = false;
                btnModificarRSS.Enabled = false;
                btnEliminarRSS.Enabled = false;
            }
            else
            {
                this.Size = new Size(523, 250);
                panelAgregar.Visible = false;
                txtDescripcion.Text = "";
                txtURL.Text = "";
                btnAgregarRSS.Enabled = true;
                btnModificarRSS.Enabled = true;
                btnEliminarRSS.Enabled = true;
            }
        }

        private void FormGestionarRSS_Load(object sender, EventArgs e)
        {
            Utilidades.AllTextBoxPlaceHolder(this);
            Toggle(); // Para ocultar el panel de agregar/modificar fuentes RSS.
        }

        private void btnAgregarRSS_Click(object sender, EventArgs e)
        {
            Toggle("Agregar");
        }

        private void btnModificarRSS_Click(object sender, EventArgs e)
        {
            Toggle("Modificar");
        }
    }
}
