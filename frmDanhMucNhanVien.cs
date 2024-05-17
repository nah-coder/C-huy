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
    public partial class frmDanhMucNhanVien : Form
    {
        private NhanVien nhanVien = new NhanVien();
        private BanHang banHang = new BanHang();
        private ChiTietBanHang chiTietBanHang = new ChiTietBanHang();
        private NhapHang nhapHang = new NhapHang();
        private ChiTietNhapHang chiTietNhapHang = new ChiTietNhapHang();
        private MatHang matHang = new MatHang();
        private DataTable dtNhanVien = new DataTable();
        private bool check = false;
        private string maNhanVien;
        private string maNhanVienSend;
        private frmChinh parentForm;
        public string MaNhanVienSend
        {
            get { return maNhanVienSend; }
            set { maNhanVienSend = value; }
        }
        public frmDanhMucNhanVien(frmChinh parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
        }

        private void frmDanhMucNhanVien_Load(object sender, EventArgs e)
        {
            IDAuto iDAuto = new IDAuto();
            maNhanVien = iDAuto.LayIdTuDong("NhanVien", "NV");
            lblMaNhanVien.Text = maNhanVien;
            btnLuu.Enabled = false;
            btnboQua.Enabled = false;
            lblTrangThai.Visible = false;
            chkTranThai.Visible = false;
            if (maNhanVienSend.Equals("NV001"))
            {
                btnXoa.Visible = true;
                lblTrangThai.Visible = true;
                chkTranThai.Visible = true;
                chkTranThai.Text = "Cấp Quyền";
            }
            else
                btnXoa.Visible = false;
            dtNhanVien = nhanVien.DsNhanVienTheoTruong();
            if (dtNhanVien.Rows.Count > 1)
                LoadDataNhanVien();
        }

        private void LoadDataNhanVien()
        {
            dtaNhanVien.DataSource = dtNhanVien.AsEnumerable().Skip(1).CopyToDataTable();
            dtaNhanVien.Columns[0].HeaderText = "Mã Nhân Viên";
            dtaNhanVien.Columns[1].HeaderText = "Họ Tên";
            dtaNhanVien.Columns[2].HeaderText = "Số Điện Thoại";
            dtaNhanVien.Columns[3].HeaderText = "Quê Quán";
            dtaNhanVien.Columns[4].HeaderText = "Trạng Thái";
            dtaNhanVien.CellFormatting += (sender, e) =>
            {
                if (e.ColumnIndex == 4 && e.Value != null && e.Value.ToString() == "0")
                {
                    e.Value = "Chưa Active";
                }else if (e.ColumnIndex == 4 && e.Value != null && e.Value.ToString() == "1")
                {
                    e.Value = "Đang Active";
                }
            };
            dtaNhanVien.AllowUserToAddRows = false;
            dtaNhanVien.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dtaNhanVien_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHoTen.Focus();
                return;
            }
            if (dtaNhanVien.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            lblMaNhanVien.Text = dtaNhanVien.CurrentRow.Cells[0].Value.ToString();
            txtHoTen.Text = dtaNhanVien.CurrentRow.Cells[1].Value.ToString();
            txtSdt.Text = dtaNhanVien.CurrentRow.Cells[2].Value.ToString();
            txtQueQuan.Text = dtaNhanVien.CurrentRow.Cells[3].Value.ToString();
            if (dtaNhanVien.CurrentRow.Cells[4].Value.ToString() == "0")
            {
                chkTranThai.Text = "Cấp Quyền";
            }
            else
            {
                chkTranThai.Checked = true;
                chkTranThai.Text = "Hủy Quền";
            }
            txtTenDangNhap.Enabled = false;
            txtMatKhau.Enabled = false;
            lblShowPasswword.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnboQua.Enabled = true;

        }
        public void ResetValue()
        {
            lblMaNhanVien.Text = maNhanVien;
            txtHoTen.Text = "";
            txtQueQuan.Text = "";
            txtSdt.Text = "";
            txtTenDangNhap.Text = "";
            txtMatKhau.Text = "";
            txtTenDangNhap.Enabled = true;
            txtMatKhau.Enabled = true;
            chkTranThai.Checked = false;
            lblShowPasswword.Enabled = true;
            dtaNhanVien.ClearSelection();
            chkTranThai.Text = "";
            
        }
        private void btnboQua_Click(object sender, EventArgs e)
        {
            ResetValue();
            btnboQua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
        }

        private void lblShowPasswword_Click(object sender, EventArgs e)
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnboQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValue(); 
            txtHoTen.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            errNhanVien.Clear();
            bool ketQua;
            string hoTen = txtHoTen.Text;
            string sdt = txtSdt.Text;
            string diachi = txtQueQuan.Text;
            string tendangnhap = txtTenDangNhap.Text;
            string matkhau = txtMatKhau.Text;

            int _sdt;
            if (hoTen == "")
                errNhanVien.SetError(palHoTen, "Vui Lòng Nhập Họ Tên");
            else if (sdt == "")
                errNhanVien.SetError(palSdt, "Vui Lòng Nhập Số Điện Thoại");
            else if (!int.TryParse(txtSdt.Text, out _sdt))
                errNhanVien.SetError(palSdt, "Bạn Hãy Nhập Đúng Đinh Dạng!");
            else if (diachi == "")
                errNhanVien.SetError(palQueQuan, "Vui Lòng Nhập Địa Chỉ");
            else if (tendangnhap == "")
                errNhanVien.SetError(palTenDangNhap, "Vui Lòng Nhập Tên Đăng Nhập");
            else if (matkhau == "")
                errNhanVien.SetError(palMatKhau, "Vui Lòng Nhập Mật Khẩu");
            else
            {
                bool chedckTDN = nhanVien.CheckTenDangNhap(tendangnhap);
                int tt;
                tt = (chkTranThai.Checked) ?  1 : 0;
                if (chedckTDN)
                {
                    ketQua = nhanVien.TaoTaiKhoan(lblMaNhanVien.Text, txtTenDangNhap.Text, txtMatKhau.Text, txtHoTen.Text, _sdt, txtQueQuan.Text, tt);
                    if (ketQua)
                    {
                        MessageBox.Show("Thêm Mới Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        parentForm.ReloadForm();
                    }
                    else
                    {
                        MessageBox.Show("Thêm Mới Thất Bại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ResetValue();
                    }
                }
                else
                {
                    errNhanVien.SetError(palTenDangNhap, "Tên Đăng Nhập Đã Có Trong hệ Thống!");
                }
            }
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dtNhanVien.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtHoTen.Text == "") 
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            errNhanVien.Clear();
            bool ketQua;
            string hoTen = txtHoTen.Text;
            string sdt = txtSdt.Text;
            string diachi = txtQueQuan.Text;

            int _sdt;
            if (hoTen == "")
                errNhanVien.SetError(palHoTen, "Vui Lòng Nhập Họ Tên");
            else if (sdt == "")
                errNhanVien.SetError(palSdt, "Vui Lòng Nhập Số Điện Thoại");
            else if (!int.TryParse(txtSdt.Text, out _sdt))
                errNhanVien.SetError(palSdt, "Bạn Hãy Nhập Đúng Đinh Dạng!");
            else if (diachi == "")
                errNhanVien.SetError(palQueQuan, "Vui Lòng Nhập Địa Chỉ");
            else
            {
                int tt;
                tt = (chkTranThai.Checked) ? 1 : 0;
                ketQua = nhanVien.CapNhatNhanVien(lblMaNhanVien.Text,hoTen,_sdt,diachi,tt);
                if (ketQua)
                {
                    MessageBox.Show("Cập Nhật Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    parentForm.ReloadForm();
                }
                else
                {
                    MessageBox.Show("Cập Nhật Thất Bại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ResetValue();
                }
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dtNhanVien.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (lblMaNhanVien.Text.Equals(maNhanVien))
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataTable dtMaNhAndMaHang = nhapHang.DsMaNhapHangTheoMaNhanVien(lblMaNhanVien.Text);
                if (dtMaNhAndMaHang != null && dtMaNhAndMaHang.Rows.Count > 0)
                {
                    foreach (DataRow row in dtMaNhAndMaHang.Rows)
                    {
                        string maNhapHang = row["ma_nhap_hang"].ToString();
                        string maHang = row["ma_hang"].ToString();
                        chiTietNhapHang.XoaCHiTietNhapHang(maNhapHang);
                        nhapHang.XoaNhapHang(maNhapHang);
                        DataTable dtBanHangTheoMatHang = chiTietBanHang.DsBanHangTheoMaHang(maHang);
                        if (dtBanHangTheoMatHang != null && dtBanHangTheoMatHang.Rows.Count > 0)
                        {
                            foreach (DataRow dataRow in dtBanHangTheoMatHang.Rows)
                            {
                                string maBanHang = dataRow["ma_ban_hang"].ToString();
                                chiTietBanHang.XoaChiTietBanHang(maBanHang);
                                banHang.XoaBanHang(maBanHang);
                            }
                        }
                        matHang.XoaMatHang(maHang);
                    }
                }
                bool ketQua = nhanVien.XoaNhanVien(lblMaNhanVien.Text);
                if(ketQua)
                {
                    MessageBox.Show("Xóa Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    parentForm.ReloadForm();
                }
                else
                {
                    MessageBox.Show("Xóa Thất Bại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                ResetValue();
            }
        }
    }
}
