using BUS_Quanly.Services.LoginLogout;
using DTO_Quanly;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GUI_Quanlykhachsan
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            dataGridView1.DataSource = DTODB.db.taikhoans.ToList();
        }

        public bool check()
        {
            if (txttk.Text.Trim() == "" || txtmk.Text.Trim() == "")
            {
                MessageBox.Show("Không được để trống");
                return false;
            }
            else
            {
                return true;
            }
        }


        // Nút đăng nhập
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (check())
            {
                // truyền qua BUS để kiểm tra xem tài khoản mật khẩu có hợp lệ không
                if (DangNhap.KetQua(txttk.Text, txtmk.Text))
                {
                    // nếu vai trò = 1 (admin) thì in label admin
                    if (DangNhap.VaiTro(txttk.Text) == 1)
                    {
                        DuLieu.vaitro = 1;
                    }
                    // nếu vai trò = 2 (nhanvien) thì in label nhanvien
                    else
                    {
                        DuLieu.vaitro = 2;
                    }
                    TrangChu trangChu = new TrangChu();
                    trangChu.FormClosed += (a, b) => this.Show();
                    trangChu.Show();
                    txttk.Text = "";
                    txtmk.Text = "";
                    this.Hide();
                    MessageBox.Show("Đăng nhập thành công!");
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void txttk_TextChanged(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
