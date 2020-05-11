using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace library_mangement
{
    public partial class addbooks : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\projects\Library Management System\library mangement\Database1.mdf;Integrated Security=True");

        public addbooks()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ADD_Click(object sender, EventArgs e)
        {

           // try
            //{
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into books values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + dateTimePicker1.Value + " '," + textBox5.Text + "," + textBox6.Text + "," + textBox6.Text + ")";
                cmd.ExecuteNonQuery();
                con.Close();


                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                MessageBox.Show("Books added Successfully");


            //}

           /* catch (Exception ex)
            {
                {
                    MessageBox.Show("Invalid format.Pleas Re_enter");
                }

            }*/
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
