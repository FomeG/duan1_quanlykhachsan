using BUS_Quanly;
using DTO_Quanly;
using System;
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
        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        // Hàm tải lại trang
        public void reload()
        {
            gview1.DataSource = bus_nhanvien.hienthi().ToList();
        }

        // Nút tải lại trang
        public void loadtrang()
        {
            gview1.DataSource = bus_nhanvien.hienthi().ToList();
            txtten.Text = "";
            txtemail.Text = "";
            rdnam.Checked = false;
            rdnu.Checked = false;
            txttk.Text = "";
            txtmk.Text = "";
            txtmk2.Text = "";
            txttimkiem.Text = "";
            txtdiachi.Text = "";
            txtsdt.Text = "";
        }
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

            txtten.Text = dong.Cells[0].Value.ToString();
            txtemail.Text = dong.Cells[1].Value.ToString();
            txtsdt.Text = dong.Cells[2].Value.ToString();
            if (dong.Cells[3].Value.ToString() == "Nam")
            {
                rdnam.Checked = true;
            }
            else rdnu.Checked = false;

            txtdiachi.Text = dong.Cells[4].Value.ToString();
            NgaySinhPicker.Value = (DateTime)dong.Cells[5].Value;
            txttk.Text = dong.Cells[6].Value.ToString();


        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            if (gview1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dữ liệu cần sửa!");
            }
            else
            {
                if (checktrong())
                {
                    if (MessageBox.Show("Có chắc chắn muốn sửa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int idnvcantim = DTODB.db.nhanviens.FirstOrDefault(p => p.taikhoan == txttk.Text).idnv;
                        string gender = rdnam.Checked ? "Nam" : "Nữ";
                        if (bus_nhanvien.suanv(idnvcantim, txtten.Text, txtemail.Text, txtsdt.Text, gender, txtdiachi.Text, NgaySinhPicker.Value.Date, txttk.Text, txtmk.Text))
                        {
                            MessageBox.Show("Sửa thành công!");
                            reload();
                        }
                    }
                }



            }
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            if (gview1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dữ liệu cần xoá!");
            }
            else
            {
                if (MessageBox.Show("Có chắc chắn muốn xoá?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int idnvcantim = DTODB.db.nhanviens.FirstOrDefault(p => p.taikhoan == txttk.Text).idnv;
                    string gender = rdnam.Checked ? "Nam" : "Nữ";
                    if (bus_nhanvien.Xoa(idnvcantim))
                    {
                        MessageBox.Show("Xoá thành công!");
                        reload();
                    }
                }

            }
        }
    }
}

