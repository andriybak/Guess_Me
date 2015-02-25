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
    public partial class highscores : Form
    {
        public highscores()
        {
            InitializeComponent();
        }
        DBconnection objConnect;
        string conString;
        DataSet ds;
        DataRow dRow;

        int MaxRows;
        int inc = 0;

        private void highscores_Load(object sender, EventArgs e)
        {
            try 
            {
                objConnect = new DBconnection();
                conString = Properties.Settings.Default.ConnectionString;
                objConnect.connection_string = conString;
                objConnect.Sql = Properties.Settings.Default.GET_ALL;
                ds = objConnect.GetConnection;
                MaxRows = ds.Tables[0].Rows.Count;

                NavigateRecords();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        private void NavigateRecords()
        {
            if (MaxRows > 0)
            {
                dRow = ds.Tables[0].Rows[inc];
                label1.Text = (inc + 1) + ". " + dRow.ItemArray.GetValue(1).ToString();
                label2.Text = dRow.ItemArray.GetValue(2).ToString();
                for (inc = 1; inc < MaxRows && inc < 5; inc++)
                {
                    dRow = ds.Tables[0].Rows[inc];
                    label1.Text = label1.Text + "\n" + (inc + 1) + ". " + dRow.ItemArray.GetValue(1).ToString();
                    label2.Text = label2.Text + "\n" + dRow.ItemArray.GetValue(2).ToString();
                }
            }
            else
            {
                label1.Text = "No data yet.";
                label2.Text = "No time yet.";
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu form2 = new Menu();
            form2.Show();
            Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
