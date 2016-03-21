using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.VisualBasic.FileIO;//Para el StreamReader

namespace CarteleriaDigital.Extras
{
    class LecturaArchivoTexto: IDisposable 
    {
        StreamReader iArchivo;
        string iRutaArchivo;
        bool iDisposed;

        /// <summary>
        /// Genera un objeto de lectura para un archivo de texto
        /// </summary>
        /// <param name="iRutaArchivo">Ruta del archivo</param>
        public LecturaArchivoTexto(string pRutaArchivo)
        {
            iRutaArchivo = pRutaArchivo;
            iDisposed = false;
        }

        /// <summary>
        /// Abrir el archivo para su posterior lectura
        /// </summary>
        public void Abrir ()
        {
                if (String.IsNullOrWhiteSpace(iRutaArchivo))//vacia, nula o unicamente consta del espacio en blanco
                    throw new ArgumentNullException("iRutaArchivo","La ruta del archivo no debe de ser vacia.");

                string mRutaDirectorio = iRutaArchivo.Substring(0, (iRutaArchivo.LastIndexOf("\\")!=-1)? 
                                                iRutaArchivo.LastIndexOf("\\") :
                                                iRutaArchivo.Length);
                if(! FileSystem.DirectoryExists( mRutaDirectorio ))
                    throw new DirectoryNotFoundException("La ruta de arhcivo("+ mRutaDirectorio +") proporcionada no existe");

                if (! FileSystem.FileExists( iRutaArchivo ))
                    throw new FileNotFoundException("iRutaArchivo","El arhcivo indicado ("+ iRutaArchivo +") no existe");


                iArchivo = new StreamReader(iRutaArchivo);

        }

        /// <summary>
        /// Permite leer la proxima linea del archivo
        /// </summary>
        /// <returns>Devuelve la linea como cadena o null si ya no hay mas lineas que leer</returns>
        public string ProximaLinea()
        {
            return (! iArchivo.EndOfStream )? iArchivo.ReadLine() : null;
        }

        /// <summary>
        /// Permite cerrar la coneccion
        /// </summary>
        public void Cerrar()
        {
            this.iArchivo.Close();
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
                this.Cerrar();
                this.iArchivo.Dispose();
                this.iRutaArchivo = String.Empty;
                iDisposed = true;
            }
        }
    }
}
