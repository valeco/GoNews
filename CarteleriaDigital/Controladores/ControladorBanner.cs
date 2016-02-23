using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarteleriaDigital.LogicaAccesoDatos;
using CarteleriaDigital.LogicaAccesoDatos.Modelo;

namespace CarteleriaDigital.Controladores
{
    public class ControladorBanner
    {
        private UnidadDeTrabajo iUnidadDeTrabajo = new UnidadDeTrabajo();

        /// <summary>
        /// Devuelve objeto de consulta
        /// </summary>
        public IQueryable<Banner> Queryable
        {
            get { return iUnidadDeTrabajo.RepositorioBanner.Queryable; }
        }

        /// <summary>
        ///     Inserta un banner en el repositorio.
        /// </summary>
        /// <param name="pBanner">Banner a insertar.</param>
        public void Insertar(Banner pBanner)
        {
            iUnidadDeTrabajo.RepositorioBanner.Insertar(pBanner);
            iUnidadDeTrabajo.Guardar();
        }

        /// <summary>
        ///     Modifica un banner del repositorio.
        /// </summary>
        /// <param name="pBanner">Banner a modificar.</param>
        public void Modificar(Banner pBanner)
        {
            iUnidadDeTrabajo.RepositorioBanner.Modificar(pBanner);
            iUnidadDeTrabajo.Guardar();
        }

        /// <summary>
        ///     Elimina un banner del repositorio.
        /// </summary>
        /// <param name="pBanner">Banner a eliminar.</param>
        public void Eliminar(Banner pBanner)
        {
            Banner mBanner = iUnidadDeTrabajo.RepositorioBanner.ObtenerPorId(pBanner.BannerId);
            iUnidadDeTrabajo.RepositorioBanner.Eliminar(mBanner);
            iUnidadDeTrabajo.Guardar();
        }

        /// <summary>
        ///     Obtiene un banner del repositorio correspondiente al ID proporcionado.
        /// </summary>
        /// <param name="pBannerId">ID de la banner.</param>
        /// <returns>Una banner.</returns>
        public Banner ObtenerPorId(int pBannerId)
        {
            return iUnidadDeTrabajo.RepositorioBanner.ObtenerPorId(pBannerId);
        }

        /// <summary>
        ///     Obtiene un lista de todas los banners del repositorio.
        /// </summary>
        /// <returns>Una lista de banners.</returns>
        public List<Banner> ObtenerTodos()
        {
            return iUnidadDeTrabajo.RepositorioBanner.Queryable.ToList();
        }

        /// <summary>
        ///  Obtiene la existencia de banners que se superpongan en fecha y horario al indicado
        /// </summary>
        /// <param name="pBanner">Banner nuevo</param>
        /// <returns>Existencia o no de seperposicion (bool)</returns>
        public bool ExiteBannerEnHorario(Banner pBanner)
        {
            DateTime mFIni = pBanner.FechaInicio();
            DateTime mFFin = pBanner.FechaFin();
            TimeSpan mHIni = pBanner.HoraInicio();
            TimeSpan mHFin = pBanner.HoraFin();

            var mConsulta = iUnidadDeTrabajo.RepositorioBanner.Queryable.Where(b => (
                (
                    (mFIni >= b.FechaInicio() && mFFin <= b.FechaFin()) || // Intervalo dentro del otro (includio)
                    (mFIni < b.FechaInicio() && mFFin <= b.FechaFin()) || // Intervalo que arranca antes y termina dentro
                    (mFIni > b.FechaInicio() && mFIni <= b.FechaFin() && mFFin > b.FechaFin()) || // Intervalo que arranque dentro y termine por fuera
                    (mFIni < b.FechaInicio() && mFFin > b.FechaFin()) // Intervalo que contenga al otro
                )
                    &&
                (
                    (mHIni >= b.HoraInicio() && mHFin <= b.HoraFin()) || // Intervalo dentro del otro (includio)
                    (mHIni < b.HoraInicio() && mHFin <= b.HoraFin()) || // Intervalo que arranca antes y termina dentro
                    (mHIni > b.HoraInicio() && mHIni <= b.HoraFin() && mHFin > b.HoraFin()) || // Intervalo que arranque dentro y termine por fuera
                    (mHIni < b.HoraInicio() && mHFin > b.HoraFin()) // Intervalo que contenga al otro 
                )
                    &&
                (b.Activo== true) //HAY QUE PREGUNTARLO? REVISAR puede que si el banner existe pero esta desactivado no haya drama en que se
                                   //genere uno en el mismo horario, el drama que si se activa hay que considerar solapamiento al activar
            ));

            return mConsulta.Count() > 0;
        }
    }
}
