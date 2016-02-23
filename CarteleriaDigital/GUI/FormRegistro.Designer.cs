namespace CarteleriaDigital.GUI
{
    partial class FormRegistro
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
            this.txtNombreCompleto = new System.Windows.Forms.TextBox();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.txtNombreUsuario = new System.Windows.Forms.TextBox();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.txtRepetirContraseña = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.pboxMinimizar = new System.Windows.Forms.PictureBox();
            this.pboxCerrar = new System.Windows.Forms.PictureBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.panelRegistro = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pboxMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxCerrar)).BeginInit();
            this.panelRegistro.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNombreCompleto
            // 
            this.txtNombreCompleto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreCompleto.ForeColor = System.Drawing.Color.Black;
            this.txtNombreCompleto.Location = new System.Drawing.Point(13, 13);
            this.txtNombreCompleto.Name = "txtNombreCompleto";
            this.txtNombreCompleto.Size = new System.Drawing.Size(183, 26);
            this.txtNombreCompleto.TabIndex = 10;
            this.txtNombreCompleto.Text = "Nombre completo";
            // 
            // lbTitulo
            // 
            this.lbTitulo.AutoSize = true;
            this.lbTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.ForeColor = System.Drawing.Color.White;
            this.lbTitulo.Location = new System.Drawing.Point(12, 12);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(77, 20);
            this.lbTitulo.TabIndex = 11;
            this.lbTitulo.Text = "Registro";
            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreUsuario.Location = new System.Drawing.Point(13, 45);
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.Size = new System.Drawing.Size(183, 26);
            this.txtNombreUsuario.TabIndex = 12;
            this.txtNombreUsuario.Text = "Nombre de usuario";
            // 
            // txtContraseña
            // 
            this.txtContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContraseña.Location = new System.Drawing.Point(13, 77);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Size = new System.Drawing.Size(183, 26);
            this.txtContraseña.TabIndex = 13;
            this.txtContraseña.Text = "Contraseña";
            // 
            // txtRepetirContraseña
            // 
            this.txtRepetirContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRepetirContraseña.Location = new System.Drawing.Point(13, 109);
            this.txtRepetirContraseña.Name = "txtRepetirContraseña";
            this.txtRepetirContraseña.Size = new System.Drawing.Size(183, 26);
            this.txtRepetirContraseña.TabIndex = 14;
            this.txtRepetirContraseña.Text = "Reescribir contraseña";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(13, 141);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(183, 26);
            this.txtEmail.TabIndex = 16;
            this.txtEmail.Text = "Email";
            // 
            // pboxMinimizar
            // 
            this.pboxMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pboxMinimizar.Image = global::CarteleriaDigital.Properties.Resources._pboxMinimizar;
            this.pboxMinimizar.Location = new System.Drawing.Point(178, 12);
            this.pboxMinimizar.Name = "pboxMinimizar";
            this.pboxMinimizar.Size = new System.Drawing.Size(20, 20);
            this.pboxMinimizar.TabIndex = 9;
            this.pboxMinimizar.TabStop = false;
            this.pboxMinimizar.Click += new System.EventHandler(this.pboxMinimizar_Click);
            // 
            // pboxCerrar
            // 
            this.pboxCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pboxCerrar.Image = global::CarteleriaDigital.Properties.Resources._pboxCerrar;
            this.pboxCerrar.Location = new System.Drawing.Point(203, 12);
            this.pboxCerrar.Name = "pboxCerrar";
            this.pboxCerrar.Size = new System.Drawing.Size(20, 20);
            this.pboxCerrar.TabIndex = 8;
            this.pboxCerrar.TabStop = false;
            this.pboxCerrar.Click += new System.EventHandler(this.pboxCerrar_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRegistrar.Location = new System.Drawing.Point(112, 230);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(110, 30);
            this.btnRegistrar.TabIndex = 17;
            this.btnRegistrar.Text = "REGISTRAR";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // panelRegistro
            // 
            this.panelRegistro.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panelRegistro.Controls.Add(this.txtEmail);
            this.panelRegistro.Controls.Add(this.txtNombreCompleto);
            this.panelRegistro.Controls.Add(this.txtNombreUsuario);
            this.panelRegistro.Controls.Add(this.txtRepetirContraseña);
            this.panelRegistro.Controls.Add(this.txtContraseña);
            this.panelRegistro.Location = new System.Drawing.Point(12, 44);
            this.panelRegistro.Name = "panelRegistro";
            this.panelRegistro.Size = new System.Drawing.Size(210, 180);
            this.panelRegistro.TabIndex = 18;
            // 
            // FormRegistro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(235, 271);
            this.Controls.Add(this.panelRegistro);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.lbTitulo);
            this.Controls.Add(this.pboxMinimizar);
            this.Controls.Add(this.pboxCerrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormRegistro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormRegistro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pboxMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxCerrar)).EndInit();
            this.panelRegistro.ResumeLayout(false);
            this.panelRegistro.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pboxMinimizar;
        private System.Windows.Forms.PictureBox pboxCerrar;
        private System.Windows.Forms.TextBox txtNombreCompleto;
        private System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.TextBox txtNombreUsuario;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.TextBox txtRepetirContraseña;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Panel panelRegistro;

    }
}