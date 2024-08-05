using DTO_Quanly;
using DTO_Quanly.Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace DAL_Quanly.Repository.KhachHang
{
    public class TruyVanKH
    {
        public List<khachhang> getlist()
        {
            return DTODB.db.khachhangs.Where(a=>a.tt==false).ToList();
        }

        public List<khachhang> getlistbyid(int id)
        {
            throw new NotImplementedException();
        }

        public void sua(int id, khachhang khachhang)
        {
            try
            {
                var kh = DTODB.db.khachhangs.FirstOrDefault(k => k.id == id);
                if (kh != null)
                {
                    kh.ten = khachhang.ten;
                    kh.email = khachhang.email;
                    kh.diachi = khachhang.diachi;
                    kh.gioitinh = khachhang.gioitinh;
                    kh.sdt = khachhang.sdt;
                    kh.ngaysinh = khachhang.ngaysinh;

                    DTODB.db.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Khách hàng không tồn tại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật khách hàng: " + ex.Message);
            }
        }

        public bool them(khachhang kh)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn thêm không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    khachhang khmoi = new khachhang();
                    khmoi.ten = kh.ten;
                    khmoi.id = kh.id;
                    khmoi.email = kh.email;
                    khmoi.diachi = kh.diachi;
                    khmoi.gioitinh = kh.gioitinh;
                    khmoi.sdt = kh.sdt;
                    khmoi.anh = kh.anh;
                    khmoi.tt = false;

                    khmoi.ngaysinh = kh.ngaysinh;

                    DTODB.db.khachhangs.Add(khmoi);
                    DTODB.db.SaveChanges();
                    MessageBox.Show("Thêm thành công!");
                }
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi!");
                return false;
            }

        }

        public void xoa(int id)
        {
            try
            {
                var kh = DTODB.db.khachhangs.FirstOrDefault(k => k.id == id);
                if (kh != null)
                {
                    kh.tt = true;
                    DTODB.db.SaveChanges();

                }
                else
                {
                    MessageBox.Show("Khách hàng không tồn tại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa khách hàng: " + ex.Message);
            }
        }
    }
}
