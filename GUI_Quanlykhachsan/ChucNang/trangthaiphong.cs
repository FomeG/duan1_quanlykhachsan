using BUS_Quanly.Services.QuanLyDatPhong.Phong;
using DTO_Quanly;
using DTO_Quanly.Transfer;
using GUI_Quanlykhachsan.ChucNang.dangphattrien;
using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI_Quanlykhachsan.ChucNang
{
    public partial class trangthaiphong : UserControl
    {
        PhongService _phongService = new PhongService();
        private int _borderRadius = 20; // Bán kính góc bo form
        private Guna2ContextMenuStrip contextMenuStrip;
        private string motaphong;
        private readonly int IdPhong; //Id của phòng phục vụ cho việc chuyển trạng thái
        private ThongTinPhongTemp _ttphongtemp;
        public trangthaiphong(string tenphong, string mota, int trangthaip, int idphong, int? tim)
        {
            InitializeComponent();
            roomname.Text = tenphong;
            description.Text = mota;
            motaphong = mota;
            IdPhong = idphong;
            TDatPhong.IdPhong = IdPhong;
            contextMenuStrip = new Guna2ContextMenuStrip();

            _ttphongtemp = new ThongTinPhongTemp(IdPhong, null, null);

            if (tim == 2) // trong trường hợp phòng trống, tìm kiếm hoặc không tìm kiếm
            {
                if (trangthaip == 0) // Nếu phòng trống
                {
                    this.BackColor = Color.FromArgb(128, 255, 128);
                    btnDat.Text = "Đặt Phòng";

                    contextMenuStrip.Items.Add("Thông tin phòng", null, (sender, e) => { _ttphongtemp.Show(); });
                    contextMenuStrip.Items.Add("Đặt phòng", null, (sender, e) => { MessageBox.Show("Đặt phòng"); });
                }
                else if (trangthaip == 1) // Nếu phòng đã được đặt (có người ở)
                {
                    this.BackColor = Color.Red;
                    btnDat.Text = "Trả Phòng";


                    contextMenuStrip.Items.Add("Thông tin phòng", null, (sender, e) => { _ttphongtemp.Show(); });
                    contextMenuStrip.Items.Add("Thanh toán phòng", null, (sender, e) => { MessageBox.Show("Thanh toán phòng"); });
                    contextMenuStrip.Items.Add("Xem hoá đơn", null, (sender, e) => { MessageBox.Show("Xem hoá đơn"); });

                }
            }
            else // trong trường hợp phòng đã đặt, tìm kiếm
            {
                if (trangthaip == 1) // Nếu phòng đã được đặt (có người ở)
                {
                    this.BackColor = Color.Red;
                    btnDat.Visible = false;
                    contextMenuStrip.Items.Add("Thông tin phòng", null, (sender, e) => { MessageBox.Show("Thông tin phòng"); });
                    contextMenuStrip.Items.Add("Huỷ phòng", null, (sender, e) => { MessageBox.Show("Huỷ phòng"); });
                    contextMenuStrip.Items.Add("Xem hoá đơn", null, (sender, e) => { MessageBox.Show("Xem hoá đơn"); });
                }
                else if (trangthaip == 0) // Nếu phòng trống
                {
                    this.BackColor = Color.FromArgb(128, 255, 128);
                    btnDat.Text = "Đặt Phòng";

                    contextMenuStrip.Items.Add("Thông tin phòng", null, (sender, e) => { MessageBox.Show("Thông tin phòng"); });
                    contextMenuStrip.Items.Add("Đặt phòng", null, (sender, e) => { MessageBox.Show("Đặt phòng"); });
                }
            }

            this.MouseDown += new MouseEventHandler(trangthaiphong_MouseDown);
        }
        private void trangthaiphong_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip.Show(this, e.Location);
            }
        }

        private void Room_Load(object sender, EventArgs e)
        {

        }
        private void Room_Click(object sender, EventArgs e)
        {

        }
        public void dph()
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
                var listtt = (from p in DTODB.db.phongs
                              join cp in DTODB.db.checkin_phong on p.idphong equals cp.idphong
                              join c in DTODB.db.checkins on cp.idcheckin equals c.id
                              join tk in DTODB.db.tempkhachhangs on c.id equals tk.idcheckin
                              join kh in DTODB.db.khachhangs on tk.idkh equals kh.id
                              join lp in DTODB.db.loaiphongs on p.loaiphong equals lp.idloaiphong
                              where p.idphong == TDatPhong.IdPhong
                              select new
                              {
                                  c.id,
                                  IdKh = kh.id
                              }).FirstOrDefault();
                int idcin = listtt.id;
                int idkh = listtt.IdKh;

                TDatPhong.IDKH = listtt.IdKh;
                TDatPhong.IDCHECKIN = idcin;

                ThanhToan traphongthanhtoan = new ThanhToan(traphong, idcin, idkh, IdPhong);
                traphongthanhtoan.Show();
            }
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
                var listtt = (from p in DTODB.db.phongs
                              join cp in DTODB.db.checkin_phong on p.idphong equals cp.idphong
                              join c in DTODB.db.checkins on cp.idcheckin equals c.id
                              join tk in DTODB.db.tempkhachhangs on c.id equals tk.idcheckin
                              join kh in DTODB.db.khachhangs on tk.idkh equals kh.id
                              join lp in DTODB.db.loaiphongs on p.loaiphong equals lp.idloaiphong
                              where p.idphong == TDatPhong.IdPhong
                              select new
                              {
                                  c.id,
                                  IdKh = kh.id
                              }).FirstOrDefault();
                int idcin = listtt.id;
                int idkh = listtt.IdKh;

                TDatPhong.IDKH = listtt.IdKh;
                TDatPhong.IDCHECKIN = idcin;

                ThanhToan traphongthanhtoan = new ThanhToan(traphong, idcin, idkh, IdPhong);
                traphongthanhtoan.Show();
            }
        }


        #region Trạng thái phòng

        public void dattruoc()
        {
            btnDat.Text = "Nhận Phòng";
            description.Text = "Phòng được đặt trước";
            this.BackColor = Color.Yellow;


            _phongService.DatTruoc(IdPhong);
        }


        public void nhanphong()
        {
            btnDat.Text = "Trả phòng";
            description.Text = "Phòng đang được sử dụng";
            this.BackColor = Color.Red;


            _phongService.NhanPhong(IdPhong);
        }


        public void traphong()
        {
            btnDat.Text = "Đặt phòng";
            description.Text = motaphong;
            this.BackColor = Color.FromArgb(128, 255, 128);


            _phongService.TraPhong(IdPhong);
        }


        #endregion


    }
}
