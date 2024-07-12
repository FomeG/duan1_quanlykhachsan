using BUS_Quanly.Services.LoginLogout;
using DTO_Quanly;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

namespace GUI_Quanlykhachsan
{
    public partial class Login : Form
    {
        List<Image> images = new List<Image>();
        string[] location = new string[25];
        public Login()
        {
            InitializeComponent();
            dataGridView1.DataSource = DTODB.db.taikhoans.ToList();
            for (int i = 0; i <= 23; i++)
            {
                location[i] = $@"D:\Login Avatar animation\Login Avatar animation\animation\textbox_user_{i + 1}.jpg";
            }
            location[24] = @"D:\Login Avatar animation\Login Avatar animation\animation\debut.JPG";

            tounage();
        }
        private void tounage()
        {
            for (int i = 0; i <= 24; i++)
            {
                Bitmap bitmap = new Bitmap(location[i]);
                images.Add(bitmap);
            }
            images.Add(Properties.Resources.textbox_user_24);
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
            if (txttk.Text.Length == 0)
            {
                pictureBox1.Image = images[24]; ;
            }
            else if (txttk.Text.Length > 0 && txttk.Text.Length <= 15)
            {
                pictureBox1.Image = images[txttk.Text.Length - 1];
                pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else
                pictureBox1.Image = images[22];
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txttk_Click(object sender, EventArgs e)
        {
            if (txttk.Text.Length == 0)
            {
                pictureBox1.Image = images[24]; ;
            }
            else if (txttk.Text.Length > 0 && txttk.Text.Length <= 15)
            {
                pictureBox1.Image = images[txttk.Text.Length - 1];
                pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else
                pictureBox1.Image = images[22];
        }

        private void txtmk_Click(object sender, EventArgs e)
        {
            Bitmap bmpass = new Bitmap(@"D:\Login Avatar animation\Login Avatar animation\animation\textbox_password.png");
            pictureBox1.Image = bmpass;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(txttk.Text.Length.ToString());
            pictureBox1.Image = Properties.Resources.debut;

        }

        private void txttk_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                Bitmap bmpass = new Bitmap(@"D:\Login Avatar animation\Login Avatar animation\animation\textbox_password.png");
                pictureBox1.Image = bmpass;
            }
        }
    }
}
