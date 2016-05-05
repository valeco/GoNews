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

namespace CarteleriaDigital.GUI
{
    public partial class FormAgregarModificarBanner : Form
    {
        Banner iBanner = null;
        bool iAgregar;
        EasyLog iLogger;
        ControladorBanner iCtrlBanner = new ControladorBanner();
        ControladorBannerRSS iCtrlBannerRSS = new ControladorBannerRSS();
        ControladorBannerTXT iCtrlBannerTXT = new ControladorBannerTXT();
        ControladorUsuario iCtrlUsuario = ControladorUsuario.Instancia;

        public FormAgregarModificarBanner(EasyLog pLogger, int pIdBanner)
        {
            InitializeComponent();

            iLogger = pLogger;

            if (pIdBanner > 0)
            {
                iAgregar = false;

                iBanner = iCtrlBanner.ObtenerPorId(pIdBanner);

                lbTitulo.Text = "Modificar banner";
            }
            else
            {
                iAgregar = true;
                lbTitulo.Text = "Agregar banner";
            }

            iLogger.Info("Initialize form AgregarModificarBanner finalizado.");
        }

        private void pboxCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pboxMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        ///     Habilita y deshabilita, al tildar alguno de los radio buttons, los controles correspondientes.
        /// </summary>
        private void ToggleControles()
        {
            if (radioTextoFijo.Checked)
            {
                radioTextoFijo.ForeColor = Color.White;
                radioFuenteRSS.ForeColor = Color.Gainsboro;

                txtTextoFijo.Enabled = true;
                comboFuenteRSS.Enabled = false;

                tbarIntervalo.Minimum = 0;
                tbarIntervalo.Value = 0;
                tbarIntervalo.Enabled = false;
            }
            else if (radioFuenteRSS.Checked)
            {
                radioTextoFijo.ForeColor = Color.Gainsboro;
                radioFuenteRSS.ForeColor = Color.White;

                txtTextoFijo.Enabled = false;
                comboFuenteRSS.Enabled = true;

                tbarIntervalo.Minimum = 5;
                tbarIntervalo.Value = 5;
                tbarIntervalo.Enabled = true;
            }
        }

        private void radioTextoFijo_CheckedChanged(object sender, EventArgs e)
        {
            ToggleControles();
        }

        private void radioFuenteRSS_CheckedChanged(object sender, EventArgs e)
        {
            ToggleControles();
        }

        private void FormAgregarModificarBanner_Load(object sender, EventArgs e)
        {
            Utilidades.AllTextBoxPlaceHolder(this);

            comboFuenteRSS.DataSource = iCtrlBannerRSS.ObtenerTodos();
            iLogger.Debug("Se cargaron " + comboFuenteRSS.Items.Count + " fuentes RSS en el combo.");

            // Si entra un banner hay que modificarlo.
            if (!iAgregar)
            {
                txtNombreBanner.Text = iBanner.Nombre;

                if (iBanner.Tipo == TipoBanner.TXT)
                {
                    radioTextoFijo.Checked = true;
                    txtTextoFijo.Text = ((BannerTXT)iBanner.Fuente).Texto;
                }
                else if (iBanner.Tipo == TipoBanner.RSS)
                {
                    radioFuenteRSS.Checked = true;
                    tbarIntervalo.Value = iBanner.IntervaloEnSeg;
                    BannerRSS brss = (BannerRSS)iBanner.Fuente;
                    comboFuenteRSS.SelectedIndex = comboFuenteRSS.FindStringExact(brss.ToString());
                }

                dtpFechaInicio.Value = iBanner.FechaInicio;
                dtpFechaFin.Value = iBanner.FechaFin;

                dtpHoraInicio.Value = new DateTime(DateTime.Today.Year,
                                                   DateTime.Today.Month,
                                                   DateTime.Today.Day,
                                                   iBanner.HoraInicio.Hours,
                                                   iBanner.HoraInicio.Minutes,0);

                dtpHoraFin.Value = new DateTime(DateTime.Today.Year,
                                                DateTime.Today.Month,
                                                DateTime.Today.Day,
                                                iBanner.HoraFin.Hours,
                                                iBanner.HoraFin.Minutes,0);
            }
            else
            {
                dtpFechaInicio.MinDate = DateTime.Today;
                dtpFechaInicio.Value = DateTime.Today;

                dtpFechaFin.MinDate = DateTime.Today;
                dtpFechaFin.Value = DateTime.Today;
            }

            iLogger.Info("Load form AgregarModificarBanner finalizado.");
        }

        private void tbarIntervalo_Scroll(object sender, EventArgs e)
        {
            lbValorIntervalo.Text = tbarIntervalo.Value.ToString() + " seg.";
        }

        private void tbarIntervalo_ValueChanged(object sender, EventArgs e)
        {
            this.tbarIntervalo_Scroll(null, null);
        }

        private void FormAgregarModificarBanner_FormClosing(object sender, FormClosingEventArgs e)
        {
            iLogger.Info("Cerrando form AgregarModificar Banner");
            iLogger.Save();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Banner mBanner = new Banner(new BannerTXT(""), TipoBanner.TXT)
            {
                FechaInicio = dtpFechaInicio.Value.Date,
                HoraInicio = dtpHoraInicio.Value.TimeOfDay,
                FechaFin = dtpFechaFin.Value.Date,
                HoraFin = dtpHoraFin.Value.TimeOfDay
            };

            if (txtNombreBanner.Text == "")
            {
                Utilidades.MensajeError(this, "¡Atención!", "Debe ingresar un nombre para el banner.");
                txtNombreBanner.Focus();
            }
            else if (dtpHoraFin.Value <= dtpHoraInicio.Value)
            {
                Utilidades.MensajeError(this, "¡Atención!", "La hora en la que termina el banner debe ser posterior a la de inicio.");
                dtpHoraFin.Focus();
            }
            else if (radioTextoFijo.Checked && txtTextoFijo.Text == "")
            {
                Utilidades.MensajeError(this, "¡Atención!", "Debe ingresar algún texto para mostrar en el banner.");
                txtTextoFijo.Focus();
            }
            else if (radioFuenteRSS.Checked && comboFuenteRSS.SelectedItem == null)
            {
                Utilidades.MensajeError(this, "¡Atención!", "Debe seleccionar alguna fuente RSS para mostrar en el banner.");
                comboFuenteRSS.Focus();
            }
            else if (iAgregar && iCtrlBanner.ExisteBannerEnHorario(mBanner))
            {
                Utilidades.MensajeError(this, "¡Atención!", "Existe otro banner en ese horario. Elija otro momento del día en el cual mostrarlo.");
                dtpHoraInicio.Focus();
            }
            else
            {

                List<Banner> mListaSolapamientos = null;
                int mSolapamientos = 0;
                if (!iAgregar)//Para optimizar tiempo, solo se consulta esto si se modifica
                {
                    mListaSolapamientos = iCtrlBanner.ListaBannersEnHorario(mBanner);
                    mSolapamientos = mListaSolapamientos.Count;
                }

                if ( ((iBanner == null) ? false: iBanner.Activo) && //Si no esta activo no se verifica los solapamientos, se lo haran en el formBuscar al querer activar
                     (
                        (!iAgregar && mSolapamientos > 1) ||
                        (!iAgregar && mSolapamientos == 1 && iBanner.Id != mListaSolapamientos.ElementAt(0).Id)
                     )
                   )
                {
                    Utilidades.MensajeError(this, "¡Atención!", "Existe otro banner en ese horario. Elija otro momento del día en el cual mostrarlo.");
                    dtpHoraInicio.Focus();
                }
                else
                {
                    try
                    {
                        if (radioTextoFijo.Checked)
                        {
                            if (iAgregar)//Se esta agregando un Banner
                            {
                                BannerTXT iBtxt = new BannerTXT(txtTextoFijo.Text);
                                iCtrlBannerTXT.Insertar(iBtxt);
                                iBanner = new Banner(iBtxt, TipoBanner.TXT);
                            }
                            else//Se esta modificando un BRSS
                            {
                                //Solo borramos la fuente si es TXT anteriormente y el texto de esta es distinto al que se desea actualmente,
                                //ya que unicamente los bTXT son usados por el banner que la crea
                                if (iBanner.Tipo == TipoBanner.TXT && iBanner.Fuente.Proximo() != txtTextoFijo.Text)
                                    iCtrlBannerTXT.Eliminar((BannerTXT)iBanner.Fuente);

                                BannerTXT iBtxt = new BannerTXT(txtTextoFijo.Text);
                                iCtrlBannerTXT.Insertar(iBtxt);
                                iBanner.CambiarTipo(iBtxt, TipoBanner.TXT);

                            }
                        }
                        else if (radioFuenteRSS.Checked)
                        {
                            if (iAgregar)//Se esta agregando un Banner
                                iBanner = new Banner((BannerRSS)comboFuenteRSS.SelectedItem, TipoBanner.RSS);
                            else
                            {
                                //Solo borramos la fuente si es TXT ya que unicamente la usa el banner que la crea
                                if (iBanner.Tipo == TipoBanner.TXT)
                                    iCtrlBannerTXT.Eliminar((BannerTXT)iBanner.Fuente);

                                iBanner.CambiarTipo((BannerRSS)comboFuenteRSS.SelectedItem, TipoBanner.RSS);
                            }
                        }

                        iBanner.Nombre = txtNombreBanner.Text;
                        iBanner.IntervaloEnSeg = (tbarIntervalo.Value); // Se hace el cast porque se sabe que es > 0.
                    
                        iBanner.FechaInicio = dtpFechaInicio.Value.Date;
                        iBanner.FechaFin = dtpFechaFin.Value.Date;
                        iBanner.HoraInicio = dtpHoraInicio.Value.TimeOfDay;
                        iBanner.HoraFin = dtpHoraFin.Value.TimeOfDay;

                        if (iAgregar) //Agregar.
                        {
                            iBanner.Activo = true; //Siempre al agregarse se lo considera activo

                            //Forma encontrada para guardar los banner asociandolos al usuario
                            iCtrlUsuario.UsuarioLogueado.ListaBanner.Add(iBanner);
                            iCtrlUsuario.Modificar(iCtrlUsuario.UsuarioLogueado);
                            iLogger.Info("Banner insertado en el repositorio.");

                            Utilidades.MensajeExito(this, "¡Perfecto!", "Banner agregado correctamente.");
                        }
                        else//Modificar
                        {
                            iCtrlBanner.Modificar(iBanner);
                            iLogger.Info("Banner insertado en el repositorio.");

                            Utilidades.MensajeExito(this, "¡Perfecto!", "Banner modificado correctamente.");
                        }

                        this.Close();
                    }
                    catch (Exception ex)
                    { 
                        iLogger.Error(ex.Source + ": " + ex.Message);
                        Utilidades.MensajeError(this, "¡Error!", "Ocurrió un error inesperado.");
                    }                
                }
            }//else
        }

        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            //Al seleccionar la fecha inicio se re adapta el minimo de la de fin y su fecha seleccionada
            dtpFechaFin.MinDate = dtpFechaInicio.Value.Date;
            if(dtpFechaInicio.Value > dtpFechaFin.Value)
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