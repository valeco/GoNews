namespace CarteleriaDigital.GUI
{
    partial class FormAdministrar
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
            this.panelCampaña = new System.Windows.Forms.Panel();
            this.btnBuscarCampaña = new System.Windows.Forms.Button();
            this.btnModificarCampaña = new System.Windows.Forms.Button();
            this.btnEliminarCampaña = new System.Windows.Forms.Button();
            this.lbCampaña = new System.Windows.Forms.Label();
            this.btnAgregarCampaña = new System.Windows.Forms.Button();
            this.ttipBotones = new System.Windows.Forms.ToolTip(this.components);
            this.btnGestionar = new System.Windows.Forms.Button();
            this.btnEditarUsuario = new System.Windows.Forms.Button();
            this.btnBuscarBanner = new System.Windows.Forms.Button();
            this.btnModificarBanner = new System.Windows.Forms.Button();
            this.btnEliminarBanner = new System.Windows.Forms.Button();
            this.btnAgregarBanner = new System.Windows.Forms.Button();
            this.panelBanner = new System.Windows.Forms.Panel();
            this.lbBanner = new System.Windows.Forms.Label();
            this.panelUsuario = new System.Windows.Forms.Panel();
            this.lbEmail = new System.Windows.Forms.Label();
            this.lbNombreCompleto = new System.Windows.Forms.Label();
            this.lbUsuario = new System.Windows.Forms.Label();
            this.panelRSS = new System.Windows.Forms.Panel();
            this.lbDescripcionRSS = new System.Windows.Forms.Label();
            this.lbRSS = new System.Windows.Forms.Label();
            this.pboxMinimizar = new System.Windows.Forms.PictureBox();
            this.pboxCerrar = new System.Windows.Forms.PictureBox();
            this.panelCampaña.SuspendLayout();
            this.panelBanner.SuspendLayout();
            this.panelUsuario.SuspendLayout();
            this.panelRSS.SuspendLayout();
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
            this.lbTitulo.Size = new System.Drawing.Size(100, 20);
            this.lbTitulo.TabIndex = 14;
            this.lbTitulo.Text = "Administrar";
            // 
            // panelCampaña
            // 
            this.panelCampaña.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panelCampaña.Controls.Add(this.btnBuscarCampaña);
            this.panelCampaña.Controls.Add(this.btnModificarCampaña);
            this.panelCampaña.Controls.Add(this.btnEliminarCampaña);
            this.panelCampaña.Controls.Add(this.lbCampaña);
            this.panelCampaña.Controls.Add(this.btnAgregarCampaña);
            this.panelCampaña.Location = new System.Drawing.Point(16, 130);
            this.panelCampaña.Name = "panelCampaña";
            this.panelCampaña.Size = new System.Drawing.Size(117, 138);
            this.panelCampaña.TabIndex = 15;
            // 
            // btnBuscarCampaña
            // 
            this.btnBuscarCampaña.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscarCampaña.Image = global::CarteleriaDigital.Properties.Resources._btnBuscar;
            this.btnBuscarCampaña.Location = new System.Drawing.Point(62, 83);
            this.btnBuscarCampaña.Name = "btnBuscarCampaña";
            this.btnBuscarCampaña.Size = new System.Drawing.Size(40, 40);
            this.btnBuscarCampaña.TabIndex = 19;
            this.ttipBotones.SetToolTip(this.btnBuscarCampaña, "Buscar una campaña");
            this.btnBuscarCampaña.UseVisualStyleBackColor = true;
            this.btnBuscarCampaña.Click += new System.EventHandler(this.btnBuscarCampaña_Click);
            // 
            // btnModificarCampaña
            // 
            this.btnModificarCampaña.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnModificarCampaña.Image = global::CarteleriaDigital.Properties.Resources._btnEditar;
            this.btnModificarCampaña.Location = new System.Drawing.Point(16, 83);
            this.btnModificarCampaña.Name = "btnModificarCampaña";
            this.btnModificarCampaña.Size = new System.Drawing.Size(40, 40);
            this.btnModificarCampaña.TabIndex = 18;
            this.ttipBotones.SetToolTip(this.btnModificarCampaña, "Modificar una campaña");
            this.btnModificarCampaña.UseVisualStyleBackColor = true;
            this.btnModificarCampaña.Click += new System.EventHandler(this.btnModificarCampaña_Click);
            // 
            // btnEliminarCampaña
            // 
            this.btnEliminarCampaña.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminarCampaña.Image = global::CarteleriaDigital.Properties.Resources._btnEliminar;
            this.btnEliminarCampaña.Location = new System.Drawing.Point(62, 37);
            this.btnEliminarCampaña.Name = "btnEliminarCampaña";
            this.btnEliminarCampaña.Size = new System.Drawing.Size(40, 40);
            this.btnEliminarCampaña.TabIndex = 17;
            this.ttipBotones.SetToolTip(this.btnEliminarCampaña, "Eliminar una campaña");
            this.btnEliminarCampaña.UseVisualStyleBackColor = true;
            this.btnEliminarCampaña.Click += new System.EventHandler(this.btnEliminarCampaña_Click);
            // 
            // lbCampaña
            // 
            this.lbCampaña.AutoSize = true;
            this.lbCampaña.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCampaña.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.lbCampaña.Location = new System.Drawing.Point(13, 11);
            this.lbCampaña.Name = "lbCampaña";
            this.lbCampaña.Size = new System.Drawing.Size(91, 17);
            this.lbCampaña.TabIndex = 16;
            this.lbCampaña.Text = "CAMPAÑAS";
            // 
            // btnAgregarCampaña
            // 
            this.btnAgregarCampaña.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregarCampaña.Image = global::CarteleriaDigital.Properties.Resources._btnAgregar;
            this.btnAgregarCampaña.Location = new System.Drawing.Point(16, 37);
            this.btnAgregarCampaña.Name = "btnAgregarCampaña";
            this.btnAgregarCampaña.Padding = new System.Windows.Forms.Padding(5);
            this.btnAgregarCampaña.Size = new System.Drawing.Size(40, 40);
            this.btnAgregarCampaña.TabIndex = 16;
            this.ttipBotones.SetToolTip(this.btnAgregarCampaña, "Agregar una nueva campaña");
            this.btnAgregarCampaña.UseVisualStyleBackColor = true;
            this.btnAgregarCampaña.Click += new System.EventHandler(this.btnAgregarCampaña_Click);
            // 
            // btnGestionar
            // 
            this.btnGestionar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGestionar.Image = global::CarteleriaDigital.Properties.Resources._btnGestionar;
            this.btnGestionar.Location = new System.Drawing.Point(180, 11);
            this.btnGestionar.Name = "btnGestionar";
            this.btnGestionar.Size = new System.Drawing.Size(40, 40);
            this.btnGestionar.TabIndex = 21;
            this.ttipBotones.SetToolTip(this.btnGestionar, "Gestionar las fuentes RSS");
            this.btnGestionar.UseVisualStyleBackColor = true;
            this.btnGestionar.Click += new System.EventHandler(this.btnGestionar_Click);
            // 
            // btnEditarUsuario
            // 
            this.btnEditarUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEditarUsuario.Image = global::CarteleriaDigital.Properties.Resources._btnEditar;
            this.btnEditarUsuario.Location = new System.Drawing.Point(180, 20);
            this.btnEditarUsuario.Name = "btnEditarUsuario";
            this.btnEditarUsuario.Size = new System.Drawing.Size(40, 40);
            this.btnEditarUsuario.TabIndex = 20;
            this.ttipBotones.SetToolTip(this.btnEditarUsuario, "Editar datos del usuario");
            this.btnEditarUsuario.UseVisualStyleBackColor = true;
            this.btnEditarUsuario.Click += new System.EventHandler(this.btnEditarUsuario_Click);
            // 
            // btnBuscarBanner
            // 
            this.btnBuscarBanner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscarBanner.Image = global::CarteleriaDigital.Properties.Resources._btnBuscar;
            this.btnBuscarBanner.Location = new System.Drawing.Point(62, 83);
            this.btnBuscarBanner.Name = "btnBuscarBanner";
            this.btnBuscarBanner.Size = new System.Drawing.Size(40, 40);
            this.btnBuscarBanner.TabIndex = 19;
            this.ttipBotones.SetToolTip(this.btnBuscarBanner, "Buscar un banner");
            this.btnBuscarBanner.UseVisualStyleBackColor = true;
            this.btnBuscarBanner.Click += new System.EventHandler(this.btnBuscarBanner_Click);
            // 
            // btnModificarBanner
            // 
            this.btnModificarBanner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnModificarBanner.Image = global::CarteleriaDigital.Properties.Resources._btnEditar;
            this.btnModificarBanner.Location = new System.Drawing.Point(16, 83);
            this.btnModificarBanner.Name = "btnModificarBanner";
            this.btnModificarBanner.Size = new System.Drawing.Size(40, 40);
            this.btnModificarBanner.TabIndex = 18;
            this.ttipBotones.SetToolTip(this.btnModificarBanner, "Modificar un banner");
            this.btnModificarBanner.UseVisualStyleBackColor = true;
            this.btnModificarBanner.Click += new System.EventHandler(this.btnModificarBanner_Click);
            // 
            // btnEliminarBanner
            // 
            this.btnEliminarBanner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminarBanner.Image = global::CarteleriaDigital.Properties.Resources._btnEliminar;
            this.btnEliminarBanner.Location = new System.Drawing.Point(62, 37);
            this.btnEliminarBanner.Name = "btnEliminarBanner";
            this.btnEliminarBanner.Size = new System.Drawing.Size(40, 40);
            this.btnEliminarBanner.TabIndex = 17;
            this.ttipBotones.SetToolTip(this.btnEliminarBanner, "Eliminar un banner");
            this.btnEliminarBanner.UseVisualStyleBackColor = true;
            this.btnEliminarBanner.Click += new System.EventHandler(this.btnEliminarBanner_Click);
            // 
            // btnAgregarBanner
            // 
            this.btnAgregarBanner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregarBanner.Image = global::CarteleriaDigital.Properties.Resources._btnAgregar;
            this.btnAgregarBanner.Location = new System.Drawing.Point(16, 37);
            this.btnAgregarBanner.Name = "btnAgregarBanner";
            this.btnAgregarBanner.Padding = new System.Windows.Forms.Padding(5);
            this.btnAgregarBanner.Size = new System.Drawing.Size(40, 40);
            this.btnAgregarBanner.TabIndex = 16;
            this.ttipBotones.SetToolTip(this.btnAgregarBanner, "Agregar un nuevo banner");
            this.btnAgregarBanner.UseVisualStyleBackColor = true;
            this.btnAgregarBanner.Click += new System.EventHandler(this.btnAgregarBanner_Click);
            // 
            // panelBanner
            // 
            this.panelBanner.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panelBanner.Controls.Add(this.btnBuscarBanner);
            this.panelBanner.Controls.Add(this.btnModificarBanner);
            this.panelBanner.Controls.Add(this.btnEliminarBanner);
            this.panelBanner.Controls.Add(this.lbBanner);
            this.panelBanner.Controls.Add(this.btnAgregarBanner);
            this.panelBanner.Location = new System.Drawing.Point(139, 130);
            this.panelBanner.Name = "panelBanner";
            this.panelBanner.Size = new System.Drawing.Size(117, 138);
            this.panelBanner.TabIndex = 16;
            // 
            // lbBanner
            // 
            this.lbBanner.AutoSize = true;
            this.lbBanner.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBanner.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.lbBanner.Location = new System.Drawing.Point(19, 11);
            this.lbBanner.Name = "lbBanner";
            this.lbBanner.Size = new System.Drawing.Size(81, 17);
            this.lbBanner.TabIndex = 16;
            this.lbBanner.Text = "BANNERS";
            this.lbBanner.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelUsuario
            // 
            this.panelUsuario.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panelUsuario.Controls.Add(this.btnEditarUsuario);
            this.panelUsuario.Controls.Add(this.lbEmail);
            this.panelUsuario.Controls.Add(this.lbNombreCompleto);
            this.panelUsuario.Controls.Add(this.lbUsuario);
            this.panelUsuario.Location = new System.Drawing.Point(16, 43);
            this.panelUsuario.Name = "panelUsuario";
            this.panelUsuario.Size = new System.Drawing.Size(240, 81);
            this.panelUsuario.TabIndex = 18;
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbEmail.Location = new System.Drawing.Point(15, 52);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(113, 13);
            this.lbEmail.TabIndex = 18;
            this.lbEmail.Text = "rubenrada@gmail.com";
            // 
            // lbNombreCompleto
            // 
            this.lbNombreCompleto.AutoSize = true;
            this.lbNombreCompleto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNombreCompleto.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbNombreCompleto.Location = new System.Drawing.Point(13, 37);
            this.lbNombreCompleto.Name = "lbNombreCompleto";
            this.lbNombreCompleto.Size = new System.Drawing.Size(78, 13);
            this.lbNombreCompleto.TabIndex = 17;
            this.lbNombreCompleto.Text = "Ruben Rada";
            // 
            // lbUsuario
            // 
            this.lbUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbUsuario.AutoSize = true;
            this.lbUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUsuario.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.lbUsuario.Location = new System.Drawing.Point(13, 10);
            this.lbUsuario.Name = "lbUsuario";
            this.lbUsuario.Size = new System.Drawing.Size(77, 17);
            this.lbUsuario.TabIndex = 16;
            this.lbUsuario.Text = "USUARIO";
            // 
            // panelRSS
            // 
            this.panelRSS.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panelRSS.Controls.Add(this.lbDescripcionRSS);
            this.panelRSS.Controls.Add(this.btnGestionar);
            this.panelRSS.Controls.Add(this.lbRSS);
            this.panelRSS.Location = new System.Drawing.Point(16, 274);
            this.panelRSS.Name = "panelRSS";
            this.panelRSS.Size = new System.Drawing.Size(240, 63);
            this.panelRSS.TabIndex = 19;
            // 
            // lbDescripcionRSS
            // 
            this.lbDescripcionRSS.AutoSize = true;
            this.lbDescripcionRSS.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbDescripcionRSS.Location = new System.Drawing.Point(15, 33);
            this.lbDescripcionRSS.Name = "lbDescripcionRSS";
            this.lbDescripcionRSS.Size = new System.Drawing.Size(99, 13);
            this.lbDescripcionRSS.TabIndex = 22;
            this.lbDescripcionRSS.Text = "Fuentes de noticias";
            // 
            // lbRSS
            // 
            this.lbRSS.AutoSize = true;
            this.lbRSS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRSS.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.lbRSS.Location = new System.Drawing.Point(15, 15);
            this.lbRSS.Name = "lbRSS";
            this.lbRSS.Size = new System.Drawing.Size(39, 17);
            this.lbRSS.TabIndex = 16;
            this.lbRSS.Text = "RSS";
            // 
            // pboxMinimizar
            // 
            this.pboxMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pboxMinimizar.Image = global::CarteleriaDigital.Properties.Resources._pboxMinimizar;
            this.pboxMinimizar.Location = new System.Drawing.Point(217, 12);
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
            this.pboxCerrar.Location = new System.Drawing.Point(242, 12);
            this.pboxCerrar.Name = "pboxCerrar";
            this.pboxCerrar.Size = new System.Drawing.Size(20, 20);
            this.pboxCerrar.TabIndex = 12;
            this.pboxCerrar.TabStop = false;
            this.pboxCerrar.Click += new System.EventHandler(this.pboxCerrar_Click);
            // 
            // FormAdministrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(274, 356);
            this.Controls.Add(this.panelRSS);
            this.Controls.Add(this.panelUsuario);
            this.Controls.Add(this.panelBanner);
            this.Controls.Add(this.panelCampaña);
            this.Controls.Add(this.lbTitulo);
            this.Controls.Add(this.pboxMinimizar);
            this.Controls.Add(this.pboxCerrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormAdministrar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAdministrar_FormClosing);
            this.Load += new System.EventHandler(this.FormAdministrar_Load);
            this.panelCampaña.ResumeLayout(false);
            this.panelCampaña.PerformLayout();
            this.panelBanner.ResumeLayout(false);
            this.panelBanner.PerformLayout();
            this.panelUsuario.ResumeLayout(false);
            this.panelUsuario.PerformLayout();
            this.panelRSS.ResumeLayout(false);
            this.panelRSS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxCerrar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.PictureBox pboxMinimizar;
        private System.Windows.Forms.PictureBox pboxCerrar;
        private System.Windows.Forms.Panel panelCampaña;
        private System.Windows.Forms.Button btnAgregarCampaña;
        private System.Windows.Forms.Button btnBuscarCampaña;
        private System.Windows.Forms.Button btnModificarCampaña;
        private System.Windows.Forms.Button btnEliminarCampaña;
        private System.Windows.Forms.Label lbCampaña;
        private System.Windows.Forms.ToolTip ttipBotones;
        private System.Windows.Forms.Panel panelBanner;
        private System.Windows.Forms.Button btnBuscarBanner;
        private System.Windows.Forms.Button btnModificarBanner;
        private System.Windows.Forms.Button btnEliminarBanner;
        private System.Windows.Forms.Label lbBanner;
        private System.Windows.Forms.Button btnAgregarBanner;
        private System.Windows.Forms.Panel panelUsuario;
        private System.Windows.Forms.Button btnEditarUsuario;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.Label lbNombreCompleto;
        private System.Windows.Forms.Label lbUsuario;
        private System.Windows.Forms.Panel panelRSS;
        private System.Windows.Forms.Button btnGestionar;
        private System.Windows.Forms.Label lbRSS;
        private System.Windows.Forms.Label lbDescripcionRSS;
    }
}