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
    public partial class FormSolicitarID : Form
    {
        private bool iEliminar;

        public FormSolicitarID(String pTipo, bool pEliminar)
        {
            InitializeComponent();

            this.iEliminar = pEliminar;

            lbTitulo.Text = (pEliminar ? "Eliminar " : "Modificar ") + pTipo;
            txtId.Text = "ID " + (pTipo == "campaña" ? "de la " : "del ") + pTipo;
            btnConfirmar.Text = (pEliminar ? "ELIMINAR " : "MODIFICAR ");
        }

        private void pboxMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pboxCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEliminar_MouseEnter(object sender, EventArgs e)
        {
            if (iEliminar)
            {
                this.BackColor = Color.Firebrick;
                panelID.BackColor = Color.Maroon;
            }
        }

        private void btnEliminar_MouseLeave(object sender, EventArgs e)
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
        }
    }
}
