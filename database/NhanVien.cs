using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanSach.database
{
    internal class NhanVien
    {
        Database db;
        public NhanVien()
        {
            db = new Database();
        }

        public bool TaoTaiKhoan(string maNhanVien, string tenDangNhap, string matKhau, string hoTen, int soDienThoai, string diaChi, int trangThai)
        {
            try
            {
                string sql = $"insert into NhanVien values ('{maNhanVien}','{tenDangNhap}','{matKhau}',N'{hoTen}',{soDienThoai},N'{diaChi}',{trangThai})";
                db.ExecuteNonQuery(sql);
                return true;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
        public bool CapNhatNhanVien(string maNhanVien, string hoTen, int soDienThoai, string diaChi, int trangThai)
        {
            try
            {
                string sql = $"update NhanVien set ho_ten = N'{hoTen}', so_dien_thoai = '{soDienThoai}', dia_chi = N'{diaChi}', trang_thai = {trangThai} where ma_nhan_vien = '{maNhanVien}'";
                db.ExecuteNonQuery (sql);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
        public bool XoaNhanVien(string maNhanVien)
        {
            try
            {
                string sql = $"delete from NhanVien where ma_nhan_vien = '{maNhanVien}'";
                db.ExecuteNonQuery(sql);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
        public bool CheckTenDangNhap(string tenDangNhap)
        {
            try
            {
                string sql = $"select ten_dang_nhap from NhanVien where ten_dang_nhap = '{tenDangNhap}'";
                DataTable dt = db.Execute(sql);
                if(dt.Rows.Count == 0)
                    return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
        public bool ThayDoiMatKhau(string maNhanVien, string matKhau)
        {
            try
            {
                string sql = $"update NhanVien set mat_khau = '{matKhau}' where ma_nhan_vien = '{maNhanVien}'";
                db.ExecuteNonQuery(sql);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
        public DataTable DsNhanVien()
        {
            try
            {
                string sql = "select * from NhanVien";
                DataTable dt = db.Execute(sql);
                return dt;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public DataTable ThongTinNhanVien(string maNhanVien)
        {
            try
            {
                string sql = $"select * from NhanVien where ma_nhan_vien = '{maNhanVien}'";
                DataTable dt = db.Execute(sql);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public DataTable DsNhanVienTheoTruong()
        {
            try
            {
                string sql = "select ma_nhan_vien, ho_ten, so_dien_thoai, dia_chi, trang_thai from NhanVien ORDER BY ma_nhan_vien ASC";
                DataTable dt = db.Execute(sql);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
