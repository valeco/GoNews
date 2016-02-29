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
        #region Patron_Singleton
        private static ControladorUsuario iInstancia;

        private ControladorUsuario() { }

        /// <summary>
        /// Obtiene la instancia del controlador (Singleton)
        /// </summary>
        public static ControladorUsuario Instancia
        {
            get
            {
                if (iInstancia == null)
                    iInstancia = new ControladorUsuario();
                return iInstancia;
            }
        }
        #endregion

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
        ///     Modificar un usuario en el repositorio.
        /// </summary>
        /// <param name="pUsuario">Usuario a actualizar</param>
        public void Modificar(Usuario pUsuario)
        {
            iUnidadDeTrabajo.RepositorioUsuario.Modificar(pUsuario);
            iUnidadDeTrabajo.Guardar();
        }

        /// <summary>
        ///     Eliminar un usuario en el repositorio.
        /// </summary>
        /// <param name="pUsuario">Usuario para borrar</param>
        public void Eliminar(Usuario pUsuario)
        {
            iUnidadDeTrabajo.RepositorioUsuario.Eliminar(pUsuario);
            iUnidadDeTrabajo.Guardar();
        }

        /// <summary>
        /// Permite loguear el usurio
        /// </summary>
        /// <param name="pNombreUsuario">nombre de usuario</param>
        /// <param name="pContraseña"></param>
        /// <returns>Valor de verdad respecto al exito del log in</returns>
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
        /// Obtiene un usuario a partir de un Nombre de Usuario
        /// </summary>
        /// <param name="pNombre"></param>
        /// <returns>Usuario o nulo</returns>
        public Usuario ObtenerPorNombreUsuario(string pNombre)
        {
            var mConsulta = iUnidadDeTrabajo.RepositorioUsuario.Queryable.Where(u => (u.NombreUsuario == pNombre));
            return (mConsulta.Count() == 0 ? null : mConsulta.First<Usuario>());
        }

        /// <summary>
        /// Obtiene si existe o no un usuario con este nombre de usuario
        /// </summary>
        /// <param name="pNombre">Nombre de Usuario que se desea verificar</param>
        /// <returns>Valor de verdad respecto a la existencia</returns>
        public bool ExisteNombreUsuario(string pNombre)
        {
            return !(this.ObtenerPorNombreUsuario(pNombre) == null);
        }

        /// <summary>
        /// Obtiene si existe o no un usuario con este correo
        /// </summary>
        /// <param name="pCorreo">Correo que se desea verificar</param>
        /// <returns>Valor de verdad respecto a la existencia</returns>
        public bool ExisteCorreoUsuario(System.Net.Mail.MailAddress pCorreo)
        {
            var mConsulta = iUnidadDeTrabajo.RepositorioUsuario.Queryable.Where(u => (u.EmailTexto == pCorreo.Address));
            return mConsulta.Count() == 1;
        }

        /// <summary>
        /// Genera una nueva contraseña aleatoria
        /// </summary>
        /// <returns>Nueva contraseña</returns>
        public string ObtenerNuevaContraseña()
        {
            Random mRand = new Random();
            string mNueva = "";

            for (int i = 0; i < 6; i++) //Longitud de 6 caracteres por ser la longitud minima
            {
                //48-57 Digitos 65-90 Letras
                int mNumOletra = mRand.Next(0, 100);
                int mMinOmay = mRand.Next(0, 100);
                string mLetra = ((char)(mNumOletra > 50 ? mRand.Next(48, 57) : mRand.Next(65, 90))).ToString();
                mNueva += (mMinOmay > 50 ? mLetra.ToLower() : mLetra.ToUpper());
            }
            return mNueva;
        }
    }
}