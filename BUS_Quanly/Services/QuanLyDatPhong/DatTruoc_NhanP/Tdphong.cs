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

        public bool checkngay(DateTime nDen, DateTime nDi, int IdPhong)
        {
            string ngaydenStr = nDen.ToString("yyyy-MM-dd HH:mm:ss");
            string ngaydiStr = nDi.ToString("yyyy-MM-dd HH:mm:ss");
                if(DTODB.db.kiemtra_dsdattruoc_chitiet(ngaydenStr, ngaydiStr, IdPhong).ToList().Count == 0)
            {
                return true;
            }
            return false;

        }

        public bool DatPhong(int Idphong,string tenkh, string email, string sdt, bool gender, string diachi, DateTime Nsinh, string duongdan, string khachtt, DateTime nDen, DateTime nDi, bool kiemtra)
        {
            try
            {
                if (checkngay(nDen, nDi, Idphong))
                {
                    if (DTODB.db.khachhangs.FirstOrDefault(x => x.email == email) != null && kiemtra == true) // ko kiểm tra!
                    {
                        return truyvan.DatPhong(tenkh, email, sdt, gender, diachi, Nsinh, duongdan, khachtt, nDen, nDi, true);
                    }
                    else
                    {
                        if (DTODB.db.khachhangs.FirstOrDefault(x => x.email == email) != null && kiemtra == false)// có kiểm tra
                        {
                            MessageBox.Show("Email khách hàng đã tồn tại!");
                            return false;
                        }
                        else
                        {
                            return truyvan.DatPhong(tenkh, email, sdt, gender, diachi, Nsinh, duongdan, khachtt, nDen, nDi, false);
                        }
                    }
                }
                MessageBox.Show($"Phòng này đã có người ở từ: {nDen.ToString()} đến {nDi.ToString()} rồi!");
                return false;

            }
            catch
            {
                return false;
            }
        }




    }
}
