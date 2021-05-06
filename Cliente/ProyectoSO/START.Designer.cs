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
            this.ConsultaSergi = new System.Windows.Forms.RadioButton();
            this.ConsultaFerran = new System.Windows.Forms.RadioButton();
            this.ConsultaDavid = new System.Windows.Forms.RadioButton();
            this.Enviar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.conexion_lbl = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.aceptar_bttn = new System.Windows.Forms.Button();
            this.rechazar_bttn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
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
            this.usuario.Location = new System.Drawing.Point(181, 158);
            this.usuario.Name = "usuario";
            this.usuario.Size = new System.Drawing.Size(135, 22);
            this.usuario.TabIndex = 0;
            // 
            // contraseña
            // 
            this.contraseña.Location = new System.Drawing.Point(181, 206);
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
            this.label1.Location = new System.Drawing.Point(90, 154);
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
            this.label2.Location = new System.Drawing.Point(55, 202);
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
            this.Loguearse.Location = new System.Drawing.Point(332, 158);
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
            this.Registrarse.Location = new System.Drawing.Point(332, 197);
            this.Registrarse.Name = "Registrarse";
            this.Registrarse.Size = new System.Drawing.Size(131, 29);
            this.Registrarse.TabIndex = 4;
            this.Registrarse.TabStop = true;
            this.Registrarse.Text = "Registrarse";
            this.Registrarse.UseVisualStyleBackColor = false;
            this.Registrarse.MouseEnter += new System.EventHandler(this.Registrarse_MouseEnter);
            this.Registrarse.MouseLeave += new System.EventHandler(this.Registrarse_MouseLeave);
            // 
            // ConsultaSergi
            // 
            this.ConsultaSergi.AutoSize = true;
            this.ConsultaSergi.BackColor = System.Drawing.Color.Transparent;
            this.ConsultaSergi.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ConsultaSergi.Location = new System.Drawing.Point(611, 341);
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
            this.ConsultaDavid.Location = new System.Drawing.Point(611, 287);
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
            this.Enviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Enviar.Location = new System.Drawing.Point(193, 252);
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
            this.label3.Location = new System.Drawing.Point(185, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 45);
            this.label3.TabIndex = 8;
            this.label3.Text = "INICIO";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(32, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(114, 95);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
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
            this.conexion_lbl.ForeColor = System.Drawing.Color.Red;
            this.conexion_lbl.Location = new System.Drawing.Point(107, 412);
            this.conexion_lbl.Name = "conexion_lbl";
            this.conexion_lbl.Size = new System.Drawing.Size(233, 25);
            this.conexion_lbl.TabIndex = 11;
            this.conexion_lbl.Text = "Disconnected from server";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(488, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(133, 150);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 291);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Petic partida";
            // 
            // aceptar_bttn
            // 
            this.aceptar_bttn.Location = new System.Drawing.Point(31, 329);
            this.aceptar_bttn.Name = "aceptar_bttn";
            this.aceptar_bttn.Size = new System.Drawing.Size(75, 23);
            this.aceptar_bttn.TabIndex = 14;
            this.aceptar_bttn.Text = "Aceptar";
            this.aceptar_bttn.UseVisualStyleBackColor = true;
            this.aceptar_bttn.Click += new System.EventHandler(this.aceptar_bttn_Click);
            // 
            // rechazar_bttn
            // 
            this.rechazar_bttn.Location = new System.Drawing.Point(112, 329);
            this.rechazar_bttn.Name = "rechazar_bttn";
            this.rechazar_bttn.Size = new System.Drawing.Size(84, 23);
            this.rechazar_bttn.TabIndex = 15;
            this.rechazar_bttn.Text = "Rechazar";
            this.rechazar_bttn.UseVisualStyleBackColor = true;
            this.rechazar_bttn.Click += new System.EventHandler(this.rechazar_bttn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(236, 335);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 17);
            this.label6.TabIndex = 16;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(678, 168);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "Invitar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(644, 12);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(133, 150);
            this.dataGridView2.TabIndex = 18;
            // 
            // START
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.rechazar_bttn);
            this.Controls.Add(this.aceptar_bttn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.conexion_lbl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ConsultaSergi);
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
            this.Name = "START";
            this.Text = "TELECOTRIVIAL UPC";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label conexion_lbl;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button aceptar_bttn;
        private System.Windows.Forms.Button rechazar_bttn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView2;
    }
}

