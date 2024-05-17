using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiBanSach.database
{
    public class Database
    {
        SqlConnection conn;
        SqlDataAdapter data;
        DataSet dataSet;
        public Database()
        {
            try
            {
                string srtCnn = @"Data Source=.;Initial Catalog=QLBanSach;Integrated Security=True;TrustServerCertificate=True";
                conn = new SqlConnection(srtCnn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public DataTable Execute(string sql)
        {
            try
            {

                data = new SqlDataAdapter(sql, conn);
                dataSet = new DataSet();
                data.Fill(dataSet);
                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Lỗi Vì Không Có CSDL!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return null;

        }
        public void ExecuteNonQuery(string sql)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand(sql, conn);
                conn.Open();
                sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [Obsolete]
        public void ExecuteNonQueryImg(string sql, byte[] anh)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                cmd.Parameters.Add("@anh", anh);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
