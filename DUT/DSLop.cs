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
    public partial class DSLop : Form
    {
        string s = @"Data Source=DESKTOP-SCR68FQ\NHUNGHOANG;Initial Catalog=QLSV;Integrated Security=True";
        public DSLop()
        {
            InitializeComponent();
            getCBB();
        }
        private void cbbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowGRV();
        }

        void getCBB()
        {
            string query = "select distinct LopHP from tbSinhVien";
            SqlConnection  con = new SqlConnection(s);
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable table = new DataTable();
            da.Fill(table);
            foreach (DataRow row in table.Rows)
            {
                cbbLop.Items.Add(row["LopHP"].ToString());
            }
            cbbLop.Items.Add("All");
        }
        public void ShowGRV()
        {
            if (cbbLop.Text == "All")
            {
                string query = "select * from tbSinhVien";
                grv_data.DataSource = DBHelper.Instance.GetRecords(query);
                
            }
            else
            {
                string query = string.Format("select * from tbSinhVien where LopHP ='{0}'", cbbLop.SelectedItem.ToString());
                grv_data.DataSource = DBHelper.Instance.GetRecords(query);
            }
        }
        private void DSLop_Load(object sender, EventArgs e)
        {

        }


        private void btAdd_Click(object sender, EventArgs e)
        {
            TTSinhVien formtt = new TTSinhVien();
            formtt.Show();
            formtt.d += new TTSinhVien.MyDel(ShowGRV);
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            TTSinhVien formtt = new TTSinhVien();
            formtt.Show();
            formtt.d += new TTSinhVien.MyDel(ShowGRV);
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            if (grv_data.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in grv_data.SelectedRows)
                {
                    string MSSV = row.Cells[1].Value.ToString(); // mã số của dòng được click vào trong datagridview
                    string query = "Delete from tbSinhVien Where MSSV = '" + MSSV + "'";
                    DBHelper.Instance.ExecuteDBs(query);
                }
            }
            // show datagridview
            ShowGRV();

        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            string query = "select * from tbSinhVien where STT= '"+ txtSTT.Text + "'";
            grv_data.DataSource = DBHelper.Instance.GetRecords(query);
           
        }
    }
}
