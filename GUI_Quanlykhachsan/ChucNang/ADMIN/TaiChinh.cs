using DTO_Quanly;
using DTO_Quanly.Model.DB;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GUI_Quanlykhachsan.ChucNang.ADMIN
{
    public partial class TaiChinh : Form
    {
        public TaiChinh()
        {
            InitializeComponent();
            InitializeDatePickers();
        }
        private decimal loinhuan;
        private void InitializeDatePickers()
        {
            datePickerStart.Value = DateTime.Now.AddMonths(-1);
            datePickerEnd.Value = DateTime.Now;
        }
        private void LoadData(bool isAllTime = false)
        {
            loinhuan = 0;
            DateTime startDate, endDate;

            if (isAllTime)
            {
                startDate = DTODB.db.hoadons.Min(h => h.ngaytao).Date;
                endDate = DTODB.db.hoadons.Max(h => h.ngaytao).Date.AddDays(1).AddSeconds(-1);
            }
            else
            {
                startDate = datePickerStart.Value.Date;
                endDate = datePickerEnd.Value.Date.AddDays(1).AddSeconds(-1);
            }

            var data = DTODB.db.hoadons
                .Where(h => h.ngaytao >= startDate && h.ngaytao <= endDate)
                .OrderBy(h => h.ngaytao)
                .ToList();

            tonghd.Text = data.Count.ToString();
            foreach (var item in data)
            {
                loinhuan += item.tongtien;
            }
            tongdt.Text = loinhuan.ToString();


            gview1.DataSource = data;
            CreateChart(data, isAllTime);
        }

        private void CreateChart(List<hoadon> data, bool isAllTime)
        {
            IEnumerable<dynamic> groupedData;

            if (isAllTime)
            {
                groupedData = data
                    .GroupBy(h => new { h.ngaytao.Year, h.ngaytao.Month })
                    .Select(g => new
                    {
                        Date = new DateTime(g.Key.Year, g.Key.Month, 1),
                        TotalAmount = g.Sum(h => h.tongtien)
                    })
                    .OrderBy(x => x.Date);
            }
            else
            {
                groupedData = data
                    .GroupBy(h => h.ngaytao.Date)
                    .Select(g => new { Date = g.Key, TotalAmount = g.Sum(h => h.tongtien) })
                    .OrderBy(x => x.Date);
            }

            var series = new LineSeries
            {
                Title = "Tổng Doanh Thu",
                Values = new ChartValues<decimal>(groupedData.Select(x => (decimal)x.TotalAmount)),
                PointGeometry = DefaultGeometries.Circle,
                PointGeometrySize = 15,
                LineSmoothness = 0
            };

            chart1.Series.Clear();
            chart1.Series.Add(series);

            chart1.AxisX.Clear();
            chart1.AxisY.Clear();

            chart1.AxisX.Add(new Axis
            {
                Title = isAllTime ? "Tháng" : "Ngày",
                Labels = isAllTime
                    ? groupedData.Select(x => ((DateTime)x.Date).ToString("MM/yyyy")).ToList()
                    : groupedData.Select(x => ((DateTime)x.Date).ToString("dd/MM/yyyy")).ToList(),
                Separator = new Separator
                {
                    Step = Math.Max(1, groupedData.Count() / 10)
                }
            });

            chart1.AxisY.Add(new Axis
            {
                Title = "Doanh Thu (VNĐ)",
                LabelFormatter = value => value.ToString("N0")
            });

            chart1.LegendLocation = LegendLocation.Top;

            series.DataLabels = true;
            series.LabelPoint = point => point.Y.ToString("N0");
        }

        private void TaiChinh_Load(object sender, EventArgs e)
        {
            LoadData(true);
        }
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            LoadData(true);
        }
    }
}
