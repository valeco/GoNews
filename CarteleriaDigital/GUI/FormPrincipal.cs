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
    public partial class FormPrincipal : Form
    {
        EasyLog iLogger;
        ControladorUsuario iCtrlUser;
        ControladorOperativo iCtrlOperativo = new ControladorOperativo();
        Campaña iCampaña = null;
        Banner iBanner = null;
        TimeSpan iMostrarBanner = default(TimeSpan);

        public FormPrincipal()
        {
            InitializeComponent();
            iLogger = new EasyLog(Utilidades.RutaPrograma() + "appLog.txt", true); //Modo Debug activo, cuando pase a prod. desactivar
            iCtrlUser = ControladorUsuario.Instancia;
            iLogger.Info("Inicializacion finalizada form Principal");
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            Utilidades.AllTextBoxPlaceHolder(this);
            //Si existe el archivo hay imagenes que eliminar
            string mRuta = Utilidades.RutaPrograma() + "ImgParaBorrar.INF";
            if ( Microsoft.VisualBasic.FileIO.FileSystem.FileExists(mRuta) )
            {
                ControladorImagen mCtrlImg = new ControladorImagen();
                LecturaArchivoTexto archivo = new LecturaArchivoTexto( mRuta );
                archivo.Abrir();
                List<string> mListaImgABorrar = new List<string>();

                string mLinea = archivo.ProximaLinea();
                do {
                    mListaImgABorrar.Add(mLinea);
                    mLinea = archivo.ProximaLinea();
                } while (mLinea != null) ;
                archivo.Cerrar();
                mListaImgABorrar.Add(mRuta);
                Utilidades.EliminarArchivos(mListaImgABorrar);
            }

            this.IniciarAnimacion();
            iLogger.Info("Load finalizado form Principal");
        }

        private void pboxCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pboxMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

            //Ocultar botones Minimizar y Cerrar
            pboxCerrar.Visible = false;
            pboxMinimizar.Visible = false;

        }

        private void lbRegistrar_Click(object sender, EventArgs e)
        {
            iLogger.Info("Abriendo form Registro Usuario");
            var mForm = new FormRegistro(iLogger);
            
            mForm.ShowDialog();
        }
        
        private void lbOlvideContraseña_Click(object sender, EventArgs e)
        {
            iLogger.Info("Abriendo form Olvide Contraseña Usuario");
            var mForm = new FormOlvideContraseña(iLogger);

            mForm.ShowDialog();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            btnEntrar.Enabled = false;
            if (txtUsuario.Text == "" || txtContraseña.Text == "")
            {
                Utilidades.MensajeError(this,"¡Atención!", "Ni el usuario, ni la contraseña deben estar vacios");
            }
            else if( ! iCtrlUser.Logear(txtUsuario.Text, Utilidades.MD5(txtContraseña.Text)) )
            {
                Utilidades.MensajeError(this, "¡Atención!", "Usuario o contraseña incorrectos");
            }
            else//Usuario logueado con exito
            {
                this.PararAnimacion();
                pboxSlide.SizeMode = PictureBoxSizeMode.StretchImage;
                pboxSlide.Image = iCtrlOperativo.ObtenerCampaña(default(DateTime)).ProximaImagen();
                iLogger.Info("Abriendo form Administrar");
                var mForm = new FormAdministrar(this.iLogger);

                panelLogin.Visible = false;
                mForm.ShowDialog();

                //Para actualizar la campaña y banner a mostrar por si hubo cambios
                iCampaña = null;
                iBanner = null;
                iMostrarBanner = default(TimeSpan);
                this.IniciarAnimacion();
                txtUsuario.Text = "";
                txtContraseña.Text = "";
            }
            btnEntrar.Enabled = true;

        }

        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            iLogger.Info("Cerrando form Principal");
            iLogger.Save();
        }

        private void timerCampaña_Tick(object sender, EventArgs e)
        {
            timerCampaña.Stop();
            int mIntevaloEnMseg = 0;//Intervalo en milisegundos de espera para el timer
            DateTime mAhora = DateTime.Now;

            if (iCampaña == null || mAhora.TimeOfDay > iCampaña.HoraFin)
            {
                iCampaña = iCtrlOperativo.ObtenerCampaña(mAhora);
            }

            TimeSpan duracion = mAhora.AddSeconds( Convert.ToDouble(iCampaña.IntervaloEnSeg) ).TimeOfDay;

            //Quiere decir que hasta que finalice el timepo de la campaña, cabe entero almenos 1 de sus intervalos
            // Y que se trata de una que posee mas de 1 imagen (x eso Intervalo > 0)
            if (duracion <= iCampaña.HoraFin && iCampaña.Intervalo > 0)
                mIntevaloEnMseg = iCampaña.Intervalo;
            else
            //Entre el tiempo actual y de fin, de la misma NO cabe otro de sus intervalos O QUE
            //Es una campaña de una SOLA imagen y debe calcularse el tiempo de espera
                mIntevaloEnMseg = (int) Math.Floor( iCampaña.HoraFin.Subtract(mAhora.TimeOfDay).TotalMilliseconds );

            timerCampaña.Interval = mIntevaloEnMseg;
            Utilidades.AnimacionSlider(pboxSlide, iCampaña.ProximaImagen());
            timerCampaña.Start();
        }

        private void timerBanner_Tick(object sender, EventArgs e)
        {
            timerBanner.Stop();
            DateTime mAhora = DateTime.Now;

            if (iBanner == null || mAhora.TimeOfDay > iBanner.HoraFin)
            {
                iBanner = iCtrlOperativo.ObtenerBanner(mAhora);
            }

            //Si corresponde, cambiar el texto a mostrar
            if (mAhora.TimeOfDay > iMostrarBanner)
            {
                TimeSpan duracion = mAhora.AddSeconds(Convert.ToDouble(iBanner.IntervaloEnSeg)).TimeOfDay;
                //Utilidades.MensajeAdvertencia(this, "", duracion.ToString());
                //Quiere decir que hasta que finalice el timepo del banner, cabe entero almenos 1 de sus intervalos
                // Y que se trata de uno que posee mas de 1 texto (x eso Intervalo > 0)
                if (duracion <= iBanner.HoraFin && iBanner.Intervalo > 0)
                    iMostrarBanner = duracion;
                else
                    iMostrarBanner = iBanner.HoraFin;
                
                lbMarquesina.Location = new Point(this.Width, lbMarquesina.Location.Y);
                lbMarquesina.Text = iBanner.ProximoTexto();                              
            }

            Utilidades.Marquesina(this, this.lbMarquesina,16);
            timerBanner.Start();
        }

        private void PararAnimacion() { timerBanner.Stop(); timerCampaña.Stop(); }
        private void IniciarAnimacion()
        {
            timerBanner.Start();
            timerCampaña.Interval = 10;
            timerCampaña.Start();
        }

        private void pboxSlide_MouseMove(object sender, MouseEventArgs e)
        {
            //Para mostrar/ocultar botones de Cerrar y Minimizar
            if (pboxSlide.Width - e.X <= 150 && e.Y <= 60)
            {
                pboxCerrar.Visible = true;
                pboxMinimizar.Visible = true;
            }
            else
            {
                pboxCerrar.Visible = false;
                pboxMinimizar.Visible = false;
            }

            //Para mostrar/ocultar boton de Login
            if (pboxSlide.Width - e.X <= 200 && pboxSlide.Height - e.Y <= 200)
            {
                panelLogin.Visible = true;
            }
            else
            {
                panelLogin.Visible = false;
            }
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter || e.KeyValue == (char)Keys.Tab)
            {
                txtContraseña.Focus();
            }
        }

        private void txtContraseña_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter || e.KeyValue == (char)Keys.Tab)
            {
                this.btnEntrar_Click(null, null);
            }
        }
    }
}
