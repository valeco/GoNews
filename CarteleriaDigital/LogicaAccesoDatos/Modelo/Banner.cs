using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteleriaDigital.LogicaAccesoDatos.Modelo
{
    public enum TipoBanner { RSS , TXT }

    public class Banner: Publicidad
    {
        public int BannerId { get; set; }
        private TipoBanner DeTipo { get; set; }
        private IBanner BannerObjeto { get; set; }

        /// <summary>
        /// Genera una instancia de Banner
        /// </summary>
        /// <param name="pBanner">Objeto que implementa la interface IBanner</param>
        /// <param name="pTipo">Tipo del Banner</param>
        public Banner(IBanner pBanner, TipoBanner pTipo)
        {
            this.DeTipo = pTipo;
            this.BannerObjeto = pBanner;
        }

        /// <summary>
        /// Modifica el objeto del banner y su tipo
        /// </summary>
        /// <param name="pBanner">Objeto que implementa la interface IBanner</param>
        /// <param name="pTipo">Tipo del Banner</param>
        public void CambiarTipo(IBanner pBanner, TipoBanner pTipo)
        {
            this.DeTipo = pTipo;
            this.BannerObjeto = pBanner;
        }

        /// <summary>
        /// Obtiene el proximo texto a mostrar
        /// </summary>
        /// <returns></returns>
        public string ProximoTexto()
        {
            return this.BannerObjeto.Proximo();
        }

        /// <summary>
        /// Retorna el tipo del que es el banner
        /// </summary>
        /// <returns>Enumerado TipoBanner</returns>
        public TipoBanner Tipo { get { return this.DeTipo; } }
    }
}
