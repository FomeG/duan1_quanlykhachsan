using System.Windows.Forms;

namespace GUI_Quanlykhachsan.ChucNang.Tai_Khoan
{
    public partial class FrmSettings : Form
    {

        private readonly DoiMatKhau _frmdoimk;
        public FrmSettings()
        {
            this._frmdoimk = new DoiMatKhau();
            InitializeComponent();
        }

        private void guna2GradientButton1_Click(object sender, System.EventArgs e)
        {
            _frmdoimk.Show();
        }
    }
}
