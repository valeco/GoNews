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
    public partial class FormGestionarRSS : Form
    {
        EasyLog iLogger;
        ControladorBannerRSS iCtrlRSS = new ControladorBannerRSS();
        BannerRSS iBRss;

        public FormGestionarRSS( EasyLog pLogger)
        {
            InitializeComponent();
            this.iLogger = pLogger;
            iLogger.Info("Inicializando form GertionRSS");
        }

        private void FormGestionarRSS_Load(object sender, EventArgs e)
        {
            Utilidades.AllTextBoxPlaceHolder(this);
            Toggle(); // Para ocultar el panel de agregar/modificar fuentes RSS.
            dgridFuentesRSS.DataSource = iCtrlRSS.ObtenerTodos();
            iLogger.Info("Load finalizado de form Gestionar RSS");
        }

        private void btnAceptar_Click(object sender, EventArgs e)
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
        private void Toggle(String pTitulo = "", BannerRSS pBRss)
        {
            lbAgregarModificar.Text = pTitulo + " fuente RSS";

            if (!panelAgregar.Visible)
            {
                this.Size = new Size(523, 340);
                panelAgregar.Visible = true;
                btnAgregarRSS.Enabled = false;
                btnModificarRSS.Enabled = false;
                btnEliminarRSS.Enabled = false;
                this.iBRss = pBRss;
                if(pBRss != null)
                {

                }
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

        private void btnAgregarRSS_Click(object sender, EventArgs e)
        {
            iLogger.Info("Inicia insercion RSS");
            Toggle("Agregar");
        }

        private void btnModificarRSS_Click(object sender, EventArgs e)
        {
            if (dgridFuentesRSS.SelectedRows.Count != 0)
            {
                iLogger.Info("Inicia modificacion RSS");
                Toggle("Modificar",(BannerRSS)dgridFuentesRSS.SelectedRows[0].DataBoundItem);
                //dgridFuentesRSS.SelectedRows[0].DataBoundItem;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                iLogger.Info("Busqueda de RSS iniciada");
                string mParametro = txtBuscar.Text;
                List<BannerRSS> mConsulta;
                if (mParametro != "")
                {
                    mConsulta = iCtrlRSS.Queryable.Where(brss => (brss.Descripcion.Contains(mParametro) || brss.URL.AbsoluteUri.Contains(mParametro))).ToList<BannerRSS>();
                }
                else
                {
                    mConsulta = iCtrlRSS.ObtenerTodos();
                }
                iLogger.Debug("Fuentes RSS filtradas " + mConsulta.Count().ToString());
                dgridFuentesRSS.DataSource = mConsulta;
            }
            catch (Exception ex)
            {
                iLogger.Error(ex.Source + ": " + ex.Message);
            }
           
        }

    }
}
