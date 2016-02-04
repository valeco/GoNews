using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteleriaDigital.LogicaAccesoDatos.Modelo
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string NombreUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public string Contraseña { get; set; }
        public string Email { get; set; }

        public virtual List<Campaña> ListaCampaña { get; set; }
        public virtual List<Banner> ListaBanner { get; set; }
    }
}
