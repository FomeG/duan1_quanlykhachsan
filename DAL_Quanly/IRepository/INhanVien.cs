using DTO_Quanly.Model;
using System.Collections.Generic;

namespace DAL_Quanly.IRepository
{
    public interface INhanVien
    {
        List<nhanvien> getlist();
        List<nhanvien> getlistbyid(int id);
        void them(nhanvien nhanvien);

        void sua(int id, nhanvien nhanvien);
        void xoa(int id);

    }
}
