using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.VisualBasic.FileIO;//Para el StreamReader

namespace CarteleriaDigital.Extras
{
    class EscrituraArchivoTexto: IDisposable 
    {
        string iRutaArchivo;
        List<string> iLineas = new List<string>();
        bool iDisposed;

        /// <summary>
        /// Genera un objeto de lectura para un archivo de texto
        /// </summary>
        /// <param name="iRutaArchivo">Ruta del archivo</param>
        public EscrituraArchivoTexto(string pRutaArchivo)
        {
            if (String.IsNullOrWhiteSpace(pRutaArchivo))//vacia, nula o unicamente consta del espacio en blanco
                throw new ArgumentNullException("iRutaArchivo", "La ruta del archivo no debe de ser vacia.");

            string mRutaDirectorio = pRutaArchivo.Substring(0, (pRutaArchivo.LastIndexOf("\\") != -1) ?
                                            pRutaArchivo.LastIndexOf("\\") :
                                            pRutaArchivo.Length);

            if (!FileSystem.DirectoryExists(mRutaDirectorio))
                throw new DirectoryNotFoundException("La ruta de arhcivo(" + mRutaDirectorio + ") proporcionada no existe");

            iDisposed = false;
            iRutaArchivo = pRutaArchivo;
        }

        /// <summary>
        /// Agrega una linea al archivo.
        /// </summary>
        /// <param name="pLinea"></param>
        public void WriteLine(string pLinea)
        {
            iLineas.Add(pLinea);
        }

        /// <summary>
        /// Agrega una lista de lineas al archivo.
        /// </summary>
        /// <param name="pLineas">Lista de lineas</param>
        public void WriteLine(List<string> pLineas)
        {
            iLineas = iLineas.Concat<string>(pLineas).ToList();
        }

        /// <summary>
        /// Persistir en disco la lista de lineas 
        /// </summary>
        public void Save()
        {
            StreamWriter pArchivo = new StreamWriter(iRutaArchivo, true, Encoding.UTF8);
            foreach (string linea in iLineas)
            {
                pArchivo.WriteLine(linea);
            }
            pArchivo.Close();
        }


        /// <summary>
        /// Obtener la ruta del archivo
        /// </summary>
        public string Ruta
        {
            get {return iRutaArchivo;}
        }

        //https://msdn.microsoft.com/es-es/library/system.idisposable(v=vs.110).aspx
        /// <summary>
        /// Liberar recursos utilizados
        /// </summary>
        public void Dispose()
        { 
            Dispose(true);
            GC.SuppressFinalize(this);           
        }

        // Implementacion protegida del Patron Dispose, utilizable para heredar y sobre-escribir su accionar.
        protected virtual void Dispose(bool disposing)
        {
            if (iDisposed && disposing) {
                iLineas.Clear();
                this.iRutaArchivo = String.Empty;
                iDisposed = true;
            }
        }
    }
}
