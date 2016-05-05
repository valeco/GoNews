using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CarteleriaDigital.LogicaAccesoDatos.Modelo
{
    public enum TipoBanner { RSS = 0 , TXT = 1}

    public class Banner : Publicidad
    {
        private TipoBanner iTipo { get; set; }
        private IBanner iFuente { get; set; }
        private int iFuenteId { get; set; }

        /// <summary>
        /// Genera una instancia de Banner
        /// </summary>
        /// <param name="pBanner">Objeto que implementa la interface IBanner</param>
        /// <param name="pTipo">Tipo del Banner</param>
        public Banner(IBanner pBanner, TipoBanner pTipo)
        {
            this.CambiarTipo(pBanner, pTipo);
        }

        /// <summary>
        /// Modifica el objeto del banner y su tipo
        /// </summary>
        /// <param name="pBanner">Objeto que implementa la interface IBanner</param>
        /// <param name="pTipo">Tipo del Banner</param>
        public void CambiarTipo(IBanner pBanner, TipoBanner pTipo)
        {
            if( (pBanner.GetType()==typeof(BannerRSS) && pTipo == TipoBanner.RSS) ||
                ((pBanner.GetType() == typeof(BannerTXT) && pTipo == TipoBanner.TXT)) )
            {
                this.iTipo = pTipo;
                this.iFuente = pBanner;
                this.iFuenteId = pBanner.Id();
            }
        }

        /// <summary>
        /// Obtiene el proximo texto a mostrar
        /// </summary>
        /// <returns></returns>
        public string ProximoTexto()
        {
            return (this.Fuente == null)? "": this.Fuente.Proximo();
        }

        /// <summary>
        /// Retorna el tipo del que es el banner
        /// </summary>
        /// <returns>Enumerado TipoBanner</returns>
        [NotMapped]
        public TipoBanner Tipo { get { return this.iTipo; } }

        /// <summary>
        /// Retorna la fuente del banner, es decir, el BannerTXT o el BannerRSS correspondiente.
        /// </summary>
        [NotMapped]
        public IBanner Fuente
        {
            get {
                if (this.iFuente == null)
                    this.CargarFuente();
                        
                return this.iFuente;
            }
        }


        /// <summary>
        /// Constructor solo apto para utilizar por Entity Frmework
        /// </summary>
        protected Banner()
        {   
                this.CargarFuente();
        }

        /// <summary>
        /// Metodo privado utilizado para que se carge la fuente
        /// </summary>
        private void CargarFuente()
        {
            if (iFuente == null && iFuenteId > 0)
            {
                UnidadDeTrabajo UoW = UnidadDeTrabajo.Instancia;
                switch (iTipo)
                {
                    case TipoBanner.RSS:
                        iFuente = UoW.RepositorioBannerRSS.ObtenerPorId(iFuenteId);
                        break;
                    case TipoBanner.TXT:
                        iFuente = UoW.RepositorioBannerTXT.ObtenerPorId(iFuenteId);
                        break;
                }
            }
        }

        //Es necesario para poder mapear una propiedad private
        public class BannerConfiguration : EntityTypeConfiguration<Banner>
        {
            public BannerConfiguration()
            {
                Property(b => b.iFuenteId);
                Property(b=>b.iTipo);
            }
        }

    }
}
