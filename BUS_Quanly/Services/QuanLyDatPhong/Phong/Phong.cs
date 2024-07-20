using DTO_Quanly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_Quanly.Services.QuanLyDatPhong.Phong
{
    public class PhongService
    {
        public void DatTruoc(int idPhong)
        {
            var phong = DTODB.db.phongs.Find(idPhong);
            if (phong != null)
            {
                phong.trangthai = 2;
                DTODB.db.SaveChanges();
            }
        }

        public void NhanPhong(int idPhong)
        {
            var phong = DTODB.db.phongs.Find(idPhong);
            if (phong != null)
            {
                phong.trangthai = 3;
                DTODB.db.SaveChanges();
            }
        }

        public void TraPhong(int idPhong)
        {
            var phong = DTODB.db.phongs.Find(idPhong);
            if (phong != null)
            {
                phong.trangthai = 1;
                DTODB.db.SaveChanges();
            }
        }
    }

}
