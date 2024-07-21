using DAL_Quanly.Repository.QuanLyDatPhong.KhachHang;
using DTO_Quanly;
using System;
using System.Linq;
using System.Windows.Forms;

namespace BUS_Quanly.Services.QuanLyDatPhong.DatTruoc_NhanP
{
    public class Tdphong
    {
        DatTruoc_TraP truyvan = new DatTruoc_TraP();

        public Tdphong(DatTruoc_TraP truyvan)
        {
            this.truyvan = truyvan;
        }

        public Tdphong()
        {

        }

        public bool DatTruoc(string tenkh, string email, string sdt, bool gender, string diachi, DateTime Nsinh, string duongdan, string khachtt, DateTime nDen, DateTime nDi)
        {
            try
            {
                if (DTODB.db.khachhangs.FirstOrDefault(x => x.email == email) == null)
                {
                    return truyvan.DatTruoc(tenkh, email, sdt, gender, diachi, Nsinh, duongdan, khachtt, nDen, nDi);
                }
                else
                {
                    MessageBox.Show("Email khách hàng đã tồn tại!");
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }


        public bool DatPhong(string tenkh, string email, string sdt, bool gender, string diachi, DateTime Nsinh, string duongdan, string khachtt, DateTime nDen, DateTime nDi)
        {
            try
            {
                if (DTODB.db.khachhangs.FirstOrDefault(x => x.email == email) == null)
                {
                    return truyvan.DatPhong(tenkh, email, sdt, gender, diachi, Nsinh, duongdan, khachtt, nDen, nDi);
                }
                else
                {
                    MessageBox.Show("Email khách hàng đã tồn tại!");
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }




    }
}
