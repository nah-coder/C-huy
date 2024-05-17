using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanSach.database
{
    internal class ChiTietBanHang
    {
        Database db;
        public ChiTietBanHang()
        {
            db = new Database();
        }

        public DataTable ThongTinChiTiet(string ngayBan)
        {
            try
            {
                string sql = $"select ctbh.ma_ban_hang, kh.ma_khach_hang, kh.ten_khach_hang,mh.ma_hang,mh.ten_hang,nv.ma_nhan_vien,nv.ho_ten, ctbh.so_luong, ctbh.thanh_tien, bh.ngay_ban from ChiTietBanHang as ctbh " +
                    $"join BanHang as bh on bh.ma_ban_hang = ctbh.ma_ban_hang " +
                    $"join KhachHang as kh on kh.ma_khach_hang = bh.ma_khach_hang " +
                    $"join NhanVien as nv on nv.ma_nhan_vien = bh.ma_nhan_vien " +
                    $"join MatHang as mh on mh.ma_hang = ctbh.ma_hang " +
                    $"where bh.ngay_ban = '{ngayBan}'";
                DataTable dt = db.Execute(sql);
                return dt;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public DataTable DSDoanhThuTheoThang()
        {
            try
            {
                string sql = $"select DAY(bh.ngay_ban) as ngay, SUM(ctbh.thanh_tien) as thanh_tien " +
                    $"from ChiTietBanHang as ctbh " +
                    $"join BanHang as bh on ctbh.ma_ban_hang = bh.ma_ban_hang " +
                    $"where MONTH(bh.ngay_ban) = MONTH(GETDATE()) AND YEAR(bh.ngay_ban) = YEAR(GETDATE()) " +
                    $"GROUP BY DAY(bh.ngay_ban)";
                DataTable dt = db.Execute(sql);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public DataTable DSDoanhThuTheoNam()
        {
            try
            {
                string sql = $"select MONTH(bh.ngay_ban) as thang,  SUM(ctbh.thanh_tien) as thanh_tien " +
                    $"from ChiTietBanHang as ctbh " +
                    $"join BanHang as bh on ctbh.ma_ban_hang = bh.ma_ban_hang " +
                    $"where  YEAR(bh.ngay_ban) = YEAR(GETDATE()) " +
                    $"GROUP BY MONTH(bh.ngay_ban)";
                DataTable dt = db.Execute(sql);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public DataTable DsBanHangTheoMaHang(string maHang)
        {
            try
            {
                string sql = $"select * from ChiTietBanHang where ma_hang = '{maHang}'";
                DataTable dt = db.Execute(sql);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public DataTable DanhSachSachVaSoLuongDaBan()
        {
            try
            {
                string sql = $"select mh.ma_hang, mh.ten_hang, SUM(ctbh.so_luong) as so_luong from ChiTietBanHang as ctbh " +
                    $"join MatHang as mh on ctbh.ma_hang = mh.ma_hang " +
                    $"GROUP BY mh.ten_hang, mh.ma_hang " +
                    $"ORDER BY so_luong DESC";
                DataTable dt = db.Execute(sql);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }

        public DataTable DanhSachSachDuocMuaNhieuNhat()
        {
            try
            {
                string sql = $"select TOP 3 mh.ma_hang, mh.ten_hang, SUM (ctbh.so_luong) as so_luong from ChiTietBanHang as ctbh " +
                    $"join MatHang as mh on mh.ma_hang = ctbh.ma_hang " +
                    $"GROUP BY mh.ten_hang, mh.ma_hang " +
                    $"ORDER BY so_luong DESC";
                DataTable dt = db.Execute(sql);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public bool TaoChiTietBanHang(string maBanHang, string maHang, int soLuong, float thanhTien)
        {
            try
            {
                string sql = $"insert into ChiTietBanHang values('{maBanHang}','{maHang}',{soLuong},{thanhTien})";
                db.ExecuteNonQuery(sql);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public bool XoaChiTietBanHang(string maBanHang)
        {
            try
            {
                string sql = $"delete from ChiTietBanHang where ma_ban_hang = '{maBanHang}'";
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
