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
using System.Threading;

namespace ProyectoSO
{
    public partial class GAME : Form
    {
        List<Point> posiciones = new List<Point>();//Lista casillas tablero
        Random rand = new Random();
        Random rand_dir = new Random();
        int count = 0;
        int user1, user2, user3, user4;//dirección
        int value,value1,value2,value3;//Guardar pos fichas
        int turno=0;

        string username;
        public GAME()
        {
            InitializeComponent();
        }

        private void GAME_Load(object sender, EventArgs e)
        {
            user_lbl.Text = username;

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

            //Aleatoriedad para punto de partida
            this.user1 = rand_dir.Next(1, 5);

            this.user2 = rand_dir.Next(1, 5);
            if (this.user2 == this.user1)
            {
                while (this.user2 == this.user1)
                {
                    this.user2 = rand_dir.Next(1, 5);
                }
            }

            this.user3 = rand_dir.Next(1, 5);
            if ((this.user3 == this.user2) | (this.user3 == this.user1))
            {
                while ((this.user3 == this.user2) | (this.user3 == this.user1))
                {
                    this.user3 = rand_dir.Next(1, 5);
                }
            }

            this.user4 = rand_dir.Next(1, 5);
            if ((this.user4 == this.user3) | (this.user4 == this.user2) | (this.user4 == this.user1))
            {
                while ((this.user4 == this.user3) | (this.user4 == this.user2) | (this.user4 == this.user1))
                {
                    this.user4 = rand_dir.Next(1, 5);
                }
            }

        }

        public void GetUsername(string name)
        {
            this.username = name;
        }

        private void Tablero_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            ficha.Location = posiciones[count];
            this.count++;
            label5.Text = "Count: " + (count-1);
        }

        private void Tablero_MouseMove(object sender, MouseEventArgs e)
        {
            label6.Text = e.X.ToString() + "," + e.Y.ToString();
        }


        private void pictureBox2_Click_1(object sender, EventArgs e)//DADO
        {
            int count = 0;
           // pictureBox2.Image = Image.FromFile(@"C:\share\S1\Proyecto-SO-Grupo3-2\Proyecto-SO-Grupo3-2\Cliente\ProyectoSO\bin\Debug\dado2.gif");
            //pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

            //System.Media.SoundPlayer sonido_dados = new System.Media.SoundPlayer(Properties.Resources.dados);
            //sonido_dados.Play();

            int num = rand.Next(1, 7);//Número dado
            dice_num.Text = num.ToString();

            int i = 18;
            int encontrado = 0;

            if ((this.turno == 0)&&(count==0))
            {         
            //DIR_1
            if ((num == 1) && (label4.Location == posiciones[24]) && (count == 0))
            {
                this.value1 = 25;
                label4.Location = posiciones[this.value1];
                count++;
            }
            if ((num == 2) && (label4.Location == posiciones[24]) && (count == 0))
            {
                this.value1 = 26;
                label4.Location = posiciones[this.value1];
                count++;
            }
            if ((num == 3) && (label4.Location == posiciones[24]) && (count == 0))
            {
                this.value1 = 0;
                label4.Location = posiciones[this.value1];
                count++;
            }
            if ((num > 3) && (label4.Location == posiciones[24]) && (count == 0))
            {
                this.value1 = 0 + (num - 3);
                label4.Location = posiciones[this.value1];
                count++;
            }
            if ((num == 1) && (label4.Location == posiciones[25]) && (count == 0))
            {
                this.value1 = 26;
                label4.Location = posiciones[this.value1];
                count++;
            }
            if ((num == 2) && (label4.Location == posiciones[25]) && (count == 0))
            {
                this.value1 = 0;
                label4.Location = posiciones[this.value1];
                count++;
            }
            if ((num > 2) && (label4.Location == posiciones[25]) && (count == 0))
            {
                this.value1 = 0 + (num - 2);
                label4.Location = posiciones[this.value1];
                count++;
            }
            if ((num == 1) && (label4.Location == posiciones[26]) && (count == 0))
            {
                this.value1 = 0;
                label4.Location = posiciones[this.value1];
                count++;
            }
            if ((num > 1) && (label4.Location == posiciones[26]) && (count == 0))
            {
                this.value1 = 0 + (num - 1);
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
                    if (((this.value1 + num) - 24) < 0)
                    {
                        this.value1 = this.value1 + num;
                        label4.Location = posiciones[this.value1];
                        count++;
                    }
                    else
                    {
                        this.value1 = (this.value1 + num) - 24;
                        label4.Location = posiciones[this.value1];

                        count++;
                    }
                }
                else
                {
                    this.value1 = this.value1 + num;
                    label4.Location = posiciones[this.value1];
                    count++;
                }

            }
                
                this.turno = 1;
                count = 1;
            }//FICHA1

            if ((this.turno == 1)&& (count == 0))
            {
                //DIR_2
                if ((num == 1) && (label2.Location == posiciones[24]) && (count == 0))
                {
                    this.value = 27;
                    label2.Location = posiciones[27];
                    count++;
                }
                if ((num == 2) && (label2.Location == posiciones[24]) && (count == 0))
                {
                    this.value = 28;
                    label2.Location = posiciones[28];
                    count++;
                }
                if ((num == 3) && (label2.Location == posiciones[24]) && (count == 0))
                {
                    this.value = 6;
                    label2.Location = posiciones[6];
                    count++;
                }
                if ((num > 3) && (label2.Location == posiciones[24]) && (count == 0))
                {
                    this.value = 6 + (num - 3);
                    label2.Location = posiciones[this.value];
                    count++;
                }
                if ((num == 1) && (label2.Location == posiciones[27]) && (count == 0))
                {
                    this.value = 28;
                    label2.Location = posiciones[28];
                    count++;
                }
                if ((num == 2) && (label2.Location == posiciones[27]) && (count == 0))
                {
                    this.value = 6;
                    label2.Location = posiciones[6];
                    count++;
                }
                if ((num > 2) && (label2.Location == posiciones[27]) && (count == 0))
                {
                    this.value = 6 + (num - 2);
                    label2.Location = posiciones[this.value];
                    count++;
                }
                if ((num == 1) && (label2.Location == posiciones[28]) && (count == 0))
                {
                    this.value = 6;
                    label2.Location = posiciones[6];
                    count++;
                }
                if ((num > 1) && (label2.Location == posiciones[28]) && (count == 0))
                {
                    this.value = 6 + (num - 1);
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
                        if ((this.value + num - 24) < 0)
                        {
                            this.value = this.value + num;
                            label2.Location = posiciones[this.value];
                            count++;
                        }
                        else
                        {
                            this.value = (this.value + num) - 24;
                            label2.Location = posiciones[this.value];

                            count++;
                        }
                    }
                    else
                    {
                        this.value = this.value + num;
                        label2.Location = posiciones[this.value];
                        count++;
                    }

                }

                this.turno = 2;
                count = 1;
            }//FICHA2

            if ((this.turno == 2) && (count == 0))
            {
                //DIR_3
                if ((num == 1) && (label7.Location == posiciones[24]) && (count == 0))
                {
                    this.value2 = 29;
                    label2.Location = posiciones[this.value2];
                    count++;
                }
                if ((num == 2) && (label7.Location == posiciones[24]) && (count == 0))
                {
                    this.value2 = 30;
                    label7.Location = posiciones[this.value2];
                    count++;
                }
                if ((num == 3) && (label7.Location == posiciones[24]) && (count == 0))
                {
                    this.value2 = 12;
                    label7.Location = posiciones[this.value2];
                    count++;
                }
                if ((num > 3) && (label7.Location == posiciones[24]) && (count == 0))
                {
                    this.value2 = 12 + (num - 3);
                    label7.Location = posiciones[this.value2];
                    count++;
                }
                if ((num == 1) && (label7.Location == posiciones[29]) && (count == 0))
                {
                    this.value2 = 30;
                    label2.Location = posiciones[this.value2];
                    count++;
                }
                if ((num == 2) && (label7.Location == posiciones[29]) && (count == 0))
                {
                    this.value2 = 12;
                    label7.Location = posiciones[12];
                    count++;
                }
                if ((num > 2) && (label7.Location == posiciones[29]) && (count == 0))
                {
                    this.value2 = 12 + (num - 2);
                    label7.Location = posiciones[this.value2];
                    count++;
                }
                if ((num == 1) && (label7.Location == posiciones[30]) && (count == 0))
                {
                    this.value2 = 12;
                    label7.Location = posiciones[this.value2];
                    count++;
                }
                if ((num > 1) && (label7.Location == posiciones[30]) && (count == 0))
                {
                    this.value2 = 12 + (num - 1);
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
                        if ((this.value2 + num - 24) < 0)
                        {
                            this.value2 = this.value2 + num;
                            label7.Location = posiciones[this.value2];
                            count++;
                        }
                        else
                        {
                            this.value2 = (this.value2 + num) - 24;
                            label7.Location = posiciones[this.value2];

                            count++;
                        }
                    }
                    else
                    {
                        this.value2 = this.value2 + num;
                        label7.Location = posiciones[this.value2];
                        count++;
                    }

                }

                this.turno = 3;
                count = 1;
            }//FICHA3

            if ((this.turno == 3) && (count == 0))
            {
                //DIR_4
                if ((num == 1) && (label8.Location == posiciones[24]) && (count == 0))
                {
                    this.value3 = 31;
                    label8.Location = posiciones[this.value3];
                    count++;
                }
                if ((num == 2) && (label8.Location == posiciones[24]) && (count == 0))
                {
                    this.value3 = 32;
                    label7.Location = posiciones[this.value3];
                    count++;
                }
                if ((num == 3) && (label8.Location == posiciones[24]) && (count == 0))
                {
                    this.value2 = 18;
                    label8.Location = posiciones[this.value3];
                    count++;
                }
                if ((num > 3) && (label8.Location == posiciones[24]) && (count == 0))
                {
                    this.value3 = 18 + (num - 3);
                    label8.Location = posiciones[this.value3];
                    count++;
                }
                if ((num == 1) && (label8.Location == posiciones[31]) && (count == 0))
                {
                    this.value3 = 32;
                    label8.Location = posiciones[this.value2];
                    count++;
                }
                if ((num == 2) && (label8.Location == posiciones[31]) && (count == 0))
                {
                    this.value3 = 18;
                    label8.Location = posiciones[18];
                    count++;
                }
                if ((num > 2) && (label8.Location == posiciones[31]) && (count == 0))
                {
                    this.value3 = 18 + (num - 2);
                    label8.Location = posiciones[this.value3];
                    count++;
                }
                if ((num == 1) && (label8.Location == posiciones[32]) && (count == 0))
                {
                    this.value3 = 18;
                    label8.Location = posiciones[this.value3];
                    count++;
                }
                if ((num > 1) && (label8.Location == posiciones[32]) && (count == 0))
                {
                    this.value3 = 18 + (num - 1);
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
                        if ((this.value3 + num - 24) < 0)
                        {
                            this.value3 = this.value3 + num;
                            label8.Location = posiciones[this.value3];
                            count++;
                        }
                        else
                        {
                            this.value3 = (this.value3 + num) - 24;
                            label8.Location = posiciones[this.value3];

                            count++;
                        }
                    }
                    else
                    {
                        this.value3 = this.value3 + num;
                        label8.Location = posiciones[this.value3];
                        count++;
                    }

                }

                this.turno = 0;
                count = 1;
            }//FICHA4



        }
    }
}
