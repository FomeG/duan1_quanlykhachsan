using DAL_Quanly.Repository.QuanLyDatPhong.ThanhToan;
using DTO_Quanly.Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_Quanly.Services.QuanLyDatPhong.ThanhToan_DV
{
    public class TTDichVu
    {
        private readonly TruyVanThanhToan _truyvan;
        public TTDichVu()
        {

        }
        public TTDichVu(TruyVanThanhToan truyVanThanhToan)
        {
            _truyvan = truyVanThanhToan;
        }


        public List<dichvu> hienthidv()
        {
            return _truyvan.truyendichvu().ToList();
        }
    }
}
