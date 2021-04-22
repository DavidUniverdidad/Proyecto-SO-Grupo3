using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoSO
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public string GetUser(string name)
        {
            return name;
            //welcome_txt.Text = "Welcome to TelecoTrivial, " + name + "!";
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }
    }
}
