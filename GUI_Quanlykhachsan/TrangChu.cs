using BUS_Quanly.Services.QuanLyDatPhong.ThanhToan_DV;
using GUI_Quanlykhachsan.ChucNang;
using GUI_Quanlykhachsan.ChucNang.ADMIN;
using GUI_Quanlykhachsan.ChucNang.Tai_Khoan;
using GUI_Quanlykhachsan.ChucNang.Test;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GUI_Quanlykhachsan
{
    public partial class TrangChu : Form
    {

        public TrangChu()
        {
            InitializeComponent();
            this.MouseDown += new MouseEventHandler(Form_MouseDown);
        }

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

        private void TrangChu_Load(object sender, EventArgs e)
        {
            label1.Text = DuLieu.vaitro == 1 ? "Đây là admin" : "Đây là nhân viên !    -    Nhân viên sẽ không sử dụng được quản lý nhân viên.";
            container.Controls.Clear();
        }

        private void TrangChu_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            e.Cancel = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes;
        }


        // Màu mặc định và màu khi nhấn vào
        private Color MauMacDinh() => Color.FromArgb(255, 255, 255);
        private Color MauKhiNhan() => Color.FromArgb(128, 128, 255);


        // Nút thoát
        private void btnEXIT_Click(object sender, EventArgs e) => Close();

        #region Code rút gọn

        private void LoadForm(Form form, Guna2GradientButton clickedButton)
        {
            form.FormBorderStyle = FormBorderStyle.None;
            form.TopLevel = false;
            container.Controls.Clear();
            container.Controls.Add(form);
            form.Show();
            form.Dock = DockStyle.Fill;

            SetButtonColor(clickedButton);
        }
        private Guna2GradientButton currentButton;
        private void SetButtonColor(Guna2GradientButton clickedButton)
        {
            if (currentButton != null && currentButton != clickedButton)
            {
                currentButton.FillColor = MauMacDinh();
                currentButton.FillColor2 = MauMacDinh();
            }

            if (clickedButton != currentButton)
            {
                clickedButton.FillColor = MauKhiNhan();
                clickedButton.FillColor2 = MauKhiNhan();
                currentButton = clickedButton;
            }
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e) => LoadForm(new Qly_NhanVien(), (Guna2GradientButton)sender);
        private void guna2GradientButton1_Click(object sender, EventArgs e) => LoadForm(new QuanLyDatPhong(), (Guna2GradientButton)sender);
        private void guna2GradientButton3_Click(object sender, EventArgs e) => LoadForm(new ThongTinKH(), (Guna2GradientButton)sender);
        private void guna2GradientButton6_Click(object sender, EventArgs e) => LoadForm(new TaiChinh(), (Guna2GradientButton)sender);
        private void guna2GradientButton8_Click(object sender, EventArgs e) => LoadForm(new FrmSettings(), (Guna2GradientButton)sender);

        #endregion

        private void guna2GradientButton7_Click(object sender, EventArgs e)
        {
            //ThanhToan ls = new ThanhToan();
            //ls.FormBorderStyle = FormBorderStyle.None;
            //ls.TopLevel = false;
            //container.Controls.Clear();
            //container.Controls.Add(ls);
            //ls.Show();
            //ls.Dock = DockStyle.Fill;
        }

        private void guna2GradientButton10_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #region khu vực test code
        // Bắt đầu phần testcode
        // Những code dưới đây để test, không có động gì vào sql và tác động lên form
        // Code chạy trong Trangchu();

        int tonghd = 0;
        private void btntest4_Click(object sender, EventArgs e)
        {
            int currentCount = hdButtons.Count + 1; // Số thứ tự mới

            Button hdmoi = new Button();
            hdmoi.AutoSize = false;
            hdmoi.Cursor = Cursors.Hand;
            hdmoi.Text = $"HDC {currentCount}";
            hdmoi.Name = $"btnHDC{currentCount}"; // Đặt tên cho button để dễ dàng xác định

            hdmoi.MouseDown += (a, b) =>
            {
                // Kiểm tra nếu là chuột phải
                if (b.Button == MouseButtons.Right)
                {
                    if (MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn này hay không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // Lấy số thứ tự của button bằng cách parse tên button
                        int index = int.Parse(((Button)a).Name.Replace("btnHDC", ""));

                        // Xóa button và cập nhật Dictionary
                        HoaDonCho.Controls.Remove(hdButtons[index]);
                        hdButtons.Remove(index);

                        MessageBox.Show("Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            };

            hdmoi.Click += (a, b) =>
            {
                MessageBox.Show($"Đây là nút thứ: {hdmoi.Text}");
            };

            // Thêm button vào Dictionary và FlowLayoutPanel
            hdButtons.Add(currentCount, hdmoi);
            HoaDonCho.Controls.Add(hdmoi);

        }


        private Dictionary<int, Button> hdButtons = new Dictionary<int, Button>();
        private List<Form_test> listform = new List<Form_test>();

        // Kết thúc phần test code
        #endregion


        #region Kéo thả form (controller)

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void guna2Panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = true;
                dragCursorPoint = Cursor.Position;
                dragFormPoint = this.Location;
            }
        }

        private void guna2Panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(diff));
            }
        }

        private void guna2Panel2_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;

        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = true;
                dragCursorPoint = Cursor.Position;
                dragFormPoint = this.Location;
            }
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(diff));
            }
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
        private void guna2Panel4_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = true;
                dragCursorPoint = Cursor.Position;
                dragFormPoint = this.Location;
            }

        }
        private void guna2Panel4_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(diff));
            }
        }

        private void guna2Panel4_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }


        #endregion

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        // Nút đăng xuất
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            Close();
        }

        TTDichVu nghia = new TTDichVu();
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(nghia.hienthidv().Count.ToString());
        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {

        }
    }
}