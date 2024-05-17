using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanSach.database
{
    internal class KhachHang
    {
        Database db;
        public KhachHang()
        {
            db = new Database();
        }

        public DataTable DsKhachHang()
        {
            try
            {
                string sql = "select * from KhachHang";
                DataTable dt = db.Execute(sql);
                return dt;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public bool ThemKhachHang(string maKhachHang,  string hoTen, string soDienThoai, string diaChi)
        {
            try
            {
                string sql = $"insert into KhachHang values ('{maKhachHang}',N'{hoTen}','{soDienThoai}',N'{diaChi}')";
                db.ExecuteNonQuery(sql);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
        public bool CapNhatKhachHang(string maKhachHang, string hoTen, string soDienThoai, string diaChi)
        {
            try
            {
                string sql = $"update KhachHang set ten_khach_hang = N'{hoTen}', so_dien_thoai = '{soDienThoai}', dia_chi = N'{diaChi}' where ma_khach_hang = '{maKhachHang}'";
                db.ExecuteNonQuery(sql);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
        public bool XoaNhanVien(string maKhachHang)
        {
            try
            {
                string sql = $"delete from KhachHang where ma_khach_hang = '{maKhachHang}'";
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
