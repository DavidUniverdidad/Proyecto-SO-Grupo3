﻿
namespace Cliente_Ej13
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
            this.username = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Register_bttn = new System.Windows.Forms.RadioButton();
            this.login_bttn = new System.Windows.Forms.RadioButton();
            this.Enviar = new System.Windows.Forms.Button();
            this.connect_bttn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Units = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.disconnect_bbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(146, 102);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(95, 22);
            this.username.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Username:";
            // 
            // Register_bttn
            // 
            this.Register_bttn.AutoSize = true;
            this.Register_bttn.Location = new System.Drawing.Point(146, 214);
            this.Register_bttn.Name = "Register_bttn";
            this.Register_bttn.Size = new System.Drawing.Size(82, 21);
            this.Register_bttn.TabIndex = 2;
            this.Register_bttn.TabStop = true;
            this.Register_bttn.Text = "Register";
            this.Register_bttn.UseVisualStyleBackColor = true;
            this.Register_bttn.CheckedChanged += new System.EventHandler(this.Register_bttn_CheckedChanged);
            // 
            // login_bttn
            // 
            this.login_bttn.AutoSize = true;
            this.login_bttn.Location = new System.Drawing.Point(146, 250);
            this.login_bttn.Name = "login_bttn";
            this.login_bttn.Size = new System.Drawing.Size(64, 21);
            this.login_bttn.TabIndex = 3;
            this.login_bttn.TabStop = true;
            this.login_bttn.Text = "Login";
            this.login_bttn.UseVisualStyleBackColor = true;
            // 
            // Enviar
            // 
            this.Enviar.Location = new System.Drawing.Point(270, 105);
            this.Enviar.Name = "Enviar";
            this.Enviar.Size = new System.Drawing.Size(96, 23);
            this.Enviar.TabIndex = 4;
            this.Enviar.Text = "Join";
            this.Enviar.UseVisualStyleBackColor = true;
            this.Enviar.Click += new System.EventHandler(this.Enviar_Click);
            // 
            // connect_bttn
            // 
            this.connect_bttn.Location = new System.Drawing.Point(61, 327);
            this.connect_bttn.Name = "connect_bttn";
            this.connect_bttn.Size = new System.Drawing.Size(75, 23);
            this.connect_bttn.TabIndex = 5;
            this.connect_bttn.Text = "Connect";
            this.connect_bttn.UseVisualStyleBackColor = true;
            this.connect_bttn.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(136, 369);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 17);
            this.label2.TabIndex = 6;
            // 
            // Units
            // 
            this.Units.AutoSize = true;
            this.Units.Location = new System.Drawing.Point(294, 105);
            this.Units.Name = "Units";
            this.Units.Size = new System.Drawing.Size(0, 17);
            this.Units.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Password:";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(146, 152);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(95, 22);
            this.password.TabIndex = 12;
            // 
            // disconnect_bbtn
            // 
            this.disconnect_bbtn.Location = new System.Drawing.Point(166, 327);
            this.disconnect_bbtn.Name = "disconnect_bbtn";
            this.disconnect_bbtn.Size = new System.Drawing.Size(99, 23);
            this.disconnect_bbtn.TabIndex = 13;
            this.disconnect_bbtn.Text = "Disconnect";
            this.disconnect_bbtn.UseVisualStyleBackColor = true;
            this.disconnect_bbtn.Click += new System.EventHandler(this.disconnect_bbtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.disconnect_bbtn);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Units);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.connect_bttn);
            this.Controls.Add(this.Enviar);
            this.Controls.Add(this.login_bttn);
            this.Controls.Add(this.Register_bttn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.username);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton Register_bttn;
        private System.Windows.Forms.RadioButton login_bttn;
        private System.Windows.Forms.Button Enviar;
        private System.Windows.Forms.Button connect_bttn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Units;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Button disconnect_bbtn;
    }
}

