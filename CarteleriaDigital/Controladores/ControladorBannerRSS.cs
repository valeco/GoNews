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
        private UnidadDeTrabajo iUnidadDeTrabajo = UnidadDeTrabajo.Instancia;

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
        ///     Modificar un banner RSS en el repositorio.
        /// </summary>
        /// <param name="pBanner">Banner RSS a insertar.</param>
        public void Modificar(BannerRSS pBannerRSS)
        {
            iUnidadDeTrabajo.RepositorioBannerRSS.Modificar(pBannerRSS);
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

        /// <summary>
        /// Obtiene todos los BannerRSS que contienen en su Descripcion o Url la cadena indicada
        /// </summary>
        /// <param name="pCadena">Cadena a contener</param>
        /// <returns>Lista de BannerRSS</returns>
        public List<BannerRSS> ObtenerPorSimilitudDescripcionOUrl(string pCadena)
        {
            return iUnidadDeTrabajo.RepositorioBannerRSS.Queryable.Where(brss => (brss.Descripcion.Contains(pCadena) == true || brss.URLtexto.Contains(pCadena) == true)).ToList<BannerRSS>();
        }

        /// <summary>
        /// Obtiene la existencia del Url dentro de los BannerRSS ya existentes
        /// </summary>
        /// <param name="pUrl">Url a buscar</param>
        /// <returns>Un booleano</returns>
        public bool ExisteUrl(Uri pUrl)
        {
            return iUnidadDeTrabajo.RepositorioBannerRSS.Queryable.Where(brss => (brss.URLtexto == pUrl.AbsoluteUri)).Count() != 0;
        }
    }
}