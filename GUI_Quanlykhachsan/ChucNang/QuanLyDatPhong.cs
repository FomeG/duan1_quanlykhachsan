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
            hienthiphong();
        }


        public void hienthiphong()
        {
            SoDoPhong.Controls.Clear();
            foreach (var item in DTODB.db.view_trangthai_phong_hientai.ToList())
            {
                trangthaiphong phong = new trangthaiphong(item.tenphong, item.mota, item.trangthai, item.idphong);
                SoDoPhong.Controls.Add(phong);
            }
        }
        // Nút tải lại
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            hienthiphong();
        }

        public void timkiem(DateTime ngayden, DateTime ngaydi)
        {
            SoDoPhong.Controls.Clear();
            var listp = DTODB.db.kiemtra_trangthai_phong(ngayden, ngaydi).ToList();
            foreach (var item in listp)
            {
                trangthaiphong phong = new trangthaiphong(item.tenphong, item.mota, item.trangthai, item.idphong);
                SoDoPhong.Controls.Add(phong);
            }
        }
    }
}
