namespace CarteleriaDigital.GUI
{
    partial class FormGestionarRSS
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
            this.components = new System.ComponentModel.Container();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.pboxMinimizar = new System.Windows.Forms.PictureBox();
            this.pboxCerrar = new System.Windows.Forms.PictureBox();
            this.btnModificarRSS = new System.Windows.Forms.Button();
            this.btnEliminarRSS = new System.Windows.Forms.Button();
            this.btnAgregarRSS = new System.Windows.Forms.Button();
            this.ttipBotones = new System.Windows.Forms.ToolTip(this.components);
            this.panelBuscar = new System.Windows.Forms.Panel();
            this.dgridFuentesRSS = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.panelAgregar = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.lbAgregarModificar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pboxMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxCerrar)).BeginInit();
            this.panelBuscar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgridFuentesRSS)).BeginInit();
            this.panelAgregar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitulo
            // 
            this.lbTitulo.AutoSize = true;
            this.lbTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.ForeColor = System.Drawing.Color.White;
            this.lbTitulo.Location = new System.Drawing.Point(12, 12);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(130, 20);
            this.lbTitulo.TabIndex = 14;
            this.lbTitulo.Text = "Gestionar RSS";
            // 
            // pboxMinimizar
            // 
            this.pboxMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pboxMinimizar.Image = global::CarteleriaDigital.Properties.Resources._pboxMinimizar;
            this.pboxMinimizar.Location = new System.Drawing.Point(466, 12);
            this.pboxMinimizar.Name = "pboxMinimizar";
            this.pboxMinimizar.Size = new System.Drawing.Size(20, 20);
            this.pboxMinimizar.TabIndex = 13;
            this.pboxMinimizar.TabStop = false;
            this.pboxMinimizar.Click += new System.EventHandler(this.pboxMinimizar_Click);
            // 
            // pboxCerrar
            // 
            this.pboxCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pboxCerrar.Image = global::CarteleriaDigital.Properties.Resources._pboxCerrar;
            this.pboxCerrar.Location = new System.Drawing.Point(491, 12);
            this.pboxCerrar.Name = "pboxCerrar";
            this.pboxCerrar.Size = new System.Drawing.Size(20, 20);
            this.pboxCerrar.TabIndex = 12;
            this.pboxCerrar.TabStop = false;
            this.pboxCerrar.Click += new System.EventHandler(this.pboxCerrar_Click);
            // 
            // btnModificarRSS
            // 
            this.btnModificarRSS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnModificarRSS.Image = global::CarteleriaDigital.Properties.Resources._btnEditar;
            this.btnModificarRSS.Location = new System.Drawing.Point(437, 92);
            this.btnModificarRSS.Name = "btnModificarRSS";
            this.btnModificarRSS.Size = new System.Drawing.Size(40, 40);
            this.btnModificarRSS.TabIndex = 21;
            this.ttipBotones.SetToolTip(this.btnModificarRSS, "Modificar fuente RSS");
            this.btnModificarRSS.UseVisualStyleBackColor = true;
            this.btnModificarRSS.Click += new System.EventHandler(this.btnModificarRSS_Click);
            // 
            // btnEliminarRSS
            // 
            this.btnEliminarRSS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminarRSS.Image = global::CarteleriaDigital.Properties.Resources._btnEliminar;
            this.btnEliminarRSS.Location = new System.Drawing.Point(437, 138);
            this.btnEliminarRSS.Name = "btnEliminarRSS";
            this.btnEliminarRSS.Size = new System.Drawing.Size(40, 40);
            this.btnEliminarRSS.TabIndex = 20;
            this.ttipBotones.SetToolTip(this.btnEliminarRSS, "Eliminar fuente RSS");
            this.btnEliminarRSS.UseVisualStyleBackColor = true;
            // 
            // btnAgregarRSS
            // 
            this.btnAgregarRSS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregarRSS.Image = global::CarteleriaDigital.Properties.Resources._btnAgregar;
            this.btnAgregarRSS.Location = new System.Drawing.Point(437, 46);
            this.btnAgregarRSS.Name = "btnAgregarRSS";
            this.btnAgregarRSS.Padding = new System.Windows.Forms.Padding(5);
            this.btnAgregarRSS.Size = new System.Drawing.Size(40, 40);
            this.btnAgregarRSS.TabIndex = 19;
            this.ttipBotones.SetToolTip(this.btnAgregarRSS, "Agregar fuente RSS");
            this.btnAgregarRSS.UseVisualStyleBackColor = true;
            this.btnAgregarRSS.Click += new System.EventHandler(this.btnAgregarRSS_Click);
            // 
            // panelBuscar
            // 
            this.panelBuscar.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panelBuscar.Controls.Add(this.dgridFuentesRSS);
            this.panelBuscar.Controls.Add(this.btnModificarRSS);
            this.panelBuscar.Controls.Add(this.btnBuscar);
            this.panelBuscar.Controls.Add(this.btnEliminarRSS);
            this.panelBuscar.Controls.Add(this.btnAgregarRSS);
            this.panelBuscar.Controls.Add(this.txtBuscar);
            this.panelBuscar.Location = new System.Drawing.Point(16, 43);
            this.panelBuscar.Name = "panelBuscar";
            this.panelBuscar.Size = new System.Drawing.Size(490, 190);
            this.panelBuscar.TabIndex = 22;
            // 
            // dgridFuentesRSS
            // 
            this.dgridFuentesRSS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgridFuentesRSS.Location = new System.Drawing.Point(13, 45);
            this.dgridFuentesRSS.Name = "dgridFuentesRSS";
            this.dgridFuentesRSS.Size = new System.Drawing.Size(418, 133);
            this.dgridFuentesRSS.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBuscar.Location = new System.Drawing.Point(385, 14);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(92, 26);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.ForeColor = System.Drawing.Color.Black;
            this.txtBuscar.Location = new System.Drawing.Point(13, 13);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(366, 26);
            this.txtBuscar.TabIndex = 2;
            this.txtBuscar.Text = "Ingrese la descripción, la URL o parte de estos...";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.ForeColor = System.Drawing.Color.Black;
            this.txtDescripcion.Location = new System.Drawing.Point(13, 45);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(186, 26);
            this.txtDescripcion.TabIndex = 23;
            this.txtDescripcion.Text = "Descripción";
            // 
            // txtURL
            // 
            this.txtURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtURL.ForeColor = System.Drawing.Color.Black;
            this.txtURL.Location = new System.Drawing.Point(206, 45);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(271, 26);
            this.txtURL.TabIndex = 24;
            this.txtURL.Text = "http://www.pagina.com/rss";
            // 
            // panelAgregar
            // 
            this.panelAgregar.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panelAgregar.Controls.Add(this.btnCancelar);
            this.panelAgregar.Controls.Add(this.btnAceptar);
            this.panelAgregar.Controls.Add(this.lbAgregarModificar);
            this.panelAgregar.Controls.Add(this.txtDescripcion);
            this.panelAgregar.Controls.Add(this.txtURL);
            this.panelAgregar.Location = new System.Drawing.Point(16, 239);
            this.panelAgregar.Name = "panelAgregar";
            this.panelAgregar.Size = new System.Drawing.Size(490, 85);
            this.panelAgregar.TabIndex = 25;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancelar.Location = new System.Drawing.Point(385, 13);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(92, 26);
            this.btnCancelar.TabIndex = 25;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAceptar.Location = new System.Drawing.Point(287, 13);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(92, 26);
            this.btnAceptar.TabIndex = 26;
            this.btnAceptar.Text = "ACEPTAR";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lbAgregarModificar
            // 
            this.lbAgregarModificar.AutoSize = true;
            this.lbAgregarModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAgregarModificar.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.lbAgregarModificar.Location = new System.Drawing.Point(10, 18);
            this.lbAgregarModificar.Name = "lbAgregarModificar";
            this.lbAgregarModificar.Size = new System.Drawing.Size(203, 16);
            this.lbAgregarModificar.TabIndex = 26;
            this.lbAgregarModificar.Text = "<Agregar/Modificar> fuente RSS:";
            // 
            // FormGestionarRSS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(523, 340);
            this.Controls.Add(this.panelAgregar);
            this.Controls.Add(this.panelBuscar);
            this.Controls.Add(this.lbTitulo);
            this.Controls.Add(this.pboxMinimizar);
            this.Controls.Add(this.pboxCerrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormGestionarRSS";
            this.Text = "FormAdministrarRSS";
            this.Load += new System.EventHandler(this.FormGestionarRSS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pboxMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxCerrar)).EndInit();
            this.panelBuscar.ResumeLayout(false);
            this.panelBuscar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgridFuentesRSS)).EndInit();
            this.panelAgregar.ResumeLayout(false);
            this.panelAgregar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.PictureBox pboxMinimizar;
        private System.Windows.Forms.PictureBox pboxCerrar;
        private System.Windows.Forms.Button btnModificarRSS;
        private System.Windows.Forms.Button btnEliminarRSS;
        private System.Windows.Forms.Button btnAgregarRSS;
        private System.Windows.Forms.ToolTip ttipBotones;
        private System.Windows.Forms.Panel panelBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgridFuentesRSS;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Panel panelAgregar;
        private System.Windows.Forms.Label lbAgregarModificar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
    }
}