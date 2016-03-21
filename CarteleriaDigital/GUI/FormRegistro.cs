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
    public partial class FormRegistro : Form
    {
        EasyLog iLogger;
        ControladorUsuario iCtrlUser;
        BackgroundWorker iWorker = new BackgroundWorker();

        public FormRegistro(EasyLog pLogger)
        {
            InitializeComponent();
            iLogger = pLogger;
            iCtrlUser = ControladorUsuario.Instancia;
            iWorker.DoWork += new DoWorkEventHandler(iWorker_DoWork);
            iWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(iWorker_RunWorkerCompleted);
            iLogger.Info("Inicializado form Registro Usuario");
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
            if( !e.Cancelled && e.Error == null && ((bool) e.Result) == true)
            {
                btnRegistrar.Enabled = true;
                btnRegistrar.Text = "Reg. Completo";
                btnRegistrar.Enabled = false;
                Utilidades.Esperar(5000);
                this.Close();
            }
            else
            {
                //Mensaje de que no se puedo enviar el correo REVISAR
            }
        }


        private void pboxCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pboxMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FormRegistro_Load(object sender, EventArgs e)
        {
            Utilidades.AllTextBoxPlaceHolder(this);
        }


        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            MailAddress mEmail;

            if (txtNombreCompleto.Text=="")
            {
                Utilidades.MensajeError(this, "ATENCION", "El Nombre Completo no debe estar vacio");
                txtNombreCompleto.Focus();
            }
            else if (txtNombreUsuario.Text == "")
            {
                Utilidades.MensajeError(this, "ATENCION", "El Nombre de Usuario no debe estar vacio");
                txtNombreUsuario.Focus();
            }
            else if (! (txtNombreUsuario.Text.Length >= 4 && txtNombreUsuario.Text.Length <= 15))
            {
                Utilidades.MensajeError(this, "ATENCION", "El Nombre de Usuario debe tener una longitud\nde 4-15 caracteres.");
                txtNombreUsuario.Focus();
            }
            else if (txtContraseña.Text == "")
            {
                Utilidades.MensajeError(this, "ATENCION", "La Contraseña no debe estar vacia");
                txtContraseña.Focus();
            }
            else if (! (txtContraseña.Text.Length >= 6) )
            {
                Utilidades.MensajeError(this, "ATENCION", "La contraseña debe tener una longitud de 6 o más caracteres.");
                txtContraseña.Focus();
            }
            else if (txtRepetirContraseña.Text == "")
            {
                Utilidades.MensajeError(this, "ATENCION", "La Contraseña Repetida no debe estar vacia");
                txtContraseña.Focus();
            }
            else if (txtRepetirContraseña.Text != txtContraseña.Text)
            {
                Utilidades.MensajeError(this, "ATENCION", "Las contraseñas no coinciden");
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

                    if (iCtrlUser.ExisteNombreUsuario(txtNombreUsuario.Text))
                    {
                        Utilidades.MensajeError(this, "ATENCION", "El Nombre de Usuario indicado ya existe!");
                        txtNombreUsuario.Focus();
                    }
                    if (iCtrlUser.ExisteCorreoUsuario(mEmail))
                    {
                        Utilidades.MensajeError(this, "ATENCION", "El Email indicado ya tiene un usuario asociado!");
                        txtEmail.Focus();
                    }
                    else
                    {
                        iLogger.Info("Comienza insercion Usuario");
                        iCtrlUser.Insertar(new Usuario  {
                                                        NombreCompleto = txtNombreCompleto.Text,
                                                        NombreUsuario = txtNombreUsuario.Text,
                                                        Contraseña = Utilidades.MD5(txtContraseña.Text),
                                                        Email = mEmail
                                                        }
                                            );
                        //REVISAR Enviar email con BackgWorker al email del usuario
                        //http://www.codeproject.com/Articles/841751/MultiThreading-Using-a-Background-Worker-Csharp

                        if (! iWorker.IsBusy)//Se fija si el Worker esta siendo utilizado
                        {
                            Dictionary<string, string> dic = new Dictionary<string, string>();
                            dic.Add("nombreCompleto", txtNombreCompleto.Text);
                            dic.Add("nombreUsuario", txtNombreUsuario.Text);
                            dic.Add("contraseña", txtContraseña.Text);
                            dic.Add("email", mEmail.Address);

                            btnRegistrar.Text = "Enviando Email";
                            btnRegistrar.Enabled = false;

                            iWorker.RunWorkerAsync(dic);//Llamando al background worker
                        }

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

        private void FormRegistro_FormClosing(object sender, FormClosingEventArgs e)
        {
            iLogger.Info("Cerrando form Registro Usuario");
            iLogger.Save();
        }
    }
}
