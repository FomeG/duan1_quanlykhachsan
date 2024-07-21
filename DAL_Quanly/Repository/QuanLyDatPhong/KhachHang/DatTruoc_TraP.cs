using DTO_Quanly;
using DTO_Quanly.Model.DB;
using DTO_Quanly.Transfer;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DAL_Quanly.Repository.QuanLyDatPhong.KhachHang
{
    public class DatTruoc_TraP
    {
        public bool DatTruoc(string tenkh, string email, string sdt, bool gender, string diachi, DateTime Nsinh, string duongdan, string khachtt, DateTime nDen, DateTime nDi)
        {
            using (var transaction = DTODB.db.Database.BeginTransaction())
            {
                try
                {
                    // Thêm khách hàng mới vào DB
                    khachhang khmoi = new khachhang()
                    {
                        ten = tenkh,
                        email = email,
                        sdt = sdt,
                        gioitinh = gender ? "Nam" : "Nữ",
                        diachi = diachi,
                        ngaysinh = Nsinh,
                        anh = duongdan
                    };
                    DTODB.db.khachhangs.Add(khmoi);
                    DTODB.db.SaveChanges();

                    // Thêm checkin mới vào DB
                    checkin checkinmoi = new checkin()
                    {
                        idkh = DTODB.db.khachhangs.FirstOrDefault(p => p.email == email).id,
                        idnv = TDatPhong.IDNV,
                        ngaycheckin = DateTime.Now.Date,
                        trangthai = "Đặt trước"
                    };
                    DTODB.db.checkins.Add(checkinmoi);
                    DTODB.db.SaveChanges();

                    // Lấy id của checkin mới thêm vào
                    int idcheckin = checkinmoi.id;

                    // Thêm tempkhachhang mới vào DB
                    decimal.TryParse(khachtt, out decimal tientra);
                    tempkhachhang tempkh = new tempkhachhang()
                    {
                        idkh = DTODB.db.khachhangs.FirstOrDefault(p => p.email == email).id,
                        idcheckin = idcheckin,
                        tienkhachtra = tientra,
                        ngayvao = nDen,
                        ngayra = nDi,
                    };
                    DTODB.db.tempkhachhangs.Add(tempkh);
                    DTODB.db.SaveChanges();

                    // Thêm checkin_phong mới vào DB
                    checkin_phong cpmoi = new checkin_phong()
                    {
                        idcheckin = idcheckin,
                        idphong = TDatPhong.IdPhong
                    };
                    DTODB.db.checkin_phong.Add(cpmoi);
                    DTODB.db.SaveChanges();

                    transaction.Commit(); // Ổn thì commit 
                    return true;
                }
                catch (Exception a)
                {
                    transaction.Rollback(); // Ko ổn thì rollback lại tránh việc dữ liệu xảy ra xung đột
                    MessageBox.Show(a.ToString());
                    return false;
                }
            }
        }


        public bool DatPhong(string tenkh, string email, string sdt, bool gender, string diachi, DateTime Nsinh, string duongdan, string khachtt, DateTime nDen, DateTime nDi)
        {
            using (var transaction = DTODB.db.Database.BeginTransaction())
            {
                try
                {
                    // Thêm khách hàng mới vào DB
                    khachhang khmoi = new khachhang()
                    {
                        ten = tenkh,
                        email = email,
                        sdt = sdt,
                        gioitinh = gender ? "Nam" : "Nữ",
                        diachi = diachi,
                        ngaysinh = Nsinh,
                        anh = duongdan
                    };
                    DTODB.db.khachhangs.Add(khmoi);
                    DTODB.db.SaveChanges();

                    // Thêm checkin mới vào DB
                    checkin checkinmoi = new checkin()
                    {
                        idkh = DTODB.db.khachhangs.FirstOrDefault(p => p.email == email).id,
                        idnv = TDatPhong.IDNV,
                        ngaycheckin = DateTime.Now.Date,
                        trangthai = "Đặt trước"
                    };
                    DTODB.db.checkins.Add(checkinmoi);
                    DTODB.db.SaveChanges();

                    // Lấy id của checkin mới thêm vào
                    int idcheckin = checkinmoi.id;

                    // Thêm tempkhachhang mới vào DB
                    decimal.TryParse(khachtt, out decimal tientra);
                    tempkhachhang tempkh = new tempkhachhang()
                    {
                        idkh = DTODB.db.khachhangs.FirstOrDefault(p => p.email == email).id,
                        idcheckin = idcheckin,
                        tienkhachtra = tientra,
                        ngayvao = nDen,
                        ngayra = nDi,
                    };
                    DTODB.db.tempkhachhangs.Add(tempkh);
                    DTODB.db.SaveChanges();

                    // Thêm checkin_phong mới vào DB
                    checkin_phong cpmoi = new checkin_phong()
                    {
                        idcheckin = idcheckin,
                        idphong = TDatPhong.IdPhong
                    };
                    DTODB.db.checkin_phong.Add(cpmoi);
                    DTODB.db.SaveChanges();

                    transaction.Commit(); // Ổn thì commit 
                    return true;
                }
                catch (Exception a)
                {
                    transaction.Rollback(); // Ko ổn thì rollback lại tránh việc dữ liệu xảy ra xung đột
                    MessageBox.Show(a.ToString());
                    return false;
                }
            }
        }




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
