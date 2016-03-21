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
    public partial class FormSolicitarID : Form
    {
        bool iEliminar;
        string iTipo;
        EasyLog iLogger;
        ControladorUsuario iCtrlUser = ControladorUsuario.Instancia;

        public FormSolicitarID(EasyLog pLogger, String pTipo, bool pEliminar)
        {
            InitializeComponent();

            iEliminar = pEliminar;
            iTipo = pTipo;
            iLogger = pLogger;
            lbTitulo.Text = (pEliminar ? "Eliminar " : "Modificar ") + pTipo;
            txtId.Text = "ID " + (pTipo == "campaña" ? "de la " : "del ") + pTipo;
            btnConfirmar.Text = (pEliminar ? "ELIMINAR " : "MODIFICAR ");

            iLogger.Info("Inicializacion finalizada form Solicitar ID " + pTipo + " " + (pEliminar ? "Eliminar " : "Modificar "));
        }

        private void pboxMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pboxCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConfirmar_MouseEnter(object sender, EventArgs e)
        {
            if (iEliminar)
            {
                this.BackColor = Color.Firebrick;
                panelID.BackColor = Color.Maroon;
            }
        }

        private void btnConfirmar_MouseLeave(object sender, EventArgs e)
        {
            if (iEliminar)
            {
                this.BackColor = Color.DarkCyan;
                panelID.BackColor = Color.DarkSlateGray;
            }
        }

        private void FormSolicitarID_Load(object sender, EventArgs e)
        {
            Utilidades.AllTextBoxPlaceHolder(this);
            iLogger.Info("Load finalizado form Solicitar ID " + iTipo + " " + (iEliminar ? "Eliminar " : "Modificar "));
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            int mId;

            if (txtId.Text == "")
            {
                Utilidades.MensajeError(this, "¡Error!", "Debes ingresar el ID de " + (iTipo == "campaña" ? "alguna campaña." : "algún banner."));
                txtId.Focus();
            }
            else if (int.TryParse(txtId.Text, out mId) && mId > 0)
            {
                bool mExiste;

                mExiste = iTipo == "campaña" ? (new ControladorCampaña()).ExisteConId(mId) : (new ControladorBanner()).ExisteConId(mId);

                if (mExiste)
                {
                    if (!iEliminar)
                    {
                        var mForm = new FormAgregarModificarBanner(iLogger, mId);
                        this.Visible = false;
                        mForm.ShowDialog();
                        this.Close();
                    }
                    else // Si se va a eliminar.
                    {
                        Publicidad mPublicidad = iTipo == "campaña" ? (Publicidad)(new ControladorCampaña()).ObtenerPorId(mId) : (Publicidad)(new ControladorBanner()).ObtenerPorId(mId);

                        string mMensaje = "¿Está seguro que desea eliminar el siguiente banner?"
                                          + "\nID: " + mPublicidad.Id
                                          + "\nNombre: " + mPublicidad.Nombre;

                        if (Utilidades.MensajeAdvertencia(this, "¡Atención!", mMensaje, false) == DialogResult.OK)
                        {
                            if (iTipo == "campaña")
                                (new ControladorCampaña()).Eliminar((Campaña)mPublicidad);
                            else
                                (new ControladorBanner()).Eliminar((Banner)mPublicidad);

                            this.Close();
                        }
                    }
                }
                else // Si no se encontró ningún banner o campaña con ese ID.
                {
                    Utilidades.MensajeError(this, "¡Error!", "El ID ingresado no corresponde a " + (iTipo == "campaña" ? "ninguna campaña." : "ningún banner" ));
                    txtId.Focus();
                }
            }
            else
            {
                Utilidades.MensajeError(this, "¡Error!", "El ID debe ser un número mayor a cero.");
                txtId.Focus();
            }
        }

        private void FormSolicitarID_FormClosing(object sender, FormClosingEventArgs e)
        {
            iLogger.Info("Cerrando form SolicitarID");
            iLogger.Save();
        }
    }
}
