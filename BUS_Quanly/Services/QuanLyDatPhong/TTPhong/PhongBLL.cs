using DAL_Quanly.Repository.QuanLyDatPhong.TTPhong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_Quanly.Services.QuanLyDatPhong.TTPhong
{
    public class PhongBLL
    {
        private readonly PhongDAL _phongDAL;

        public PhongBLL()
        {
            _phongDAL = new PhongDAL();
        }

        public decimal GetGiaPhong(int idPhong)
        {
            return _phongDAL.GetGiaPhong(idPhong);
        }

        public dynamic GetDatPhongInfo(int idPhong)
        {
            return _phongDAL.GetDatPhongInfo(idPhong);
        }

        public dynamic GetThongTinDatPhong(int idPhong)
        {
            return _phongDAL.GetThongTinDatPhong(idPhong);
        }
    }
}
