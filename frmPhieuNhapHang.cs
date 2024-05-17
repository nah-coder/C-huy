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
    public partial class frmPhieuNhapHang : Form
    {
        private NhanVien nhanVien = new NhanVien();
        private NhaCungCap nhaCungCap = new NhaCungCap();
        private MatHang matHangClass = new MatHang();
        private NhapHang nhapHang = new NhapHang();
        private ChiTietNhapHang chiTietNhapHang = new ChiTietNhapHang();
        private DataTable dtNhanVien = new DataTable();
        private DataTable dtNhaCungCap = new DataTable();
        private List<string> matHangs = new List<string>();
        private List<int> soLuongs = new List<int>();
        private List<float> giaNhaps = new List<float>();
        private int click = 1;
        private double tongThanhTien = 0;
        private string maNhanVien;
        public string MaNhanVien
        {
            get { return maNhanVien; }
            set { maNhanVien = value; }
        }
        public frmPhieuNhapHang()
        {
            InitializeComponent();
        }
        private void frmPhieuNhapHang_Load(object sender, EventArgs e)
        {
            LoadNhanVien();
            LoadNhaCungCap();
            lblNgayLap.Text = DateTime.Now.ToString();
        }

        private void LoadNhanVien()
        {
            dtNhanVien = nhanVien.ThongTinNhanVien(maNhanVien);
            if(dtNhanVien.Rows.Count > 0)
            {
                string tenNhanVien = dtNhanVien.Rows[0]["ho_ten"].ToString();
                lblNhanVien.Text = maNhanVien + " | " + tenNhanVien;
            }
        }

        private void LoadNhaCungCap()
        {
            dtNhaCungCap = nhaCungCap.DsNhaCungCap();
            if(dtNhaCungCap.Rows.Count > 0)
            {
                for(int i = 0; i<dtNhaCungCap.Rows.Count; i++)
                {
                    string maNCC = dtNhaCungCap.Rows[i]["ma_nha_cung_cap"].ToString();
                    string tenNCC = dtNhaCungCap.Rows[i]["ten_nha_cung_cap"].ToString();
                    cbxNCC.Items.Add(maNCC + " | "+ tenNCC);
                }
            }
        }

        public void ResetValues()
        {
            errNhapHang.Clear();
            txtMatHang.Text = "";
            txtgiaNhap.Text = "";
            txtSoLuong.Text = "";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            errNhapHang.Clear();
            int soLuong;
            float giaNhap;
            if (cbxNCC.Text == "")
                errNhapHang.SetError(palNCC, "Vui Lòng Chọn Nhà Cung Cấp!");
            else if (txtMatHang.Text == "")
                errNhapHang.SetError(palMatHang,"Vui Lòng Nhập Trường Này!");
            else if (!float.TryParse(txtgiaNhap.Text, out giaNhap))
                errNhapHang.SetError(palGiaNhap, "Nhập Đúng Định Dạng!");
            else if (!int.TryParse(txtSoLuong.Text, out soLuong))
                errNhapHang.SetError(palSoLuong, "Nhập Đúng Định Dạng!");
            else
            {
                string matHang = txtMatHang.Text;
                ListViewItem item = new ListViewItem("NH00"+click);
                item.SubItems.Add(matHang);
                item.SubItems.Add(giaNhap.ToString());
                item.SubItems.Add(soLuong.ToString());
                item.SubItems.Add(soLuong*giaNhap +"");
                lvDonHang.Items.Add(item);
                ResetValues();
                cbxNCC.Enabled = false;
                click++;
                foreach (ListViewItem lv in lvDonHang.Items)
                {
                    double tt = double.Parse(lv.SubItems[4].Text);
                    tongThanhTien += tt;
                }
                lblThanhTien.Text = tongThanhTien.ToString("#,##0") + "đ";
                tongThanhTien = 0;
            }
            if(lvDonHang.Items.Count > 0)
                btnLuu.Enabled = true;
        }
        private void lvDonHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDonHang.SelectedItems.Count > 0)
            {
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnThem.Enabled = false;
                txtMatHang.Text = lvDonHang.SelectedItems[0].SubItems[1].Text;
                txtSoLuong.Text = lvDonHang.SelectedItems[0].SubItems[2].Text;
                txtgiaNhap.Text = lvDonHang.SelectedItems[0].SubItems[3].Text; 
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if(lvDonHang.SelectedItems.Count > 0)
            {
                errNhapHang.Clear();
                int soLuong;
                float giaNhap;
                if (txtMatHang.Text == "")
                    errNhapHang.SetError(palMatHang, "Vui Lòng Nhập Trường Này!");
                else if (!float.TryParse(txtgiaNhap.Text, out giaNhap))
                    errNhapHang.SetError(palGiaNhap, "Nhập Đúng Định Dạng!");
                else if (!int.TryParse(txtSoLuong.Text, out soLuong))
                    errNhapHang.SetError(palSoLuong, "Nhập Đúng Định Dạng!");
                else
                {
                    lvDonHang.SelectedItems[0].SubItems[1].Text = txtMatHang.Text;
                    lvDonHang.SelectedItems[0].SubItems[2].Text = txtgiaNhap.Text;
                    lvDonHang.SelectedItems[0].SubItems[3].Text = txtSoLuong.Text;
                    lvDonHang.SelectedItems[0].SubItems[4].Text = soLuong * giaNhap+"";
                    ResetValues();
                    btnXoa.Enabled = false;
                    btnSua.Enabled = false;
                    btnThem.Enabled = true;
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvDonHang.SelectedItems.Count > 0)
            {
                lvDonHang.Items.RemoveAt(lvDonHang.SelectedIndices[0]);
                ResetValues();
                click--;
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
                btnThem.Enabled = true;
                foreach (ListViewItem lv in lvDonHang.Items)
                {
                    float tt = int.Parse(lv.SubItems[4].Text);
                    tongThanhTien += tt;
                }
                lblThanhTien.Text = tongThanhTien.ToString("#,##0") + "đ";
                tongThanhTien = 0;
            }else
            {
                cbxNCC.Enabled = true;
                cbxNCC.Text = "";
            }
        }
        
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string nccString = cbxNCC.Text;
            string maNCC = nccString.Split('|')[0].Trim();
            DateTime dateNgayLap = DateTime.Parse(lblNgayLap.Text);
            if (lvDonHang.Items.Count > 0)
            {
                foreach(ListViewItem lv in lvDonHang.Items)
                {
                    string matHang = lv.SubItems[1].Text;
                    float gia = float.Parse(lv.SubItems[2].Text);
                    int soLuong = int.Parse(lv.SubItems[3].Text);
                    matHangs.Add(matHang);
                    giaNhaps.Add(gia);
                    soLuongs.Add(soLuong);
                }
            }
            bool ketQua = true;
            bool ketQua2 = true;
            bool ketQua3 = true;
            DialogResult result = MessageBox.Show("Bạn Có Xác Nhận Thanh Toán Không", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                for (int i = 0; i < soLuongs.Count; i++)
                {
                    IDAuto id = new IDAuto();
                    string maHang = id.LayIdTuDong("MatHang", "MH");
                    string maNhapHang = id.LayIdTuDong("NhapHang", "NH");
                    ketQua = matHangClass.TaoMatHang(maHang, matHangs[i]);
                    ketQua2 = nhapHang.TaoNhapHang(maNhapHang, maNCC, maNhanVien, dateNgayLap.ToString("yyyy-MM-dd HH:mm:ss"));
                    ketQua3 = chiTietNhapHang.TaoChiTietNhapHang(maNhapHang, maHang, soLuongs[i], giaNhaps[i]);
                }
                if (ketQua && ketQua2 && ketQua3)
                {
                    MessageBox.Show("Tạo Đơn Hàng Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnThem.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            lvDonHang.SelectedItems.Clear();
        }

        
    }
}
