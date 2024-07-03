using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GUI_Quanlykhachsan.ChucNang
{
    public partial class Room : UserControl
    {

        private int _borderRadius = 20; // Bán kính góc bo
        public Room(string tenphong)
        {
            InitializeComponent();
            this.SetRoundedRegion();
            this.Resize += new System.EventHandler(this.RoundedUserControl_Resize);

            roomname.Text = tenphong;
        }

        private void Room_Load(object sender, EventArgs e)
        {

        }
        private void Room_Click(object sender, EventArgs e)
        {
            SoLuong form = new SoLuong();
            form.Show();
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


        // Nút test
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
