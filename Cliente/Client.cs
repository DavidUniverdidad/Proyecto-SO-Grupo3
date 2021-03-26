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

namespace Cliente_Ej13
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
            IPAddress direc = IPAddress.Parse("192.168.56.102");
            IPEndPoint ipep = new IPEndPoint(direc, 9066);


            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                label2.ForeColor = Color.Green;
                label2.Text = "Connected to server";

            }
            catch (SocketException ex)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("Unrecheable server");
                return;
            }

        }//Conexión

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void disconnect_bbtn_Click(object sender, EventArgs e)
        {
            string mensaje = "0/";
            // Enviamos al servidor la orden de desconexión
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            server.Shutdown(SocketShutdown.Both);
            server.Close();
            label2.ForeColor = Color.Red;
            label2.Text = "Disconnected from server";
        }

        private void Register_bttn_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void Enviar_Click(object sender, EventArgs e)
        {
            if (Register_bttn.Checked)//Registrarse como usuario
            {
                string mensaje = "1/" + username.Text + "/" + password.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split(',')[0];
                if (mensaje == "Done")
                {
                    MessageBox.Show(username.Text + " has been registered to the system");
                }
                else
                {
                    MessageBox.Show("Registration failed");
                }
            }
            else
            {
                string mensaje = "2/" + username.Text + "/" + password.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split(',')[0];

                if (mensaje == "Done")
                {
                    MessageBox.Show("User Logged");
                }
                else
                {
                    MessageBox.Show("Registration failed");
                }
            }

            label2.ForeColor = Color.Red;
            label2.Text = "Disconnected from server";
        }
    }
}
