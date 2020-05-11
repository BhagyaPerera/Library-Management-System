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
using System.IO;

namespace library_mangement
{
    public partial class Issue_books : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\projects\Library Management System\library mangement\Database1.mdf;Integrated Security=True");


        public Issue_books()
        {
            InitializeComponent();
        }

        private void Issue_books_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {

                con.Close();

            }

            con.Open();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from s_info where student_registration_no='" + txt_enroll.Text + "'";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            int i;
            i = Convert.ToInt32(dt.Rows.Count.ToString());


            if (i == 0)
            {

                MessageBox.Show("This enrollment number not Found");
            }

            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    txt_name.Text = dr["student_name"].ToString();
                    txt_NIC.Text = dr["student_NIC"].ToString();
                    txt_contact.Text = dr["student_contact"].ToString();
                    txt_mail.Text = dr["student_email"].ToString();
                    //dateTimePicker1.Text = dr["books_issue_date"].ToString();
                    //txt_bookname.Text = dr["books_name"].ToString();

                }


            }

        }

        private void txt_bookname_KeyUp(object sender, KeyEventArgs e)
        {
            int count = 0;


            if (e.KeyCode != Keys.Enter)
            {

                listBox1.Items.Clear();


                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from books where books_name like('%" + txt_bookname.Text + "%')";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                count = Convert.ToInt32(dt.Rows.Count.ToString());

                if (count > 0)
                {
                    listBox1.Visible = true;
                    foreach (DataRow dr in dt.Rows)
                    {
                        listBox1.Items.Add(dr["books_name"].ToString());

                    }




                }






            }



        }

        private void txt_bookname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                listBox1.Focus();

                listBox1.SelectedIndex = 0;

            }
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_bookname.Text = listBox1.SelectedItem.ToString();
                listBox1.Visible = false;



            }
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            txt_bookname.Text = listBox1.SelectedItem.ToString();
            listBox1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {


  
            /*SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select * from books where books_name='" + txt_bookname + "' and books_available_qty>0";
            cmd2.ExecuteNonQuery();

            DataTable dt2 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            da.Fill(dt2);

            if (dt2.DataSet != null)
            {
                MessageBox.Show("Book issued successfully");
            }

            else
            {
                MessageBox.Show("Book is not available");

            }*/
               
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into issue_books values('" + txt_enroll.Text + "','" + txt_name.Text + "','" + txt_contact.Text + "','" + txt_NIC.Text + "','" + txt_mail.Text + "','" + txt_bookname.Text + "','" + dateTimePicker1.Value.ToShortDateString() + "','')";
            cmd.ExecuteNonQuery();

            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "update books set books_available_qty=books_available_qty-1 where books_name='" + txt_bookname.Text + "' and books_available_qty>0";
            cmd1.ExecuteNonQuery();
            MessageBox.Show("Book issued successfully");

        }

        }
    }
