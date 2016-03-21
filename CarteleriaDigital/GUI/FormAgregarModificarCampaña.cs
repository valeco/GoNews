using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarteleriaDigital.Extras;
using CarteleriaDigital.LogicaAccesoDatos.Modelo;
using CarteleriaDigital.Controladores;
using Microsoft.VisualBasic.FileIO;

namespace CarteleriaDigital.GUI
{
    public partial class FormAgregarModificarCampaña : Form
    {
        Campaña iCampaña = null;
        EasyLog iLogger;
        bool iAgregar;
        ControladorCampaña iCtrlCampaña = new ControladorCampaña();
        ControladorUsuario iCtrlUsuario = ControladorUsuario.Instancia;
        ControladorImagen iCtrlImg = new ControladorImagen();
        List<string> iListaRutaImagenes=new List<string>();

        private void galeria_imagen_click (object sender, EventArgs e)
        {
            try
            {
                //Sender es un diccionario que contiene el "nombre" y la "ruta"
                Dictionary<string, string> dic = ((Dictionary<string, string>)sender);
                List<Imagen> Lista = (List<Imagen>)dgridPrioridades.DataSource;
                bool mAgregarAlista = true;
                int mPrioridad = 0;
                int mIndice = 0;

                for (int i = 0; i < Lista.Count; i++)
                    if (Lista.ElementAt(i).Ruta.ToLower() == dic["ruta"].ToLower())
                    {
                        mIndice = i;
                        mPrioridad = Lista.ElementAt(i).Prioridad;
                        mAgregarAlista = false;
                        break;
                    }

                if (mAgregarAlista)
                {
                        Lista.Add(new Imagen((ushort)(dgridPrioridades.RowCount + 1), dic["ruta"])); 
                        Lista.Sort();
                        dgridPrioridades.DataSource = Lista.ToList<Imagen>();
                }
                else
                {
                    Utilidades.MensajeAdvertencia(this, "ATENCION", "Esta imagen ya tiene una prioridad asignada ("+mPrioridad.ToString()+").");
                    dgridPrioridades.Rows[mIndice].Selected = true;
                }
            }
            catch (FormatException)
            {
                Utilidades.MensajeAdvertencia(this, "ATENCION", "El valor ingresado no es un numero entero mayor a 0 (cero).");
            }
            catch (Exception ex)
            {
                iLogger.Error(ex.Source + ": " + ex.Message);
                Utilidades.MensajeError(this, "¡Error!", "Ocurrió un error inesperado.");
            }
        }

        private void galeria_imagen_delete_click(object sender, EventArgs e)
        {
            try
            {
                //Sender es un diccionario que contiene el "nombre" y la "ruta"
                Dictionary<string, string> dic = ((Dictionary<string, string>)sender);
                List<Imagen> Lista = (List<Imagen>)dgridPrioridades.DataSource;
                for (int i = 0; i < Lista.Count; i++)
                    if (Lista.ElementAt(i).Ruta.ToLower() == dic["ruta"].ToLower())
                    {
                        dgridPrioridades.Rows[i].Selected = true;
                        this.AccionesConLaPrioridad("Del");
                        break;
                    }
            }
            catch (Exception ex)
            {
                iLogger.Error(ex.Source + ": " + ex.Message);
                Utilidades.MensajeError(this, "¡Error!", "Ocurrió un error inesperado.");
            }
        }

        public FormAgregarModificarCampaña(EasyLog pLogger, int pIdCampaña)
        {
            InitializeComponent();

            iLogger = pLogger;

            if (pIdCampaña > 0)
            {
                iCampaña = iCtrlCampaña.ObtenerPorId(pIdCampaña);
                lbTitulo.Text = "Modificar campaña";
                iAgregar = false;
            }
            else
            {
                lbTitulo.Text = "Agregar Campaña";
                iAgregar = true;
            }

            iLogger.Info("Initialize form AgregarModificarCampaña finalizado.");
        }

        private void pboxMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pboxCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbarIntervalo_Scroll(object sender, EventArgs e)
        {
            lbValorIntervalo.Text = tbarIntervalo.Value.ToString() + " seg.";
        }

        private void FormAgregarModificarCampaña_Load(object sender, EventArgs e)
        {
            Utilidades.AllTextBoxPlaceHolder(this);

            galeria.AltoImagenes = 70;
            galeria.AnchoImagenes = 100;
            galeria.MargenXImagenes = 20;
            galeria.MargenYImagenes = 10;
            galeria.ForeColor = Color.WhiteSmoke;
            galeria.ColorAlSeleccionar = Color.Firebrick;
            galeria.ShowLabels = true;
            galeria.AutoScroll = true;
            galeria.ShowDeleteButtons = true;
            galeria.ImgClick += new System.EventHandler(this.galeria_imagen_click);
            galeria.ImgDeleteClick += new System.EventHandler(this.galeria_imagen_delete_click);

            dgridPrioridades.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dgridPrioridades.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;
            dgridPrioridades.AutoGenerateColumns = true;
            dgridPrioridades.DataSource = new List<Imagen>();
            dgridPrioridades.Columns["ImagenId"].Visible = false;
            dgridPrioridades.Columns["Ruta"].Visible = false;
            dgridPrioridades.Columns["Prioridad"].Width = 50;

            ToolTip ttip = new ToolTip();
            ttip.SetToolTip(btnBajarPrioridad, "Bajar Prioridad");
            ttip.SetToolTip(btnSubirPrioridad, "Subir Prioridad");
            ttip.SetToolTip(btnEliminarPrioridad, "Eliminar Prioridad");
            ttip.SetToolTip(btnQuitarCompletamente, "Quitar Imagen (y su Prioridad) del Espacio de Trabajo");

            if (!iAgregar)
            {
                txtNombreCampaña.Text = iCampaña.Nombre;
                tbarIntervalo.Value = iCampaña.ListaImagenes.Count()==1? tbarIntervalo.Minimum: iCampaña.IntervaloEnSeg;
                dtpFechaInicio.Value = iCampaña.FechaInicio;
                dtpFechaFin.Value = iCampaña.FechaFin;

                dtpHoraInicio.Value = new DateTime(DateTime.Today.Year,
                                                   DateTime.Today.Month,
                                                   DateTime.Today.Day,
                                                   iCampaña.HoraInicio.Hours,
                                                   iCampaña.HoraInicio.Minutes,0);

                dtpHoraFin.Value = new DateTime(DateTime.Today.Year,
                                                DateTime.Today.Month,
                                                DateTime.Today.Day,
                                                iCampaña.HoraFin.Hours,
                                                iCampaña.HoraFin.Minutes,0);
                dgridPrioridades.DataSource = iCampaña.ListaImagenes.ToList();
                foreach (Imagen item in iCampaña.ListaImagenes)
                    iListaRutaImagenes.Add(item.Ruta);
                iListaRutaImagenes.Sort();
                galeria.ListaImagenes = iListaRutaImagenes;
            }
            else
            {
                dtpFechaInicio.MinDate = DateTime.Today;
                dtpFechaInicio.Value = DateTime.Today;

                dtpFechaFin.MinDate = DateTime.Today;
                dtpFechaFin.Value = DateTime.Today;
            }

            iLogger.Info("Load form AgregarModificarCampaña finalizado.");
        }

        private void FormAgregarModificarCampaña_FormClosing(object sender, FormClosingEventArgs e)
        {
            iLogger.Info("Cerrando form AgregarModificarCampaña");
            iLogger.Save();
        }

        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            //Al seleccionar la fecha inicio se re adapta el minimo de la de fin y su fecha seleccionada
            dtpFechaFin.MinDate = dtpFechaInicio.Value.Date;
            if (dtpFechaInicio.Value > dtpFechaFin.Value)
                dtpFechaFin.Value = dtpFechaInicio.Value;
        }

        private void tbarIntervalo_ValueChanged(object sender, EventArgs e)
        {
            this.tbarIntervalo_Scroll(null, null);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Campaña mCampaña = new Campaña()
            {
                FechaInicio = dtpFechaInicio.Value.Date,
                HoraInicio = dtpHoraInicio.Value.TimeOfDay,
                FechaFin = dtpFechaFin.Value.Date,
                HoraFin = dtpHoraFin.Value.TimeOfDay
            };
            List<string> listaGaleria = galeria.ListaImagenes;

            if (txtNombreCampaña.Text == "")
            {
                Utilidades.MensajeError(this, "¡Atención!", "Debe ingresar un nombre para la campaña.");
                txtNombreCampaña.Focus();
            }
            else if (dtpFechaFin.Value < dtpFechaInicio.Value)
            {
                Utilidades.MensajeError(this, "¡Atención!", "La fecha de finalización de la campaña debe ser posterior a la de inicio.");
                dtpFechaFin.Focus();
            }
            else if (dtpHoraFin.Value <= dtpHoraInicio.Value)
            {
                Utilidades.MensajeError(this, "¡Atención!", "La hora en la que termina la campaña debe ser posterior a la de inicio.");
                dtpHoraFin.Focus();
            }
            else if (iAgregar && iCtrlCampaña.ExisteCampañaEnHorario(mCampaña))
            {
                Utilidades.MensajeError(this, "¡Atención!", "Existe otra campaña en ese horario. Elija otro momento del día en el cual mostrarla.");
                dtpHoraInicio.Focus();
            }
            else if(dgridPrioridades.Rows.Count == 0)
                Utilidades.MensajeError(this, "¡Atención!", "Toda campaña debe constar de almenos 1 (una) imagen.");
            else
            {
                List<Campaña> mListaSolapamientos = null;
                int mSolapamientos = 0;
                if (!iAgregar)//Para optimizar tiempo, solo se consulta esto si se modifica
                {
                    mListaSolapamientos = iCtrlCampaña.ListaCampañasEnHorario(mCampaña);
                    mSolapamientos = mListaSolapamientos.Count;
                }

                if ( ((iCampaña==null)? false: iCampaña.Activo) && //Si no esta activo no se verifica los solapamientos, se lo haran en el formBuscar al querer activar
                     (
                        (!iAgregar && mSolapamientos > 1) ||
                        (!iAgregar && mSolapamientos == 1 && iCampaña.Id != mListaSolapamientos.ElementAt(0).Id)
                     )
                   )
                {
                    Utilidades.MensajeError(this, "¡Atención!", "Existe otra campaña en ese horario. Elija otro momento del día en el cual mostrarla.");
                    dtpHoraInicio.Focus();
                }
                else
                {
                    try
                    {
                        btnAceptar.Text = "Procesando...";
                        btnAceptar.Enabled = false;
                        galeria.ListaImagenes = new List<string>();

                        List<Imagen>  mListaImagenes = (List<Imagen>)dgridPrioridades.DataSource;
                        if (iAgregar)
                            iCampaña = new Campaña();
                        else
                            iCampaña = iCtrlCampaña.ObtenerPorId(iCampaña.Id);

                        iCampaña.Nombre = txtNombreCampaña.Text;                      
                        iCampaña.FechaInicio = dtpFechaInicio.Value.Date;
                        iCampaña.FechaFin = dtpFechaFin.Value.Date;
                        iCampaña.HoraInicio = dtpHoraInicio.Value.TimeOfDay;
                        iCampaña.HoraFin = dtpHoraFin.Value.TimeOfDay;

                        string mRuta = Utilidades.RutaPrograma();

                        //En caso de modificar o agregar, si hay imagenes nuevas, se copian a la carpeta y se les asigna su nueva ruta        
                        for (int i = 0; i < (mListaImagenes.Count); i++)
                        {
                            Imagen mImg = mListaImagenes.ElementAt(i);
                            if (! mImg.Ruta.StartsWith(mRuta))
                            {
                                string mRutaArchivoNueva = Utilidades.CopiarArchivos(new List<string>() {mImg.Ruta},
                                                                                        mRuta + "Imagenes\\").ElementAt(0);
                                mImg.Ruta = mRutaArchivoNueva;
                            }
                        }

                        
                        iCampaña.IntervaloEnSeg = (mListaImagenes.Count > 1)? tbarIntervalo.Value: 0;

                        if (iAgregar) //Agregar
                        {
                            iCampaña.ListaImagenes = mListaImagenes;
                            iCampaña.Activo = true;
                            iCtrlUsuario.UsuarioLogueado.ListaCampaña.Add(iCampaña);
                            iCtrlUsuario.Modificar(iCtrlUsuario.UsuarioLogueado);
                            Utilidades.MensajeExito(this, "¡Perfecto!", "Campaña agregada correctamente.");
                        }
                        else // Modificar
                        {
                            var mListaAux = iCampaña.ListaImagenes.ToList();
                            iCampaña.ListaImagenes = mListaImagenes;

                            iCtrlCampaña.Modificar(iCampaña);
                            this.EliminarImagenesBasura(mListaAux, mListaImagenes);
                            Utilidades.MensajeExito(this, "¡Perfecto!", "Campaña modificada correctamente.");
                        }
                        this.Close();
                        iLogger.Info("Campaña nueva/modificada insertada correctamente.");
                    }
                    catch (Exception ex)
                    {
                        iLogger.Error(ex.Source + ": " + ex.Message);
                        Utilidades.MensajeError(this, "¡Error!", "Ocurrió un error inesperado.");

                        btnAceptar.Enabled = true;
                        btnAceptar.Text = "ACEPTAR";
                        galeria.ListaImagenes = listaGaleria;
                    }
                }
            }
        }

        private void dtpHoraInicio_ValueChanged(object sender, EventArgs e)
        {
            if (dtpHoraInicio.Value.TimeOfDay == new TimeSpan(23, 59, 0))
                dtpHoraInicio.Value.AddMinutes(-1);

            dtpHoraFin.MinDate = dtpHoraInicio.Value.Date.AddMinutes(1);

            if (dtpHoraInicio.Value > dtpHoraFin.Value)
                dtpHoraFin.Value = dtpHoraInicio.Value;
        }

        private void btnCargarImagenes_Click(object sender, EventArgs e)
        {
            try
            {
                iListaRutaImagenes = galeria.ListaImagenes.Concat<string>(Utilidades.SeleccionarImagenes(this, "Cargar Imagenes Campaña")).ToList();
                galeria.ListaImagenes = iListaRutaImagenes;
            }
            catch (OutOfMemoryException)
            {
                Utilidades.MensajeError(this,"ATENCION","No es posible cargar mas imagenes, ya que no hay espacio en memoria suficiente");
            }
        }

        private void dgridPrioridades_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView grilla = (DataGridView)sender;
            int mFilaDelClick = grilla.HitTest(e.X, e.Y).RowIndex;
            if (e.Button==MouseButtons.Right &&  mFilaDelClick >= 0)
            {
                grilla.Rows[mFilaDelClick].Selected = true;
                ContextMenuStrip mMenuDinamico = new ContextMenuStrip();
                mMenuDinamico.Items.Add("Eliminar Prioridad").Name = "Del";
                mMenuDinamico.Items.Add("-");
                mMenuDinamico.Items.Add("Priorizar").Name = "Min"; 
                mMenuDinamico.Items.Add("Postergar").Name = "Max";
                mMenuDinamico.Items.Add("-");
                mMenuDinamico.Items.Add("Eliminar del Espacio de Trabajo").Name = "HardDel";
                mMenuDinamico.ItemClicked += new ToolStripItemClickedEventHandler(MenuDinamicoClick);
                mMenuDinamico.Show((Control)sender, new Point(e.X, e.Y));
            }
        }

        private void MenuDinamicoClick(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name != "-") { this.AccionesConLaPrioridad( e.ClickedItem.Name ); }
        }

        private void AccionesConLaPrioridad(string pAccion)
        {
            DataGridView grilla = dgridPrioridades;
            List<Imagen> Lista = (List<Imagen>)grilla.DataSource;
            int mIndex = grilla.SelectedRows[0].Index;

            switch (pAccion)
            {
                case "Del":
                    //Desde la fila indicada hacia abajo, disminuye las prioridades
                    for (int i = (mIndex + 1); i < Lista.Count; i++)
                        Lista.ElementAt(i).Prioridad += (-1);
                    //Elimina la fila
                    Lista.RemoveAt(mIndex);
                    mIndex = 0;
                    break;
                case "HardDel":
                    string mRuta = Lista.ElementAt(mIndex).Ruta;
                    this.AccionesConLaPrioridad("Del");
                    int mIndiceGaleria = -1;

                    for (int i = 0; i < galeria.ListaImagenes.Count; i++)
                        if (galeria.ListaImagenes.ElementAt(i).ToLower() == mRuta.ToLower())
                            mIndiceGaleria = i;

                    if (mIndiceGaleria >= 0)
                    {
                        List<string> mLista = galeria.ListaImagenes;
                        mLista.RemoveAt(mIndiceGaleria);
                        galeria.ListaImagenes = mLista;
                        mIndex = 0;
                    }
                    break;
                case "Max":
                    if (mIndex < (Lista.Count() - 1))
                    {
                        Lista.ElementAt(mIndex).Prioridad += 1;
                        Lista.ElementAt(mIndex + 1).Prioridad += (-1);
                        Lista.Sort();
                        mIndex = mIndex + 1;
                    }
                    break;
                case "Min":
                    if (mIndex > 0)
                    {
                        Lista.ElementAt(mIndex).Prioridad += (-1);
                        Lista.ElementAt(mIndex - 1).Prioridad += 1;
                        Lista.Sort();
                        mIndex = mIndex - 1;
                    }
                    break;
            }//Fin SWITCH
            grilla.DataSource = Lista.ToList();
            if (Lista.Count > 0)//Si hay elementos en la grilla
                grilla.Rows[mIndex].Selected = true;
        }

        private void btnEliminarPrioridad_Click(object sender, EventArgs e)
        {
            if (dgridPrioridades.SelectedRows.Count > 0)
                this.AccionesConLaPrioridad("Del");
        }

        private void btnSubirPrioridad_Click(object sender, EventArgs e)
        {
            if (dgridPrioridades.SelectedRows.Count > 0)
                this.AccionesConLaPrioridad("Min");
        }

        private void btnBajarPrioridad_Click(object sender, EventArgs e)
        {
            if (dgridPrioridades.SelectedRows.Count > 0)
                this.AccionesConLaPrioridad("Max");
        }

        private void btnQuitarCompletamente_Click(object sender, EventArgs e)
        {
            if (dgridPrioridades.SelectedRows.Count > 0)
                this.AccionesConLaPrioridad("HardDel");
        }

        private void dgridPrioridades_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgridPrioridades.SelectedRows.Count > 0)
            {
                galeria.SeleccionarImagen( ((Imagen)dgridPrioridades.SelectedRows[0].DataBoundItem).Ruta );
            }
        }

        private void EliminarImagenesBasura( List<Imagen> pListaActual, List<Imagen> pListaNueva)
        {
            bool mBorrar;
            ControladorImagen mCtrlImg = new ControladorImagen();
            List<string> mListaImgParaBorrar = new List<string>();

            foreach (Imagen mImg in pListaActual)
            {
                mBorrar = true;
                foreach (Imagen mImgNueva in pListaNueva)
                    if (mImg.ImagenId == mImgNueva.ImagenId && mImg.Ruta.ToLower() == mImgNueva.Ruta.ToLower())
                    {
                        mBorrar = false;
                        break;
                    }

                if (mBorrar)
                {
                    mListaImgParaBorrar.Add(mImg.Ruta);//Guardamos el id
                    mCtrlImg.Eliminar(mImg);
                }
            }

            if (mListaImgParaBorrar.Count > 0)
            {
                //Se tomo esta decicion por problemas de liberacion de recursos, ya que imagenes que se van a borrar son utilizadas por otro proceso simultaneamente.
                EscrituraArchivoTexto archivo = new EscrituraArchivoTexto( Utilidades.RutaPrograma() + "ImgParaBorrar.INF" );
                archivo.WriteLine(mListaImgParaBorrar);
                archivo.Save();
            }
        }

    }
}
