using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_Quanlykhachsan.ChucNang
{
    public partial class QuanLyDatPhong : Form
    {
        public QuanLyDatPhong()
        {
            InitializeComponent();
        }

        public void formdatphong()
        {
            SoLuong form = new SoLuong();
            form.Show();
        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false) Thuong1.FillColor = SystemColors.MenuHighlight;
            else
            {
                formdatphong();
                Thuong1.FillColor = SystemColors.Window;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == false) Thuong2.FillColor = SystemColors.MenuHighlight;
            else
            {
                formdatphong();
                Thuong2.FillColor = SystemColors.Window;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == false) Thuong3.FillColor = SystemColors.MenuHighlight;
            else
            {
                formdatphong();
                Thuong3.FillColor = SystemColors.Window;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == false) Thuong4.FillColor = SystemColors.MenuHighlight;
            else
            {
                formdatphong();
                Thuong4.FillColor = SystemColors.Window;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == false) Thuong5.FillColor = SystemColors.MenuHighlight;
            else
            {
                formdatphong();
                Thuong5.FillColor = SystemColors.Window;
            }
        }

        private void QuanLyDatPhong_Load(object sender, EventArgs e)
        {

        }

        public void test()
        {
            string[] phong = { "phong1", "phong2", "phong3", "phong4", "phong5", "phong6", "phong7", "phong8", "phong9", "phong10" };
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            KhachHang a = new KhachHang();
            a.Show();
            this.btnDatphong.Enabled = false;
            a.FormClosed += (ggg, b) =>
            {
                this.Show();
                this.btnDatphong.Enabled = true;
            };
        }
        public void test2()
        {
            // Duyệt qua các checkbox và kiểm tra trạng thái của chúng
            for (int i = 1; i <= 5; i++)
            {
                CheckBox checkBox = (CheckBox)this.Controls["checkBox" + i];
                Guna2Button button = (Guna2Button)this.Controls["Thuong" + i];

                if (checkBox.Checked)
                {
                    // Nếu checkbox được chọn, đổi màu nền của nút tương ứng thành màu đỏ
                    button.BackColor = Color.Red;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Guna2Button button = (Guna2Button)this.Controls["Thuong1"];
            button.BackColor = SystemColors.ControlDark;
        }
    }
}
