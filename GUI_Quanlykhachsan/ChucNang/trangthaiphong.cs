using DTO_Quanly;
using DTO_Quanly.Transfer;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI_Quanlykhachsan.ChucNang
{
    public partial class trangthaiphong : UserControl
    {

        private int _borderRadius = 20; // Bán kính góc bo form


        private string motaphong;
        private readonly int IdPhong; //Id của phòng phục vụ cho việc chuyển trạng thái
        public trangthaiphong(string tenphong, string mota, int trangthaip, int idphong)
        {
            InitializeComponent();
            roomname.Text = tenphong;
            description.Text = mota;
            motaphong = mota;
            IdPhong = idphong;
            TDatPhong.IdPhong = IdPhong;


            if (trangthaip == 1) // Nếu phòng trống
            {
                this.BackColor = Color.FromArgb(128, 255, 128);
                btnDat.Text = "Đặt Phòng";
            }
            else if (trangthaip == 2) // Nếu phòng đang được đặt trước
            {
                this.BackColor = Color.Yellow;
                btnDat.Text = "Nhận Phòng";

            }
            else // Nếu phòng đã được đặt (có người ở)
            {
                this.BackColor = Color.Red;
                btnDat.Text = "Trả Phòng";

            }
        }

        private void Room_Load(object sender, EventArgs e)
        {

        }
        private void Room_Click(object sender, EventArgs e)
        {

        }


        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (btnDat.Text == "Đặt Phòng")
            {
                TDatPhong.IdPhong = IdPhong;

                // Hiển thị tiền phòng (của tất cả các phòng đã đặt nếu có)
                TDatPhong.TienPhong = (from a in DTODB.db.phongs join b in DTODB.db.loaiphongs on a.loaiphong equals b.idloaiphong where a.idphong == IdPhong select b.giaphong).FirstOrDefault();

                
                KhachHang khachHang = new KhachHang(nhanphong, dattruoc);
                khachHang.Show();
            }
            else if (btnDat.Text == "Nhận Phòng")
            {
                TDatPhong.IdPhong = IdPhong;
                nhanphong();
            }
            else
            {
                TDatPhong.IdPhong = IdPhong;

                // Tìm ra idcheckin để phục vụ cho việc thêm dịch vụ trong form thanh toán
                // Cụ thể là hiển thị ra form dịch vụ để add / xoá dịch vụ
                int idcin = (from p in DTODB.db.phongs
                             join cp in DTODB.db.checkin_phong on p.idphong equals cp.idphong
                             join c in DTODB.db.checkins on cp.idcheckin equals c.id
                             join tk in DTODB.db.tempkhachhangs on c.id equals tk.idcheckin
                             join kh in DTODB.db.khachhangs on tk.idkh equals kh.id
                             join lp in DTODB.db.loaiphongs on p.loaiphong equals lp.idloaiphong
                             where p.idphong == TDatPhong.IdPhong
                             select c.id).FirstOrDefault();

                TDatPhong.IDCHECKIN = idcin;

                ThanhToan traphongthanhtoan = new ThanhToan(traphong, idcin);
                traphongthanhtoan.Show();
            }
        }


        #region Trạng thái phòng

        public void dattruoc()
        {
            btnDat.Text = "Nhận Phòng";
            description.Text = "Phòng được đặt trước";
            this.BackColor = Color.Yellow;

            DTODB.db.phongs.Find(IdPhong).trangthai = 2;
            DTODB.db.SaveChanges();
        }


        public void nhanphong()
        {
            btnDat.Text = "Trả phòng";
            description.Text = "Phòng đang được sử dụng";
            this.BackColor = Color.Red;

            DTODB.db.phongs.Find(IdPhong).trangthai = 3;
            DTODB.db.SaveChanges();
        }


        public void traphong()
        {
            btnDat.Text = "Đặt phòng";
            description.Text = motaphong;
            this.BackColor = Color.FromArgb(128, 255, 128);

            DTODB.db.phongs.Find(IdPhong).trangthai = 1;
            DTODB.db.SaveChanges();
        }
        #endregion
    }
}
