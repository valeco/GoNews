using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarteleriaDigital.GUI
{
    public partial class FormAdministrar : Form
    {
        public FormAdministrar()
        {
            InitializeComponent();
        }

        private void pboxMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pboxCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregarCampaña_Click(object sender, EventArgs e)
        {
            var mForm = new FormAgregarModificarCampaña();

            mForm.ShowDialog();
        }

        private void btnEliminarCampaña_Click(object sender, EventArgs e)
        {
            var mForm = new FormSolicitarID("campaña", true);

            mForm.ShowDialog();
        }

        private void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            var mForm = new FormEditarUsuario();

            mForm.ShowDialog();
        }

        private void btnAgregarBanner_Click(object sender, EventArgs e)
        {
            var mForm = new FormAgregarModificarBanner();

            mForm.ShowDialog();
        }

        private void btnEliminarBanner_Click(object sender, EventArgs e)
        {
            var mForm = new FormSolicitarID("banner", true);

            mForm.ShowDialog();
        }

        private void btnModificarCampaña_Click(object sender, EventArgs e)
        {
            var mForm = new FormSolicitarID("campaña", false);

            mForm.ShowDialog();
        }

        private void btnModificarBanner_Click(object sender, EventArgs e)
        {
            var mForm = new FormSolicitarID("banner", false);

            mForm.ShowDialog();
        }

        private void btnBuscarCampaña_Click(object sender, EventArgs e)
        {
            var mForm = new FormBuscar("campaña");

            mForm.ShowDialog();
        }

        private void btnBuscarBanner_Click(object sender, EventArgs e)
        {
            var mForm = new FormBuscar("banner");

            mForm.ShowDialog();
        }

        private void btnGestionar_Click(object sender, EventArgs e)
        {
            var mForm = new FormGestionarRSS();

            mForm.ShowDialog();
        }

        private void FormAdministrar_Load(object sender, EventArgs e)
        {

        }
    }
}
