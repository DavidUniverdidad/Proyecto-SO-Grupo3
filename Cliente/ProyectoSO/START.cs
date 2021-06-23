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
        System.Media.SoundPlayer sonido_puntero = new System.Media.SoundPlayer(Properties.Resources.fsx_sonido_puntero);

        Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        Thread atender;
        int flag_conexion = 0;//Si se ha establecido conexion antes de Entrar
        int login_ok;
        string username;

        private static Mutex mutex = new Mutex();

        delegate void DelegadoParaEscribir(string[] mensaje, string res);//DataGrid Conectados Online
        delegate void DelegadoParaEscribir2(string username, string respuesta);//DataGrid Jugadores Partida
        delegate void DelegadoParaEscribir3(string respuesta);//Label para aceptar invitacion

        List<GAME> formulario_juego = new List<GAME>();//Lista Forms creados tablero juego
        List<Form2> formularios = new List<Form2>();//Lista Forms creados

        public START()
        {
            InitializeComponent();
            //CheckForIllegalCrossThreadCalls = false;
        }
       
        private void AtenderServidor()
       {
           while (true)
           {
               try
               {
                   byte[] msg2 = new byte[800];
                   server.Receive(msg2);

                   string[] mensaje = Encoding.ASCII.GetString(msg2).Split('/');
                   int codigo = Convert.ToInt32(mensaje[0]);//Extraer codigo
                   string res = mensaje[1].Split('\0')[0];

                    switch (codigo)
                   {
                       case 1: //Registrar

                           if (res == "Done")
                           {
                               
                               MessageBox.Show(usuario.Text + " se ha registrado al sistema");
                           }
                           else
                           {
                               MessageBox.Show("Registration failed");
                           }

                           break;

                       case 2: //Login

                           if (res == "Done")
                           {
                                this.login_ok = 1;
                                ThreadStart ts1 = delegate { PonEnMarchaForm(); };
                                Thread T = new Thread(ts1);
                                T.Start();//Iniciar thread para atender respuestas de servidor
                                Thread.Sleep(200);
                            }
                           else
                           {
                                this.login_ok = 0;
                                MessageBox.Show("Usuario no existente, registrate antes de entrar");
                           }
                           break;

                       case 3:

                           //MessageBox.Show("El máximo que ha durado en una partida es." + res);
                            formularios[0].Enlace_Form4(mensaje);//Pasar datos al Form2

                            break;

                       case 4:

                            //MessageBox.Show("El porcentaje es de victorias es:" + res);
                            formularios[0].Enlace_Form4(mensaje);//Pasar datos al Form2

                            break;

                       case 5:

                            // MessageBox.Show("El número de partidas ganadas es:" + res);
                            formularios[0].Enlace_Form4(mensaje);//Pasar datos al Form2

                            break;

                       case 6://Notificacion
                              //int nForm = Convert.ToInt32(mensaje[1]);//Extraer codigo
                            if (this.login_ok==1)
                            {
                                string res1 = mensaje[1];//Extraer num
                                formularios[0].RecibirNotificacion(mensaje, res1);//Pasar datos al Form2
                            }
                            
                            break;

                        case 7://Petición a jugar

                            formularios[0].RecibirPeticion(res);//Pasar datos al Form2

                            //DelegadoParaEscribir3 delegado3 = new DelegadoParaEscribir3(LlenarLabel);
                            //label5.Invoke(delegado3, new object[] { res });

                            break;

                        case 8://Aceptacion a jugar
                            
                            username = mensaje[1];
                            int respuesta = Convert.ToInt32(mensaje[2]);
                           // this.num_partida = Convert.ToInt32(mensaje[3]);

                            formularios[0].RecibirRespuesta(username,respuesta);//Pasar datos al Form2

                           // DelegadoParaEscribir2 delegado2 = new DelegadoParaEscribir2(LlenarGrid2);
                            //dataGridView3.Invoke(delegado2, new object[] { username, respuesta });

                            //label5.Text = " ";
                                //label6.Text = username + " "+respuesta+" acepta";
                                break;

                        case 9://Respuesta para invitados a jugar

                            formularios[0].RecibirUser(mensaje);//Para dar nombre usuario
                            break;

                        case 10://Movimento jugador dado

                            formularios[0].Enlace_Form3(mensaje);//Funcion enlace en Form2 para Form3

                            break;

                        case 11://Obtencion identificadores para cada usuario

                            formularios[0].Enlace2_Form3(mensaje);//Funcion enlace en Form2 para Form3

                            break;

                        case 12: //Chat

                            formularios[0].Enlace3_Form3(mensaje);//Funcion enlace en Form1 para Form3

                            break;

                        case 13: //Preguntas/Respuestas BBDD
                            formularios[0].Enlace4_Form3(mensaje);//Funcion enlace en Form1 para Form3

                            break;

                        case 14: //Obtener actualizacion puntos por jugador
                            formularios[0].Enlace6_Form3(mensaje);//Funcion enlace en Form1 para Form3

                            break;

                        case 15: //Fin Juego
                            formularios[0].Enlace5_Form3(mensaje);//Funcion enlace en Form1 para Form3

                            break;

                        case 16: //Actualizacion

                            break;

                        case 17: //

                            break;

                        default:
                            MessageBox.Show("Error");//Se recibe entrada que no corresponde con ningun codigo del protocolo
                            break;
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("FALLO DE FORMATO");
                    //Si hay excepcion imprimimos error y salimos del programa con return 
                    //MessageBox.Show("Error de formato del mensaje de recepción");
                    return;
                }

            }
        }//Punto de entrada de todos los paquetes
        private void button1_Click(object sender, EventArgs e)//Conexión
        {
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("147.83.117.22");//192.168.56.109, Local addr MV
                                                                //147.83.117.22 shiva server
            IPEndPoint ipep = new IPEndPoint(direc, 50076);//Puerto shiva 50076,50077,50078


            //Creamos el socket 
            //server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                conexion_lbl.Text = "Conectado al servidor";
                conexion_lbl.ForeColor = Color.LimeGreen;
                this.flag_conexion = 1;
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

            if (this.flag_conexion==1)
            {
                if ((usuario.Text != "") && (contraseña.Text != ""))
                {
                    if (Registrarse.Checked)//Registrarse como usuario
                    {

                        string mensaje = "1/" + usuario.Text + "/" + contraseña.Text;
                        // Enviamos al servidor el nombre tecleado
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);

                    }
                    else if (Loguearse.Checked)
                    {
                        this.login_ok = 0;
                        string mensaje = "2/" + usuario.Text + "/" + contraseña.Text;
                        // Enviamos al servidor el nombre tecleado
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);

                    }
                }
                else
                {
                    MessageBox.Show("Debe introducir un Usuario y Contraseña");
                }
               
            }
            else
            {
                MessageBox.Show("Debe conectarse al servidor para entrar");
            }
        }//Loguerase [1/Username/Contraseña] o Registrarse [2/Usename/Contraseña]
        private void desconectarse_Click(object sender, EventArgs e)//Desconexión [0/]
        {
            //Mensaje de desconexión
            string mensaje = "0/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            // Nos desconectamos

            atender.Abort();//Cerramos thread

            conexion_lbl.Text = "Desconectado del servidor";
            conexion_lbl.ForeColor = Color.Crimson;
            this.flag_conexion = 0;

            server.Shutdown(SocketShutdown.Both);
            server.Close();
        }
        private void Enviar_MouseEnter(object sender, EventArgs e)
        {
            Enviar.ForeColor = Color.White;
            sonido_puntero.Play();
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
        }//Load inicial del Form
        private void PonEnMarchaForm()
        {
            if (this.login_ok==1)
            {
                mutex.WaitOne();
                int cont = formularios.Count;
                Form2 Form2 = new Form2(cont, server);
                Form2.GetUser(usuario.Text);
                Form2.GetPassword(contraseña.Text);

                formularios.Add(Form2);
                mutex.ReleaseMutex();

                Form2.ShowDialog();
               formularios.RemoveAt(0);

            }

            Thread.Sleep(200);
            atender.Abort();//Cerramos thread
            

        }//Abrir form MENU
        private void START_FormClosing(object sender, FormClosingEventArgs e)
        {

            atender.Abort();//Cerramos thread

            conexion_lbl.Text = "Desconectado del servidor";
            conexion_lbl.ForeColor = Color.Red;

            
        }//Evento para el cierre
    }
}
