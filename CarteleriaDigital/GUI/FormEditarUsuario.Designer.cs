namespace CarteleriaDigital.GUI
{
    partial class FormEditarUsuario
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
            this.panelDatosUsuario = new System.Windows.Forms.Panel();
            this.lbDatosUsuario = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtNombreCompleto = new System.Windows.Forms.TextBox();
            this.txtNombreUsuario = new System.Windows.Forms.TextBox();
            this.btnCambiar = new System.Windows.Forms.Button();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.pboxMinimizar = new System.Windows.Forms.PictureBox();
            this.pboxCerrar = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbCambiarContraseña = new System.Windows.Forms.Label();
            this.txtNuevaContraseñaRepetir = new System.Windows.Forms.TextBox();
            this.txtNuevaContraseña = new System.Windows.Forms.TextBox();
            this.panelDatosUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxCerrar)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDatosUsuario
            // 
            this.panelDatosUsuario.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panelDatosUsuario.Controls.Add(this.lbDatosUsuario);
            this.panelDatosUsuario.Controls.Add(this.txtEmail);
            this.panelDatosUsuario.Controls.Add(this.txtNombreCompleto);
            this.panelDatosUsuario.Controls.Add(this.txtNombreUsuario);
            this.panelDatosUsuario.Location = new System.Drawing.Point(12, 44);
            this.panelDatosUsuario.Name = "panelDatosUsuario";
            this.panelDatosUsuario.Size = new System.Drawing.Size(210, 142);
            this.panelDatosUsuario.TabIndex = 23;
            // 
            // lbDatosUsuario
            // 
            this.lbDatosUsuario.AutoSize = true;
            this.lbDatosUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDatosUsuario.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.lbDatosUsuario.Location = new System.Drawing.Point(13, 13);
            this.lbDatosUsuario.Name = "lbDatosUsuario";
            this.lbDatosUsuario.Size = new System.Drawing.Size(116, 16);
            this.lbDatosUsuario.TabIndex = 24;
            this.lbDatosUsuario.Text = "Datos del usuario:";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(13, 102);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(183, 26);
            this.txtEmail.TabIndex = 16;
            this.txtEmail.Text = "nombre@correo.com";
            // 
            // txtNombreCompleto
            // 
            this.txtNombreCompleto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreCompleto.ForeColor = System.Drawing.Color.Black;
            this.txtNombreCompleto.Location = new System.Drawing.Point(13, 38);
            this.txtNombreCompleto.Name = "txtNombreCompleto";
            this.txtNombreCompleto.Size = new System.Drawing.Size(183, 26);
            this.txtNombreCompleto.TabIndex = 10;
            this.txtNombreCompleto.Text = "Nombre Completo";
            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreUsuario.Location = new System.Drawing.Point(13, 70);
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.Size = new System.Drawing.Size(183, 26);
            this.txtNombreUsuario.TabIndex = 12;
            this.txtNombreUsuario.Text = "Nombre Usuario";
            // 
            // btnCambiar
            // 
            this.btnCambiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCambiar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCambiar.Location = new System.Drawing.Point(122, 308);
            this.btnCambiar.Name = "btnCambiar";
            this.btnCambiar.Size = new System.Drawing.Size(100, 30);
            this.btnCambiar.TabIndex = 22;
            this.btnCambiar.Text = "ACEPTAR";
            this.btnCambiar.UseVisualStyleBackColor = true;
            this.btnCambiar.Click += new System.EventHandler(this.btnCambiar_Click);
            // 
            // lbTitulo
            // 
            this.lbTitulo.AutoSize = true;
            this.lbTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.ForeColor = System.Drawing.Color.White;
            this.lbTitulo.Location = new System.Drawing.Point(12, 12);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(121, 20);
            this.lbTitulo.TabIndex = 21;
            this.lbTitulo.Text = "Editar usuario";
            // 
            // pboxMinimizar
            // 
            this.pboxMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pboxMinimizar.Image = global::CarteleriaDigital.Properties.Resources._pboxMinimizar;
            this.pboxMinimizar.Location = new System.Drawing.Point(177, 12);
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
            this.pboxCerrar.Location = new System.Drawing.Point(202, 12);
            this.pboxCerrar.Name = "pboxCerrar";
            this.pboxCerrar.Size = new System.Drawing.Size(20, 20);
            this.pboxCerrar.TabIndex = 19;
            this.pboxCerrar.TabStop = false;
            this.pboxCerrar.Click += new System.EventHandler(this.pboxCerrar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.lbCambiarContraseña);
            this.panel1.Controls.Add(this.txtNuevaContraseñaRepetir);
            this.panel1.Controls.Add(this.txtNuevaContraseña);
            this.panel1.Location = new System.Drawing.Point(12, 192);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(210, 110);
            this.panel1.TabIndex = 24;
            // 
            // lbCambiarContraseña
            // 
            this.lbCambiarContraseña.AutoSize = true;
            this.lbCambiarContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCambiarContraseña.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.lbCambiarContraseña.Location = new System.Drawing.Point(13, 13);
            this.lbCambiarContraseña.Name = "lbCambiarContraseña";
            this.lbCambiarContraseña.Size = new System.Drawing.Size(132, 16);
            this.lbCambiarContraseña.TabIndex = 23;
            this.lbCambiarContraseña.Text = "Cambiar contraseña:";
            // 
            // txtNuevaContraseñaRepetir
            // 
            this.txtNuevaContraseñaRepetir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNuevaContraseñaRepetir.Location = new System.Drawing.Point(13, 70);
            this.txtNuevaContraseñaRepetir.Name = "txtNuevaContraseñaRepetir";
            this.txtNuevaContraseñaRepetir.PasswordChar = '•';
            this.txtNuevaContraseñaRepetir.Size = new System.Drawing.Size(183, 26);
            this.txtNuevaContraseñaRepetir.TabIndex = 14;
            this.txtNuevaContraseñaRepetir.Text = "Repetir Nueva contraseña";
            // 
            // txtNuevaContraseña
            // 
            this.txtNuevaContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNuevaContraseña.Location = new System.Drawing.Point(13, 38);
            this.txtNuevaContraseña.Name = "txtNuevaContraseña";
            this.txtNuevaContraseña.PasswordChar = '•';
            this.txtNuevaContraseña.Size = new System.Drawing.Size(183, 26);
            this.txtNuevaContraseña.TabIndex = 13;
            this.txtNuevaContraseña.Text = "Nueva contraseña";
            // 
            // FormEditarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(234, 348);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelDatosUsuario);
            this.Controls.Add(this.btnCambiar);
            this.Controls.Add(this.lbTitulo);
            this.Controls.Add(this.pboxMinimizar);
            this.Controls.Add(this.pboxCerrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormEditarUsuario";
            this.Text = "Editar usuario";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEditarUsuario_FormClosing);
            this.Load += new System.EventHandler(this.FormEditarUsuario_Load);
            this.panelDatosUsuario.ResumeLayout(false);
            this.panelDatosUsuario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxCerrar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelDatosUsuario;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtNombreCompleto;
        private System.Windows.Forms.TextBox txtNombreUsuario;
        private System.Windows.Forms.Button btnCambiar;
        private System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.PictureBox pboxMinimizar;
        private System.Windows.Forms.PictureBox pboxCerrar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtNuevaContraseñaRepetir;
        private System.Windows.Forms.TextBox txtNuevaContraseña;
        private System.Windows.Forms.Label lbCambiarContraseña;
        private System.Windows.Forms.Label lbDatosUsuario;
    }
}