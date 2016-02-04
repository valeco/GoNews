using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarteleriaDigital.RSS;

namespace CarteleriaDigital.LogicaAccesoDatos.Modelo
{
    public class BannerRSS: IBanner
    {
        int iContador;
        List<RssItem> iListaItems = null;

        public int BannerRSSId { get; set; }
        public string Descripcion { get; set; }
        private string URLtexto { get; set; }

        public Uri URL
        {
            get { return (URLtexto == String.Empty) ? null : new Uri(URLtexto); }
            set { URLtexto = value.ToString(); }
        }

        /// <summary>
        /// Devuelve el proximo texto a mostrar
        /// </summary>
        /// <returns>Cadena de texto de una noticia</returns>
        public string Proximo()
        {
            if (this.iListaItems.Count() == 0 || this.iListaItems == null)
            {
                this.iListaItems = RSS.RSS.Feed(this.URL);
                this.iContador = 0;
            }

            if (this.iContador >= this.iListaItems.Count())
                iContador = 0;

            RssItem mItem = this.iListaItems.Count()==0 ?   new RssItem("GO NEWS",
                                                                        "Publicita tu producto aquí, informate en WWW.goNews.com.ar",
                                                                        DateTime.Today,
                                                                        new Uri("www.gonews.com.ar") ):
                                                            this.iListaItems.ElementAt(iContador);

            return "[" + mItem.Fecha + "] " + mItem.Titulo + ": " + mItem.Descripcion;
        }
    }
}
