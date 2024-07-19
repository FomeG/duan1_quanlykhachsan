using BUS_Quanly;
using System.ComponentModel;
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

        // Nút tải lại trang
        private void guna2GradientButton4_Click(object sender, System.EventArgs e)
        {
            txttk.Enabled = true;
            reload();
        }

        private void Qly_NhanVien_Load(object sender, System.EventArgs e)
        {

        }

        // validate nhân viên
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
            else if (!txtsdt.Text.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại không được chứa chữ!");
                return false;
            }
            else if (txttk.Text.Trim() == "" || txtmk.Text.Trim() == "")
            {
                MessageBox.Show("Không được để trống tk hoặc mật khẩu!");
                return false;
            }
            else if (txttk.Text.Trim() != "" && txtmk.Text.Trim() != "" && txtmk.Text != txtmk2.Text)
            {
                MessageBox.Show("Mật khẩu nhập lại không trùng!");
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
                string gioitinh;
                if (rdnam.Checked)
                {
                    gioitinh = "Nam";
                }
                else gioitinh = "Nữ";
                if (bus_nhanvien.addnv(txtten.Text, txtemail.Text, txtsdt.Text, gioitinh, txtdiachi.Text, NgaySinhPicker.Value.Date, txttk.Text, txtmk.Text))
                {
                    MessageBox.Show("Thêm thành công!");
                    reload();
                }
            }

        }

        private void gview1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dong = gview1.Rows[e.RowIndex];
            txttk.Enabled = false;


        }
    }
}
