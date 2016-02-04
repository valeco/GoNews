using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarteleriaDigital.LogicaAccesoDatos;
using CarteleriaDigital.LogicaAccesoDatos.Modelo;

namespace CarteleriaDigital.Controladores
{
    public class ControladorBanner
    {
        private UnidadDeTrabajo iUnidadDeTrabajo = new UnidadDeTrabajo();

        /// <summary>
        ///     Inserta un banner en el repositorio.
        /// </summary>
        /// <param name="pBanner">Banner a insertar.</param>
        public void Insertar(Banner pBanner)
        {
            iUnidadDeTrabajo.RepositorioBanner.Insertar(pBanner);
            iUnidadDeTrabajo.Guardar();
        }

        /// <summary>
        ///     Modifica un banner del repositorio.
        /// </summary>
        /// <param name="pBanner">Banner a modificar.</param>
        public void Modificar(Banner pBanner)
        {
            iUnidadDeTrabajo.RepositorioBanner.Modificar(pBanner);
            iUnidadDeTrabajo.Guardar();
        }

        /// <summary>
        ///     Elimina un banner del repositorio.
        /// </summary>
        /// <param name="pBanner">Banner a eliminar.</param>
        public void Eliminar(Banner pBanner)
        {
            Banner mBanner = iUnidadDeTrabajo.RepositorioBanner.ObtenerPorId(pBanner.BannerId);
            iUnidadDeTrabajo.RepositorioBanner.Eliminar(mBanner);
            iUnidadDeTrabajo.Guardar();
        }

        /// <summary>
        ///     Obtiene un banner del repositorio correspondiente al ID proporcionado.
        /// </summary>
        /// <param name="pBannerId">ID de la banner.</param>
        /// <returns>Una banner.</returns>
        public Banner ObtenerPorId(int pBannerId)
        {
            return iUnidadDeTrabajo.RepositorioBanner.ObtenerPorId(pBannerId);
        }

        /// <summary>
        ///     Obtiene un lista de todas los banners del repositorio.
        /// </summary>
        /// <returns>Una lista de banners.</returns>
        public List<Banner> ObtenerTodos()
        {
            return iUnidadDeTrabajo.RepositorioBanner.Queryable.ToList();
        }
    }
}
