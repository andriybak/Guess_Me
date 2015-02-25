// Project Created by Andriy Bakshalov
// 2015

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guess_Me
{
    public partial class Game : Form
    {
        Stopwatch sw = new Stopwatch();

        Random rd = new Random();
        List<String> items = new List<string>
        {
            "!", "!", "N", "N", ",", ",", "k", "k",
            "b", "b", "v", "v", "w", "w", "z", "z"
        };
        Label first_clicked = null;
        Label second_clicked = null;
        int matches = 0;
        public Game()
        {
            sw.Start();
            InitializeComponent();
            assign_icons();            
        }

        private void assign_icons()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int rd_item = rd.Next(items.Count);
                    iconLabel.Text = items[rd_item];
                    items.RemoveAt(rd_item);
                    iconLabel.ForeColor = iconLabel.BackColor;                    
                }
            }
        }

        private void label_click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                return;
            }

            Label clicked_label = sender as Label;
            if (clicked_label != null)
            {   
                if (clicked_label.ForeColor == Color.Black)
                    return;
                if (first_clicked == null)
                {
                    first_clicked = clicked_label;
                    clicked_label.ForeColor = Color.Red;
                    return;
                }             
                    second_clicked = clicked_label;
                    clicked_label.ForeColor = Color.Red;              

                if (!(second_clicked.Text.Equals(first_clicked.Text)))
                {
                    timer1.Start();
                }
                else
                {
                    first_clicked.ForeColor = Color.Black;
                    second_clicked.ForeColor = Color.Black;
                    first_clicked = null;
                    second_clicked = null;
                    matches++;                     
                }
                if (matches == 8)
                {
                    sw.Stop();
                    TimeSpan ts = sw.Elapsed;
                    String elapsedTime = String.Format("{0:00}:{1:00}:{2:00}",
                    ts.Hours, ts.Minutes, ts.Seconds);
                    MessageBox.Show("Congratulations you won!!! Your times is: " + elapsedTime);
                    add_record record = new add_record(elapsedTime);
                    record.Tag = this;
                    record.Show(this);
                    Hide();
                }                             
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {            
            timer1.Stop();

            first_clicked.ForeColor = first_clicked.BackColor;
            second_clicked.ForeColor = second_clicked.BackColor;

            first_clicked = null;
            second_clicked = null;
        }


    }
}
