using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteleriaDigital.LogicaAccesoDatos.Modelo
{
    public class Publicidad
    {
        public string Nombre { get; set; }
        public ushort Intervalo { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFin { get; set; }
        public bool Activo { get; set; }

        /// <summary>
        /// Devuelve unicamente la fecha del FechaHoraInicio
        /// </summary>
        /// <returns>Devuelve una fecha</returns>
        public DateTime FechaInicio() { return this.FechaHoraInicio.Date; }

        /// <summary>
        /// Devuelve unicamente la hora (como una duracion) del FechaHoraInicio
        /// </summary>
        /// <returns>Retorna una duracion</returns>
        public TimeSpan HoraInicio() { return new TimeSpan(this.FechaHoraInicio.Hour, this.FechaHoraInicio.Minute, this.FechaHoraInicio.Second); }
        
        /// <summary>
        /// Devuelve unicamente la fecha del FechaHoraFin
        /// </summary>
        /// <returns>Devuelve una fecha</returns>
        public DateTime FechaFin() { return this.FechaHoraFin.Date; }

        /// <summary>
        /// Devuelve unicamente la hora (como una duracion) del FechaHoraFin
        /// </summary>
        /// <returns>Retorna una duracion</returns>
        public TimeSpan HoraFin() { return new TimeSpan(this.FechaHoraFin.Hour, this.FechaHoraFin.Minute, this.FechaHoraFin.Second); }
    }
}
