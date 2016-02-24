using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CarteleriaDigital.LogicaAccesoDatos.Modelo;

namespace CarteleriaDigital.LogicaAccesoDatos
{
    public class CarteleriaContext : DbContext
    {
        public DbSet<Campaña> Campaña { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<BannerRSS> BannerRSSes { get; set; }
        public DbSet<BannerTXT> BannersTXTs { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Imagen> Imagens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add( new BannerRSS.BannerRSSConfiguration() );
            modelBuilder.Configurations.Add( new Usuario.UsuarioConfiguration() );
        }
    }
}
