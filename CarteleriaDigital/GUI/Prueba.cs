using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

using CarteleriaDigital.Extras;

namespace CarteleriaDigital.GUI
{
    public partial class Prueba : Form
    {
        public Prueba()
        {
            InitializeComponent();
        }
        EasyLog log;
        private void Prueba_Load(object sender, EventArgs e)
        {
            log = new EasyLog(Utilidades.RutaPrograma() + "appLog.txt");
            //Utilidades.PlaceHolder(tboxPrueba, "Anda o no!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            log.Write(Utilidades.InputBox<string>("Linea del Log","Nueva linea del log para agregar","Algun texto de error"));           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            log.Save();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CarteleriaDigital.LogicaAccesoDatos.UnidadDeTrabajo uow = new CarteleriaDigital.LogicaAccesoDatos.UnidadDeTrabajo();
            CarteleriaDigital.LogicaAccesoDatos.Modelo.Usuario user = new CarteleriaDigital.LogicaAccesoDatos.Modelo.Usuario
            {
                NombreCompleto = "Luciano Thoma",
                NombreUsuario = "luchothoma",
                Email = "luchothoma@gmail.com",
                Contraseña = CarteleriaDigital.Extras.Utilidades.MD5("luchothoma"),
                ListaBanner = new List<CarteleriaDigital.LogicaAccesoDatos.Modelo.Banner>(),
                ListaCampaña = new List<CarteleriaDigital.LogicaAccesoDatos.Modelo.Campaña>()
            };
            uow.RepositorioUsuario.Insertar(user);
            uow.Guardar();
        }
    }
}
