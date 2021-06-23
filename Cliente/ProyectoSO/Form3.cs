using System;
using System.Collections;
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

    public partial class GAME : Form
    {
        List<Point> posiciones = new List<Point>();//Lista casillas tablero
        delegate void DelegadoParaMover(string username, int num_dado, int id_jugador, string username_siguiente);//Escribir en tablero
        delegate void DelegadoParaEscribir(string username, string text);//Escribir en chat
        delegate void DelegadoParaEscribirPreguntas(string pregunta_respuesta);//Escribir en preguntas y respuestas (label,checkbox)
        delegate void DelegadoParaEscribirLabel(string username);//Escribir mensaje victoria
        delegate void DelegadoParaEscribirGrid(string[] mensaje);//Escribir grid
        delegate void DelegadoParaFuncion();//Abrir funcion
        System.Media.SoundPlayer sonido_fallo = new System.Media.SoundPlayer(Properties.Resources.pregunta_incorrecta);
        System.Media.SoundPlayer sonido_victoria = new System.Media.SoundPlayer(Properties.Resources.victoria);
        System.Media.SoundPlayer sonido_mensaje = new System.Media.SoundPlayer(Properties.Resources.nuevo_mensaje);

        Random rand = new Random();
        //Random rand_dir = new Random();

        int count = 0;
        //int user1, user2, user3, user4;//dirección(ELIMINAR?)
        string user1, user2, user3, user4;//dirección
        int puntos1=0, puntos2=0, puntos3=0, puntos4=0;//puntuacion de cada jugador
        int user1_id,user2_id,user3_id,user4_id;//identificadores todos los usuarios en partida
        int value, value1, value2, value3;//Guardar pos fichas
        int ident;//Identifica al jugador local
        int num_jugadores;//Det el numero jugadores activos en la partida
        string ganador;//nombre del ganador
        int nForms;
        Socket server;
        string username;//Nombre local usuario
        string username_chat;//Nombre quien escribe mensaje chat
        string texto;//Texto del chat
        int turno;//Inicialmente, siempre empieza el jugador con id=0
        string pregunta,respuesta1, respuesta2, respuesta3, respuesta4;//respuestas, la respuesta1 siempre es la correcta
        int id_user_responde;//Id del usuario que puede responder la pregunta
        int id_tipo;//Indica tipo de tematica de casilla
        int flag_tirada_dado=0;//Indica que se ha tirado el dado
        int flag_respuesta = 0;//Indica que ya se ha respondido
        int flag_fin_partida = 0;//Indica fin de la partida
        int num_mensajes_rx = 0;//mensajes recibidos
        string texto2;
        string username_chat2;
        int num_preguntas;
        
        int puntos = 0;//Puntos
        List<GAME> formulario_juego = new List<GAME>();//Lista Forms creados tablero juego



        public GAME(int nForm, Socket server)
        {
            this.nForms = nForm;
            this.server = server;

            InitializeComponent();
            
        }
        private void GAME_Load(object sender, EventArgs e)
        {
            user_lbl.Text = username;

            usuario_lbl2.Visible = false;
            respuesta_lbl2.Visible = false;
            usuario_lbl.Visible = false;
            respuesta_lbl.Visible = false;
            dice_num.Visible = false;

            posiciones.Add(new Point(245, 530));//AZUL-0
            posiciones.Add(new Point(170, 530));//1
            posiciones.Add(new Point(95, 530));//2
            posiciones.Add(new Point(17, 530));//3
            posiciones.Add(new Point(17, 445));//4
            posiciones.Add(new Point(17, 360));//5
            posiciones.Add(new Point(17, 279));//ROJO-6
            posiciones.Add(new Point(18, 192));//7
            posiciones.Add(new Point(18, 109));//8
            posiciones.Add(new Point(18, 26));//9
            posiciones.Add(new Point(93, 26));//10
            posiciones.Add(new Point(168, 26));//11
            posiciones.Add(new Point(243, 26));//AMARILLO-12
            posiciones.Add(new Point(320, 26));//13
            posiciones.Add(new Point(397, 26));//14
            posiciones.Add(new Point(473, 26));//15
            posiciones.Add(new Point(473, 111));//16
            posiciones.Add(new Point(473, 196));//17
            posiciones.Add(new Point(473, 278));//VERDE-18
            posiciones.Add(new Point(475, 360));//19
            posiciones.Add(new Point(475, 442));//20
            posiciones.Add(new Point(476, 524));//21
            posiciones.Add(new Point(401, 530));//22
            posiciones.Add(new Point(326, 530));//23

            posiciones.Add(new Point(243, 275));//Incio-24
            posiciones.Add(new Point(243, 362));//25
            posiciones.Add(new Point(243, 447));//26
            posiciones.Add(new Point(168, 275));//27
            posiciones.Add(new Point(93, 275));//28
            posiciones.Add(new Point(243, 190));//29
            posiciones.Add(new Point(243, 108));//30
            posiciones.Add(new Point(321, 278));//31
            posiciones.Add(new Point(397, 278));//32

            Label label5 = new Label();

            label5.Text = "Count: " + count;

            label2.Location = posiciones[24];
            label4.Location = posiciones[24];
            label7.Location = posiciones[24];
            label8.Location = posiciones[24];

            GetIdent();

            dataGridView1.ColumnCount = 3;
            dataGridView1.RowCount = this.num_jugadores+10;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dataGridView1.Rows[0].Cells[0].Value ="Nombre";
            dataGridView1.Rows[0].Cells[1].Value = "Ficha";
            dataGridView1.Rows[0].Cells[2].Value = "Puntos";

            usuario_lbl.Text = this.username;//Escribir nombre usuario en su interfaz

            fin_bttn.Visible = false;//Boton de finalizar inicialmente escondido
            puntuacion.Visible = false;//Oculto por el momento*(ahora hay grid situacional de partida)

            int i = 0;
            while (i<20)
            {
                i++;
            }
            i = 0;

            if (this.num_jugadores == 2)
            {
                dataGridView1.Rows[this.user1_id + 1].Cells[0].Value = this.user1;
                dataGridView1.Rows[this.user2_id + 1].Cells[0].Value = this.user2;
                dataGridView1.Rows[this.user1_id + 1].Cells[1].Value = "Ficha 1";
                dataGridView1.Rows[this.user2_id + 1].Cells[1].Value = "Ficha 2";
                dataGridView1.Rows[this.user1_id + 1].Cells[2].Value = this.puntos1;
                dataGridView1.Rows[this.user2_id + 1].Cells[2].Value = this.puntos2;
                label7.Visible = false;
                label8.Visible = false;
            }

            if (this.num_jugadores == 3)
            {
                dataGridView1.Rows[this.user1_id + 1].Cells[0].Value = this.user1;
                dataGridView1.Rows[this.user2_id + 1].Cells[0].Value = this.user2;
                dataGridView1.Rows[this.user3_id + 1].Cells[0].Value = this.user3;
                dataGridView1.Rows[this.user1_id + 1].Cells[1].Value = "Ficha 1";
                dataGridView1.Rows[this.user2_id + 1].Cells[1].Value = "Ficha 2";
                dataGridView1.Rows[this.user3_id + 1].Cells[1].Value = "Ficha 3";
                dataGridView1.Rows[this.user1_id + 1].Cells[2].Value = this.puntos1;
                dataGridView1.Rows[this.user2_id + 1].Cells[2].Value = this.puntos2;
                dataGridView1.Rows[this.user3_id + 1].Cells[2].Value = this.puntos3;
                label8.Visible = false;
            }

            if (this.num_jugadores == 4)
            {
                dataGridView1.Rows[this.user1_id + 1].Cells[0].Value = this.user1;
                dataGridView1.Rows[this.user2_id + 1].Cells[0].Value = this.user2;
                dataGridView1.Rows[this.user3_id + 1].Cells[0].Value = this.user3;
                dataGridView1.Rows[this.user4_id + 1].Cells[0].Value = this.user4;
                dataGridView1.Rows[this.user1_id + 1].Cells[1].Value = "Ficha 1";
                dataGridView1.Rows[this.user2_id + 1].Cells[1].Value = "Ficha 2";
                dataGridView1.Rows[this.user3_id + 1].Cells[1].Value = "Ficha 3";
                dataGridView1.Rows[this.user4_id + 1].Cells[1].Value = "Ficha 4";
                dataGridView1.Rows[this.user1_id + 1].Cells[2].Value = this.puntos1;
                dataGridView1.Rows[this.user2_id + 1].Cells[2].Value = this.puntos2;
                dataGridView1.Rows[this.user3_id + 1].Cells[2].Value = this.puntos3;
                dataGridView1.Rows[this.user4_id + 1].Cells[2].Value = this.puntos4;
            }

            this.turno = 0;
            if (this.ident==0)
            {
                MessageBox.Show("Empiezas tirando!");
            }
        }
        public void GetUsername(string name)
        {
            this.username = name;
        }//Escribir nombre usuario local
        public void Enlace3_Form3(string[] mensaje)
        {
            this.num_mensajes_rx++;

            if (this.num_mensajes_rx >= 2)
            {
                this.texto2 = this.texto;
                this.username_chat2 = this.username_chat;
            }
                this.username_chat = mensaje[1];
                this.texto = mensaje[2];
            
            DelegadoParaEscribir delegado = new DelegadoParaEscribir(EscribirLabelChat);
            respuesta_lbl.Invoke(delegado, new object[] { this.username_chat, this.texto });

            if (this.num_mensajes_rx >= 2)
            {
                respuesta_lbl.Invoke(delegado, new object[] { this.username_chat, this.texto });
                respuesta_lbl2.Invoke(delegado, new object[] { this.username_chat2, this.texto2 });
            }
           

        }//Enlace de datos con Form3 [CHAT]
        private void res1_Click(object sender, EventArgs e)
        {
            if (this.id_user_responde == this.ident)
            {
                //Si id_user_responde=identificador del jugador local, es que es su turno para responder y los otros no podran
                
                if (this.flag_respuesta == 0)
                {//Si flag=0 indica que aun no ha seleccionado ninguna opcion
                 
                    if (res1.Text == "a) " + this.respuesta1)
                    {
                        MessageBox.Show("Respuesta CORRECTA!");
                        this.puntos++;//Se incrementan los puntos
                        puntuacion.Text = "Puntos: " + this.puntos;

                        string mensaje = "14/"+this.username+"/"+this.puntos; //Enviar puntos al servidor
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);

                        this.flag_respuesta = 1;

                        if (this.puntos == 5)//Se ha llegado a la puntuación máxima
                        {
                            FinJuego();
                        }

                        res1.Text = "";
                        res2.Text = "";
                        res3.Text = "";
                        res4.Text = "";
                        label3.ForeColor = Color.Black;
                        label3.Text = "Espere a que el siguiente usuario tire el dado";
                        label1.Text = "";
                    }
                    else
                    {
                        sonido_fallo.Play();
                        MessageBox.Show("Respuesta INCORRECTA!");
                        
                        this.flag_respuesta = 1;

                        res1.Text = "";
                        res2.Text = "";
                        res3.Text = "";
                        res4.Text = "";
                        label3.ForeColor = Color.Black;
                        label3.Text = "Espere a que el siguiente usuario tire el dado";
                        label1.Text = "";
                    }
                }
            }
            
            else
            {
                MessageBox.Show("Debe responder el usuario que ha tirado!");
            }
        }//Click primera opcion respuesta [14/username/puntos_sumados]
        private void res2_Click(object sender, EventArgs e)
        {
            if (this.id_user_responde == this.ident)
            {
                if (this.flag_respuesta == 0)
                {
                    if (res2.Text == "b) " + this.respuesta1)
                    {
                        MessageBox.Show("Respuesta CORRECTA!");
                        this.puntos++;//Se incrementan los puntos
                        puntuacion.Text = "Puntos: " + this.puntos;
                        this.flag_respuesta = 1;

                        string mensaje = "14/" + this.username + "/" + this.puntos; //Enviar puntos al servidor
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);

                        if (this.puntos == 5)//Se ha llegado a la puntuación máxima
                        {
                            FinJuego();
                        }

                        res1.Text = "";
                        res2.Text = "";
                        res3.Text = "";
                        res4.Text = "";
                        label3.ForeColor = Color.Black;
                        label3.Text = "Espere a que el siguiente usuario tire el dado";
                        label1.Text = "";
                    }
                    else
                    {
                        sonido_fallo.Play();
                        MessageBox.Show("Respuesta INCORRECTA!");
                        this.flag_respuesta = 1;

                        res1.Text = "";
                        res2.Text = "";
                        res3.Text = "";
                        res4.Text = "";
                        label3.ForeColor = Color.Black;
                        label3.Text = "Espere a que el siguiente usuario tire el dado";
                        label1.Text = "";
                    }
                }
            }

            else
            {
                MessageBox.Show("Debe responder el usuario que ha tirado!");
            }

        }//Click segunda opcion respuesta [14/username/puntos_sumados]
        private void res3_Click(object sender, EventArgs e)
        {
            if (this.id_user_responde == this.ident)
            {
                if (this.flag_respuesta == 0)
                {
                    if (res3.Text == "c) " + this.respuesta1)
                    {
                        MessageBox.Show("Respuesta CORRECTA!");
                        this.puntos++;//Se incrementan los puntos
                        puntuacion.Text = "Puntos: " + this.puntos;
                        this.flag_respuesta = 1;

                        string mensaje = "14/" + this.username + "/" + this.puntos; //Enviar puntos al servidor
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);

                        if (this.puntos == 5)//Se ha llegado a la puntuación máxima
                        {
                            FinJuego();
                        }

                        res1.Text = "";
                        res2.Text = "";
                        res3.Text = "";
                        res4.Text = "";
                        label3.ForeColor = Color.Black;
                        label3.Text = "Espere a que el siguiente usuario tire el dado";
                        label1.Text = "";
                    }
                    else
                    {
                        sonido_fallo.Play();
                        MessageBox.Show("Respuesta INCORRECTA!");
                        this.flag_respuesta = 1;

                        res1.Text = "";
                        res2.Text = "";
                        res3.Text = "";
                        res4.Text = "";
                        label3.ForeColor = Color.Black;
                        label3.Text = "Espere a que el siguiente usuario tire el dado";
                        label1.Text = "";
                    }
                }
            }

            else
            {
                MessageBox.Show("Debe responder el usuario que ha tirado!");
            }

        }//Click tercera opcion respuesta [14/username/puntos_sumados]
        private void res4_Click(object sender, EventArgs e)
        {
            if (this.id_user_responde == this.ident)
            {
                if (this.flag_respuesta == 0)
                {
                    if (res4.Text == "d) " + this.respuesta1)
                    {
                        MessageBox.Show("Respuesta CORRECTA!");
                        this.puntos++;//Se incrementan los puntos
                        puntuacion.Text = "Puntos: " + this.puntos;
                        this.flag_respuesta = 1;

                        string mensaje = "14/" + this.username + "/" + this.puntos; //Enviar puntos al servidor
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);

                        if (this.puntos == 5)//Se ha llegado a la puntuación máxima
                        {
                            FinJuego();
                        }

                        res1.Text = "";
                        res2.Text = "";
                        res3.Text = "";
                        res4.Text = "";
                        label3.ForeColor = Color.Black;
                        label3.Text = "Espere a que el siguiente usuario tire el dado";
                        label1.Text = "";
                    }
                    else
                    {
                        sonido_fallo.Play();

                        MessageBox.Show("Respuesta INCORRECTA!");
                        this.flag_respuesta = 1;

                        res1.Text = "";
                        res2.Text = "";
                        res3.Text = "";
                        res4.Text = "";
                        label3.ForeColor = Color.Black;
                        label3.Text = "Espere a que el siguiente usuario tire el dado";
                        label1.Text = "";
                    }
                }
            }

            else
            {
                MessageBox.Show("Debe responder el usuario que ha tirado!");
            }

        }//Click cuarta opcion respuesta [14/username/puntos_sumados]
        private void res1_MouseEnter(object sender, EventArgs e)
        {
            res1.ForeColor = Color.White;
        }
        private void res1_MouseLeave(object sender, EventArgs e)
        {
            res1.ForeColor = Color.Black;
        }

        private void res2_MouseEnter(object sender, EventArgs e)
        {
            res2.ForeColor = Color.White;
        }

        private void res2_MouseLeave(object sender, EventArgs e)
        {
            res2.ForeColor = Color.Black;
        }

        private void res3_MouseEnter(object sender, EventArgs e)
        {
            res3.ForeColor = Color.White;
        }

        private void res3_MouseLeave(object sender, EventArgs e)
        {
            res3.ForeColor = Color.Black;
        }

        private void res4_MouseEnter(object sender, EventArgs e)
        {
            res4.ForeColor = Color.White;
        }

        private void res4_MouseLeave(object sender, EventArgs e)
        {
            res4.ForeColor = Color.Black;
        }

        private void fin_bttn_Click(object sender, EventArgs e)
        {
            
                string mensaje = "16/" + this.username + "/"+this.ganador;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

            this.Close();
            
        }//Boton Salir Form (fin partida) [16/username/usuario_ganador]
        public void FinJuego()//Establece un ganador y final del juego! [15/usuario_ganador]
        {
            string mensaje = "15/" +this.username;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }
        public void Enlace4_Form3(string[] mensaje)
        {
            this.pregunta = mensaje[1];
            this.respuesta1 = mensaje[2];
            this.respuesta2 = mensaje[3];
            this.respuesta3 = mensaje[4];
            this.respuesta4 = mensaje[5];

            this.id_user_responde = Convert.ToInt32(mensaje[6]);

            DelegadoParaEscribirPreguntas delegado_preguntas = new DelegadoParaEscribirPreguntas(EscribirLabelPregunta_Respuesta);
            label3.Invoke(delegado_preguntas, new object[] { this.pregunta });


        }//Enlace de datos con Form3 [PREGUNTAS/RESPUESTAS]
        public void Enlace5_Form3(string[] mensaje)
        {
            this.flag_fin_partida = 1;
            this.ganador = mensaje[1].Split('\0')[0];

            DelegadoParaEscribirLabel delegado_fin_juego = new DelegadoParaEscribirLabel(DarGanador);

            label10.Invoke(delegado_fin_juego, new object[] { mensaje[1] });
            

        }//Enlace de datos con Form3 [FINAL JUEGO]
        public void Enlace6_Form3(string[] mensaje)
        {

            DelegadoParaEscribirGrid delegado = new DelegadoParaEscribirGrid(EscribirGrid);
            dataGridView1.Invoke(delegado, new object[] { mensaje });

        }//Enlace de datos puntos de partida para Form3
        public void EscribirGrid(string[] mensaje)
        {
            int identificador = Convert.ToInt32(mensaje[1]);

            if (identificador==0)
            {
                this.puntos1 = Convert.ToInt32(mensaje[2]);
            }
            if (identificador == 1)
            {
                this.puntos2 = Convert.ToInt32(mensaje[2]);
            }
            if (identificador == 2)
            {
                this.puntos3 = Convert.ToInt32(mensaje[2]);
            }
            if (identificador == 3)
            {
                this.puntos4 = Convert.ToInt32(mensaje[2]);
            }


            dataGridView1.Rows.Clear();

            dataGridView1.ColumnCount = 3;
            dataGridView1.RowCount = this.num_jugadores + 2;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dataGridView1.Rows[0].Cells[0].Value = "Nombre";
            dataGridView1.Rows[0].Cells[1].Value = "Ficha";
            dataGridView1.Rows[0].Cells[2].Value = "Puntos";

            if (this.num_jugadores == 2)
            {
                dataGridView1.Rows[this.user1_id + 1].Cells[0].Value = this.user1;
                dataGridView1.Rows[this.user2_id + 1].Cells[0].Value = this.user2;
                dataGridView1.Rows[this.user1_id + 1].Cells[1].Value = "Ficha 1";
                dataGridView1.Rows[this.user2_id + 1].Cells[1].Value = "Ficha 2";
                dataGridView1.Rows[this.user1_id + 1].Cells[2].Value = this.puntos1;
                dataGridView1.Rows[this.user2_id + 1].Cells[2].Value = this.puntos2;
            }

            if (this.num_jugadores == 3)
            {
                dataGridView1.Rows[this.user1_id + 1].Cells[0].Value = this.user1;
                dataGridView1.Rows[this.user2_id + 1].Cells[0].Value = this.user2;
                dataGridView1.Rows[this.user3_id + 1].Cells[0].Value = this.user3;
                dataGridView1.Rows[this.user1_id + 1].Cells[1].Value = "Ficha 1";
                dataGridView1.Rows[this.user2_id + 1].Cells[1].Value = "Ficha 2";
                dataGridView1.Rows[this.user3_id + 1].Cells[1].Value = "Ficha 3";
                dataGridView1.Rows[this.user1_id + 1].Cells[2].Value = this.puntos1;
                dataGridView1.Rows[this.user2_id + 1].Cells[2].Value = this.puntos2;
                dataGridView1.Rows[this.user3_id + 1].Cells[2].Value = this.puntos3;
            }

            if (this.num_jugadores == 4)
            {
                dataGridView1.Rows[this.user1_id + 1].Cells[0].Value = this.user1;
                dataGridView1.Rows[this.user2_id + 1].Cells[0].Value = this.user2;
                dataGridView1.Rows[this.user3_id + 1].Cells[0].Value = this.user3;
                dataGridView1.Rows[this.user4_id + 1].Cells[0].Value = this.user4;
                dataGridView1.Rows[this.user1_id + 1].Cells[1].Value = "Ficha 1";
                dataGridView1.Rows[this.user2_id + 1].Cells[1].Value = "Ficha 2";
                dataGridView1.Rows[this.user3_id + 1].Cells[1].Value = "Ficha 3";
                dataGridView1.Rows[this.user4_id + 1].Cells[1].Value = "Ficha 4";
                dataGridView1.Rows[this.user1_id + 1].Cells[2].Value = this.puntos1;
                dataGridView1.Rows[this.user2_id + 1].Cells[2].Value = this.puntos2;
                dataGridView1.Rows[this.user3_id + 1].Cells[2].Value = this.puntos3;
                dataGridView1.Rows[this.user4_id + 1].Cells[2].Value = this.puntos4;
            }

            dataGridView1.Refresh();
        }//Escribir en grid situacional de partida
        public void DarGanador(string ganador)
        {
            if (this.username==this.ganador)
            {
                sonido_victoria.Play();
                label10.BackColor = Color.Transparent;
                label10.Text = "Felicidades, "+this.ganador + " eres el nuevo ingeniero master!";
                MessageBox.Show(this.ganador + " has ganado la partida");

            }
            else
            {
                MessageBox.Show(this.ganador+" ha ganado la partida");
            }
            
            fin_bttn.Visible = true;//Muestra boton para finalizar
        }//Mensajes de victoria/derrota
        private void enviar_btn_Click(object sender, EventArgs e)
        {
            string mensaje = "12/" + username + "/" + chat_txt.Text;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }//Enviar mensaje chat [12/username/texto]
        public void EscribirLabelChat(string username, string text)
        {
            if (this.num_mensajes_rx>=2)
            {
                usuario_lbl2.Visible = true;
                respuesta_lbl2.Visible = true;

                if (this.username == this.username_chat)
                {
                    usuario_lbl.ForeColor = Color.Black;
                }
                if (this.username != this.username_chat)
                {
                    usuario_lbl.ForeColor = Color.Red;
                    sonido_mensaje.Play();
                }
                if (this.username == this.username_chat2)
                {
                    usuario_lbl2.ForeColor = Color.Black;
                }
                if (this.username != this.username_chat2)
                {
                    usuario_lbl2.ForeColor = Color.Red;
                }

                usuario_lbl.Text = this.username_chat + ":";
                respuesta_lbl.Text = this.texto + ":";
                usuario_lbl2.Text = this.username_chat2 + ":";
                respuesta_lbl2.Text = this.texto2;
            }
            else
            {
                usuario_lbl.Visible = true;
                respuesta_lbl.Visible = true;

                if (this.username == username)
                {
                    usuario_lbl.ForeColor = Color.Black;
                    usuario_lbl2.ForeColor = Color.Black;
                }
                else
                {
                    sonido_mensaje.Play();
                    usuario_lbl.ForeColor = Color.Red;
                    usuario_lbl2.ForeColor = Color.Red;
                }

                usuario_lbl.Text = username + ":";
                respuesta_lbl.Text = text;
            }  
            
        }//Escribir mensaje en chat, label
        private void pictureBox2_Click_1(object sender, EventArgs e)//TIRAR DADO [10/username/num_dado]
        {
            if ((this.flag_fin_partida == 0))
            {
                if (this.turno == this.ident)//Entonces puede tirar el dado, es su turno (y la partida no ha finalizado)
                {
                   
                    System.Media.SoundPlayer sonido_dados = new System.Media.SoundPlayer(Properties.Resources.dados);
                    sonido_dados.Play();

                    dice_num.Visible = true;

                    int num = rand.Next(1, 7);//Número dado
                    dice_num.Text = num.ToString();

                    string mensaje = "10/" + this.username + "/" + num;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                    this.turno++;
                    if (this.turno > this.num_jugadores)//En caso de llegar al max de jugadores de la partida
                    {
                        this.turno = 0;//se hace reset del valor y vuelve a empezar la cuenta
                    }

                    this.flag_tirada_dado = 1;
                    this.flag_respuesta = 0;//Reiniciar flag para responder
                }
                else
                {
                    MessageBox.Show("Espera tu turno!");
                }
            }
 
        } 
        public void Enlace_Form3(string[] mensaje)//Entra en esta funcion cada vez que se recibe 10/ en START (alguien ha tirado el dado)
        {

            string nombre_jugador = mensaje[1];
            int num_dado = Convert.ToInt32(mensaje[2]);
            int id_jugador = Convert.ToInt32(mensaje[3]);
            int turno = Convert.ToInt32(mensaje[4]);//id jugador siguiente turno
            string nombre_siguiente = mensaje[5];//nombre jugador siguiente turno

            this.turno++; //Hay que volverlo a poner, para el caso en que cliente es receptor de jugada y no emisor
            if (this.turno > this.num_jugadores)//En caso de llegar al max de jugadores de la partida
            {
                this.turno = 0;//se hace reset del valor y vuelve a empezar la cuenta
            }
            

            DelegadoParaMover delegado = new DelegadoParaMover(MoverFicha);


            if (id_jugador == 0)
            {
                label4.Invoke(delegado, new object[] { nombre_jugador, num_dado, id_jugador, nombre_siguiente });
            }
            if (id_jugador == 1)
            {
                label2.Invoke(delegado, new object[] { nombre_jugador, num_dado, id_jugador, nombre_siguiente });
            }
            if (id_jugador == 2)
            {
                label7.Invoke(delegado, new object[] { nombre_jugador, num_dado, id_jugador, nombre_siguiente });
            }
            if (id_jugador == 3)
            {
                label8.Invoke(delegado, new object[] { nombre_jugador, num_dado, id_jugador, nombre_siguiente });
            }
        }
        public void MoverFicha(string nombre_jugador, int num_dado, int id_jugador, string nombre_siguiente)//Desplazamiento de las fichas por el tablero
        {
            int i = 18;
            int encontrado = 0;
            label12.Text = "Ha tirado: " + nombre_jugador;
            label13.Text = "Siguiente turno: " + nombre_siguiente;
            count = 0;

            if (id_jugador == 0)
            {
                //if ((this.turno == 0) && (count == 0))
                //{
                //DIR_1
                if ((num_dado == 1) && (label4.Location == posiciones[24]) && (count == 0))
                {
                    this.value1 = 25;
                    label4.Location = posiciones[this.value1];
                    count++;
                }
                if ((num_dado == 2) && (label4.Location == posiciones[24]) && (count == 0))
                {
                    this.value1 = 26;
                    label4.Location = posiciones[this.value1];
                    count++;
                }
                if ((num_dado == 3) && (label4.Location == posiciones[24]) && (count == 0))
                {
                    this.value1 = 0;
                    label4.Location = posiciones[this.value1];
                    count++;
                }
                if ((num_dado > 3) && (label4.Location == posiciones[24]) && (count == 0))
                {
                    this.value1 = 0 + (num_dado - 3);
                    label4.Location = posiciones[this.value1];
                    count++;
                }
                if ((num_dado == 1) && (label4.Location == posiciones[25]) && (count == 0))
                {
                    this.value1 = 26;
                    label4.Location = posiciones[this.value1];
                    count++;
                }
                if ((num_dado == 2) && (label4.Location == posiciones[25]) && (count == 0))
                {
                    this.value1 = 0;
                    label4.Location = posiciones[this.value1];
                    count++;
                }
                if ((num_dado > 2) && (label4.Location == posiciones[25]) && (count == 0))
                {
                    this.value1 = 0 + (num_dado - 2);
                    label4.Location = posiciones[this.value1];
                    count++;
                }
                if ((num_dado == 1) && (label4.Location == posiciones[26]) && (count == 0))
                {
                    this.value1 = 0;
                    label4.Location = posiciones[this.value1];
                    count++;
                }
                if ((num_dado > 1) && (label4.Location == posiciones[26]) && (count == 0))
                {
                    this.value1 = 0 + (num_dado - 1);
                    label4.Location = posiciones[this.value1];
                    count++;
                }
                if ((label4.Location != posiciones[24]) && (label4.Location != posiciones[25]) && (label4.Location != posiciones[26]) && (count == 0))
                {
                    while ((i < 24) && (encontrado == 0))
                    {
                        if (label4.Location == posiciones[i])
                        {
                            encontrado = 1;
                        }
                        i++;
                    }
                    if (encontrado == 1)
                    {
                        if (((this.value1 + num_dado) - 24) < 0)
                        {
                            this.value1 = this.value1 + num_dado;
                            label4.Location = posiciones[this.value1];
                            count++;
                        }
                        else
                        {
                            this.value1 = (this.value1 + num_dado) - 24;
                            label4.Location = posiciones[this.value1];

                            count++;
                        }
                    }
                    else
                    {
                        this.value1 = this.value1 + num_dado;
                        label4.Location = posiciones[this.value1];
                        count++;
                    }

                }

                //this.turno = 1;
                //count = 1;//ELIMINAR??


                //DET. COLOR CASILLA:

                if ((label4.Location == posiciones[0]) || (label4.Location == posiciones[2]) || (label4.Location == posiciones[5]) || (label4.Location == posiciones[7]) || (label4.Location == posiciones[11]))
                {
                    this.id_tipo = 1;
                }//Casilla azul1 [Electro]
                if ((label4.Location == posiciones[14]) || (label4.Location == posiciones[16]) || (label4.Location == posiciones[19]) || (label4.Location == posiciones[21]) || (label4.Location == posiciones[31]) || (label4.Location == posiciones[30]))
                {
                    this.id_tipo = 1;
                }//Casilla azul2 [Electro]
                if ((label4.Location == posiciones[6]) || (label4.Location == posiciones[10]) || (label4.Location == posiciones[15]) || (label4.Location == posiciones[32]) || (label4.Location == posiciones[25]) || (label4.Location == posiciones[20]) || (label4.Location == posiciones[1]))
                {
                    this.id_tipo = 2;
                }//Casilla roja [Mates]
                if ((label4.Location == posiciones[9]) || (label4.Location == posiciones[13]) || (label4.Location == posiciones[18]) || (label4.Location == posiciones[23]) || (label4.Location == posiciones[29]) || (label4.Location == posiciones[28]) || (label4.Location == posiciones[4]))
                {
                    this.id_tipo = 3;
                }//Casilla verde [Program]
                if ((label4.Location == posiciones[12]) || (label4.Location == posiciones[8]) || (label4.Location == posiciones[17]) || (label4.Location == posiciones[22]) || (label4.Location == posiciones[26]) || (label4.Location == posiciones[3]) || (label4.Location == posiciones[27]))
                {
                    this.id_tipo = 4;
                }//Casilla amarillo [Historia]

                int random_num = rand.Next(1, this.num_preguntas);//Obtener número id_pregunta aletoria(6)

                if (this.flag_tirada_dado == 1)
                {
                    //Enviar mensaje a servidor para obtener preguntas/respuestas para esa casilla
                    string mensaje = "13/" + this.username + "/" + this.id_tipo + "/" + random_num;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                    this.flag_tirada_dado = 0;
                }

            }//FICHA1-JUGADOR0

            if (id_jugador == 1)
            {
                //if ((this.turno == 1) && (count == 0))
                //{
                //DIR_2
                if ((num_dado == 1) && (label2.Location == posiciones[24]) && (count == 0))
                {
                    this.value = 27;
                    label2.Location = posiciones[27];
                    count++;
                }
                if ((num_dado == 2) && (label2.Location == posiciones[24]) && (count == 0))
                {
                    this.value = 28;
                    label2.Location = posiciones[28];
                    count++;
                }
                if ((num_dado == 3) && (label2.Location == posiciones[24]) && (count == 0))
                {
                    this.value = 6;
                    label2.Location = posiciones[6];
                    count++;
                }
                if ((num_dado > 3) && (label2.Location == posiciones[24]) && (count == 0))
                {
                    this.value = 6 + (num_dado - 3);
                    label2.Location = posiciones[this.value];
                    count++;
                }
                if ((num_dado == 1) && (label2.Location == posiciones[27]) && (count == 0))
                {
                    this.value = 28;
                    label2.Location = posiciones[28];
                    count++;
                }
                if ((num_dado == 2) && (label2.Location == posiciones[27]) && (count == 0))
                {
                    this.value = 6;
                    label2.Location = posiciones[6];
                    count++;
                }
                if ((num_dado > 2) && (label2.Location == posiciones[27]) && (count == 0))
                {
                    this.value = 6 + (num_dado - 2);
                    label2.Location = posiciones[this.value];
                    count++;
                }
                if ((num_dado == 1) && (label2.Location == posiciones[28]) && (count == 0))
                {
                    this.value = 6;
                    label2.Location = posiciones[6];
                    count++;
                }
                if ((num_dado > 1) && (label2.Location == posiciones[28]) && (count == 0))
                {
                    this.value = 6 + (num_dado - 1);
                    label2.Location = posiciones[this.value];
                    count++;
                }
                if ((label2.Location != posiciones[24]) && (label2.Location != posiciones[27]) && (label2.Location != posiciones[28]) && (count == 0))
                {
                    while ((i < 24) && (encontrado == 0))
                    {
                        if (label2.Location == posiciones[i])
                        {
                            encontrado = 1;
                        }
                        i++;
                    }
                    if (encontrado == 1)
                    {
                        if ((this.value + num_dado - 24) < 0)
                        {
                            this.value = this.value + num_dado;
                            label2.Location = posiciones[this.value];
                            count++;
                        }
                        else
                        {
                            this.value = (this.value + num_dado) - 24;
                            label2.Location = posiciones[this.value];

                            count++;
                        }
                    }
                    else
                    {
                        this.value = this.value + num_dado;
                        label2.Location = posiciones[this.value];
                        count++;
                    }

                }

                //DET COLOR CASILLA:

                if ((label2.Location == posiciones[0]) || (label2.Location == posiciones[2]) || (label2.Location == posiciones[5]) || (label2.Location == posiciones[7]) || (label2.Location == posiciones[11]))
                {
                    this.id_tipo = 1;
                }//Casilla azul1
                if ((label2.Location == posiciones[14]) || (label2.Location == posiciones[16]) || (label2.Location == posiciones[19]) || (label2.Location == posiciones[21]) || (label2.Location == posiciones[31]) || (label2.Location == posiciones[30]))
                {
                    this.id_tipo = 1;
                }//Casilla azul2
                if ((label2.Location == posiciones[6]) || (label2.Location == posiciones[10]) || (label2.Location == posiciones[15]) || (label2.Location == posiciones[32]) || (label2.Location == posiciones[25]) || (label2.Location == posiciones[20]) || (label2.Location == posiciones[1]))
                {
                    this.id_tipo = 2;
                }//Casilla roja
                if ((label2.Location == posiciones[9]) || (label2.Location == posiciones[13]) || (label2.Location == posiciones[18]) || (label2.Location == posiciones[23]) || (label2.Location == posiciones[29]) || (label2.Location == posiciones[28]) || (label2.Location == posiciones[4]))
                {
                    this.id_tipo = 3;
                }//Casilla verde
                if ((label2.Location == posiciones[12]) || (label2.Location == posiciones[8]) || (label2.Location == posiciones[17]) || (label2.Location == posiciones[22]) || (label2.Location == posiciones[26]) || (label2.Location == posiciones[3]) || (label2.Location == posiciones[27]))
                {
                    this.id_tipo = 4;
                }//Casilla amarillo

                int random_num = rand.Next(1, this.num_preguntas);//Obtener número id_pregunta aletoria

                if (this.flag_tirada_dado == 1)
                {
                    //Enviar mensaje a servidor para obtener preguntas/respuestas para esa casilla
                    string mensaje = "13/" + this.username + "/" + this.id_tipo + "/" + random_num;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                    this.flag_tirada_dado = 0;
                }

            }//FICHA2-JUGADOR1

            if (id_jugador==2)
            {
                //if ((this.turno == 2) && (count == 0))
                //{
                    //DIR_3
                    if ((num_dado == 1) && (label7.Location == posiciones[24]) && (count == 0))
                    {
                        this.value2 = 29;
                        label7.Location = posiciones[this.value2];
                        count++;
                    }
                    if ((num_dado == 2) && (label7.Location == posiciones[24]) && (count == 0))
                    {
                        this.value2 = 30;
                        label7.Location = posiciones[this.value2];
                        count++;
                    }
                    if ((num_dado == 3) && (label7.Location == posiciones[24]) && (count == 0))
                    {
                        this.value2 = 12;
                        label7.Location = posiciones[this.value2];
                        count++;
                    }
                    if ((num_dado > 3) && (label7.Location == posiciones[24]) && (count == 0))
                    {
                        this.value2 = 12 + (num_dado - 3);
                        label7.Location = posiciones[this.value2];
                        count++;
                    }
                    if ((num_dado == 1) && (label7.Location == posiciones[29]) && (count == 0))
                    {
                        this.value2 = 30;
                        label7.Location = posiciones[this.value2];
                        count++;
                    }
                    if ((num_dado == 2) && (label7.Location == posiciones[29]) && (count == 0))
                    {
                        this.value2 = 12;
                        label7.Location = posiciones[12];
                        count++;
                    }
                    if ((num_dado > 2) && (label7.Location == posiciones[29]) && (count == 0))
                    {
                        this.value2 = 12 + (num_dado - 2);
                        label7.Location = posiciones[this.value2];
                        count++;
                    }
                    if ((num_dado == 1) && (label7.Location == posiciones[30]) && (count == 0))
                    {
                        this.value2 = 12;
                        label7.Location = posiciones[this.value2];
                        count++;
                    }
                    if ((num_dado > 1) && (label7.Location == posiciones[30]) && (count == 0))
                    {
                        this.value2 = 12 + (num_dado - 1);
                        label7.Location = posiciones[this.value2];
                        count++;
                    }
                    if ((label7.Location != posiciones[24]) && (label7.Location != posiciones[29]) && (label7.Location != posiciones[30]) && (count == 0))
                    {
                        while ((i < 24) && (encontrado == 0))
                        {
                            if (label7.Location == posiciones[i])
                            {
                                encontrado = 1;
                            }
                            i++;
                        }
                        if (encontrado == 1)
                        {
                            if ((this.value2 + num_dado - 24) < 0)
                            {
                                this.value2 = this.value2 + num_dado;
                                label7.Location = posiciones[this.value2];
                                count++;
                            }
                            else
                            {
                                this.value2 = (this.value2 + num_dado) - 24;
                                label7.Location = posiciones[this.value2];

                                count++;
                            }
                        }
                        else
                        {
                            this.value2 = this.value2 + num_dado;
                            label7.Location = posiciones[this.value2];
                            count++;
                        }

                    }

                    this.turno = 3;
                    count = 1;
                //}//FICHA3

                if ((label7.Location == posiciones[0]) || (label7.Location == posiciones[2]) || (label7.Location == posiciones[5]) || (label7.Location == posiciones[7]) || (label7.Location == posiciones[11]))
                {
                    this.id_tipo = 1;
                }//Casilla azul1 [Electro]
                if ((label7.Location == posiciones[14]) || (label7.Location == posiciones[16]) || (label7.Location == posiciones[19]) || (label7.Location == posiciones[21]) || (label7.Location == posiciones[31]) || (label7.Location == posiciones[30]))
                {
                    this.id_tipo = 1;
                }//Casilla azul2 [Electro]
                if ((label7.Location == posiciones[6]) || (label7.Location == posiciones[10]) || (label7.Location == posiciones[15]) || (label7.Location == posiciones[32]) || (label7.Location == posiciones[25]) || (label7.Location == posiciones[20]) || (label7.Location == posiciones[1]))
                {
                    this.id_tipo = 2;
                }//Casilla roja [Mates]
                if ((label7.Location == posiciones[9]) || (label7.Location == posiciones[13]) || (label7.Location == posiciones[18]) || (label7.Location == posiciones[23]) || (label7.Location == posiciones[29]) || (label7.Location == posiciones[28]) || (label7.Location == posiciones[4]))
                {
                    this.id_tipo = 3;
                }//Casilla verde [Program]
                if ((label7.Location == posiciones[12]) || (label7.Location == posiciones[8]) || (label7.Location == posiciones[17]) || (label7.Location == posiciones[22]) || (label7.Location == posiciones[26]) || (label7.Location == posiciones[3]) || (label7.Location == posiciones[27]))
                {
                    this.id_tipo = 4;
                }//Casilla amarillo [Historia]

                int random_num = rand.Next(1, this.num_preguntas);//Obtener número id_pregunta aletoria

                if (this.flag_tirada_dado == 1)
                {
                    //Enviar mensaje a servidor para obtener preguntas/respuestas para esa casilla
                    string mensaje = "13/" + this.username + "/" + this.id_tipo + "/" + random_num;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                    this.flag_tirada_dado = 0;
                }
            }//FICHA3-JUGADOR2

            if (id_jugador==3)
            {
                //if ((this.turno == 3) && (count == 0))
                //{
                    //DIR_4
                    if ((num_dado == 1) && (label8.Location == posiciones[24]) && (count == 0))
                    {
                        this.value3 = 31;
                        label8.Location = posiciones[this.value3];
                        count++;
                    }
                    if ((num_dado == 2) && (label8.Location == posiciones[24]) && (count == 0))
                    {
                        this.value3 = 32;
                        label7.Location = posiciones[this.value3];
                        count++;
                    }
                    if ((num_dado == 3) && (label8.Location == posiciones[24]) && (count == 0))
                    {
                        this.value2 = 18;
                        label8.Location = posiciones[this.value3];
                        count++;
                    }
                    if ((num_dado > 3) && (label8.Location == posiciones[24]) && (count == 0))
                    {
                        this.value3 = 18 + (num_dado - 3);
                        label8.Location = posiciones[this.value3];
                        count++;
                    }
                    if ((num_dado == 1) && (label8.Location == posiciones[31]) && (count == 0))
                    {
                        this.value3 = 32;
                        label8.Location = posiciones[this.value2];
                        count++;
                    }
                    if ((num_dado == 2) && (label8.Location == posiciones[31]) && (count == 0))
                    {
                        this.value3 = 18;
                        label8.Location = posiciones[18];
                        count++;
                    }
                    if ((num_dado > 2) && (label8.Location == posiciones[31]) && (count == 0))
                    {
                        this.value3 = 18 + (num_dado - 2);
                        label8.Location = posiciones[this.value3];
                        count++;
                    }
                    if ((num_dado == 1) && (label8.Location == posiciones[32]) && (count == 0))
                    {
                        this.value3 = 18;
                        label8.Location = posiciones[this.value3];
                        count++;
                    }
                    if ((num_dado > 1) && (label8.Location == posiciones[32]) && (count == 0))
                    {
                        this.value3 = 18 + (num_dado - 1);
                        label8.Location = posiciones[this.value3];
                        count++;
                    }
                    if ((label8.Location != posiciones[24]) && (label8.Location != posiciones[31]) && (label8.Location != posiciones[32]) && (count == 0))
                    {
                        while ((i < 24) && (encontrado == 0))
                        {
                            if (label8.Location == posiciones[i])
                            {
                                encontrado = 1;
                            }
                            i++;
                        }
                        if (encontrado == 1)
                        {
                            if ((this.value3 + num_dado - 24) < 0)
                            {
                                this.value3 = this.value3 + num_dado;
                                label8.Location = posiciones[this.value3];
                                count++;
                            }
                            else
                            {
                                this.value3 = (this.value3 + num_dado) - 24;
                                label8.Location = posiciones[this.value3];

                                count++;
                            }
                        }
                        else
                        {
                            this.value3 = this.value3 + num_dado;
                            label8.Location = posiciones[this.value3];
                            count++;
                        }

                    }

                    this.turno = 0;
                    count = 1;
                //}//FICHA4

                if ((label8.Location == posiciones[0]) || (label8.Location == posiciones[2]) || (label8.Location == posiciones[5]) || (label8.Location == posiciones[7]) || (label8.Location == posiciones[11]))
                {
                    this.id_tipo = 1;
                }//Casilla azul1 [Electro]
                if ((label8.Location == posiciones[14]) || (label8.Location == posiciones[16]) || (label8.Location == posiciones[19]) || (label8.Location == posiciones[21]) || (label8.Location == posiciones[31]) || (label8.Location == posiciones[30]))
                {
                    this.id_tipo = 1;
                }//Casilla azul2 [Electro]
                if ((label8.Location == posiciones[6]) || (label8.Location == posiciones[10]) || (label8.Location == posiciones[15]) || (label8.Location == posiciones[32]) || (label8.Location == posiciones[25]) || (label8.Location == posiciones[20]) || (label8.Location == posiciones[1]))
                {
                    this.id_tipo = 2;
                }//Casilla roja [Mates]
                if ((label8.Location == posiciones[9]) || (label8.Location == posiciones[13]) || (label8.Location == posiciones[18]) || (label8.Location == posiciones[23]) || (label8.Location == posiciones[29]) || (label8.Location == posiciones[28]) || (label8.Location == posiciones[4]))
                {
                    this.id_tipo = 3;
                }//Casilla verde [Program]
                if ((label8.Location == posiciones[12]) || (label8.Location == posiciones[8]) || (label8.Location == posiciones[17]) || (label8.Location == posiciones[22]) || (label8.Location == posiciones[26]) || (label8.Location == posiciones[3]) || (label8.Location == posiciones[27]))
                {
                    this.id_tipo = 4;
                }//Casilla amarillo [Historia]

                int random_num = rand.Next(1, this.num_preguntas);//Obtener número id_pregunta aletoria

                if (this.flag_tirada_dado == 1)
                {
                    //Enviar mensaje a servidor para obtener preguntas/respuestas para esa casilla
                    string mensaje = "13/" + this.username + "/" + this.id_tipo + "/" + random_num;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                    this.flag_tirada_dado = 0;
                }

            }//FICHA4-JUGADOR3
             
        }//[13/username/codigo_categoria/num_pregunta]
        public void GetIdent()
        {
            string mensaje = "11/" + this.username;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }//Enviar al cargar form peticion para obtener identificadores + info partida [11/username]
        public void Enlace2_Form3(string[] mensaje)
        {
            int cont= Convert.ToInt32(mensaje[1]);//pos1 siempre es longitud
            //pos2 siempre es nombre usuario local
            this.num_jugadores = Convert.ToInt32(mensaje[cont + 1]);//total jugadores
            this.num_preguntas = Convert.ToInt32(mensaje[cont + 2]);//num preguntas bbdd

            if (this.num_jugadores==2)
            {
                this.user1 = mensaje[2];
                this.user1_id = Convert.ToInt32(mensaje[3]);
                this.user2 = mensaje[4];
                this.user2_id = Convert.ToInt32(mensaje[5]);
            }
            if (this.num_jugadores == 3)
            {
                this.user1 = mensaje[2];
                this.user1_id = Convert.ToInt32(mensaje[3]);
                this.user2 = mensaje[4];
                this.user2_id = Convert.ToInt32(mensaje[5]);
                this.user3 = mensaje[6];
                this.user3_id = Convert.ToInt32(mensaje[7]);
            }
            if (this.num_jugadores == 4)
            {
                this.user1 = mensaje[2];
                this.user1_id = Convert.ToInt32(mensaje[3]);
                this.user2 = mensaje[4];
                this.user2_id = Convert.ToInt32(mensaje[5]);
                this.user3 = mensaje[6];
                this.user3_id = Convert.ToInt32(mensaje[7]); ;
                this.user4 = mensaje[8];
                this.user4_id = Convert.ToInt32(mensaje[9]);
            }

            int i = 2;
            int encontrado = 0;

            while ((i<cont)&&(encontrado==0))//Buscar del vector, el id local correspondiente
            {
                if (mensaje[i]==this.username)
                {
                    this.ident = Convert.ToInt32(mensaje[i+1]);
                    encontrado = 1;
                }
                i++;
            }

            //MessageBox.Show("id_otro: " + this.user1 + " nombre: " + this.user1);

        }//Enlace de datos de info de partida para Form3
        public void EscribirLabelPregunta_Respuesta(string pregunta_respuesta)
        {
            if (this.id_tipo == 1)//Pregunta casilla AZUL-ELECTRONICA
            {
                label1.Text = "ELECTRONICA";
                label1.ForeColor = Color.Cyan;

                label3.Text = this.pregunta;
                label3.ForeColor = Color.Cyan;
            }
            if (this.id_tipo == 2)//Pregunta casilla ROJO-MATEMATICA
            {
                label1.Text = "MATEMÁTICAS";
                label1.ForeColor = Color.DarkRed;

                label3.Text = this.pregunta;
                label3.ForeColor = Color.DarkRed;
            }
            if (this.id_tipo == 3)//Pregunta casilla VERDE-PROGRAM
            {
                label1.Text = "PROGRAMACIÓN";
                label1.ForeColor = Color.Lime;

                label3.Text = this.pregunta;
                label3.ForeColor = Color.Lime;
            }
            if (this.id_tipo == 4)//Pregunta casilla AMARILLA-HISTORIA
            {
                label1.Text = "HISTORIA DE LA UPC";
                label1.ForeColor = Color.Gold;

                label3.Text = this.pregunta;
                label3.ForeColor = Color.Gold;
            }

            int num = rand.Next(1,6);

            if (num==1)
            {
                res1.Text = "a) " + this.respuesta1;
                res2.Text = "b) " + this.respuesta2;
                res3.Text = "c) " + this.respuesta3;
                res4.Text = "d) " + this.respuesta4;
            }
            if (num == 2)
            {
                res1.Text = "a) " + this.respuesta2;
                res2.Text = "b) " + this.respuesta1;
                res3.Text = "c) " + this.respuesta4;
                res4.Text = "d) " + this.respuesta3;
            }
            if (num == 3)
            {
                res1.Text = "a) " + this.respuesta4;
                res2.Text = "b) " + this.respuesta1;
                res3.Text = "c) " + this.respuesta3;
                res4.Text = "d) " + this.respuesta2;
            }
            if (num == 4)
            {
                res1.Text = "a) " + this.respuesta3;
                res2.Text = "b) " + this.respuesta4;
                res3.Text = "c) " + this.respuesta2;
                res4.Text = "d) " + this.respuesta1;
            }
            if (num == 5)
            {
                res1.Text = "a) " + this.respuesta3;
                res2.Text = "b) " + this.respuesta2;
                res3.Text = "c) " + this.respuesta1;
                res4.Text = "d) " + this.respuesta4;
            }
            if (num == 6)
            {
                res1.Text = "a) " + this.respuesta1;
                res2.Text = "b) " + this.respuesta4;
                res3.Text = "c) " + this.respuesta3;
                res4.Text = "d) " + this.respuesta2;
            }

        
        }//Escribir respuestas/preguntas en FORMS
    }
}
