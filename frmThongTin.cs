using QuanLiBanSach.database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiBanSach
{
    public partial class frmThongTin : Form
    {
        private DataTable dtThongTinNhanVien = new DataTable();
        private NhanVien nhanVien = new NhanVien();
        private string maNhanVien;
        public string MaNhanVien
        {
            get { return maNhanVien; }
            set { maNhanVien = value; }
        }
        public frmThongTin()
        {
            InitializeComponent();
        }

        private void frmThongTin_Load(object sender, EventArgs e)
        {
            if (maNhanVien.Equals("NV001"))
            {
                txtDiaChi.Enabled = false;
                txtSoDienThoai.Enabled = false;
                txtHoTen.Enabled  = false;
                btnCapNhatThongTin.Enabled = false;
            }
            LoadThongTin();
        }

        public void LoadThongTin()
        {
            dtThongTinNhanVien = nhanVien.ThongTinNhanVien(maNhanVien);
            if (dtThongTinNhanVien != null && dtThongTinNhanVien.Rows.Count > 0)
            {
                string maNhanVien1 = dtThongTinNhanVien.Rows[0]["ma_nhan_vien"].ToString();
                string tenDangNhap = dtThongTinNhanVien.Rows[0]["ten_dang_nhap"].ToString();
                string hoTen = dtThongTinNhanVien.Rows[0]["ho_ten"].ToString();
                string diaChi = dtThongTinNhanVien.Rows[0]["dia_chi"].ToString();
                string soDienTHoai = dtThongTinNhanVien.Rows[0]["so_dien_thoai"].ToString();
                lblMaNhanVien.Text = maNhanVien1;
                txtHoTen.Text = hoTen;
                txtDiaChi.Text = diaChi;
                txtSoDienThoai.Text = soDienTHoai;
                lblTenDangNhap.Text = tenDangNhap;
            }
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau frm = new frmDoiMatKhau();
            frm.MaNhanVien = maNhanVien;
            frm.ShowDialog();
        }

        private void btnCapNhatThongTin_Click(object sender, EventArgs e)
        {
            errHeThong.Clear();
            string hoTen = txtHoTen.Text;
            int soDienThoai;
            string diaChi = txtDiaChi.Text;
            if (!int.TryParse(txtSoDienThoai.Text, out soDienThoai))
                errHeThong.SetError(palSoDienThoai, "Vui Lòng Nhập Đúng Dữ Liệu");
            else
            {
                bool ketQua = false;
                DialogResult result = MessageBox.Show("Bạn Có Chắc Chắn Muốn Thay Đổi Thông Tin Không", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    ketQua = nhanVien.CapNhatNhanVien(maNhanVien,hoTen,soDienThoai,diaChi,1);
                }
                if (ketQua)
                {
                    MessageBox.Show("Thay Đổi Thông Tin Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }
    }
}
