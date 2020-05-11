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
    public partial class return_books : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\projects\Library Management System\library mangement\Database1.mdf;Integrated Security=True");


        int i;
        public return_books()
        {
            InitializeComponent();
        }

    

        private void return_books_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            fill_grid(txt_enroll.Text);
        }

        public void fill_grid(string enrollment)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from issue_books where student_registration_no='"+enrollment.ToString()+"' and book_return_date=''";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel3.Visible = true;
            
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from issue_books where Id=" + i + "";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                booksname.Text = row.Cells[6].Value.ToString();
                dateTimePicker1.Text = row.Cells[7].Value.ToString();
                dateTimePicker2.Text = row.Cells[8].Value.ToString();

            }



        }

        private void button3_Click(object sender, EventArgs e)
        {
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update  issue_books  set book_return_date='"+dateTimePicker2.Value.ToString()+"'  where Id="+i+"";
            cmd.ExecuteNonQuery();


            SqlCommand cmd1= con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "update  books  set books_available_qty=books_available_qty+1 where books_name='"+booksname.Text+"'";
            cmd1.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();


            MessageBox.Show("books return successfully");

            fill_grid(txt_enroll.Text);
            panel3.Visible = true;



        }
    }
}
