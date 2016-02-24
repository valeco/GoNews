using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarteleriaDigital.RSS;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CarteleriaDigital.LogicaAccesoDatos.Modelo
{
    public class BannerRSS: IBanner
    {
        int iContador=0;
        List<RssItem> iListaItems = null;

        public int BannerRSSId { get; set; }
        public string Descripcion { get; set; }
        private string URLtexto { get; set; }

        [NotMapped]
        public Uri URL
        {
            get { return (URLtexto == null) ? null : new Uri(URLtexto); }
            set { URLtexto = value.ToString(); }
        }

        //http://blog.oneunicorn.com/2012/03/26/code-first-data-annotations-on-non-public-properties/
        //Es necesario para poder mapear una propiedad private
        public class BannerRSSConfiguration : EntityTypeConfiguration<BannerRSS>
        {
            public BannerRSSConfiguration()
            {
                Property(brss => brss.URLtexto);
            }
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Descripcion;
        }
    }
}
