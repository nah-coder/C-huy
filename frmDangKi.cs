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
    public partial class frmDangKi : Form
    {
        private bool check = false;
        private bool check1 = false;
        private DataTable dtNhanVien = new DataTable();
        private NhanVien nhanVien = new NhanVien();
        public frmDangKi()
        {
            InitializeComponent();
        }
        private void frmDangKi_Load(object sender, EventArgs e)
        {
            dtNhanVien = nhanVien.DsNhanVien();
        }
        private void lblShowPass1_Click(object sender, EventArgs e)
        {
            if (check)
            {
                check = false;
                lblShowPass1.Image = QuanLiBanSach.Properties.Resources.lock16;
                txtMKDK.PasswordChar = '*';
            }
            else
            {
                check = true;
                lblShowPass1.Image = QuanLiBanSach.Properties.Resources.unlockmk;
                txtMKDK.PasswordChar = '\0';
            }
        }

        private void lblShowPass2_Click(object sender, EventArgs e)
        {
            if (check1)
            {
                check1 = false;
                lblShowPass2.Image = QuanLiBanSach.Properties.Resources.lock16;
                txtMKDKINhapLai.PasswordChar = '*';
            }
            else
            {
                check1 = true;
                lblShowPass2.Image = QuanLiBanSach.Properties.Resources.unlockmk;
                txtMKDKINhapLai.PasswordChar = '\0';
            }
        }

        private void btnDangKi_Click(object sender, EventArgs e)
        {
            errDangKi.Clear();
            IDAuto id = new IDAuto();
            string maNhanVien;
            bool ketQua;
            string hoTen = txtHoTen.Text;
            string sdt = txtSdt.Text;
            string diachi = txtQueQuan.Text;
            string tendangnhap = txtTenDangNhap.Text;
            string matkhau = txtMKDK.Text;
            string mknhaplai = txtMKDKINhapLai.Text;
            int checkTenDangNhap = 0;

            int _sdt;
            if (hoTen == "")
                errDangKi.SetError(palHoTen, "Vui Lòng Nhập Họ Tên");
            else if (sdt == "")
                errDangKi.SetError(palSdt, "Vui Lòng Nhập Số Điện Thoại");
            else if (!int.TryParse(txtSdt.Text, out _sdt))
                errDangKi.SetError(palSdt, "Bạn Hãy Nhập Đúng Đinh Dạng!");
            else if (diachi == "")
                errDangKi.SetError(palQueQuan, "Vui Lòng Nhập Địa Chỉ");
            else if (tendangnhap == "")
                errDangKi.SetError(palTenDangNhap, "Vui Lòng Nhập Tên Đăng Nhập");
            else if (matkhau == "")
                errDangKi.SetError(palMatKhau, "Vui Lòng Nhập Mật Khẩu");
            else if (mknhaplai == "")
                errDangKi.SetError(palNhapLai, "Vui Lòng Nhập Lại Mật Khẩu");
            else if (!mknhaplai.Equals(matkhau))
                errDangKi.SetError(palNhapLai, "Mật Khẩu Nhập Lại Không Khớp!");
            else if (mknhaplai.Equals(matkhau))
            {
                for(int i = 0; i<dtNhanVien.Rows.Count; i++)
                {
                    string tenDangNhapHt = dtNhanVien.Rows[i]["ten_dang_nhap"].ToString();
                    if (tenDangNhapHt.Equals(tendangnhap))
                        checkTenDangNhap++;
                }
                if(checkTenDangNhap == 0)
                {
                    DialogResult result = MessageBox.Show("Bạn Có Chắc Chắn Muốn Đăng Kí Tài Khoản Không!", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        maNhanVien = id.LayIdTuDong("NhanVien", "NV");
                        ketQua = nhanVien.TaoTaiKhoan(maNhanVien, tendangnhap, matkhau, hoTen, _sdt, diachi,0);
                        if (ketQua)
                        {
                            MessageBox.Show("Bạn Đã Đăng Kí Tài Khoản Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Tên Đăng Nhập Đã Có Trong Hệ Thống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        
    }
}
