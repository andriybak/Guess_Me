// Project Created by Andriy Bakshalov
// 2015

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guess_Me
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();          
        }

        private void button1_Click(object sender, EventArgs e)
        {          
            Game form1 = new Game();
            form1.Show();
            Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            highscores hs = new highscores();
            hs.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
