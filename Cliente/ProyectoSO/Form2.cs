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
    public partial class Form2 : Form
    {
        string username;//Nombre usuario (local)
        string password;//Contraseña usuario (local)

        System.Media.SoundPlayer sonido_puntero = new System.Media.SoundPlayer(Properties.Resources.fsx_sonido_puntero);
        System.Media.SoundPlayer sonido_invitacion = new System.Media.SoundPlayer(Properties.Resources.nueva_invitacion);

        string[] jugadores_partida= new string[80];
        int jugadores = 0;//Cuenta el num jugadores para la partida
        int nForms;
        Socket server;
        string usuario_invitacion;
        int row = 0;
        int finalizar = 0;
        int num_partida;//(Sí que se utiliza!)

        List<GAME> formulario_juego = new List<GAME>();//Lista Forms creados tablero juego
        List<Form4> formulario_perfil = new List<Form4>();//Lista Forms creados perfil
        List<Form5> formulario_ayuda = new List<Form5>();//Lista Forms creados ayuda

        int flag_invitar = 0;//Flag para no enviar mensaje para jugar cada vez que se clica JUGAR de cada jugador
        int flag_play = 0;//Flag para bloquear inicio partida hasta que no haya empezado quien ha invitado las peticiones
        int flag_rechazar = 0;//Si rechaza no puede jugar

        delegate void DelegadoParaEscribir(string[] mensaje, string res);//Escribir Grid conectados
        delegate void DelegadoParaEscribir2(string username, int respuesta1);//DataGrid Jugadores Partida
        delegate void DelegadoParaEscribir3(string respuesta);//Label para aceptar invitacion
        delegate void DelegadoParaVaciarGrid();//Delegado para vaciar Grid

        public Form2(int nForm, Socket server)
        {
            InitializeComponent();
            this.nForms = nForm;
            this.server = server;
        }
        public void GetUser(string name)
        {
            this.username = name;
        }

        public void GetPassword(string pwd)
        {
            this.password = pwd;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            welcome_txt.Text = "Bienvenido a TelecoTrivial, "+this.username+"!";
            dataGridView1.ColumnCount = 1;
            dataGridView1.RowCount = 10;

            button2.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            aceptar_bttn.Visible = false;
            rechazar_bttn.Visible = false;
            label3.Visible = false;
            label2.Visible = false;
            label4.Visible = false;

            this.finalizar = 0;
        }

        private void exit_bttn_Click(object sender, EventArgs e)
        {
            sonido_puntero.Play();

            string mensaje = "0/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            Thread.Sleep(200);

            server.Shutdown(SocketShutdown.Both);
            server.Close();

            Thread.Sleep(200);

            this.Close();
        }

        private void play_bbtn_MouseEnter(object sender, EventArgs e)
        {
            this.finalizar = 1;

            play_bbtn.ForeColor = Color.DarkBlue;
            sonido_puntero.Play();
        }

        private void play_bbtn_MouseLeave(object sender, EventArgs e)
        {
            play_bbtn.ForeColor = Color.White;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.ForeColor = Color.DarkBlue;
            sonido_puntero.Play();
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.White;
        }

        private void help_bttn_MouseEnter(object sender, EventArgs e)
        {
            help_bttn.ForeColor = Color.DarkBlue;
            sonido_puntero.Play();
        }

        private void help_bttn_MouseLeave(object sender, EventArgs e)
        {
            help_bttn.ForeColor = Color.White;
        }

        private void exit_bttn_MouseEnter(object sender, EventArgs e)
        {
            exit_bttn.ForeColor = Color.DarkBlue;
            sonido_puntero.Play();
        }

        private void exit_bttn_MouseLeave(object sender, EventArgs e)
        {
            exit_bttn.ForeColor = Color.White;
        }

        private void play_bbtn_Click(object sender, EventArgs e)
        {
            if (this.flag_invitar == 1)//Solo puede iniciar partida el que invita, este envia mensaje 9/ a los invitados
            {
                ThreadStart ts1 = delegate { PonEnMarchaForm3(); };
                Thread T = new Thread(ts1);
                T.Start();//Iniciar thread para atender respuestas de servidor
                Thread.Sleep(200);

                string mensaje = "9/" + this.username;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                this.flag_invitar = 0;//Resetar flag
                this.flag_play = 0;//Resetar flag
            }

            if ((this.flag_play == 1)&&(this.flag_rechazar==0))//Los invitados han recibido que anfitrion ha iniciado la partida
            {
                ThreadStart ts1 = delegate { PonEnMarchaForm3(); };
                Thread T = new Thread(ts1);
                T.Start();//Iniciar thread para atender respuestas de servidor
                //Thread.Sleep(200);

                this.flag_play = 0;
            }

            if(this.flag_invitar!=1)
            {
                MessageBox.Show("Debes esperar a que el anfitrión inicie la partida");
            }
            if (this.flag_rechazar != 0)
            {
                MessageBox.Show("Has rechazado la partida, no puedes unirte a esta");
            }

        }//PLAY [9/usuario_quien_invita]

        private void button1_Click(object sender, EventArgs e)//MI PERFIL
        {

            ThreadStart ts2 = delegate { PonEnMarchaForm4(); };
            Thread T = new Thread(ts2);
            T.Start();//Iniciar thread 

        }

        private void help_bttn_Click(object sender, EventArgs e)//AYUDA
        {
            //System.Media.SoundPlayer sonido_help = new System.Media.SoundPlayer(Properties.Resources.fsx);
            //sonido_help.Play();

            ThreadStart ts3 = delegate { PonEnMarchaForm5(); };
            Thread T = new Thread(ts3);
            T.Start();//Iniciar thread 
        }

        public void RecibirPeticion(string respuesta)
        {
            DelegadoParaEscribir3 delegado = new DelegadoParaEscribir3(LlenarLabel);
            label3.Invoke(delegado, new object[] { respuesta });
        }//Recibir invitacion para jugar
        public void Enlace_Form4(string[] respuesta)
        {
            formulario_perfil[0].Enlace_Form4(respuesta);//Funcion enlace de Form2 para Form4
        }
        public void Enlace_Form3(string[] mensaje)
        {
            formulario_juego[0].Enlace_Form3(mensaje);//Funcion enlace de Form2 para Form3
        }//Enlace de datos con Form3
        public void Enlace2_Form3(string[] mensaje)
        {
            formulario_juego[0].Enlace2_Form3(mensaje);//Funcion enlace de Form2 para Form3
        }//Enlace de datos con Form3

        public void Enlace3_Form3(string[] mensaje)
        {
            formulario_juego[0].Enlace3_Form3(mensaje);//Funcion enlace de Form2 para Form3
        }//Enlace de datos chat con Form3

        public void Enlace4_Form3(string[] mensaje)
        {
            formulario_juego[0].Enlace4_Form3(mensaje);//Funcion enlace de Form2 para Form3
        }//Enlace de datos Enuncido/Respuestas con Form3
        public void Enlace5_Form3(string[] mensaje)
        {
            formulario_juego[0].Enlace5_Form3(mensaje);//Funcion enlace de Form2 para Form3
        }//Enlace de datos ganador partida para Form3

        public void Enlace6_Form3(string[] mensaje)
        {
            formulario_juego[0].Enlace6_Form3(mensaje);//Funcion enlace de Form2 para Form3
        }//Enlace de datos puntos de partida para Form3

        public void RecibirUser(string[] mensaje)
        {
            this.flag_play = 1;

            MessageBox.Show("Pulse JUGAR para iniciar partida con "+ mensaje[1]);
        }//Señal ok para iniciar juego
        public void RecibirRespuesta(string username, int respuesta1)
        {
            DelegadoParaEscribir2 delegado = new DelegadoParaEscribir2(LlenarGrid2);
            dataGridView3.Invoke(delegado, new object[] { username, respuesta1 });
        }//Usuarios invitados, para llenar grid2
        public void RecibirNotificacion(string[] mensaje, string res)
        {
            if (this.finalizar==0)
            {
                DelegadoParaEscribir delegado = new DelegadoParaEscribir(LlenarGrid);
                dataGridView1.Invoke(delegado, new object[] { mensaje, res });
            }
           
        }//Usuarios conectados, para llenar grid1
        public void LlenarLabel(string respuesta)//Escribir peticion invitacion
        {
            label5.Visible = true;
            label3.Visible = true;
            aceptar_bttn.Visible = true;
            rechazar_bttn.Visible = true;

            label5.Text = "Nueva invitación";
            label3.Text = "Unirse a la partida de " + respuesta + "?";
            sonido_invitacion.Play();

            this.usuario_invitacion = respuesta;//Guardar nombre de quien invitaba en var global, para ser utilizado en codigo 8
        }
        public void LlenarGrid(string[] mensaje, string res)
        {
            int i = 0;
            int num = Convert.ToInt32(res);

            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dataGridView1.Rows.Clear();

            while (i < num)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = mensaje[i +2];
                i++;
            }
            dataGridView1.Refresh();
        }//Funcion delegada para llenar grid1
        public void LlenarGrid2(string username, int res)
        {
            dataGridView3.ColumnCount = 1;
            dataGridView3.RowCount = 2;

            dataGridView3.ColumnHeadersVisible = false;
            dataGridView3.RowHeadersVisible = false;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            if (res == 1)
            {
                dataGridView3.Rows.Add();
                dataGridView3.Rows[row].Cells[0].Value = username + " Acepta";
            }

            if(res==0)
            {
                dataGridView3.Rows.Add();
                dataGridView3.Rows[row].Cells[0].Value = username + " Rechaza";

            }

            row++;

            dataGridView3.Refresh();
        }//Funcion delegada para llenar grid2
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string value = "";
            value = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();//Obtener nombre jugadores
            string[] nombre = value.Split('/');//Limpiar variable
            string usuario_nombre = nombre[0].Split('\0')[0];

            dataGridView2.Visible = true;
            dataGridView3.Visible = true;
            button2.Visible = true;
            label2.Visible = true;
            label4.Visible = true;
            label6.Visible = false;

            if (usuario_nombre!=this.username)
            {
                dataGridView2.ColumnCount = 1;
                dataGridView2.RowCount = 2;

                if (this.jugadores<3)
                {
                    //MessageBox.Show("Invitar a " + value);

                    this.jugadores_partida[this.jugadores] = "/" + value;
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

                else
                {

                    dataGridView2.ColumnHeadersVisible = false;
                    dataGridView2.RowHeadersVisible = false;
                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    
                    int i = 0;

                    while (i < this.jugadores)
                    {
                        dataGridView2.Rows.Add();
                        dataGridView2.Rows[i].Cells[0].Value = this.jugadores_partida[i];
                        i++;
                    }
                    dataGridView1.Refresh();

                    MessageBox.Show("Una partida no puede tener más de 4 usuarios!");
                }
                
            }
            else
            {
                MessageBox.Show("No puedes invitarte a ti mismo");
            }
            
        }//Seleccion jugadores invitados
        private void button2_Click(object sender, EventArgs e)//Boton confirmacion Invitar jugadores a partida [7/num_Form/jugadores_seleccionados/]
        {
            int i = 0;
            string string_jugadores = "";

            while (i < this.jugadores + 1)
            {
                string_jugadores = string_jugadores + this.jugadores_partida[i];
                i++;
            }

            this.jugadores = 0;
            this.flag_invitar = 1;

            string mensaje = "7/"+nForms+"/" + string_jugadores + "/";
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            MessageBox.Show("Invitación enviada");
            button2.Visible = false;
        }
        private void aceptar_bttn_Click(object sender, EventArgs e)
        {
            label5.Visible = false;
            label3.Visible = false;
            aceptar_bttn.Visible = false;
            rechazar_bttn.Visible = false;

            label5.Text = "";
            label3.Text = "No hay invitaciones para jugar";
            string mensaje = "8/" + this.usuario_invitacion + "/SI/" + this.num_partida + "/";
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            
        }//Boton aceptar invitacion [8/usuario_quien_invita/SI/numero_partida/]
        private void rechazar_bttn_Click(object sender, EventArgs e)
        {
            label5.Visible = false;
            label3.Visible = false;
            aceptar_bttn.Visible = false;
            rechazar_bttn.Visible = false;

            label5.Text = "";
            label3.Text = "No hay invitaciones para jugar";

            string mensaje = "8/" + this.usuario_invitacion + "/NO/" + this.num_partida + "/";
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            this.flag_rechazar = 1;


        }//Boton rechazar invitacion [8/usuario_quien_invita/NO/numero_partida/]
        private void PonEnMarchaForm3()
        {
            int cont = formulario_juego.Count;

            GAME game = new GAME(cont, server);
            game.GetUsername(username);
            //System.Media.SoundPlayer sonido_play = new System.Media.SoundPlayer(Properties.Resources.fsx);
            //sonido_play.Play();
            game.GetUsername(this.username);

            formulario_juego.Add(game);

            game.ShowDialog();

            DelegadoParaVaciarGrid delegado = new DelegadoParaVaciarGrid(VaciarGrid);
            dataGridView2.Invoke(delegado, new object[] { });
            dataGridView3.Invoke(delegado, new object[] { });
            label2.Invoke(delegado, new object[] { });
            label4.Invoke(delegado, new object[] { });

        }//Abrir form JUEGO
        public void VaciarGrid()
        {
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            button2.Visible = false;
            label2.Visible = false;
            label4.Visible = false;

            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
        }//Limipiar los grid de invitacion
        private void PonEnMarchaForm4()
        {
            int cont = formulario_juego.Count;

            Form4 f4 = new Form4(cont,server);

            f4.GetUsername(this.username);
            f4.GetPassword(this.password);

            formulario_perfil.Add(f4);

            f4.ShowDialog();

            formulario_perfil.RemoveAt(0);

        }//Abrir form PERFIL
        private void PonEnMarchaForm5()
        {
            int cont = formulario_ayuda.Count;

            Form5 f5 = new Form5(cont);

            formulario_ayuda.Add(f5);

            f5.ShowDialog();

        }//Abrir form AYUDA

    }
}
