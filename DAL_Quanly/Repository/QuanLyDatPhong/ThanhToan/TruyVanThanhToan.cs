﻿using DTO_Quanly;
using DTO_Quanly.Model.DB;
using DTO_Quanly.Model.NoiBang;
using DTO_Quanly.Transfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DAL_Quanly.Repository.QuanLyDatPhong.ThanhToan
{
    public class TruyVanThanhToan
    {
        public TruyVanThanhToan()
        {
                
        }
        public List<dichvu> truyendichvu()
        {
            return DTODB.db.dichvus.ToList();
        }

        // lấy dịch vụ dựa vào id checkin
        public IEnumerable<dynamic> GetDichvusByCheckinId(int checkinId)
        {
            var listThongTin = from cd in DTODB.db.checkin_dichvu
                               join dv in DTODB.db.dichvus on cd.iddv equals dv.id
                               where cd.idcheckin == checkinId
                               select new
                               {
                                   IDdv = cd.id,
                                   // Add other necessary fields here
                               };
            return listThongTin.ToList();
        }

        // lấy thông tin hoá đơn để fill vào các label
        public dynamic GetHoaDonTemp(int idPhong)
        {
            var hoadontemp = (from p in DTODB.db.phongs
                              join cp in DTODB.db.checkin_phong on p.idphong equals cp.idphong
                              join c in DTODB.db.checkins on cp.idcheckin equals c.id
                              join tk in DTODB.db.tempkhachhangs on c.id equals tk.idcheckin
                              join kh in DTODB.db.khachhangs on tk.idkh equals kh.id
                              join lp in DTODB.db.loaiphongs on p.loaiphong equals lp.idloaiphong
                              where p.idphong == idPhong
                              select new
                              {
                                  kh.ten,
                                  kh.diachi,
                                  tk.ngayvao,
                                  tk.ngayra,
                                  lp.giaphong,
                                  tk.tienkhachtra
                              }).FirstOrDefault();
            return hoadontemp;
        }

        public List<CheckinDichVuInfo> GetCheckinDichVuList(int idCheckin)
        {

            var query = from cd in DTODB.db.checkin_dichvu
                        join dv in DTODB.db.dichvus on cd.iddv equals dv.id
                        where cd.idcheckin == idCheckin
                        select new CheckinDichVuInfo
                        {
                            TenDV = dv.tendv,
                            SoLuong = (int)cd.soluong,
                            MoTa = dv.mota,
                            GiaTien = (decimal)(dv.gia * cd.soluong)
                        };
            return query.ToList();
        }
    }



    /* Nút trả phòng và thanh toán, luồng hoạt động:
       1.  Sau khi trả phòng và thanh toán thì khách hàng đang sử dụng phòng trong bảng temp sẽ không còn nữa.
       2.  Insert checkout
       3.  Lập hoá đơn và hoá đơn chi tiết
       4.  Chuyển trạng thái những phòng khách hàng đã thuê về trống
   */
    //public bool TraPhongTT(int IDKh, string ghichu, int idcheckin, decimal tongTT)
    //{
    //    using (var transaction = DTODB.db.Database.BeginTransaction())
    //    {
    //        try
    //        {
    //            // Cập nhật thông tin vào trong checkout
    //            checkout checkoutmoi = new checkout()
    //            {
    //                idkh = IDKh,
    //                idnv = TDatPhong.IDNV,
    //                ngaycheckout = DateTime.Now.Date,
    //                trangthai = ghichu,
    //            };
    //            DTODB.db.checkouts.Add(checkoutmoi);
    //            DTODB.db.SaveChanges();

    //            // Trả phòng xong thì sẽ xoá hết dữ liệu trong bảng temp
    //            DTODB.db.tempkhachhangs.Remove(DTODB.db.tempkhachhangs.FirstOrDefault(p => p.idcheckin == idcheckin && p.idkh == IDKh));
    //            DTODB.db.SaveChanges();


    //            // Chốt hoá đơn, dv_trunggian và phong_trunggian (nếu có)
    //            hoadon hoadonmoi = new hoadon()
    //            {
    //                idkh = IDKh,
    //                idnv = TDatPhong.IDNV,
    //                ngaytao = DateTime.Now.Date,
    //                tongtien = tongTT,
    //                songuoi = 1,
    //                trangthai = "Đã thanh toán"

    //            };
    //            DTODB.db.hoadons.Add(hoadonmoi);
    //            DTODB.db.SaveChanges();
    //            var listThongTin = from cd in DTODB.db.checkin_dichvu
    //                               join dv in DTODB.db.dichvus on cd.iddv equals dv.id
    //                               where cd.idcheckin == idcheckin
    //                               select new
    //                               {
    //                                   IDdv = cd.id
    //                               };
    //            foreach (var item in listThongTin)
    //            {
    //                dv_trunggian dvtrunggianmoi = new dv_trunggian()
    //                {
    //                    iddv = item.IDdv,
    //                    idhd = hoadonmoi.idhoadon
    //                };

    //                DTODB.db.dv_trunggian.Add(dvtrunggianmoi);
    //                DTODB.db.SaveChanges();
    //            };



    //            //phong_trunggian ptrunggianmoi = new phong_trunggian()
    //            //{
    //            //    idp = IDPhong,
    //            //    idhd = hoadonmoi.idhoadon
    //            //};
    //            //DTODB.db.phong_trunggian.Add(ptrunggianmoi);
    //            //DTODB.db.SaveChanges();


    //            // Chuyển trạng thái phòng về trống (dựa vào temp khách hàng đã bị xoá trước đó)
    //            MessageBox.Show("Cập nhật thành công!");


    //            transaction.Commit();
    //            return true;
    //        }
    //        catch (Exception a)
    //        {
    //            transaction.Rollback(); // Ko ổn thì rollback lại tránh việc dữ liệu xảy ra xung đột
    //            MessageBox.Show("Đã có lỗi xảy ra!" + a.ToString());
    //            return false;
    //        }
    //    }
    //}







}

