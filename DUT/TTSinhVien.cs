using System;
using System.Collections;
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
    public partial class TTSinhVien : Form
    {
        //string s = @"Data Source=DESKTOP-SCR68FQ\NHUNGHOANG;Initial Catalog=QLSV;Integrated Security=True;";
        public delegate void MyDel();
        public MyDel d { get; set; }

        public TTSinhVien()
        {
            InitializeComponent();

        }
        
        
        public void cn()
        {
          
            string query = "INSERT INTO tbSinhVien (MSSV, Name, LopHP, DTB, DiaChi) VALUES "
                    + "('" + txtMSSV.Text + "', '" + txtName.Text + "', '" + txtLop.Text
                    + "', '" + txtDTB.Text + "', '" + txtDiaChi.Text + "')";
            DBHelper.Instance.ExecuteDBs(query);
            
        }
        private void txtOK_Click(object sender, EventArgs e)
        {
            cn();
            d();
            this.Close();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
