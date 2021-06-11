namespace ProyectoSO
{
    partial class START
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
            this.Enviar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.conexion_lbl = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
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
            this.usuario.Location = new System.Drawing.Point(310, 170);
            this.usuario.Name = "usuario";
            this.usuario.Size = new System.Drawing.Size(135, 22);
            this.usuario.TabIndex = 0;
            // 
            // contraseña
            // 
            this.contraseña.Location = new System.Drawing.Point(310, 218);
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
            this.label1.Location = new System.Drawing.Point(219, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Usuario:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(184, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Contraseña:";
            // 
            // Loguearse
            // 
            this.Loguearse.AutoSize = true;
            this.Loguearse.BackColor = System.Drawing.Color.Transparent;
            this.Loguearse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Loguearse.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Loguearse.Location = new System.Drawing.Point(461, 170);
            this.Loguearse.Name = "Loguearse";
            this.Loguearse.Size = new System.Drawing.Size(150, 29);
            this.Loguearse.TabIndex = 3;
            this.Loguearse.TabStop = true;
            this.Loguearse.Text = "Iniciar Sesión";
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
            this.Registrarse.Location = new System.Drawing.Point(461, 209);
            this.Registrarse.Name = "Registrarse";
            this.Registrarse.Size = new System.Drawing.Size(131, 29);
            this.Registrarse.TabIndex = 4;
            this.Registrarse.TabStop = true;
            this.Registrarse.Text = "Registrarse";
            this.Registrarse.UseVisualStyleBackColor = false;
            this.Registrarse.MouseEnter += new System.EventHandler(this.Registrarse_MouseEnter);
            this.Registrarse.MouseLeave += new System.EventHandler(this.Registrarse_MouseLeave);
            // 
            // Enviar
            // 
            this.Enviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Enviar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.WindowText;
            this.Enviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Enviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Enviar.Location = new System.Drawing.Point(322, 264);
            this.Enviar.Name = "Enviar";
            this.Enviar.Size = new System.Drawing.Size(99, 39);
            this.Enviar.TabIndex = 3;
            this.Enviar.Text = "Entrar";
            this.Enviar.UseVisualStyleBackColor = false;
            this.Enviar.Click += new System.EventHandler(this.Enviar_Click);
            this.Enviar.MouseEnter += new System.EventHandler(this.Enviar_MouseEnter);
            this.Enviar.MouseLeave += new System.EventHandler(this.Enviar_MouseLeave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Nirmala UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(314, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 45);
            this.label3.TabIndex = 8;
            this.label3.Text = "INICIO";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(27, 411);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Estado:";
            // 
            // conexion_lbl
            // 
            this.conexion_lbl.AutoSize = true;
            this.conexion_lbl.BackColor = System.Drawing.Color.Transparent;
            this.conexion_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conexion_lbl.ForeColor = System.Drawing.Color.Crimson;
            this.conexion_lbl.Location = new System.Drawing.Point(107, 412);
            this.conexion_lbl.Name = "conexion_lbl";
            this.conexion_lbl.Size = new System.Drawing.Size(233, 25);
            this.conexion_lbl.TabIndex = 11;
            this.conexion_lbl.Text = "Disconnected from server";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(236, 335);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 17);
            this.label6.TabIndex = 16;
            // 
            // START
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = global::ProyectoSO.Properties.Resources.dark_gradient_blue_background_1258_1365;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.conexion_lbl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Enviar);
            this.Controls.Add(this.usuario);
            this.Controls.Add(this.desconectarse);
            this.Controls.Add(this.Registrarse);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Loguearse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.contraseña);
            this.Controls.Add(this.label2);
            this.Name = "START";
            this.Text = "TELECOTRIVIAL UPC";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.START_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
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
        private System.Windows.Forms.Button Enviar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label conexion_lbl;
        private System.Windows.Forms.Label label6;
    }
}

