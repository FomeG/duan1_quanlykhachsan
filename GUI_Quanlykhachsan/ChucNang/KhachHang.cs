using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GUI_Quanlykhachsan.ChucNang
{
    public partial class KhachHang : Form
    {
        public Action dattruoc;
        public Action nhanphong;
        public KhachHang(/*Action nhanphong, Action dattruoc*/)
        {
            InitializeComponent();
            this.dattruoc = dattruoc;
            this.nhanphong = nhanphong;




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

        private void KhachHang_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            dattruoc?.Invoke();
            Close();
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
    }
}
