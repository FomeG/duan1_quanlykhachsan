using DTO_Quanly;
using DTO_Quanly.Transfer;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GUI_Quanlykhachsan.ChucNang.Tai_Khoan
{
    public partial class DoiMatKhau : Form
    {
        public DoiMatKhau()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public void Tailai()
        {
            txtmk1.Text = txtmk2.Text = txtmk3.Text = "";
        }

        public void loadtt()
        {
            var nvhtai = DTODB.db.nhanviens.Find(TDatPhong.IDNV);

            txttennv.Text = nvhtai.ten;
            txtemailnv.Text = nvhtai.email;
            txttaikhoannv.Text = nvhtai.taikhoan;
        }

        public bool check()
        {
            string taikhoannv = DTODB.db.nhanviens.Find(TDatPhong.IDNV).taikhoan;
            if (txtmk1.Text.Trim() == "" || txtmk2.Text.Trim() == "" || txtmk3.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng điền thông tin!");
                return false;
            }


            if (txtmk1.Text.Trim() != DTODB.db.taikhoans.Find(taikhoannv).matkhau)
            {
                MessageBox.Show("Mật khẩu hiện tại không đúng!");
                return false;
            }

            if (txtmk2.Text.Trim() != txtmk3.Text.Trim())
            {
                MessageBox.Show("Mật khẩu nhập lại không trùng nhau!");
                return false;
            }

            return true;

        }

        // Nút đổi mật khẩu
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (check())
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn đổi mật khẩu?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DTODB.db.taikhoans.SingleOrDefault(x => x.taikhoan1 == txttaikhoannv.Text).matkhau = txtmk2.Text;
                    DTODB.db.SaveChanges();

                    Tailai();
                    MessageBox.Show("Đổi mật khẩu thành công!");
                }
            }
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void DoiMatKhau_Load(object sender, EventArgs e)
        {
            loadtt();
        }
    }
}
