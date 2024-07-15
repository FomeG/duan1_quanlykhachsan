using System;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GUI_Quanlykhachsan.ChucNang
{
    public partial class KhachHang : Form
    {
        public Action dattruoc;
        public Action nhanphong;
        private readonly int IdPhong;
        public KhachHang(Action nhanphong, Action dattruoc, int IdPhong)
        {
            InitializeComponent();
            this.dattruoc = dattruoc;
            this.nhanphong = nhanphong;
            this.IdPhong = IdPhong;


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
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion
        #region Kéo thả form (controller)

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private void guna2GroupBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = true;
                dragCursorPoint = Cursor.Position;
                dragFormPoint = this.Location;
            }
        }

        private void guna2GroupBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(diff));
            }
        }

        private void guna2GroupBox1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;

        }
        #endregion

        // Hàm validate form
        public bool checkthanhtoan()
        {
            if (txtTen.Text.Trim() == "" || txtEmail.Text.Trim() == "")
            {
                MessageBox.Show("Không được để trống dữ liệu.", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (IsValidEmail(txtEmail.Text) == false)
            {
                MessageBox.Show("Email không hợp lệ!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (txtSDT.Text != "" && !txtSDT.Text.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại không hợp lệ!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (!rdNam.Checked && !rdNu.Checked)
            {
                MessageBox.Show("Vui lòng chọn giới tính!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (SoLuongNguoi.Value <= 0)
            {
                MessageBox.Show("Số lượng người phải lớn hơn 0!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (NgayDen.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Ngày đến không được nhỏ hơn ngày hiện tại!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (NgayDi.Value.Date <= NgayDen.Value.Date)
            {
                MessageBox.Show("Ngày đi không được nhỏ hơn ngày đến!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
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
                dattruoc?.Invoke();
                Close();
                MessageBox.Show("Đặt trước phòng thành công!");
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            nhanphong?.Invoke();
            Close();
        }
        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog lam = new OpenFileDialog();
            if (lam.ShowDialog() == DialogResult.OK)
            {
                anhkh.Image = System.Drawing.Image.FromFile(lam.FileName);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

    }
}
