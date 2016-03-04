using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarteleriaDigital.LogicaAccesoDatos;
using CarteleriaDigital.LogicaAccesoDatos.Modelo;

namespace CarteleriaDigital.Controladores
{
    public class ControladorBannerTXT
    {
        private UnidadDeTrabajo iUnidadDeTrabajo = new UnidadDeTrabajo();

        /// <summary>
        ///     Inserta un banner TXT en el repositorio.
        /// </summary>
        /// <param name="pBanner">Banner TXT a insertar.</param>
        public void Insertar(BannerTXT pBannerTXT)
        {
            iUnidadDeTrabajo.RepositorioBannerTXT.Insertar(pBannerTXT);
            iUnidadDeTrabajo.Guardar();
        }

        /// <summary>
        ///     Modificar un banner TXT en el repositorio.
        /// </summary>
        /// <param name="pBanner">Banner TXT a insertar.</param>
        public void Modificar(BannerTXT pBannerTXT)
        {
            iUnidadDeTrabajo.RepositorioBannerTXT.Modificar(pBannerTXT);
            iUnidadDeTrabajo.Guardar();
        }

        /// <summary>
        ///     Elimina un banner TXT del repositorio.
        /// </summary>
        /// <param name="pBanner">Banner TXT a eliminar.</param>
        public void Eliminar(BannerTXT pBannerTXT)
        {
            BannerTXT mBannerTXT = iUnidadDeTrabajo.RepositorioBannerTXT.ObtenerPorId(pBannerTXT.BannerTXTId);
            iUnidadDeTrabajo.RepositorioBannerTXT.Eliminar(mBannerTXT);
            iUnidadDeTrabajo.Guardar();
        }

        /// <summary>
        ///     Obtiene un banner del repositorio correspondiente al ID proporcionado.
        /// </summary>
        /// <param name="pBannerId">ID del banner.</param>
        /// <returns>Una banner.</returns>
        public BannerTXT ObtenerPorId(int pBannerTXTId)
        {
            return iUnidadDeTrabajo.RepositorioBannerTXT.ObtenerPorId(pBannerTXTId);
        }

        /// <summary>
        ///     Obtiene un lista de todas los banners TXT del repositorio.
        /// </summary>
        /// <returns>Una lista de banners TXT.</returns>
        public List<BannerTXT> ObtenerTodos()
        {
            return iUnidadDeTrabajo.RepositorioBannerTXT.Queryable.ToList();
        }
    }
}