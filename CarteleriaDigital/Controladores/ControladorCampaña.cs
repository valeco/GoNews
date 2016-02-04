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
    }
}
