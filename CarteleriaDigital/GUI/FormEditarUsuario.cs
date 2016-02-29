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
using CarteleriaDigital.LogicaAccesoDatos.Modelo;
using CarteleriaDigital.Controladores;
using System.Net.Mail;

namespace CarteleriaDigital.GUI
{
    public partial class FormEditarUsuario : Form
    {
        EasyLog iLogger;
        ControladorUsuario iCtrlUser;

        public FormEditarUsuario(EasyLog pLogger)
        {
            InitializeComponent();
            iLogger = pLogger;
            iCtrlUser = ControladorUsuario.Instancia;
            iLogger.Info("Inicializando form Editar Usuario");
        }

        private void pboxMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pboxCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormEditarUsuario_Load(object sender, EventArgs e)
        {
            Utilidades.AllTextBoxPlaceHolder(this);
            txtNombreCompleto.Text = iCtrlUser.UsuarioLogueado.NombreCompleto;
            txtNombreUsuario.Text = iCtrlUser.UsuarioLogueado.NombreUsuario;
            txtEmail.Text = iCtrlUser.UsuarioLogueado.Email.Address;
            iLogger.Info("Load finalizado de Form User Edit");
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            bool mModificarUsuario = false;

            if (txtNombreCompleto.Text != iCtrlUser.UsuarioLogueado.NombreCompleto)
            {
                if (txtNombreCompleto.Text == "")
                {
                    Utilidades.MensajeError(this, "ATENCION", "El Nombre Completo no debe estar vacio para ser cambiado");
                    txtNombreCompleto.Text = iCtrlUser.UsuarioLogueado.NombreCompleto;
                }
                else
                {
                    iCtrlUser.UsuarioLogueado.NombreCompleto = txtNombreCompleto.Text;
                    mModificarUsuario = true;
                    Utilidades.MensajeExito(this, "EXITO", "El Nombre Completo se cambio satisfactoriamente");
                }
            }

            if (txtNombreUsuario.Text != iCtrlUser.UsuarioLogueado.NombreUsuario)
            {
                if (txtNombreUsuario.Text == "")
                {
                    Utilidades.MensajeError(this, "ATENCION", "El Nombre de Usuario no debe estar vacio para ser cambiado");
                    txtNombreUsuario.Text = iCtrlUser.UsuarioLogueado.NombreUsuario;
                }
                else if (!(txtNombreUsuario.Text.Length >= 4 && txtNombreUsuario.Text.Length <= 15))
                {
                    Utilidades.MensajeError(this, "ATENCION", "El NUEVO Nombre de Usuario debe tener\nuna longitud de 4-15 caracteres.");
                    txtNombreUsuario.Text = iCtrlUser.UsuarioLogueado.NombreUsuario;
                }
                else if (iCtrlUser.ExisteNombreUsuario(txtNombreUsuario.Text))
                {
                    Utilidades.MensajeError(this, "ATENCION", "El NUEVO Nombre de Usuario ya esta en uso!");
                }
                else
                {
                    iCtrlUser.UsuarioLogueado.NombreUsuario = txtNombreUsuario.Text;
                    mModificarUsuario = true;
                    Utilidades.MensajeExito(this, "EXITO", "El Nombre de Usuario se cambio satisfactoriamente");
                }
            }

            if (txtEmail.Text != iCtrlUser.UsuarioLogueado.Email.Address)
            {
                if (txtEmail.Text == "")
                {
                    Utilidades.MensajeError(this, "ATENCION", "El Email no debe estar vacio para ser cambiado");
                    txtEmail.Text = iCtrlUser.UsuarioLogueado.Email.Address;
                }
                else if (iCtrlUser.ExisteCorreoUsuario(new MailAddress(txtEmail.Text)))
                {
                    Utilidades.MensajeError(this, "ATENCION", "El Email indicado ya tiene un usuario asociado!");
                    txtEmail.Focus();
                }
                else
                {
                    try
                    {
                        MailAddress mEmail = new MailAddress(txtEmail.Text);
                        iCtrlUser.UsuarioLogueado.Email = mEmail;
                        mModificarUsuario = true;
                        Utilidades.MensajeExito(this, "EXITO", "El Email se cambio satisfactoriamente");
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

            if (txtNuevaContraseña.Text != "" && txtNuevaContraseñaRepetir.Text != "")
            {
                if (txtNuevaContraseña.Text != txtNuevaContraseñaRepetir.Text)
                {
                    Utilidades.MensajeError(this, "ATENCION", "La contraseña y su repeticion deben ser iguales");
                }
                else if (!(txtNuevaContraseña.Text.Length >= 6 && txtNuevaContraseñaRepetir.Text.Length >= 6))
                {
                    Utilidades.MensajeError(this, "ATENCION", "La contraseña y su repeticion\ndeben tener 6 o mas caracteres de longitud");
                }
                else
                {
                    iCtrlUser.UsuarioLogueado.Contraseña = Utilidades.MD5(txtNuevaContraseña.Text);
                    txtNuevaContraseña.Text = "";
                    txtNuevaContraseñaRepetir.Text = "";
                    mModificarUsuario = true;
                    Utilidades.MensajeExito(this, "EXITO", "La contraseña se modifico satisfactoriamente");
                }
            }
            else if (txtNuevaContraseña.Text != "" || txtNuevaContraseñaRepetir.Text != "")
            {
                Utilidades.MensajeError(this, "ATENCION", "La contraseña y su repeticion no deben estar vacias para cambiarla");
            }


            if (mModificarUsuario) { iCtrlUser.Modificar(iCtrlUser.UsuarioLogueado); }
        }

        private void FormEditarUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            iLogger.Info("Cerrando form Editar Usuario");
            iLogger.Save();
        }
    }
}
