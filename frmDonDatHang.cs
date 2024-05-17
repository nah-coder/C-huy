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
    public partial class frmDonDatHang : Form
    {
        private NhanVien nhanVien = new NhanVien();
        private KhachHang khachHang = new KhachHang();
        private MatHang matHang = new MatHang();
        private BanHang banHang = new BanHang();
        private ChiTietBanHang chiTietBanHang = new ChiTietBanHang();
        public DataTable dtNhanVien = new DataTable();
        public DataTable dtKhachHang = new DataTable();
        public DataTable dtMatHang = new DataTable();
        private List<string> maHangSends = new List<string>();
        private List<string> maHangs = new List<string>();
        private List<int> soLuongMatHangConLais = new List<int>();
        private List<int> indexMatHangs = new List<int>();
        private List<float> giaBans = new List<float>();
        private List<int> indexindexMatHangGops = new List<int>();
        private int click = 1;
        private float tongThanhTien;
        private string maNhanVien;
        public string MaNhanVien
        {
            get { return maNhanVien; }
            set { maNhanVien = value; }
        }
        public frmDonDatHang()
        {
            InitializeComponent();
        }

        private void frmDonDatHang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            dtNhanVien = nhanVien.ThongTinNhanVien(maNhanVien);
            dtKhachHang = khachHang.DsKhachHang();
            dtMatHang = matHang.MatHangTrongCuaHang();
            lblNgayBan.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            if(dtNhanVien != null && dtNhanVien.Rows.Count > 0)
            {
                string tenNhanVien = dtNhanVien.Rows[0]["ho_ten"].ToString();
                lblNhanVien.Text = maNhanVien + " | " + tenNhanVien;
            }

            if(dtKhachHang != null && dtKhachHang.Rows.Count > 0)
            {
                for(int i = 0; i< dtKhachHang.Rows.Count; i++)
                {
                    string maKhachHang = dtKhachHang.Rows[i]["ma_khach_hang"].ToString();
                    string tenKhachHang = dtKhachHang.Rows[i]["ten_khach_hang"].ToString();
                    cbKhachHang.Items.Add(maKhachHang + " | " + tenKhachHang);
                }
            }

            if(dtMatHang != null && dtMatHang.Rows.Count > 0)
            {
                for(int i = 0; i < dtMatHang.Rows.Count; i++)
                {
                    string maHang = dtMatHang.Rows[i]["ma_hang"].ToString();
                    string tenHang = dtMatHang.Rows[i]["ten_hang"].ToString();
                    float giaBan = float.Parse(dtMatHang.Rows[i]["gia_ban"].ToString());
                    int soLuong = int.Parse(dtMatHang.Rows[i]["so_luong_ban"].ToString());
                    maHangs.Add(maHang);
                    soLuongMatHangConLais.Add(soLuong);
                    giaBans.Add(giaBan);
                    cbxMatHang.Items.Add(maHang + " | " + tenHang);
                }
            }
        }

        private void cbxMatHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (soLuongMatHangConLais[cbxMatHang.SelectedIndex] > 0)
            {
                lblSoLuongConLai.Text = $"Số Lượng Còn Lại: {soLuongMatHangConLais[cbxMatHang.SelectedIndex]}";
                txtSoLuong.Enabled = true;
            }
            else
            {
                lblSoLuongConLai.Text = $"Số Lượng Còn Lại: Đã Hết!";
            }
            lblGiaBan.Text = giaBans[cbxMatHang.SelectedIndex].ToString("#,##0") + " VNĐ";
        }

        public void ResetValues()
        {
            errDonDatHang.Clear();
            if(lvDonHang.Items.Count == 0)
            {
                cbKhachHang.Enabled = true ;
                cbKhachHang.Text = "";
            }
            cbxMatHang.Text = "";
            lblSoLuongConLai.Text = "";
            txtSoLuong.Enabled = true;
            txtSoLuong.Text = "";
            lblGiaBan.Text = "";
            lblGiaBan.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            errDonDatHang.Clear();
            int soLuong;
            if (cbKhachHang.Text == "")
                errDonDatHang.SetError(palKhachhang, "Vui Lòng Chọn Khách Hàng!");
            else if(cbxMatHang.Text == "")
                errDonDatHang.SetError(palMatHang, "Vui Lòng Chọn mặt Hàng!");
            else if (txtSoLuong.Text == "")
                errDonDatHang.SetError(palSoLuong, "Vui Lòng Nhập Trường Này!");
            else if (!int.TryParse(txtSoLuong.Text, out soLuong))
                errDonDatHang.SetError(palSoLuong, "Định Dạng Không Đúng!");
            else if (soLuong > soLuongMatHangConLais[cbxMatHang.SelectedIndex] || txtSoLuong.Text == "0")
                errDonDatHang.SetError(palSoLuong, "Số Lượng Không Đáp Ứng!");
            else
            {
                cbKhachHang.Enabled = false;
                string matHang = cbxMatHang.Text.Split('|')[1].Trim();
                maHangSends.Add(cbxMatHang.Text.Split('|')[0].Trim());
                indexMatHangs.Add(cbxMatHang.SelectedIndex);
                ListViewItem lv = new ListViewItem("BH00" + click);
                lv.SubItems.Add(matHang);
                lv.SubItems.Add(lblGiaBan.Text.Replace("VNĐ", ""));
                lv.SubItems.Add(soLuong.ToString());
                lv.SubItems.Add((soLuong * float.Parse(lblGiaBan.Text.Replace(",","").Replace("VNĐ" ,""))).ToString("#,##0"));
                lvDonHang.Items.Add(lv);
                foreach (ListViewItem item in lvDonHang.Items)
                {
                    float tt = int.Parse(item.SubItems[4].Text.Replace(".", ""));
                    tongThanhTien += tt;
                }
                soLuongMatHangConLais[cbxMatHang.SelectedIndex] -= soLuong;
                lblThanhTien.Text = tongThanhTien.ToString("#,##0") + " VNĐ";
                tongThanhTien = 0;
                click++;
                ResetValues();
            }
            if (lvDonHang.Items.Count > 0)
                btnLuu.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            errDonDatHang.Clear();
            if(lvDonHang.SelectedItems.Count > 0)
            {
                int sl = int.Parse(lvDonHang.SelectedItems[0].SubItems[3].Text);
                int soLuong;
                if (!int.TryParse(txtSoLuong.Text, out soLuong))
                    errDonDatHang.SetError(palSoLuong, "Vui Lòng Nhập Đúng Định Dạng!");
                else if (txtSoLuong.Text.Equals("0") || soLuong > sl + soLuongMatHangConLais[cbxMatHang.SelectedIndex])
                    errDonDatHang.SetError(palSoLuong, "Sô Lượng Không Đáp Ứng!");
                else
                {
                    int slKhoMoi = soLuongMatHangConLais[cbxMatHang.SelectedIndex] - (soLuong - sl);
                    lvDonHang.SelectedItems[0].SubItems[3].Text = soLuong.ToString();
                    soLuongMatHangConLais[cbxMatHang.SelectedIndex] = slKhoMoi;
                    ResetData();
                }
            }
            else
            {
                MessageBox.Show("Sai Thao Tác!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(lvDonHang.SelectedItems.Count > 0)
            {
                int sl = int.Parse(lvDonHang.SelectedItems[0].SubItems[3].Text);
                soLuongMatHangConLais[cbxMatHang.SelectedIndex] += sl;
                maHangSends.RemoveAt(lvDonHang.SelectedIndices[0]);
                indexMatHangs.RemoveAt(lvDonHang.SelectedIndices[0]);
                lvDonHang.Items.RemoveAt(lvDonHang.SelectedIndices[0]);
                ResetData();
                foreach (ListViewItem item in lvDonHang.Items)
                {
                    float tt = int.Parse(item.SubItems[4].Text.Replace(".", ""));
                    tongThanhTien += tt;
                }
                lblThanhTien.Text = tongThanhTien.ToString("#,##0") + " VNĐ";
                tongThanhTien = 0;
            }
            else
            {
                MessageBox.Show("Sai Thao Tác!","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            
        }

        private void ResetData()
        {
            ResetValues();
            cbxMatHang.Enabled = true;
            btnThem.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            lvDonHang.SelectedItems.Clear();
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetData();
        }

        private void lvDonHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDonHang.SelectedItems.Count > 0)
            {
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnThem.Enabled = false;
                string selectedTenHang = lvDonHang.SelectedItems[0].SubItems[1].Text;
                foreach (object item in cbxMatHang.Items)
                {
                    if (item.ToString().Contains(selectedTenHang))
                    {
                        cbxMatHang.SelectedItem = item;
                        cbxMatHang.Text = item.ToString();
                        break;
                    }
                }
                lblSoLuongConLai.Text = $"Số Lượng Còn Lại: {soLuongMatHangConLais[cbxMatHang.SelectedIndex]}";
                cbxMatHang.Enabled = false;
                lblGiaBan.Text = lvDonHang.SelectedItems[0].SubItems[2].Text + " VNĐ";
                txtSoLuong.Text = lvDonHang.SelectedItems[0].SubItems[3].Text;
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(lvDonHang.Items.Count > 0)
            {
                indexindexMatHangGops.Clear();
                var mbdDistinct = indexMatHangs.Distinct();
                foreach (int s in mbdDistinct)
                    indexindexMatHangGops.Add(s);
                bool ketQua = false;
                IDAuto id = new IDAuto();
                DialogResult result = MessageBox.Show("Bạn Có Chắc Chắn Muốn Thanh Toán Đơn Hàng Này!", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    string maKhachHang = cbKhachHang.Text.Split('|')[0].Trim();
                    string maNhanVien = lblNhanVien.Text.Split('|')[0].Trim();
                    DateTime dateNgayBan = DateTime.Parse(lblNgayBan.Text);
                    for(int i = 0; i <lvDonHang.Items.Count; i++)
                    {
                        ListViewItem lv = lvDonHang.Items[i];
                        float thanhTien = float.Parse(lv.SubItems[4].Text);
                        int soLuong = int.Parse(lv.SubItems[3].Text);
                        string maBanHang = id.LayIdTuDong("BanHang", "BH");
                        ketQua = banHang.TaoBanHang(maBanHang, maKhachHang, maNhanVien, dateNgayBan.ToString("yyyy-MM-dd HH:mm:ss"));
                        ketQua &= chiTietBanHang.TaoChiTietBanHang(maBanHang, maHangSends[i], soLuong, thanhTien);

                    }
                    for (int i = 0; i < indexindexMatHangGops.Count; i++)
                    {
                        for(int j = 0; j<maHangs.Count; j++)
                        {
                            if (maHangs[j].Equals(dtMatHang.Rows[indexindexMatHangGops[i]]["ma_hang"].ToString()))
                            {
                                string maHang = dtMatHang.Rows[indexindexMatHangGops[i]]["ma_hang"].ToString();
                                ketQua &= matHang.CapNhatSoLuongMatHangKhiKHMua(maHang,soLuongMatHangConLais[j]);
                            }
                        }
                    }
                    if (ketQua)
                    {
                        MessageBox.Show("Tạo Đơn Đạt Hàng Thành Công!","Thông Báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
        }
    }
}
