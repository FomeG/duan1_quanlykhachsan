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

            location[0] = @"D:\Login Avatar animation\Login Avatar animation\animation\textbox_user_1.jpg";
            location[1] = @"D:\Login Avatar animation\Login Avatar animation\animation\textbox_user_2.jpg";
            location[2] = @"D:\Login Avatar animation\Login Avatar animation\animation\textbox_user_3.jpg";
            location[3] = @"D:\Login Avatar animation\Login Avatar animation\animation\textbox_user_4.jpg";
            location[4] = @"D:\Login Avatar animation\Login Avatar animation\animation\textbox_user_5.jpg";
            location[5] = @"D:\Login Avatar animation\Login Avatar animation\animation\textbox_user_6.jpg";
            location[6] = @"D:\Login Avatar animation\Login Avatar animation\animation\textbox_user_7.jpg";
            location[7] = @"D:\Login Avatar animation\Login Avatar animation\animation\textbox_user_8.jpg";
            location[8] = @"D:\Login Avatar animation\Login Avatar animation\animation\textbox_user_9.jpg";
            location[9] = @"D:\Login Avatar animation\Login Avatar animation\animation\textbox_user_10.jpg";
            location[10] = @"D:\Login Avatar animation\Login Avatar animation\animation\textbox_user_11.jpg";
            location[11] = @"D:\Login Avatar animation\Login Avatar animation\animation\textbox_user_12.jpg";
            location[12] = @"D:\Login Avatar animation\Login Avatar animation\animation\textbox_user_13.jpg";
            location[13] = @"D:\Login Avatar animation\Login Avatar animation\animation\textbox_user_14.jpg";
            location[14] = @"D:\Login Avatar animation\Login Avatar animation\animation\textbox_user_15.jpg";
            location[15] = @"D:\Login Avatar animation\Login Avatar animation\animation\textbox_user_16.jpg";
            location[16] = @"D:\Login Avatar animation\Login Avatar animation\animation\textbox_user_17.jpg";
            location[17] = @"D:\Login Avatar animation\Login Avatar animation\animation\textbox_user_18.jpg";
            location[18] = @"D:\Login Avatar animation\Login Avatar animation\animation\textbox_user_19.jpg";
            location[19] = @"D:\Login Avatar animation\Login Avatar animation\animation\textbox_user_20.jpg";
            location[20] = @"D:\Login Avatar animation\Login Avatar animation\animation\textbox_user_21.jpg";
            location[21] = @"D:\Login Avatar animation\Login Avatar animation\animation\textbox_user_22.jpg";
            location[22] = @"D:\Login Avatar animation\Login Avatar animation\animation\textbox_user_23.jpg";
            location[23] = @"D:\Login Avatar animation\Login Avatar animation\animation\textbox_user_24.jpg";

            tounage();
        }
        private void tounage()
        {
            for (int i = 0; i < 24; i++)
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
            if (txttk.Text.Length > 0 && txttk.Text.Length <= 15)
            {
                pictureBox1.Image = images[txttk.Text.Length - 1];
                pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else if (txttk.Text.Length <= 0)
                pictureBox1.Image = Properties.Resources.debut;
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
            if (txttk.Text.Length > 0)
                pictureBox1.Image = images[txttk.Text.Length - 1];
            else
                pictureBox1.Image = Properties.Resources.debut;
        }

        private void txtmk_Click(object sender, EventArgs e)
        {
            Bitmap bmpass = new Bitmap(@"D:\Login Avatar animation\Login Avatar animation\animation\textbox_password.png");
            pictureBox1.Image = bmpass;
        }
    }
}
