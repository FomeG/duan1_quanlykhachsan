using BUS_Quanly.Services.QuanLyDatPhong.DatTruoc_NhanP;
using DTO_Quanly;
using DTO_Quanly.Transfer;
using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GUI_Quanlykhachsan.ChucNang
{
    public partial class KhachHang : Form
    {
        private readonly Tdphong _tdp = new Tdphong();
        private readonly Action _dattruoc;
        private readonly Action _nhanphong;
        private bool _dragging;
        private Point _dragCursorPoint;
        private Point _dragFormPoint;
        private string _duongdananh;
        public KhachHang(Action nhanphong, Action dattruoc)
        {
            InitializeComponent();
            _dattruoc = dattruoc;
            _nhanphong = nhanphong;

            tiencantra.Text = TDatPhong.TienPhong.ToString();

            this.MouseDown += new MouseEventHandler(Form_MouseDown);
        }
        #region Kéo thả form
        // Dùng WinAPI để di chuyển form
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            // Nếu nhấn nút chuột trái
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion
        #region Kéo thả form (controller)
        private void guna2GroupBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _dragging = true;
                _dragCursorPoint = Cursor.Position;
                _dragFormPoint = Location;
            }
        }
        private void guna2GroupBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(_dragCursorPoint));
                Location = Point.Add(_dragFormPoint, new Size(diff));
            }
        }
        private void guna2GroupBox1_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }
        #endregion
        // Hàm validate form
        private bool checkthanhtoan()
        {
            if (string.IsNullOrWhiteSpace(txtTen.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Không được để trống dữ liệu.", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Email không hợp lệ!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!string.IsNullOrEmpty(txtSDT.Text) && !txtSDT.Text.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại không hợp lệ!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!rdNam.Checked && !rdNu.Checked)
            {
                MessageBox.Show("Vui lòng chọn giới tính!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (SoLuongNguoi.Value <= 0)
            {
                MessageBox.Show("Số lượng người phải lớn hơn 0!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (NgayDen.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Ngày đến không được nhỏ hơn ngày hiện tại!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (NgayDi.Value.Date <= NgayDen.Value.Date)
            {
                MessageBox.Show("Ngày đi không được nhỏ hơn ngày đến!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        // Hàm kiểm tra email bằng regex
        public static bool IsValidEmail(string email)
        {
            try
            {
                // Biểu thức chính quy để kiểm tra email
                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
                return regex.IsMatch(email);
            }
            catch (Exception)
            {
                return false;
            }
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (checkthanhtoan())
            {
                if (MessageBox.Show("Xác nhận đặt trước?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    int soluongnguoitoida = (int)(from a in DTODB.db.phongs
                                                  join b in DTODB.db.loaiphongs on a.loaiphong equals b.idloaiphong
                                                  where a.idphong == TDatPhong.IdPhong
                                                  select b.songuoi).FirstOrDefault();
                    if (SoLuongNguoi.Value > soluongnguoitoida)
                    {
                        MessageBox.Show("Số lượng người vượt quá tối đa!");
                    }
                    else
                    {
                        if (_tdp.DatTruoc(txtTen.Text, txtEmail.Text, txtSDT.Text, rdNam.Checked, txtDiaChi.Text, NgaySinh.Value.Date, _duongdananh, txtKhachThanhToan.Text, NgayDen.Value.Date, NgayDi.Value.Date))
                        {
                            _dattruoc?.Invoke();
                            Close();
                        }
                    }
                }
            }
        }
        // Nút nhận phòng
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (checkthanhtoan())
            {
                if (MessageBox.Show("Xác nhận đặt phòng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    // Thực hiện truy vấn
                    int soluongnguoitoida = (int)(from a in DTODB.db.phongs
                                                  join b in DTODB.db.loaiphongs on a.loaiphong equals b.idloaiphong
                                                  where a.idphong == TDatPhong.IdPhong
                                                  select b.songuoi).FirstOrDefault();
                    if (SoLuongNguoi.Value > soluongnguoitoida)
                    {
                        MessageBox.Show("Số lượng người vượt quá tối đa!");
                    }
                    else
                    {
                        if (_tdp.DatPhong(txtTen.Text, txtEmail.Text, txtSDT.Text, rdNam.Checked, txtDiaChi.Text, NgaySinh.Value.Date, _duongdananh, txtKhachThanhToan.Text, NgayDen.Value.Date, NgayDi.Value.Date))
                        {
                            _nhanphong?.Invoke();
                            Close();
                        }
                    }
                }
            }
        }
        private void label9_Click(object sender, EventArgs e)
        {
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog lam = new OpenFileDialog();
            if (lam.ShowDialog() == DialogResult.OK)
            {
                anhkh.Image = Image.FromFile(lam.FileName);
                _duongdananh = lam.FileName;
            }
        }
        private void txtKhachThanhToan_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKhachThanhToan.Text))
            {
            }
            else
            {
                if (!decimal.TryParse(txtKhachThanhToan.Text.Trim(), out decimal Khachtra))
                {
                    MessageBox.Show("Tiền không được chứa ký tự!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    txttientralai.Text = (Khachtra < TDatPhong.TienPhong) ? "0" : (Khachtra - TDatPhong.TienPhong).ToString();
                }
            }
        }
        private void BtnDatThem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}