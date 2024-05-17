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
    public partial class frmNhapHang : Form
    {
        private ChiTietNhapHang chiTietNhapHang = new ChiTietNhapHang();
        private NhapHang nhapHang = new NhapHang();
        private MatHang matHang = new MatHang();
        private DataTable dtDsNhapHangGop = new DataTable();
        private DataTable dtThongTinChiTiet = new DataTable();
        private List<string> maHangs = new List<string>();
        public frmNhapHang()
        {
            InitializeComponent();
        }

        private void frmHoaDonNhapHang_Load(object sender, EventArgs e)
        {
            txtTimKiem.Text = "Tìm Kiếm";
            txtTimKiem.GotFocus += RemoveText;
            txtTimKiem.LostFocus += AddText;
            LoadDataGiview();
        }

        public void LoadDataGiview()
        {
            dtDsNhapHangGop = chiTietNhapHang.DsNhapHangGop();
            DataColumn maNhapHangColumn = new DataColumn("ma_nhap_hang", typeof(string));
            dtDsNhapHangGop.Columns.Add(maNhapHangColumn);
            maNhapHangColumn.SetOrdinal(0);
            int index = 1;
            foreach (DataRow row in dtDsNhapHangGop.Rows)
            {
                string maNhapHang = "";
                if (index < 10)
                    maNhapHang = "NH00" + index;
                else
                    maNhapHang = "NH0" + index;
                row["ma_nhap_hang"] = maNhapHang;
                index++;
            }
            dgvDonHang.DataSource = dtDsNhapHangGop;
            dgvDonHang.Columns[0].HeaderText = "Mã Nhập Hàng";
            dgvDonHang.Columns[1].HeaderText = "Tên Nhân Viên";
            dgvDonHang.Columns[2].HeaderText = "Ngày Lập";
            dgvDonHang.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDonHang.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDonHang.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDonHang.AllowUserToAddRows = false;
            dgvDonHang.EditMode = DataGridViewEditMode.EditProgrammatically;
            
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

        public void LoadThongTin()
        {
            if(dtThongTinChiTiet != null && dtThongTinChiTiet.Rows.Count > 0)
            {
                string maNhanVien = dtThongTinChiTiet.Rows[0]["ma_nhan_vien"].ToString();
                string tenNhanVien = dtThongTinChiTiet.Rows[0]["ho_ten"].ToString();
                string maNCC = dtThongTinChiTiet.Rows[0]["ma_nha_cung_cap"].ToString();
                string tenNCC = dtThongTinChiTiet.Rows[0]["ten_nha_cung_cap"].ToString();
                string ngayNhap = dtThongTinChiTiet.Rows[0]["ngay_nhap"].ToString();
                DateTime dateTime = DateTime.Parse(ngayNhap);
                lblNhanVien.Text = maNhanVien + " | " + tenNhanVien;
                lblNhaCungCap.Text = maNCC + " | " + tenNCC;
                lblTgianNhap.Text = dateTime.ToString("dd/MM/yyyy HH:mm:ss");
                for(int i = 0; i<dtThongTinChiTiet.Rows.Count; i++)
                {
                    string maNhapHang = dtThongTinChiTiet.Rows[i]["ma_nhap_hang"].ToString();
                    string maHang = dtThongTinChiTiet.Rows[i]["ma_hang"].ToString();
                    string tenHang = dtThongTinChiTiet.Rows[i]["ten_hang"].ToString();
                    string soLuong = dtThongTinChiTiet.Rows[i]["so_luong"].ToString();
                    float giaNhap = float.Parse(dtThongTinChiTiet.Rows[i]["gia_nhap"].ToString());
                    ListViewItem lv = new ListViewItem(maNhapHang);
                    lv.SubItems.Add(tenHang);
                    lv.SubItems.Add(soLuong);
                    lv.SubItems.Add(giaNhap.ToString("#,##0"));
                    lvChiTietDonHang.Items.Add(lv);
                    maHangs.Add(maHang);
                }
            }
        }

        private void dgvDonHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            maHangs.Clear();
            dtThongTinChiTiet.Clear();
            lvChiTietDonHang.Items.Clear();
            if(dgvDonHang.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvDonHang.SelectedRows[0];
                string ngayNhap = selectedRow.Cells[2].Value.ToString();
                DateTime dateNgayNhap = DateTime.Parse(ngayNhap);
                dtThongTinChiTiet = chiTietNhapHang.ThongTinChiTietDonHang(dateNgayNhap.ToString("yyyy-MM-dd HH:mm:ss"));
                LoadThongTin();
            }
            
        }

        public void RestValues()
        {
            lblNhanVien.Text = "";
            lblNhaCungCap.Text = "";
            lblTgianNhap.Text = "";
            lvChiTietDonHang.Items.Clear();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(lvChiTietDonHang.Items.Count == 0)
            {
                MessageBox.Show("Thao Tác Sai!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool ketQua = false;
            if(lvChiTietDonHang.SelectedItems.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn Có Chắc Chắn Xóa Các Đơn Hàng Đã Chọn","Xác Nhận",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    foreach (ListViewItem item in lvChiTietDonHang.SelectedItems)
                    {
                        string maNhaphang = item.SubItems[0].Text;
                        ketQua = chiTietNhapHang.XoaCHiTietNhapHang(maNhaphang);
                        ketQua &= nhapHang.XoaNhapHang(maNhaphang);

                    }
                    foreach (int index in lvChiTietDonHang.SelectedIndices)
                        matHang.XoaMatHang(maHangs[index]);
                    if (ketQua)
                    {
                        MessageBox.Show("Xóa Đơn Hàng Thành Công!","Thông Báo", MessageBoxButtons.OK,MessageBoxIcon.Information);
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
                        string maNhaphang = item.SubItems[0].Text;
                        ketQua = chiTietNhapHang.XoaCHiTietNhapHang(maNhaphang);
                        ketQua &= nhapHang.XoaNhapHang(maNhaphang);

                    }
                    for (int i = 0; i < lvChiTietDonHang.Items.Count; i++)
                        matHang.XoaMatHang(maHangs[i]);
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

            DataTable dataTrue = dtDsNhapHangGop.Clone();
            foreach (DataRow row in dtDsNhapHangGop.Rows)
            {
                if(cbxLuaChon.SelectedIndex ==0)
                {
                    if (row[0].ToString().ToLower().Contains(timkiemFomat))
                    {
                        dataTrue.ImportRow(row);
                    }
                }else if (cbxLuaChon.SelectedIndex == 1)
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
    }
}
