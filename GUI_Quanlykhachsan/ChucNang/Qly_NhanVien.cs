using BUS_Quanly;
using DTO_Quanly;
using DTO_Quanly.Transfer;
using System;
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
            SetupVaiTro();
        }

        private void SetupVaiTro()
        {
            if (TDatPhong.VaiTro != 1)
            {
                CbVaitro.Enabled = CbVaitro.Visible = labelVaiTro.Enabled = labelVaiTro.Visible = false;
                CbVaitro.SelectedIndex = -1;
            }
            else
            {
                CbVaitro.Items.AddRange(bus_nhanvien.listvt().Select(item => item.vaitro1).ToArray());
            }
        }

        // Hàm tải lại trang
        public void reload() => gview1.DataSource = bus_nhanvien.hienthi().ToList();

        // Nút tải lại trang
        public void loadtrang()
        {
            txtten.Text = txtemail.Text = txttk.Text = txtmk.Text = txtmk2.Text = txttimkiem.Text = txtdiachi.Text = txtsdt.Text = "";
            rdnam.Checked = rdnu.Checked = false;
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            txttk.Enabled = true;
            loadtrang();
            reload();
        }

        private void Qly_NhanVien_Load(object sender, EventArgs e) {
            reload();
        }

        // validate nhân viên
        public bool checktrong()
        {
            if (string.IsNullOrWhiteSpace(txtten.Text) || string.IsNullOrWhiteSpace(txtsdt.Text))
            {
                MessageBox.Show("Không được để trống tên hoặc sdt");
                return false;
            }
            if (!rdnam.Checked && !rdnu.Checked)
            {
                MessageBox.Show("Vui lòng chọn giới tính");
                return false;
            }
            if (!IsDigitsOnly(txtsdt.Text))
            {
                MessageBox.Show("Số điện thoại không được chứa chữ!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txttk.Text) || string.IsNullOrWhiteSpace(txtmk.Text))
            {
                MessageBox.Show("Không được để trống tk hoặc mật khẩu!");
                return false;
            }
            if (txtmk.Text != txtmk2.Text)
            {
                MessageBox.Show("Mật khẩu nhập lại không trùng!");
                return false;
            }
            return true;
        }

        public bool checktrongSua()
        {
            if (string.IsNullOrWhiteSpace(txtten.Text) || string.IsNullOrWhiteSpace(txtsdt.Text))
            {
                MessageBox.Show("Không được để trống tên hoặc sdt");
                return false;
            }
            if (!rdnam.Checked && !rdnu.Checked)
            {
                MessageBox.Show("Vui lòng chọn giới tính");
                return false;
            }
            if (!IsDigitsOnly(txtsdt.Text))
            {
                MessageBox.Show("Số điện thoại không được chứa chữ!");
                return false;
            }
            if (!string.IsNullOrEmpty(txtmk.Text) && txtmk.Text != txtmk2.Text)
            {
                MessageBox.Show("Mật khẩu nhập lại không trùng!");
                return false;
            }
            return true;
        }




        // Hàm check chuỗi có phải 1 số hay không, sau này bảo trì có thể thay đổi thay vì dùng mỗi char.isdigit
        private bool IsDigitsOnly(string str) => str.All(c => c >= '0' && c <= '9');

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (checktrong())
            {
                string gioitinh = rdnam.Checked ? "Nam" : "Nữ";
                int vaitro = TDatPhong.VaiTro != 1 ? 3 : (CbVaitro.SelectedIndex + 1) == 0 ? 3 : CbVaitro.SelectedIndex + 1;
                if (bus_nhanvien.addnv(txtten.Text, txtemail.Text, txtsdt.Text, gioitinh, txtdiachi.Text, NgaySinhPicker.Value.Date, txttk.Text, txtmk.Text, vaitro))
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

            txtten.Text = dong.Cells[0].Value.ToString();
            txtemail.Text = dong.Cells[1].Value.ToString();
            txtsdt.Text = dong.Cells[2].Value.ToString();
            rdnam.Checked = dong.Cells[3].Value.ToString() == "Nam";
            rdnu.Checked = !rdnam.Checked;
            txtdiachi.Text = dong.Cells[4].Value.ToString();
            NgaySinhPicker.Value = (DateTime)dong.Cells[5].Value;
            txttk.Text = dong.Cells[6].Value.ToString();
            if (TDatPhong.VaiTro == 1)
            {
                CbVaitro.SelectedItem = dong.Cells[7].Value.ToString();
            }
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            if (gview1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dữ liệu cần sửa!");
            }
            else if (checktrongSua() && MessageBox.Show("Có chắc chắn muốn sửa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int idnvcantim = DTODB.db.nhanviens.First(p => p.taikhoan == txttk.Text).idnv;
                string gender = rdnam.Checked ? "Nam" : "Nữ";
                int vaitro = TDatPhong.VaiTro != 1 ? 3 : (CbVaitro.SelectedIndex + 1) == 0 ? 3 : CbVaitro.SelectedIndex + 1;
                if (bus_nhanvien.suanv(idnvcantim, txtten.Text, txtemail.Text, txtsdt.Text, gender, txtdiachi.Text, NgaySinhPicker.Value.Date, txttk.Text, txtmk.Text, vaitro))
                {
                    MessageBox.Show("Sửa thành công!");
                    reload();
                }
            }
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            if (gview1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dữ liệu cần xoá!");
            }
            else if (MessageBox.Show("Có chắc chắn muốn đổi trạng thái?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int idnvcantim = DTODB.db.nhanviens.First(p => p.taikhoan == txttk.Text).idnv;
                if (bus_nhanvien.Xoa(idnvcantim))
                {
                    MessageBox.Show("thành công!");
                    reload();
                }
            }
        }
    }
}