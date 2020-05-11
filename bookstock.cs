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
using System.Net.Mail;
using System.Net;




namespace library_mangement
{
    public partial class bookstock : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\projects\Library Management System\library mangement\Database1.mdf;Integrated Security=True");

        public bookstock()
        {
            InitializeComponent();
        }

        private void bookstock_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();
            fill_books_info();

        }
            public void fill_books_info()
            {

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select books_name,books_author,books_quantity,books_available_qty from books ";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;

            }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            string i;
            i = dataGridView1.SelectedCells[0].Value.ToString();
            MessageBox.Show(i.ToString());

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from issue_books where books_name='"+i.ToString()+"'and book_return_date=''";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView2.DataSource = dt;



        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select books_name,books_author,books_quantity,books_available_qty from books where books_name like('%"+textBox1.Text+"%') ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            string i;
            i = dataGridView2.SelectedCells[5].Value.ToString();
            txt_mail.Text=i.ToString();

      

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SmtpClient smtp = new SmtpClient("smtp.gmail.com",25);
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            //(username,password)
            smtp.Credentials = new NetworkCredential("wbmadushani@gmail.com", "958250185vF","gmail.com");
                
             MailMessage mail=new MailMessage("wbmadushani@gmail.com", txt_mail.Text, "this is for book return notice from the library", txt_contact.Text);
            mail.Priority = MailPriority.High;
            smtp.Send(mail);
            MessageBox.Show("mail send");
        }
    }
}
