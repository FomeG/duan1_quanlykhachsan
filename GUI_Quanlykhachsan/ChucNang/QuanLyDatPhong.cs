using DTO_Quanly;
using Guna.UI2.WinForms;
using System;
using System.Drawing;
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
            foreach (var item in DTODB.db.phongs.ToList())
            {
                trangthaiphong phong = new trangthaiphong(item.tenphong);
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

        private void button1_Click(object sender, EventArgs e)
        {
            Guna2Button button = (Guna2Button)this.Controls["Thuong1"];
            button.BackColor = SystemColors.ControlDark;
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        // Nút tải lại
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            SoDoPhong.Controls.Clear();
            foreach (var item in DTODB.db.phongs.ToList())
            {
                trangthaiphong phong = new trangthaiphong(item.tenphong);
                SoDoPhong.Controls.Add(phong);
            }
        }

        private void SoDoPhong_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
