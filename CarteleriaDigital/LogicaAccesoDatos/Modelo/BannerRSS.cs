using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarteleriaDigital.RSS;
using System.ComponentModel.DataAnnotations;
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

        //[Index(IsUnique = true)]
        //[DataType(DataType.Url)]
        [Url]
        //public object URL { get; set; }
        public string URLtexto { get; set; }

        [NotMapped]
        public Uri URL
        {
            get { return (URLtexto == null) ? null : new Uri(URLtexto); }
            set { URLtexto = value.ToString(); }
        }
        //https://msdn.microsoft.com/es-es/library/bb738642(v=vs.100).aspx doc query
        //https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.datatype(v=vs.110).aspx Annotations Datatype
        //http://blog.oneunicorn.com/2012/03/26/code-first-data-annotations-on-non-public-properties/
        
        ////Es necesario para poder mapear una propiedad private
        //public class BannerRSSConfiguration : EntityTypeConfiguration<BannerRSS>
        //{
        //    public BannerRSSConfiguration()
        //    {
        //        Property(brss => brss.URLtexto);
        //    }
        //}

        /// <summary>
        /// Devuelve el proximo texto a mostrar
        /// </summary>
        /// <returns>Cadena de texto de una noticia</returns>
        public string Proximo()
        {
            RssItem mItem;
            RssItem mDefaultItem = new RssItem( "Go News",
                                                "Publicita tu producto aquí, informate en www.GoNews.com.ar",
                                                DateTime.Now,
                                                new Uri("http://www.gonews.com.ar"));
            try
            {
                if (this.iListaItems == null || this.iListaItems.Count() == 0)
                {
                    this.iListaItems = RSS.RSS.Feed(this.URL);
                    this.iContador = 0;
                }

                if (this.iContador == this.iListaItems.Count() - 1)
                    iContador = 0;
                else
                    iContador++;

                mItem = this.iListaItems.Count() == 0 ? mDefaultItem : this.iListaItems.ElementAt(iContador);

                
            }
            catch (NotInternetAvailable)
            {
                mItem = mDefaultItem;
            }

            return "[" + mItem.Fecha + "] " + mItem.Titulo + ": " + mItem.Descripcion;
                   
        }

        public int Id ()
        {
            return this.BannerRSSId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Descripcion;
        }

        /// <summary>
        /// Obtiene una instancia de la clase BannerRSS
        /// </summary>
        public BannerRSS() { }
    }
}
