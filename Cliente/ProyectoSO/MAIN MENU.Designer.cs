
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
            this.SuspendLayout();
            // 
            // welcome_txt
            // 
            this.welcome_txt.AutoSize = true;
            this.welcome_txt.BackColor = System.Drawing.Color.Transparent;
            this.welcome_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcome_txt.ForeColor = System.Drawing.Color.White;
            this.welcome_txt.Location = new System.Drawing.Point(23, 41);
            this.welcome_txt.Name = "welcome_txt";
            this.welcome_txt.Size = new System.Drawing.Size(289, 29);
            this.welcome_txt.TabIndex = 0;
            this.welcome_txt.Text = "Welcome to TelecoTrivial";
            // 
            // play_bbtn
            // 
            this.play_bbtn.BackColor = System.Drawing.Color.MediumTurquoise;
            this.play_bbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.play_bbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.play_bbtn.ForeColor = System.Drawing.Color.White;
            this.play_bbtn.Location = new System.Drawing.Point(68, 144);
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
            this.button1.Location = new System.Drawing.Point(68, 206);
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
            this.help_bttn.Location = new System.Drawing.Point(68, 269);
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
            this.exit_bttn.Location = new System.Drawing.Point(68, 332);
            this.exit_bttn.Name = "exit_bttn";
            this.exit_bttn.Size = new System.Drawing.Size(150, 42);
            this.exit_bttn.TabIndex = 4;
            this.exit_bttn.Text = "SALIR";
            this.exit_bttn.UseVisualStyleBackColor = false;
            this.exit_bttn.Click += new System.EventHandler(this.exit_bttn_Click);
            this.exit_bttn.MouseEnter += new System.EventHandler(this.exit_bttn_MouseEnter);
            this.exit_bttn.MouseLeave += new System.EventHandler(this.exit_bttn_MouseLeave);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ProyectoSO.Properties.Resources.dark_gradient_blue_background_1258_1365;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.exit_bttn);
            this.Controls.Add(this.help_bttn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.play_bbtn);
            this.Controls.Add(this.welcome_txt);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label welcome_txt;
        private System.Windows.Forms.Button play_bbtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button help_bttn;
        private System.Windows.Forms.Button exit_bttn;
    }
}