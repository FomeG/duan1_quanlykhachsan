using DTO_Quanly;
using System.Linq;
using System.Windows.Forms;

namespace GUI_Quanlykhachsan.ChucNang
{
    public partial class HoaDon : Form
    {
        public HoaDon()
        {
            InitializeComponent();
            loaddl();
        }
        private void HoaDon_Load(object sender, System.EventArgs e)
        {

        }
        public void loaddl()
        {
            var listnhanvien = DTODB.db.dichvus.Where(nv => nv.tt == false).ToList();
            gview1.DataSource = listnhanvien;
        }
    }
}
