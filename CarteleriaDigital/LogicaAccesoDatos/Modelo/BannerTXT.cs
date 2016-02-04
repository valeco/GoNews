using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteleriaDigital.LogicaAccesoDatos.Modelo
{
    public class BannerTXT :IBanner
    {
        public int BannerTXTId { get; set; }
        public string Texto { get; set; }

        /// <summary>
        /// Devuelve el proximo texto a mostrar
        /// </summary>
        /// <returns>Cadena de texto de una noticia</returns>
        public string Proximo() { return this.Texto; }
    }
}
