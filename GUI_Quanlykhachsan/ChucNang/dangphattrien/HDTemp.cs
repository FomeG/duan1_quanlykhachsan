using BUS_Quanly.Services.QuanLyDatPhong.ThanhToan_DV;
using DTO_Quanly;
using System;
using System.Drawing;
using System.Linq;
using System.Web.Compilation;
using System.Windows.Forms;

namespace GUI_Quanlykhachsan.ChucNang.dangphattrien
{
    public partial class HDTemp : Form
    {
        private int IdCin;
        private int Idp;
        private int IdKH;

        private int Idhd;
        TTDichVu _dv = new TTDichVu();

        public HDTemp(int idcheckin, int idkh, int idphong, int idhoadon)
        {
            InitializeComponent();
            this.IdCin = idcheckin;
            this.Idp = idphong;
            this.IdKH = idkh;
            this.Idhd = idhoadon;

            loadtt();

            MaHD.Text = idhoadon.ToString();
            ngaytaoHD.Text = DateTime.Now.ToString();
        }
        public void loadtt()
        {
            var hoadontemp = (from p in DTODB.db.phongs
                              join cp in DTODB.db.checkin_phong on p.idphong equals cp.idphong
                              join c in DTODB.db.checkins on cp.idcheckin equals c.id
                              join tk in DTODB.db.tempkhachhangs on c.id equals tk.idcheckin
                              join kh in DTODB.db.khachhangs on tk.idkh equals kh.id
                              join lp in DTODB.db.loaiphongs on p.loaiphong equals lp.idloaiphong
                              join kv in DTODB.db.khuvucs on p.khuvuc equals kv.id
                              where p.idphong == Idp
                              select new
                              {
                                  kh.ten,
                                  kh.diachi,
                                  tk.ngayvao,
                                  tk.ngayra,
                                  lp.giaphong,
                                  tk.tienkhachtra,

                                  p.tenphong,
                                  lp.loaiphong1,
                                  lp.mota,
                                  kv.tenkhuvuc,

                              }).FirstOrDefault();

            txttenkh.Text = hoadontemp.ten;
            txtngayvao.Text = hoadontemp.ngayvao.ToString();
            txtngayradk.Text = hoadontemp.ngayra.ToString();
            txtngayrathucte.Text = DateTime.Now.Date.ToString();
            txttienphong.Text = hoadontemp.giaphong.ToString();
            txttientratruoc.Text = hoadontemp.tienkhachtra.ToString();

            tenphong.Text = hoadontemp.tenphong.ToString();
            loaiphong.Text = hoadontemp.loaiphong1.ToString();
            giaphong.Text = hoadontemp.giaphong.ToString();
            khuvuc.Text = hoadontemp.tenkhuvuc.ToString();


            gview1.Columns.Clear();
            var list = _dv.GetCheckinDichVuList(IdCin);
            gview1.DataSource = list;
        }

        private void guna2GradientButton1_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {

        }
    }
}
