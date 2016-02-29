namespace CarteleriaDigital.GUI
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbMarquesina = new System.Windows.Forms.Label();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.lbOlvideContraseña = new System.Windows.Forms.LinkLabel();
            this.lbRegistrar = new System.Windows.Forms.LinkLabel();
            this.btnEntrar = new System.Windows.Forms.Button();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.pboxMinimizar = new System.Windows.Forms.PictureBox();
            this.pboxLogin = new System.Windows.Forms.PictureBox();
            this.pboxCerrar = new System.Windows.Forms.PictureBox();
            this.pboxSlide = new System.Windows.Forms.PictureBox();
            this.panelLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxSlide)).BeginInit();
            this.SuspendLayout();
            // 
            // lbMarquesina
            // 
            this.lbMarquesina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbMarquesina.AutoSize = true;
            this.lbMarquesina.BackColor = System.Drawing.Color.DarkCyan;
            this.lbMarquesina.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMarquesina.ForeColor = System.Drawing.Color.White;
            this.lbMarquesina.Location = new System.Drawing.Point(10, 270);
            this.lbMarquesina.Name = "lbMarquesina";
            this.lbMarquesina.Size = new System.Drawing.Size(1112, 20);
            this.lbMarquesina.TabIndex = 1;
            this.lbMarquesina.Text = "Luego de que el ministro de Hacienda, Alfonso Prat Gay, y el jefe de Gabinete, Ma" +
    "rcos Peña, anunciaran que el gobierno nacional había...";
            // 
            // panelLogin
            // 
            this.panelLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panelLogin.Controls.Add(this.lbOlvideContraseña);
            this.panelLogin.Controls.Add(this.lbRegistrar);
            this.panelLogin.Controls.Add(this.btnEntrar);
            this.panelLogin.Controls.Add(this.txtContraseña);
            this.panelLogin.Controls.Add(this.txtUsuario);
            this.panelLogin.Location = new System.Drawing.Point(500, 110);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(120, 150);
            this.panelLogin.TabIndex = 4;
            // 
            // lbOlvideContraseña
            // 
            this.lbOlvideContraseña.AutoSize = true;
            this.lbOlvideContraseña.Location = new System.Drawing.Point(7, 122);
            this.lbOlvideContraseña.Name = "lbOlvideContraseña";
            this.lbOlvideContraseña.Size = new System.Drawing.Size(106, 13);
            this.lbOlvideContraseña.TabIndex = 5;
            this.lbOlvideContraseña.TabStop = true;
            this.lbOlvideContraseña.Text = "Olvidé mi contraseña";
            this.lbOlvideContraseña.Click += new System.EventHandler(this.lbOlvideContraseña_Click);
            // 
            // lbRegistrar
            // 
            this.lbRegistrar.AutoSize = true;
            this.lbRegistrar.Location = new System.Drawing.Point(7, 102);
            this.lbRegistrar.Name = "lbRegistrar";
            this.lbRegistrar.Size = new System.Drawing.Size(60, 13);
            this.lbRegistrar.TabIndex = 4;
            this.lbRegistrar.TabStop = true;
            this.lbRegistrar.Text = "Registrarse";
            this.lbRegistrar.Click += new System.EventHandler(this.lbRegistrar_Click);
            // 
            // btnEntrar
            // 
            this.btnEntrar.Location = new System.Drawing.Point(10, 64);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(100, 23);
            this.btnEntrar.TabIndex = 1;
            this.btnEntrar.Text = "Entrar";
            this.btnEntrar.UseVisualStyleBackColor = true;
            this.btnEntrar.Click += new System.EventHandler(this.btnEntrar_Click);
            // 
            // txtContraseña
            // 
            this.txtContraseña.Location = new System.Drawing.Point(10, 38);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.PasswordChar = '•';
            this.txtContraseña.Size = new System.Drawing.Size(100, 20);
            this.txtContraseña.TabIndex = 3;
            this.txtContraseña.Text = "Contraseña";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(10, 12);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(100, 20);
            this.txtUsuario.TabIndex = 2;
            this.txtUsuario.Text = "Usuario";
            // 
            // pboxMinimizar
            // 
            this.pboxMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pboxMinimizar.Image = global::CarteleriaDigital.Properties.Resources._pboxMinimizar;
            this.pboxMinimizar.Location = new System.Drawing.Point(450, 5);
            this.pboxMinimizar.Name = "pboxMinimizar";
            this.pboxMinimizar.Size = new System.Drawing.Size(20, 20);
            this.pboxMinimizar.TabIndex = 7;
            this.pboxMinimizar.TabStop = false;
            this.pboxMinimizar.Click += new System.EventHandler(this.pboxMinimizar_Click);
            // 
            // pboxLogin
            // 
            this.pboxLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pboxLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pboxLogin.Image = global::CarteleriaDigital.Properties.Resources._pboxLogin;
            this.pboxLogin.Location = new System.Drawing.Point(480, 200);
            this.pboxLogin.Name = "pboxLogin";
            this.pboxLogin.Size = new System.Drawing.Size(20, 60);
            this.pboxLogin.TabIndex = 6;
            this.pboxLogin.TabStop = false;
            this.pboxLogin.Click += new System.EventHandler(this.pboxLogin_Click);
            // 
            // pboxCerrar
            // 
            this.pboxCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pboxCerrar.Image = global::CarteleriaDigital.Properties.Resources._pboxCerrar;
            this.pboxCerrar.Location = new System.Drawing.Point(475, 5);
            this.pboxCerrar.Name = "pboxCerrar";
            this.pboxCerrar.Size = new System.Drawing.Size(20, 20);
            this.pboxCerrar.TabIndex = 5;
            this.pboxCerrar.TabStop = false;
            this.pboxCerrar.Click += new System.EventHandler(this.pboxCerrar_Click);
            // 
            // pboxSlide
            // 
            this.pboxSlide.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pboxSlide.BackColor = System.Drawing.Color.DarkSlateGray;
            this.pboxSlide.Image = global::CarteleriaDigital.Properties.Resources._campaña_gonews;
            this.pboxSlide.Location = new System.Drawing.Point(0, 0);
            this.pboxSlide.Margin = new System.Windows.Forms.Padding(0);
            this.pboxSlide.Name = "pboxSlide";
            this.pboxSlide.Size = new System.Drawing.Size(500, 260);
            this.pboxSlide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxSlide.TabIndex = 0;
            this.pboxSlide.TabStop = false;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(500, 300);
            this.Controls.Add(this.pboxMinimizar);
            this.Controls.Add(this.pboxLogin);
            this.Controls.Add(this.pboxCerrar);
            this.Controls.Add(this.panelLogin);
            this.Controls.Add(this.lbMarquesina);
            this.Controls.Add(this.pboxSlide);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxSlide)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pboxSlide;
        private System.Windows.Forms.Label lbMarquesina;
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.LinkLabel lbOlvideContraseña;
        private System.Windows.Forms.LinkLabel lbRegistrar;
        private System.Windows.Forms.Button btnEntrar;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.PictureBox pboxCerrar;
        private System.Windows.Forms.PictureBox pboxLogin;
        private System.Windows.Forms.PictureBox pboxMinimizar;
    }
}

