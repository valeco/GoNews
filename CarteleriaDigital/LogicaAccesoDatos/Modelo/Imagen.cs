using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace CarteleriaDigital.LogicaAccesoDatos.Modelo
{
    public class Imagen: IComparable<Imagen>
    {
        public int ImagenId { get; set; }
        public int Prioridad { get; set; }
        /// <summary>
        /// Obtiene el nombre del archivo
        /// </summary>
        public string Nombre
        {
            get { return Path.GetFileName(this.Ruta); }
        }
        public string Ruta { get; set; }

        /// <summary>
        /// Constructor solo valido para ser utilizado por EF
        /// </summary>
        public Imagen() { }

        /// <summary>
        /// Obtiene un objeto Imagen
        /// </summary>
        /// <param name="pPrioridad">Prioridad o orden de la imagen</param>
        /// <param name="pRuta">Ruta absoluta de la imagen</param>
        public Imagen(ushort pPrioridad, string pRuta) { this.Prioridad = pPrioridad; this.Ruta = pRuta; }

        /// <summary>
        /// Constructor que implementa la copia de una imagen
        /// </summary>
        /// <param name="pImg"></param>
        public Imagen(Imagen pImg)
        {
            this.ImagenId = pImg.ImagenId;
            this.Ruta = pImg.Ruta;
            this.Prioridad = pImg.Prioridad;
        }

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
