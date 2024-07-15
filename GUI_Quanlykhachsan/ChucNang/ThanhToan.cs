using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using BUS_Quanly.Services.QuanLyDatPhong.ThanhToan_DV;
using DTO_Quanly;
using DTO_Quanly.Transfer;

namespace GUI_Quanlykhachsan.ChucNang
{
    public partial class ThanhToan : Form
    {
        public Action traphong;
        private TTDichVu _truyvan;
        public ThanhToan(Action traphong)
        {
            InitializeComponent();
            this.traphong = traphong;
            LoadDV();
            loadtt();

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

        public void LoadDV()
        {
            foreach (var item in DTODB.db.dichvus.ToList())
            {
                LsDichVu.Items.Add(item.tendv);
            }
        }

        public void loadtt()
        {
            var hoadontemp = (from p in DTODB.db.phongs
                              join cp in DTODB.db.checkin_phong on p.idphong equals cp.idphong
                              join c in DTODB.db.checkins on cp.idcheckin equals c.id
                              join tk in DTODB.db.tempkhachhangs on c.id equals tk.idcheckin
                              join kh in DTODB.db.khachhangs on tk.idkh equals kh.id
                              join lp in DTODB.db.loaiphongs on p.loaiphong equals lp.idloaiphong
                              where p.idphong == TDatPhong.IdPhong
                              select new
                              {
                                  kh.ten,
                                  kh.diachi,
                                  tk.ngayvao,
                                  tk.ngayra,
                                  lp.giaphong,
                                  tk.tienkhachtra
                              }).FirstOrDefault();

            txttenkh.Text = hoadontemp.ten;
            txtngayvao.Text = hoadontemp.ngayvao.ToString();
            txtngayradk.Text = hoadontemp.ngayra.ToString();
            txtngayrathucte.Text = DateTime.Now.Date.ToString();
            txttienphong.Text = hoadontemp.giaphong.ToString();
            txttientratruoc.Text = hoadontemp.tienkhachtra.ToString();
        }


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
            if (MessageBox.Show("Bạn chắc chắn muốn thực hiện hành động này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                traphong.Invoke();
                Close();
            }
        }

        private void ThanhToan_Load(object sender, EventArgs e)
        {

        }

        private void guna2CustomCheckBox1_Click(object sender, EventArgs e)
        {

        }

        private void LsDichVu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
