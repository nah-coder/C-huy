namespace QuanLiBanSach
{
    partial class frmThongKeDoanhThu
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.palChart = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbxChuKi = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1370, 80);
            this.panel1.TabIndex = 0;
            // 
            // palChart
            // 
            this.palChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.palChart.Location = new System.Drawing.Point(0, 80);
            this.palChart.Name = "palChart";
            this.palChart.Size = new System.Drawing.Size(1370, 641);
            this.palChart.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cbxChuKi);
            this.panel3.Location = new System.Drawing.Point(47, 30);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(180, 35);
            this.panel3.TabIndex = 5;
            // 
            // cbxChuKi
            // 
            this.cbxChuKi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxChuKi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxChuKi.FormattingEnabled = true;
            this.cbxChuKi.Items.AddRange(new object[] {
            "Theo Tháng",
            "Theo Năm"});
            this.cbxChuKi.Location = new System.Drawing.Point(4, 3);
            this.cbxChuKi.Name = "cbxChuKi";
            this.cbxChuKi.Size = new System.Drawing.Size(173, 30);
            this.cbxChuKi.TabIndex = 1;
            this.cbxChuKi.Text = "Theo Tháng";
            this.cbxChuKi.SelectedIndexChanged += new System.EventHandler(this.cbxChuKi_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Chọn chu kì";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmThongKeDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 721);
            this.Controls.Add(this.palChart);
            this.Controls.Add(this.panel1);
            this.Name = "frmThongKeDoanhThu";
            this.Text = "frmThongKeDoanhThu";
            this.Load += new System.EventHandler(this.frmThongKeDoanhThu_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel palChart;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cbxChuKi;
        private System.Windows.Forms.Label label1;
    }
}