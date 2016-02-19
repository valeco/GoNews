using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CarteleriaDigital.LogicaAccesoDatos.Modelo
{
    public class Imagen: IComparable<Imagen>
    {
        public int ImagenId { get; set; }
        public ushort Prioridad { get; set; }
        public string Ruta { get; set; }

        /// <summary>
        /// Obtiene un objeto Imagen
        /// </summary>
        /// <param name="pPrioridad">Prioridad o orden de la imagen</param>
        /// <param name="pRuta">Ruta absoluta de la imagen</param>
        public Imagen(ushort pPrioridad, string pRuta) { this.Prioridad = pPrioridad; this.Ruta = pRuta; }

        /// <summary>
        /// Obtiene una Image a partir de la Ruta de la Imagen
        /// </summary>
        /// <returns></returns>
        public Image ObtenerImagen() { return Image.FromFile(Ruta); }

        public int CompareTo(Imagen pImagen)
        {
            return pImagen == null ? 1: this.Prioridad.CompareTo(pImagen.Prioridad);
        }
    }
}
