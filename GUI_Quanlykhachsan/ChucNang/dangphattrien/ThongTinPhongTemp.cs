using DTO_Quanly;
using System;
using System.ComponentModel.Design;
using System.Linq;
using System.Windows.Forms;

namespace GUI_Quanlykhachsan.ChucNang.dangphattrien
{
    public partial class ThongTinPhongTemp : Form
    {
        private int _idp;
        public ThongTinPhongTemp(int idphong, DateTime? ngayden, DateTime? ngaydi)
        {
            InitializeComponent();
            this._idp = idphong;
        }

        public void loadtt()
        {
            var thongtinp = DTODB.db.view_trangthai_phong_hientai.SingleOrDefault(a => a.idphong == this._idp);
            tenphong.Text = thongtinp.tenphong.ToString();
            loaiphong.Text = thongtinp.loaiphong.ToString();
            mota.Text = thongtinp.mota.ToString();
            giaphong.Text = thongtinp.giaphong.ToString();
            khuvuc.Text = thongtinp.tenkhuvuc.ToString();
            if(thongtinp.trangthai_text.ToString() == "Trống")
            {
                trangthai.Text = "Trống";
            }
            else
            {
                trangthai.Text = "Đã đặt";
                
            }
        }

        private void label9_Click(object sender, System.EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void ThongTinPhongTemp_Load(object sender, System.EventArgs e)
        {
            loadtt();
        }
    }
}
