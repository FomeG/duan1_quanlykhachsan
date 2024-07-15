using DTO_Quanly;
using DTO_Quanly.Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
