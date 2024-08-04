using BUS_Quanly.Services.LoginLogout;
using DTO_Quanly;
using DTO_Quanly.Transfer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_Quanlykhachsan
{
    public partial class Login : Form
    {
        private readonly List<Image> images = new List<Image>();
        private readonly string[] location = new string[25];
        private TrangChu _TrangChu;
        public Login()
        {
            InitializeComponent();
            InitializeImageLocations();
            LoadImages();
            MouseDown += Form_MouseDown;
            panellogin.ApplyRoundedCorners(30);
            panelvien1.ApplyRoundedCorners(30);


            // Khởi tạo Timer
            progressTimer = new System.Windows.Forms.Timer();
            progressTimer.Interval = 10; // Cập nhật mỗi 10ms
            progressTimer.Tick += ProgressTimer_Tick;
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
                SendMessage(Handle, 0xA1, 0x2, 0);
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

        #region Nút đăng nhập Animated
        private System.Windows.Forms.Timer progressTimer;
        private int targetProgress = 0;

        private void ProgressTimer_Tick(object sender, EventArgs e)
        {
            if (bar1.Value < targetProgress)
            {
                bar1.Value++;
            }
            else if (bar1.Value > targetProgress)
            {
                bar1.Value--;
            }
            else
            {
                progressTimer.Stop();
            }
        }

        private void UpdateProgressBar(int value)
        {
            targetProgress = value;
            progressTimer.Start();
        }

        private bool IsRetired;

        private async void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            if (!check())
            {
                MessageBox.Show("Không được để trống");
                return;
            }

            // Disable nút đăng nhập và hiển thị ProgressBar
            guna2GradientButton2.Enabled = false;
            guna2GradientButton2.Text = "Đang đăng nhập";
            bar1.Visible = true;
            bar1.Value = 0;

            try
            {
                // Bắt đầu đăng nhập
                UpdateProgressBar(20);
                bool loginResult = await Task.Run(() => DangNhap.KetQua(txttk.Text, txtmk.Text));
                UpdateProgressBar(40);

                if (loginResult)
                {
                    _TrangChu = new TrangChu();
                    UpdateProgressBar(60);

                    int? vaiTro = await Task.Run(() => DangNhap.VaiTro(txttk.Text));
                    UpdateProgressBar(80);

                    switch (vaiTro)
                    {
                        case 1:
                            // Admin (idvaitro = 1)
                            _TrangChu.Username.Text = "ADMIN";
                            TDatPhong.IDNV = 1;
                            TDatPhong.VaiTro = 1;
                            break;
                        case 2:
                            // Quản lý (idvaitro = 2)
                            var quanLy = await Task.Run(() => DTODB.db.nhanviens.FirstOrDefault(a => a.taikhoan == txttk.Text));
                            _TrangChu.Username.Text = quanLy?.ten?.ToString() ?? string.Empty;
                            TDatPhong.IDNV = quanLy.idnv;
                            TDatPhong.VaiTro = 2;
                            if (quanLy.tt == true)
                            {
                                IsRetired = true;
                            }
                            else IsRetired = false;
                            break;
                        default:
                            // Nhân viên (idvaitro = 3)
                            var nhanVien = await Task.Run(() => DTODB.db.nhanviens.FirstOrDefault(a => a.taikhoan == txttk.Text));
                            TDatPhong.IDNV = nhanVien.idnv;
                            TDatPhong.VaiTro = 3;
                            _TrangChu.Username.Text = nhanVien?.ten?.ToString() ?? string.Empty;
                            if (nhanVien.tt == true)
                            {
                                IsRetired = true;
                            }
                            else IsRetired = false;
                            break;
                    }

                    UpdateProgressBar(100);

                    // Đợi ProgressBar hoàn thành trước khi chuyển form
                    while (bar1.Value < 100)
                    {
                        await Task.Delay(1);
                    }

                    if (IsRetired)
                    {
                        MessageBox.Show("Nhân viên đã nghỉ việc, không thể đăng nhập nữa");
                    }
                    else
                    {
                        _TrangChu.FormClosed += (a, b) => Show();
                        _TrangChu.Show();
                        txttk.Text = txtmk.Text = string.Empty;
                        Hide();
                        MessageBox.Show("Đăng nhập thành công!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
            finally
            {
                // Ẩn ProgressBar, enable lại nút đăng nhập
                progressTimer.Stop();
                bar1.Visible = false;
                guna2GradientButton2.Enabled = true;
                guna2GradientButton2.Text = "Đăng nhập";
            }
        }
        #endregion



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
                dragFormPoint = Location;
            }
        }

        private void guna2PictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                Location = Point.Add(dragFormPoint, new Size(diff));
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
                dragFormPoint = Location;
            }
        }

        private void panellogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                Location = Point.Add(dragFormPoint, new Size(diff));
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
                dragFormPoint = Location;
            }
        }

        private void guna2Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                Location = Point.Add(dragFormPoint, new Size(diff));
            }
        }

        private void guna2Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;

        }

        #endregion

    }
}