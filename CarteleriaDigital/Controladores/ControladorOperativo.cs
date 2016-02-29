using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarteleriaDigital.LogicaAccesoDatos.Modelo;


namespace CarteleriaDigital.Controladores
{
    public class ControladorOperativo
    {
        private ControladorCampaña iControladorCampaña = new ControladorCampaña();
        private ControladorBanner iControladorBanner = new ControladorBanner();

        /// <summary>
        /// Devuelve la campaña que debe mostrarse en la fecha/hora indicada
        /// </summary>
        /// <param name="pFechaHora">Fecha de interes</param>
        /// <returns>Una campaña</returns>
        public Campaña ObtenerCampaña(DateTime pFechaHora)
        {
            return iControladorCampaña.ObtenerCampaña(pFechaHora);
        }

        /// <summary>
        /// Devuelve el banner que debe mostrarse en la fecha/hora indicada
        /// </summary>
        /// <param name="pFechaHora">Fecha de interes</param>
        /// <returns>Un banner</returns>
        public Banner ObtenerBanner(DateTime pFechaHora)
        {
            return iControladorBanner.ObtenerBanner(pFechaHora);
        }
    }
}