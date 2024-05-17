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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace QuanLiBanSach
{
    public partial class frmDangNhap : Form
    {
        private NhanVien nhanVien = new NhanVien();
        private DataTable dtNhanVien = new DataTable();
        private bool check = false;
        public frmDangNhap()
        {
            InitializeComponent();
        }
        private void lblDangKi_Click(object sender, EventArgs e)
        {
            frmDangKi frmDangKi = new frmDangKi();
            frmDangKi.ShowDialog();
        }
        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            dtNhanVien = nhanVien.DsNhanVien();
        }
        private void lblShowPasswword_Click_1(object sender, EventArgs e)
        {
            if (check)
            {
                check = false;
                lblShowPasswword.Image = QuanLiBanSach.Properties.Resources.lock16;
                txtMatKhau.PasswordChar = '*';
            }
            else
            {
                check = true;
                lblShowPasswword.Image = QuanLiBanSach.Properties.Resources.unlockmk;
                txtMatKhau.PasswordChar = '\0';
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            errorDangNhap.Clear();
            string tenDangNhap = txtTenDangNhap.Text;
            string matKhau = txtMatKhau.Text;
            string maNhanVien = "";
            int trangThai = -1;
            bool checkDk = false;
            bool khop = false;

            if (string.IsNullOrEmpty(tenDangNhap))
                errorDangNhap.SetError(txtTenDangNhap, "Vui Lòng Nhập Tên Đăng Nhập");
            else if (string.IsNullOrEmpty(matKhau))
                errorDangNhap.SetError(txtMatKhau, "Vui Lòng Nhập Mật Khẩu");
            else
            {
                for (int i = 0; i < dtNhanVien.Rows.Count; i++)
                {
                    string tdn = dtNhanVien.Rows[i]["ten_dang_nhap"].ToString();
                    string mk = dtNhanVien.Rows[i]["mat_khau"].ToString();
                    if (tdn.Equals(tenDangNhap) && mk.Equals(matKhau))
                    {
                        maNhanVien = dtNhanVien.Rows[i]["ma_nhan_vien"].ToString();
                        trangThai = int.Parse(dtNhanVien.Rows[i]["trang_thai"].ToString());
                        checkDk = true;
                        khop = true; 
                        break; 
                    }
                }

                if (!khop) 
                {
                    errorDangNhap.SetError(txtMatKhau, "Tên Đăng Nhập Hoặc Mật Khẩu Không Đúng!");
                }
                else if (checkDk)
                {
                    if (trangThai == 1)
                    {
                        frmChinh frmChinh = new frmChinh();
                        MessageBox.Show("Đăng Nhập Thành Công");
                        frmChinh.MaNhanVien = maNhanVien;
                        frmChinh.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Bạn Chưa Được Cấp Quyền Đăng Nhập");
                    }
                }
            }
        }
    }
}
