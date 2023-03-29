using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUT
{
    public  class cla_crud
    {
        //string s = @"Data Source=DESKTOP-SCR68FQ\NHUNGHOANG;Initial Catalog=QLSV;Integrated Security=True";
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-SCR68FQ\NHUNGHOANG;Initial Catalog=QLSV;Integrated Security=True");
        public DataTable readdata(string cmd)// hàm đọc dữ liệu
        {
            con.Open();
            DataTable da = new DataTable();
            try
            {
                SqlCommand sc = new SqlCommand(cmd, con);// khai báo 1 lênh SQL
                SqlDataAdapter sda = new SqlDataAdapter(sc);//để chuyển đổi dữ liệu từ lệnh cmd trả về
                sda.Fill(da);
            }
            catch (Exception)
            {
                da = null;
            }
            con.Close();
            return da;
        }
        public Boolean exedata(string cmd)// kiểm tra hàm chạy được hoạc không
        {
            con.Open();
            Boolean check = false;
            try
            {
                SqlCommand sc = new SqlCommand(cmd, con);
                sc.ExecuteNonQuery();
                check = true;
            }
            catch (Exception)
            {
                check = false;
            }
            con.Close ();
            return check;
        }

    }
}
