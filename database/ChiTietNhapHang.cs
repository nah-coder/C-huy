using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanSach.database
{
    internal class ChiTietNhapHang
    {
        Database db;
        public ChiTietNhapHang()
        {
            db = new Database();
        }

        public DataTable DsNhapHangGop()
        {
            try
            {
                string sql = $"select nv.ho_ten,nh.ngay_nhap from ChiTietNhapHang as ctnh " +
                    $"join NhapHang as nh on ctnh.ma_nhap_hang = nh.ma_nhap_hang " +
                    $"join NhanVien as nv on nv.ma_nhan_vien = nh.ma_nhan_vien " +
                    $"GROUP BY nh.ngay_nhap, nv.ho_ten";
                DataTable dt = db.Execute(sql);
                return dt;
            }catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public DataTable ThongTinChiTietDonHang(string ngayNhap)
        {
            try
            {
                string sql = $"select nh.ma_nhap_hang,mh.ma_hang,mh.ten_hang,nv.ma_nhan_vien,nv.ho_ten,ncc.ma_nha_cung_cap,ncc.ten_nha_cung_cap,nh.ngay_nhap,ctnh.so_luong,ctnh.gia_nhap,nh.ngay_nhap " +
                    $"from ChiTietNhapHang as ctnh " +
                    $"join NhapHang as nh on ctnh.ma_nhap_hang = nh.ma_nhap_hang " +
                    $"join MatHang as mh on mh.ma_hang = ctnh.ma_hang " +
                    $"join NhanVien as nv on nh.ma_nhan_vien = nv.ma_nhan_vien " +
                    $"join NhaCungCap as ncc on ncc.ma_nha_cung_cap = nh.ma_nha_cung_cap " +
                    $"where nh.ngay_nhap = '{ngayNhap}'";
                DataTable dt = db.Execute(sql);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public bool TaoChiTietNhapHang(string maNhapHang, string maHang, int soLuong, float giaNhap)
        {
            try
            {
                string sql = $"insert into ChiTietNhaphang values ('{maNhapHang}','{maHang}',{soLuong},{giaNhap})";
                db.ExecuteNonQuery(sql);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
        public bool XoaCHiTietNhapHang(string maNhapHang)
        {
            try
            {
                string sql = $"delete from ChiTietNhapHang where ma_nhap_hang = '{maNhapHang}'";
                db.ExecuteNonQuery(sql);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
        public bool CapNhatLaiSoLuongKho(string maHang, int giaTri)
        {
            try
            {
                string sql = $"update ChiTietNhapHang set so_luong = {giaTri} where ma_hang = '{maHang}'";
                db.ExecuteNonQuery(sql);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
        public void CapNhatLaiSoLuongKhoKhiThayDoiSoLuongTrongCuaHang(string maHang, int giaTri)
        {
            try
            {
                string sql = $"update ChiTietNhapHang set so_luong = so_luong + {giaTri} where ma_hang = '{maHang}'";
                db.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public int SoLuongMatHangTrongKho(string maHang)
        {
            try
            {
                string sql = $"select so_luong from ChiTietNhapHang where ma_hang = '{maHang}'";
                DataTable dt = db.Execute(sql);
                if (dt.Rows[0]["so_luong"].ToString() != "")
                    return int.Parse(dt.Rows[0]["so_luong"].ToString());
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return 0;
        }
    }
}
