
namespace ProyectoSO
{
    partial class Form2
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
            this.welcome_txt = new System.Windows.Forms.Label();
            this.play_bbtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.help_bttn = new System.Windows.Forms.Button();
            this.exit_bttn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.aceptar_bttn = new System.Windows.Forms.Button();
            this.rechazar_bttn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // welcome_txt
            // 
            this.welcome_txt.AutoSize = true;
            this.welcome_txt.BackColor = System.Drawing.Color.Transparent;
            this.welcome_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcome_txt.ForeColor = System.Drawing.Color.White;
            this.welcome_txt.Location = new System.Drawing.Point(23, 41);
            this.welcome_txt.Name = "welcome_txt";
            this.welcome_txt.Size = new System.Drawing.Size(358, 32);
            this.welcome_txt.TabIndex = 0;
            this.welcome_txt.Text = "Welcome to TelecoTrivial";
            // 
            // play_bbtn
            // 
            this.play_bbtn.BackColor = System.Drawing.Color.MediumTurquoise;
            this.play_bbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.play_bbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.play_bbtn.ForeColor = System.Drawing.Color.White;
            this.play_bbtn.Location = new System.Drawing.Point(43, 139);
            this.play_bbtn.Name = "play_bbtn";
            this.play_bbtn.Size = new System.Drawing.Size(150, 42);
            this.play_bbtn.TabIndex = 1;
            this.play_bbtn.Text = "JUGAR";
            this.play_bbtn.UseVisualStyleBackColor = false;
            this.play_bbtn.Click += new System.EventHandler(this.play_bbtn_Click);
            this.play_bbtn.MouseEnter += new System.EventHandler(this.play_bbtn_MouseEnter);
            this.play_bbtn.MouseLeave += new System.EventHandler(this.play_bbtn_MouseLeave);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MediumTurquoise;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(43, 232);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 42);
            this.button1.TabIndex = 2;
            this.button1.Text = "MI PERFIL";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            this.button1.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            // 
            // help_bttn
            // 
            this.help_bttn.BackColor = System.Drawing.Color.MediumTurquoise;
            this.help_bttn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.help_bttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.help_bttn.ForeColor = System.Drawing.Color.White;
            this.help_bttn.Location = new System.Drawing.Point(43, 326);
            this.help_bttn.Name = "help_bttn";
            this.help_bttn.Size = new System.Drawing.Size(150, 42);
            this.help_bttn.TabIndex = 3;
            this.help_bttn.Text = "AYUDA";
            this.help_bttn.UseVisualStyleBackColor = false;
            this.help_bttn.Click += new System.EventHandler(this.help_bttn_Click);
            this.help_bttn.MouseEnter += new System.EventHandler(this.help_bttn_MouseEnter);
            this.help_bttn.MouseLeave += new System.EventHandler(this.help_bttn_MouseLeave);
            // 
            // exit_bttn
            // 
            this.exit_bttn.BackColor = System.Drawing.Color.MediumTurquoise;
            this.exit_bttn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit_bttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit_bttn.ForeColor = System.Drawing.Color.White;
            this.exit_bttn.Location = new System.Drawing.Point(43, 412);
            this.exit_bttn.Name = "exit_bttn";
            this.exit_bttn.Size = new System.Drawing.Size(150, 42);
            this.exit_bttn.TabIndex = 4;
            this.exit_bttn.Text = "SALIR";
            this.exit_bttn.UseVisualStyleBackColor = false;
            this.exit_bttn.Click += new System.EventHandler(this.exit_bttn_Click);
            this.exit_bttn.MouseEnter += new System.EventHandler(this.exit_bttn_MouseEnter);
            this.exit_bttn.MouseLeave += new System.EventHandler(this.exit_bttn_MouseLeave);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(343, 192);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(168, 150);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.MediumTurquoise;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.Location = new System.Drawing.Point(585, 356);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 30);
            this.button2.TabIndex = 6;
            this.button2.Text = "INVITAR";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(582, 192);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(137, 150);
            this.dataGridView2.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(339, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Jugadores en línea:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(578, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Lista invitados:";
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(734, 192);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersWidth = 51;
            this.dataGridView3.RowTemplate.Height = 24;
            this.dataGridView3.Size = new System.Drawing.Size(133, 150);
            this.dataGridView3.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(339, 399);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(234, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "No hay invitaciones para jugar";
            // 
            // aceptar_bttn
            // 
            this.aceptar_bttn.BackColor = System.Drawing.Color.PaleGreen;
            this.aceptar_bttn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aceptar_bttn.ForeColor = System.Drawing.Color.Green;
            this.aceptar_bttn.Location = new System.Drawing.Point(369, 436);
            this.aceptar_bttn.Name = "aceptar_bttn";
            this.aceptar_bttn.Size = new System.Drawing.Size(53, 23);
            this.aceptar_bttn.TabIndex = 12;
            this.aceptar_bttn.Text = "✔";
            this.aceptar_bttn.UseVisualStyleBackColor = false;
            this.aceptar_bttn.Click += new System.EventHandler(this.aceptar_bttn_Click);
            // 
            // rechazar_bttn
            // 
            this.rechazar_bttn.BackColor = System.Drawing.Color.DarkSalmon;
            this.rechazar_bttn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rechazar_bttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rechazar_bttn.ForeColor = System.Drawing.Color.Red;
            this.rechazar_bttn.Location = new System.Drawing.Point(439, 436);
            this.rechazar_bttn.Name = "rechazar_bttn";
            this.rechazar_bttn.Size = new System.Drawing.Size(47, 23);
            this.rechazar_bttn.TabIndex = 13;
            this.rechazar_bttn.Text = "X";
            this.rechazar_bttn.UseVisualStyleBackColor = false;
            this.rechazar_bttn.Click += new System.EventHandler(this.rechazar_bttn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(730, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Respuestas:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkRed;
            this.label5.Location = new System.Drawing.Point(339, 379);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 20);
            this.label5.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label6.Location = new System.Drawing.Point(244, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(386, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "Haga doble click sobre los usuarios para invitarlos";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = global::ProyectoSO.Properties.Resources.dark_gradient_blue_background_1258_1365;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(890, 520);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rechazar_bttn);
            this.Controls.Add(this.aceptar_bttn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.exit_bttn);
            this.Controls.Add(this.help_bttn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.play_bbtn);
            this.Controls.Add(this.welcome_txt);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label welcome_txt;
        private System.Windows.Forms.Button play_bbtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button help_bttn;
        private System.Windows.Forms.Button exit_bttn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button aceptar_bttn;
        private System.Windows.Forms.Button rechazar_bttn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}