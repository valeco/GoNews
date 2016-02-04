using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarteleriaDigital.GUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Prueba());
            CarteleriaDigital.LogicaAccesoDatos.UnidadDeTrabajo uow = new CarteleriaDigital.LogicaAccesoDatos.UnidadDeTrabajo();
            CarteleriaDigital.LogicaAccesoDatos.Modelo.Usuario user = new CarteleriaDigital.LogicaAccesoDatos.Modelo.Usuario
            {
                NombreCompleto = "Luciano Thoma",
                NombreUsuario = "luchothoma",
                Email = "luchothoma@gmail.com",
                Contraseña = CarteleriaDigital.Extras.Utilidades.md5("luchothoma"),
                ListaBanner = new List<CarteleriaDigital.LogicaAccesoDatos.Modelo.Banner>(),
                ListaCampaña = new List<CarteleriaDigital.LogicaAccesoDatos.Modelo.Campaña>()
            };
            uow.RepositorioUsuario.Insertar(user);
            uow.Guardar();
        }
    }
}
