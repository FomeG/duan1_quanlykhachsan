using DTO_Quanly;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GUI_Quanlykhachsan.ChucNang
{
    public partial class QuanLyDatPhong : Form
    {
        public QuanLyDatPhong()
        {
            InitializeComponent();
            thunghiem();
            SoDoPhong.Controls.Clear();


            SoDoPhong.Controls.Clear();
            var listphong = from a in DTODB.db.phongs
                            join b in DTODB.db.loaiphongs
                            on a.loaiphong equals b.idloaiphong
                            select new
                            {
                                a,
                                b,
                            };


            foreach (var item in listphong)
            {
                trangthaiphong phong = new trangthaiphong(item.a.tenphong, "Đặt phòng", item.b.mota);
                SoDoPhong.Controls.Add(phong);
            }
        }

        public void thunghiem()
        {

        }

        private void QuanLyDatPhong_Load(object sender, EventArgs e)
        {

        }

        public void test()
        {
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            //KhachHang a = new KhachHang();
            //a.Show();
            //this.btnDatphong.Enabled = false;
            //a.FormClosed += (ggg, b) =>
            //{
            //    this.Show();
            //    this.btnDatphong.Enabled = true;
            //};
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        // Nút tải lại
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            SoDoPhong.Controls.Clear();
            var listphong = from a in DTODB.db.phongs
                            join b in DTODB.db.loaiphongs
                            on a.loaiphong equals b.idloaiphong
                            select new
                            {
                                a,
                                b,
                            };
            foreach (var item in listphong)
            {
                trangthaiphong phong = new trangthaiphong(item.a.tenphong, "Đặt phòng", item.b.mota);
                SoDoPhong.Controls.Add(phong);
            }
        }

        private void SoDoPhong_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
