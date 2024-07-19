using DTO_Quanly;
using DTO_Quanly.Model.DB;
using DTO_Quanly.Transfer;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GUI_Quanlykhachsan.ChucNang
{
    public partial class KhachHang : Form
    {
        public Action dattruoc;
        public Action nhanphong;
        public KhachHang(Action nhanphong, Action dattruoc)
        {
            InitializeComponent();
            this.dattruoc = dattruoc;
            this.nhanphong = nhanphong;

            tiencantra.Text = TDatPhong.TienPhong.ToString();



            this.MouseDown += new MouseEventHandler(Form_MouseDown);
        }

        #region Kéo thả form
        // Dùng WinAPI để di chuyển form
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            // Nếu nhấn nút chuột trái
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion
        #region Kéo thả form (controller)

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private void guna2GroupBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = true;
                dragCursorPoint = Cursor.Position;
                dragFormPoint = this.Location;
            }
        }

        private void guna2GroupBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(diff));
            }
        }

        private void guna2GroupBox1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;

        }
        #endregion

        // Hàm validate form
        public bool checkthanhtoan()
        {
            if (txtTen.Text.Trim() == "" || txtEmail.Text.Trim() == "")
            {
                MessageBox.Show("Không được để trống dữ liệu.", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (IsValidEmail(txtEmail.Text) == false)
            {
                MessageBox.Show("Email không hợp lệ!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (txtSDT.Text != "" && !txtSDT.Text.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại không hợp lệ!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (!rdNam.Checked && !rdNu.Checked)
            {
                MessageBox.Show("Vui lòng chọn giới tính!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (SoLuongNguoi.Value <= 0)
            {
                MessageBox.Show("Số lượng người phải lớn hơn 0!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (NgayDen.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Ngày đến không được nhỏ hơn ngày hiện tại!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (NgayDi.Value.Date <= NgayDen.Value.Date)
            {
                MessageBox.Show("Ngày đi không được nhỏ hơn ngày đến!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        // Hàm kiểm tra email bằng regex
        public static bool IsValidEmail(string email)
        {
            try
            {
                // Biểu thức chính quy để kiểm tra email
                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
                return regex.IsMatch(email);
            }
            catch (Exception)
            {
                return false;
            }
        }




        private void guna2Button2_Click(object sender, EventArgs e)
        {

            if (checkthanhtoan())
            {
                if (MessageBox.Show("Xác nhận đặt trước?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    int soluongnguoitoida = (int)(from a in DTODB.db.phongs
                                                  join b in DTODB.db.loaiphongs on a.loaiphong equals b.idloaiphong
                                                  where a.idphong == TDatPhong.IdPhong
                                                  select b.songuoi).FirstOrDefault();
                    if (SoLuongNguoi.Value > soluongnguoitoida)
                    {
                        MessageBox.Show("Số lượng người vượt quá tối đa!");
                    }
                    else
                    {

                        using (var transaction = DTODB.db.Database.BeginTransaction())
                        {
                            try
                            {
                                // Thêm khách hàng mới vào DB
                                khachhang khmoi = new khachhang()
                                {
                                    ten = txtTen.Text,
                                    email = txtEmail.Text,
                                    sdt = txtSDT.Text,
                                    gioitinh = rdNam.Checked ? "Nam" : "Nữ",
                                    diachi = txtDiaChi.Text,
                                    ngaysinh = NgaySinh.Value.Date,
                                    anh = duongdananh
                                };
                                DTODB.db.khachhangs.Add(khmoi);
                                DTODB.db.SaveChanges();


                                // Thêm checkin mới vào DB
                                checkin checkinmoi = new checkin()
                                {
                                    idkh = DTODB.db.khachhangs.FirstOrDefault(p => p.email == txtEmail.Text).id,
                                    idnv = TDatPhong.IDNV,
                                    ngaycheckin = DateTime.Now.Date,
                                    trangthai = "Đặt trước"
                                };
                                DTODB.db.checkins.Add(checkinmoi);
                                DTODB.db.SaveChanges();

                                // Lấy id của checkin mới thêm vào
                                int idcheckin = checkinmoi.id;

                                // Thêm tempkhachhang mới vào DB
                                decimal.TryParse(txtKhachThanhToan.Text, out decimal tientra);
                                tempkhachhang tempkh = new tempkhachhang()
                                {
                                    idkh = DTODB.db.khachhangs.FirstOrDefault(p => p.email == txtEmail.Text).id,
                                    idcheckin = idcheckin,
                                    tienkhachtra = tientra,
                                    ngayvao = NgayDen.Value.Date,
                                    ngayra = NgayDi.Value.Date,
                                };
                                DTODB.db.tempkhachhangs.Add(tempkh);
                                DTODB.db.SaveChanges();


                                // Thêm checkin_phong mới vào DB
                                checkin_phong cpmoi = new checkin_phong()
                                {
                                    idcheckin = idcheckin,
                                    idphong = TDatPhong.IdPhong
                                };
                                DTODB.db.checkin_phong.Add(cpmoi);
                                DTODB.db.SaveChanges();


                                transaction.Commit(); // Ổn thì commit 
                                dattruoc?.Invoke();
                                MessageBox.Show("Đặt trước phòng thành công!");
                            }
                            catch (Exception a)
                            {
                                transaction.Rollback(); // Ko ổn thì rollback lại tránh việc dữ liệu xảy ra xung đột
                                MessageBox.Show(a.ToString());
                                MessageBox.Show("Đã có lỗi gì đó xảy ra");
                            }
                        }
                        Close();
                    }
                }
            }
        }



        // Nút nhận phòng
        private void guna2Button3_Click(object sender, EventArgs e)
        {

            if (checkthanhtoan())
            {
                if (MessageBox.Show("Xác nhận đặt phòng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    nhanphong?.Invoke();

                    // Thực hiện truy vấn

                    using (var transaction = DTODB.db.Database.BeginTransaction())
                    {
                        try
                        {
                            // Thêm khách hàng mới vào DB
                            khachhang khmoi = new khachhang()
                            {
                                ten = txtTen.Text,
                                email = txtEmail.Text,
                                sdt = txtSDT.Text,
                                gioitinh = rdNam.Checked ? "Nam" : "Nữ",
                                diachi = txtDiaChi.Text,
                                ngaysinh = NgaySinh.Value.Date,
                                anh = duongdananh
                            };
                            DTODB.db.khachhangs.Add(khmoi);
                            DTODB.db.SaveChanges();

                            // Lấy id của khách hàng mới thêm vào
                            int idkhachhang = khmoi.id;

                            // Thêm checkin mới vào DB
                            checkin checkinmoi = new checkin()
                            {
                                idkh = idkhachhang,
                                idnv = TDatPhong.IDNV,
                                ngaycheckin = DateTime.Now.Date,
                                trangthai = "Đặt trước"
                            };
                            DTODB.db.checkins.Add(checkinmoi);
                            DTODB.db.SaveChanges();

                            // Lấy id của checkin mới thêm vào
                            int idcheckin = checkinmoi.id;

                            // Thêm tempkhachhang mới vào DB
                            decimal.TryParse(txtKhachThanhToan.Text, out decimal tientra);
                            tempkhachhang tempkh = new tempkhachhang()
                            {
                                idkh = DTODB.db.khachhangs.FirstOrDefault(p => p.email == txtEmail.Text).id,
                                idcheckin = idcheckin,
                                tienkhachtra = tientra,
                                ngayvao = NgayDen.Value.Date,
                                ngayra = NgayDi.Value.Date,
                            };
                            DTODB.db.tempkhachhangs.Add(tempkh);
                            DTODB.db.SaveChanges();

                            // Thêm checkin_phong mới vào DB
                            checkin_phong cpmoi = new checkin_phong()
                            {
                                idcheckin = idcheckin,
                                idphong = TDatPhong.IdPhong
                            };
                            DTODB.db.checkin_phong.Add(cpmoi);

                            // Lưu tất cả thay đổi vào DB
                            DTODB.db.SaveChanges();



                            transaction.Commit();
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }

                    Close();
                    MessageBox.Show("Đặt phòng thành công!");
                }
            }
        }


        private void label9_Click(object sender, EventArgs e)
        {

        }



        public string duongdananh;
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog lam = new OpenFileDialog();
            if (lam.ShowDialog() == DialogResult.OK)
            {
                anhkh.Image = System.Drawing.Image.FromFile(lam.FileName);
                duongdananh = lam.FileName;
            }
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtKhachThanhToan_TextChanged(object sender, EventArgs e)
        {
            if (txtKhachThanhToan.Text.Trim() == "")
            {

            }
            else
            {
                if (!decimal.TryParse(txtKhachThanhToan.Text.Trim(), out decimal Khachtra))
                {

                    MessageBox.Show("Tiền không được chứa ký tự!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (Khachtra < TDatPhong.TienPhong)
                    {
                        txttientralai.Text = "0";
                    }
                    else
                    {
                        txttientralai.Text = (Khachtra - TDatPhong.TienPhong).ToString();
                    }
                }
            }
        }

        private void BtnDatThem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
