﻿using BUS_Quanly.Services.QuanLyDatPhong.ThanhToan_DV;
using DTO_Quanly;
using DTO_Quanly.Model.DB;
using DTO_Quanly.Transfer;
using GUI_Quanlykhachsan.ChucNang.dangphattrien;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace GUI_Quanlykhachsan.ChucNang
{
    public partial class ThanhToan : Form
    {
        TTDichVu _dv = new TTDichVu();
        public Action traphong;
        private TTDichVu _truyvan;
        private readonly int IDCin;
        private readonly int IDKh;
        private readonly int idnv;
        private readonly int IDPhong;





        public ThanhToan(int idcheckin, int idkh, int idphong)
        {
            InitializeComponent();
            traphong = traphong;
            IDCin = idcheckin;
            IDKh = idkh;
            idnv = TDatPhong.IDNV;
            TDatPhong.IdPhong = IDPhong = idphong;

            loadtt();
            loaddvgview();

            MouseDown += new MouseEventHandler(Form_MouseDown);
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


        #region LOAD DỮ LIỆU TRÊN FORM, VÀ DỊCH VỤ

        public void loadttdv()
        {


        }
        public void loadtt()
        {
            var hoadontemp = (from p in DTODB.db.phongs
                              join cp in DTODB.db.checkin_phong on p.idphong equals cp.idphong
                              join c in DTODB.db.checkins on cp.idcheckin equals c.id
                              join tk in DTODB.db.tempkhachhangs on c.id equals tk.idcheckin
                              join kh in DTODB.db.khachhangs on tk.idkh equals kh.id
                              join lp in DTODB.db.loaiphongs on p.loaiphong equals lp.idloaiphong
                              where p.idphong == IDPhong
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

        public void loaddvgview()
        {
            gview1.Columns.Clear();
            var list = _dv.GetCheckinDichVuList(IDCin);
            gview1.DataSource = list;

            decimal tienDichVu = _dv.TinhTongTienDichVu(list);
            txttiendv.Text = tienDichVu.ToString();

            decimal.TryParse(txttienphong.Text, out decimal tienPhong);
            decimal tongThanhToan = _dv.TinhTongThanhToan(tienDichVu, tienPhong);
            tongTT.Text = tongThanhToan.ToString();
        }

        #endregion


        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ThanhToan_Load(object sender, EventArgs e)
        {

        }

        private void guna2CustomCheckBox1_Click(object sender, EventArgs e)
        {

        }

        /* Nút trả phòng và thanh toán, luồng hoạt động:
           1.  Sau khi trả phòng và thanh toán thì khách hàng đang sử dụng phòng trong bảng temp sẽ không còn nữa.
           2.  Insert checkout
           3.  Lập hoá đơn và hoá đơn chi tiết
           4.  Chuyển trạng thái những phòng khách hàng đã thuê về trống
       */
        private void BtnTraPhong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn xuất hoá đơn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var listThongTin = from cd in DTODB.db.checkin_dichvu
                                   join dv in DTODB.db.dichvus on cd.iddv equals dv.id
                                   where cd.idcheckin == IDCin
                                   select new
                                   {
                                       cd.id,
                                   };
                using (var transaction = DTODB.db.Database.BeginTransaction())
                {
                    try
                    {

                        // Cập nhật thông tin vào trong checkout
                        checkout checkoutmoi = new checkout()
                        {
                            idkh = IDKh,
                            idnv = TDatPhong.IDNV,
                            ngaycheckout = DateTime.Now.Date,
                            trangthai = txtGhiChu.Text
                        };
                        DTODB.db.checkouts.Add(checkoutmoi);
                        //DTODB.db.SaveChanges();


                        var tempkh = DTODB.db.tempkhachhangs.FirstOrDefault(p => p.idcheckin == IDCin && p.idkh == IDKh);
                        DateTime? Nvao = tempkh.ngayvao;
                        DateTime? Nra = tempkh.ngayra;
                        decimal? tientra = tempkh.tienkhachtra;

                        // Trả phòng xong thì sẽ xoá hết dữ liệu trong bảng temp
                        DTODB.db.tempkhachhangs.Remove(DTODB.db.tempkhachhangs.FirstOrDefault(p => p.idcheckin == IDCin && p.idkh == IDKh));
                        //DTODB.db.SaveChanges();


                        // Chốt hoá đơn, dv_trunggian và phong_trunggian (nếu có)
                        decimal.TryParse(tongTT.Text, out decimal tongtien);
                        hoadon hoadonmoi = new hoadon()
                        {
                            idkh = IDKh,
                            idnv = TDatPhong.IDNV,
                            ngaytao = DateTime.Now.Date,
                            tongtien = tongtien,
                            songuoi = 1,
                            trangthai = "Đã thanh toán"

                        };
                        DTODB.db.hoadons.Add(hoadonmoi);
                        //DTODB.db.SaveChanges();

                        foreach (var item in listThongTin)
                        {
                            if (!DTODB.db.dv_trunggian.Any(d => d.iddv == item.id && d.idhd == hoadonmoi.idhoadon))
                            {
                                dv_trunggian dvtrunggianmoi = new dv_trunggian()
                                {
                                    iddv = item.id,
                                    idhd = hoadonmoi.idhoadon
                                };
                                DTODB.db.dv_trunggian.Add(dvtrunggianmoi);
                            }
                        }
                        DTODB.db.SaveChanges();

                        phong_trunggian ptrunggianmoi = new phong_trunggian()
                        {
                            idp = (from p in DTODB.db.phongs
                                   join cp in DTODB.db.checkin_phong on p.idphong equals cp.idphong
                                   join c in DTODB.db.checkins on cp.idcheckin equals c.id
                                   where p.idphong == IDPhong && c.id == IDCin
                                   select cp.id).FirstOrDefault(),
                            idhd = hoadonmoi.idhoadon
                        };
                        DTODB.db.phong_trunggian.Add(ptrunggianmoi);
                        //DTODB.db.SaveChanges();

                        // Xoá ds đặt trước đi => sẽ đổi trạng thái phòng về trống!

                        var ngayhientai = DateTime.Now;
                        DTODB.db.dsdattruocs.Remove(DTODB.db.dsdattruocs.FirstOrDefault(a => a.idphong == IDPhong && a.idkh == IDKh && ngayhientai >= a.ngayden && ngayhientai <= a.ngaydi));
                        DTODB.db.SaveChanges();


                        // Show ra cái hoá đơn
                        HDTemp hdtempmoi = new HDTemp(IDCin, IDPhong, hoadonmoi.idhoadon, txttenkh.Text, Nvao.Value, Nra.Value, tientra);
                        hdtempmoi.Show();

                        if (checkv.Checked)
                        {
                            if (DTODB.db.vouchers.Find(txtVoucher.Text) != null)
                            {

                                MessageBox.Show("Cập nhật thành công với voucher!");
                            }
                            else
                            {
                                MessageBox.Show("Voucher không hợp lệ!");
                                return;
                            }
                        }

                        MessageBox.Show("Cập nhật thành công!");
                        transaction.Commit();
                    }
                    catch (Exception a)
                    {
                        transaction.Rollback(); // Ko ổn thì rollback lại tránh việc dữ liệu xảy ra xung đột
                        MessageBox.Show("Đã có lỗi xảy ra!");
                        MessageBox.Show(a.ToString());
                    }
                }

                Close();
            }
        }

        // Nút thanh toán sau, vê căn bản là thoát form thanh toán và không làm gì CSDL cả.
        private void BtnThanhToanSau_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn thực hiện hành động này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void guna2CustomCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkv.Enabled)
            {
                txtVoucher.Enabled = true;
            }
            else txtVoucher.Enabled = false;
        }
    }
}