using DTO_Quanly.Model.DB;
using DTO_Quanly.Transfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Quanly.Repository.QuanLyDatPhong.KhachHang
{
    internal class TruyVanKhachHang
    {

        #region test

        //public void test()
        //{


        //    using (var transaction = DTODB.db.Database.BeginTransaction())
        //    {
        //        try
        //        {
        //            // Thêm khách hàng mới vào DB
        //            khachhang khmoi = new khachhang()
        //            {
        //                ten = txtTen.Text,
        //                email = txtEmail.Text,
        //                sdt = txtSDT.Text,
        //                gioitinh = rdNam.Checked ? "Nam" : "Nữ",
        //                diachi = txtDiaChi.Text,
        //                ngaysinh = NgaySinh.Value.Date,
        //                anh = duongdananh
        //            };
        //            DTODB.db.khachhangs.Add(khmoi);
        //            DTODB.db.SaveChanges();

        //            // Lấy id của khách hàng mới thêm vào
        //            int idkhachhang = khmoi.id;

        //            // Thêm checkin mới vào DB
        //            checkin checkinmoi = new checkin()
        //            {
        //                idkh = idkhachhang,
        //                idnv = 1,
        //                ngaycheckin = DateTime.Now.Date,
        //                trangthai = "Đặt trước"
        //            };
        //            DTODB.db.checkins.Add(checkinmoi);
        //            DTODB.db.SaveChanges();

        //            // Lấy id của checkin mới thêm vào
        //            int idcheckin = checkinmoi.id;

        //            // Thêm tempkhachhang mới vào DB
        //            decimal.TryParse(txtKhachThanhToan.Text, out decimal tientra);
        //            tempkhachhang tempkh = new tempkhachhang()
        //            {
        //                idkh = idkhachhang,
        //                idcheckin = idcheckin,
        //                tienkhachtra = tientra
        //            };
        //            DTODB.db.tempkhachhangs.Add(tempkh);

        //            // Thêm checkin_phong mới vào DB
        //            checkin_phong cpmoi = new checkin_phong()
        //            {
        //                idcheckin = idcheckin,
        //                idphong = TDatPhong.IdPhong
        //            };
        //            DTODB.db.checkin_phong.Add(cpmoi);

        //            // Lưu tất cả thay đổi vào DB
        //            DTODB.db.SaveChanges();

        //            transaction.Commit();
        //        }
        //        catch (Exception)
        //        {
        //            transaction.Rollback();
        //            throw;
        //        }
        //    }
        //}




        #endregion
    }
}
