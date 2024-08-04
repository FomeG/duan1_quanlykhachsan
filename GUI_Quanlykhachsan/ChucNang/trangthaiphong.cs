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

        private DateTime? Nden;
        private DateTime? Ndi;

        private bool cotimkiem;

        public trangthaiphong(string tenphong, string mota, int trangthaip, int idphong, int? tim, bool Tk, DateTime? ngayden, DateTime? ngaydi)
        {
            InitializeComponent();
            roomname.Text = tenphong;
            description.Text = mota;
            motaphong = mota;
            TDatPhong.IdPhong = IdPhong = idphong;
            contextMenuStrip = new Guna2ContextMenuStrip();
            cotimkiem = Tk;
            Nden = ngayden;
            Ndi = ngaydi;

            if (tim == 2) // trong trường hợp pkhông tìm kiếm
            {
                if (trangthaip == 0) // Nếu phòng trống
                {
                    BackColor = Color.FromArgb(128, 255, 128);
                    btnDat.Text = "Đặt Phòng";

                    _ttphongtemp = new ThongTinPhongTemp(IdPhong, null, null);

                    contextMenuStrip.Items.Add("Thông tin phòng", null, (sender, e) => { _ttphongtemp.Show(); });
                    contextMenuStrip.Items.Add("Đặt phòng", null, (sender, e) =>
                    {
                        TDatPhong.IdPhong = IdPhong;
                        // Hiển thị tiền phòng (của tất cả các phòng đã đặt nếu có)
                        TDatPhong.TienPhong = (from a in DTODB.db.phongs join b in DTODB.db.loaiphongs on a.loaiphong equals b.idloaiphong where a.idphong == IdPhong select b.giaphong).FirstOrDefault();

                        if (!cotimkiem)
                        {
                            KhachHang khachHang = new KhachHang(IdPhong, null, null);
                            khachHang.Show();
                        }
                        else
                        {
                            KhachHang khachHang = new KhachHang(IdPhong, Nden, Ndi);
                            khachHang.Show();
                        }
                    });
                }
                else if (trangthaip == 1) // Nếu phòng đã được đặt (có người ở)
                {
                    BackColor = Color.Red;
                    btnDat.Text = "Dịch vụ";
                    DateTime nden = (DateTime)DTODB.db.view_dsdattruoc_chitiet.FirstOrDefault(x => x.idphong == IdPhong).ngayden;
                    DateTime ndi = (DateTime)DTODB.db.view_dsdattruoc_chitiet.FirstOrDefault(x => x.idphong == IdPhong).ngaydi;
                    _ttphongtemp = new ThongTinPhongTemp(IdPhong, nden, ndi);
                    #region Phần chuột phải
                    contextMenuStrip.Items.Add("Thông tin phòng", null, (sender, e) =>
                    {
                        _ttphongtemp.Show();
                    });

                    //contextMenuStrip.Items.Add("Thanh toán phòng", null, (sender, e) =>
                    //{
                    //    if (MessageBox.Show("Bạn có chắc chắn muốn thanh toán phòng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    //    {
                    //        MessageBox.Show("Thành công!");
                    //    }
                    //});

                    contextMenuStrip.Items.Add("Thanh toán phòng", null, (sender, e) =>
                    {
                        var query = (from dsd in DTODB.db.dsdattruocs
                                     join kh in DTODB.db.khachhangs on dsd.idkh equals kh.id
                                     join p in DTODB.db.phongs on dsd.idphong equals p.idphong
                                     join cip in DTODB.db.checkin_phong on p.idphong equals cip.idphong
                                     join tkh in DTODB.db.tempkhachhangs on cip.idcheckin equals tkh.idcheckin
                                     where p.idphong == IdPhong

                                     select new
                                     {
                                         IDkhachhang = kh.id,
                                         IDcheckin = cip.idcheckin
                                     }).FirstOrDefault();


                        int idcin = query.IDcheckin;
                        TDatPhong.IDCHECKIN = idcin;
                        int idkh = query.IDkhachhang;
                        TDatPhong.IDKH = query.IDkhachhang;

                        ThanhToan frmTT = new ThanhToan(idcin, idkh, IdPhong);
                        frmTT.Show();
                    });
                    #endregion
                }
            }
            else // trong trường hợp tìm kiếm
            {
                if (trangthaip == 1) // Nếu phòng đã được đặt (có người ở)
                {
                    BackColor = Color.Red;
                    btnDat.Visible = false;
                    _ttphongtemp = new ThongTinPhongTemp(IdPhong, Nden, Ndi);
                    #region Phần chuột phải
                    contextMenuStrip.Items.Add("Thông tin phòng", null, (sender, e) =>
                    {
                        _ttphongtemp.Show();
                    });
                    contextMenuStrip.Items.Add("Huỷ phòng", null, (sender, e) =>
                    {
                        frmHuyPhong huyp = new frmHuyPhong((DateTime)Nden, (DateTime)Ndi, IdPhong);
                        huyp.Show();
                    });
                    #endregion
                }
                else if (trangthaip == 0) // Nếu phòng trống
                {
                    BackColor = Color.FromArgb(128, 255, 128);
                    btnDat.Text = "Đặt Phòng";
                    _ttphongtemp = new ThongTinPhongTemp(IdPhong, null, null);

                    #region Phần chuột phải
                    contextMenuStrip.Items.Add("Thông tin phòng", null, (sender, e) =>
                    {
                        _ttphongtemp.Show();
                    });

                    contextMenuStrip.Items.Add("Đặt phòng", null, (sender, e) =>
                    {
                        TDatPhong.IdPhong = IdPhong;

                        // Hiển thị tiền phòng (của tất cả các phòng đã đặt nếu có)
                        TDatPhong.TienPhong = (from a in DTODB.db.phongs join b in DTODB.db.loaiphongs on a.loaiphong equals b.idloaiphong where a.idphong == IdPhong select b.giaphong).FirstOrDefault();

                        if (!cotimkiem)
                        {
                            KhachHang khachHang = new KhachHang(IdPhong, null, null);
                            khachHang.Show();
                        }
                        else
                        {
                            KhachHang khachHang = new KhachHang(IdPhong, Nden, Ndi);
                            khachHang.Show();
                        }
                    });
                    #endregion
                }
            }

            MouseDown += new MouseEventHandler(trangthaiphong_MouseDown);
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


        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (btnDat.Text == "Đặt Phòng")
            {
                TDatPhong.IdPhong = IdPhong;

                // Hiển thị tiền phòng (của tất cả các phòng đã đặt nếu có)
                TDatPhong.TienPhong = (from a in DTODB.db.phongs join b in DTODB.db.loaiphongs on a.loaiphong equals b.idloaiphong where a.idphong == IdPhong select b.giaphong).FirstOrDefault();

                if (!cotimkiem)
                {
                    KhachHang khachHang = new KhachHang(IdPhong, null, null);
                    khachHang.Show();
                }
                else
                {
                    KhachHang khachHang = new KhachHang(IdPhong, Nden, Ndi);
                    khachHang.Show();
                }


            }
            else if (btnDat.Text == "Dịch vụ")
            {
                var query = (from dsd in DTODB.db.dsdattruocs
                             join kh in DTODB.db.khachhangs on dsd.idkh equals kh.id
                             join p in DTODB.db.phongs on dsd.idphong equals p.idphong
                             join cip in DTODB.db.checkin_phong on p.idphong equals cip.idphong
                             join tkh in DTODB.db.tempkhachhangs on cip.idcheckin equals tkh.idcheckin
                             where p.idphong == IdPhong

                             select new
                             {
                                 IDkhachhang = kh.id,
                                 IDcheckin = cip.idcheckin
                             }).FirstOrDefault();


                int idcin = query.IDcheckin;
                TDatPhong.IDCHECKIN = idcin;
                int idkh = query.IDkhachhang;
                TDatPhong.IDKH = query.IDkhachhang;

                FrmDichVu frmDichVu = new FrmDichVu(idcin, idkh);
                frmDichVu.Show();
            }

        }
    }
}
