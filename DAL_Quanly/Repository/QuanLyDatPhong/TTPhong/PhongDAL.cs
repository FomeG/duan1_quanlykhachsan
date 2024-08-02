using DTO_Quanly;
using System.Linq;

namespace DAL_Quanly.Repository.QuanLyDatPhong.TTPhong
{
    public class PhongDAL
    {
        public decimal GetGiaPhong(int idPhong)
        {
            return (from a in DTODB.db.phongs
                    join b in DTODB.db.loaiphongs on a.loaiphong equals b.idloaiphong
                    where a.idphong == idPhong
                    select b.giaphong).FirstOrDefault();
        }

        public dynamic GetDatPhongInfo(int idPhong)
        {
            return DTODB.db.view_dsdattruoc_chitiet
                .Where(x => x.idphong == idPhong)
                .Select(x => new { x.ngayden, x.ngaydi })
                .FirstOrDefault();
        }

        public dynamic GetThongTinDatPhong(int idPhong)
        {
            return (from dsd in DTODB.db.dsdattruocs
                    join kh in DTODB.db.khachhangs on dsd.idkh equals kh.id
                    join p in DTODB.db.phongs on dsd.idphong equals p.idphong
                    join cip in DTODB.db.checkin_phong on p.idphong equals cip.idphong
                    where p.idphong == idPhong
                    select new { IdKhachHang = kh.id, IdCheckin = cip.idcheckin })
                    .FirstOrDefault();
        }
    }
}
