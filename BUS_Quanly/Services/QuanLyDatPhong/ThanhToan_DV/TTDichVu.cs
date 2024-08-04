using DAL_Quanly.Repository.QuanLyDatPhong.ThanhToan;
using DTO_Quanly.Model.NoiBang;
using System.Collections.Generic;
using System.Linq;

namespace BUS_Quanly.Services.QuanLyDatPhong.ThanhToan_DV
{
    public class TTDichVu
    {
        TruyVanThanhToan _truyvan = new TruyVanThanhToan();
        public TTDichVu()
        {

        }

        public List<NoiDichvu> hienthidv()
        {
            return _truyvan.truyendichvu().ToList();
        }

        public IEnumerable<dynamic> GetDichvusByCheckinId(int checkinId)
        {
            return _truyvan.GetDichvusByCheckinId(checkinId);
        }

        public dynamic GetHoaDonTemp(int idPhong)
        {
            return _truyvan.GetHoaDonTemp(idPhong);
        }

        //public bool ThanhToanTT()
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



        #region form load
        public List<CheckinDichVuInfo> GetCheckinDichVuList(int idCheckin)
        {
            return _truyvan.GetCheckinDichVuList(idCheckin);
        }

        public decimal TinhTongTienDichVu(List<CheckinDichVuInfo> list)
        {
            return list.Sum(item => item.GiaTien);
        }

        public decimal TinhTongThanhToan(decimal tienDichVu, decimal tienPhong)
        {
            return tienDichVu + tienPhong;
        }
        #endregion
    }
}
