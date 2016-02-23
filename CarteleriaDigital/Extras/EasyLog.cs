using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;//Para el StreamReader
using System.IO;//Excepciones del filesystem

namespace CarteleriaDigital.Extras
{    
    public class EasyLog
    {
        private enum TipoEscritura { INFO, ERROR, Debug }

        bool iDebugMode;
        string iRutaArchivo = String.Empty;
        List<string> iLineas= new List<string>();

        /// <summary>
        /// Genera una instancia de EasyLog
        /// </summary>
        /// <param name="pRutaArchivo">Ruta del archivo donde escribir</param>
        /// <param name="pDebugMode">Activar o desactivar la escritura en modo Debug</param>
        public EasyLog( string pRutaArchivo, Boolean pDebugMode = true)
        {
            if (String.IsNullOrWhiteSpace(pRutaArchivo))//vacia, nula o unicamente consta del espacio en blanco
                throw new ArgumentNullException("iRutaArchivo", "La ruta del archivo no debe de ser vacia.");

            string mRutaDirectorio = pRutaArchivo.Substring(0, (pRutaArchivo.LastIndexOf("\\") != -1) ?
                                            pRutaArchivo.LastIndexOf("\\") :
                                            pRutaArchivo.Length);

            if (!FileSystem.DirectoryExists(mRutaDirectorio))
                throw new DirectoryNotFoundException("La ruta de arhcivo(" + mRutaDirectorio + ") proporcionada no existe");

            iDebugMode = pDebugMode;
            iRutaArchivo = pRutaArchivo;
        }

        /// <summary>
        /// Activar o desactivar la escritura al Log en modo Debug
        /// </summary>
        public bool DebugMode
        {
            get { return iDebugMode; }
            set { iDebugMode = value; }
        }

        /// <summary>
        /// Genera linea con el formato para almacenar
        /// </summary>
        /// <param name="pLinea">Linea a formatear</param>
        /// <param name="pEscritura">Modo de escritura</param>
        /// <returns>Cadena con el formato esperado</returns>
        private string GenerarLinea (string pLinea, TipoEscritura pEscritura)
        {
            return pEscritura.ToString() + ":[" + DateTime.Now.ToString() + " (" + Environment.MachineName + ")] " + pLinea;
        }

        /// <summary>
        /// Alamacenar una linea para su posterior persistencia
        /// </summary>
        /// <param name="pLinea">Mensaje a almacenar</param>
        /// <param name="pEscritura">Modo de escritura</param>
        private void Write(string pLinea, TipoEscritura pEscritura = TipoEscritura.INFO)
        {
            iLineas.Add( this.GenerarLinea(pLinea, pEscritura) );
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
        /// Persistir en disco unicamente la linea indicada
        /// </summary>        
        /// <param name="pLinea">Mensaje a almacenar</param>
        /// <param name="pEscritura">Modo de escritura</param>
        private void WriteAndSave(string pLinea, TipoEscritura pEscritura = TipoEscritura.INFO)
        {
            this.Save( new List<string> {this.GenerarLinea(pLinea, pEscritura)} );
        }

        /// <summary>
        /// Persistir en disco todas las lineas aun no almacenadas en disco.(Las que aplican sin persistencia automatica)
        /// </summary>
        public void Save()
        {
            this.Save(this.iLineas);
            iLineas.Clear();
        }

        /// <summary>
        /// Generar linea al Log de tipo Info
        /// </summary>
        /// <param name="pCadena">Cadena que se quiere persistir</param>
        /// <param name="pPersistirAutomaticamente">Guardado automatico o posterior con el comando con .Save() por el usuario </param>
        public void Info (string pCadena, bool pPersistirAutomaticamente = true)
        {
            if(pPersistirAutomaticamente)
            { this.WriteAndSave(pCadena); }//Por defecto se guarda como tipo INFO
            else
            { this.Write(pCadena); }//Por defecto se guarda como tipo INFO
        }

        /// <summary>
        /// Generar linea al Log de tipo Error
        /// </summary>
        /// <param name="pCadena">Cadena que se quiere persistir</param>
        /// <param name="pPersistirAutomaticamente">Guardado automatico o posterior luego por el usuario con .Save()</param>
        public void Error(string pCadena, bool pPersistirAutomaticamente = true)
        {
            if (pPersistirAutomaticamente)
            { this.WriteAndSave(pCadena, TipoEscritura.ERROR); }
            else
            { this.Write(pCadena); }
        }

        /// <summary>
        /// Generar linea al Log de tipo Debug, si el Log esta en ModoDebug -> False no se genera.
        /// </summary>
        /// <param name="pCadena">Cadena que se quiere persistir</param>
        /// <param name="pPersistirAutomaticamente">Guardado automatico o posterior luego por el usuario con .Save()</param>
        public void Debug(string pCadena, bool pPersistirAutomaticamente = true)
        {
            if (pPersistirAutomaticamente)
            { this.WriteAndSave(pCadena, TipoEscritura.Debug); }
            else
            { this.Write(pCadena, TipoEscritura.Debug); }
        }
    }
}
