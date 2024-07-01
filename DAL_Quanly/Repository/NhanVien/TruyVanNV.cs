using DAL_Quanly.IRepository;
using DTO_Quanly;
using DTO_Quanly.Model;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public void them(nhanvien nhanvien)
        {
            throw new NotImplementedException();
        }

        public void xoa(int id)
        {
            throw new NotImplementedException();
        }
    }
}
