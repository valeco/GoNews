namespace CarteleriaDigital.GUI
{
    partial class FormAgregarModificarCampaña
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAgregarModificarCampaña));
            this.lbTitulo = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.tbarIntervalo = new System.Windows.Forms.TrackBar();
            this.txtNombreCampaña = new System.Windows.Forms.TextBox();
            this.lbIntervalo = new System.Windows.Forms.Label();
            this.panelIntervalo = new System.Windows.Forms.Panel();
            this.lbValorIntervalo = new System.Windows.Forms.Label();
            this.panelFecha = new System.Windows.Forms.Panel();
            this.lbFechaFin = new System.Windows.Forms.Label();
            this.lbFechaInicio = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.lbDias = new System.Windows.Forms.Label();
            this.panelHora = new System.Windows.Forms.Panel();
            this.dtpHoraFin = new System.Windows.Forms.DateTimePicker();
            this.dtpHoraInicio = new System.Windows.Forms.DateTimePicker();
            this.lbHoraFin = new System.Windows.Forms.Label();
            this.lbHoraInicio = new System.Windows.Forms.Label();
            this.lbHorario = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnCargarImagenes = new System.Windows.Forms.Button();
            this.pboxMinimizar = new System.Windows.Forms.PictureBox();
            this.pboxCerrar = new System.Windows.Forms.PictureBox();
            this.galeria = new CarteleriaDigital.GUI.GaleriaImagenes();
            ((System.ComponentModel.ISupportInitialize)(this.tbarIntervalo)).BeginInit();
            this.panelIntervalo.SuspendLayout();
            this.panelFecha.SuspendLayout();
            this.panelHora.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxCerrar)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitulo
            // 
            this.lbTitulo.AutoSize = true;
            this.lbTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.ForeColor = System.Drawing.Color.White;
            this.lbTitulo.Location = new System.Drawing.Point(12, 12);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(151, 20);
            this.lbTitulo.TabIndex = 1;
            this.lbTitulo.Text = "Agregar campaña";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(13, 51);
            this.dtpFechaInicio.MinDate = new System.DateTime(2016, 2, 5, 0, 12, 35, 0);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(110, 24);
            this.dtpFechaInicio.TabIndex = 3;
            this.dtpFechaInicio.Value = new System.DateTime(2016, 2, 5, 0, 12, 35, 0);
            // 
            // tbarIntervalo
            // 
            this.tbarIntervalo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbarIntervalo.Location = new System.Drawing.Point(13, 50);
            this.tbarIntervalo.Maximum = 20;
            this.tbarIntervalo.Minimum = 1;
            this.tbarIntervalo.Name = "tbarIntervalo";
            this.tbarIntervalo.Size = new System.Drawing.Size(227, 45);
            this.tbarIntervalo.TabIndex = 2;
            this.tbarIntervalo.Value = 5;
            this.tbarIntervalo.Scroll += new System.EventHandler(this.tbarIntervalo_Scroll);
            // 
            // txtNombreCampaña
            // 
            this.txtNombreCampaña.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreCampaña.ForeColor = System.Drawing.Color.Black;
            this.txtNombreCampaña.Location = new System.Drawing.Point(12, 44);
            this.txtNombreCampaña.Name = "txtNombreCampaña";
            this.txtNombreCampaña.Size = new System.Drawing.Size(254, 26);
            this.txtNombreCampaña.TabIndex = 2;
            this.txtNombreCampaña.Text = "Nombre de la campaña";
            this.txtNombreCampaña.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbIntervalo
            // 
            this.lbIntervalo.AutoSize = true;
            this.lbIntervalo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIntervalo.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.lbIntervalo.Location = new System.Drawing.Point(10, 12);
            this.lbIntervalo.Name = "lbIntervalo";
            this.lbIntervalo.Size = new System.Drawing.Size(138, 32);
            this.lbIntervalo.TabIndex = 21;
            this.lbIntervalo.Text = "Intervalo de transición\r\nentre imágenes:";
            // 
            // panelIntervalo
            // 
            this.panelIntervalo.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panelIntervalo.Controls.Add(this.lbValorIntervalo);
            this.panelIntervalo.Controls.Add(this.tbarIntervalo);
            this.panelIntervalo.Controls.Add(this.lbIntervalo);
            this.panelIntervalo.Location = new System.Drawing.Point(12, 76);
            this.panelIntervalo.Name = "panelIntervalo";
            this.panelIntervalo.Size = new System.Drawing.Size(254, 88);
            this.panelIntervalo.TabIndex = 3;
            // 
            // lbValorIntervalo
            // 
            this.lbValorIntervalo.AutoSize = true;
            this.lbValorIntervalo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbValorIntervalo.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbValorIntervalo.Location = new System.Drawing.Point(152, 16);
            this.lbValorIntervalo.Name = "lbValorIntervalo";
            this.lbValorIntervalo.Size = new System.Drawing.Size(77, 26);
            this.lbValorIntervalo.TabIndex = 22;
            this.lbValorIntervalo.Text = "5 seg.";
            this.lbValorIntervalo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelFecha
            // 
            this.panelFecha.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panelFecha.Controls.Add(this.lbFechaFin);
            this.panelFecha.Controls.Add(this.lbFechaInicio);
            this.panelFecha.Controls.Add(this.dtpFechaFin);
            this.panelFecha.Controls.Add(this.lbDias);
            this.panelFecha.Controls.Add(this.dtpFechaInicio);
            this.panelFecha.Location = new System.Drawing.Point(12, 170);
            this.panelFecha.Name = "panelFecha";
            this.panelFecha.Size = new System.Drawing.Size(254, 89);
            this.panelFecha.TabIndex = 4;
            // 
            // lbFechaFin
            // 
            this.lbFechaFin.AutoSize = true;
            this.lbFechaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFechaFin.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbFechaFin.Location = new System.Drawing.Point(128, 35);
            this.lbFechaFin.Name = "lbFechaFin";
            this.lbFechaFin.Size = new System.Drawing.Size(52, 13);
            this.lbFechaFin.TabIndex = 25;
            this.lbFechaFin.Text = "HASTA:";
            // 
            // lbFechaInicio
            // 
            this.lbFechaInicio.AutoSize = true;
            this.lbFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFechaInicio.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbFechaInicio.Location = new System.Drawing.Point(10, 35);
            this.lbFechaInicio.Name = "lbFechaInicio";
            this.lbFechaInicio.Size = new System.Drawing.Size(53, 13);
            this.lbFechaInicio.TabIndex = 24;
            this.lbFechaInicio.Text = "DESDE:";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(131, 51);
            this.dtpFechaFin.MinDate = new System.DateTime(2016, 2, 5, 0, 12, 35, 0);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(110, 24);
            this.dtpFechaFin.TabIndex = 4;
            this.dtpFechaFin.Value = new System.DateTime(2016, 2, 5, 0, 12, 35, 0);
            // 
            // lbDias
            // 
            this.lbDias.AutoSize = true;
            this.lbDias.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDias.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.lbDias.Location = new System.Drawing.Point(10, 12);
            this.lbDias.Name = "lbDias";
            this.lbDias.Size = new System.Drawing.Size(132, 16);
            this.lbDias.TabIndex = 22;
            this.lbDias.Text = "Días de la campaña:";
            // 
            // panelHora
            // 
            this.panelHora.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panelHora.Controls.Add(this.dtpHoraFin);
            this.panelHora.Controls.Add(this.dtpHoraInicio);
            this.panelHora.Controls.Add(this.lbHoraFin);
            this.panelHora.Controls.Add(this.lbHoraInicio);
            this.panelHora.Controls.Add(this.lbHorario);
            this.panelHora.Location = new System.Drawing.Point(12, 264);
            this.panelHora.Name = "panelHora";
            this.panelHora.Size = new System.Drawing.Size(254, 89);
            this.panelHora.TabIndex = 5;
            // 
            // dtpHoraFin
            // 
            this.dtpHoraFin.CustomFormat = "HH:mm";
            this.dtpHoraFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHoraFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHoraFin.Location = new System.Drawing.Point(131, 51);
            this.dtpHoraFin.Name = "dtpHoraFin";
            this.dtpHoraFin.ShowUpDown = true;
            this.dtpHoraFin.Size = new System.Drawing.Size(110, 24);
            this.dtpHoraFin.TabIndex = 6;
            this.dtpHoraFin.Value = new System.DateTime(2016, 2, 5, 23, 59, 0, 0);
            // 
            // dtpHoraInicio
            // 
            this.dtpHoraInicio.CustomFormat = "HH:mm";
            this.dtpHoraInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHoraInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHoraInicio.Location = new System.Drawing.Point(13, 51);
            this.dtpHoraInicio.Name = "dtpHoraInicio";
            this.dtpHoraInicio.ShowUpDown = true;
            this.dtpHoraInicio.Size = new System.Drawing.Size(110, 24);
            this.dtpHoraInicio.TabIndex = 5;
            this.dtpHoraInicio.Value = new System.DateTime(2016, 2, 5, 0, 0, 0, 0);
            // 
            // lbHoraFin
            // 
            this.lbHoraFin.AutoSize = true;
            this.lbHoraFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHoraFin.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbHoraFin.Location = new System.Drawing.Point(128, 35);
            this.lbHoraFin.Name = "lbHoraFin";
            this.lbHoraFin.Size = new System.Drawing.Size(52, 13);
            this.lbHoraFin.TabIndex = 25;
            this.lbHoraFin.Text = "HASTA:";
            // 
            // lbHoraInicio
            // 
            this.lbHoraInicio.AutoSize = true;
            this.lbHoraInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHoraInicio.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbHoraInicio.Location = new System.Drawing.Point(10, 35);
            this.lbHoraInicio.Name = "lbHoraInicio";
            this.lbHoraInicio.Size = new System.Drawing.Size(53, 13);
            this.lbHoraInicio.TabIndex = 24;
            this.lbHoraInicio.Text = "DESDE:";
            // 
            // lbHorario
            // 
            this.lbHorario.AutoSize = true;
            this.lbHorario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHorario.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.lbHorario.Location = new System.Drawing.Point(10, 12);
            this.lbHorario.Name = "lbHorario";
            this.lbHorario.Size = new System.Drawing.Size(149, 16);
            this.lbHorario.TabIndex = 22;
            this.lbHorario.Text = "Horario de la campaña:";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.Black;
            this.btnAgregar.Location = new System.Drawing.Point(573, 359);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(100, 30);
            this.btnAgregar.TabIndex = 7;
            this.btnAgregar.Text = "AGREGAR";
            this.btnAgregar.UseVisualStyleBackColor = true;
            // 
            // btnCargarImagenes
            // 
            this.btnCargarImagenes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCargarImagenes.Image = global::CarteleriaDigital.Properties.Resources._btnExaminar;
            this.btnCargarImagenes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCargarImagenes.Location = new System.Drawing.Point(272, 45);
            this.btnCargarImagenes.Name = "btnCargarImagenes";
            this.btnCargarImagenes.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnCargarImagenes.Size = new System.Drawing.Size(125, 26);
            this.btnCargarImagenes.TabIndex = 6;
            this.btnCargarImagenes.Text = "Cargar imágenes...";
            this.btnCargarImagenes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCargarImagenes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCargarImagenes.UseVisualStyleBackColor = true;
            // 
            // pboxMinimizar
            // 
            this.pboxMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pboxMinimizar.Image = global::CarteleriaDigital.Properties.Resources._pboxMinimizar;
            this.pboxMinimizar.Location = new System.Drawing.Point(628, 12);
            this.pboxMinimizar.Name = "pboxMinimizar";
            this.pboxMinimizar.Size = new System.Drawing.Size(20, 20);
            this.pboxMinimizar.TabIndex = 16;
            this.pboxMinimizar.TabStop = false;
            this.pboxMinimizar.Click += new System.EventHandler(this.pboxMinimizar_Click);
            // 
            // pboxCerrar
            // 
            this.pboxCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pboxCerrar.Image = global::CarteleriaDigital.Properties.Resources._pboxCerrar;
            this.pboxCerrar.Location = new System.Drawing.Point(653, 12);
            this.pboxCerrar.Name = "pboxCerrar";
            this.pboxCerrar.Size = new System.Drawing.Size(20, 20);
            this.pboxCerrar.TabIndex = 15;
            this.pboxCerrar.TabStop = false;
            this.pboxCerrar.Click += new System.EventHandler(this.pboxCerrar_Click);
            // 
            // galeria
            // 
            this.galeria.AltoImagenes = 100;
            this.galeria.AnchoImagenes = 150;
            this.galeria.BackColor = System.Drawing.Color.DarkSlateGray;
            this.galeria.Directorio = null;
            this.galeria.ListaImagenes = ((System.Collections.Generic.List<string>)(resources.GetObject("galeria.ListaImagenes")));
            this.galeria.Location = new System.Drawing.Point(272, 76);
            this.galeria.MargenXImagenes = 10;
            this.galeria.MargenYImagenes = 10;
            this.galeria.Name = "galeria";
            this.galeria.ShowLabels = false;
            this.galeria.Size = new System.Drawing.Size(398, 277);
            this.galeria.TabIndex = 1;
            // 
            // FormAgregarModificarCampaña
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(685, 398);
            this.Controls.Add(this.btnCargarImagenes);
            this.Controls.Add(this.galeria);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.panelHora);
            this.Controls.Add(this.panelFecha);
            this.Controls.Add(this.panelIntervalo);
            this.Controls.Add(this.txtNombreCampaña);
            this.Controls.Add(this.lbTitulo);
            this.Controls.Add(this.pboxMinimizar);
            this.Controls.Add(this.pboxCerrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormAgregarModificarCampaña";
            this.Text = "Agregar campaña";
            this.Load += new System.EventHandler(this.FormAgregarModificarCampaña_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbarIntervalo)).EndInit();
            this.panelIntervalo.ResumeLayout(false);
            this.panelIntervalo.PerformLayout();
            this.panelFecha.ResumeLayout(false);
            this.panelFecha.PerformLayout();
            this.panelHora.ResumeLayout(false);
            this.panelHora.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxCerrar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.PictureBox pboxMinimizar;
        private System.Windows.Forms.PictureBox pboxCerrar;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.TrackBar tbarIntervalo;
        private System.Windows.Forms.TextBox txtNombreCampaña;
        private System.Windows.Forms.Label lbIntervalo;
        private System.Windows.Forms.Panel panelIntervalo;
        private System.Windows.Forms.Panel panelFecha;
        private System.Windows.Forms.Label lbValorIntervalo;
        private System.Windows.Forms.Label lbFechaFin;
        private System.Windows.Forms.Label lbFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label lbDias;
        private System.Windows.Forms.Panel panelHora;
        private System.Windows.Forms.Label lbHoraFin;
        private System.Windows.Forms.Label lbHoraInicio;
        private System.Windows.Forms.Label lbHorario;
        private System.Windows.Forms.DateTimePicker dtpHoraFin;
        private System.Windows.Forms.DateTimePicker dtpHoraInicio;
        private System.Windows.Forms.Button btnAgregar;
        private GaleriaImagenes galeria;
        private System.Windows.Forms.Button btnCargarImagenes;
    }
}