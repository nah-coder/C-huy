using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanSach.database
{
    internal class NhaCungCap
    {
        Database db;
        public NhaCungCap()
        {
            db = new Database();
        }
        public DataTable DsNhaCungCap()
        {
            try
            {
                string sql = "select * from NhaCungCap";
                DataTable dt = db.Execute(sql);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public DataTable ThongTinNhaCungCap(string maNhaCungCap)
        {
            try
            {
                string sql = $"select * from NhaCungCap where ma_nha_cung_cap = '{maNhaCungCap}'";
                DataTable dt = db.Execute(sql);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public bool ThemNhaCungCap(string maNCC, string hoTen, string soDienThoai, string diaChi)
        {
            try
            {
                string sql = $"insert into NhaCungCap values ('{maNCC}',N'{hoTen}','{soDienThoai}',N'{diaChi}')";
                db.ExecuteNonQuery(sql);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
        public bool CapNhatNhaCungCap(string maNCC, string hoTen, string soDienThoai, string diaChi)
        {
            try
            {
                string sql = $"update NhaCungCap set ten_nha_cung_cap = N'{hoTen}', so_dien_thoai = '{soDienThoai}', dia_chi = N'{diaChi}' where ma_nha_cung_cap = '{maNCC}'";
                db.ExecuteNonQuery(sql);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
        public bool XoaNhaCungCap(string maNCC)
        {
            try
            {
                string sql = $"delete from NhaCungCap where ma_nha_cung_cap = '{maNCC}'";
                db.ExecuteNonQuery(sql);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
    }
}
