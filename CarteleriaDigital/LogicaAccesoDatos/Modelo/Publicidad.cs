using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarteleriaDigital.LogicaAccesoDatos.Modelo
{
    public class Publicidad
    {
        [Key]
        public int Id { get; set; }

        public string Nombre { get; set; }
        public int Intervalo { get; set; }//Almacenado en milisegundos
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public bool Activo { get; set; }
        [NotMapped]
        public int IntervaloEnSeg
        {
            get { return (this.Intervalo / 1000); }
            set { this.Intervalo = (value * 1000); }
        }
    }
}
