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

using System.ComponentModel.DataAnnotations;

namespace CarteleriaDigital.GUI
{
    public partial class FormGestionarRSS : Form
    {
        EasyLog iLogger;
        ControladorBannerRSS iCtrlRSS = new ControladorBannerRSS();
        BannerRSS iBRss;
        bool iEventoAgregar;

        public FormGestionarRSS( EasyLog pLogger)
        {
            InitializeComponent();
            this.iLogger = pLogger;
            iLogger.Info("Inicializando form Gertion RSS");
        }

        private void FormGestionarRSS_Load(object sender, EventArgs e)
        {
            Utilidades.AllTextBoxPlaceHolder(this);
            Toggle(); // Para ocultar el panel de agregar/modificar fuentes RSS.

            //Configurando grilla
            dgridFuentesRSS.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dgridFuentesRSS.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;
            dgridFuentesRSS.DataSource = iCtrlRSS.ObtenerTodos();
            dgridFuentesRSS.Columns["URLtexto"].Visible = false;

            iLogger.Info("Load finalizado de form Gestionar RSS");
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Uri mUrl;
            bool mUrlValido = Uri.TryCreate(txtURL.Text, UriKind.Absolute, out mUrl);

            if (txtDescripcion.Text == "")
            {
                Utilidades.MensajeError(this, "¡Atención!", "La descripcion no debe estar vacia");
                txtDescripcion.Focus();
            }
            else if (txtURL.Text == "")
            {
                Utilidades.MensajeError(this, "¡Atención!", "El URL no debe estar vacio");
                txtURL.Focus();
            }
            else if (!mUrlValido)
            {
                Utilidades.MensajeError(this, "¡Atención!", "El URL debe tener un formato valido");
                txtURL.Focus();
            }
            else if ( (iEventoAgregar && iCtrlRSS.ExisteUrl(mUrl)) || (!iEventoAgregar && iBRss.URL != mUrl && iCtrlRSS.ExisteUrl(mUrl)) )
            {
                Utilidades.MensajeError(this, "¡Atención!", "El URL indicado ya esta siendo usado");
                string mBusquedaAnterior = txtBuscar.Text;
                txtBuscar.Text = mUrl.AbsoluteUri;
                btnBuscar_Click(null, null);
                txtBuscar.Text = mBusquedaAnterior;
            }
            else
            {
                try
                {
                    if (RSS.RSS.Feed(mUrl).Count() == 0)
                    {
                        Utilidades.MensajeError(this, "¡Atención!", "El el url indicado NO devuelve informacion");
                        txtURL.Focus();
                    }
                    else
                    {
                        iLogger.Info("Comienza " + (iEventoAgregar ? "insercion" : "modificacion") + " RSS");
                        iBRss.Descripcion = txtDescripcion.Text;
                        iBRss.URL = mUrl;
                        if (iEventoAgregar)//Agregar RSS
                            iCtrlRSS.Insertar(iBRss);
                        else//Modificar RSS
                            iCtrlRSS.Modificar(iBRss);
                        btnBuscar_Click(null, null);
                        Toggle();//Ocultamos panel
                        iLogger.Info("Finaliza " + (iEventoAgregar ? "insercion" : "modificacion") + " RSS");
                        Utilidades.MensajeExito(this, "¡Perfecto!", "Banner " + (iEventoAgregar ? "insertado" : "modificado") + " correctamente.");
                    }
                }
                catch (NotInternetAvailable ex)
                {
                    iLogger.Debug(mUrl.AbsolutePath + " " + ex.Message);
                    Utilidades.MensajeAdvertencia(this, "¡Atención!", "No es posible verificar que el url indicado devuelve informacion,\nal NO tener acceso a Internet.");
                }
                catch (System.Xml.XmlException exXML)
                {
                    iLogger.Debug(mUrl.AbsolutePath + " " + exXML.Message);
                    Utilidades.MensajeAdvertencia(this, "¡Atención!", "El url brindado no devuelve informacion en el formato esperado (XML).");
                }
                catch (Exception ex)
                {
                    if (ex.Source == "System" && ex.Message == "The remote server returned an error: (404) Not Found.")
                    {
                        iLogger.Debug(mUrl.AbsolutePath + " " + ex.Message);
                        Utilidades.MensajeAdvertencia(this, "¡Atención!", "El url brindado no existe.");
                    }
                    else
                    {
                        iLogger.Error(ex.Source + ": " + ex.Message);
                        Utilidades.MensajeError(this, "¡Error!", "Sucedió algo inesperado, reintente luego la acción.");
                    }
                }
            }
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

        /// <summary>
        /// Muestra/Oculta panel de insercion-modificacion de BannerRSS
        /// </summary>
        /// <param name="pTitulo">Titulo del panel</param>
        /// <param name="pBRss">Objeto para agregar o modificar</param>
        private void Toggle(String pTitulo = "", BannerRSS pBRss = null)
        {       
            if (!panelAgregar.Visible)
            {
                lbAgregarModificar.Text = pTitulo + " fuente RSS";
                this.Size = new Size(523, 340);
                panelAgregar.Visible = true;
                btnAgregarRSS.Enabled = false;
                btnModificarRSS.Enabled = false;
                btnEliminarRSS.Enabled = false;
                this.iBRss = pBRss;
                txtDescripcion.Text = pBRss.Descripcion;
                txtURL.Text = (pBRss.URL==null ? "": pBRss.URL.AbsoluteUri.ToString() );
                panelAgregar.Focus();
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
            this.iEventoAgregar = true;//Indica que se desea agregar
            Toggle("Agregar",new BannerRSS());
        }

        private void btnModificarRSS_Click(object sender, EventArgs e)
        {
            if (dgridFuentesRSS.SelectedRows.Count != 0)
            {
                iLogger.Info("Inicia modificacion RSS");
                this.iEventoAgregar = false;//Indica que se desea modificar
                Toggle("Modificar", (BannerRSS)dgridFuentesRSS.SelectedRows[0].DataBoundItem);
            }
        }

        private void btnEliminarRSS_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgridFuentesRSS.SelectedRows.Count != 0)
                {
                    iBRss = (BannerRSS)dgridFuentesRSS.SelectedRows[0].DataBoundItem;
                    if (Utilidades.MensajeAdvertencia(this, "ELIMINAR FUENTE RSS", "¿ Desea eliminar la fuente: \n" + iBRss.Descripcion + " -> " +
                                                        iBRss.URL.AbsoluteUri + " ?", false) == DialogResult.OK)
                    {
                        iLogger.Info("Inicia borrado RSS");
                        iCtrlRSS.Eliminar(iBRss);
                        this.btnBuscar_Click(null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                iLogger.Error(ex.Source + ": " + ex.Message);
                Utilidades.MensajeError(this, "¡Error!", "Sucedio un error inesperado, reintente luego la accion.");
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
                    mConsulta = iCtrlRSS.ObtenerPorSimilitudDescripcionOUrl(mParametro); 
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
                Utilidades.MensajeError(this, "¡Error!", "Sucedio un error inesperado, reintente luego la accion.");
            }           
        }

        private void FormGestionarRSS_FormClosing(object sender, FormClosingEventArgs e)
        {
            iLogger.Info("Cerrando form Gestionar RSS");
            iLogger.Save();
        }
    }
}
