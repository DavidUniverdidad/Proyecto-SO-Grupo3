using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ProyectoSO
{
    public partial class Form5 : Form
    {
        int nForms;
        public Form5(int nForm)
        {
            this.nForms = nForm;
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
