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
using CarteleriaDigital.Controladores;
using CarteleriaDigital.LogicaAccesoDatos.Modelo;

namespace CarteleriaDigital.GUI
{
    public partial class FormAdministrar : Form
    {
        EasyLog iLogger;
        ControladorUsuario iCtrlUser;

        public FormAdministrar( EasyLog pLogger )
        {
            InitializeComponent();
            this.iLogger = pLogger;
            this.iCtrlUser = ControladorUsuario.Instancia;
            iLogger.Info("Inicializando form Administrar");
        }

        private void FormAdministrar_Load(object sender, EventArgs e)
        {
            lbNombreCompleto.Text = iCtrlUser.UsuarioLogueado.NombreCompleto;
            lbEmail.Text = iCtrlUser.UsuarioLogueado.Email.Address;
            iLogger.Info("Load finalizado form Administrar");
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
            var mForm = new FormAgregarModificarCampaña(iLogger, 0);

            mForm.ShowDialog();
        }

        private void btnEliminarCampaña_Click(object sender, EventArgs e)
        {
            iLogger.Info("Inicializando form Solicitar ID campaña");
            var mForm = new FormSolicitarID(iLogger, "campaña", true);

            mForm.ShowDialog();
        }

        private void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            iLogger.Info("Abriendo form Editar User");
            var mForm = new FormEditarUsuario(iLogger);

            mForm.ShowDialog();
            lbNombreCompleto.Text = iCtrlUser.UsuarioLogueado.NombreCompleto;
            lbEmail.Text = iCtrlUser.UsuarioLogueado.Email.Address;
        }

        private void btnAgregarBanner_Click(object sender, EventArgs e)
        {
            iLogger.Info("Abriendo form Agregar Banner");
            var mForm = new FormAgregarModificarBanner(this.iLogger, 0);

            mForm.ShowDialog();
        }

        private void btnEliminarBanner_Click(object sender, EventArgs e)
        {
            iLogger.Info("Abriendo form Solicitar ID Banner");
            var mForm = new FormSolicitarID(iLogger, "banner", true);

            mForm.ShowDialog();
        }

        private void btnModificarCampaña_Click(object sender, EventArgs e)
        {
            iLogger.Info("Abriendo form Solicitar ID CAMPAÑA");
            var mForm = new FormSolicitarID(iLogger, "campaña", false);


            mForm.ShowDialog();
        }

        private void btnModificarBanner_Click(object sender, EventArgs e)
        {
            iLogger.Info("Abriendo form Solicitar ID Banner");
            var mForm = new FormSolicitarID(iLogger, "banner", false);

            mForm.ShowDialog();
        }

        private void btnBuscarCampaña_Click(object sender, EventArgs e)
        {
            iLogger.Info("Abriendo form Buscar CAMPAÑA");
            var mForm = new FormBuscar(iLogger, "campaña");

            mForm.ShowDialog();
        }

        private void btnBuscarBanner_Click(object sender, EventArgs e)
        {
            iLogger.Info("Abriendo form Buscar BANNER");
            var mForm = new FormBuscar(iLogger, "banner");

            mForm.ShowDialog();
        }

        private void btnGestionar_Click(object sender, EventArgs e)
        {
            iLogger.Info("Abriendo form Gestionar RSS");
            var mForm = new FormGestionarRSS( this.iLogger );

            mForm.ShowDialog();
        }

        private void FormAdministrar_FormClosing(object sender, FormClosingEventArgs e)
        {
            iCtrlUser.LogOut();
            iLogger.Info("Cerrando form Administrar");
            iLogger.Save();
        }
    }
}
