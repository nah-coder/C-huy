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
    public partial class frmDanhMucKhachHang : Form
    {
        private KhachHang khachHang = new KhachHang();
        private DataTable dtKhachHang = new DataTable();
        private BanHang banHang = new BanHang();
        private ChiTietBanHang chiTietBanHang = new ChiTietBanHang();
        private string maKhachHang = "";
        public frmDanhMucKhachHang()
        {
            InitializeComponent();
        }

        private void frmDanhMucKhachHang_Load(object sender, EventArgs e)
        {
            IDAuto id = new IDAuto();
            maKhachHang = id.LayIdTuDong("KhachHang", "KH");
            lblMaKhachHang.Text = maKhachHang;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            LoadDataKhachHang();
        }

        public void LoadDataKhachHang()
        {
            IDAuto id = new IDAuto();
            maKhachHang = id.LayIdTuDong("KhachHang", "KH");
            lblMaKhachHang.Text = maKhachHang;
            dtKhachHang = khachHang.DsKhachHang();
            if (dtKhachHang != null)
                dgvKhachHang.DataSource = dtKhachHang; 
            dgvKhachHang.Columns[0].HeaderText = "Mã khách";
            dgvKhachHang.Columns[1].HeaderText = "Tên khách";
            dgvKhachHang.Columns[2].HeaderText = "Địa chỉ";
            dgvKhachHang.Columns[3].HeaderText = "Điện thoại";
            dgvKhachHang.AllowUserToAddRows = false;
            dgvKhachHang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgvKhachHang_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHoTen.Focus();
                return;
            }
            if (dtKhachHang.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            lblMaKhachHang.Text = dgvKhachHang.CurrentRow.Cells[0].Value.ToString();
            txtHoTen.Text = dgvKhachHang.CurrentRow.Cells[1].Value.ToString();
            txtQueQuan.Text = dgvKhachHang.CurrentRow.Cells[2].Value.ToString();
            txtSdt.Text = dgvKhachHang.CurrentRow.Cells[3].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
        }
        private void ResetValues()
        {
            lblMaKhachHang.Text = maKhachHang;
            txtHoTen.Text = "";
            txtQueQuan.Text = "";
            txtSdt.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtHoTen.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dtKhachHang.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtHoTen.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            errKhachHang.Clear();
            bool ketQua;
            string hoTen = txtHoTen.Text;
            string sdt = txtSdt.Text;
            string diachi = txtQueQuan.Text;

            if (hoTen == "")
                errKhachHang.SetError(palHoTen, "Vui Lòng Nhập Họ Tên");
            else if (sdt == "")
                errKhachHang.SetError(palSdt, "Vui Lòng Nhập Số Điện Thoại");
            else if (diachi == "")
                errKhachHang.SetError(palQueQuan, "Vui Lòng Nhập Địa Chỉ");
            else
            {
                ketQua = khachHang.CapNhatKhachHang(lblMaKhachHang.Text, hoTen, sdt, diachi);
                if (ketQua)
                {
                    MessageBox.Show("Cập Nhật Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataKhachHang();
                }
                else
                {
                    MessageBox.Show("Cập Nhật Thất Bại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                ResetValues();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dtKhachHang.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (lblMaKhachHang.Text.Equals(maKhachHang))
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataTable dtMaBanHangTheoMaKh = banHang.DsMaBanHangTheoMaKhachHang(lblMaKhachHang.Text);
                if (dtMaBanHangTheoMaKh != null && dtMaBanHangTheoMaKh.Rows.Count > 0)
                {
                    foreach (DataRow row in dtMaBanHangTheoMaKh.Rows)
                    {
                        string maBanHang = row["ma_ban_hang"].ToString();
                        chiTietBanHang.XoaChiTietBanHang(maBanHang);
                        banHang.XoaBanHang(maBanHang);
                    }
                }
                    
                bool ketQua = khachHang.XoaNhanVien(lblMaKhachHang.Text);
                if (ketQua)
                {
                    MessageBox.Show("Xóa Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataKhachHang();
                }
                else
                {
                    MessageBox.Show("Xóa Thất Bại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                ResetValues();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            errKhachHang.Clear();
            bool ketQua;
            string hoTen = txtHoTen.Text;
            string sdt = txtSdt.Text;
            string diachi = txtQueQuan.Text;

            if (hoTen == "")
                errKhachHang.SetError(palHoTen, "Vui Lòng Nhập Họ Tên");
            else if (sdt == "")
                errKhachHang.SetError(palSdt, "Vui Lòng Nhập Số Điện Thoại");
            else if (diachi == "")
                errKhachHang.SetError(palQueQuan, "Vui Lòng Nhập Địa Chỉ");
            else
            {
                ketQua = khachHang.ThemKhachHang(lblMaKhachHang.Text, hoTen, sdt, diachi);
                if (ketQua)
                {
                    MessageBox.Show("Thêm Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataKhachHang();
                }
                else
                {
                    MessageBox.Show("Thêm Thất Bại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                ResetValues();
                btnXoa.Enabled = true;
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnBoQua.Enabled = false;
                btnLuu.Enabled = false;
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoQua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
