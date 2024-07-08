using DAL_Quanly.IRepository;
using DTO_Quanly;
using DTO_Quanly.Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DAL_Quanly.Repository.NhanVien
{
    public class TruyVanNV : INhanVien
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

        public void them(nhanvien nv)
        {

            try
            {
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi!");
            }
        }

        public void xoa(int id)
        {
            throw new NotImplementedException();
        }
    }
}
