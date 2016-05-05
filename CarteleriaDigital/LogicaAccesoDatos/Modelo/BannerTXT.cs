using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteleriaDigital.LogicaAccesoDatos.Modelo
{
    public class BannerTXT : IBanner
    {
        public int BannerTXTId { get; set; }
        public string Texto { get; set; }

        /// <summary>
        /// Obtiene una instancia de BannerTXT
        /// </summary>
        /// <param name="pTexto">Texto asociado al banner</param>
        public BannerTXT(string pTexto)
        { this.Texto = pTexto != string.Empty? pTexto: "Go News: Publicita tu producto aquí, informate en www.GoNews.com.ar"; }

        /// <summary>
        /// Devuelve el proximo texto a mostrar
        /// </summary>
        /// <returns>Cadena de texto de una noticia</returns>
        public string Proximo() { return this.Texto; }

        public int Id()
        {
            return this.BannerTXTId;
        }

        /// <summary>
        /// Constructor solo valido para ser utilizado por EF
        /// </summary>
        protected BannerTXT() {}
    }
}
