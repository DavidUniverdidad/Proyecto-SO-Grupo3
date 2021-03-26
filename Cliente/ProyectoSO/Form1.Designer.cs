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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Enviar = new System.Windows.Forms.Button();
            this.ConsultaDavid = new System.Windows.Forms.RadioButton();
            this.ConsultaFerran = new System.Windows.Forms.RadioButton();
            this.ConsultaSergi = new System.Windows.Forms.RadioButton();
            this.Registrarse = new System.Windows.Forms.RadioButton();
            this.Loguearse = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.contraseña = new System.Windows.Forms.TextBox();
            this.usuario = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(207, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(245, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "conectarse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // desconectarse
            // 
            this.desconectarse.Location = new System.Drawing.Point(198, 355);
            this.desconectarse.Name = "desconectarse";
            this.desconectarse.Size = new System.Drawing.Size(254, 23);
            this.desconectarse.TabIndex = 1;
            this.desconectarse.Text = "desconectarse";
            this.desconectarse.UseVisualStyleBackColor = true;
            this.desconectarse.Click += new System.EventHandler(this.desconectarse_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.groupBox1.Controls.Add(this.Enviar);
            this.groupBox1.Controls.Add(this.ConsultaDavid);
            this.groupBox1.Controls.Add(this.ConsultaFerran);
            this.groupBox1.Controls.Add(this.ConsultaSergi);
            this.groupBox1.Controls.Add(this.Registrarse);
            this.groupBox1.Controls.Add(this.Loguearse);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.contraseña);
            this.groupBox1.Controls.Add(this.usuario);
            this.groupBox1.Location = new System.Drawing.Point(104, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(444, 214);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // Enviar
            // 
            this.Enviar.Location = new System.Drawing.Point(16, 82);
            this.Enviar.Name = "Enviar";
            this.Enviar.Size = new System.Drawing.Size(107, 23);
            this.Enviar.TabIndex = 3;
            this.Enviar.Text = "enviar";
            this.Enviar.UseVisualStyleBackColor = true;
            this.Enviar.Click += new System.EventHandler(this.Enviar_Click);
            // 
            // ConsultaDavid
            // 
            this.ConsultaDavid.AutoSize = true;
            this.ConsultaDavid.Location = new System.Drawing.Point(299, 160);
            this.ConsultaDavid.Name = "ConsultaDavid";
            this.ConsultaDavid.Size = new System.Drawing.Size(120, 21);
            this.ConsultaDavid.TabIndex = 6;
            this.ConsultaDavid.TabStop = true;
            this.ConsultaDavid.Text = "ConsultaDavid";
            this.ConsultaDavid.UseVisualStyleBackColor = true;
            // 
            // ConsultaFerran
            // 
            this.ConsultaFerran.AutoSize = true;
            this.ConsultaFerran.Location = new System.Drawing.Point(145, 160);
            this.ConsultaFerran.Name = "ConsultaFerran";
            this.ConsultaFerran.Size = new System.Drawing.Size(148, 21);
            this.ConsultaFerran.TabIndex = 5;
            this.ConsultaFerran.TabStop = true;
            this.ConsultaFerran.Text = "Porcentaje de wins";
            this.ConsultaFerran.UseVisualStyleBackColor = true;
            // 
            // ConsultaSergi
            // 
            this.ConsultaSergi.AutoSize = true;
            this.ConsultaSergi.Location = new System.Drawing.Point(25, 160);
            this.ConsultaSergi.Name = "ConsultaSergi";
            this.ConsultaSergi.Size = new System.Drawing.Size(121, 21);
            this.ConsultaSergi.TabIndex = 3;
            this.ConsultaSergi.TabStop = true;
            this.ConsultaSergi.Text = "Consulta Sergi";
            this.ConsultaSergi.UseVisualStyleBackColor = true;
            // 
            // Registrarse
            // 
            this.Registrarse.AutoSize = true;
            this.Registrarse.Location = new System.Drawing.Point(280, 103);
            this.Registrarse.Name = "Registrarse";
            this.Registrarse.Size = new System.Drawing.Size(97, 21);
            this.Registrarse.TabIndex = 4;
            this.Registrarse.TabStop = true;
            this.Registrarse.Text = "registrarse";
            this.Registrarse.UseVisualStyleBackColor = true;
            // 
            // Loguearse
            // 
            this.Loguearse.AutoSize = true;
            this.Loguearse.Location = new System.Drawing.Point(280, 57);
            this.Loguearse.Name = "Loguearse";
            this.Loguearse.Size = new System.Drawing.Size(92, 21);
            this.Loguearse.TabIndex = 3;
            this.Loguearse.TabStop = true;
            this.Loguearse.Text = "loguearse";
            this.Loguearse.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(156, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Contraseña";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(156, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Usuario";
            // 
            // contraseña
            // 
            this.contraseña.Location = new System.Drawing.Point(145, 103);
            this.contraseña.Name = "contraseña";
            this.contraseña.Size = new System.Drawing.Size(100, 22);
            this.contraseña.TabIndex = 1;
            // 
            // usuario
            // 
            this.usuario.Location = new System.Drawing.Point(145, 57);
            this.usuario.Name = "usuario";
            this.usuario.Size = new System.Drawing.Size(100, 22);
            this.usuario.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.desconectarse);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button desconectarse;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Enviar;
        private System.Windows.Forms.RadioButton ConsultaDavid;
        private System.Windows.Forms.RadioButton ConsultaFerran;
        private System.Windows.Forms.RadioButton ConsultaSergi;
        private System.Windows.Forms.RadioButton Registrarse;
        private System.Windows.Forms.RadioButton Loguearse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox contraseña;
        private System.Windows.Forms.TextBox usuario;
    }
}

