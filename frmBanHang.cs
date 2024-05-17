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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLiBanSach
{
    public partial class frmBanHang : Form
    {
        private BanHang banHang = new BanHang();
        private ChiTietBanHang chiTietBanHang = new ChiTietBanHang();
        private DataTable dtDsBanHangGop = new DataTable();
        private DataTable dtChiTietDonHang = new DataTable();
        private List<string> maBanHangs = new List<string>();
        private float tongThanhTien = 0;
        public frmBanHang()
        {
            InitializeComponent();
        }

        private void frmBanHang_Load(object sender, EventArgs e)
        {
            txtTimKiem.Text = "Tìm Kiếm";
            txtTimKiem.GotFocus += RemoveText;
            txtTimKiem.LostFocus += AddText;
            LoadDataGiview();
        }
        public void LoadDataGiview()
        {
            dtDsBanHangGop = banHang.DSBanHangGop();
            DataColumn maNhapHangColumn = new DataColumn("ma_ban_hang", typeof(string));
            dtDsBanHangGop.Columns.Add(maNhapHangColumn);
            maNhapHangColumn.SetOrdinal(0);
            int index = 1;
            foreach (DataRow row in dtDsBanHangGop.Rows)
            {
                string maNhapHang = "";
                if (index < 10)
                    maNhapHang = "BH00" + index;
                else
                    maNhapHang = "BH0" + index;
                row["ma_ban_hang"] = maNhapHang;
                index++;
            }
            dgvDonHang.DataSource = dtDsBanHangGop;
            dgvDonHang.Columns[0].HeaderText = "Mã Bán Hàng";
            dgvDonHang.Columns[1].HeaderText = "Tên Khách Hàng";
            dgvDonHang.Columns[2].HeaderText = "Ngày Bán";
            dgvDonHang.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDonHang.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDonHang.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDonHang.AllowUserToAddRows = false;
            dgvDonHang.EditMode = DataGridViewEditMode.EditProgrammatically;

        }
        
        private void LoadChiTietBanHang()
        {
            if(dtChiTietDonHang != null && dtChiTietDonHang.Rows.Count > 0)
            {
                string maNhanVien = dtChiTietDonHang.Rows[0]["ma_nhan_vien"].ToString();
                string tenNhanVien = dtChiTietDonHang.Rows[0]["ho_ten"].ToString();
                string maKhachHang = dtChiTietDonHang.Rows[0]["ma_khach_hang"].ToString();
                string tenKhachHang = dtChiTietDonHang.Rows[0]["ten_khach_hang"].ToString();
                string ngayBan = dtChiTietDonHang.Rows[0]["ngay_ban"].ToString();
                lblNhanVien.Text = maNhanVien + " | " + tenNhanVien;
                lblKhachHang.Text = maKhachHang + " | " + tenKhachHang;
                lblTgianBan.Text = ngayBan;
                for (int i = 0; i < dtChiTietDonHang.Rows.Count; i++)
                {
                    string maBanHang = dtChiTietDonHang.Rows[i]["ma_ban_hang"].ToString();
                    string tenMatHang = dtChiTietDonHang.Rows[i]["ten_hang"].ToString();
                    string soLuong = dtChiTietDonHang.Rows[i]["so_luong"].ToString();
                    float thanhTien = float.Parse(dtChiTietDonHang.Rows[i]["thanh_tien"].ToString());
                    ListViewItem lv = new ListViewItem(maBanHang);
                    lv.SubItems.Add(tenMatHang);
                    lv.SubItems.Add(soLuong);
                    lv.SubItems.Add(thanhTien.ToString("#,##0"));
                    lvChiTietDonHang.Items.Add(lv);
                    maBanHangs.Add(maBanHang);
                }
                foreach(ListViewItem item in lvChiTietDonHang.Items)
                {
                    tongThanhTien += float.Parse(item.SubItems[3].Text.Replace(".",""));
                    lblTongThanhTien.Text = tongThanhTien.ToString("#,##0") + " VNĐ";
                }
                tongThanhTien = 0;
            }
        }
        private void dgvDonHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lvChiTietDonHang.Items.Clear();
            dtChiTietDonHang.Clear();
            if (dgvDonHang.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvDonHang.SelectedRows[0];
                string ngayBan = selectedRow.Cells[2].Value.ToString();
                DateTime dateNgayBan = DateTime.Parse(ngayBan);
                dtChiTietDonHang = chiTietBanHang.ThongTinChiTiet(dateNgayBan.ToString("yyyy-MM-dd HH:mm:ss"));
                LoadChiTietBanHang();
            }
        }
        public void RestValues()
        {
            lblNhanVien.Text = "";
            lblKhachHang.Text = "";
            lblTgianBan.Text = "";
            lblTongThanhTien.Text = "0 VNĐ";
            lvChiTietDonHang.Items.Clear();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvChiTietDonHang.Items.Count == 0)
            {
                MessageBox.Show("Thao Tác Sai!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool ketQua = false;
            if (lvChiTietDonHang.SelectedItems.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn Có Chắc Chắn Xóa Các Đơn Hàng Đã Chọn", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    foreach (ListViewItem item in lvChiTietDonHang.SelectedItems)
                    {
                        string maBanHang = item.SubItems[0].Text;
                        ketQua = chiTietBanHang.XoaChiTietBanHang(maBanHang);
                        ketQua &= banHang.XoaBanHang(maBanHang);
                    }
                    if (ketQua)
                    {
                        MessageBox.Show("Xóa Đơn Hàng Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RestValues();
                        LoadDataGiview();
                    }
                }
            }
            else
            {

                DialogResult result = MessageBox.Show("Bạn Có Chắc Chắn Xóa Tất Cả Đơn Hàng", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    foreach (ListViewItem item in lvChiTietDonHang.Items)
                    {
                        string maBanHang = item.SubItems[0].Text;
                        ketQua = chiTietBanHang.XoaChiTietBanHang(maBanHang);
                        ketQua &= banHang.XoaBanHang(maBanHang);
                    }
                    if (ketQua)
                    {
                        MessageBox.Show("Xóa Đơn Hàng Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RestValues();
                        LoadDataGiview();
                    }
                }
            }
        }
        private void TimKiem(string timkiem)
        {
            if (timkiem.Equals("Tìm Kiếm"))
                timkiem = "";
            string timkiemFomat = timkiem.Trim().ToLower();

            DataTable dataTrue = dtDsBanHangGop.Clone();
            foreach (DataRow row in dtDsBanHangGop.Rows)
            {
                if (cbxLuaChon.SelectedIndex == 0)
                {
                    if (row[0].ToString().ToLower().Contains(timkiemFomat))
                    {
                        dataTrue.ImportRow(row);
                    }
                }
                else if (cbxLuaChon.SelectedIndex == 1)
                {
                    if (row[1].ToString().ToLower().Contains(timkiemFomat))
                    {
                        dataTrue.ImportRow(row);
                    }
                }
                else if (cbxLuaChon.SelectedIndex == 2)
                {
                    if (row[2].ToString().ToLower().Contains(timkiemFomat))
                    {
                        dataTrue.ImportRow(row);
                    }
                }
            }
            dgvDonHang.DataSource = dataTrue;
        }
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKiem.Text != "" && cbxLuaChon.SelectedIndex != -1)
            {
                TimKiem(txtTimKiem.Text);
            }
            else if (txtTimKiem.Text == "")
            {
                LoadDataGiview();
            }
        }
        public void RemoveText(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "Tìm Kiếm")
            {
                txtTimKiem.Text = "";
            }
        }
        public void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
                txtTimKiem.Text = "Tìm Kiếm";
        }

    }
}
