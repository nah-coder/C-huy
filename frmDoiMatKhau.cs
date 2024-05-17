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
    public partial class frmDoiMatKhau : Form
    {
        private NhanVien nhanVien = new NhanVien();
        private string matKhauHienTai;
        private bool showHienMkHienTai = false;
        private bool showHienMkMoi = false;
        private bool showHienMkNhapLai = false;
        private string maNhanVien;
        public string MaNhanVien
        {
            get { return maNhanVien; }
            set { maNhanVien = value; }
        }
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            DataTable dtTT = nhanVien.ThongTinNhanVien(maNhanVien);
            matKhauHienTai = dtTT.Rows[0]["mat_khau"].ToString();
        }
        private void btnXacNhanLayLaiMK_Click(object sender, EventArgs e)
        {
            errCheck.Clear();
            bool ketQua = false;
            if (txtMKHienTai.Text == "")
                errCheck.SetError(palMkHienTai, "Vui Lòng Nhập Trường Này!");
            else if (!txtMKHienTai.Text.Equals(matKhauHienTai))
                errCheck.SetError(palMkHienTai, "Mật Khẩu Không Đúng!");
            else if (txtMatKhauMoi.Text == "")
                errCheck.SetError(palMkMoi, "Vui Lòng Nhập Trường Này!");
            else if (txtMKNhapLai.Text == "")
                errCheck.SetError(palMkMoiNhapLai, "Vui Lòng Nhập Trường Này!");
            else if (!txtMKNhapLai.Text.Equals(txtMatKhauMoi.Text))
                errCheck.SetError(palMkMoiNhapLai, "Mật Khẩu Nhập Lại Không Đúng!");
            else
            {
                DialogResult result = MessageBox.Show("Bạn Có Chắc Chắn Thay Đổi Mật Khẩu Không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    string mkMoi = txtMatKhauMoi.Text;
                    ketQua = nhanVien.ThayDoiMatKhau(maNhanVien,mkMoi);
                    if (ketQua)
                    {
                        MessageBox.Show("Thay Đổi Mật Khẩu Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
        }
        private void lblShowPasswwordMoi_Click(object sender, EventArgs e)
        {
            if (showHienMkMoi)
            {
                showHienMkMoi = false;
                lblShowPasswwordMoi.Image = QuanLiBanSach.Properties.Resources.lock16;
                txtMatKhauMoi.PasswordChar = '*';
            }
            else
            {
                showHienMkMoi = true;
                lblShowPasswwordMoi.Image = QuanLiBanSach.Properties.Resources.unlockmk;
                txtMatKhauMoi.PasswordChar = '\0';
            }
        }

        private void lblShowPassNhapLai_Click(object sender, EventArgs e)
        {
            if (showHienMkNhapLai)
            {
                showHienMkNhapLai = false;
                lblShowPassNhapLai.Image = QuanLiBanSach.Properties.Resources.lock16;
                txtMKNhapLai.PasswordChar = '*';
            }
            else
            {
                showHienMkNhapLai = true;
                lblShowPassNhapLai.Image = QuanLiBanSach.Properties.Resources.unlockmk;
                txtMKNhapLai.PasswordChar = '\0';
            }
        }

        private void lblShowMkHienTai_Click(object sender, EventArgs e)
        {
            if (showHienMkHienTai)
            {
                showHienMkHienTai = false;
                lblShowMkHienTai.Image = QuanLiBanSach.Properties.Resources.lock16;
                txtMKHienTai.PasswordChar = '*';
            }
            else
            {
                showHienMkHienTai = true;
                lblShowMkHienTai.Image = QuanLiBanSach.Properties.Resources.unlockmk;
                txtMKHienTai.PasswordChar = '\0';
            }
        }
    }
}
