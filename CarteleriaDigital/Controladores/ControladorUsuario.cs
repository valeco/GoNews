using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarteleriaDigital.LogicaAccesoDatos;
using CarteleriaDigital.LogicaAccesoDatos.Modelo;

namespace CarteleriaDigital.Controladores
{
    public class ControladorUsuario
    {
        // Usuario logeado
        private Usuario iUsuario;
        private UnidadDeTrabajo iUnidadDeTrabajo = new UnidadDeTrabajo();

        /// <summary>
        ///     Inserta un usuario en el repositorio.
        /// </summary>
        /// <param name="pUsuario">Usuario a insertar.</param>
        public void Insertar(Usuario pUsuario)
        {
            iUnidadDeTrabajo.RepositorioUsuario.Insertar(pUsuario);
            iUnidadDeTrabajo.Guardar();
        }

        /// <summary>
        /// Permite loguear el usurio
        /// </summary>
        /// <param name="pNombreUsuario">nombre de usuario</param>
        /// <param name="pContraseña"></param>
        /// <returns></returns>
        public bool Logear(String pNombreUsuario, String pContraseña)
        {
            var mConsulta = iUnidadDeTrabajo.RepositorioUsuario.Queryable.Where(u => ((u.NombreUsuario == pNombreUsuario) && (u.Contraseña == pContraseña)));
            iUsuario = mConsulta.FirstOrDefault<Usuario>();
            return mConsulta.Count() == 1;
        }

        /// <summary>
        /// Retorna el objeto Usuario logueado actualmente
        /// </summary>
        public Usuario UsuarioLogueado
        {
            get { return iUsuario; }
        }

        /// <summary>
        /// Cierra la session del usuario logueado actualmente
        /// </summary>
        public void LogOut()
        {
            iUsuario = null;
        }

        /// <summary>
        /// Obtiene si existe o no un usuario con este correo
        /// </summary>
        /// <param name="pCorreo">Correo que se desea verificar</param>
        /// <returns></returns>
        public bool ExisteCorreoUsuario(System.Net.Mail.MailAddress pCorreo)
        {
            var mConsulta = iUnidadDeTrabajo.RepositorioUsuario.Queryable.Where(u => (u.Email== pCorreo.Address ));
            return mConsulta.Count() == 1;
        }

        /// <summary>
        /// Obtiene si existe o no un usuario con este nombre de usuario
        /// </summary>
        /// <param name="pCorreo">Correo que se desea verificar</param>
        /// <returns></returns>
        public bool ExisteNombreUsuario(string pNombre)
        {
            var mConsulta = iUnidadDeTrabajo.RepositorioUsuario.Queryable.Where(u => (u.NombreUsuario == pNombre));
            return mConsulta.Count() == 1;
        }
    }
}
