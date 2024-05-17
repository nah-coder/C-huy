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
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLiBanSach
{
    public partial class frmThongKeDoanhThu : Form
    {
        private DataTable dtDoanhThuTheoThang = new DataTable();
        private DataTable dtDoanhThuTheoNam = new DataTable();
        private ChiTietBanHang chiTietBanHang = new ChiTietBanHang();
        private List<int> ngays = new List<int>();
        private List<int> ngayBans = new List<int>();
        private List<int> thangBans = new List<int>();
        private List<float> thanhTienNgays = new List<float>();
        private List<float> thanhTienThangs = new List<float>();
        private Chart chartTheoThang;
        private Chart chartTheoNam;
        public frmThongKeDoanhThu()
        {
            InitializeComponent();
        }
        
        private void frmThongKeDoanhThu_Load(object sender, EventArgs e)
        {
            LoadNgayVaThanhTien();
            LoadThangVaThanhTien();
            ChartColumsTheoThang();
            ChartColumsTheoNam();
        }
        private void LoadNgayVaThanhTien()
        {
            dtDoanhThuTheoThang = chiTietBanHang.DSDoanhThuTheoThang();
            if (dtDoanhThuTheoThang != null)
            {
                for (int i = 0; i < dtDoanhThuTheoThang.Rows.Count; i++)
                {
                    int ngayBan = int.Parse(dtDoanhThuTheoThang.Rows[i]["ngay"].ToString());
                    float thanhTien = float.Parse(dtDoanhThuTheoThang.Rows[i]["thanh_tien"].ToString());
                    ngayBans.Add(ngayBan);
                    thanhTienNgays.Add(thanhTien);
                }
            }
        }

        private void LoadThangVaThanhTien()
        {
            dtDoanhThuTheoNam = chiTietBanHang.DSDoanhThuTheoNam();
            if (dtDoanhThuTheoNam.Rows.Count > 0)
            {
                for (int i = 0; i < dtDoanhThuTheoNam.Rows.Count; i++)
                {
                    int thang = int.Parse(dtDoanhThuTheoNam.Rows[i]["thang"].ToString());
                    float thanhTien = float.Parse(dtDoanhThuTheoNam.Rows[i]["thanh_tien"].ToString());
                    thangBans.Add(thang);
                    thanhTienThangs.Add(thanhTien);
                }
            }
        }

        private void ChartColumsTheoThang()
        {
            chartTheoThang = new Chart();
            chartTheoThang.Dock = DockStyle.Fill;
            chartTheoThang.Size = new Size(1000, 462);
            DateTime dateTimeNow = DateTime.Now;
            string thangNow = dateTimeNow.Month.ToString();
            string namNow = dateTimeNow.Year.ToString();
            int soNgayTrongThang = DateTime.DaysInMonth(int.Parse(namNow), int.Parse(thangNow));
            for (int i = 1; i < soNgayTrongThang; i++)
                ngays.Add(i);
            Title title = chartTheoThang.Titles.Add($"Đồ Thị Doanh Thu Tháng {thangNow}/{namNow}");
            title.Font = new Font("Arial", 10, FontStyle.Bold);
            Series series = new Series();
            series.ChartType = SeriesChartType.Column;
            for (int i = 0; i < ngays.Count; i++)
            {
                for (int j = 0; j < ngayBans.Count; j++)
                {
                    float tt = 0;
                    if (ngays[i] == ngayBans[j])
                    {
                        tt = thanhTienNgays[j];
                    }
                    series.Points.AddXY(ngays[i], tt);
                }
            }
            series.IsVisibleInLegend = false;
            chartTheoThang.ChartAreas.Add(new ChartArea("ChartArea"));
            chartTheoThang.ChartAreas["ChartArea"].AxisX.Interval = 3;
            chartTheoThang.ChartAreas["ChartArea"].AxisX.Minimum = 1;
            chartTheoThang.ChartAreas["ChartArea"].AxisX.MajorGrid.Enabled = false;
            chartTheoThang.Series.Add(series);
            palChart.Controls.Add(chartTheoThang);
        }
        private void ChartColumsTheoNam()
        {
            chartTheoNam = new Chart();
            chartTheoNam.Dock = DockStyle.Fill;
            DateTime dateTimeNow = DateTime.Now;
            Title title = chartTheoNam.Titles.Add($"Đồ Thị Doanh Thu Năm {dateTimeNow.Year}");
            title.Font = new Font("Arial", 10, FontStyle.Bold);
            Series series = new Series();
            series.ChartType = SeriesChartType.Column;

            for (int i = 1; i < 12; i++)
            {
                for (int j = 0; j < thangBans.Count; j++)
                {
                    float tt = 0;
                    if (i == thangBans[j])
                    {
                        tt = thanhTienThangs[j];
                    }
                    series.Points.AddXY(i, tt);
                }
            }

            series.IsVisibleInLegend = false;
            chartTheoNam.ChartAreas.Add(new ChartArea("ChartArea"));
            chartTheoNam.ChartAreas["ChartArea"].AxisX.Minimum = 1;
            chartTheoNam.ChartAreas["ChartArea"].AxisX.MajorGrid.Enabled = false;
            chartTheoNam.Series.Add(series);
            palChart.Controls.Add(chartTheoNam);
        }
        private void cbxChuKi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxChuKi.SelectedIndex == 0)
            {
                chartTheoNam.Visible = false;
                chartTheoThang.Visible = true;
            }
            else
            {
                chartTheoThang.Visible = false;
                chartTheoNam.Visible = true;
            }
        }
    }
}
