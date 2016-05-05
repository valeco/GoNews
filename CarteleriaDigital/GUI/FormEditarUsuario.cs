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
        BackgroundWorker iWorker = new BackgroundWorker();


        public FormEditarUsuario(EasyLog pLogger)
        {
            InitializeComponent();
            iLogger = pLogger;
            iCtrlUser = ControladorUsuario.Instancia;
            iWorker.DoWork += new DoWorkEventHandler(iWorker_DoWork);
            iWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(iWorker_RunWorkerCompleted);
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
            string mContraNueva = "";

            if (txtNombreCompleto.Text != iCtrlUser.UsuarioLogueado.NombreCompleto)
            {
                if (txtNombreCompleto.Text == "")
                {
                    Utilidades.MensajeError(this, "¡Atención!", "El Nombre Completo no debe estar vacio para ser cambiado");
                    txtNombreCompleto.Text = iCtrlUser.UsuarioLogueado.NombreCompleto;
                }
                else
                {
                    iCtrlUser.UsuarioLogueado.NombreCompleto = txtNombreCompleto.Text;
                    mModificarUsuario = true;
                    Utilidades.MensajeExito(this, "¡Éxito!", "El Nombre Completo se cambio satisfactoriamente");
                }
            }

            if (txtNombreUsuario.Text != iCtrlUser.UsuarioLogueado.NombreUsuario)
            {
                if (txtNombreUsuario.Text == "")
                {
                    Utilidades.MensajeError(this, "¡Atención!", "El campo nombre de usuario no debe estar vacío.");
                    txtNombreUsuario.Text = iCtrlUser.UsuarioLogueado.NombreUsuario;
                }
                else if (!(txtNombreUsuario.Text.Length >= 4 && txtNombreUsuario.Text.Length <= 15))
                {
                    Utilidades.MensajeError(this, "¡Atención!", "El nuevo nombre de usuario debe tener\nuna longitud de 4-15 caracteres.");
                    txtNombreUsuario.Text = iCtrlUser.UsuarioLogueado.NombreUsuario;
                }
                else if (iCtrlUser.ExisteNombreUsuario(txtNombreUsuario.Text))
                {
                    Utilidades.MensajeError(this, "¡Atención!", "El nuevo nombre de usuario ya está en uso.");
                }
                else
                {
                    iCtrlUser.UsuarioLogueado.NombreUsuario = txtNombreUsuario.Text;
                    mModificarUsuario = true;
                    Utilidades.MensajeExito(this, "¡Éxito!", "El nombre de usuario se cambió satisfactoriamente.");
                }
            }

            if (txtEmail.Text != iCtrlUser.UsuarioLogueado.Email.Address)
            {
                if (txtEmail.Text == "")
                {
                    Utilidades.MensajeError(this, "¡Atención!", "El campo email no debe estar vacío.");
                    txtEmail.Text = iCtrlUser.UsuarioLogueado.Email.Address;
                }
                else if (iCtrlUser.ExisteCorreoUsuario(new MailAddress(txtEmail.Text)))
                {
                    Utilidades.MensajeError(this, "¡Atención!", "El email indicado ya tiene un usuario asociado.");
                    txtEmail.Focus();
                }
                else
                {
                    try
                    {
                        MailAddress mEmail = new MailAddress(txtEmail.Text);
                        iCtrlUser.UsuarioLogueado.Email = mEmail;
                        mModificarUsuario = true;
                        Utilidades.MensajeExito(this, "¡Éxito!", "El email se cambió satisfactoriamente.");
                    }
                    catch (FormatException exf)
                    {
                        Utilidades.MensajeError(this, "¡Atención!", "El email no tiene el formato requerido.");
                        iLogger.Debug(exf.Source + " Formato del email no válido -> " + txtEmail.Text);
                        txtEmail.Focus();
                    }
                    catch (Exception ex)
                    {
                        iLogger.Error(ex.Source + ": " + ex.Message);
                        Utilidades.MensajeError(this, "¡Error!", "Sucedió un error inesperado, reintente luego.");
                    }
                }
            }

            if (txtNuevaContraseña.Text != "" && txtNuevaContraseñaRepetir.Text != "")
            {
                if (txtNuevaContraseña.Text != txtNuevaContraseñaRepetir.Text)
                {
                    Utilidades.MensajeError(this, "¡Atención!", "Las contraseñas deben ser iguales.");
                }
                else if (!(txtNuevaContraseña.Text.Length >= 6 && txtNuevaContraseñaRepetir.Text.Length >= 6))
                {
                    Utilidades.MensajeError(this, "¡Atención!", "La contraseña debe tener 6 o más caracteres de longitud.");
                }
                else
                {
                    mContraNueva = txtNuevaContraseña.Text;
                    iCtrlUser.UsuarioLogueado.Contraseña = Utilidades.MD5(txtNuevaContraseña.Text);
                    txtNuevaContraseña.Text = "";
                    txtNuevaContraseñaRepetir.Text = "";
                    mModificarUsuario = true;
                    Utilidades.MensajeExito(this, "¡Éxito!", "La contraseña se modificó satisfactoriamente.");
                }
            }
            else if (txtNuevaContraseña.Text != "" || txtNuevaContraseñaRepetir.Text != "")
            {
                Utilidades.MensajeError(this, "¡Atención!", "Repita la nueva contraseña en los dos campos correspondientes.");
            }

            //Si se modifico el password
            if (mModificarUsuario)
            {
                iCtrlUser.Modificar(iCtrlUser.UsuarioLogueado);
                if (!iWorker.IsBusy)//Se fija si el Worker esta siendo utilizado
                {
                    Dictionary<string, string> dic = new Dictionary<string, string>();
                    dic.Add("nombreCompleto", iCtrlUser.UsuarioLogueado.NombreCompleto);
                    dic.Add("nombreUsuario", iCtrlUser.UsuarioLogueado.NombreUsuario);
                    dic.Add("contraseña", mContraNueva);
                    dic.Add("email", iCtrlUser.UsuarioLogueado.Email.Address);

                    btnCambiar.Text = "ENVIANDO...";
                    btnCambiar.Enabled = false;

                    iWorker.RunWorkerAsync(dic);//Llamando al background worker
                }
            }
        }

        private void iWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Dictionary<string, string> dic = (Dictionary<string, string>)e.Argument;
            Utilidades.EnviarCorreo(new MailAddress(dic["email"]), "Cambio de contraseña - Go News", "<div style = 'padding:20px;font-family: Arial, sans-serif; background-color: #eee;'><div style = 'text-align: center'><img src ='https://raw.githubusercontent.com/valeco/GoNews/master/CarteleriaDigital/Imagenes/_logo.png' alt = 'Logo de GoNews' style = 'width: 150px; height: 150px;'></div><h1 style = 'color: steelblue;'>Cambio de contraseña</h1><p style='color:black;'> Hola <em> "+dic["nombreCompleto"]+"</em>.</p><p style='color:black;'> La contraseña de tu cuenta en GoNews ha sido modificada. Tu nueva contraseña es <strong>" + dic["contraseña"] + "</strong>.</p style='color:black;'><p style='color:black;'>¡Que tengas un buen día!</p></div>", true);
            e.Result = true;
        }

        private void iWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled && e.Error == null && ((bool)e.Result) == true)
            {
                btnCambiar.Enabled = true;
                btnCambiar.Text = "ACTUALIZADO";
                btnCambiar.Enabled = false;
                Utilidades.Esperar(3000);

            }
            else
            {
                //Mensaje de que no se puedo enviar el correo
                Utilidades.MensajeAdvertencia(this, "Error inesperado", "Se actualizo con éxito su contraseña,\n aunque no pudimos enviarle un email notificandole.");
            }
            btnCambiar.Enabled = true;
            btnCambiar.Text = "ACEPTAR";
        }

        private void FormEditarUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            iLogger.Info("Cerrando form Editar Usuario");
            iLogger.Save();
        }
    }
}
