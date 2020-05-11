using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;


namespace library_mangement
{
    public partial class add_student : Form
    {

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\projects\Library Management System\library mangement\Database1.mdf;Integrated Security=True");


       //string pwd;
        string wanted_path;
        string pwd = Class1.GetRandomPassword(20);

        public add_student()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void name_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void add_student_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            wanted_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            DialogResult result = openFileDialog1.ShowDialog();
            openFileDialog1.Filter = "JPEG Files (*.jpeg)|.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files(*.gif)|*.gif";
            if (result == DialogResult.OK)
            {

                pictureBox1.ImageLocation = openFileDialog1.FileName;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            //pictureBox1.ImageLocation = @"..\..\students_images\" + pwd + ".jpg";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string img_path;
                File.Copy(openFileDialog1.FileName, wanted_path + "\\students_images\\" + pwd + ".jpg");

                img_path = "student_images\\" + pwd + ".jpg";
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into s_info values('" + textBox4.Text + "','" + textBox1.Text + "','" + @"students_images\" + pwd + ".jpg".ToString() + "','" + textBox3.Text + "','" + textBox5.Text + "','" + textBox7.Text + "')";
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Sucessfully registered");

            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
