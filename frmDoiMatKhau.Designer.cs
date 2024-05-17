namespace QuanLiBanSach
{
    partial class frmDoiMatKhau
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
            this.components = new System.ComponentModel.Container();
            this.grpQuenMatKhau = new System.Windows.Forms.GroupBox();
            this.palMkMoiNhapLai = new System.Windows.Forms.Panel();
            this.lblShowPassNhapLai = new System.Windows.Forms.Label();
            this.txtMKNhapLai = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.palMkMoi = new System.Windows.Forms.Panel();
            this.lblShowPasswwordMoi = new System.Windows.Forms.Label();
            this.txtMatKhauMoi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.palMkHienTai = new System.Windows.Forms.Panel();
            this.lblShowMkHienTai = new System.Windows.Forms.Label();
            this.txtMKHienTai = new System.Windows.Forms.TextBox();
            this.btnXacNhanLayLaiMK = new System.Windows.Forms.Button();
            this.lblMKHienTai = new System.Windows.Forms.Label();
            this.errCheck = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpQuenMatKhau.SuspendLayout();
            this.palMkMoiNhapLai.SuspendLayout();
            this.palMkMoi.SuspendLayout();
            this.palMkHienTai.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errCheck)).BeginInit();
            this.SuspendLayout();
            // 
            // grpQuenMatKhau
            // 
            this.grpQuenMatKhau.Controls.Add(this.palMkMoiNhapLai);
            this.grpQuenMatKhau.Controls.Add(this.label3);
            this.grpQuenMatKhau.Controls.Add(this.palMkMoi);
            this.grpQuenMatKhau.Controls.Add(this.label2);
            this.grpQuenMatKhau.Controls.Add(this.palMkHienTai);
            this.grpQuenMatKhau.Controls.Add(this.btnXacNhanLayLaiMK);
            this.grpQuenMatKhau.Controls.Add(this.lblMKHienTai);
            this.grpQuenMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpQuenMatKhau.Location = new System.Drawing.Point(47, 19);
            this.grpQuenMatKhau.Name = "grpQuenMatKhau";
            this.grpQuenMatKhau.Size = new System.Drawing.Size(513, 396);
            this.grpQuenMatKhau.TabIndex = 1;
            this.grpQuenMatKhau.TabStop = false;
            this.grpQuenMatKhau.Text = "Đổi Mật Khẩu";
            // 
            // palMkMoiNhapLai
            // 
            this.palMkMoiNhapLai.BackColor = System.Drawing.SystemColors.Window;
            this.palMkMoiNhapLai.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.palMkMoiNhapLai.Controls.Add(this.lblShowPassNhapLai);
            this.palMkMoiNhapLai.Controls.Add(this.txtMKNhapLai);
            this.palMkMoiNhapLai.Location = new System.Drawing.Point(185, 218);
            this.palMkMoiNhapLai.Name = "palMkMoiNhapLai";
            this.palMkMoiNhapLai.Size = new System.Drawing.Size(293, 43);
            this.palMkMoiNhapLai.TabIndex = 3;
            // 
            // lblShowPassNhapLai
            // 
            this.lblShowPassNhapLai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblShowPassNhapLai.Image = global::QuanLiBanSach.Properties.Resources.lock16;
            this.lblShowPassNhapLai.Location = new System.Drawing.Point(249, 0);
            this.lblShowPassNhapLai.Name = "lblShowPassNhapLai";
            this.lblShowPassNhapLai.Size = new System.Drawing.Size(42, 34);
            this.lblShowPassNhapLai.TabIndex = 4;
            this.lblShowPassNhapLai.Click += new System.EventHandler(this.lblShowPassNhapLai_Click);
            // 
            // txtMKNhapLai
            // 
            this.txtMKNhapLai.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMKNhapLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMKNhapLai.Location = new System.Drawing.Point(10, 11);
            this.txtMKNhapLai.Name = "txtMKNhapLai";
            this.txtMKNhapLai.PasswordChar = '*';
            this.txtMKNhapLai.Size = new System.Drawing.Size(239, 17);
            this.txtMKNhapLai.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(13, 227);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 27);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nhập Lại Mật Khẩu:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // palMkMoi
            // 
            this.palMkMoi.BackColor = System.Drawing.SystemColors.Window;
            this.palMkMoi.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.palMkMoi.Controls.Add(this.lblShowPasswwordMoi);
            this.palMkMoi.Controls.Add(this.txtMatKhauMoi);
            this.palMkMoi.Location = new System.Drawing.Point(185, 128);
            this.palMkMoi.Name = "palMkMoi";
            this.palMkMoi.Size = new System.Drawing.Size(293, 43);
            this.palMkMoi.TabIndex = 3;
            // 
            // lblShowPasswwordMoi
            // 
            this.lblShowPasswwordMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblShowPasswwordMoi.Image = global::QuanLiBanSach.Properties.Resources.lock16;
            this.lblShowPasswwordMoi.Location = new System.Drawing.Point(249, 0);
            this.lblShowPasswwordMoi.Name = "lblShowPasswwordMoi";
            this.lblShowPasswwordMoi.Size = new System.Drawing.Size(42, 34);
            this.lblShowPasswwordMoi.TabIndex = 3;
            this.lblShowPasswwordMoi.Click += new System.EventHandler(this.lblShowPasswwordMoi_Click);
            // 
            // txtMatKhauMoi
            // 
            this.txtMatKhauMoi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMatKhauMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhauMoi.Location = new System.Drawing.Point(10, 11);
            this.txtMatKhauMoi.Name = "txtMatKhauMoi";
            this.txtMatKhauMoi.PasswordChar = '*';
            this.txtMatKhauMoi.Size = new System.Drawing.Size(239, 17);
            this.txtMatKhauMoi.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mật Khẩu Mới:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // palMkHienTai
            // 
            this.palMkHienTai.BackColor = System.Drawing.SystemColors.Window;
            this.palMkHienTai.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.palMkHienTai.Controls.Add(this.lblShowMkHienTai);
            this.palMkHienTai.Controls.Add(this.txtMKHienTai);
            this.palMkHienTai.Location = new System.Drawing.Point(185, 37);
            this.palMkHienTai.Name = "palMkHienTai";
            this.palMkHienTai.Size = new System.Drawing.Size(293, 43);
            this.palMkHienTai.TabIndex = 1;
            // 
            // lblShowMkHienTai
            // 
            this.lblShowMkHienTai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblShowMkHienTai.Image = global::QuanLiBanSach.Properties.Resources.lock16;
            this.lblShowMkHienTai.Location = new System.Drawing.Point(249, 3);
            this.lblShowMkHienTai.Name = "lblShowMkHienTai";
            this.lblShowMkHienTai.Size = new System.Drawing.Size(42, 34);
            this.lblShowMkHienTai.TabIndex = 4;
            this.lblShowMkHienTai.Click += new System.EventHandler(this.lblShowMkHienTai_Click);
            // 
            // txtMKHienTai
            // 
            this.txtMKHienTai.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMKHienTai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMKHienTai.Location = new System.Drawing.Point(10, 11);
            this.txtMKHienTai.Name = "txtMKHienTai";
            this.txtMKHienTai.PasswordChar = '*';
            this.txtMKHienTai.Size = new System.Drawing.Size(239, 17);
            this.txtMKHienTai.TabIndex = 0;
            // 
            // btnXacNhanLayLaiMK
            // 
            this.btnXacNhanLayLaiMK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(30)))));
            this.btnXacNhanLayLaiMK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXacNhanLayLaiMK.FlatAppearance.BorderSize = 0;
            this.btnXacNhanLayLaiMK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhanLayLaiMK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhanLayLaiMK.ForeColor = System.Drawing.Color.White;
            this.btnXacNhanLayLaiMK.Location = new System.Drawing.Point(185, 299);
            this.btnXacNhanLayLaiMK.Name = "btnXacNhanLayLaiMK";
            this.btnXacNhanLayLaiMK.Size = new System.Drawing.Size(293, 59);
            this.btnXacNhanLayLaiMK.TabIndex = 8;
            this.btnXacNhanLayLaiMK.Text = "Xác Nhận";
            this.btnXacNhanLayLaiMK.UseVisualStyleBackColor = false;
            this.btnXacNhanLayLaiMK.Click += new System.EventHandler(this.btnXacNhanLayLaiMK_Click);
            // 
            // lblMKHienTai
            // 
            this.lblMKHienTai.Location = new System.Drawing.Point(13, 46);
            this.lblMKHienTai.Name = "lblMKHienTai";
            this.lblMKHienTai.Size = new System.Drawing.Size(178, 27);
            this.lblMKHienTai.TabIndex = 0;
            this.lblMKHienTai.Text = "Mật Khẩu Hiện Tại:";
            this.lblMKHienTai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // errCheck
            // 
            this.errCheck.ContainerControl = this;
            // 
            // frmDoiMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 437);
            this.Controls.Add(this.grpQuenMatKhau);
            this.Name = "frmDoiMatKhau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đổi Mật Khẩu";
            this.Load += new System.EventHandler(this.frmDoiMatKhau_Load);
            this.grpQuenMatKhau.ResumeLayout(false);
            this.palMkMoiNhapLai.ResumeLayout(false);
            this.palMkMoiNhapLai.PerformLayout();
            this.palMkMoi.ResumeLayout(false);
            this.palMkMoi.PerformLayout();
            this.palMkHienTai.ResumeLayout(false);
            this.palMkHienTai.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errCheck)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpQuenMatKhau;
        private System.Windows.Forms.Panel palMkMoiNhapLai;
        private System.Windows.Forms.Label lblShowPassNhapLai;
        private System.Windows.Forms.TextBox txtMKNhapLai;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel palMkMoi;
        private System.Windows.Forms.Label lblShowPasswwordMoi;
        private System.Windows.Forms.TextBox txtMatKhauMoi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel palMkHienTai;
        private System.Windows.Forms.Label lblShowMkHienTai;
        private System.Windows.Forms.TextBox txtMKHienTai;
        private System.Windows.Forms.Button btnXacNhanLayLaiMK;
        private System.Windows.Forms.Label lblMKHienTai;
        private System.Windows.Forms.ErrorProvider errCheck;
    }
}