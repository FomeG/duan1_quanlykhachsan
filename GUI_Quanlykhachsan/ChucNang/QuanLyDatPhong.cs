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
            SoDoPhong.Controls.Clear();


            SoDoPhong.Controls.Clear();

            var listphong = from a in DTODB.db.trangthaiphongs
                            join b in DTODB.db.phongs
                            on a.id equals b.trangthai
                            join c in DTODB.db.loaiphongs
                            on b.loaiphong equals c.idloaiphong
                            select new
                            {
                                a,
                                b,
                                c
                            };
            foreach (var item in listphong)
            {
                trangthaiphong phong = new trangthaiphong(item.b.tenphong, item.c.mota, item.a.id, item.b.idphong);
                SoDoPhong.Controls.Add(phong);
            }
        }

        // Nút tải lại
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            SoDoPhong.Controls.Clear();
            var listphong = from a in DTODB.db.trangthaiphongs
                            join b in DTODB.db.phongs
                            on a.id equals b.trangthai
                            join c in DTODB.db.loaiphongs
                            on b.loaiphong equals c.idloaiphong
                            select new
                            {
                                a,
                                b,
                                c
                            };


            foreach (var item in listphong)
            {
                trangthaiphong phong = new trangthaiphong(item.b.tenphong, item.c.mota, item.a.id, item.b.idphong);
                SoDoPhong.Controls.Add(phong);
            }
        }

    }
}
