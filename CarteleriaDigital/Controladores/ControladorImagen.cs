using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarteleriaDigital.LogicaAccesoDatos;
using CarteleriaDigital.LogicaAccesoDatos.Modelo;

namespace CarteleriaDigital.Controladores
{
    public class ControladorImagen
    {
        private UnidadDeTrabajo iUnidadDeTrabajo = UnidadDeTrabajo.Instancia;

        /// <summary>
        ///     Inserta una imagen en el repositorio.
        /// </summary>
        /// <param name="pImg">Imagen a insertar.</param>
        public void Insertar(Imagen pImg)
        {
            iUnidadDeTrabajo.RepositorioImagen.Insertar(pImg);
            iUnidadDeTrabajo.Guardar();
        }

        /// <summary>
        ///     Modificar una Imagen en el repositorio.
        /// </summary>
        /// <param name="pImg">Imagen a modificar.</param>
        public void Modificar(Imagen pImg)
        {
            iUnidadDeTrabajo.RepositorioImagen.Modificar(pImg);
            iUnidadDeTrabajo.Guardar();
        }

        /// <summary>
        ///     Elimina una Imagen del repositorio.
        /// </summary>
        /// <param name="pImg">Imagen a eliminar.</param>
        public void Eliminar(Imagen pImg)
        {
            Imagen mImagen = iUnidadDeTrabajo.RepositorioImagen.ObtenerPorId(pImg.ImagenId);
            iUnidadDeTrabajo.RepositorioImagen.Eliminar(mImagen);
            iUnidadDeTrabajo.Guardar();
        }

        /// <summary>
        ///     Obtiene una Imagen del repositorio correspondiente al ID proporcionado.
        /// </summary>
        /// <param name="pImg">ID de la Imagen.</param>
        /// <returns>Una Imagen.</returns>
        public Imagen ObtenerPorId(int pImgId)
        {
            return iUnidadDeTrabajo.RepositorioImagen.ObtenerPorId(pImgId);
        }
    }
}
