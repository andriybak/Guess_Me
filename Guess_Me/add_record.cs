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
    public partial class add_record : Form
    {
        public add_record(String elapsed)
        {
            InitializeComponent();
            time.Text = elapsed;
        }

        DBconnection objConnect;
        string conString;
        DataSet ds;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox1.Text.Length>0){
                    objConnect = new DBconnection();
                    conString = Properties.Settings.Default.ConnectionString;
                    objConnect.connection_string = conString;
                    objConnect.Sql = Properties.Settings.Default.GET_ALL;
                    ds = objConnect.GetConnection;

                    DataRow newData = ds.Tables[0].NewRow();
                    newData[1] = textBox1.Text;
                    newData[2] = time.Text;

                    ds.Tables[0].Rows.Add(newData);

                    objConnect.UpdateDatabase(ds);
                    MessageBox.Show("Updated!"+ textBox1.Text.Length);
                    Menu form2 = new Menu();
                    form2.Show();
                    Hide();
                }
                else MessageBox.Show("Enter your name please!");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

           
        }
    }
}
