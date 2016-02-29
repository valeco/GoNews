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
            Campaña mCampaña = iUnidadDeTrabajo.RepositorioCampaña.ObtenerPorId(pCampaña.CampañaId);
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
        ///  Obtiene la existencia de campañas que se superpongan en fecha y horario a la indicada
        /// </summary>
        /// <param name="pCampaña">Campaña nueva</param>
        /// <returns>Existencia o no de seperposicion (bool)</returns>
        public bool ExisteCampañaEnHorario(Campaña pCampaña)
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

            return mConsulta.Count() > 0;
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
    }
}