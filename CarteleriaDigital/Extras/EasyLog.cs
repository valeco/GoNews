using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;//Para el StreamReader
using System.IO;//Excepciones del filesystem

namespace CarteleriaDigital.Extras
{
    class EasyLog
    {
        string iRutaArchivo = String.Empty;
        List<string> iLineas= new List<string>();

        /// <summary>
        /// Genera una instancia de EasyLog
        /// </summary>
        /// <param name="pRutaArchivo">Ruta del archivo donde escribir</param>
        public EasyLog( string pRutaArchivo )
        {
            if (String.IsNullOrWhiteSpace(pRutaArchivo))//vacia, nula o unicamente consta del espacio en blanco
                throw new ArgumentNullException("iRutaArchivo", "La ruta del archivo no debe de ser vacia.");

            string mRutaDirectorio = pRutaArchivo.Substring(0, (pRutaArchivo.LastIndexOf("\\") != -1) ?
                                            pRutaArchivo.LastIndexOf("\\") :
                                            pRutaArchivo.Length);

            if (!FileSystem.DirectoryExists(mRutaDirectorio))
                throw new DirectoryNotFoundException("La ruta de arhcivo(" + mRutaDirectorio + ") proporcionada no existe");


            iRutaArchivo = pRutaArchivo;
        }
        
        /// <summary>
        /// Genera linea con el formato para almacenar
        /// </summary>
        /// <param name="pLinea">Linea a formatear</param>
        /// <returns></returns>
        private string GenerarLinea (string pLinea)
        {
            return "[" + DateTime.Now.ToString() + " (" + Environment.MachineName + ")] " + pLinea;
        }

        /// <summary>
        /// Alamacenar una linea para su posterior persistencia
        /// </summary>
        /// <param name="pLinea">Mensaje a almacenar</param>
        public void Write(string pLinea)
        {
            iLineas.Add( this.GenerarLinea(pLinea) );
        }

        /// <summary>
        /// Persistir en disco la lista de lineas indicada
        /// </summary>
        /// <param name="pLista">Lista de lineas que se quiere persistir</param>
        private void Save(List<string> pLista)
        {
            StreamWriter pArchivo = new StreamWriter(iRutaArchivo, true, Encoding.UTF8);
            foreach (string linea in pLista)
            {
                pArchivo.WriteLine(linea);
            }
            pArchivo.Close();
        }

        /// <summary>
        /// Persistir en disco todas las lineas almacenadas
        /// </summary>
        public void Save()
        {
            this.Save(iLineas);
            iLineas.Clear();
        }

        /// <summary>
        /// Persistir en disco unicamente la linea indicada
        /// </summary>
        public void WriteAndSave(string pLinea)
        {
            List<string> pLista = new List<string>();
            pLista.Add( this.GenerarLinea(pLinea) );
            this.Save( pLista );
        }
    }
}
