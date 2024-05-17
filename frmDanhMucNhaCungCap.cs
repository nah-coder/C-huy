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
    public partial class frmDanhMucNhaCungCap : Form
    {
        private NhaCungCap nhaCungCap = new NhaCungCap();
        private NhapHang nhapHang = new NhapHang();
        private ChiTietNhapHang chiTietNhapHang = new ChiTietNhapHang();
        private ChiTietBanHang chiTietBanHang = new ChiTietBanHang();
        private BanHang banHang = new BanHang();
        private MatHang matHang = new MatHang();
        private DataTable dtNhaCungCap = new DataTable();
        private string maNhaCungCap;
        public frmDanhMucNhaCungCap()
        {
            InitializeComponent();
        }

        private void frmDanhMucNhaCungCap_Load(object sender, EventArgs e)
        {
            IDAuto id = new IDAuto();
            maNhaCungCap = id.LayIdTuDong("NhaCungCap", "NCC");
            lblMa.Text = maNhaCungCap;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            LoadDataNhaCungCap();
        }

        private void LoadDataNhaCungCap()
        {
            IDAuto id = new IDAuto();
            maNhaCungCap = id.LayIdTuDong("NhaCungCap", "NCC");
            lblMa.Text = maNhaCungCap;
            dtNhaCungCap = nhaCungCap.DsNhaCungCap();
            if (dtNhaCungCap != null)
                dgvNhaCungCap.DataSource = dtNhaCungCap;
            dgvNhaCungCap.Columns[0].HeaderText = "Mã NCC";
            dgvNhaCungCap.Columns[1].HeaderText = "Tên NCC";
            dgvNhaCungCap.Columns[2].HeaderText = "Địa chỉ";
            dgvNhaCungCap.Columns[3].HeaderText = "Điện thoại";
            dgvNhaCungCap.AllowUserToAddRows = false;
            dgvNhaCungCap.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgvNhaCungCap_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHoTen.Focus();
                return;
            }
            if (dtNhaCungCap.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            lblMa.Text = dgvNhaCungCap.CurrentRow.Cells[0].Value.ToString();
            txtHoTen.Text = dgvNhaCungCap.CurrentRow.Cells[1].Value.ToString();
            txtQueQuan.Text = dgvNhaCungCap.CurrentRow.Cells[2].Value.ToString();
            txtSdt.Text = dgvNhaCungCap.CurrentRow.Cells[3].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
        }
        private void ResetValues()
        {
            lblMa.Text = maNhaCungCap;
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
            if (dtNhaCungCap.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtHoTen.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            errNhaCungCap.Clear();
            bool ketQua;
            string hoTen = txtHoTen.Text;
            string sdt = txtSdt.Text;
            string diachi = txtQueQuan.Text;

            if (hoTen == "")
                errNhaCungCap.SetError(palHoTen, "Vui Lòng Nhập Họ Tên");
            else if (sdt == "")
                errNhaCungCap.SetError(palSdt, "Vui Lòng Nhập Số Điện Thoại");
            else if (diachi == "")
                errNhaCungCap.SetError(palQueQuan, "Vui Lòng Nhập Địa Chỉ");
            else
            {
                ketQua = nhaCungCap.CapNhatNhaCungCap(lblMa.Text, hoTen, sdt, diachi);
                if (ketQua)
                {
                    MessageBox.Show("Cập Nhật Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataNhaCungCap();
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
            if (dtNhaCungCap.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (lblMa.Text.Equals(maNhaCungCap))
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataTable dtMaNhAndMaHang = nhapHang.DsMaNhapHangTheoNcc(lblMa.Text);
                if(dtMaNhAndMaHang != null && dtMaNhAndMaHang.Rows.Count > 0)
                {
                    foreach(DataRow row in dtMaNhAndMaHang.Rows)
                    {
                        string maNhapHang = row["ma_nhap_hang"].ToString();
                        string maHang = row["ma_hang"].ToString();
                        chiTietNhapHang.XoaCHiTietNhapHang(maNhapHang);
                        nhapHang.XoaNhapHang(maNhapHang);
                        DataTable dtBanHangTheoMatHang = chiTietBanHang.DsBanHangTheoMaHang(maHang);
                        if(dtBanHangTheoMatHang != null && dtBanHangTheoMatHang.Rows.Count > 0)
                        {
                            foreach(DataRow dataRow in dtBanHangTheoMatHang.Rows)
                            {
                                string maBanHang = dataRow["ma_ban_hang"].ToString();
                                chiTietBanHang.XoaChiTietBanHang(maBanHang);
                                banHang.XoaBanHang(maBanHang);
                            }
                        }
                        matHang.XoaMatHang(maHang);
                    }
                }
                bool ketQua = nhaCungCap.XoaNhaCungCap(lblMa.Text);
                if (ketQua)
                {
                    MessageBox.Show("Xóa Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataNhaCungCap();
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
            errNhaCungCap.Clear();
            bool ketQua;
            string hoTen = txtHoTen.Text;
            string sdt = txtSdt.Text;
            string diachi = txtQueQuan.Text;

            if (hoTen == "")
                errNhaCungCap.SetError(palHoTen, "Vui Lòng Nhập Họ Tên");
            else if (sdt == "")
                errNhaCungCap.SetError(palSdt, "Vui Lòng Nhập Số Điện Thoại");
            else if (diachi == "")
                errNhaCungCap.SetError(palQueQuan, "Vui Lòng Nhập Địa Chỉ");
            else
            {
                ketQua = nhaCungCap.ThemNhaCungCap(lblMa.Text, hoTen, sdt, diachi);
                if (ketQua)
                {
                    MessageBox.Show("Thêm Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataNhaCungCap();
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
