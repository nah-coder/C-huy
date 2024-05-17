using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanSach.database
{
    internal class BanHang
    {
        Database db;
        public BanHang()
        {
            db = new Database();
        }

        public DataTable DSBanHangGop()
        {
            try
            {
                string sql = $"select kh.ten_khach_hang,bh.ngay_ban from BanHang as bh " +
                    $"join KhachHang as kh on bh.ma_khach_hang = kh.ma_khach_hang " +
                    $"GROUP BY bh.ngay_ban, kh.ten_khach_hang";
                DataTable dt = db.Execute(sql);
                return dt;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public DataTable DsMaBanHangTheoMaKhachHang(string maKhachHang)
        {
            try
            {
                string sql = $"select ma_ban_hang from BanHang where ma_khach_hang = '{maKhachHang}'";
                DataTable dt = db.Execute(sql);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public bool TaoBanHang(string maBanHang, string maKhachHang, string maNhanVien, string ngayBan)
        {
            try
            {
                string sql = $"insert into BanHang values('{maBanHang}','{maKhachHang}','{maNhanVien}','{ngayBan}')";
                db.ExecuteNonQuery(sql);
                return true;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public bool XoaBanHang(string maBanHang)
        {
            try
            {
                string sql = $"delete from BanHang where ma_ban_hang = '{maBanHang}'";
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
