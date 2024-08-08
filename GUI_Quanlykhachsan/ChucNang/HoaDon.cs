using BUS_Quanly.Services.QuanLyDatPhong.DatTruoc_NhanP;
using DTO_Quanly;
using DTO_Quanly.Model.DB;
using DTO_Quanly.Transfer;
using System.Drawing;
using System;
using System.Linq;
using System.Windows.Forms;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;
using BUS_Quanly.Services.QuanLyDatPhong.ThanhToan_DV;

namespace GUI_Quanlykhachsan.ChucNang
{
    public partial class HoaDon : Form
    {
        public HoaDon()
        {
            InitializeComponent();
            loaddl();
        }
        private void HoaDon_Load(object sender, System.EventArgs e)
        {

        }

        public void loaddl()
        {
            var listnhanvien = DTODB.db.dichvus.Where(nv => nv.tt == false).ToList();
            gview1.DataSource = listnhanvien;

        }
        public bool checkkiemtra()
        {
            if (NgayDi.Value.Date <= NgayDen.Value.Date)
            {
                MessageBox.Show("Ngày đi không được nhỏ hơn ngày đến!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (checkkiemtra())
            {

            }
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            if (gview1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Vui lòng chọn hoá đơn");
            }
        }

        private void NgayDen_ValueChanged(object sender, EventArgs e)
        {

        }

        private void NgayDi_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
