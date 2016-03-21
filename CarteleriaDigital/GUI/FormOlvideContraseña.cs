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
        BackgroundWorker iWorker = new BackgroundWorker();

        public FormOlvideContraseña(EasyLog pLogger)
        {
            InitializeComponent();
            iLogger = pLogger;
            iCtrlUser = ControladorUsuario.Instancia;
            iWorker.DoWork += new DoWorkEventHandler(iWorker_DoWork);
            iWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(iWorker_RunWorkerCompleted);
            iLogger.Info("Inicializado form Olvido Contraseña");
        }

        private void iWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Dictionary<string, string> dic = (Dictionary<string, string>)e.Argument;
            Utilidades.EnviarCorreo(new MailAddress(dic["email"]), "Recuperacion de COntraseña - GO NEWS",
                                    "<b>ACA HTML</b>", true);
            //REVISAR falta html de tablita con buenos colores y los datos
            e.Result = true;
        }

        private void iWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled && e.Error == null && ((bool)e.Result) == true)
            {
                btnRecuperar.Enabled = true;
                btnRecuperar.Text = "Recuperado !";
                btnRecuperar.Enabled = false;
                Utilidades.Esperar(5000);
                this.Close();
            }
            else
            {
                //Mensaje de que no se puedo enviar el correo REVISAR
                this.Close();
            }
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

                    if ( ! iCtrlUser.ExisteNombreUsuario(txtNombreUsuario.Text) || ! iCtrlUser.ExisteCorreoUsuario(mEmail))
                    {
                        Utilidades.MensajeError(this, "ATENCION", "El Nombre de Usuario o Correo indicado NO existen!");
                        txtNombreUsuario.Focus();
                    }
                    else
                    {
                        iLogger.Info("Comienza recuperacion cuenta de Usuario -> " + txtNombreUsuario.Text);

                        Usuario mUser = iCtrlUser.ObtenerPorNombreUsuario(txtNombreUsuario.Text);
                        string mContraseñaNueva = iCtrlUser.ObtenerNuevaContraseña();
                        mUser.Contraseña = Utilidades.MD5(mContraseñaNueva);
                        iCtrlUser.Modificar(mUser);
                       
                        if (!iWorker.IsBusy)//Se fija si el Worker esta siendo utilizado
                        {
                            Dictionary<string, string> dic = new Dictionary<string, string>();
                            dic.Add("nombreCompleto", mUser.NombreCompleto);
                            dic.Add("nombreUsuario", txtNombreUsuario.Text);
                            dic.Add("contraseñaNueva", mContraseñaNueva);
                            dic.Add("email", mEmail.Address);

                            btnRecuperar.Text = "Enviando Email";
                            btnRecuperar.Enabled = false;

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

        private void FormOlvideContraseña_FormClosing(object sender, FormClosingEventArgs e)
        {
            iLogger.Info("Cerrando form Olvido Contraseña");
            iLogger.Save();
        }
    }
}
