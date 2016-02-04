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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            log.Write("asd" + DateTime.Now.Ticks.ToString());
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            log.Save();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string l= Utilidades.InputBox<String>("Titulo", "Contenido", "0.8").ToString();
            MessageBox.Show(new Uri(l).ToString());
        }
    }
}
