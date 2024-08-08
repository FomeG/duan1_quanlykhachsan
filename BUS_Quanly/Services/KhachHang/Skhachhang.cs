using DAL_Quanly.Repository.KhachHang;
using DTO_Quanly.Model.DB;
using DTO_Quanly.Model.NoiBang;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BUS_Quanly.Services.KhachHang
{

    public class Skhachhang
    {
        TruyVanKH TruyVanKH = new TruyVanKH();
        public Skhachhang()
        {

        }

        public Skhachhang(TruyVanKH truyVanKH)
        {
            TruyVanKH = truyVanKH;
        }

        public List<NoiKH> hienthi()
        {
            return TruyVanKH.getlist();
        }
        public bool ThemKhachHang(khachhang khachhang)
        {
            return TruyVanKH.them(khachhang);
        }
        public bool SuaKhachHang(khachhang khachhang)
        {
            try
            {
                TruyVanKH.sua(khachhang.id, khachhang);
                MessageBox.Show("Sửa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa thất bại, lỗi: " + ex.Message);
                return false;
            }
        }
        public void Xoa(khachhang khachhang)
        {
            try
            {
                if (khachhang != null)
                {
                    TruyVanKH.xoa(khachhang.id);
                    MessageBox.Show("Xoá khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Khách hàng không tồn tại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xoá thất bại, lỗi: " + ex.Message);
            }
        }
    }
}
