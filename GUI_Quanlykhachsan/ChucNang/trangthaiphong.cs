using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI_Quanlykhachsan.ChucNang
{
    public partial class trangthaiphong : UserControl
    {

        private int _borderRadius = 20; // Bán kính góc bo
        private string motaphong;
        public trangthaiphong(string tenphong, string mota, int trangthaip)
        {
            InitializeComponent();
            roomname.Text = tenphong;
            description.Text = mota;
            motaphong = mota;

            if (trangthaip == 1) // Nếu phòng trống
            {
                this.BackColor = Color.FromArgb(128, 255, 128);
                btnDat.Text = "Đặt Phòng";
            }
            else if (trangthaip == 2) // Nếu phòng đang được đặt trước
            {
                this.BackColor = Color.Yellow;
                btnDat.Text = "Nhận Phòng";

            }
            else // Nếu phòng đã được đặt (có người ở)
            {
                this.BackColor = Color.Red;
                btnDat.Text = "Trả Phòng";

            }
        }

        private void Room_Load(object sender, EventArgs e)
        {

        }
        private void Room_Click(object sender, EventArgs e)
        {

        }


        #region test_logic

        // Nút test
        //int a = 0;
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (btnDat.Text == "Đặt Phòng")
            {
                KhachHang khachHang = new KhachHang(nhanphong, dattruoc);
                khachHang.Show();
            }
            else if (btnDat.Text == "Nhận Phòng")
            {
                nhanphong();
            }
            else
            {
                ThanhToan traphongthanhtoan = new ThanhToan(traphong);
                traphongthanhtoan.Show();
            }
        }
        public void dattruoc()
        {
            btnDat.Text = "Nhận Phòng";
            description.Text = "Phòng được đặt trước";
            this.BackColor = Color.Yellow;
        }

        public void nhanphong()
        {
            btnDat.Text = "Trả phòng";
            description.Text = "Phòng đang được sử dụng";
            this.BackColor = Color.Red;
        }

        public void traphong()
        {
            btnDat.Text = "Đặt phòng";
            description.Text = motaphong;
            this.BackColor = Color.FromArgb(128, 255, 128);
        }
        #endregion
    }
}
