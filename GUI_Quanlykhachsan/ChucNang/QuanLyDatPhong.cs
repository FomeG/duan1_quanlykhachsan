using DTO_Quanly;
using System;
using System.Linq;
using System.Web.UI;
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
               
                SoDoPhong.Controls.Add(new trangthaiphong(item.tenphong, item.mota, item.trangthai, item.idphong, 2, false, null,null));
            }

            //var phongddddd = DTODB.db.view_trangthai_phong_hientai.Where(x => x.idphong == 9).First();
            //SoDoPhong.Controls.Add(new trangthaiphong(phongddddd.tenphong, phongddddd.mota, phongddddd.trangthai, phongddddd.idphong, 2));

        }
        // Nút tải lại
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            hienthiphong();
        }

        private string ngaydenStr;
        private string ngaydiStr;
        public void timkiem(DateTime ngayden, DateTime ngaydi)
        {
            SoDoPhong.Controls.Clear();
            this.ngaydenStr = ngayden.ToString("yyyy-MM-dd HH:mm:ss");
            this.ngaydiStr = ngaydi.ToString("yyyy-MM-dd HH:mm:ss");
            var listptimkiem = DTODB.db.kiemtra_trangthai_phong(ngaydenStr, ngaydiStr).ToList();

            foreach (var item in listptimkiem)
            {
                trangthaiphong phong = new trangthaiphong(item.tenphong, item.mota, item.trangthai, item.idphong, item.trangthai != 0 ? 1 : 2, IsSeached, ngayden.Date, ngaydi.Date);
                SoDoPhong.Controls.Add(phong);
            }
            IsSeached = true;
        }
    }
}
