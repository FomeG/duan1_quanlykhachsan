using GUI_Quanlykhachsan.ChucNang;
using GUI_Quanlykhachsan.Properties;
using System;
using System.Windows.Forms;

namespace GUI_Quanlykhachsan
{
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
        }

        // Nút thoát
        private void btnEXIT_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TrangChu_Load(object sender, EventArgs e)
        {
            //nếu vai trò = 1 (admin) -> in label admin và ngược lại
            if (DuLieu.vaitro == 1) label1.Text = "Đây là admin";
            else label1.Text = "Đây là nhân viên !";
            container.Controls.Clear();
        }


        private void TrangChu_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
            }
            else
            {
                e.Cancel = true;
            }
        }
    
        private void guna2ContainerControl1_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {

        }

        // Nút quản lý đặt phòng, khi ấn vào thì thay container = form quản lý đặt phòng
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            QuanLyDatPhong ls = new QuanLyDatPhong();
            ls.FormBorderStyle = FormBorderStyle.None;
            ls.TopLevel = false;
            container.Controls.Clear();
            container.Controls.Add(ls);
            ls.Show();
            ls.Dock = DockStyle.Fill;
        }

        
        // Nút đăng xuất
        private void guna2GradientButton9_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Nút thanh toán để test, sau này sẽ thay đổi lại
        private void guna2GradientButton7_Click(object sender, EventArgs e)
        {
            ThanhToan ls = new ThanhToan();
            ls.FormBorderStyle = FormBorderStyle.None;
            ls.TopLevel = false;
            container.Controls.Clear();
            container.Controls.Add(ls);
            ls.Show();
            ls.Dock = DockStyle.Fill;
        }

        // Nút mở form thông tin khách hàng
        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
