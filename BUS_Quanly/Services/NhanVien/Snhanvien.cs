using DAL_Quanly.Repository.NhanVien;
using DTO_Quanly.Model.DB;
using System.Collections.Generic;


namespace BUS_Quanly
{
    public class Snhanvien
    {
        TruyVanNV TruyVanNV = new TruyVanNV();
        public Snhanvien()
        {

        }

        public Snhanvien(TruyVanNV truyVanNV)
        {
            TruyVanNV = truyVanNV;
        }

        public List<nhanvien> hienthi()
        {
            return TruyVanNV.getlist();
        }
    }
}
