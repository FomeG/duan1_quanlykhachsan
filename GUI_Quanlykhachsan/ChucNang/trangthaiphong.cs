using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI_Quanlykhachsan.ChucNang
{
    public partial class trangthaiphong : UserControl
    {

        private int _borderRadius = 20; // Bán kính góc bo
        public trangthaiphong(string tenphong, string btnname, string mota)
        {
            InitializeComponent();
            //this.SetRoundedRegion();
            //this.Resize += new System.EventHandler(this.RoundedUserControl_Resize);

            roomname.Text = tenphong;
            btnDat.Text = btnname;
            description.Text = mota;

            //traphong();
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
            if (btnDat.Text == "Đặt phòng")
            {
                KhachHang khachHang = new KhachHang();
                khachHang.Show();
            }














            //if (btnDat.Text == "Đặt phòng")
            //{
            //    KhachHang a = new KhachHang(nhanphong, dattruoc);
            //    a.Show();
            //}
            //else if (btnDat.Text == "Trả phòng")
            //{
            //    ThanhToan frmtt = new ThanhToan(traphong);
            //    frmtt.Show();
            //}
            //else
            //{
            //    nhanphong();
            //}
            //a++;
            //if (a == 1)
            //{
            //    btnDat.Text = "Nhận Phòng";
            //    label2.Text = "Phòng được đặt trước";
            //    this.BackColor = Color.Yellow;
            //    KhachHang a = new KhachHang();
            //    a.Show();
            //}
            //else if (a == 2)
            //{
            //    btnDat.Text = "Trả phòng";
            //    label2.Text = "Phòng đang được sử dụng";
            //    this.BackColor = Color.Red;
            //}
            //else
            //{
            //    btnDat.Text = "Đặt phòng";
            //    label2.Text = "phòng trống";
            //    this.BackColor = Color.Green;
            //    a = 0;
            //    ThanhToan traphongthanhtoan = new ThanhToan();
            //    traphongthanhtoan.Show();
            //}
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
            description.Text = "phòng trống";
            this.BackColor = Color.Green;
        }
        #endregion
    }
}
