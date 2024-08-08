using BUS_Quanly.Services.QuanLyDatPhong.ThanhToan_DV;
using DTO_Quanly.Transfer;
using GUI_Quanlykhachsan.ChucNang;
using GUI_Quanlykhachsan.ChucNang.ADMIN;
using GUI_Quanlykhachsan.ChucNang.dangphattrien;
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
        private readonly QuanLyDatPhong _qlydp;
        private readonly Qly_NhanVien _qlynv;
        private readonly ThongTinKH _ttkh;
        private readonly HoaDon _hd;
        private readonly TaiChinh _taiChinh;
        private readonly FrmSettings _caiDat;
        private readonly frmPhong _frmphong;
        private readonly frmQuanlyDV _frmQuanlyDV;
        private readonly Voucher _frmVoucher;

        private Guna2GradientButton _currentButton;
        private bool _dragging;
        private Point _dragCursorPoint;
        private Point _dragFormPoint;
        private readonly TTDichVu _nghia = new TTDichVu();

        public TrangChu()
        {
            InitializeComponent();
            MouseDown += Form_MouseDown;

            _qlydp = new QuanLyDatPhong();
            _qlynv = new Qly_NhanVien();
            _ttkh = new ThongTinKH();
            _hd = new HoaDon();
            _taiChinh = new TaiChinh();
            _caiDat = new FrmSettings();
            _frmphong = new frmPhong();
            _frmQuanlyDV = new frmQuanlyDV();
            _frmVoucher = new Voucher();

            tngayden.Enabled = tngayden.Visible = tngaydi.Enabled = tngaydi.Visible = Ttimp.Visible = Ttimp.Enabled = false;
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
                SendMessage(Handle, 0xA1, 0x2, 0);
            }
        }
        #endregion

        private void TrangChu_Load(object sender, EventArgs e)
        {
            label1.Text = TDatPhong.VaiTro == 1 ? "Đây là admin" : TDatPhong.VaiTro == 3 ? "Đây là nhân viên !    -    Nhân viên sẽ không sử dụng được quản lý nhân viên." : "Đây là quản lý !    -    Quản lý sẽ xem được danh sách nhân viên.";
            container.Controls.Clear();
            if (TDatPhong.VaiTro == 3)
            {
                btnQLNV.Enabled = false;
            }


            _taiChinh.TopLevel = false;
            container.Controls.Add(_taiChinh);
            _taiChinh.Show();
        }

        private void TrangChu_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            e.Cancel = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes;
        }

        // Màu mặc định và màu khi nhấn vào
        private Color MauMacDinh() => Color.FromArgb(255, 255, 255);
        private Color MauKhiNhan() => Color.FromArgb(128, 128, 255);

        // Nút thoát

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

        // Form nhân viên
        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            tngayden.Enabled = tngayden.Visible = tngaydi.Enabled = tngaydi.Visible = Ttimp.Visible = Ttimp.Enabled = false;
            LoadForm(_qlynv, (Guna2GradientButton)sender);
        }

        // Form quản lý đặt phòng
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            tngayden.Enabled = tngayden.Visible = tngaydi.Enabled = tngaydi.Visible = Ttimp.Visible = Ttimp.Enabled = true;
            _qlydp.hienthiphong();
            LoadForm(_qlydp, (Guna2GradientButton)sender);
        }

        // Form quản lý thông tin khách hàng
        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            tngayden.Enabled = tngayden.Visible = tngaydi.Enabled = tngaydi.Visible = Ttimp.Visible = Ttimp.Enabled = false;
            LoadForm(_ttkh, (Guna2GradientButton)sender);
        }

        // Form tài chính, hiển thị biểu đồ doanh thu
        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
            tngayden.Enabled = tngayden.Visible = tngaydi.Enabled = tngaydi.Visible = Ttimp.Visible = Ttimp.Enabled = false;
            LoadForm(_taiChinh, (Guna2GradientButton)sender);
        }

        // Form cài đặt
        private void guna2GradientButton8_Click(object sender, EventArgs e)
        {
            tngayden.Enabled = tngayden.Visible = tngaydi.Enabled = tngaydi.Visible = Ttimp.Visible = Ttimp.Enabled = false;
            LoadForm(_caiDat, (Guna2GradientButton)sender);
        }


        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            tngayden.Enabled = tngayden.Visible = tngaydi.Enabled = tngaydi.Visible = Ttimp.Visible = Ttimp.Enabled = false;
            LoadForm(_frmphong, (Guna2GradientButton)sender);
        }

        // Form quản lý hoá đơn
        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            tngayden.Enabled = tngayden.Visible = tngaydi.Enabled = tngaydi.Visible = Ttimp.Visible = Ttimp.Enabled = false;
            LoadForm(_hd, (Guna2GradientButton)sender);
        }

        // Form quản lý dịch vụ
        private void guna2GradientButton7_Click(object sender, EventArgs e)
        {
            tngayden.Enabled = tngayden.Visible = tngaydi.Enabled = tngaydi.Visible = Ttimp.Visible = Ttimp.Enabled = false;
            LoadForm(_frmQuanlyDV, (Guna2GradientButton)sender);
        }


        // Form voucher
        private void guna2GradientButton1_Click_1(object sender, EventArgs e)
        {
            tngayden.Enabled = tngayden.Visible = tngaydi.Enabled = tngaydi.Visible = Ttimp.Visible = Ttimp.Enabled = false;
            LoadForm(_frmVoucher, (Guna2GradientButton)sender);
        }

        #endregion


        private void guna2GradientButton10_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
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
        private void StartDragging(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _dragging = true;
                _dragCursorPoint = Cursor.Position;
                _dragFormPoint = Location;
            }
        }

        private void DragForm(MouseEventArgs e)
        {
            if (_dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(_dragCursorPoint));
                Location = Point.Add(_dragFormPoint, new Size(diff));
            }
        }
        private void StopDragging(MouseEventArgs e) => _dragging = false;

        private void guna2Panel2_MouseDown(object sender, MouseEventArgs e) => StartDragging(e);
        private void guna2Panel2_MouseMove(object sender, MouseEventArgs e) => DragForm(e);
        private void guna2Panel2_MouseUp(object sender, MouseEventArgs e) => StopDragging(e);

        private void label1_MouseDown(object sender, MouseEventArgs e) => StartDragging(e);
        private void label1_MouseMove(object sender, MouseEventArgs e) => DragForm(e);
        private void label1_MouseUp(object sender, MouseEventArgs e) => StopDragging(e);

        private void guna2Panel4_MouseDown(object sender, MouseEventArgs e) => StartDragging(e);
        private void guna2Panel4_MouseMove(object sender, MouseEventArgs e) => DragForm(e);
        private void guna2Panel4_MouseUp(object sender, MouseEventArgs e) => StopDragging(e);

        #endregion



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

        private void Ttimp_Click(object sender, EventArgs e)
        {
            if (tngayden.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Ngày đến không được nhỏ hơn ngày hiện tại!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (tngaydi.Value.Date <= tngayden.Value.Date)
            {
                MessageBox.Show("Ngày đi không được nhỏ hơn ngày đến!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _qlydp.timkiem(tngayden.Value.Date, tngaydi.Value.Date);
            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}