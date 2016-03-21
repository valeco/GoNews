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
            /*
                REVISAR. No conviene mostrarle sólo un mensaje de éxito al final en vez de uno por text box?
                Si edita todos los text box, el usuario va tener que aceptar 4 message box. xD
            */

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
                    mContraNueva = txtNuevaContraseña.Text;
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

                    btnCambiar.Text = "Enviando Email";
                    btnCambiar.Enabled = false;

                    iWorker.RunWorkerAsync(dic);//Llamando al background worker
                }
            }
        }

        private void iWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Dictionary<string, string> dic = (Dictionary<string, string>)e.Argument;
            Utilidades.EnviarCorreo(new MailAddress(dic["email"]), "Registro de Usuario - GO NEWS",
                                    "<b>ACA HTML</b>", true);
            //REVISAR falta html de tablita con buenos colores y los datos
            e.Result = true;
        }

        private void iWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled && e.Error == null && ((bool)e.Result) == true)
            {
                btnCambiar.Enabled = true;
                btnCambiar.Text = "Actualizado";
                btnCambiar.Enabled = false;
                Utilidades.Esperar(3000);
                btnCambiar.Enabled = true;
                btnCambiar.Text = "ACEPTAR";
            }
            else
            {
                //Mensaje de que no se puedo enviar el correo REVISAR
            }
        }

        private void FormEditarUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            iLogger.Info("Cerrando form Editar Usuario");
            iLogger.Save();
        }
    }
}
