using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_Quanly.Model.DB;



namespace DAL_Quanly.IRepository
{
  
    public interface IKhachHang
    {
        List<khachhang> getlist();
        List<khachhang> getlistbyid(int id);

        void them(khachhang khachhang);

        void sua(int id, khachhang khachhang);
        void xoa(int id);

    }
}
