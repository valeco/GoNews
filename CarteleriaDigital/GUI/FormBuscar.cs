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
using CarteleriaDigital.Controladores;
using CarteleriaDigital.LogicaAccesoDatos.Modelo;

namespace CarteleriaDigital.GUI
{
    public partial class FormBuscar: Form
    {
        EasyLog iLogger;
        string iTipoBusqueda;
        //VER
        ControladorCampaña CtrlCampaña;
        ControladorBanner CtrlBanner;
        //VER

        public FormBuscar(EasyLog pLogger, String pTipo)
        {
            InitializeComponent();
            iLogger = pLogger;
            lbTitulo.Text = "Buscar " + pTipo;
            txtNombre.Text = "Ingrese el nombre " + (pTipo == "campaña" ? "de la " : "del ") + pTipo + " o parte de él...";
            lbInfo.Text = "Haciendo doble click sobre la fila, activas o desactivas" + (pTipo == "campaña" ? "la campaña." : "el banner.");
            iTipoBusqueda = pTipo;
            //VER
            if (pTipo == "campaña")
                CtrlCampaña = new ControladorCampaña();
            else
                CtrlBanner = new ControladorBanner();
            //VER
            iLogger.Info("Inicializacion finalizada Buscar");
        }

        private void pboxMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pboxCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormBuscar_Load(object sender, EventArgs e)
        {
            Utilidades.AllTextBoxPlaceHolder(this);
            comboDesActivo.Items.Add("Activos");
            comboDesActivo.Items.Add("Inactivos");
            comboDesActivo.Items.Add("Todos");
            comboDesActivo.SelectedIndex = 2;
            checkDias.Checked = false;
            checkHorario.Checked = false;
            dgridResultados.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dgridResultados.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;
            btnBuscar_Click(null, null);//Para cargar grilla
            iLogger.Info("Load finalizado form Buscar");
        }

        private void checkDias_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDias.Checked)
            {
                dtpFechaInicio.Enabled = true;
                dtpFechaFin.Enabled = true;
            }
            else
            {
                dtpFechaInicio.Enabled = false;
                dtpFechaFin.Enabled = false;
            }
        }

        private void checkHorario_CheckedChanged(object sender, EventArgs e)
        {
            if (checkHorario.Checked)
            {
                dtpHoraInicio.Enabled = true;
                dtpHoraFin.Enabled = true;
            }
            else
            {
                dtpHoraInicio.Enabled = false;
                dtpHoraFin.Enabled = false;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Publicidad> mConsulta;
                ushort mElementos;
                //VER
                /*
                mConsulta = (iTipoBusqueda == "campaña") ?
                    (new ControladorCampaña()).Buscar(  comboDesActivo.Text, txtNombre.Text,
                                                        (checkDias.Checked ? dtpFechaInicio.Value : default(DateTime)),
                                                        (checkDias.Checked ? dtpFechaFin.Value : default(DateTime)),
                                                        (checkHorario.Checked ? dtpHoraInicio.Value.TimeOfDay : default(TimeSpan)),
                                                        (checkHorario.Checked ? dtpHoraFin.Value.TimeOfDay : default(TimeSpan))
                                                        ).ToList<Publicidad>():
                    (new ControladorBanner()).Buscar(   comboDesActivo.Text, txtNombre.Text,
                                                        (checkDias.Checked ? dtpFechaInicio.Value : default(DateTime)),
                                                        (checkDias.Checked ? dtpFechaFin.Value : default(DateTime)),
                                                        (checkHorario.Checked ? dtpHoraInicio.Value.TimeOfDay : default(TimeSpan)),
                                                        (checkHorario.Checked ? dtpHoraFin.Value.TimeOfDay : default(TimeSpan))
                                                        ).ToList<Publicidad>();
                                                        */
                mConsulta = (iTipoBusqueda == "campaña") ?
                                    CtrlCampaña.Buscar  (comboDesActivo.Text, txtNombre.Text,
                                                        (checkDias.Checked ? dtpFechaInicio.Value : default(DateTime)),
                                                        (checkDias.Checked ? dtpFechaFin.Value : default(DateTime)),
                                                        (checkHorario.Checked ? dtpHoraInicio.Value.TimeOfDay : default(TimeSpan)),
                                                        (checkHorario.Checked ? dtpHoraFin.Value.TimeOfDay : default(TimeSpan))
                                                        ).ToList<Publicidad>() :
                                    CtrlBanner.Buscar   (comboDesActivo.Text, txtNombre.Text,
                                                        (checkDias.Checked ? dtpFechaInicio.Value : default(DateTime)),
                                                        (checkDias.Checked ? dtpFechaFin.Value : default(DateTime)),
                                                        (checkHorario.Checked ? dtpHoraInicio.Value.TimeOfDay : default(TimeSpan)),
                                                        (checkHorario.Checked ? dtpHoraFin.Value.TimeOfDay : default(TimeSpan))
                                                        ).ToList<Publicidad>();
                //VER
                mElementos = (ushort)mConsulta.Count();
                dgridResultados.DataSource = mConsulta;
                dgridResultados.Columns["Intervalo"].Visible = false;

                iLogger.Debug("Se buscaron " + mElementos.ToString() + " " + iTipoBusqueda + "s");                
            }
            catch (Exception ex)
            {
                iLogger.Error(ex.Source + ": " + ex.Message);
                Utilidades.MensajeError(this, "ERROR", "Sucedió algo inesperado, reintente luego la acción.");
            }
        }

        private void FormBuscar_FormClosing(object sender, FormClosingEventArgs e)
        {
            iLogger.Info("Cerrado form Buscar "+ iTipoBusqueda);
            iLogger.Save();
        }

        private void dgridResultados_DoubleClick(object sender, EventArgs e)
        {
            if(dgridResultados.SelectedRows.Count > 0)
            {
                bool mDesActivo;
                int mId;
                string mNombre;

                try
                {
                    //VER
                    /*
                    Publicidad mAmodificar = (Publicidad)dgridResultados.SelectedRows[0].DataBoundItem;
                    List<Publicidad> mListaSolapamientos = (iTipoBusqueda == "campaña") ?
                                                        (new ControladorCampaña()).ListaCampañasEnHorario((Campaña)mAmodificar).ToList<Publicidad>() :
                                                        (new ControladorBanner()).ListaBannersEnHorario((Banner)mAmodificar).ToList<Publicidad>();
                    int mSolapamientos = mListaSolapamientos.Count;

                    if (mSolapamientos > 1 || (mSolapamientos == 1 && mAmodificar.Id != mListaSolapamientos.ElementAt(0).Id))
                        Utilidades.MensajeError(this, "¡Atención!", "Existe otr" + ((iTipoBusqueda == "campaña") ? "a campaña" : "o banner") + " en ese horario.");
                    else
                    {
                        mAmodificar = (iTipoBusqueda == "campaña") ?
                                      (Publicidad) (new ControladorCampaña()).ObtenerPorId(mAmodificar.Id):
                                      (Publicidad) (new ControladorBanner()).ObtenerPorId(mAmodificar.Id);

                        mAmodificar.Activo = !mAmodificar.Activo;

                        if (iTipoBusqueda == "campaña")
                            (new ControladorCampaña()).Modificar((Campaña)mAmodificar);
                        else                            
                            (new ControladorBanner()).Modificar((Banner)mAmodificar);

                        

                        mDesActivo = mAmodificar.Activo;
                        mId = mAmodificar.Id;
                        mNombre = mAmodificar.Nombre;

                        Utilidades.MensajeExito(this, "¡Perfecto!", "Se " + (mDesActivo ? "activó" : "desactivó") + " con éxito "
                                                                    + (iTipoBusqueda == "campaña" ? "la campaña" : "el banner")
                                                                    + "\n" + "ID -> " + mId
                                                                    + "\n" + "Nombre -> " + mNombre);
                        btnBuscar_Click(null, null);
                    }
                    */
                    Publicidad mAmodificar = (Publicidad)dgridResultados.SelectedRows[0].DataBoundItem;
                    List<Publicidad> mListaSolapamientos = (iTipoBusqueda == "campaña") ?
                                                        CtrlCampaña.ListaCampañasEnHorario((Campaña)mAmodificar).ToList<Publicidad>() :
                                                        CtrlBanner.ListaBannersEnHorario((Banner)mAmodificar).ToList<Publicidad>();
                    int mSolapamientos = mListaSolapamientos.Count;

                    if (mSolapamientos > 1 || (mSolapamientos == 1 && mAmodificar.Id != mListaSolapamientos.ElementAt(0).Id))
                        Utilidades.MensajeError(this, "¡Atención!", "Existe otr" + ((iTipoBusqueda == "campaña") ? "a campaña" : "o banner") + " en ese horario.");
                    else
                    {
                        mAmodificar = (iTipoBusqueda == "campaña") ?
                                      (Publicidad)CtrlCampaña.ObtenerPorId(mAmodificar.Id) :
                                      (Publicidad)CtrlBanner.ObtenerPorId(mAmodificar.Id);

                        mAmodificar.Activo = !mAmodificar.Activo;

                        if (iTipoBusqueda == "campaña")
                            CtrlCampaña.Modificar((Campaña)mAmodificar);
                        else
                            CtrlBanner.Modificar((Banner)mAmodificar);

                        mDesActivo = mAmodificar.Activo;
                        mId = mAmodificar.Id;
                        mNombre = mAmodificar.Nombre;

                        Utilidades.MensajeExito(this, "¡Perfecto!", "Se " + (mDesActivo ? "activó" : "desactivó") + " con éxito "
                                                                    + (iTipoBusqueda == "campaña" ? "la campaña" : "el banner")
                                                                    + "\n" + "ID -> " + mId
                                                                    + "\n" + "Nombre -> " + mNombre);
                        btnBuscar_Click(null, null);
                    }
                    //VER
                }
                catch (Exception ex)
                {
                    iLogger.Error(ex.Source + ": " + ex.Message);
                    Utilidades.MensajeError(this, "ERROR", "Sucedió algo inesperado, reintente luego la acción.");
                }
            }
        }

        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            //Al seleccionar la fecha inicio se re adapta el minimo de la de fin y su fecha seleccionada
            dtpFechaFin.MinDate = dtpFechaInicio.Value.Date;
            if (dtpFechaInicio.Value > dtpFechaFin.Value)
                dtpFechaFin.Value = dtpFechaInicio.Value;
        }

        private void dtpHoraInicio_ValueChanged(object sender, EventArgs e)
        {
            if (dtpHoraInicio.Value.TimeOfDay == new TimeSpan(23, 59, 0))
                dtpHoraInicio.Value.AddMinutes(-1);

            dtpHoraFin.MinDate = dtpHoraInicio.Value.Date.AddMinutes(1);

            if (dtpHoraInicio.Value > dtpHoraFin.Value)
                dtpHoraFin.Value = dtpHoraInicio.Value;
        }

    }
}
