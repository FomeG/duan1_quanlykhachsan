using BUS_Quanly.Services.LoginLogout;
using DTO_Quanly;
using DTO_Quanly.Transfer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GUI_Quanlykhachsan
{
    public partial class Login : Form
    {
        private readonly List<Image> images = new List<Image>();
        private readonly string[] location = new string[25];

        public Login()
        {
            InitializeComponent();
            InitializeImageLocations();
            LoadImages();
            this.MouseDown += Form_MouseDown;
            panellogin.ApplyRoundedCorners(30);
            panelvien1.ApplyRoundedCorners(30);
        }

        private void InitializeImageLocations()
        {
            for (int i = 0; i < 24; i++)
            {
                location[i] = Path.Combine("_Animation", $"textbox_user_{i + 1}.jpg");
            }
            location[24] = Path.Combine("_Animation", "debut.JPG");
        }

        private void LoadImages()
        {
            foreach (var path in location)
            {
                if (File.Exists(path))
                {
                    images.Add(Image.FromFile(path));
                }
            }
            images.Add(Properties.Resources.textbox_user_24);
        }

        public bool check() => !(string.IsNullOrWhiteSpace(txttk.Text) || string.IsNullOrWhiteSpace(txtmk.Text));

        #region Kéo thả form
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0xA1, 0x2, 0);
            }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e) => Close();

        private void Login_Load(object sender, EventArgs e) { }

        private void UpdatePictureBox()
        {
            int index = txttk.Text.Length;
            if (index == 0)
                pictureBox1.Image = images[24];
            else if (index > 0 && index <= 15)
                pictureBox1.Image = images[index - 1];
            else
                pictureBox1.Image = images[22];
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void txttk_TextChanged(object sender, EventArgs e) => UpdatePictureBox();
        private void txttk_Click(object sender, EventArgs e) => UpdatePictureBox();

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void label1_Click(object sender, EventArgs e) { }

        private void txtmk_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(Path.Combine("_Animation", "textbox_password.png"));
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.debut;
        }

        private void txttk_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                pictureBox1.Image = Image.FromFile(Path.Combine("_Animation", "textbox_password.png"));
            }
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            if (!check())
            {
                MessageBox.Show("Không được để trống");
                return;
            }

            if (DangNhap.KetQua(txttk.Text, txtmk.Text))
            {
                var trangChu = new TrangChu();
                if (DangNhap.VaiTro(txttk.Text) == 1)
                {
                    // Admin
                    trangChu.Username.Text = "ADMIN";
                    TDatPhong.IDNV = 1;
                    TDatPhong.VaiTro = 1;
                }
                else if (DangNhap.VaiTro(txttk.Text) == 2)
                {
                    // Quản lý
                    var nhanVien = DTODB.db.nhanviens.FirstOrDefault(a => a.taikhoan == txttk.Text);
                    trangChu.Username.Text = nhanVien?.ten?.ToString() ?? string.Empty;
                    TDatPhong.IDNV = 1;
                    TDatPhong.VaiTro = 2;
                }
                else
                {
                    // Nhân viên
                    var nhanVien = DTODB.db.nhanviens.FirstOrDefault(a => a.taikhoan == txttk.Text);
                    TDatPhong.IDNV = nhanVien?.idnv ?? 0;
                    TDatPhong.VaiTro = 3;
                    trangChu.Username.Text = nhanVien?.ten?.ToString() ?? string.Empty;
                }
                trangChu.FormClosed += (a, b) => this.Show();
                trangChu.Show();
                txttk.Text = txtmk.Text = string.Empty;
                this.Hide();
                MessageBox.Show("Đăng nhập thành công!");
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Close();
        }


        #region Kéo thả form (Controller)
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;


        private void guna2PictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = true;
                dragCursorPoint = Cursor.Position;
                dragFormPoint = this.Location;
            }
        }

        private void guna2PictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(diff));
            }
        }

        private void guna2PictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;

        }



        private void panellogin_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = true;
                dragCursorPoint = Cursor.Position;
                dragFormPoint = this.Location;
            }
        }

        private void panellogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(diff));
            }
        }

        private void panellogin_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;

        }

        private void guna2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = true;
                dragCursorPoint = Cursor.Position;
                dragFormPoint = this.Location;
            }
        }

        private void guna2Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(diff));
            }
        }

        private void guna2Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;

        }

        #endregion

    }
}