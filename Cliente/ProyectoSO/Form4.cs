using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ProyectoSO
{
    public partial class Form4 : Form
    {
        int nForms;
        Socket server;
        string username;
        string password;
        delegate void DelegadoParaEscribir(string[] mensaje);//Escribir Label
        int veces = 0;
        int flag_E = 0, flag_M = 0, flag_P = 0, flag_H = 0;

        System.Media.SoundPlayer sonido_puntero = new System.Media.SoundPlayer(Properties.Resources.fsx_sonido_puntero);

        public Form4(int nForm, Socket server)
        {
            this.nForms = nForm;
            this.server = server;

            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            label1.Text = username;
            label5.Visible = false;
            label4.Visible = false;
            panel1.Visible = false;
        }

        public void GetUsername(string name)
        {
            this.username = name;
        }//Escribir nombre usuario local

        public void GetPassword(string pwd)
        {
            this.password = pwd;
        }//Escribir contraseña usuario local

        private void button1_Click(object sender, EventArgs e)//MOSTRAR [3/username/password] o [4/username/password] o [5/username/password]
        {
            if (consulta_tiempo.Checked)
            {
                string mensaje = "3/" + this.username+  "/" + this.password;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }

            if (consulta_ratio.Checked)
            {
                string mensaje = "4/" + this.username + "/" + this.password;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }

            if (consulta_ganadas.Checked)
            {
                string mensaje = "5/" + this.username + "/" + this.password;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
        }

        public void Enlace_Form4(string[] respuesta)
        {
            DelegadoParaEscribir delegado = new DelegadoParaEscribir(LlenarLabel);
            label4.Invoke(delegado, new object[] { respuesta});
        }

        public void LlenarLabel(string[] respuesta)
        {
            label5.Visible = true;
            label4.Visible = true;

            int codigo = Convert.ToInt32(respuesta[0]);

            if (codigo == 3)//Respuesta de duracion máxima de partida
            {
                int wins = Convert.ToInt32(respuesta[1].Split('\0')[0]);
                label4.Text = "Total de partidas perdidas: " + wins;
            }

            if (codigo == 4)//Respuesta al ratio
            {
                string percent = respuesta[1].Split('\0')[0];
                string[] percent2 = percent.Split('.');

                label4.Text = "El ratio es de: " + percent2[0] + "%";
            }

            if (codigo == 5)//Respuesta a total partidas ganadas
            {
                int lost = Convert.ToInt32(respuesta[1].Split('\0')[0]);

                label4.Text = "Total de partidas ganadas: " + lost;
            }
        }//Escribir resultados obttenidos

        private void consulta_tiempo_MouseEnter(object sender, EventArgs e)
        {
            consulta_tiempo.ForeColor = Color.Red;
        }

        private void consulta_tiempo_MouseLeave(object sender, EventArgs e)
        {
            consulta_tiempo.ForeColor = Color.White;
        }

        private void consulta_ratio_MouseEnter(object sender, EventArgs e)
        {
            consulta_ratio.ForeColor = Color.Red;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            if (this.veces == 0)
            {
                MessageBox.Show("IMPORTANTE: es obligatorio añadir una pregunta para cada campo");
                this.veces++;
            }
            else
            {
                if ((textBox1 != null) && (textBox2 != null) && (textBox3 != null) && (textBox4 != null) && (textBox5 != null) && (textBox6 != null))
                {
                    int valor_cat;
                    string enunciado;
                    string resp1;
                    string resp2;
                    string resp3;
                    string resp4;

                    if ((textBox1.Text == "E") || (textBox1.Text == "M") || (textBox1.Text == "P") || (textBox1.Text == "H"))
                    {
                        if (textBox1.Text == "E")
                        {
                            valor_cat = 1;
                            enunciado = textBox2.Text;
                            resp1 = textBox3.Text;
                            resp2 = textBox4.Text;
                            resp3 = textBox5.Text;
                            resp4 = textBox6.Text;
                            this.flag_E = 1;

                            string mensaje = "17/" + valor_cat + "/" + enunciado + "/" + resp1 + "/" + resp2 + "/" + resp3 + "/" + resp4;
                            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                            server.Send(msg);

                            MessageBox.Show("Pregunta de Electrónica añadida");

                        }
                        if (textBox1.Text == "M")
                        {
                            valor_cat = 2;
                            enunciado = textBox2.Text;
                            resp1 = textBox3.Text;
                            resp2 = textBox4.Text;
                            resp3 = textBox5.Text;
                            resp4 = textBox6.Text;
                            this.flag_M = 1;

                            string mensaje = "17/" + valor_cat + "/" + enunciado + "/" + resp1 + "/" + resp2 + "/" + resp3 + "/" + resp4;
                            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                            server.Send(msg);

                            MessageBox.Show("Pregunta de Matemáticas añadida");

                        }
                        if (textBox1.Text == "P")
                        {
                            valor_cat = 3;
                            enunciado = textBox2.Text;
                            resp1 = textBox3.Text;
                            resp2 = textBox4.Text;
                            resp3 = textBox5.Text;
                            resp4 = textBox6.Text;
                            this.flag_P = 1;

                            string mensaje = "17/" + valor_cat + "/" + enunciado + "/" + resp1 + "/" + resp2 + "/" + resp3 + "/" + resp4;
                            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                            server.Send(msg);

                            MessageBox.Show("Pregunta de Programación añadida");

                        }
                        if (textBox1.Text == "H")
                        {
                            valor_cat = 4;
                            enunciado = textBox2.Text;
                            resp1 = textBox3.Text;
                            resp2 = textBox4.Text;
                            resp3 = textBox5.Text;
                            resp4 = textBox6.Text;
                            this.flag_H = 1;

                            string mensaje = "17/" + valor_cat + "/" + enunciado + "/" + resp1 + "/" + resp2 + "/" + resp3 + "/" + resp4;
                            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                            server.Send(msg);

                            MessageBox.Show("Pregunta de Historia añadida");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Código de catergoria incorrecto");
                    }
                }
                else
                {
                    MessageBox.Show("Todos los campos son obligatorios");
                }
            }
        }//Añadir preguntas [17/Codigo/Enunciado/Resp1/Resp2/Resp3/Resp4]

        private void button3_Click(object sender, EventArgs e)//Volver al menú
        {
            if (this.veces == 1)
            {
                if ((this.flag_E == 1) && (this.flag_M == 1) && (this.flag_P == 1) && (this.flag_H == 1))
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Debes acabar de añadir preguntas para los campos que quedan!");
                }
            }
            else
            {
                this.Close();
            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            sonido_puntero.Play();
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            sonido_puntero.Play();
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            sonido_puntero.Play();
        }

        private void consulta_ratio_MouseLeave(object sender, EventArgs e)
        {
            consulta_ratio.ForeColor = Color.White;
        }

        private void consulta_ganadas_MouseEnter(object sender, EventArgs e)
        {
            consulta_ganadas.ForeColor = Color.Red;
        }

        private void consulta_ganadas_MouseLeave(object sender, EventArgs e)
        {
            consulta_ganadas.ForeColor = Color.White;
        }
    }
}
