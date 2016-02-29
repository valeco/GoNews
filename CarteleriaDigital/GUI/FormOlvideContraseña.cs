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
using System.Net.Mail;

namespace CarteleriaDigital.GUI
{
    public partial class FormOlvideContraseña : Form
    {
        EasyLog iLogger;
        ControladorUsuario iCtrlUser;

        public FormOlvideContraseña(EasyLog pLogger)
        {
            InitializeComponent();
            iLogger = pLogger;
            iCtrlUser = ControladorUsuario.Instancia;
            iLogger.Info("Inicializado form Olvido Contraseña");
        }

        private void pboxMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pboxCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormOlvideContraseña_Load(object sender, EventArgs e)
        {
            Utilidades.AllTextBoxPlaceHolder(this);
        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            MailAddress mEmail;

            if (txtNombreUsuario.Text == "")
            {
                Utilidades.MensajeError(this, "ATENCION", "El Nombre Usuario no debe estar vacio");
                txtNombreUsuario.Focus();
            }
            else if (!(txtNombreUsuario.Text.Length >= 4 && txtNombreUsuario.Text.Length <= 15))
            {
                Utilidades.MensajeError(this, "ATENCION", "El Nombre de Usuario debe tener una longitud\nde 4-15 caracteres.");
                txtNombreUsuario.Focus();
            }
            else if (txtEmail.Text == "")
            {
                Utilidades.MensajeError(this, "ATENCION", "El Email no debe estar vacio");
                txtEmail.Focus();
            }
            else
            {
                try
                {
                    mEmail = new MailAddress(txtEmail.Text);

                    if ( ! iCtrlUser.ExisteNombreUsuario(txtNombreUsuario.Text)) // || ! iCtrlUser.ExisteCorreoUsuario(mEmail))
                    {
                        Utilidades.MensajeError(this, "ATENCION", "El Nombre de Usuario o Correo indicado NO existen!");
                        txtNombreUsuario.Focus();
                    }
                    else
                    {
                        iLogger.Info("Comienza recuperacion cuenta de Usuario -> " + txtNombreUsuario.Text);
                        //iCtrlUser.Q
                        Usuario mUser = iCtrlUser.ObtenerPorNombreUsuario(txtNombreUsuario.Text);
                        string mContraseñaNueva = iCtrlUser.ObtenerNuevaContraseña();
                        mUser.Contraseña = Utilidades.MD5(mContraseñaNueva);
                        iCtrlUser.Modificar(mUser);
                        //REVISAR Enviar email con BackgWorker al email del usuario con contraseña nueva
                        Utilidades.MensajeExito(this, "EXITO", "Contraseña nueva generada: " + mContraseñaNueva);
                        this.Close();
                    }

                }
                catch (FormatException exf)
                {
                    Utilidades.MensajeError(this, "ATENCION", "El Email no tiene el formato requerido");
                    iLogger.Debug(exf.Source + " Formato del email no valido -> " + txtEmail.Text);
                    txtEmail.Focus();
                }
                catch (Exception ex)
                {
                    iLogger.Error(ex.Source + ": " + ex.Message);
                    Utilidades.MensajeError(this, "ERROR", "Sucedio un error inesperado, reintente luego la accion.");
                }

            }
        }

        private void FormOlvideContraseña_FormClosing(object sender, FormClosingEventArgs e)
        {
            iLogger.Info("Cerrando form Olvido Contraseña");
            iLogger.Save();
        }
    }
}
