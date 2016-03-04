using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarteleriaDigital.LogicaAccesoDatos;
using CarteleriaDigital.LogicaAccesoDatos.Modelo;
using CarteleriaDigital.Extras;

using System.Windows;

namespace CarteleriaDigital.Controladores
{
    public class ControladorCampaña
    {
        private UnidadDeTrabajo iUnidadDeTrabajo = new UnidadDeTrabajo();

        /// <summary>
        ///     Inserta una campaña en el repositorio.
        /// </summary>
        /// <param name="pCampaña">Campaña a insertar.</param>
        public void Insertar(Campaña pCampaña)
        {
            iUnidadDeTrabajo.RepositorioCampaña.Insertar(pCampaña);
            iUnidadDeTrabajo.Guardar();
        }

        /// <summary>
        ///     Modifica una campaña del repositorio.
        /// </summary>
        /// <param name="pCampaña">Campaña a modificar.</param>
        public void Modificar(Campaña pCampaña)
        {
            iUnidadDeTrabajo.RepositorioCampaña.Modificar(pCampaña);
            iUnidadDeTrabajo.Guardar();
        }

        /// <summary>
        ///     Elimina una campaña del repositorio.
        /// </summary>
        /// <param name="pCampaña">Campaña a eliminar.</param>
        public void Eliminar(Campaña pCampaña)
        {
            Campaña mCampaña = iUnidadDeTrabajo.RepositorioCampaña.ObtenerPorId(pCampaña.Id);
            iUnidadDeTrabajo.RepositorioCampaña.Eliminar(mCampaña);
            iUnidadDeTrabajo.Guardar();
        }

        /// <summary>
        ///     Obtiene una campaña del repositorio correspondiente al ID proporcionado.
        /// </summary>
        /// <param name="pCampañaId">ID de la campaña.</param>
        /// <returns>Una campaña.</returns>
        public Campaña ObtenerPorId(int pCampañaId)
        {
            return iUnidadDeTrabajo.RepositorioCampaña.ObtenerPorId(pCampañaId);
        }

        /// <summary>
        ///     Obtiene una lista de todas las campañas del repositorio.
        /// </summary>
        /// <returns>Una lista de campañas.</returns>
        public List<Campaña> ObtenerTodos()
        {
            return iUnidadDeTrabajo.RepositorioCampaña.Queryable.ToList();
        }

        /// <summary>
        /// Obtiene una lista de campañas que se superponen en fecha y horario con la indicada.
        /// </summary>
        /// <param name="pCampaña">Campaña nueva.</param>
        /// <returns>Lista de campañas existentes que se superponen con la nueva.</returns>
        public List<Campaña> ListaCampañasEnHorario(Campaña pCampaña)
        {
            DateTime mFIni = pCampaña.FechaInicio;
            DateTime mFFin = pCampaña.FechaFin;
            TimeSpan mHIni = pCampaña.HoraInicio;
            TimeSpan mHFin = pCampaña.HoraFin;

            var mConsulta = iUnidadDeTrabajo.RepositorioCampaña.Queryable.Where(c => (
                (
                    (mFIni >= c.FechaInicio && mFFin <= c.FechaFin) || // Intervalo dentro del otro (includio)
                    (mFIni < c.FechaInicio && mFFin <= c.FechaFin) || // Intervalo que arranca antes y termina dentro
                    (mFIni > c.FechaInicio && mFIni <= c.FechaFin && mFFin > c.FechaFin) || // Intervalo que arranque dentro y termine por fuera
                    (mFIni < c.FechaInicio && mFFin > c.FechaFin) // Intervalo que contenga al otro
                )
                    &&
                (
                    (mHIni >= c.HoraInicio && mHFin <= c.HoraFin) || // Intervalo dentro del otro (includio)
                    (mHIni < c.HoraInicio && mHFin <= c.HoraFin) || // Intervalo que arranca antes y termina dentro
                    (mHIni > c.HoraInicio && mHIni <= c.HoraFin && mHFin > c.HoraFin) || // Intervalo que arranque dentro y termine por fuera
                    (mHIni < c.HoraInicio && mHFin > c.HoraFin) // Intervalo que contenga al otro 
                )
                    &&
                (c.Activo == true)
            ));

            return mConsulta.ToList();
        }

        /// <summary>
        /// Obtiene la cantidad de campañas que se superpongan en fecha y horario al indicado.
        /// </summary>
        /// <param name="pCampaña">Campaña nueva.</param>
        /// <returns>Cantidad de campañas que se superponen.</returns>
        public int CantidadCampañasEnHorario(Campaña pCampaña)
        {
            return ListaCampañasEnHorario(pCampaña).Count;
        }

        /// <summary>
        ///  Obtiene la existencia de campañas que se superpongan en fecha y horario a la indicada
        /// </summary>
        /// <param name="pCampaña">Campaña nueva</param>
        /// <returns>Existencia o no de seperposicion (bool)</returns>
        public bool ExisteCampañaEnHorario(Campaña pCampaña)
        {
            return CantidadCampañasEnHorario(pCampaña) > 0;
        }

        /// <summary>
        /// Devuelve la campaña que debe mostrarse en la fecha/hora indicada
        /// </summary>
        /// <param name="pFechaHora">Fecha de interes</param>
        /// <returns>Una campaña</returns>
        public Campaña ObtenerCampaña(DateTime pFechaHora)
        {
            //Valores para inicializar la campaña auxiliar
            DateTime mFechaFin = pFechaHora.AddMinutes(1);
            TimeSpan mHoraInicio = new TimeSpan(pFechaHora.Hour, pFechaHora.Minute, pFechaHora.Second);
            TimeSpan mHoraFin = new TimeSpan(mFechaFin.Hour, mFechaFin.Minute, mFechaFin.Second);

            Campaña mCampañaAuxiliar = new Campaña
            {
                FechaInicio = pFechaHora.Date,
                HoraInicio = mHoraInicio,
                FechaFin = mFechaFin.Date,
                HoraFin = mHoraFin,
                Intervalo = 0,
                Nombre = "GO NEWS",
                ListaImagenes = new List<Imagen>()//Se inicializa vacia, ya q la clase lo reconoce y devuelve una imagen por defecto.
            };

            //Valores utilizados para la busqueda
            DateTime mDia = mCampañaAuxiliar.FechaInicio;
            TimeSpan mHora = mCampañaAuxiliar.HoraInicio;

            var mConsulta = iUnidadDeTrabajo.RepositorioCampaña.Queryable.Where(c => (
                (c.Activo == true)
                &&
                (mDia >= c.FechaInicio && mDia <= c.FechaFin)
                &&
                (mHora >= c.HoraInicio && mHora <= c.HoraFin)
            ));

            return mConsulta.Count() == 1 ? mConsulta.First() : mCampañaAuxiliar;
        }

        /// <summary>
        /// Obtiene el resultado de una busqueda amplia (y adaptable)
        /// </summary>
        /// <param name="pDesActivo">Cadena "Todos","Activos","Desactivos"</param>
        /// <param name="pNombre">Nombre de la Campaña</param>
        /// <param name="pFInicio">Fecha de Inicio</param>
        /// <param name="pFFin">Fecha de Fin</param>
        /// <param name="pHInicio">Hora de Inicio</param>
        /// <param name="pHFin">Hora de Fin</param>
        /// <returns>Lista de campañas</returns>
        public List<Campaña> Buscar(string pDesActivo, string pNombre = "", DateTime pFInicio = default(DateTime),
                                    DateTime pFFin = default(DateTime), TimeSpan pHInicio = default(TimeSpan),
                                    TimeSpan pHFin = default(TimeSpan) )
        {
            return this.iUnidadDeTrabajo.RepositorioCampaña.Queryable.Where(c => (
                   (pDesActivo == "Todos" ? true : (pDesActivo == "Activos" ? (c.Activo == true) : (c.Activo == false)))
                   &&
                   (pNombre == "" ? true : c.Nombre.Contains(pNombre))
                   &&
                   (pFInicio == default(DateTime) ? true: (
                        (c.FechaInicio >= pFInicio && c.FechaInicio <= pFFin) ||
                        (c.FechaFin >= pFInicio && c.FechaFin <= pFFin) ||
                        (c.FechaInicio < pFInicio && c.FechaFin > pFFin) // REVISAR. Esto está fuera del intervalo de días. Por qué iría?
                   ))
                   &&
                   (pHInicio == default(TimeSpan) ? true : (
                        (c.HoraInicio >= pHInicio && c.HoraInicio <= pHFin) ||
                        (c.HoraFin >= pHInicio && c.HoraFin <= pHFin) ||
                        (c.HoraInicio < pHInicio && c.HoraFin > pHFin) // REVISAR. Esto está fuera del intervalo de horas. Por qué iría?
                   ))
                )).ToList();
        }

    }
}