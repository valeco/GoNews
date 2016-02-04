using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarteleriaDigital
{
    public class NotInternetAvailable : ApplicationException
    {
        /// <summary>
        /// Generar un error de coneccion a Internet
        /// </summary>
        /// <param name="pMensaje">Mensaje de la exepcion</param>
        public NotInternetAvailable(string pMensaje): 
            base ("No posee acceso a internet.\n\r" + pMensaje){}
    }
}
