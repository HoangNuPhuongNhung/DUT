using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUT
{
    internal class DBHelper
    {
        private static DBHelper _Instance;
        private SqlConnection con;

        private DBHelper(string s)
        {
            con = new SqlConnection(s);
        }
        public static DBHelper Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DBHelper(@"Data Source=DESKTOP-SCR68FQ\NHUNGHOANG;Initial Catalog=QLSV;Integrated Security=True");
                }
                return _Instance;
            }
            private set { }
        }
        public DataTable GetRecords(string query)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            con.Open();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public void ExecuteDBs(string query)
        {
            SqlCommand cmd = new SqlCommand(query,con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
//hahahihi
