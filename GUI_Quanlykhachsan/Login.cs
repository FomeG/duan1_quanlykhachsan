using BUS_Quanly.Services.LoginLogout;
using DTO_Quanly;
using DTO_Quanly.Transfer;
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
                    TrangChu trangChu = new TrangChu();
                    // nếu vai trò = 1 (admin) thì in label admin
                    if (DangNhap.VaiTro(txttk.Text) == 1)
                    {
                        DuLieu.vaitro = 1;
                        trangChu.Username.Text = "ADMIN";
                    }
                    // nếu vai trò = 2 (nhanvien) thì in label nhanvien
                    else
                    {
                        // Đặt id người dùng để phục vụ cho tác vụ liên quan đến đặt phòng
                        TDatPhong.IDNV = DTODB.db.nhanviens.FirstOrDefault(a => a.taikhoan == txttk.Text).idnv;
                        DuLieu.vaitro = 2;
                        trangChu.Username.Text = DTODB.db.nhanviens.FirstOrDefault(a => a.taikhoan == txttk.Text).ten.ToString();
                    }
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
    }
}
