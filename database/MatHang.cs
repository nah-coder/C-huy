using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanSach.database
{
    internal class MatHang
    {
        Database db;
        public MatHang()
        {
            db = new Database();
        }
        public bool TaoMatHang(string maHang, string tenHang)
        {
            try
            {
                string sql = $"insert into MatHang values ('{maHang}',N'{tenHang}',NULL,NULL,NULL)";
                db.ExecuteNonQuery(sql);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public DataTable DsMatHang()
        {
            try
            {
                string sql = $"select * from MatHang";
                DataTable dt = db.Execute(sql);
                return dt;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public DataTable ThongTinMatHang(string maHang)
        {
            try
            {
                string sql = $"select * from MatHang where ma_hang = '{maHang}'";
                DataTable dt = db.Execute(sql);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public DataTable MatHangTrongCuaHang()
        {
            try
            {
                string sql = $"select * from MatHang where so_luong_ban IS NOT NULL";
                DataTable dt = db.Execute(sql);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        
        public bool DuaMatHangLenCuaHang(string maHang, float giaBan, int soLuong)
        {
            try
            {
                string sql = $"update MatHang set gia_ban = {giaBan}, so_luong_ban = ISNULL(so_luong_ban,0) + {soLuong} where ma_hang = '{maHang}'";
                db.ExecuteNonQuery(sql);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public bool CapNhatSoLuongMatHangKhiKHMua(string maHang, int soLuong)
        {
            try
            {
                string sql = $"update MatHang set so_luong_ban = {soLuong} where ma_hang = '{maHang}'";
                db.ExecuteNonQuery(sql);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public bool CapNhatMatHanng(string maHang, float giaBan, int soLuong)
        {
            try
            {
                string sql = $"update MatHang set gia_ban = {giaBan}, so_luong_ban = {soLuong} where ma_hang = '{maHang}'";
                db.ExecuteNonQuery(sql);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public bool XoaMatHangTrongCuaHang(string maHang)
        {
            try
            {
                string sql = $"update MatHang set so_luong_ban = NULL, anh = NULL, gia_ban = NULL where ma_hang = '{maHang}'";
                db.ExecuteNonQuery(sql);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
        public bool XoaMatHang(string maHang)
        {
            try
            {
                string sql = $"delete from MatHang where ma_hang = '{maHang}'";
                db.ExecuteNonQuery(sql);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        [Obsolete]
        public void LuuAnhSach(string maHang, byte[] anh)
        {
            try
            {
                string sql = $"update MatHang set anh =@anh where ma_hang = '{maHang}'";
                db.ExecuteNonQueryImg(sql, anh);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
