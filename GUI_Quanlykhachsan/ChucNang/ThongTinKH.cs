using System;
using System.Windows.Forms;
using BUS_Quanly.Services.KhachHang;
using System.Linq;
using DTO_Quanly;
using DTO_Quanly.Model.DB;
using System.IO;
using System.Drawing;


namespace GUI_Quanlykhachsan.ChucNang
{
    public partial class ThongTinKH : Form
    {
        private Skhachhang BUS_khachhang = new Skhachhang();
        private string ImagePath;
        private const string IMAGE_FOLDER = @"\LuuAnh";

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
            guna2DataGridView1.DataSource = BUS_khachhang.hienthi().ToList();
        }
        public bool KiemTra()
        {
            if (string.IsNullOrEmpty(txtten.Text) || string.IsNullOrEmpty(txtsdt.Text) ||
                string.IsNullOrEmpty(txtdiachi.Text) || string.IsNullOrEmpty(txtemail.Text))
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
            DateTime ngaySinh;
            if (!DateTime.TryParse(date1.Value.ToString("yyyy/MM/dd"), out ngaySinh) || ngaySinh > DateTime.Now)
            {
                MessageBox.Show("Ngày sinh không hợp lệ hoặc lớn hơn ngày hiện tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnanh_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ImagePath = openFileDialog1.FileName;
                guna2PictureBox1.Image = System.Drawing.Image.FromFile(ImagePath);
            }
        }

        private string GetProjectRootPath()
        {
            string currentPath = Application.StartupPath;
            while (!Directory.Exists(Path.Combine(currentPath, "GUI_Quanlykhachsan")))
            {
                currentPath = Directory.GetParent(currentPath).FullName;
                if (string.IsNullOrEmpty(currentPath)) // Đề phòng trường hợp không tìm thấy
                {
                    return Application.StartupPath;
                }
            }
            return currentPath;
        }

        private string SaveImage(string sourcePath)
        {
            try
            {
                string fileName = Path.GetFileName(sourcePath);
                string projectRoot = GetProjectRootPath();
                string destinationFolder = Path.Combine(projectRoot, "GUI_Quanlykhachsan", IMAGE_FOLDER.TrimStart('\\'));

                if (!Directory.Exists(destinationFolder))
                {
                    Directory.CreateDirectory(destinationFolder);
                }

                string destinationPath = Path.Combine(destinationFolder, fileName);
                File.Copy(sourcePath, destinationPath, true);

                return Path.Combine(IMAGE_FOLDER, fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Thêm
        private void guna2GradientButton1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (KiemTra())
                {
                    string savedImagePath = null;
                    if (!string.IsNullOrEmpty(ImagePath))
                    {
                        savedImagePath = SaveImage(ImagePath);
                        if (savedImagePath == null)
                        {
                            MessageBox.Show("Không thể lưu ảnh. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Chưa chọn ảnh. Vui lòng chọn ảnh trước khi thêm khách hàng.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    DateTime.TryParse(date1.Value.ToString("yyyy/MM/dd"), out DateTime ngaySinh);
                    var kh = new khachhang()
                    {
                        ten = txtten.Text,
                        diachi = txtdiachi.Text,
                        sdt = txtsdt.Text,
                        ngaysinh = ngaySinh,
                        gioitinh = rdnam.Checked ? "Nam" : "Nữ",
                        email = txtemail.Text,
                        anh = savedImagePath
                    };

                    if (BUS_khachhang.ThemKhachHang(kh))
                    {
                        reload();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm thất bại, lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sửa
        private void guna2GradientButton2_Click_1(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa");
            }
            else if (KiemTra())
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn sửa không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string tenKH = guna2DataGridView1.SelectedRows[0].Cells["ten"].Value.ToString();
                    var khCanSua = DTODB.db.khachhangs.FirstOrDefault(a => a.ten == tenKH);
                    if (khCanSua != null)
                    {
                        DateTime.TryParse(date1.Value.ToString("yyyy/MM/dd"), out DateTime ngaySinh);
                        khCanSua.ten = txtten.Text;
                        khCanSua.diachi = txtdiachi.Text;
                        khCanSua.sdt = txtsdt.Text;
                        khCanSua.ngaysinh = ngaySinh;
                        khCanSua.gioitinh = rdnam.Checked ? "Nam" : "Nữ";
                        khCanSua.email = txtemail.Text;

                        if (!string.IsNullOrEmpty(ImagePath))
                        {
                            khCanSua.anh = SaveImage(ImagePath);
                        }

                        if (BUS_khachhang.SuaKhachHang(khCanSua))
                        {
                            reload();
                        }
                    }
                }
            }
        }


        // Xoá
        private void guna2GradientButton3_Click_1(object sender, EventArgs e)
        {

        }

        // Tải lại
        private void guna2GradientButton4_Click_1(object sender, EventArgs e)
        {
            txtten.Text = "";
            txtdiachi.Text = "";
            txtsdt.Text = "";
            txtemail.Text = "";
            date1.Value = DateTime.Now;
            rdnam.Checked = true;
            rdnu.Checked = false;
            guna2PictureBox1.Image = null;
            ImagePath = null;
        }

        private void guna2DataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var dongDL = guna2DataGridView1.Rows[e.RowIndex];

                txtten.Text = dongDL.Cells["ten"].Value.ToString();
                txtemail.Text = dongDL.Cells["email"].Value.ToString();
                txtsdt.Text = dongDL.Cells["sdt"].Value.ToString();
                txtdiachi.Text = dongDL.Cells["diachi"].Value.ToString();

                DateTime.TryParse(dongDL.Cells["ngaysinh"].Value.ToString(), out DateTime ngaySinh);
                date1.Value = ngaySinh;

                string gioiTinh = dongDL.Cells["gioitinh"].Value.ToString();
                rdnam.Checked = gioiTinh == "Nam";
                rdnu.Checked = gioiTinh == "Nữ";

                string imagePath = dongDL.Cells["anh"].Value.ToString();

                if (!string.IsNullOrEmpty(imagePath))
                {
                    try
                    {
                        string projectRoot = GetProjectRootPath();
                        string fullImagePath = Path.Combine(projectRoot, "GUI_Quanlykhachsan", imagePath.TrimStart('\\'));

                        if (File.Exists(fullImagePath))
                        {
                            guna2PictureBox1.Image = Image.FromFile(fullImagePath);
                            ImagePath = fullImagePath;
                        }
                        else
                        {
                            guna2PictureBox1.Image = null;
                            MessageBox.Show("Không tìm thấy ảnh tại đường dẫn: " + fullImagePath);
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
                    ImagePath = null;
                }
            }
        }


    }
}
