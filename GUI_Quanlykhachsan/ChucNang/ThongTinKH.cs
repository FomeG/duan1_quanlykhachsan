using System;
using System.Windows.Forms;
using BUS_Quanly.Services.KhachHang;
using System.Linq;
using DTO_Quanly;
using System.Data;
using System.Drawing;
using DTO_Quanly.Model.DB;
using System.Web.UI.WebControls;
using Microsoft.Win32;


namespace GUI_Quanlykhachsan.ChucNang
{
    public partial class ThongTinKH : Form
    {
        Skhachhang bus_khachhang = new Skhachhang();
        private string imagePath;

        public ThongTinKH()
        {
            InitializeComponent();
            reload();
        }

        private void ThongTinKH_Load(object sender, EventArgs e)
        {

        }

        public void reload()
        {
            guna2DataGridView1.DataSource = bus_khachhang.hienthi().ToList();
        }
        public bool kiemtra()
        {
            if (txtten.Text == "" || txtsdt.Text == "" || txtdiachi.Text == "" || txtemail.Text == "")
            {
                MessageBox.Show("Không được để trống dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtsdt.Text.Length != 10 || !txtsdt.Text.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại phải có 10 chữ số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!txtemail.Text.Contains('@') || !txtemail.Text.Contains('.'))
            {
                MessageBox.Show("Định dạng email không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            DateTime ngaysinh;
            if (!DateTime.TryParse(date1.Value.ToString("yyyy/MM/dd"), out ngaysinh) || ngaysinh > DateTime.Now)
            {
                MessageBox.Show("Ngày sinh không hợp lệ hoặc lớn hơn ngày hiện tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (kiemtra())
                {
                    DateTime.TryParse(date1.Value.ToString("yyyy/MM/dd"), out DateTime ngaysinh);
                    var kh = new khachhang
                    {
                        ten = txtten.Text,
                        diachi = txtdiachi.Text,
                        sdt = txtsdt.Text,
                        ngaysinh = ngaysinh,
                        gioitinh = rdnam.Checked ? "Nam" : "Nữ",
                        email = txtemail.Text,
                        anh = imagePath
                    };

                    bus_khachhang.ThemKhachHang(kh);
                    reload();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm thất bại, lỗi: " + ex.Message);
            }
        }




        private void btnanh_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                imagePath = openFileDialog1.FileName;
                guna2PictureBox1.Image = System.Drawing.Image.FromFile(imagePath);
            }
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa");
            }
            else if (kiemtra())
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn sửa không?", "xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string tenkh = guna2DataGridView1.Rows[guna2DataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
                    var khcansua = DTODB.db.khachhangs.FirstOrDefault(a => a.ten == tenkh);
                    DateTime.TryParse(date1.Value.ToString("yyyy/MM/dd"), out DateTime ngaysinh);
                    khcansua.ten = txtten.Text;
                    khcansua.diachi = txtdiachi.Text;
                    khcansua.sdt = txtsdt.Text;
                    khcansua.ngaysinh = ngaysinh;
                    khcansua.gioitinh = rdnam.Checked ? "Nam" : "Nữ";
                    khcansua.email = txtemail.Text;
                    khcansua.anh = imagePath;

                    if (bus_khachhang.SuaKhachHang(khcansua))
                    {
                        reload();
                    }
                }
            }
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dòng cần xoá");
            }
            else
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xoá không?", "xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string tenkh = guna2DataGridView1.Rows[guna2DataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
                    var nvcanxoa = DTODB.db.khachhangs.FirstOrDefault(a => a.ten == tenkh);
                    bus_khachhang.Xoa(nvcanxoa);
                    reload();
                }
            }
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            txtten.Text = "";
            txtdiachi.Text = "";
            txtsdt.Text = "";
            txtemail.Text = "";
            date1.Value = DateTime.Now;
            rdnam.Checked = true;
            rdnu.Checked = false;
            guna2PictureBox1.Image = null;
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var dongdl = guna2DataGridView1.Rows[e.RowIndex];

                txtten.Text = dongdl.Cells["ten"].Value.ToString();
                txtemail.Text = dongdl.Cells["email"].Value.ToString();
                txtsdt.Text = dongdl.Cells["sdt"].Value.ToString();
                txtdiachi.Text = dongdl.Cells["diachi"].Value.ToString();

                DateTime.TryParse(dongdl.Cells["ngaysinh"].Value.ToString(), out DateTime ngaysinh);
                date1.Value = ngaysinh;

                string gioitinh = dongdl.Cells["gioitinh"].Value.ToString();
                rdnam.Checked = gioitinh == "Nam";
                rdnu.Checked = gioitinh == "Nữ";


                string imagePath = dongdl.Cells["anh"].Value.ToString();

                if (!string.IsNullOrEmpty(imagePath))
                {
                    try
                    {
                        if (System.IO.File.Exists(imagePath))
                        {
                            guna2PictureBox1.Image = System.Drawing.Image.FromFile(imagePath);
                        }
                        else
                        {
                            guna2PictureBox1.Image = null;
                            MessageBox.Show("Không tìm thấy ảnh tại đường dẫn: " + imagePath);
                        }
                    }
                    catch (Exception ex)
                    {
                        guna2PictureBox1.Image = null;
                        MessageBox.Show("Lỗi khi tải ảnh: " + ex.Message);
                    }
                }
                else
                {
                    guna2PictureBox1.Image = null;
                }
            }
        }

    }
}
