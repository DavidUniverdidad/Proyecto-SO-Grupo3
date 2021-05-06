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
using System.Media;
using System.Threading;

namespace ProyectoSO
{
    public partial class START : Form
    {
        //System.Media.SoundPlayer sonido_puntero = new System.Media.SoundPlayer(Properties.Resources.fsx_sonido_puntero);

        Socket server;
        Thread atender;
        string usuario_invitacion;
        string[] jugadores_partida = new string[80];
        int jugadores=0;
        int num_partida;

        public START()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void AtenderServidor()
        {
            while (true)
            {
                try
                {
                    byte[] msg2 = new byte[80];
                    server.Receive(msg2);

                    string[] mensaje = Encoding.ASCII.GetString(msg2).Split('/');
                    int codigo = Convert.ToInt32(mensaje[0]);//Extraer codigo
                    string res = mensaje[1].Split('\0')[0];

                    switch (codigo)
                    {
                        case 1: //Registrar

                            if (res == "Done")
                            {
                                MessageBox.Show(usuario.Text + " has been registered to the system");
                            }
                            else
                            {
                                MessageBox.Show("Registration failed");
                            }

                            break;

                        case 2: //Login

                            if (res == "Done")
                            {
                                MessageBox.Show("Usuario logueado");
                            }
                            else
                            {
                                MessageBox.Show("Error al iniciar sesión");
                            }
                            break;

                        case 3:

                            MessageBox.Show("El máximo que ha durado en una partida es." + res);

                            break;

                        case 4:

                            MessageBox.Show("El porcentaje es de victorias es:" + res);

                            break;

                        case 5:

                            MessageBox.Show("El número de partidas ganadas es:" + res);
                            break;

                        case 6://Notificacion
                            int num = Convert.ToInt32(res);

                            dataGridView1.ColumnHeadersVisible = false;
                            dataGridView1.RowHeadersVisible = false;
                            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                            dataGridView1.Rows.Clear();
                            int i = 0;

                            while (i < num)
                            {
                                dataGridView1.Rows.Add();
                                dataGridView1.Rows[i].Cells[0].Value = mensaje[i + 2];
                                i++;
                            }
                            dataGridView1.Refresh();

                            break;

                        case 7://Petición a jugar

                            label5.Text = "Unirse a la partida de "+res+"?";
                            this.usuario_invitacion = res;
                            break;

                        case 8://Aceptacion a jugar
                            string username;
                            username = mensaje[1];
                            string respuesta = mensaje[2];
                            this.num_partida = Convert.ToInt32(mensaje[3]);

                                label5.Text = " ";
                                label6.Text = username + " "+respuesta+" acepta";
                                break;

                        default:
                            MessageBox.Show("Error");
                            break;
                    }
                }
                catch (FormatException)
                {
                    //Si hay excepcion imprimimos error y salimos del programa con return 
                    MessageBox.Show("Error de formato del mensaje de recepción");
                    return;
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)//Conexión
        {
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("192.168.56.105");//192.168.56.104, Local addr MV
                                                                //147.83.117.22 shiva server
            IPEndPoint ipep = new IPEndPoint(direc, 9077);//Puerto shiva 50076,50077,50078


            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                conexion_lbl.Text = "Conectado al servidor";
                conexion_lbl.ForeColor = Color.Green;
            }
            catch (SocketException)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No he podido conectar con el servidor");
                return;
            }

            ThreadStart ts = delegate { AtenderServidor(); };
            atender = new Thread(ts);
            atender.Start();//Iniciar thread para atender respuestas de servidor 

        }
        private void Enviar_Click(object sender, EventArgs e)
        {
            //System.Media.SoundPlayer sonido_enviar = new System.Media.SoundPlayer(Properties.Resources.fsx);
            //sonido_enviar.Play();
            //sonido_inicio.Stop();

            if (Registrarse.Checked)//Registrarse como usuario
            {

                string mensaje = "1/" + usuario.Text + "/" + contraseña.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

            }
            else if (Loguearse.Checked)
            {

                string mensaje = "2/" + usuario.Text + "/" + contraseña.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                Form2 menu = new Form2();
                menu.GetUser(usuario.Text);

                menu.Show();

            }
            else if (ConsultaDavid.Checked)
            {
                string mensaje = "3/" + usuario.Text + "/" + contraseña.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

            }
            else if (ConsultaFerran.Checked)
            {
                string mensaje = "4/" + usuario.Text + "/" + contraseña.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

            }
            else if (ConsultaSergi.Checked)
            {
                string mensaje = "5/" + usuario.Text + "/" + contraseña.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

            }
        }
        private void desconectarse_Click(object sender, EventArgs e)//Desconexión
        {
            //Mensaje de desconexión
            string mensaje = "0/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            // Nos desconectamos

            atender.Abort();//Cerramos thread

            conexion_lbl.Text = "Desconectado del servidor";
            conexion_lbl.ForeColor = Color.Red;

            server.Shutdown(SocketShutdown.Both);
            server.Close();
        }

        private void Enviar_MouseEnter(object sender, EventArgs e)
        {
            Enviar.ForeColor = Color.White;
            //sonido_puntero.Play();
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

        private void Form1_Load(object sender, EventArgs e)
        {
            //GAME game_prueba = new GAME();
            //game_prueba.Show();

            dataGridView1.ColumnCount = 1;
            dataGridView1.RowCount = 10;

            dataGridView2.ColumnCount = 1;
            dataGridView2.RowCount = 10;

            //sonido_inicio.PlayLooping();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)//Invitar usuario
        {
            string value = "";
            value = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();//Obtener nombre jugadores
            MessageBox.Show("Invitar a " + value);

            this.jugadores_partida[this.jugadores] = "/"+value;
            this.jugadores++;

            dataGridView2.ColumnHeadersVisible = false;
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dataGridView2.Rows.Clear();

            int i = 0;

            while (i < this.jugadores)
            {
                dataGridView2.Rows.Add();
                dataGridView2.Rows[i].Cells[0].Value = this.jugadores_partida[i];
                i++;
            }
            dataGridView1.Refresh();

        }

        private void aceptar_bttn_Click(object sender, EventArgs e)//Aceptar partida
        {
            string mensaje = "8/" +this.usuario_invitacion+ "/SI/" + this.num_partida+"/";
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            label5.Text = "";
        }

        private void rechazar_bttn_Click(object sender, EventArgs e)
        {
            string mensaje = "8/" + this.usuario_invitacion + "/NO/"+this.num_partida+"/";
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            label5.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)//Invitar
        {
            int i = 0;
            string string_jugadores="";

            while (i < this.jugadores+1)
            {
                string_jugadores = string_jugadores+this.jugadores_partida[i];
                i++;
            }

            this.jugadores = 0;

            string mensaje = "7" + string_jugadores+"/";
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }
    }
}
