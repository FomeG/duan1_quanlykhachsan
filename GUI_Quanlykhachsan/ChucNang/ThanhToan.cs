using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GUI_Quanlykhachsan.ChucNang
{
    public partial class ThanhToan : Form
    {
        public Action traphong;
        public ThanhToan(Action traphong)
        {
            InitializeComponent();
            this.traphong = traphong;
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

        // Nút thanh toán sau, vê căn bản là thoát form thanh toán và không làm gì CSDL cả.
        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn thực hiện hành động này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }



        /* Nút trả phòng và thanh toán, luồng hoạt động
            1.  Sau khi trả phòng và thanh toán thì khách hàng đang sử dụng phòng trong bảng temp sẽ không còn nữa.
            2.  Insert checkout
            3.  Lập hoá đơn và hoá đơn chi tiết
            4.  Chuyển trạng thái những phòng khách hàng đã thuê về trống

        */



        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            traphong?.Invoke();
            Close();
        }

        private void ThanhToan_Load(object sender, EventArgs e)
        {

        }
    }
}
