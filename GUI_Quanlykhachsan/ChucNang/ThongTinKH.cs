using BUS_Quanly.Services.KhachHang;
using DTO_Quanly;
using DTO_Quanly.Model.DB;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;


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
            if ((DateTime.Now.Year - date1.Value.Year) < 18 ||
     (DateTime.Now.Year - date1.Value.Year == 18 && DateTime.Now < date1.Value.AddYears(18)))
            {
                MessageBox.Show("Khách hàng phải trên 18 tuôi!");
                return false;
            }

            return true;
        }

        private void btnanh_Click(object sender, EventArgs e)
        {

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
                        else
                        {
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
                    BUS_khachhang.Xoa(nvcanxoa);
                    reload();
                }
            }
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
            reload();
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

                if (dongDL.Cells["anh"].Value == null)
                {
                    MessageBox.Show("Không tồn tại ảnh khách hàng!");
                    return;
                }

                string imagePath = dongDL.Cells["anh"].Value.ToString();

                if (!string.IsNullOrEmpty(dongDL.Cells["anh"].Value.ToString()))
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

                kiemtra = false;
            }
        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ImagePath = openFileDialog1.FileName;
                guna2PictureBox1.Image = System.Drawing.Image.FromFile(ImagePath);
            }
        }

        private bool kiemtra = true;
        private bool suaemail = false;

        private void txtemail_TextChanged(object sender, EventArgs e)
        {
            if (kiemtra == false)
            {
                suaemail = true;
            }
        }
    }
}
