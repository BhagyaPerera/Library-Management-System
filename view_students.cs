using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;


namespace library_mangement
{
    public partial class view_students : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\projects\Library Management System\library mangement\Database1.mdf;Integrated Security=True");
        int i = 0;
        string wanted_path;
        string pwd = Class1.GetRandomPassword(20);
        DialogResult result;

        public view_students()
        {
            InitializeComponent();
        }


        private void view_students_Load(object sender, EventArgs e)
        {

            int i = 0;
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();

            }
            conn.Open();
            fill_grid();

            
        }

        public void fill_grid()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from s_info";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;


            /* DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
             imageCol.Width = 500;
             imageCol.HeaderText = "studentimage";
             imageCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
             imageCol.Width = 100;
             dataGridView1.Columns.Add(imageCol);
             Bitmap MyBitmap;

            foreach (DataRow dr in dt.Rows)
             {

                 dataGridView1.Rows[i].Cells[7].Value=(@"..\..\" + dr["student_image"].ToString());
                 dataGridView1.Rows[i].Height = 100;
                 i = i + 1;
              }*/


        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                dataGridView1.Columns.Clear();
                dataGridView1.Refresh();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from s_info where student_registration_no like('%" + textBox1.Text + "%')";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;

            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                dataGridView1.Columns.Clear();
                dataGridView1.Refresh();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from s_info where student_name like('%" + textBox2.Text + "%')";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;

            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());

            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from s_info where Id=" + i + "";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                regno.Text = row.Cells[1].Value.ToString();
                name.Text = row.Cells[2].Value.ToString();
                nic.Text = row.Cells[4].Value.ToString();
                cont.Text = row.Cells[5].Value.ToString();
                mail.Text = row.Cells[6].Value.ToString();

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            wanted_path = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            result = openFileDialog1.ShowDialog();
            openFileDialog1.Filter = "JPEG Files (*.jpeg)|.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files(*.gif)|*.gif";


        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(result==DialogResult.OK)
            {
                int i;
                i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
                string img_path;
                File.Copy(openFileDialog1.FileName, wanted_path + "\\students_images\\" + pwd + ".jpg");

                img_path = "student_images\\" + pwd + ".jpg";

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update s_info set student_name='" + name.Text + "',student_image='" + img_path.ToString() + "',student_NIC= '" + nic.Text + "',student_Contact='" + cont.Text + "',student_registration_no='" + regno.Text + "',student_Email='" + mail.Text + "' where Id='" + i + "'";
                cmd.ExecuteNonQuery();
                fill_grid();
                MessageBox.Show("successfully updated");
            }


            else if (result == DialogResult.Cancel)
            {
                int i;
                i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
                string img_path;
                

          

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update s_info set student_name='" + name.Text + "',student_NIC= '" + nic.Text + "',student_Contact='" + cont.Text + "',student_registration_no='" + regno.Text + "',student_Email='" + mail.Text + "' where Id='" + i + "'";
                cmd.ExecuteNonQuery();
                fill_grid();
                MessageBox.Show("successfully updated");
            }



            else
            {
                int i;
                i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
                string img_path;




                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update s_info set student_name='" + name.Text + "',student_NIC= '" + nic.Text + "',student_Contact='" + cont.Text + "',student_registration_no='" + regno.Text + "',student_Email='" + mail.Text + "' where Id='" + i + "'";
                cmd.ExecuteNonQuery();
                fill_grid();
                MessageBox.Show("successfully updated");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }

}