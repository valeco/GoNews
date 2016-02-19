using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarteleriaDigital.LogicaAccesoDatos;
using CarteleriaDigital.LogicaAccesoDatos.Modelo;

namespace CarteleriaDigital.Controladores
{
    public class ControladorCampaña
    {
        private UnidadDeTrabajo iUnidadDeTrabajo = new UnidadDeTrabajo();

        // ¡REVISAR!
        public IQueryable<Campaña> Queryable
        {
            get { return iUnidadDeTrabajo.RepositorioCampaña.Queryable; }
        }

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
        public bool ExiteCampañaEnHorario(Campaña pCampaña)
        {
            DateTime mFIni = pCampaña.FechaInicio();
            DateTime mFFin = pCampaña.FechaFin();
            TimeSpan mHIni = pCampaña.HoraInicio();
            TimeSpan mHFin = pCampaña.HoraFin();

            var mConsulta = iUnidadDeTrabajo.RepositorioCampaña.Queryable.Where(c => (
                (   
                    (mFIni >= c.FechaInicio() && mFFin <= c.FechaFin()) || // Intervalo dentro del otro (includio)
                    (mFIni < c.FechaInicio() && mFFin <= c.FechaFin()) || // Intervalo que arranca antes y termina dentro
                    (mFIni > c.FechaInicio() && mFIni <= c.FechaFin() && mFFin > c.FechaFin()) || // Intervalo que arranque dentro y termine por fuera
                    (mFIni < c.FechaInicio() && mFFin > c.FechaFin()) // Intervalo que contenga al otro
                ) 
                    && 
                (
                    (mHIni >= c.HoraInicio() && mHFin <= c.HoraFin()) || // Intervalo dentro del otro (includio)
                    (mHIni < c.HoraInicio() && mHFin <= c.HoraFin()) || // Intervalo que arranca antes y termina dentro
                    (mHIni > c.HoraInicio() && mHIni <= c.HoraFin() && mHFin > c.HoraFin()) || // Intervalo que arranque dentro y termine por fuera
                    (mHIni < c.HoraInicio() && mHFin > c.HoraFin()) // Intervalo que contenga al otro 
                )
                    &&
                (c.Activo == true) //HAY QUE PREGUNTARLO? REVISAR puede que si el banner existe pero esta desactivado no haya drama en que se
                                    //genere uno en el mismo horario, el drama que si se activa hay que considerar solapamiento al activar
            ));

            return mConsulta.Count() > 0;
        }
    }
}
