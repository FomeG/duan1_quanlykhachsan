using BUS_Quanly;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI_Quanlykhachsan.ChucNang
{
    public partial class Qly_NhanVien : Form
    {
        Snhanvien bus_nhanvien = new Snhanvien();
        public Qly_NhanVien()
        {
            InitializeComponent();
            reload();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        // Hàm tải lại trang
        public void reload()
        {
            gview1.DataSource = bus_nhanvien.hienthi().ToList();
        }
        private void guna2GradientButton4_Click(object sender, System.EventArgs e)
        {

        }

        private void Qly_NhanVien_Load(object sender, System.EventArgs e)
        {

        }

        public bool checktrong()
        {
            if (txtten.Text.Trim() == "" || txtsdt.Text.Trim() == "")
            {
                MessageBox.Show("Không được để trống tên hoặc sdt");
                return false;
            }
            else if (!rdnam.Checked && !rdnu.Checked)
            {
                MessageBox.Show("Vui lòng chọn giới tính");
                return false;
            }
            else
            {
                return true;
            }
        }
        private void guna2GradientButton1_Click(object sender, System.EventArgs e)
        {
            if (checktrong())
            {

            }
        }
    }
}
