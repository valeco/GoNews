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

namespace CarteleriaDigital.GUI
{
    public partial class FormPrincipal : Form
    {
        EasyLog iLogger;
        ControladorUsuario iCtrlUser;

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
            iLogger.Info("Load finalizado form Principal");
        }

        private void pboxCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pboxLogin_Click(object sender, EventArgs e)
        {
            if (panelLogin.Location.X == this.Size.Width)
            {
                pboxLogin.Location = new System.Drawing.Point(this.Size.Width - panelLogin.Size.Width - pboxLogin.Size.Width, pboxLogin.Location.Y);
                panelLogin.Location = new System.Drawing.Point(this.Size.Width - panelLogin.Size.Width, panelLogin.Location.Y);
            }
            else
            {
                pboxLogin.Location = new System.Drawing.Point(this.Size.Width - pboxLogin.Size.Width, pboxLogin.Location.Y);
                panelLogin.Location = new System.Drawing.Point(this.Size.Width, panelLogin.Location.Y);
            }
        }

        private void pboxMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
            if (txtUsuario.Text == "" || txtContraseña.Text == "")
            {
                Utilidades.MensajeError(this,"ATENCION", "Ni el usuario, ni la contraseña deben estar vacios");
            }
            else if( ! iCtrlUser.Logear(txtUsuario.Text, Utilidades.MD5(txtContraseña.Text)) )
            {
                Utilidades.MensajeError(this, "ATENCION", "Usuario o contraseña incorrectos");
            }
            else//Usuario logueado con exito
            {
                iLogger.Info("Abriendo form Administrar");
                var mForm = new FormAdministrar(this.iLogger);

                this.pboxLogin_Click(null, null);

                mForm.ShowDialog();
            }
        }

        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            iLogger.Info("Cerrando form Principal");
            iLogger.Save();
        }
    }
}
