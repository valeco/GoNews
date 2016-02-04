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

        public bool Logear(String pNombreUsuario, String pContraseña)
        {
            var mConsulta = iUnidadDeTrabajo.RepositorioUsuario.Queryable.Where(u => ((u.NombreUsuario == pNombreUsuario) && (u.Contraseña == pContraseña)));
            iUsuario = mConsulta.FirstOrDefault<Usuario>();
            return mConsulta.Count() == 1;
        }
    }
}
