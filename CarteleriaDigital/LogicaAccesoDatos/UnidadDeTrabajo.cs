using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CarteleriaDigital.LogicaAccesoDatos.Modelo;

namespace CarteleriaDigital.LogicaAccesoDatos
{
    public class UnidadDeTrabajo : IDisposable
    {

		private bool disposed = false;
        private CarteleriaContext iContext = new CarteleriaContext();
        private RepositorioGenerico<Usuario> iRepositorioUsuario;
        private RepositorioGenerico<Imagen> iRepositorioImagen;
        private RepositorioGenerico<Campaña> iRepositorioCampaña;
        private RepositorioGenerico<Banner> iRepositorioBanner;
        private RepositorioGenerico<BannerRSS> iRepositorioBannerRSS;

        public RepositorioGenerico<Usuario> RepositorioUsuario
        {
        	get
        	{
        		if (this.iRepositorioUsuario == null)
        		{
                    this.iRepositorioUsuario = new RepositorioGenerico<Usuario>(iContext);
        		}

        		return this.iRepositorioUsuario;
        	}
        }

        public RepositorioGenerico<Imagen> RepositorioImagen
        {
        	get
        	{
        		if (this.iRepositorioImagen == null)
        		{
                    this.iRepositorioImagen = new RepositorioGenerico<Imagen>(iContext);
        		}

        		return this.iRepositorioImagen;
        	}
        }

        public RepositorioGenerico<Campaña> RepositorioCampaña
        {
        	get
        	{
        		if (this.iRepositorioCampaña == null)
        		{
                    this.iRepositorioCampaña = new RepositorioGenerico<Campaña>(iContext);
        		}

        		return this.iRepositorioCampaña;
        	}
        }

        public RepositorioGenerico<Banner> RepositorioBanner
        {
        	get
        	{
        		if (this.iRepositorioBanner == null)
        		{
                    this.iRepositorioBanner = new RepositorioGenerico<Banner>(iContext);
        		}

        		return this.iRepositorioBanner;
        	}
        }

        public RepositorioGenerico<BannerRSS> RepositorioBannerRSS
        {
        	get
        	{
        		if (this.iRepositorioBannerRSS == null)
        		{
                    this.iRepositorioBannerRSS = new RepositorioGenerico<BannerRSS>(iContext);
        		}

        		return this.iRepositorioBannerRSS;
        	}
        }

        /// <summary>
        ///     Guarda los cambios realizados en el contexto.
        /// </summary>
        public void Guardar()
        {
            this.iContext.SaveChanges();
        }

        /// <summary>
        ///     Habilita la liberación de memoria.
        /// </summary>
        /// <param name="disposing">Verdadero si se quiere liberar la memoria.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
            {
                this.iContext.Dispose();
            }

            this.disposed = true;
        }

        /// <summary>
        ///     Libera la memoria.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
