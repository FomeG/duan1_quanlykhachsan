using DTO_Quanly;
using DTO_Quanly.Model.DB;
using System.Collections.Generic;
using System.Linq;

namespace DAL_Quanly.Repository.QuanLyDatPhong.ThanhToan
{
    public class TruyVanThanhToan
    {
        public List<dichvu> truyendichvu()
        {
            return DTODB.db.dichvus.ToList();
        }

    }
}
