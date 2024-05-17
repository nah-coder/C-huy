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
    public partial class frmThongKeMatHangDaban : Form
    {
        private ChiTietBanHang chiTietBanHang = new ChiTietBanHang();
        private DataTable dtSachVaSoLuong = new DataTable();
        private DataTable dtSachBanNhieuNhat = new DataTable();
        public frmThongKeMatHangDaban()
        {
            InitializeComponent();
        }

        private void frmThongKeMatHangDaban_Load(object sender, EventArgs e)
        {
            dtSachVaSoLuong = chiTietBanHang.DanhSachSachVaSoLuongDaBan();
            dtSachBanNhieuNhat = chiTietBanHang.DanhSachSachDuocMuaNhieuNhat();
            PieChartSachBan();
            PieChartMuaNhieu();
        }
        private void PieChartSachBan()
        {
            if (dtSachVaSoLuong.Rows.Count > 0)
            {
                Series series = new Series();
                series.ChartType = SeriesChartType.Pie;
                for (int i = 0; i < dtSachVaSoLuong.Rows.Count; i++)
                {
                    string tenHang = dtSachVaSoLuong.Rows[i]["ten_hang"].ToString();
                    int soLuong = int.Parse(dtSachVaSoLuong.Rows[i]["so_luong"].ToString());
                    series.Points.AddXY(tenHang, soLuong);
                }
                series.Font = new Font("Arial", 9, FontStyle.Bold);
                series.IsValueShownAsLabel = true;
                chartSach.Series.Add(series);
            }
        }

        private void PieChartMuaNhieu()
        {
            if (dtSachBanNhieuNhat.Rows.Count > 0)
            {
                Series series = new Series();
                series.ChartType = SeriesChartType.Doughnut;
                for (int i = 0; i < dtSachBanNhieuNhat.Rows.Count; i++)
                {
                    string tenHang = dtSachBanNhieuNhat.Rows[i]["ten_hang"].ToString();
                    int soLuong = int.Parse(dtSachBanNhieuNhat.Rows[i]["so_luong"].ToString());
                    series.Points.AddXY(tenHang, soLuong);
                }
                series.Font = new Font("Arial", 9, FontStyle.Bold);
                series.IsValueShownAsLabel = true;
                chartSoLuong.Series.Add(series);
            }
        }
    }
}
