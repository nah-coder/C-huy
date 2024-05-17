namespace QuanLiBanSach
{
    partial class frmChinh
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChinh));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.trangChuMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.danhMụcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sáchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhanVienMenuDanhMuc = new System.Windows.Forms.ToolStripMenuItem();
            this.KhachHangMenuDanhMuc = new System.Windows.Forms.ToolStripMenuItem();
            this.NhaCungCapMenuDanhMuc = new System.Windows.Forms.ToolStripMenuItem();
            this.LapPhieuNhapMenuNhapHang = new System.Windows.Forms.ToolStripMenuItem();
            this.phieuNhapMenuNhapHang = new System.Windows.Forms.ToolStripMenuItem();
            this.hoaDonMenuNhapHang = new System.Windows.Forms.ToolStripMenuItem();
            this.LapDonHangMenuBanHang = new System.Windows.Forms.ToolStripMenuItem();
            this.LapDonBanHangMenuBanHang = new System.Windows.Forms.ToolStripMenuItem();
            this.hoaDonMenuBanHang = new System.Windows.Forms.ToolStripMenuItem();
            this.baoCaoThongKeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.thongKeMatHangMenuBaoCao = new System.Windows.Forms.ToolStripMenuItem();
            this.thongKeDoanhThuMenuBaoCao = new System.Windows.Forms.ToolStripMenuItem();
            this.heThongMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.thongTinMenuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.btnThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.palChinh = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.palChinh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trangChuMenu,
            this.danhMụcToolStripMenuItem,
            this.LapPhieuNhapMenuNhapHang,
            this.LapDonHangMenuBanHang,
            this.baoCaoThongKeMenu,
            this.heThongMenu,
            this.btnThoat});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1388, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // trangChuMenu
            // 
            this.trangChuMenu.Name = "trangChuMenu";
            this.trangChuMenu.Size = new System.Drawing.Size(94, 24);
            this.trangChuMenu.Text = "Trang Chủ";
            this.trangChuMenu.Click += new System.EventHandler(this.trangChuMenu_Click);
            // 
            // danhMụcToolStripMenuItem
            // 
            this.danhMụcToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sáchToolStripMenuItem,
            this.nhanVienMenuDanhMuc,
            this.KhachHangMenuDanhMuc,
            this.NhaCungCapMenuDanhMuc});
            this.danhMụcToolStripMenuItem.Name = "danhMụcToolStripMenuItem";
            this.danhMụcToolStripMenuItem.Size = new System.Drawing.Size(94, 24);
            this.danhMụcToolStripMenuItem.Text = "Danh Mục";
            // 
            // sáchToolStripMenuItem
            // 
            this.sáchToolStripMenuItem.Name = "sáchToolStripMenuItem";
            this.sáchToolStripMenuItem.Size = new System.Drawing.Size(266, 26);
            this.sáchToolStripMenuItem.Text = "Danh Mục Sách";
            this.sáchToolStripMenuItem.Click += new System.EventHandler(this.sáchToolStripMenuItem_Click);
            // 
            // nhanVienMenuDanhMuc
            // 
            this.nhanVienMenuDanhMuc.Name = "nhanVienMenuDanhMuc";
            this.nhanVienMenuDanhMuc.Size = new System.Drawing.Size(266, 26);
            this.nhanVienMenuDanhMuc.Text = "Danh Mục Nhân Viên";
            this.nhanVienMenuDanhMuc.Click += new System.EventHandler(this.nhanVienMenuDanhMuc_Click);
            // 
            // KhachHangMenuDanhMuc
            // 
            this.KhachHangMenuDanhMuc.Name = "KhachHangMenuDanhMuc";
            this.KhachHangMenuDanhMuc.Size = new System.Drawing.Size(266, 26);
            this.KhachHangMenuDanhMuc.Text = "Danh Mục Khách Hàng";
            this.KhachHangMenuDanhMuc.Click += new System.EventHandler(this.KhachHangMenuDanhMuc_Click);
            // 
            // NhaCungCapMenuDanhMuc
            // 
            this.NhaCungCapMenuDanhMuc.Name = "NhaCungCapMenuDanhMuc";
            this.NhaCungCapMenuDanhMuc.Size = new System.Drawing.Size(266, 26);
            this.NhaCungCapMenuDanhMuc.Text = "Danh Mục Nhà Cung Cấp";
            this.NhaCungCapMenuDanhMuc.Click += new System.EventHandler(this.NhaCungCapMenuDanhMuc_Click);
            // 
            // LapPhieuNhapMenuNhapHang
            // 
            this.LapPhieuNhapMenuNhapHang.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.phieuNhapMenuNhapHang,
            this.hoaDonMenuNhapHang});
            this.LapPhieuNhapMenuNhapHang.Name = "LapPhieuNhapMenuNhapHang";
            this.LapPhieuNhapMenuNhapHang.Size = new System.Drawing.Size(100, 24);
            this.LapPhieuNhapMenuNhapHang.Text = "Nhập hàng";
            // 
            // phieuNhapMenuNhapHang
            // 
            this.phieuNhapMenuNhapHang.Name = "phieuNhapMenuNhapHang";
            this.phieuNhapMenuNhapHang.Size = new System.Drawing.Size(202, 26);
            this.phieuNhapMenuNhapHang.Text = "Lập Phiếu Nhập";
            this.phieuNhapMenuNhapHang.Click += new System.EventHandler(this.phieuNhapMenuNhapHang_Click);
            // 
            // hoaDonMenuNhapHang
            // 
            this.hoaDonMenuNhapHang.Name = "hoaDonMenuNhapHang";
            this.hoaDonMenuNhapHang.Size = new System.Drawing.Size(202, 26);
            this.hoaDonMenuNhapHang.Text = "Hóa Đơn";
            this.hoaDonMenuNhapHang.Click += new System.EventHandler(this.hoaDonMenuNhapHang_Click);
            // 
            // LapDonHangMenuBanHang
            // 
            this.LapDonHangMenuBanHang.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LapDonBanHangMenuBanHang,
            this.hoaDonMenuBanHang});
            this.LapDonHangMenuBanHang.Name = "LapDonHangMenuBanHang";
            this.LapDonHangMenuBanHang.Size = new System.Drawing.Size(91, 24);
            this.LapDonHangMenuBanHang.Text = "Bán Hàng";
            // 
            // LapDonBanHangMenuBanHang
            // 
            this.LapDonBanHangMenuBanHang.Name = "LapDonBanHangMenuBanHang";
            this.LapDonBanHangMenuBanHang.Size = new System.Drawing.Size(220, 26);
            this.LapDonBanHangMenuBanHang.Text = "Lập Đơn Đặt Hàng";
            this.LapDonBanHangMenuBanHang.Click += new System.EventHandler(this.LapDonBanHangMenuBanHang_Click);
            // 
            // hoaDonMenuBanHang
            // 
            this.hoaDonMenuBanHang.Name = "hoaDonMenuBanHang";
            this.hoaDonMenuBanHang.Size = new System.Drawing.Size(220, 26);
            this.hoaDonMenuBanHang.Text = "Hóa Đơn";
            this.hoaDonMenuBanHang.Click += new System.EventHandler(this.hoaDonMenuBanHang_Click);
            // 
            // baoCaoThongKeMenu
            // 
            this.baoCaoThongKeMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thongKeMatHangMenuBaoCao,
            this.thongKeDoanhThuMenuBaoCao});
            this.baoCaoThongKeMenu.Name = "baoCaoThongKeMenu";
            this.baoCaoThongKeMenu.Size = new System.Drawing.Size(151, 24);
            this.baoCaoThongKeMenu.Text = "Báo Cáo Thống Kê";
            // 
            // thongKeMatHangMenuBaoCao
            // 
            this.thongKeMatHangMenuBaoCao.Name = "thongKeMatHangMenuBaoCao";
            this.thongKeMatHangMenuBaoCao.Size = new System.Drawing.Size(290, 26);
            this.thongKeMatHangMenuBaoCao.Text = "Thống Kê  Mặt Hàng Đã Bán";
            this.thongKeMatHangMenuBaoCao.Click += new System.EventHandler(this.thongKeMatHangMenuBaoCao_Click);
            // 
            // thongKeDoanhThuMenuBaoCao
            // 
            this.thongKeDoanhThuMenuBaoCao.Name = "thongKeDoanhThuMenuBaoCao";
            this.thongKeDoanhThuMenuBaoCao.Size = new System.Drawing.Size(290, 26);
            this.thongKeDoanhThuMenuBaoCao.Text = "Thống Kê Doanh Thu";
            this.thongKeDoanhThuMenuBaoCao.Click += new System.EventHandler(this.thongKeDoanhThuMenuBaoCao_Click);
            // 
            // heThongMenu
            // 
            this.heThongMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thongTinMenuHeThong,
            this.toolStripMenuItem1,
            this.btnDangXuat});
            this.heThongMenu.Name = "heThongMenu";
            this.heThongMenu.Size = new System.Drawing.Size(91, 24);
            this.heThongMenu.Text = "Hệ Thống";
            // 
            // thongTinMenuHeThong
            // 
            this.thongTinMenuHeThong.Name = "thongTinMenuHeThong";
            this.thongTinMenuHeThong.Size = new System.Drawing.Size(166, 26);
            this.thongTinMenuHeThong.Text = "Thông Tin";
            this.thongTinMenuHeThong.Click += new System.EventHandler(this.thongTinMenuHeThong_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(163, 6);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(166, 26);
            this.btnDangXuat.Text = "Đăng Xuất";
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(64, 24);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // palChinh
            // 
            this.palChinh.Controls.Add(this.pictureBox1);
            this.palChinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.palChinh.Location = new System.Drawing.Point(0, 28);
            this.palChinh.Name = "palChinh";
            this.palChinh.Size = new System.Drawing.Size(1388, 716);
            this.palChinh.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1388, 716);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frmChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1388, 744);
            this.Controls.Add(this.palChinh);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmChinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lí Bán Sách";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.palChinh.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem trangChuMenu;
        private System.Windows.Forms.ToolStripMenuItem danhMụcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LapPhieuNhapMenuNhapHang;
        private System.Windows.Forms.ToolStripMenuItem LapDonHangMenuBanHang;
        private System.Windows.Forms.ToolStripMenuItem baoCaoThongKeMenu;
        private System.Windows.Forms.ToolStripMenuItem heThongMenu;
        private System.Windows.Forms.ToolStripMenuItem sáchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhanVienMenuDanhMuc;
        private System.Windows.Forms.ToolStripMenuItem KhachHangMenuDanhMuc;
        private System.Windows.Forms.ToolStripMenuItem NhaCungCapMenuDanhMuc;
        private System.Windows.Forms.ToolStripMenuItem phieuNhapMenuNhapHang;
        private System.Windows.Forms.ToolStripMenuItem hoaDonMenuNhapHang;
        private System.Windows.Forms.ToolStripMenuItem LapDonBanHangMenuBanHang;
        private System.Windows.Forms.ToolStripMenuItem hoaDonMenuBanHang;
        private System.Windows.Forms.ToolStripMenuItem thongKeMatHangMenuBaoCao;
        private System.Windows.Forms.ToolStripMenuItem thongKeDoanhThuMenuBaoCao;
        private System.Windows.Forms.ToolStripMenuItem thongTinMenuHeThong;
        private System.Windows.Forms.ToolStripMenuItem btnThoat;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem btnDangXuat;
        private System.Windows.Forms.Panel palChinh;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

