using DTO_Quanly;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GUI_Quanlykhachsan.ChucNang
{
    public partial class QuanLyDatPhong : Form
    {
        private bool IsSeached;

        public QuanLyDatPhong()
        {
            InitializeComponent();
            SoDoPhong.Controls.Clear();
            hienthiphong();

            IsSeached = false;
        }


        public void hienthiphong()
        {
            SoDoPhong.Controls.Clear();

            var listp = DTODB.db.view_trangthai_phong_hientai.ToList();
            foreach (var item in listp)
            {
                SoDoPhong.Controls.Add(new trangthaiphong(item.tenphong, item.mota, item.trangthai, item.idphong, 2, false, null, null));
            }

            slgptrong.Text = DTODB.db.view_trangthai_phong_hientai.Where(x => x.trangthai_text == "Trống").ToList().Count().ToString();
            slgpsudung.Text = DTODB.db.view_trangthai_phong_hientai.Where(x => x.trangthai_text == "Đã đặt").ToList().Count().ToString();

        }
        // Nút tải lại
        public void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            hienthiphong();
        }



        private string ngaydenStr;
        private string ngaydiStr;
        public void timkiem(DateTime ngayden, DateTime ngaydi)
        {
            SoDoPhong.Controls.Clear();
            ngaydenStr = ngayden.ToString("yyyy-MM-dd HH:mm:ss");
            ngaydiStr = ngaydi.ToString("yyyy-MM-dd HH:mm:ss");
            var listptimkiem = DTODB.db.kiemtra_trangthai_phong(ngaydenStr, ngaydiStr).ToList();

            foreach (var item in listptimkiem)
            {
                trangthaiphong phong = new trangthaiphong(item.tenphong, item.mota, item.trangthai, item.idphong, item.trangthai != 0 ? 1 : 2, IsSeached, ngayden.Date, ngaydi.Date);
                SoDoPhong.Controls.Add(phong);
            }

            slgptrong.Text = DTODB.db.kiemtra_trangthai_phong(ngaydenStr, ngaydiStr).Where(x => x.trangthai_text == "Trống").ToList().Count.ToString();
            slgpsudung.Text = DTODB.db.kiemtra_trangthai_phong(ngaydenStr, ngaydiStr).Where(x => x.trangthai_text == "Đã đặt").ToList().Count.ToString();
            IsSeached = true;
        }
    }
}
