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

namespace ProyectoSO
{
    public partial class Form2 : Form
    {
        string username;
        System.Media.SoundPlayer sonido_puntero = new System.Media.SoundPlayer(Properties.Resources.fsx_sonido_puntero);

        public Form2()
        {
            InitializeComponent();
        }
        public void GetUser(string name)
        {
            this.username = name;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            welcome_txt.Text = "Welcome to TelecoTrivial, "+username+"!";
        }

        private void exit_bttn_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer sonido_exit = new System.Media.SoundPlayer(Properties.Resources.fsx);
            sonido_exit.Play();
            this.Close();
        }

        private void play_bbtn_MouseEnter(object sender, EventArgs e)
        {
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
            GAME game = new GAME();
            game.GetUsername(username);
            System.Media.SoundPlayer sonido_play = new System.Media.SoundPlayer(Properties.Resources.fsx);
            sonido_play.Play();

            game.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer sonido_profile = new System.Media.SoundPlayer(Properties.Resources.fsx);
            sonido_profile.Play();
        }

        private void help_bttn_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer sonido_help = new System.Media.SoundPlayer(Properties.Resources.fsx);
            sonido_help.Play();
        }
    }
}
