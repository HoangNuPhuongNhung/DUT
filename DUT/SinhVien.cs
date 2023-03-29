using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DUT
{
    public partial class SinhVien : Form
    {
        string s = @"Data Source=DESKTOP-SCR68FQ\NHUNGHOANG;Initial Catalog=QLSV;Integrated Security=True";
        public SinhVien()
        {
            InitializeComponent();
        }

        public void Show()
        {
            SqlConnection con = new SqlConnection(s);
            string query = " select * from tbSinhVien ";

            con.Open();

            SqlDataAdapter da = new SqlDataAdapter(query, con);//sử dụng sqldatadapter để chuyển đổi dữ liệu từ lệnh query trả về
            DataTable table = new DataTable();
            da.Fill(table);//dùng Fill để đổ dữ liệu từ adapter vào datatable
            dataGridView1.DataSource = table;

            con.Close();
        }
        private void btShow_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(s);
            string query = " select * from tbSinhVien ";
            
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable table = new DataTable();
            
            da.Fill(table);
            dataGridView1.DataSource = table;

            con.Close();
        }
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtSTT.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtSTT.Enabled = false;
            txtMSSV.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtName.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtLop.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtDTB.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            txtDiaChi.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();

        }
        

        private void btAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(s);
            string query = "insert into tbSinhVien values ( @MSSV, @Name, @LopHP, @DTB, @DiaChi) ";

            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);//là đoạn khai báo một lệnh SQL
            cmd.Parameters.AddWithValue("@MSSV", int.Parse(txtMSSV.Text));
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@LopHP", txtLop.Text);
            cmd.Parameters.AddWithValue("@DTB",  int.Parse(txtDTB.Text));
            cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
            cmd.ExecuteNonQuery();
            Show();

            con.Close();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            string query = "update tbSinhVien set MSSV=@MSSV, Name=@Name, LopHP=@LopHP, DTB=@DTB, DiaChi=@DiaCHi where STT=@STT";
            SqlConnection con = new SqlConnection(s);

            con.Open();
            SqlCommand cmd = new SqlCommand(query,con);
            cmd.Parameters.AddWithValue("@STT", int.Parse(txtSTT.Text));
            cmd.Parameters.AddWithValue("@MSSV", int.Parse(txtMSSV.Text));
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@LopHP", txtLop.Text);
            cmd.Parameters.AddWithValue("@DTB", int.Parse(txtDTB.Text));
            cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
            cmd.ExecuteNonQuery();
            Show();
            con.Close();
            txtSTT.Enabled = true;
            txtSTT.Text = null;
            txtMSSV.Text = null;
            txtName.Text = null;
            txtLop.Text = null;
            txtDTB.Text = null;
            txtDiaChi.Text = null;
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            string query = "Delete tbSinhVien Where STT=@STT";
            SqlConnection con = new SqlConnection(s);

            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@STT", int.Parse(txtSTT.Text));
            cmd.ExecuteNonQuery();
            Show();
            con.Close();
            txtSTT.Enabled = true;
            txtSTT.Text = null;
            txtMSSV.Text = null;
            txtName.Text = null;
            txtLop.Text = null;
            txtDTB.Text = null;
            txtDiaChi.Text = null;
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            string query = "select * from tbSinhVien where STT=@STT";
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlCommand cmd = new SqlCommand(query,con);
            cmd.Parameters.AddWithValue("@STT", int.Parse(txtSTT.Text));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

    }
}
