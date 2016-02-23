namespace CarteleriaDigital.GUI
{
    partial class FormAgregarModificarBanner
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
            this.panelTipo = new System.Windows.Forms.Panel();
            this.radioFuenteRSS = new System.Windows.Forms.RadioButton();
            this.radioTextoFijo = new System.Windows.Forms.RadioButton();
            this.lbTipo = new System.Windows.Forms.Label();
            this.txtNombreBanner = new System.Windows.Forms.TextBox();
            this.panelTextoFijo = new System.Windows.Forms.Panel();
            this.txtTextoFijo = new System.Windows.Forms.TextBox();
            this.lbTextoFijo = new System.Windows.Forms.Label();
            this.panelFuenteRSS = new System.Windows.Forms.Panel();
            this.comboFuenteRSS = new System.Windows.Forms.ComboBox();
            this.lbFuenteRSS = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.panelIntervalo = new System.Windows.Forms.Panel();
            this.lbValorIntervalo = new System.Windows.Forms.Label();
            this.tbarIntervalo = new System.Windows.Forms.TrackBar();
            this.lbIntervalo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pboxMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxCerrar)).BeginInit();
            this.panelTipo.SuspendLayout();
            this.panelTextoFijo.SuspendLayout();
            this.panelFuenteRSS.SuspendLayout();
            this.panelIntervalo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarIntervalo)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitulo
            // 
            this.lbTitulo.AutoSize = true;
            this.lbTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.ForeColor = System.Drawing.Color.White;
            this.lbTitulo.Location = new System.Drawing.Point(12, 12);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(134, 20);
            this.lbTitulo.TabIndex = 18;
            this.lbTitulo.Text = "Agregar banner";
            // 
            // pboxMinimizar
            // 
            this.pboxMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pboxMinimizar.Image = global::CarteleriaDigital.Properties.Resources._pboxMinimizar;
            this.pboxMinimizar.Location = new System.Drawing.Point(481, 12);
            this.pboxMinimizar.Name = "pboxMinimizar";
            this.pboxMinimizar.Size = new System.Drawing.Size(20, 20);
            this.pboxMinimizar.TabIndex = 20;
            this.pboxMinimizar.TabStop = false;
            this.pboxMinimizar.Click += new System.EventHandler(this.pboxMinimizar_Click);
            // 
            // pboxCerrar
            // 
            this.pboxCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pboxCerrar.Image = global::CarteleriaDigital.Properties.Resources._pboxCerrar;
            this.pboxCerrar.Location = new System.Drawing.Point(506, 12);
            this.pboxCerrar.Name = "pboxCerrar";
            this.pboxCerrar.Size = new System.Drawing.Size(20, 20);
            this.pboxCerrar.TabIndex = 19;
            this.pboxCerrar.TabStop = false;
            this.pboxCerrar.Click += new System.EventHandler(this.pboxCerrar_Click);
            // 
            // panelTipo
            // 
            this.panelTipo.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panelTipo.Controls.Add(this.radioFuenteRSS);
            this.panelTipo.Controls.Add(this.radioTextoFijo);
            this.panelTipo.Controls.Add(this.lbTipo);
            this.panelTipo.Location = new System.Drawing.Point(12, 76);
            this.panelTipo.Name = "panelTipo";
            this.panelTipo.Size = new System.Drawing.Size(254, 69);
            this.panelTipo.TabIndex = 1;
            // 
            // radioFuenteRSS
            // 
            this.radioFuenteRSS.AutoSize = true;
            this.radioFuenteRSS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioFuenteRSS.ForeColor = System.Drawing.Color.Gainsboro;
            this.radioFuenteRSS.Location = new System.Drawing.Point(128, 37);
            this.radioFuenteRSS.Name = "radioFuenteRSS";
            this.radioFuenteRSS.Size = new System.Drawing.Size(112, 21);
            this.radioFuenteRSS.TabIndex = 2;
            this.radioFuenteRSS.TabStop = true;
            this.radioFuenteRSS.Text = "Fuente RSS";
            this.radioFuenteRSS.UseVisualStyleBackColor = true;
            this.radioFuenteRSS.CheckedChanged += new System.EventHandler(this.radioFuenteRSS_CheckedChanged);
            // 
            // radioTextoFijo
            // 
            this.radioTextoFijo.AutoSize = true;
            this.radioTextoFijo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioTextoFijo.ForeColor = System.Drawing.Color.Gainsboro;
            this.radioTextoFijo.Location = new System.Drawing.Point(128, 10);
            this.radioTextoFijo.Name = "radioTextoFijo";
            this.radioTextoFijo.Size = new System.Drawing.Size(93, 21);
            this.radioTextoFijo.TabIndex = 1;
            this.radioTextoFijo.TabStop = true;
            this.radioTextoFijo.Text = "Texto fijo";
            this.radioTextoFijo.UseVisualStyleBackColor = true;
            this.radioTextoFijo.CheckedChanged += new System.EventHandler(this.radioTextoFijo_CheckedChanged);
            // 
            // lbTipo
            // 
            this.lbTipo.AutoSize = true;
            this.lbTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTipo.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.lbTipo.Location = new System.Drawing.Point(10, 12);
            this.lbTipo.Name = "lbTipo";
            this.lbTipo.Size = new System.Drawing.Size(103, 16);
            this.lbTipo.TabIndex = 22;
            this.lbTipo.Text = "Tipo de banner:";
            // 
            // txtNombreBanner
            // 
            this.txtNombreBanner.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreBanner.ForeColor = System.Drawing.Color.Black;
            this.txtNombreBanner.Location = new System.Drawing.Point(12, 44);
            this.txtNombreBanner.Name = "txtNombreBanner";
            this.txtNombreBanner.Size = new System.Drawing.Size(254, 26);
            this.txtNombreBanner.TabIndex = 2;
            this.txtNombreBanner.Text = "Nombre del banner";
            this.txtNombreBanner.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panelTextoFijo
            // 
            this.panelTextoFijo.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panelTextoFijo.Controls.Add(this.txtTextoFijo);
            this.panelTextoFijo.Controls.Add(this.lbTextoFijo);
            this.panelTextoFijo.Location = new System.Drawing.Point(272, 76);
            this.panelTextoFijo.Name = "panelTextoFijo";
            this.panelTextoFijo.Size = new System.Drawing.Size(254, 242);
            this.panelTextoFijo.TabIndex = 3;
            // 
            // txtTextoFijo
            // 
            this.txtTextoFijo.Enabled = false;
            this.txtTextoFijo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTextoFijo.Location = new System.Drawing.Point(13, 35);
            this.txtTextoFijo.Multiline = true;
            this.txtTextoFijo.Name = "txtTextoFijo";
            this.txtTextoFijo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTextoFijo.Size = new System.Drawing.Size(227, 193);
            this.txtTextoFijo.TabIndex = 4;
            this.txtTextoFijo.Text = "Escribe aquí el texto que deseas mostrar. Puedes ingresar saltos de líneas, pero " +
    "en pantalla se verá el texto en una sola línea.";
            // 
            // lbTextoFijo
            // 
            this.lbTextoFijo.AutoSize = true;
            this.lbTextoFijo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTextoFijo.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.lbTextoFijo.Location = new System.Drawing.Point(10, 12);
            this.lbTextoFijo.Name = "lbTextoFijo";
            this.lbTextoFijo.Size = new System.Drawing.Size(65, 16);
            this.lbTextoFijo.TabIndex = 22;
            this.lbTextoFijo.Text = "Texto fijo:";
            // 
            // panelFuenteRSS
            // 
            this.panelFuenteRSS.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panelFuenteRSS.Controls.Add(this.comboFuenteRSS);
            this.panelFuenteRSS.Controls.Add(this.lbFuenteRSS);
            this.panelFuenteRSS.Location = new System.Drawing.Point(12, 245);
            this.panelFuenteRSS.Name = "panelFuenteRSS";
            this.panelFuenteRSS.Size = new System.Drawing.Size(254, 73);
            this.panelFuenteRSS.TabIndex = 4;
            // 
            // comboFuenteRSS
            // 
            this.comboFuenteRSS.Enabled = false;
            this.comboFuenteRSS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboFuenteRSS.FormattingEnabled = true;
            this.comboFuenteRSS.Location = new System.Drawing.Point(13, 35);
            this.comboFuenteRSS.Name = "comboFuenteRSS";
            this.comboFuenteRSS.Size = new System.Drawing.Size(227, 24);
            this.comboFuenteRSS.TabIndex = 5;
            this.comboFuenteRSS.Text = "Seleccionar fuente RSS...";
            // 
            // lbFuenteRSS
            // 
            this.lbFuenteRSS.AutoSize = true;
            this.lbFuenteRSS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFuenteRSS.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.lbFuenteRSS.Location = new System.Drawing.Point(10, 12);
            this.lbFuenteRSS.Name = "lbFuenteRSS";
            this.lbFuenteRSS.Size = new System.Drawing.Size(83, 16);
            this.lbFuenteRSS.TabIndex = 22;
            this.lbFuenteRSS.Text = "Fuente RSS:";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.Black;
            this.btnAgregar.Location = new System.Drawing.Point(426, 324);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(100, 30);
            this.btnAgregar.TabIndex = 5;
            this.btnAgregar.Text = "AGREGAR";
            this.btnAgregar.UseVisualStyleBackColor = true;
            // 
            // panelIntervalo
            // 
            this.panelIntervalo.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panelIntervalo.Controls.Add(this.lbValorIntervalo);
            this.panelIntervalo.Controls.Add(this.tbarIntervalo);
            this.panelIntervalo.Controls.Add(this.lbIntervalo);
            this.panelIntervalo.Location = new System.Drawing.Point(12, 151);
            this.panelIntervalo.Name = "panelIntervalo";
            this.panelIntervalo.Size = new System.Drawing.Size(254, 88);
            this.panelIntervalo.TabIndex = 21;
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
            // lbIntervalo
            // 
            this.lbIntervalo.AutoSize = true;
            this.lbIntervalo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIntervalo.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.lbIntervalo.Location = new System.Drawing.Point(10, 12);
            this.lbIntervalo.Name = "lbIntervalo";
            this.lbIntervalo.Size = new System.Drawing.Size(138, 32);
            this.lbIntervalo.TabIndex = 21;
            this.lbIntervalo.Text = "Intervalo de transición\r\nentre textos:";
            // 
            // FormAgregarModificarBanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(538, 365);
            this.Controls.Add(this.panelIntervalo);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.panelFuenteRSS);
            this.Controls.Add(this.panelTextoFijo);
            this.Controls.Add(this.panelTipo);
            this.Controls.Add(this.txtNombreBanner);
            this.Controls.Add(this.pboxMinimizar);
            this.Controls.Add(this.pboxCerrar);
            this.Controls.Add(this.lbTitulo);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormAgregarModificarBanner";
            this.Text = "Agregar banner";
            this.Load += new System.EventHandler(this.FormAgregarModificarBanner_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pboxMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxCerrar)).EndInit();
            this.panelTipo.ResumeLayout(false);
            this.panelTipo.PerformLayout();
            this.panelTextoFijo.ResumeLayout(false);
            this.panelTextoFijo.PerformLayout();
            this.panelFuenteRSS.ResumeLayout(false);
            this.panelFuenteRSS.PerformLayout();
            this.panelIntervalo.ResumeLayout(false);
            this.panelIntervalo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarIntervalo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.PictureBox pboxMinimizar;
        private System.Windows.Forms.PictureBox pboxCerrar;
        private System.Windows.Forms.Panel panelTipo;
        private System.Windows.Forms.Label lbTipo;
        private System.Windows.Forms.TextBox txtNombreBanner;
        private System.Windows.Forms.RadioButton radioFuenteRSS;
        private System.Windows.Forms.RadioButton radioTextoFijo;
        private System.Windows.Forms.Panel panelTextoFijo;
        private System.Windows.Forms.TextBox txtTextoFijo;
        private System.Windows.Forms.Label lbTextoFijo;
        private System.Windows.Forms.Panel panelFuenteRSS;
        private System.Windows.Forms.Label lbFuenteRSS;
        private System.Windows.Forms.ComboBox comboFuenteRSS;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Panel panelIntervalo;
        private System.Windows.Forms.Label lbValorIntervalo;
        private System.Windows.Forms.TrackBar tbarIntervalo;
        private System.Windows.Forms.Label lbIntervalo;
    }
}