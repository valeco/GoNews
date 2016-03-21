namespace CarteleriaDigital.GUI
{
    partial class FormBuscar
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
            this.lbTitulo = new System.Windows.Forms.Label();
            this.pboxMinimizar = new System.Windows.Forms.PictureBox();
            this.pboxCerrar = new System.Windows.Forms.PictureBox();
            this.panelBuscar = new System.Windows.Forms.Panel();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgridResultados = new System.Windows.Forms.DataGridView();
            this.panelDias = new System.Windows.Forms.Panel();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.lbFechaFin = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lbFechaInicio = new System.Windows.Forms.Label();
            this.checkDias = new System.Windows.Forms.CheckBox();
            this.panelHorario = new System.Windows.Forms.Panel();
            this.dtpHoraFin = new System.Windows.Forms.DateTimePicker();
            this.lbHoraFin = new System.Windows.Forms.Label();
            this.dtpHoraInicio = new System.Windows.Forms.DateTimePicker();
            this.lbHoraInicio = new System.Windows.Forms.Label();
            this.checkHorario = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboDesActivo = new System.Windows.Forms.ComboBox();
            this.lbMostrar = new System.Windows.Forms.Label();
            this.panelResultados = new System.Windows.Forms.Panel();
            this.lbInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pboxMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxCerrar)).BeginInit();
            this.panelBuscar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgridResultados)).BeginInit();
            this.panelDias.SuspendLayout();
            this.panelHorario.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelResultados.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitulo
            // 
            this.lbTitulo.AutoSize = true;
            this.lbTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.ForeColor = System.Drawing.Color.White;
            this.lbTitulo.Location = new System.Drawing.Point(12, 12);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(140, 20);
            this.lbTitulo.TabIndex = 1;
            this.lbTitulo.Text = "Buscar <param>";
            // 
            // pboxMinimizar
            // 
            this.pboxMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pboxMinimizar.Image = global::CarteleriaDigital.Properties.Resources._pboxMinimizar;
            this.pboxMinimizar.Location = new System.Drawing.Point(489, 12);
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
            this.pboxCerrar.Location = new System.Drawing.Point(514, 12);
            this.pboxCerrar.Name = "pboxCerrar";
            this.pboxCerrar.Size = new System.Drawing.Size(20, 20);
            this.pboxCerrar.TabIndex = 15;
            this.pboxCerrar.TabStop = false;
            this.pboxCerrar.Click += new System.EventHandler(this.pboxCerrar_Click);
            // 
            // panelBuscar
            // 
            this.panelBuscar.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panelBuscar.Controls.Add(this.txtNombre);
            this.panelBuscar.Location = new System.Drawing.Point(16, 43);
            this.panelBuscar.Name = "panelBuscar";
            this.panelBuscar.Size = new System.Drawing.Size(512, 53);
            this.panelBuscar.TabIndex = 18;
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.ForeColor = System.Drawing.Color.Black;
            this.txtNombre.Location = new System.Drawing.Point(13, 13);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(485, 26);
            this.txtNombre.TabIndex = 2;
            this.txtNombre.Text = "Ingrese el nombre <de la/del> <param> o parte de él...";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBuscar.Location = new System.Drawing.Point(275, 199);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(253, 44);
            this.btnBuscar.TabIndex = 10;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dgridResultados
            // 
            this.dgridResultados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgridResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgridResultados.Location = new System.Drawing.Point(13, 13);
            this.dgridResultados.MultiSelect = false;
            this.dgridResultados.Name = "dgridResultados";
            this.dgridResultados.ReadOnly = true;
            this.dgridResultados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgridResultados.Size = new System.Drawing.Size(485, 162);
            this.dgridResultados.TabIndex = 0;
            this.dgridResultados.DoubleClick += new System.EventHandler(this.dgridResultados_DoubleClick);
            // 
            // panelDias
            // 
            this.panelDias.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panelDias.Controls.Add(this.dtpFechaFin);
            this.panelDias.Controls.Add(this.lbFechaFin);
            this.panelDias.Controls.Add(this.dtpFechaInicio);
            this.panelDias.Controls.Add(this.lbFechaInicio);
            this.panelDias.Controls.Add(this.checkDias);
            this.panelDias.Location = new System.Drawing.Point(16, 102);
            this.panelDias.Name = "panelDias";
            this.panelDias.Size = new System.Drawing.Size(253, 91);
            this.panelDias.TabIndex = 23;
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Enabled = false;
            this.dtpFechaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(129, 52);
            this.dtpFechaFin.MinDate = new System.DateTime(2016, 1, 1, 0, 0, 0, 0);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(110, 24);
            this.dtpFechaFin.TabIndex = 5;
            // 
            // lbFechaFin
            // 
            this.lbFechaFin.AutoSize = true;
            this.lbFechaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFechaFin.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbFechaFin.Location = new System.Drawing.Point(126, 36);
            this.lbFechaFin.Name = "lbFechaFin";
            this.lbFechaFin.Size = new System.Drawing.Size(52, 13);
            this.lbFechaFin.TabIndex = 3;
            this.lbFechaFin.Text = "HASTA:";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Enabled = false;
            this.dtpFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(13, 52);
            this.dtpFechaInicio.MinDate = new System.DateTime(2016, 1, 1, 0, 0, 0, 0);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(110, 24);
            this.dtpFechaInicio.TabIndex = 4;
            this.dtpFechaInicio.ValueChanged += new System.EventHandler(this.dtpFechaInicio_ValueChanged);
            // 
            // lbFechaInicio
            // 
            this.lbFechaInicio.AutoSize = true;
            this.lbFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFechaInicio.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbFechaInicio.Location = new System.Drawing.Point(10, 36);
            this.lbFechaInicio.Name = "lbFechaInicio";
            this.lbFechaInicio.Size = new System.Drawing.Size(53, 13);
            this.lbFechaInicio.TabIndex = 1;
            this.lbFechaInicio.Text = "DESDE:";
            // 
            // checkDias
            // 
            this.checkDias.AutoSize = true;
            this.checkDias.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkDias.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.checkDias.Location = new System.Drawing.Point(13, 13);
            this.checkDias.Name = "checkDias";
            this.checkDias.Size = new System.Drawing.Size(115, 20);
            this.checkDias.TabIndex = 3;
            this.checkDias.Text = "Filtrar por días:";
            this.checkDias.UseVisualStyleBackColor = true;
            this.checkDias.CheckedChanged += new System.EventHandler(this.checkDias_CheckedChanged);
            // 
            // panelHorario
            // 
            this.panelHorario.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panelHorario.Controls.Add(this.dtpHoraFin);
            this.panelHorario.Controls.Add(this.lbHoraFin);
            this.panelHorario.Controls.Add(this.dtpHoraInicio);
            this.panelHorario.Controls.Add(this.lbHoraInicio);
            this.panelHorario.Controls.Add(this.checkHorario);
            this.panelHorario.Location = new System.Drawing.Point(275, 102);
            this.panelHorario.Name = "panelHorario";
            this.panelHorario.Size = new System.Drawing.Size(253, 91);
            this.panelHorario.TabIndex = 24;
            // 
            // dtpHoraFin
            // 
            this.dtpHoraFin.CustomFormat = "HH:mm";
            this.dtpHoraFin.Enabled = false;
            this.dtpHoraFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHoraFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHoraFin.Location = new System.Drawing.Point(129, 52);
            this.dtpHoraFin.MinDate = new System.DateTime(2016, 1, 1, 0, 0, 0, 0);
            this.dtpHoraFin.Name = "dtpHoraFin";
            this.dtpHoraFin.ShowUpDown = true;
            this.dtpHoraFin.Size = new System.Drawing.Size(110, 24);
            this.dtpHoraFin.TabIndex = 8;
            // 
            // lbHoraFin
            // 
            this.lbHoraFin.AutoSize = true;
            this.lbHoraFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHoraFin.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbHoraFin.Location = new System.Drawing.Point(126, 36);
            this.lbHoraFin.Name = "lbHoraFin";
            this.lbHoraFin.Size = new System.Drawing.Size(52, 13);
            this.lbHoraFin.TabIndex = 3;
            this.lbHoraFin.Text = "HASTA:";
            // 
            // dtpHoraInicio
            // 
            this.dtpHoraInicio.CustomFormat = "HH:mm";
            this.dtpHoraInicio.Enabled = false;
            this.dtpHoraInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHoraInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHoraInicio.Location = new System.Drawing.Point(13, 52);
            this.dtpHoraInicio.MinDate = new System.DateTime(2016, 1, 1, 0, 0, 0, 0);
            this.dtpHoraInicio.Name = "dtpHoraInicio";
            this.dtpHoraInicio.ShowUpDown = true;
            this.dtpHoraInicio.Size = new System.Drawing.Size(110, 24);
            this.dtpHoraInicio.TabIndex = 7;
            this.dtpHoraInicio.ValueChanged += new System.EventHandler(this.dtpHoraInicio_ValueChanged);
            // 
            // lbHoraInicio
            // 
            this.lbHoraInicio.AutoSize = true;
            this.lbHoraInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHoraInicio.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbHoraInicio.Location = new System.Drawing.Point(10, 36);
            this.lbHoraInicio.Name = "lbHoraInicio";
            this.lbHoraInicio.Size = new System.Drawing.Size(53, 13);
            this.lbHoraInicio.TabIndex = 1;
            this.lbHoraInicio.Text = "DESDE:";
            // 
            // checkHorario
            // 
            this.checkHorario.AutoSize = true;
            this.checkHorario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkHorario.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.checkHorario.Location = new System.Drawing.Point(13, 13);
            this.checkHorario.Name = "checkHorario";
            this.checkHorario.Size = new System.Drawing.Size(131, 20);
            this.checkHorario.TabIndex = 6;
            this.checkHorario.Text = "Filtrar por horario:";
            this.checkHorario.UseVisualStyleBackColor = true;
            this.checkHorario.CheckedChanged += new System.EventHandler(this.checkHorario_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.comboDesActivo);
            this.panel1.Controls.Add(this.lbMostrar);
            this.panel1.Location = new System.Drawing.Point(16, 199);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(253, 44);
            this.panel1.TabIndex = 25;
            // 
            // comboDesActivo
            // 
            this.comboDesActivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDesActivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboDesActivo.FormattingEnabled = true;
            this.comboDesActivo.Location = new System.Drawing.Point(75, 10);
            this.comboDesActivo.Name = "comboDesActivo";
            this.comboDesActivo.Size = new System.Drawing.Size(164, 24);
            this.comboDesActivo.TabIndex = 9;
            // 
            // lbMostrar
            // 
            this.lbMostrar.AutoSize = true;
            this.lbMostrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMostrar.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.lbMostrar.Location = new System.Drawing.Point(13, 13);
            this.lbMostrar.Name = "lbMostrar";
            this.lbMostrar.Size = new System.Drawing.Size(56, 16);
            this.lbMostrar.TabIndex = 0;
            this.lbMostrar.Text = "Mostrar:";
            // 
            // panelResultados
            // 
            this.panelResultados.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panelResultados.Controls.Add(this.lbInfo);
            this.panelResultados.Controls.Add(this.dgridResultados);
            this.panelResultados.Location = new System.Drawing.Point(16, 249);
            this.panelResultados.Name = "panelResultados";
            this.panelResultados.Size = new System.Drawing.Size(512, 211);
            this.panelResultados.TabIndex = 26;
            // 
            // lbInfo
            // 
            this.lbInfo.AutoSize = true;
            this.lbInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInfo.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.lbInfo.Location = new System.Drawing.Point(13, 184);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(446, 16);
            this.lbInfo.TabIndex = 27;
            this.lbInfo.Text = "Haciendo doble click sobre una fila, activas o desactivas <la/el> <param>";
            // 
            // FormBuscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(546, 478);
            this.Controls.Add(this.panelResultados);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelHorario);
            this.Controls.Add(this.panelDias);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.panelBuscar);
            this.Controls.Add(this.lbTitulo);
            this.Controls.Add(this.pboxMinimizar);
            this.Controls.Add(this.pboxCerrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormBuscar";
            this.Text = "FormBuscar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormBuscar_FormClosing);
            this.Load += new System.EventHandler(this.FormBuscar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pboxMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxCerrar)).EndInit();
            this.panelBuscar.ResumeLayout(false);
            this.panelBuscar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgridResultados)).EndInit();
            this.panelDias.ResumeLayout(false);
            this.panelDias.PerformLayout();
            this.panelHorario.ResumeLayout(false);
            this.panelHorario.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelResultados.ResumeLayout(false);
            this.panelResultados.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.PictureBox pboxMinimizar;
        private System.Windows.Forms.PictureBox pboxCerrar;
        private System.Windows.Forms.Panel panelBuscar;
        private System.Windows.Forms.DataGridView dgridResultados;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Panel panelDias;
        private System.Windows.Forms.CheckBox checkDias;
        private System.Windows.Forms.Label lbFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label lbFechaFin;
        private System.Windows.Forms.Panel panelHorario;
        private System.Windows.Forms.DateTimePicker dtpHoraFin;
        private System.Windows.Forms.Label lbHoraFin;
        private System.Windows.Forms.DateTimePicker dtpHoraInicio;
        private System.Windows.Forms.Label lbHoraInicio;
        private System.Windows.Forms.CheckBox checkHorario;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboDesActivo;
        private System.Windows.Forms.Label lbMostrar;
        private System.Windows.Forms.Panel panelResultados;
        private System.Windows.Forms.Label lbInfo;
    }
}