using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CarteleriaDigital.LogicaAccesoDatos.Modelo
{
    public class Campaña: Publicidad
    {
        int iContador = 0;

        //public int CampañaId { get; set; }
        public virtual List<Imagen> ListaImagenes { get; set; }

        /// <summary>
        /// Devuelve la imagen que se debe mostrar a continuacion
        /// </summary>
        /// <returns>Devuelve una instancia de objeto Image</returns>
        public Image ProximaImagen()
        {
            if (ListaImagenes.Count() != 0)
            {
                iContador = (iContador == (this.ListaImagenes.Count() - 1)) ? 0 : iContador + 1;
                return this.ListaImagenes.ElementAt(iContador).ObtenerImagen();
            }
            else
            {
                //Se devuelve imagen por defecto en caso que la lista este vacia
                return global::CarteleriaDigital.Properties.Resources._campaña_gonews;
            }
        }

        /// <summary>
        /// Obtiene una instancia de Campaña
        /// </summary>
        public Campaña() {}
    }
}
