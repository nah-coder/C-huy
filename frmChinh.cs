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
    public partial class frmChinh : Form
    {
        private string maNhanVien;
        private Form currentFormChild;
        public string MaNhanVien
        {
            get { return maNhanVien; }
            set { maNhanVien = value; }
        }
        public frmChinh()
        {
            InitializeComponent();
        }
        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            palChinh.Controls.Add(childForm);
            palChinh.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void trangChuMenu_Click(object sender, EventArgs e)
        {
            if (currentFormChild != null)
                currentFormChild.Close();
        }
        public void ReloadForm()
        {
            frmDanhMucNhanVien frm = new frmDanhMucNhanVien(this);
            frm.MaNhanVienSend = maNhanVien;
            OpenChildForm(frm);
        }
        private void nhanVienMenuDanhMuc_Click(object sender, EventArgs e)
        {
            frmDanhMucNhanVien frm = new frmDanhMucNhanVien(this);
            frm.MaNhanVienSend = maNhanVien;
            OpenChildForm(frm);
        }

        private void KhachHangMenuDanhMuc_Click(object sender, EventArgs e)
        {
            frmDanhMucKhachHang frm = new frmDanhMucKhachHang();
            OpenChildForm(frm);
        }

        private void NhaCungCapMenuDanhMuc_Click(object sender, EventArgs e)
        {
            frmDanhMucNhaCungCap frm = new frmDanhMucNhaCungCap();
            OpenChildForm(frm);
        }

        private void phieuNhapMenuNhapHang_Click(object sender, EventArgs e)
        {
            frmPhieuNhapHang frm = new frmPhieuNhapHang();
            frm.MaNhanVien = maNhanVien;
            OpenChildForm(frm);
        }

        private void hoaDonMenuNhapHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmNhapHang());
        }

        private void sáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmDanhMucSach());
        }

        private void LapDonBanHangMenuBanHang_Click(object sender, EventArgs e)
        {
            frmDonDatHang frm = new frmDonDatHang();
            frm.MaNhanVien = maNhanVien;
            OpenChildForm(frm);
        }

        private void hoaDonMenuBanHang_Click(object sender, EventArgs e)
        {
            frmBanHang frm = new frmBanHang();
            OpenChildForm(frm);
        }

        private void thongTinMenuHeThong_Click(object sender, EventArgs e)
        {
            frmThongTin frm = new frmThongTin();
            frm.MaNhanVien = maNhanVien;
            OpenChildForm(frm);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn Có Chắc Chắn Thoát Chương Trình!", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
            maNhanVien = "";
        }

        private void thongKeDoanhThuMenuBaoCao_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmThongKeDoanhThu());
        }

        private void thongKeMatHangMenuBaoCao_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmThongKeMatHangDaban());
        }
    }
}
