using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarteleriaDigital.LogicaAccesoDatos;
using CarteleriaDigital.LogicaAccesoDatos.Modelo;

namespace CarteleriaDigital.Controladores
{
    public class ControladorBannerRSS
    {
        private UnidadDeTrabajo iUnidadDeTrabajo = new UnidadDeTrabajo();

        /// <summary>
        ///     Inserta un banner RSS en el repositorio.
        /// </summary>
        /// <param name="pBanner">Banner RSS a insertar.</param>
        public void Insertar(BannerRSS pBannerRSS)
        {
            iUnidadDeTrabajo.RepositorioBannerRSS.Insertar(pBannerRSS);
            iUnidadDeTrabajo.Guardar();
        }

        /// <summary>
        ///     Elimina un banner RSS del repositorio.
        /// </summary>
        /// <param name="pBanner">Banner RSS a eliminar.</param>
        public void Eliminar(BannerRSS pBannerRSS)
        {
            BannerRSS mBannerRSS = iUnidadDeTrabajo.RepositorioBannerRSS.ObtenerPorId(pBannerRSS.BannerRSSId);
            iUnidadDeTrabajo.RepositorioBannerRSS.Eliminar(mBannerRSS);
            iUnidadDeTrabajo.Guardar();
        }

        /// <summary>
        ///     Obtiene un lista de todas los banners RSS del repositorio.
        /// </summary>
        /// <returns>Una lista de banners RSS.</returns>
        public List<BannerRSS> ObtenerTodos()
        {
            return iUnidadDeTrabajo.RepositorioBannerRSS.Queryable.ToList();
        }
    }
}
