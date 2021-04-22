using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace ProyectoSO
{
    public partial class Form1 : Form
    {
        Socket server;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("192.168.56.103");
            IPEndPoint ipep = new IPEndPoint(direc, 9060);


            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                this.BackColor = Color.Green;
                MessageBox.Show("Conectado");
            }
            catch (SocketException)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No he podido conectar con el servidor");
                return;
            }
        }
        private void Enviar_Click(object sender, EventArgs e)
        {
            if (Registrarse.Checked)//Registrarse como usuario
            {
                string mensaje = "1/" + usuario.Text + "/" + contraseña.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                if (mensaje == "Done")
                {
                    MessageBox.Show(usuario.Text + " has been registered to the system");
                }
                else
                {
                    MessageBox.Show("Registration failed");
                }
            }
            else if (Loguearse.Checked)
            {
                string mensaje = "2/" + usuario.Text + "/" + contraseña.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

                if (mensaje == "Done")
                {
                    MessageBox.Show("User Logged");

                    Form2 game = new Form2();
                    game.GetUser(usuario.Text);

                    game.Show();
                }
                else
                {
                    MessageBox.Show("Login failed");
                }
            }
            else if (ConsultaDavid.Checked)
            {
                string mensaje = "3/" + usuario.Text + "/" + contraseña.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                MessageBox.Show("El máximo que ha durado en una partida es." + mensaje);
            }
            else if (ConsultaFerran.Checked)
            {
                string mensaje = "4/" + usuario.Text + "/" + contraseña.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                MessageBox.Show("El porcentaje es de victorias es:" + mensaje);
            }
            else if (ConsultaSergi.Checked)
            {
                string mensaje = "5/" + usuario.Text + "/" + contraseña.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                MessageBox.Show("El número de partidas ganadas es:" + mensaje);
            }

            else if (conectados_bttn.Checked)
            {
                string mensaje = "6/";//Obtener usuarios online
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

                MessageBox.Show("Los jugadores conectados son:" + mensaje);
            }
        }
            private void desconectarse_Click(object sender, EventArgs e)
        {
            //Mensaje de desconexión
            string mensaje = "0/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            // Nos desconectamos
            this.BackColor = Color.Red;
            server.Shutdown(SocketShutdown.Both);
            server.Close();
        }

        private void Enviar_MouseEnter(object sender, EventArgs e)
        {
            Enviar.ForeColor = Color.White;
        }

        private void Enviar_MouseLeave(object sender, EventArgs e)
        {
            Enviar.ForeColor = Color.Black;
        }

        private void Loguearse_MouseEnter(object sender, EventArgs e)
        {
            Loguearse.ForeColor = Color.Red;
        }

        private void Loguearse_MouseLeave(object sender, EventArgs e)
        {
            Loguearse.ForeColor = Color.White;
        }

        private void Registrarse_MouseEnter(object sender, EventArgs e)
        {
            Registrarse.ForeColor = Color.Red;
        }

        private void Registrarse_MouseLeave(object sender, EventArgs e)
        {
            Registrarse.ForeColor = Color.White;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }
    }
}
