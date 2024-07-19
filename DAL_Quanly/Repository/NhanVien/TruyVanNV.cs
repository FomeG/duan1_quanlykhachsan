using DAL_Quanly.IRepository;
using DTO_Quanly;
using DTO_Quanly.Model.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace DAL_Quanly.Repository.NhanVien
{
    public class TruyVanNV
    {

        public List<nhanvien> getlist()
        {
            return DTODB.db.nhanviens.ToList();
        }

        public List<nhanvien> getlistbyid(int id)
        {
            throw new NotImplementedException();
        }

        public void sua(int id, nhanvien nhanvien)
        {
            throw new NotImplementedException();
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
                        loaitk = 2
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

        public bool sua(int id, nhanvien nv, taikhoan tk)
        {
            using (var transaction = DTODB.db.Database.BeginTransaction())
            {
                try
                {
                    var tkcantim = (from a in DTODB.db.nhanviens join b in DTODB.db.taikhoans on a.taikhoan equals b.taikhoan1 where a.idnv == id select a.taikhoan).FirstOrDefault();


                    taikhoan tkcansua = DTODB.db.taikhoans.Find(tkcantim);
                    tkcansua.matkhau = tk.matkhau;
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

        public void xoa(int id)
        {
            throw new NotImplementedException();
        }
    }
}
