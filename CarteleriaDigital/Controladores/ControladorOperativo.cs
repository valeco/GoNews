﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarteleriaDigital.LogicaAccesoDatos.Modelo;
using CarteleriaDigital.Extras;

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
            Campaña mCampañaAuxiliar = new Campaña { FechaHoraInicio = pFechaHora,
                FechaHoraFin = pFechaHora.AddMinutes(1),
                Intervalo = 0,
                Nombre = "GO NEWS",
                ListaImagenes = new List<Imagen>(new Imagen[] { new Imagen(0, Utilidades.RutaPrograma() + "Imagenes\\_campaña_gonews.jpg") })
                //IMAGEN POR DEFECTO PARA PUBLICITAR EL SERVICIO    
            };
            DateTime mDia = mCampañaAuxiliar.FechaInicio();
            TimeSpan mHora = mCampañaAuxiliar.HoraInicio();

            var mConsulta = iControladorCampaña.Queryable.Where(c =>( 
                (mDia >= c.FechaInicio() && mDia <= c.FechaFin())
                &&                                                
                (mHora >= c.HoraInicio() && mHora <= c.HoraFin())
                &&
                (c.Activo==true)
            ));

            return mConsulta.Count() == 1 ? mConsulta.First(): mCampañaAuxiliar;
        }

        /// <summary>
        /// Devuelve el banner que debe mostrarse en la fecha/hora indicada
        /// </summary>
        /// <param name="pFechaHora">Fecha de interes</param>
        /// <returns>Un banner</returns>
        public Banner ObtenerBanner(DateTime pFechaHora)
        {
            Banner mBannerAuxiliar = new Banner(new BannerTXT(), TipoBanner.TXT) { FechaHoraInicio = pFechaHora,
                FechaHoraFin = pFechaHora.AddMinutes(1),
                Intervalo = 0,
                Nombre = "GO NEWS Campaña Default",
            };
            DateTime mDia = mBannerAuxiliar.FechaInicio();
            TimeSpan mHora = mBannerAuxiliar.HoraInicio();

            var mConsulta = iControladorBanner.Queryable.Where(b => (
                (mDia >= b.FechaInicio() && mDia <= b.FechaFin())
                &&
                (mHora >= b.HoraInicio() && mHora <= b.HoraFin())
                &&
                (b.Activo == true)
            ));

            return mConsulta.Count() == 1 ? mConsulta.First(): mBannerAuxiliar;
        }
    }
}
