namespace ProyectoSO
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.desconectarse = new System.Windows.Forms.Button();
            this.usuario = new System.Windows.Forms.TextBox();
            this.contraseña = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Loguearse = new System.Windows.Forms.RadioButton();
            this.Registrarse = new System.Windows.Forms.RadioButton();
            this.ConsultaSergi = new System.Windows.Forms.RadioButton();
            this.ConsultaFerran = new System.Windows.Forms.RadioButton();
            this.ConsultaDavid = new System.Windows.Forms.RadioButton();
            this.Enviar = new System.Windows.Forms.Button();
            this.conectados_bttn = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(678, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // desconectarse
            // 
            this.desconectarse.Location = new System.Drawing.Point(553, 415);
            this.desconectarse.Name = "desconectarse";
            this.desconectarse.Size = new System.Drawing.Size(119, 23);
            this.desconectarse.TabIndex = 1;
            this.desconectarse.Text = "Disconect";
            this.desconectarse.UseVisualStyleBackColor = true;
            this.desconectarse.Click += new System.EventHandler(this.desconectarse_Click);
            // 
            // usuario
            // 
            this.usuario.Location = new System.Drawing.Point(304, 166);
            this.usuario.Name = "usuario";
            this.usuario.Size = new System.Drawing.Size(135, 22);
            this.usuario.TabIndex = 0;
            // 
            // contraseña
            // 
            this.contraseña.Location = new System.Drawing.Point(304, 214);
            this.contraseña.Name = "contraseña";
            this.contraseña.Size = new System.Drawing.Size(135, 22);
            this.contraseña.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(184, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(188, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password:";
            // 
            // Loguearse
            // 
            this.Loguearse.AutoSize = true;
            this.Loguearse.BackColor = System.Drawing.Color.Transparent;
            this.Loguearse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Loguearse.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Loguearse.Location = new System.Drawing.Point(492, 168);
            this.Loguearse.Name = "Loguearse";
            this.Loguearse.Size = new System.Drawing.Size(81, 29);
            this.Loguearse.TabIndex = 3;
            this.Loguearse.TabStop = true;
            this.Loguearse.Text = "Login";
            this.Loguearse.UseVisualStyleBackColor = false;
            this.Loguearse.MouseEnter += new System.EventHandler(this.Loguearse_MouseEnter);
            this.Loguearse.MouseLeave += new System.EventHandler(this.Loguearse_MouseLeave);
            // 
            // Registrarse
            // 
            this.Registrarse.AutoSize = true;
            this.Registrarse.BackColor = System.Drawing.Color.Transparent;
            this.Registrarse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Registrarse.ForeColor = System.Drawing.Color.Transparent;
            this.Registrarse.Location = new System.Drawing.Point(492, 207);
            this.Registrarse.Name = "Registrarse";
            this.Registrarse.Size = new System.Drawing.Size(149, 29);
            this.Registrarse.TabIndex = 4;
            this.Registrarse.TabStop = true;
            this.Registrarse.Text = "New Account";
            this.Registrarse.UseVisualStyleBackColor = false;
            this.Registrarse.MouseEnter += new System.EventHandler(this.Registrarse_MouseEnter);
            this.Registrarse.MouseLeave += new System.EventHandler(this.Registrarse_MouseLeave);
            // 
            // ConsultaSergi
            // 
            this.ConsultaSergi.AutoSize = true;
            this.ConsultaSergi.BackColor = System.Drawing.Color.Transparent;
            this.ConsultaSergi.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ConsultaSergi.Location = new System.Drawing.Point(611, 368);
            this.ConsultaSergi.Name = "ConsultaSergi";
            this.ConsultaSergi.Size = new System.Drawing.Size(121, 21);
            this.ConsultaSergi.TabIndex = 3;
            this.ConsultaSergi.TabStop = true;
            this.ConsultaSergi.Text = "Consulta Sergi";
            this.ConsultaSergi.UseVisualStyleBackColor = false;
            // 
            // ConsultaFerran
            // 
            this.ConsultaFerran.AutoSize = true;
            this.ConsultaFerran.BackColor = System.Drawing.Color.Transparent;
            this.ConsultaFerran.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ConsultaFerran.Location = new System.Drawing.Point(611, 314);
            this.ConsultaFerran.Name = "ConsultaFerran";
            this.ConsultaFerran.Size = new System.Drawing.Size(148, 21);
            this.ConsultaFerran.TabIndex = 5;
            this.ConsultaFerran.TabStop = true;
            this.ConsultaFerran.Text = "Porcentaje de wins";
            this.ConsultaFerran.UseVisualStyleBackColor = false;
            // 
            // ConsultaDavid
            // 
            this.ConsultaDavid.AutoSize = true;
            this.ConsultaDavid.BackColor = System.Drawing.Color.Transparent;
            this.ConsultaDavid.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ConsultaDavid.Location = new System.Drawing.Point(611, 278);
            this.ConsultaDavid.Name = "ConsultaDavid";
            this.ConsultaDavid.Size = new System.Drawing.Size(120, 21);
            this.ConsultaDavid.TabIndex = 6;
            this.ConsultaDavid.TabStop = true;
            this.ConsultaDavid.Text = "ConsultaDavid";
            this.ConsultaDavid.UseVisualStyleBackColor = false;
            // 
            // Enviar
            // 
            this.Enviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Enviar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.WindowText;
            this.Enviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Enviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Enviar.Location = new System.Drawing.Point(349, 264);
            this.Enviar.Name = "Enviar";
            this.Enviar.Size = new System.Drawing.Size(78, 35);
            this.Enviar.TabIndex = 3;
            this.Enviar.Text = "Join";
            this.Enviar.UseVisualStyleBackColor = false;
            this.Enviar.Click += new System.EventHandler(this.Enviar_Click);
            this.Enviar.MouseEnter += new System.EventHandler(this.Enviar_MouseEnter);
            this.Enviar.MouseLeave += new System.EventHandler(this.Enviar_MouseLeave);
            // 
            // conectados_bttn
            // 
            this.conectados_bttn.AutoSize = true;
            this.conectados_bttn.BackColor = System.Drawing.Color.Transparent;
            this.conectados_bttn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.conectados_bttn.Location = new System.Drawing.Point(611, 341);
            this.conectados_bttn.Name = "conectados_bttn";
            this.conectados_bttn.Size = new System.Drawing.Size(176, 21);
            this.conectados_bttn.TabIndex = 7;
            this.conectados_bttn.TabStop = true;
            this.conectados_bttn.Text = "Numero de conectados";
            this.conectados_bttn.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Nirmala UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(308, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 45);
            this.label3.TabIndex = 8;
            this.label3.Text = "START";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::ProyectoSO.Properties.Resources.Logo_UPC_svg;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(32, 314);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(114, 95);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ProyectoSO.Properties.Resources.hexagonal_technology_pattern_mesh_background_with_text_space_1017_26293;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ConsultaSergi);
            this.Controls.Add(this.conectados_bttn);
            this.Controls.Add(this.ConsultaFerran);
            this.Controls.Add(this.ConsultaDavid);
            this.Controls.Add(this.Enviar);
            this.Controls.Add(this.usuario);
            this.Controls.Add(this.desconectarse);
            this.Controls.Add(this.Registrarse);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Loguearse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.contraseña);
            this.Controls.Add(this.label2);
            this.Name = "Form1";
            this.Text = "TELECOTRIVIAL UPC";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button desconectarse;
        private System.Windows.Forms.TextBox usuario;
        private System.Windows.Forms.TextBox contraseña;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton Loguearse;
        private System.Windows.Forms.RadioButton Registrarse;
        private System.Windows.Forms.RadioButton ConsultaSergi;
        private System.Windows.Forms.RadioButton ConsultaFerran;
        private System.Windows.Forms.RadioButton ConsultaDavid;
        private System.Windows.Forms.Button Enviar;
        private System.Windows.Forms.RadioButton conectados_bttn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

