using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CarteleriaDigital.LogicaAccesoDatos.Modelo
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        //[Unique]
        public string NombreUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public string Contraseña { get; set; }
        [EmailAddress]
        public string EmailTexto { get; set; }
        
        public virtual List<Campaña> ListaCampaña { get; set; }
        public virtual List<Banner> ListaBanner { get; set; }

        [NotMapped]
        public MailAddress Email
        {
            get { return (EmailTexto == null) ? null : new MailAddress(EmailTexto); }
            set { EmailTexto = value.ToString(); }
        }

        public Usuario()
        {
            if (ListaCampaña == null)
                ListaCampaña = new List<Campaña>();
            if (ListaBanner == null)
                ListaBanner = new List<Banner>();
        }
        //public class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
        //{
        //    public UsuarioConfiguration()
        //    {
        //        Property(u => u.EmailTexto);
        //    }
        //}
    }
}
