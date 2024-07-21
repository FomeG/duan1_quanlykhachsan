using DTO_Quanly;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GUI_Quanlykhachsan.ChucNang
{
    public partial class HoaDonTEMP : Form
    {
        public HoaDonTEMP()
        {
            InitializeComponent();
        }

        private void HoaDonTEMP_Load(object sender, System.EventArgs e)
        {
            loadhoadon();
        }
        public void loadhoadon()
        {
            var query = from hoadon in DTODB.db.hoadons.ToList()
                        join khachhang in DTODB.db.khachhangs on hoadon.idkh equals khachhang.id
                        join nhanvien in DTODB.db.nhanviens on hoadon.idnv equals nhanvien.idnv
                        select new
                        {
                            hoadon.idhoadon,
                            TenNhanVien = nhanvien.ten,
                            TenKhachHang = khachhang.ten,
                            Tuoi = (DateTime.Now.Year - (khachhang.ngaysinh?.Year ?? DateTime.Now.Year)) -
                                   ((DateTime.Now.Month < (khachhang.ngaysinh?.Month ?? DateTime.Now.Month)) ||
                                   (DateTime.Now.Month == (khachhang.ngaysinh?.Month ?? DateTime.Now.Month) && DateTime.Now.Day < (khachhang.ngaysinh?.Day ?? DateTime.Now.Day)) ? 1 : 0),
                            khachhang.gioitinh,
                            hoadon.ngaytao,
                            hoadon.tongtien,
                            hoadon.songuoi,
                            hoadon.trangthai
                        };



            gview1.DataSource = query.ToList();


        }
    }
}
