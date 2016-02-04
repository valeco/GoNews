using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing;

namespace CarteleriaDigital.Extras
{
    enum TipoFade { In, Out };
    class Utilidades
    {
        /// <summary>
        ///     Anima un label como una marquesina.
        /// </summary>
        /// <param name="pFormulario">Formulario que contiene al label.</param>
        /// <param name="pLabel">Label a animar.</param>
        /// <param name="pPaso">Velocidad con la que se desplaza el label. Por defecto: 1.</param>
        /// <param name="pDerechaAIzquierda">Sentido de desplazamiento del label. Por defecto: TRUE, de derecha a izquierda.</param>
        public static void Marquesina(Form pFormulario, Label pLabel, int pPaso = 1, bool pDerechaAIzquierda = true)
        {
            int mXLabel = pLabel.Location.X;
            int mYLabel = pLabel.Location.Y;
            int mAnchoLabel = pLabel.Width;
            int mAnchoForm = pFormulario.Width;

            if (pDerechaAIzquierda ? (mXLabel <= -mAnchoLabel) : (mXLabel >= mAnchoForm))
                pLabel.Location = new System.Drawing.Point((pDerechaAIzquierda ? mAnchoForm : -mAnchoLabel), mYLabel);
            else
                pLabel.Location = new System.Drawing.Point(mXLabel + (pDerechaAIzquierda ? -pPaso : pPaso), mYLabel);
        }

        /// <summary>
        ///     Realiza el efecto visual fade in/out sobre un formulario
        /// </summary>
        /// <param name="pForm">Formulario al que se le va aplicar el efecto</param>
        /// <param name="pTipo">Tipo de efecto fade</param>
        public static void Fade(Form pForm, TipoFade pTipo = TipoFade.In)
        {
            int mComienzo = (pTipo == TipoFade.In ? 0 : 100);
            int mTermina = (pTipo == TipoFade.In ? 100 : 0);
            int tIncremento = (pTipo == TipoFade.In ? 1 : -1);

            for (int i = mComienzo; (pTipo == TipoFade.In ? i < 100 : i > 0); i += tIncremento)
            {
                double opacidad = (i / 100.0);
                pForm.Opacity = opacidad;
                Esperar(25);
            }
        }

        /// <summary>
        ///     Obliga al programa a esperar X milisegundos
        /// </summary>
        /// <param name="milisegundos">Tiempo de espera</param>
        public static void Esperar(ushort milisegundos) { Thread.Sleep(milisegundos); }

        /// <summary>
        ///     Devuelve una lista con las rutas absolutas de las imagenes seleccionadas por el usuario
        /// </summary>
        /// <param name="pFormPerteneciente">Formulario del cual dependera</param>
        /// <param name="pTitulo">Titulo de la ventana</param>
        /// <returns>Lista con las rutas absolutas de las imagenes</returns>
        public static List<string> SeleccionarImagenes(Form pFormPerteneciente, string pTitulo)
        {
            List<string> mListaImg = new List<string>();
            OpenFileDialog mOFD = new OpenFileDialog();

            //Configuracion de la ventana de dialogo
            mOFD.Multiselect = true;
            mOFD.Title = pTitulo;
            mOFD.Filter = "Imagenes Validas (*.jpg; *.jpeg; *.png; *.gif *.bmp)| *.jpg; *.jpeg; *.png; *.gif *.bmp";

            if (mOFD.ShowDialog(pFormPerteneciente) == DialogResult.OK && mOFD.FileNames.Count() > 0)
                foreach (string img in mOFD.FileNames) { mListaImg.Add(img); }

            return mListaImg;
        }

        /// <summary>
        /// Obtiene la ruta absoluta desde donde se ejecuta el programa
        /// </summary>
        /// <returns>Cadena de texto con la ruta absoluta</returns>
        public static string RutaPrograma() { return Application.StartupPath + "\\"; }

        /// <summary>
        /// Copia una lista de rutas absoluta de archivos a una carpeta de destino generandoles un nombre nuevo
        /// </summary>
        /// <param name="pListaArchivos">Lista de rutas absolutas a archivos</param>
        /// <param name="pDirectorioDestino">Directorio de destino</param>
        /// <returns>Lista con las rutas absolutas al directorio destino con sus nuevos nombres</returns>
        public static List<String> CopiarArchivos(List<String> pListaArchivos, String pDirectorioDestino)
        {
            List<String> mListaArchivosCopiados = new List<String>();
            foreach (string archivoRuta in pListaArchivos)
            {
                FileInfo archivo = new FileInfo(archivoRuta);
                if (archivo.Exists)
                {
                    string nuevaRutaArchivo = pDirectorioDestino + DateTime.Now.Ticks.ToString() + archivo.Extension;
                    File.Copy(archivo.FullName, nuevaRutaArchivo);
                }
            }

            return mListaArchivosCopiados;
        }

        /// <summary>
        /// Se obtiene un valor ramdom dentro de un enumerado
        /// </summary>
        /// <typeparam name="T">Nombre del enumerado</typeparam>
        /// <returns>Elemento del enumerado</returns>
        public static T RandomEnumValue<T>()
        {
            var v = Enum.GetValues(typeof(T));
            return (T)v.GetValue(new Random().Next(v.Length));
        }

        //----------------------------------SLIDER INICIO--------------------------------------
        public enum EfectoSlider { Roll, Slide, Center};

        private static int[] dirmap = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        private static int[] effmap = { 0, 0x40000, 0x10, 0x80000 };
        [DllImport("user32.dll")]
        private static extern bool AnimateWindow(IntPtr handle, int msec, int flags);

        private static void AnimacionUnica(Control pCtrl, EfectoSlider pEfecto,int flags,int msec, int angulo)
        {
            if (pCtrl.Visible)
            {
                flags |= 0x10000;
                angulo += 180;
            }
            else if (pCtrl.TopLevelControl == pCtrl)
            {
                    flags |= 0x20000;
            }

            flags |= dirmap[(angulo % 360) / 45];

            bool ok = AnimateWindow(pCtrl.Handle, msec, flags);
            if (!ok)
                throw new Exception("Animacion fallida");
            pCtrl.Visible = !pCtrl.Visible;
        }

        /// <summary>
        /// Anima la transicion de imagenes en un picture box.
        /// </summary>
        /// <param name="pPBox">Picturbox al que se le aplica el efecto</param>
        /// <param name="pEfectoSalida">Efecto de salida de la imagen actual</param>
        /// <param name="pEfectoEntrada">Efecto de entrada de la imagen siguiente</param>
        /// <param name="pImagenSig">Imagen a continuacion</param>
        public static void AnimacionSlider(PictureBox pPBox, EfectoSlider pEfectoSalida, EfectoSlider pEfectoEntrada, Image pImagenSig)
        {
            //www.youtube.com/watch?v=yIVyrPXpgE0 ejemplo para cualquier control
            //Se l adapto unicamente para picture box
            int flagSalida = effmap[(int)pEfectoSalida];
            int flagEntrada = effmap[(int)pEfectoEntrada];
            int anguloSalida = (new Random()).Next(0, 360);
            int anguloEntrada = (new Random()).Next(0, 360);

            AnimacionUnica(pPBox,pEfectoSalida,flagSalida,250,anguloSalida);
            pPBox.Image = pImagenSig;
            AnimacionUnica(pPBox, pEfectoEntrada, flagEntrada, 250, anguloEntrada);
        }

        public static void AnimacionSlider(PictureBox pPBox,Image pImgSiguiente)
        {
            AnimacionSlider(pPBox, RandomEnumValue<Utilidades.EfectoSlider>(), 
                            RandomEnumValue<Utilidades.EfectoSlider>(), pImgSiguiente);
        }
        //----------------------------------SLIDER FIN--------------------------------------

        /// <summary>
        /// Muestra un inputbox y devuelve lo escrito por el usuario
        /// </summary>
        /// <typeparam name="T">Tipo de devolucion de dato</typeparam>
        /// <param name="pTitulo">Titulo del input</param>
        /// <param name="pMensaje">Mensaje del input</param>
        /// <param name="pValorPorDefecto">Valor predefinido para el input</param>
        /// <returns>Dato del usuario en el formato indicado</returns>
        /// <exception cref="System.FormatException">Lanzado cuando el formato deseado no es compatible con los datos introducidos por el usuario</exception>
        public static T InputBox <T>(string pTitulo, string pMensaje, string pValorPorDefecto)
        {
            return (T) Convert.ChangeType( Microsoft.VisualBasic.Interaction.InputBox(pMensaje,pTitulo,pValorPorDefecto) ,typeof(T) );
        }

        /// <summary>
        /// Obtiene el resultado de un mensaje de error estandar de la aplicacion
        /// </summary>
        /// <param name="pFrmResponsable">Formulario propietario del mensaje</param>
        /// <param name="pTitulo">Titulo del mensaje</param>
        /// <param name="pDescripcion">Descripcion detallada del mensaje</param>
        /// <param name="pOkOnly">Mostrar solo el boton OK true o OK/Cancel flase</param>
        /// <returns>Resultado del dialogo</returns>
        public static DialogResult MensajeError( Form pFrmResponsable, string pTitulo, string pDescripcion, bool pOkOnly  = true)
        {
            return MessageBox.Show(pFrmResponsable, pTitulo, pDescripcion, (pOkOnly? MessageBoxButtons.OK: MessageBoxButtons.OKCancel),MessageBoxIcon.Error);
        }

        /// <summary>
        /// Obtiene el resultado de un mensaje de advertencia estandar de la aplicacion
        /// </summary>
        /// <param name="pFrmResponsable">Formulario propietario del mensaje</param>
        /// <param name="pTitulo">Titulo del mensaje</param>
        /// <param name="pDescripcion">Descripcion detallada del mensaje</param>
        /// <param name="pOkOnly">Mostrar solo el boton OK true o OK/Cancel flase</param>
        /// <returns>Resultado del dialogo</returns>
        public static DialogResult MensajeAdvertencia(Form pFrmResponsable, string pTitulo, string pDescripcion, bool pOkOnly = true)
        {
            return MessageBox.Show(pFrmResponsable, pTitulo, pDescripcion, (pOkOnly ? MessageBoxButtons.OK : MessageBoxButtons.OKCancel), MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Obtiene el resultado de un mensaje de exito estandar de la aplicacion
        /// </summary>
        /// <param name="pFrmResponsable">Formulario propietario del mensaje</param>
        /// <param name="pTitulo">Titulo del mensaje</param>
        /// <param name="pDescripcion">Descripcion detallada del mensaje</param>
        /// <param name="pOkOnly">Mostrar solo el boton OK true o OK/Cancel flase</param>
        /// <returns>Resultado del dialogo</returns>
        public static DialogResult MensajeExito(Form pFrmResponsable, string pTitulo, string pDescripcion, bool pOkOnly = true)
        {
            return MessageBox.Show(pFrmResponsable, pTitulo, pDescripcion, (pOkOnly ? MessageBoxButtons.OK : MessageBoxButtons.OKCancel), MessageBoxIcon.Warning);
        }

        //----------------------------------Place Holder INICIO--------------------------------------
        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);

        /// <summary>
        /// Mostrar un texto como place holder en un textbox
        /// </summary>
        /// <param name="pTBox"></param>
        /// <param name="pCadena"></param>
        public static void PlaceHolder(TextBox pTBox, string pCadena)
        {
            Utilidades.SendMessage(pTBox.Handle, EM_SETCUEBANNER, 0, pCadena);
        }
        //----------------------------------Place Holder FIN--------------------------------------

        /// <summary>
        /// Encriptar una cadena con el hash MD5
        /// </summary>
        /// <param name="pCadena">Cadena a encriptar</param>
        /// <returns></returns>
        public static string md5(string pCadena)
        {
            //Declaraciones
            System.Security.Cryptography.MD5 md5;
            md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();

            //Conversion
            Byte[] encodedBytes = md5.ComputeHash(ASCIIEncoding.Default.GetBytes( pCadena )); 
            //genero el hash a partir de la password original

            //Resultado

            //return BitConverter.ToString(encodedBytes);      //esto, devuelve el hash con "-" cada 2 char
            return System.Text.RegularExpressions.Regex.Replace(BitConverter.ToString(encodedBytes).ToLower(), @"-", "");
            //devuelve el hash continuo y en minuscula. (igual que en php)
        }
    }
}

