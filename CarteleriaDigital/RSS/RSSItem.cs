using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarteleriaDigital.RSS
{
    /// <summary>
    /// Objeto donde mantener la informacion de los items rss.
    /// </summary>
    public class RssItem
    {
        string iTitulo, iDescripcion;
        Uri iLink;
        DateTime iFecha;

        /// <summary>
        /// Devuelve un item del feed Rss
        /// </summary>
        /// <param name="pTitulo">Titulo del item</param>
        /// <param name="pDescripcion">Descripcion del item</param>
        /// <param name="pFecha">Fecha en la que se lo realizo</param>
        /// <param name="pLink">Link hacia la noticia</param>
        public RssItem (string pTitulo ,string pDescripcion ,DateTime pFecha ,Uri pLink)
        {
            iTitulo = pTitulo;
            iDescripcion = pDescripcion;
            iFecha = pFecha;
            iLink = pLink;
        }

        #region Propiedades
            /// <summary>
            /// Fecha de Publicacion.
            /// </summary>
            public DateTime Fecha { get {return iFecha;} }

            /// <summary>
            /// Titulo
            /// </summary>
            public string Titulo { get { return iTitulo; } }

            /// <summary>
            /// Descripcion
            /// </summary>
            public string Descripcion { get { return iDescripcion; } }

            /// <summary>
            /// Link de la noticia
            /// </summary>
            public string Link { get { return iLink.ToString(); } }
        #endregion
    }
}
