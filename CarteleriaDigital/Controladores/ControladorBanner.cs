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
            Banner mBanner = iUnidadDeTrabajo.RepositorioBanner.ObtenerPorId(pBanner.Id);
            iUnidadDeTrabajo.RepositorioBanner.Eliminar(mBanner);
            iUnidadDeTrabajo.Guardar();
        }

        /// <summary>
        ///     Obtiene un banner del repositorio correspondiente al ID proporcionado.
        /// </summary>
        /// <param name="pBannerId">ID del banner.</param>
        /// <returns>Un banner.</returns>
        public Banner ObtenerPorId(int pBannerId)
        {
            return iUnidadDeTrabajo.RepositorioBanner.ObtenerPorId(pBannerId);
        }

        /// <summary>
        ///     Obtiene la existencia del banner en el repositorio, correspondiente al ID proporcionado.
        /// </summary>
        /// <param name="pBannerId">ID del banner.</param>
        /// <returns>Un booleano</returns>
        public bool ExisteConId(int pBannerId)
        {
            return (this.ObtenerPorId(pBannerId) != null);
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
        /// Obtiene una lista de banners existentes que se superpongan en fecha/hora con el indicado.
        /// </summary>
        /// <param name="pBanner">Banner nuevo.</param>
        /// <returns>Lista de banners existentes que se superponen con el nuevo.</returns>
        public List<Banner> ListaBannersEnHorario(Banner pBanner)
        {
            DateTime mFIni = pBanner.FechaInicio;
            DateTime mFFin = pBanner.FechaFin;
            TimeSpan mHIni = pBanner.HoraInicio;
            TimeSpan mHFin = pBanner.HoraFin;

            var mConsulta = iUnidadDeTrabajo.RepositorioBanner.Queryable.Where(b => (
                (
                    (mFIni >= b.FechaInicio && mFFin <= b.FechaFin) || // Intervalo dentro del otro (includio)
                    (mFIni < b.FechaInicio && mFFin >= b.FechaInicio && mFFin <= b.FechaFin) || // Intervalo que arranca antes y termina dentro
                    (mFIni >= b.FechaInicio && mFIni <= b.FechaFin && mFFin > b.FechaFin) || // Intervalo que arranque dentro y termine despues
                    (mFIni < b.FechaInicio && mFFin > b.FechaFin) // Intervalo que contenga al otro
                )
                    &&
                (
                    (mHIni >= b.HoraInicio && mHFin <= b.HoraFin) || // Intervalo dentro del otro (includio)
                    (mHIni < b.HoraInicio && mHFin >= b.HoraInicio && mHFin <= b.HoraFin) || // Intervalo que arranca antes y termina dentro
                    (mHIni >= b.HoraInicio && mHIni <= b.HoraFin && mHFin > b.HoraFin) || // Intervalo que arranque dentro y termine despues
                    (mHIni < b.HoraInicio && mHFin > b.HoraFin) // Intervalo que contenga al otro 
                )
                    &&
                (b.Activo == true) //HAY QUE PREGUNTARLO? REVISAR puede que si el banner existe pero esta desactivado no haya drama en que se
                                   //genere uno en el mismo horario, el drama que si se activa hay que considerar solapamiento al activar
            ));

            return mConsulta.ToList();
        }

        /// <summary>
        ///  Obtiene la existencia de banners que se superpongan en fecha y horario al indicado
        /// </summary>
        /// <param name="pBanner">Banner nuevo</param>
        /// <returns>Existencia o no de seperposicion (bool)</returns>
        public bool ExisteBannerEnHorario(Banner pBanner)
        {
            return this.CantidadBannersEnHorario(pBanner) > 0;
        }

        /// <summary>
        /// Obtiene la cantidad de banners que se superpongan en fecha y horario al indicado.
        /// </summary>
        /// <param name="pBanner">Banner nuevo.</param>
        /// <returns>Cantidad de banners que se superponen.</returns>
        public int CantidadBannersEnHorario(Banner pBanner)
        {
            return ListaBannersEnHorario(pBanner).Count;
        }

        /// <summary>
        /// Devuelve el banner que debe mostrarse en la fecha/hora indicada
        /// </summary>
        /// <param name="pFechaHora">Fecha de interes</param>
        /// <returns>Un banner</returns>
        public Banner ObtenerBanner(DateTime pFechaHora)
        {
            Banner mBannerAuxiliar = new Banner(new BannerTXT(), TipoBanner.TXT)//Por defecto BannerTXT tiene un texto promocional de GoNews
            {
                FechaInicio = pFechaHora.Date,
                FechaFin = pFechaHora.Date.AddMinutes(1),
                HoraInicio = new TimeSpan(pFechaHora.Hour, pFechaHora.Minute, pFechaHora.Second),
                HoraFin = new TimeSpan(pFechaHora.Hour, pFechaHora.Minute, pFechaHora.Second),
                Intervalo = 0,
                Nombre = "GO NEWS Campaña Default",
            };
            DateTime mDia = mBannerAuxiliar.FechaInicio;
            TimeSpan mHora = mBannerAuxiliar.HoraInicio;

            var mConsulta = iUnidadDeTrabajo.RepositorioBanner.Queryable.Where(b => (
                (mDia >= b.FechaInicio && mDia <= b.FechaFin)
                &&
                (mHora >= b.HoraInicio && mHora <= b.HoraFin)
                &&
                (b.Activo == true)
            ));

            return mConsulta.Count() == 1 ? mConsulta.First() : mBannerAuxiliar;
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
        /// <returns>Lista de banners</returns>
        public List<Banner> Buscar(string pDesActivo, string pNombre = "", DateTime pFInicio = default(DateTime),
                                    DateTime pFFin = default(DateTime), TimeSpan pHInicio = default(TimeSpan),
                                    TimeSpan pHFin = default(TimeSpan))
        {
            return this.iUnidadDeTrabajo.RepositorioBanner.Queryable.Where(b => (
                   (pDesActivo == "Todos" ? true : (pDesActivo == "Activos" ? (b.Activo == true) : (b.Activo == false)))
                   &&
                   (pNombre == "" ? true : b.Nombre.Contains(pNombre))
                   &&
                   (pFInicio == default(DateTime) ? true : (
                        (b.FechaInicio >= pFInicio && b.FechaInicio <= pFFin) ||
                        (b.FechaFin >= pFInicio && b.FechaFin <= pFFin) ||
                        (b.FechaInicio < pFInicio && b.FechaFin > pFFin)
                   ))
                   &&
                   (pHInicio == default(TimeSpan) ? true : (
                        (b.HoraInicio >= pHInicio && b.HoraInicio <= pHFin) ||
                        (b.HoraFin >= pHInicio && b.HoraFin <= pHFin) ||
                        (b.HoraInicio < pHInicio && b.HoraFin > pHFin)
                   ))
             )).ToList();
        }
    }
}