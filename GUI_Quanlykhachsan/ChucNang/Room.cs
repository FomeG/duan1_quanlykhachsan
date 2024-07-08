using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GUI_Quanlykhachsan.ChucNang
{
    public partial class trangthaiphong : UserControl
    {

        private int _borderRadius = 20; // Bán kính góc bo
        public trangthaiphong(string tenphong)
        {
            InitializeComponent();
            this.SetRoundedRegion();
            this.Resize += new System.EventHandler(this.RoundedUserControl_Resize);

            roomname.Text = tenphong;

            //traphong();
        }

        private void Room_Load(object sender, EventArgs e)
        {

        }
        private void Room_Click(object sender, EventArgs e)
        {

        }



        #region Bo_Góc_Form
        private void SetRoundedRegion()
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, _borderRadius, _borderRadius, 180, 90);
                path.AddArc(this.Width - _borderRadius, 0, _borderRadius, _borderRadius, 270, 90);
                path.AddArc(this.Width - _borderRadius, this.Height - _borderRadius, _borderRadius, _borderRadius, 0, 90);
                path.AddArc(0, this.Height - _borderRadius, _borderRadius, _borderRadius, 90, 90);
                path.CloseFigure();

                this.Region = new Region(path);
            }
        }

        private void RoundedUserControl_Resize(object sender, System.EventArgs e)
        {
            this.SetRoundedRegion();
        }



        #endregion




        #region test_logic

        // Nút test
        //int a = 0;
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
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

        //public void dattruoc()
        //{
        //    btnDat.Text = "Nhận Phòng";
        //    label2.Text = "Phòng được đặt trước";
        //    this.BackColor = Color.Yellow;
        //}

        //public void nhanphong()
        //{
        //    btnDat.Text = "Trả phòng";
        //    label2.Text = "Phòng đang được sử dụng";
        //    this.BackColor = Color.Red;
        //}

        //public void traphong()
        //{
        //    btnDat.Text = "Đặt phòng";
        //    label2.Text = "phòng trống";
        //    this.BackColor = Color.Green;
        //}

        #endregion
    }
}
