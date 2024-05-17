using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanSach.database
{
    internal class NhapHang
    {
        Database db;
        public NhapHang()
        {
            db = new Database();
        }
        public DataTable DsMaNhapHangTheoNcc(string maNhaCungCap)
        {
            try
            {
                string sql = $"select ctnh.ma_hang, nh.ma_nhap_hang from NhapHang as nh " +
                    $"join ChiTietNhapHang as ctnh on ctnh.ma_nhap_hang = nh.ma_nhap_hang " +
                    $"where nh.ma_nha_cung_cap = '{maNhaCungCap}'";
                DataTable dt = db.Execute(sql);
                return dt;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public DataTable DsMaNhapHangTheoMaNhanVien(string maNhanVien)
        {
            try
            {
                string sql = $"select ctnh.ma_hang, nh.ma_nhap_hang from NhapHang as nh " +
                    $"join ChiTietNhapHang as ctnh on ctnh.ma_nhap_hang = nh.ma_nhap_hang " +
                    $"where nh.ma_nhan_vien = '{maNhanVien}'";
                DataTable dt = db.Execute(sql);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public bool TaoNhapHang(string maNhapHang, string maNCC, string maNhanVien, string ngayLap)
        {
            try
            {
                string sql = $"insert into Nhaphang values ('{maNhapHang}','{maNCC}','{maNhanVien}','{ngayLap}')";
                db.ExecuteNonQuery(sql);
                return true;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
        public bool XoaNhapHang(string maNhapHang)
        {
            try
            {
                string sql = $"delete from NhapHang where ma_nhap_hang = '{maNhapHang}'";
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
