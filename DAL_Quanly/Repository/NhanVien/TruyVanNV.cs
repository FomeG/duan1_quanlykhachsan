using DTO_Quanly;
using DTO_Quanly.Model.DB;
using DTO_Quanly.Transfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DAL_Quanly.Repository.NhanVien
{
    public class TruyVanNV
    {

        public IEnumerable<dynamic> getlist()
        {
            // Nếu là quản lý thì sẽ xem được nhân viên nhưng không thể xem được admin
            if (TDatPhong.VaiTro == 2)
            {
                var listnhanvien = from a in DTODB.db.nhanviens.ToList()
                                   join b in DTODB.db.taikhoans.ToList()
                               on a.taikhoan equals b.taikhoan1
                                   join c in DTODB.db.vaitroes.ToList()
                                   on b.loaitk equals c.id
                                   where b.loaitk == 3
                                   select new
                                   {
                                       Ten = a.ten,
                                       Email = a.email,
                                       SDT = a.sdt,
                                       Gioitinh = a.gioitinh,
                                       Diachi = a.diachi,
                                       Ngaysinh = a.ngaysinh,
                                       Taikhoan = a.taikhoan,
                                       Vaitro = c.vaitro1,
                                       TrangThai = a.tt==false ? "Đang làm việc" : "Đã nghỉ"
                                   };
                return listnhanvien.ToList();

            }
            else
            {
                var listnhanvien = from a in DTODB.db.nhanviens.ToList()
                                   join b in DTODB.db.taikhoans.ToList()
                               on a.taikhoan equals b.taikhoan1
                                   join c in DTODB.db.vaitroes.ToList()
                                   on b.loaitk equals c.id
                                   where b.loaitk == 3 && a.tt == false
                                   select new
                                   {
                                       Ten = a.ten,
                                       Email = a.email,
                                       SDT = a.sdt,
                                       Gioitinh = a.gioitinh,
                                       Diachi = a.diachi,
                                       Ngaysinh = a.ngaysinh,
                                       Taikhoan = a.taikhoan,
                                       Vaitro = c.vaitro1,
                                   };
                return listnhanvien.ToList();
            }
        }

        public List<vaitro> listvaitro()
        {
            return DTODB.db.vaitroes.ToList();
        }

        public bool them(nhanvien nv, taikhoan tk)
        {
            using (var transaction = DTODB.db.Database.BeginTransaction())
            {
                try
                {
                    taikhoan tkmoi = new taikhoan()
                    {
                        taikhoan1 = tk.taikhoan1,
                        matkhau = tk.matkhau,
                        loaitk = tk.loaitk,
                    };

                    DTODB.db.taikhoans.Add(tkmoi);
                    DTODB.db.SaveChanges();


                    nhanvien nvmoi = new nhanvien();
                    nvmoi.ten = nv.ten;
                    nvmoi.idnv = nv.idnv;
                    nvmoi.email = nv.email;
                    nvmoi.diachi = nv.diachi;
                    nvmoi.gioitinh = nv.gioitinh;
                    nvmoi.sdt = nv.sdt;
                    nvmoi.taikhoan = nv.taikhoan;
                    nvmoi.ngaysinh = nv.ngaysinh;
                    nvmoi.tt = false;

                    DTODB.db.nhanviens.Add(nvmoi);
                    DTODB.db.SaveChanges();

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi!");
                    transaction.Rollback();
                    return false;
                }
            }

        }
        public bool sua(int id, nhanvien nv, string mkmoi, int? loai)
        {
            using (var transaction = DTODB.db.Database.BeginTransaction())
            {
                try
                {
                    var tkcantim = (from a in DTODB.db.nhanviens join b in DTODB.db.taikhoans on a.taikhoan equals b.taikhoan1 where a.idnv == id select a.taikhoan).FirstOrDefault();

                    taikhoan tkcansua = DTODB.db.taikhoans.Find(tkcantim);
                    if (mkmoi == "")
                    {
                        tkcansua.loaitk = loai ?? 3;
                    }
                    else
                    {
                        tkcansua.matkhau = mkmoi;
                        tkcansua.loaitk = loai ?? 3;
                    }

                    DTODB.db.SaveChanges();

                    nhanvien nvcansua = DTODB.db.nhanviens.Find(id);
                    nvcansua.ten = nv.ten;
                    nvcansua.email = nv.email;
                    nvcansua.sdt = nv.sdt;
                    nvcansua.gioitinh = nv.gioitinh;
                    nvcansua.diachi = nv.diachi;
                    nvcansua.ngaysinh = nv.ngaysinh;
                    nvcansua.taikhoan = nv.taikhoan;



                    DTODB.db.SaveChanges();
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return false;
                }

            }
        }
        public bool xoa(int id)
        {
            using (var transaction = DTODB.db.Database.BeginTransaction())
            {
                try
                {
                    if(DTODB.db.nhanviens.Find(id).tt == true)
                    {
                        DTODB.db.nhanviens.Find(id).tt = false;
                    DTODB.db.SaveChanges();
                    transaction.Commit();
                    return true;
                    }
                    else
                    {
                        DTODB.db.nhanviens.Find(id).tt = true;

                        DTODB.db.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                }
                catch
                {
                    transaction.Rollback();
                    MessageBox.Show("Đã có lỗi xảy ra");
                    return false;
                }
            }
        }
    }
}
