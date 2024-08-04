using DTO_Quanly;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Windows.Forms;

namespace GUI_Quanlykhachsan.ChucNang
{
    public partial class Voucher : Form
    {
        public Voucher()
        {
            InitializeComponent();
            loadtt();
        }


        public void loadtt()
        {
            gview1.ClearSelection();
            var listvoucher = from a in DTODB.db.vouchers.ToList()
                              join nv in DTODB.db.nhanviens on a.idnv equals nv.idnv
                              select new
                              {
                                  a.MaVoucher,
                                  Nguoitao = nv.ten,
                                  a.soluong,
                                  a.ngaylap,
                                  a.ngayhethan,
                                  a.giamgia,
                                  Trangthai = a.trangthai == false ? "Còn" : "Hết hạn"
                              };
            gview1.DataSource = listvoucher.ToList();
        }

        public void reload()
        {

        }


        private void guna2GradientButton4_Click(object sender, System.EventArgs e)
        {

        }
        private void guna2GradientButton1_Click(object sender, System.EventArgs e)
        {

        }

      
    }
}
