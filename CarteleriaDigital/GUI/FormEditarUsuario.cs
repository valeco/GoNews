﻿using System;
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
    public partial class FormEditarUsuario : Form
    {
        public FormEditarUsuario()
        {
            InitializeComponent();
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
        }
    }
}