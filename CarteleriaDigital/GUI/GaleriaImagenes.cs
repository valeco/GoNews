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

        private void GaleriaImagenes_Resize(object sender, EventArgs e)
        {
            CtrlHeight = this.Height;
            CtrlWidth = this.Width;
        }

        public string Directorio
        {
            get { return _Directory_Path; }
            set { _Directory_Path = value; ListaImg = new List<String>(); Crear(); }
        }

        public List<string> ListaImagenes
        {
            get { return ListaImg; }
            set { ListaImg = value; _Directory_Path =null; Crear(); }
        }

        public int AnchoImagenes
        {
            get { return PicWidth; }
            set { PicWidth = value; }
        }

        public int AltoImagenes
        {
            get { return PicHeight; }
            set { PicHeight = value; }
        }

        public int MargenXImagenes
        {
            get { return XMargen; }
            set { XMargen = value; }
        }

        public int MargenYImagenes
        {
            get { return YMargen; }
            set { YMargen = value; }
        }

        public bool ShowLabels
        {
            get { return labels;  }
            set { labels = value;  }
        }

        private void DibujarPictureBox(string _filename, string _displayname)
        {
            PictureBox Pic1 = new PictureBox();
            Pic1.Location = new System.Drawing.Point(XLocation + XMargen, YLocation + YMargen);        
           
            Pic1.Name = "PictureBox" + i;
            i ++;
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


            XLocation = XLocation + XMargen + PicWidth;
            if ((XLocation + XMargen + PicWidth) >= CtrlWidth)
            {
                XLocation = 0;
                YLocation = YLocation + YMargen + PicHeight + (labels?lb.Height:0);
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
                    if(File.Exists(img) && (img.EndsWith(".jpg") || img.EndsWith(".jpeg") || img.EndsWith(".png") || img.EndsWith(".bmp") || img.EndsWith("gif") ))
                        DibujarPictureBox(img,Path.GetFileName(img));
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

        public event EventHandler ImgClick;

        private void Pic1_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            PictureBox Pic = default(PictureBox);
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
            }
            ImgClick(dic, e);
        }

        private void Lb_Click(object sender, EventArgs e)
        {
            Label lb = default(Label);
            lb = (Label)sender;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("nombre", lb.Text);

            Label lbFull = default(Label);
            lbFull = (Label) Controls.Find(lb.Name.Replace("Label", "LabelFull"),false)[0];
            dic.Add("ruta",lbFull.Text);

            ImgClick(dic, e);
        }

        private void QuitarControles()
        {
            Again:
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is PictureBox || ctrl is Label)
                {
                    this.Controls.Remove(ctrl);
                }
            }
            if (this.Controls.Count > 0)
            {
                goto Again;
            }
        }

    }
}