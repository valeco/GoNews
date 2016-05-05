using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

//Basado en el Control de Usuarios --> http://www.authorcode.com/image-gallery-in-your-windows-applciation-in-c/
namespace CarteleriaDigital.GUI
{
    public partial class GaleriaImagenes : UserControl
    {
        public GaleriaImagenes()
        {
            InitializeComponent();
        }

        ToolTip ttip = new ToolTip();
        string _Directory_Path = null;
        List<String> ListaImg = new List<String>();
        int CtrlWidth;
        int CtrlHeight;
        int PicWidth=150;
        int PicHeight=100;
        int XMargen = 10;
        int YMargen = 10;
        int XLocation=0;
        int YLocation=0;
        int i=0;
        bool labels = false;
        bool btnEliminar = false;
        Label iLabelSeleccionado = null;
        PictureBox iPBoxSeleccionado = null;
        Color iColorSeleccion = Color.Firebrick;

        private void GaleriaImagenes_Resize(object sender, EventArgs e)
        {
            CtrlHeight = this.Height;
            CtrlWidth = this.Width;
        }

        /// <summary>
        /// Obtener ruta del directorio actual y Cargar todas las imagenes(de formato valido) de un directorio
        /// </summary>
        public string Directorio
        {
            get { return _Directory_Path; }
            set {
                    try
                    { 
                        _Directory_Path = value;
                        ListaImg = new List<String>();
                        Crear();
                    }
                    catch (OutOfMemoryException exOut)
                    {
                        throw exOut;
                    }
                }
        }

        /// <summary>
        /// Obtener la lista de ruta de imagenes actual y Cargar todas las imagenes(de formato valido) de una Lista
        /// </summary>
        public List<string> ListaImagenes
        {
            get { return ListaImg; }
            set {
                    try
                    {
                        ListaImg = value;
                        _Directory_Path = null;
                        Crear();
                    }
                    catch (OutOfMemoryException exOut)
                    {
                        throw exOut;
                    }
                }
        }

        /// <summary>
        /// Obtener/Asignar ancho de imagenes dentro del componente. DEFAULT 150
        /// </summary>
        public int AnchoImagenes
        {
            get { return PicWidth; }
            set { PicWidth = value; }
        }

        /// <summary>
        /// Obtener/Asignar alto de imagenes dentro del componente. DEFAULT 100
        /// </summary>
        public int AltoImagenes
        {
            get { return PicHeight; }
            set { PicHeight = value; }
        }

        /// <summary>
        /// Obtener/Asignar margen horizontal entre imagenes dentro del componente. DEFAULT 10
        /// </summary>
        public int MargenXImagenes
        {
            get { return XMargen; }
            set { XMargen = value; }
        }

        /// <summary>
        /// Obtener/Asignar margenvertical entre imagenes dentro del componente. DEFAULT 10
        /// </summary>
        public int MargenYImagenes
        {
            get { return YMargen; }
            set { YMargen = value; }
        }

        /// <summary>
        /// Mostrar nombre de los archivos en pantalla . DEFAULT False
        /// </summary>
        public bool ShowLabels
        {
            get { return labels;  }
            set { labels = value;  }
        }

        /// <summary>
        /// Mostrar botones de eliminacion de fotos en pantalla . DEFAULT False
        /// </summary>
        public bool ShowDeleteButtons
        {
            get { return btnEliminar; }
            set { btnEliminar = value; }
        }

        /// <summary>
        /// Obtener/Asignar el color al seleccionar una imagen
        /// </summary>
        public Color ColorAlSeleccionar
        {
            get { return iColorSeleccion; }
            set { iColorSeleccion = value; }
        }

        private void DibujarPictureBox(string _filename, string _displayname)
        {try
            {
                PictureBox Pic1 = new PictureBox();
                Pic1.Location = new System.Drawing.Point(XLocation + XMargen, YLocation + YMargen);

                Pic1.Name = "PictureBox" + i;
                i++;
                Pic1.Size = new System.Drawing.Size(PicWidth, PicHeight);
                Pic1.TabIndex = 0;
                Pic1.TabStop = false;
                Pic1.BorderStyle = BorderStyle.None;
                this.ttip.SetToolTip(Pic1, _filename);
                Pic1.MouseEnter += Pic1_MouseEnter;
                Pic1.MouseLeave += Pic1_MouseLeave;
                Pic1.Click += Pic1_Click;
                Pic1.Image = Image.FromFile(_filename);
                Pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                this.Controls.Add(Pic1);

                Label lb = new Label();
                //Label en el que se muetra el nombre
                lb.Visible = labels;
                lb.Name = "Label" + Pic1.Name;
                lb.Text = _displayname;
                lb.BackColor = this.BackColor;
                lb.Location = new System.Drawing.Point(XLocation + XMargen, YLocation + YMargen + Pic1.Height);
                lb.Click += Lb_Click;
                this.Controls.Add(lb);

                //Label en el que se guarda la ruta
                Label lbFullName = new Label();
                lbFullName.Location = new System.Drawing.Point(XLocation + XMargen, YLocation + YMargen + Pic1.Height);
                lbFullName.Text = _filename;
                lbFullName.Visible = false;
                lbFullName.Name = "LabelFull" + Pic1.Name;
                this.Controls.Add(lbFullName);

                if (btnEliminar)
                {
                    //Boton para eliminar la imagen de la grilla
                    Button btn = new Button();
                    btn.Name = "btn" + Pic1.Name;
                    btn.Location = new System.Drawing.Point(XLocation + XMargen + 2, YLocation + YMargen + 2);
                    btn.Width = 15;
                    btn.Height = 15;
                    btn.Font = new Font(this.Font.Name, 6, FontStyle.Bold);
                    btn.TextAlign = ContentAlignment.TopCenter;
                    btn.Text = "X";
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Click += btn_Click;
                    this.Controls.Add(btn);
                    btn.BringToFront();
                    btn.Visible = true;
                }

                XLocation = XLocation + XMargen + PicWidth;
                if ((XLocation + XMargen + PicWidth) >= CtrlWidth)
                {
                    XLocation = 0;
                    YLocation = YLocation + YMargen + PicHeight + (labels ? lb.Height : 0);
                }
            }
            catch(Exception)
            {
                //REVISAR
            }
        }

        private void Crear()
        {
            if (i > 0)
            {
                QuitarControles();
                i = 0;
                XLocation = 0;
                YLocation = 0;
            }
            else
            {
                GaleriaImagenes_Resize(null, null);
            }



            if (this.Directorio != null && this.Directorio != string.Empty)
            {
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(Directorio);

                System.IO.FileInfo[] diar1 = di.GetFiles("*.jpg");
                System.IO.FileInfo[] diar2 = di.GetFiles("*.jpeg");
                System.IO.FileInfo[] diar3 = di.GetFiles("*.bmp");
                System.IO.FileInfo[] diar4 = di.GetFiles("*.png");
                System.IO.FileInfo[] diar5 = di.GetFiles("*.gif");

                var diarList = new List<System.IO.FileInfo>();
                diarList.AddRange(diar1);
                diarList.AddRange(diar2);
                diarList.AddRange(diar3);
                diarList.AddRange(diar4);
                diarList.AddRange(diar5);
                System.IO.FileInfo[] diar = diarList.ToArray();

                foreach (System.IO.FileInfo dra in diar)
                {
                    DibujarPictureBox(dra.FullName, dra.Name);
                }
            }
            else if(ListaImg!=null && ListaImg.Count > 0)
            {
                foreach(string img in ListaImg)
                {
                    string mImg = img.ToLower();
                    if(File.Exists(mImg) && (mImg.EndsWith(".jpg") || mImg.EndsWith(".jpeg") || mImg.EndsWith(".png") || mImg.EndsWith(".bmp") || mImg.EndsWith("gif") ))
                        DibujarPictureBox(mImg,Path.GetFileName(mImg));
                }
            }


        }

        private void Pic1_MouseEnter(System.Object sender, System.EventArgs e)
        {
            PictureBox Pic = default(PictureBox);
            Pic = (PictureBox)sender;
            Pic.BorderStyle = BorderStyle.None;
        }

        private void Pic1_MouseLeave(System.Object sender, System.EventArgs e)
        {
            PictureBox Pic = default(PictureBox);
            Pic = (PictureBox)sender;
            Pic.BorderStyle = BorderStyle.FixedSingle;
        }

        /// <summary>
        /// Evento a implementar para capturar el evento click sobre cualquier imagen dentro del control.
        /// Se envia en el "sender" un Diccionario con las keys "ruta" absoluta y "nombre" del archivo.
        /// </summary>
        public event EventHandler ImgClick;

        private void Pic1_Click(object sender, EventArgs e)
        {
            DeseleccionarImagen();

            Dictionary<string, string> dic = new Dictionary<string, string>();
            /* PictureBox Pic = default(PictureBox);
             Pic = (PictureBox)sender;
             foreach (Control ctrl in this.Controls)
             {
                 if (ctrl is Label)
                 {
                     if (ctrl.Name == "Label" + Pic.Name)
                         dic.Add("nombre", ctrl.Text);
                     else if (ctrl.Name == "LabelFull" + Pic.Name)
                         dic.Add("ruta", ctrl.Text);
                 }
             }*/
            dic.Add("nombre", ((Label)this.Controls.Find("Label"+((PictureBox)sender).Name, true)[0]).Text);
            dic.Add("ruta", ((Label)this.Controls.Find("LabelFull" + ((PictureBox)sender).Name, true)[0]).Text);

            if (ImgClick != null)
                ImgClick(dic, e);
        }

        private void Lb_Click(object sender, EventArgs e)
        {
            DeseleccionarImagen();

            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("nombre", ((Label)sender).Text);
            //"Label".Length = 5
            dic.Add("ruta", ((Label)this.Controls.Find("LabelFull" + ((Label)sender).Name.Substring(5), true)[0]).Text);

            if(ImgClick != null)
                ImgClick(dic, e);
        }

        /// <summary>
        /// Evento a implementar para capturar el evento click sobre cualquier boton eliminar dentro de una imagen, luego de haber sacado la misma del componente.
        /// Se envia en el "sender" un Diccionario con las keys "ruta" absoluta y "nombre" del archivo.
        /// </summary>
        public event EventHandler ImgDeleteClick;

        private void btn_Click(object sender, EventArgs e)
        {
            DeseleccionarImagen();

            Button btn = (Button)sender;
            //Obtengo el ID del nombre del boton, para eliminar en la lista
            int longitud = (btn.Name.Length - 1);
            int aux;
            string num = "";
            for (int i = longitud; i >= 0; i--)
                if (int.TryParse(btn.Name[i].ToString(), out aux))
                    num = btn.Name[i].ToString() + num;
                else
                    break;

            aux = int.Parse(num);
            ListaImagenes.RemoveAt(aux);


            Dictionary<string, string> dic = new Dictionary<string, string>();
            //"btn".Length=3
            dic.Add("nombre", ((Label)this.Controls.Find("Label" + (btn.Name.Substring(3)), true)[0]).Text);
            dic.Add("ruta", ((Label)this.Controls.Find("LabelFull" + (btn.Name.Substring(3)), true)[0]).Text);

            this.Crear();

            if (ImgDeleteClick != null)
                ImgDeleteClick(dic, e);
        }


        private void QuitarControles()
        {
            Again:
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is PictureBox || ctrl is Label || ctrl is Button)
                {
                    ctrl.Dispose();
                    this.Controls.Remove(ctrl);
                }
            }
            if (this.Controls.Count > 0)
            {
                goto Again;
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void GaleriaImagenes_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Seleccionar una imagen dentro del componente, a partir del nombre de la misma
        /// </summary>
        /// <param name="pRutaImagen"></param>
        public void SeleccionarImagen( string pRutaImagen)
        {
            int mIndice = -1;
            for (int i = 0; i < this.ListaImagenes.Count; i++)
                if (this.ListaImagenes.ElementAt(i).ToLower() == pRutaImagen.ToLower())
                    mIndice = i;
            if (mIndice >= 0)
            {
                DeseleccionarImagen();
                iPBoxSeleccionado = (PictureBox)this.Controls.Find("PictureBox" + mIndice.ToString() , true)[0];
                iPBoxSeleccionado.Focus();
                if (this.labels)
                {
                    iLabelSeleccionado = (Label)this.Controls.Find("LabelPictureBox" + mIndice.ToString(), true)[0];
                    iLabelSeleccionado.BackColor = Color.Firebrick;
                    iLabelSeleccionado.Focus();
                }
            }
        }

        private void DeseleccionarImagen()
        {
            if(iPBoxSeleccionado != null && labels)
            {
                iLabelSeleccionado.BackColor = this.BackColor;
            }
        }

    }
}