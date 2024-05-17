using QuanLiBanSach.database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiBanSach
{
    public partial class frmDanhMucSach : Form
    {
        private MatHang matHang = new MatHang();
        private ChiTietNhapHang chiTietNhapHang = new ChiTietNhapHang();
        private DataTable dtDsMatHang = new DataTable();
        private DataTable dtDsMatHangTrongCuaHang = new DataTable();
        private List<string> maHangSends = new List<string>();
        private List<string> tenHangSends = new List<string>();
        private List<float> giaBanSends = new List<float>();
        private List<int> soLuongSends = new List<int>();
        private List<int> soLuongs = new List<int>();
        private List<float> giaBans = new List<float>();
        private List<byte[]> anhs = new List<byte[]>();
        private List<byte[]> anhSends = new List<byte[]>();
        private List<FlowLayoutPanel> fls = new List<FlowLayoutPanel>();
        private FlowLayoutPanel containingPanel = null;
        private int index;
        private int soLuongTrongKho;
        private int soLuongCuaSach = 0;
        private int dem;
        public frmDanhMucSach()
        {
            InitializeComponent();
        }
        private void frmDanhMucSach_Load(object sender, EventArgs e)
        {
            txtTimKiem.Text = "Tìm Kiếm";
            txtTimKiem.GotFocus += RemoveText;
            txtTimKiem.LostFocus += AddText;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            dtDsMatHang = matHang.DsMatHang();
            LoadData();
            LoadDSMatHang();
            LoadMatHang();
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
        public void LoadData()
        {
            if(dtDsMatHang != null && dtDsMatHang.Rows.Count > 0)
            {
                for(int i = 0; i<dtDsMatHang.Rows.Count; i++)
                {
                    string maMatHang = dtDsMatHang.Rows[i]["ma_hang"].ToString();
                    string tenHang = dtDsMatHang.Rows[i]["ten_hang"].ToString();
                    cbxTenHang.Items.Add(maMatHang + " | " + tenHang);
                }
            }
        }

        public void LoadMatHang()
        {
            dtDsMatHangTrongCuaHang = matHang.MatHangTrongCuaHang();
            if(dtDsMatHangTrongCuaHang != null && dtDsMatHangTrongCuaHang.Rows.Count > 0)
            {
                for(int i = 0; i<dtDsMatHangTrongCuaHang.Rows.Count; i++)
                {
                    FlowLayoutPanel flowLayoutPanel = CreateFlow();
                    flowLayoutPanel.Cursor = Cursors.Hand;
                    fls.Add(flowLayoutPanel);
                    string maHang = dtDsMatHangTrongCuaHang.Rows[i]["ma_hang"].ToString();
                    string tenHang = dtDsMatHangTrongCuaHang.Rows[i]["ten_hang"].ToString();
                    float giaBan = float.Parse(dtDsMatHangTrongCuaHang.Rows[i]["gia_ban"].ToString());
                    int soLuongBan = int.Parse(dtDsMatHangTrongCuaHang.Rows[i]["so_luong_ban"].ToString());
                    byte[] anh = null;
                    if (dtDsMatHangTrongCuaHang.Rows[i]["anh"].ToString() != "")
                        anh = (byte[])dtDsMatHangTrongCuaHang.Rows[i]["anh"];
                    anhs.Add(anh);
                    maHangSends.Add(maHang);
                    tenHangSends.Add(tenHang);
                    giaBanSends.Add(giaBan);
                    soLuongSends.Add(soLuongBan);
                    anhSends.Add(anh);
                    Label lblTen = CreatLabel(tenHang);
                    Label lblSoLuong = CreatLabel("Sẳn Có: " + soLuongBan);
                    Label lblgia = CreatLabel(giaBan.ToString("#,00#") + " VNĐ");
                    PictureBox pictureBox = new PictureBox();
                    if (dtDsMatHangTrongCuaHang.Rows[i]["anh"].ToString() != "")
                        pictureBox = CreatePicbox(BytesToImage((byte[])dtDsMatHangTrongCuaHang.Rows[i]["anh"]));
                    flowLayoutPanel.Controls.Add(pictureBox);
                    flowLayoutPanel.Controls.Add(lblTen);
                    flowLayoutPanel.Controls.Add(lblSoLuong);
                    flowLayoutPanel.Controls.Add(lblgia);
                    flChinh.Controls.Add(flowLayoutPanel);
                }
            }
        }
        private FlowLayoutPanel CreateFlow()
        {
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel.AutoSize = false;
            flowLayoutPanel.Size = new Size(160, 180);
            flowLayoutPanel.BackColor = Color.White;
            flowLayoutPanel.WrapContents = false;
            flowLayoutPanel.Margin = new Padding(10);
            return flowLayoutPanel;
        }

        private void FlowLayout_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGiaBan.Focus();
                return;
            }
            if (dtDsMatHangTrongCuaHang.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            foreach (FlowLayoutPanel panel in fls)
            {
                if (panel.Controls.Contains((Control)sender))
                {
                    containingPanel = panel;
                    break;
                }
            }
            if (containingPanel != null)
            {
                index = fls.IndexOf(containingPanel);
            }

            cbxTenHang.Enabled = false;
            cbxTenHang.Text = maHangSends[index] + " | " + tenHangSends[index];
            soLuongTrongKho = chiTietNhapHang.SoLuongMatHangTrongKho(maHangSends[index]);
            lblSoLuongKho.Text = soLuongTrongKho.ToString();
            txtGiaBan.Text = giaBanSends[index].ToString();
            txtSoLuong.Text = soLuongSends[index].ToString();
            soLuongCuaSach = soLuongSends[index];
            picAnh.Image = BytesToImage(anhSends[index]);
            txtGiaBan.Enabled = true;
            txtSoLuong.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
        }
        private Label CreatLabel(string text)
        {
            Label label = new Label();
            label.Text = text;
            label.BackColor = Color.White;
            label.ForeColor = Color.Black;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Click += FlowLayout_Click;
            label.Font = new Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label.Size = new Size(150, 20);
            label.Margin = new Padding(0, 2, 0, 0);
            return label;
        }

        private PictureBox CreatePicbox(Image img)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = img;
            pictureBox.Size = new Size(90, 90);
            pictureBox.Margin = new Padding(30, 7, 20, 8);
            pictureBox.Click += FlowLayout_Click;
            pictureBox.BackColor = Color.White;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            return pictureBox;
        }
        private void picAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                dem++;
                picAnh.Image = Image.FromFile(openFileDialog.FileName);
            }
        }
        private void cbxTenHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maMh = cbxTenHang.Text.Split('|')[0].Trim();
            soLuongTrongKho = chiTietNhapHang.SoLuongMatHangTrongKho(maMh);
            LoadDSMatHang();
            soLuongCuaSach = soLuongs[cbxTenHang.SelectedIndex];
            if (soLuongTrongKho > 0)
            {
                lblSoLuongKho.Text = soLuongTrongKho.ToString();
                txtSoLuong.Enabled = true;
                txtSoLuong.Text = "";
            }
            else
            {
                lblSoLuongKho.Text = "0";
                txtSoLuong.Enabled = false;
                txtSoLuong.BackColor = Color.WhiteSmoke;
                txtSoLuong.Text = "0";
            }
            if (giaBans[cbxTenHang.SelectedIndex] > 0)
            {
                txtGiaBan.Text = giaBans[cbxTenHang.SelectedIndex].ToString();
                txtGiaBan.Enabled = false;
                txtGiaBan.BackColor = Color.WhiteSmoke;
            }
            else if (giaBans[cbxTenHang.SelectedIndex] == 0)
            {
                txtGiaBan.Enabled = true;
                txtGiaBan.Text = "";
            }
            if (anhs[cbxTenHang.SelectedIndex] != null)
            {
                picAnh.Image = BytesToImage(anhs[cbxTenHang.SelectedIndex]);
                lblChuoiCapNhatAnh.Visible = false;
            }
            else
            {
                picAnh.Image = QuanLiBanSach.Properties.Resources.bookmacdinh;
                lblChuoiCapNhatAnh.Visible = true;
            }
        }

        public void LoadDSMatHang()
        {
            if (dtDsMatHang != null && dtDsMatHang.Rows.Count > 0)
            {
                for (int i = 0; i < dtDsMatHang.Rows.Count; i++)
                {
                    float giaBan = 0;
                    int sl = 0;
                    if (dtDsMatHang.Rows[i]["gia_ban"].ToString() != "")
                        giaBan = float.Parse(dtDsMatHang.Rows[i]["gia_ban"].ToString());
                    if (dtDsMatHang.Rows[i]["so_luong_ban"].ToString() != "")
                        sl = int.Parse(dtDsMatHang.Rows[i]["so_luong_ban"].ToString());
                    byte[] anh = null;
                    if (dtDsMatHang.Rows[i]["anh"].ToString() != "")
                        anh = (byte[])dtDsMatHang.Rows[i]["anh"];
                    anhs.Add(anh);
                    soLuongs.Add(sl);
                    giaBans.Add(giaBan);
                }
            }
        }
        public void RestData()
        {
            cbxTenHang.Text = "";
            lblSoLuongKho.Text = "";
            txtSoLuong.Text = "";
            txtGiaBan.Text = "";
            picAnh.Image = QuanLiBanSach.Properties.Resources.bookmacdinh;
        }

        public void ResetNhap()
        {
            cbxTenHang.Enabled = true;
            txtGiaBan.Enabled = true;
            txtSoLuong.Enabled = true;
        }

        public void ResetValueList()
        {
            giaBans.Clear();
            anhs.Clear();
            flChinh.Controls.Clear();
            fls.Clear();
            tenHangSends.Clear();
            maHangSends.Clear();
            giaBanSends.Clear();
            soLuongSends.Clear();
            anhSends.Clear();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetNhap();
            RestData();
        }

        public void LoadLai()
        {
            ResetValueList();
            RestData();
            ResetNhap();
            dtDsMatHang = matHang.DsMatHang();
            LoadDSMatHang();
            LoadMatHang();
        }

        public Image BytesToImage(byte[] imageRaw)
        {
            MemoryStream ms = new MemoryStream(imageRaw);
            Image img = Image.FromStream(ms);
            return img;
        }

        public byte[] ImgToByArray(Image img)
        {
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }

        [Obsolete]
        private void btnLuu_Click(object sender, EventArgs e)
        {
            errSach.Clear();
            int soLuong;
            float giaBan;
            bool ketQua;
            if (cbxTenHang.Text == "")
                errSach.SetError(palTenHang, "Vui Lòng Chọn Mặt Hàng!");
            else if (txtSoLuong.Text == "")
                errSach.SetError(palSoLuong, "Vui Lòng Nhập Số Lượng");
            else if (txtGiaBan.Text == "")
                errSach.SetError(palGiaBan, "Vui Lòng Nhập Giá Bán");
            else if (!int.TryParse(txtSoLuong.Text, out soLuong))
                errSach.SetError(palSoLuong, "Trường Nhập Không Đúng!");
            else if (!float.TryParse(txtGiaBan.Text, out giaBan))
                errSach.SetError(palGiaBan, "Trường Nhập Không Đúng!");
            else if (soLuong > int.Parse(lblSoLuongKho.Text))
                errSach.SetError(palSoLuong, "Số Lượng Không Đáp Ứng");
            else
            {
                int soLuongConLai = soLuongTrongKho - soLuong;
                Image img = QuanLiBanSach.Properties.Resources.sach2;
                DialogResult result = MessageBox.Show("Bạn Có Muốn Thêm Sách Lên Cửa Hàng Không!", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string maHang = cbxTenHang.Text.Split('|')[0].Trim();
                    ketQua = matHang.DuaMatHangLenCuaHang(maHang, giaBan, soLuong);
                    if (ketQua)
                    {
                        chiTietNhapHang.CapNhatLaiSoLuongKho(maHang, soLuongConLai);
                        if (dem == 0)
                            matHang.LuuAnhSach(maHang, ImgToByArray(img));
                        else
                            matHang.LuuAnhSach(maHang, ImgToByArray(picAnh.Image));
                            
                        MessageBox.Show("Thêm Sách Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadLai();
                    }
                }
                btnXoa.Enabled = true;
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnBoQua.Enabled = false;
                btnLuu.Enabled = false;
            }
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(dtDsMatHangTrongCuaHang.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtGiaBan.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            errSach.Clear();
            int soLuong;
            float giaBan;
            bool ketQua;
            if (txtSoLuong.Text == "")
                errSach.SetError(palSoLuong, "Vui Lòng Nhập Số Lượng");
            else if (txtGiaBan.Text == "")
                errSach.SetError(palGiaBan, "Vui Lòng Nhập Giá Bán");
            else if (!int.TryParse(txtSoLuong.Text, out soLuong))
                errSach.SetError(palSoLuong, "Trường Nhập Không Đúng!");
            else if (!float.TryParse(txtGiaBan.Text, out giaBan))
                errSach.SetError(palGiaBan, "Trường Nhập Không Đúng!");
            else if (soLuongCuaSach + soLuongTrongKho < soLuong)
                errSach.SetError(palSoLuong, "Số Lượng Không Đáp Ứng");
            else
            {
                DialogResult result = MessageBox.Show("Bạn Có Chắc Chắn Cập Nhật Không!", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string maHang = cbxTenHang.Text.Split('|')[0].Trim();
                    int slVeKho = soLuongCuaSach - soLuong;
                    ketQua = matHang.CapNhatMatHanng(maHang, giaBan, soLuong);
                    chiTietNhapHang.CapNhatLaiSoLuongKhoKhiThayDoiSoLuongTrongCuaHang(maHang, slVeKho);
                    if(dem != 0)
                        matHang.LuuAnhSach(maHang, ImgToByArray(picAnh.Image));
                    if (ketQua)
                    {
                        MessageBox.Show("Bạn Đã Cập Nhật Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                }
                LoadLai();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            bool ketQua;
            DialogResult result = MessageBox.Show("Bạn Có Chắc Chắn Xóa Sách Này Trên Của Hàng?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                string maHang = cbxTenHang.Text.Split('|')[0].Trim();
                chiTietNhapHang.CapNhatLaiSoLuongKhoKhiThayDoiSoLuongTrongCuaHang(maHang, soLuongCuaSach);
                ketQua = matHang.XoaMatHangTrongCuaHang(maHang);
                if (ketQua)
                {
                    MessageBox.Show("Xóa Sách Khỏi Cửa Hàng Thành Công!","Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadLai();
                }
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            errSach.Clear();
            RestData();
            ResetNhap();
            picAnh.Enabled = true;
            lblChuoiCapNhatAnh.Visible = true;
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
        private void TimKiem(string timkiem)
        {
            if (timkiem.Equals("Tìm Kiếm"))
                timkiem = "";
            string timkiemFomat = timkiem.Trim().ToLower();
            for (int i = 0; i < fls.Count; i++)
            {
                FlowLayoutPanel flowLayoutPanel = fls[i];
                bool containsValue = false;
                foreach (Control control in flowLayoutPanel.Controls)
                {
                    if (cbxTimKiem.SelectedIndex == 0)
                    {
                        if (tenHangSends[i].ToLower().Contains(timkiemFomat))
                        {
                            containsValue = true;
                            break;
                        }
                    }
                    else if (cbxTimKiem.SelectedIndex == 1)
                    {
                        if (giaBanSends[i].ToString().ToLower().Contains(timkiemFomat))
                        {
                            containsValue = true;
                            break;
                        }
                    }
                    else if (cbxTimKiem.SelectedIndex == 2)
                    {
                        if (soLuongSends[i].ToString().ToLower().Contains(timkiemFomat))
                        {
                            containsValue = true;
                            break;
                        }
                    }
                }
                flowLayoutPanel.Visible = containsValue;
            }
        }
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKiem.Text != "" && cbxTimKiem.SelectedIndex != -1)
            {
                TimKiem(txtTimKiem.Text);
            }
            else if (txtTimKiem.Text == "")
            {
                foreach (FlowLayoutPanel flowLayoutPanel in fls)
                    flowLayoutPanel.Visible = true;
            }
        }
    }
}
