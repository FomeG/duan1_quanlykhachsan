using GUI_Quanlykhachsan.ChucNang;
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

        private void btnEXIT_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void TrangChu_Load(object sender, EventArgs e)
        {
            //nếu vai trò = 1 (admin) -> in label admin và ngược lại
            if (DuLieu.vaitro == 1) label1.Text = "Đây là admin";
            else label1.Text = "Đây là nhân viên !";
        }
        public void tesT()
        {
            UserControl1 nghia = new UserControl1();
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
    }
}
