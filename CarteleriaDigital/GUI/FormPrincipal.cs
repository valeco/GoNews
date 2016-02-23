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

namespace CarteleriaDigital.GUI
{
    public partial class FormPrincipal : Form
    {
        EasyLog iLogger = new EasyLog("appLog.txt", true); //Modo Debug activo

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            Utilidades.AllTextBoxPlaceHolder(this);
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
            var mForm = new FormRegistro();
            
            mForm.ShowDialog();
        }
        
        private void lbOlvideContraseña_Click(object sender, EventArgs e)
        {
            var mForm = new FormOlvideContraseña();

            mForm.ShowDialog();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            iLogger.Info("Abriendo form Administrar");
            var mForm = new FormAdministrar( this.iLogger );

            this.pboxLogin_Click(null, null);

            mForm.ShowDialog();
        }
    }
}
