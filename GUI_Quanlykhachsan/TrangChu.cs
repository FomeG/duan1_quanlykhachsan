using GUI_Quanlykhachsan.ChucNang;
using GUI_Quanlykhachsan.ChucNang.ADMIN;
using GUI_Quanlykhachsan.ChucNang.Tai_Khoan;
using GUI_Quanlykhachsan.ChucNang.Test;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Reflection;
using System.Windows.Forms;

namespace GUI_Quanlykhachsan
{
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
        }

        // Nút thoát
        private void btnEXIT_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TrangChu_Load(object sender, EventArgs e)
        {
            //nếu vai trò = 1 (admin) -> in label admin và ngược lại
            if (DuLieu.vaitro == 1) label1.Text = "Đây là admin";
            else label1.Text = "Đây là nhân viên !    -    Nhân viên sẽ không sử dụng được quản lý nhân viên.";
            container.Controls.Clear();
        }


        private void TrangChu_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
            }
            else
            {
                e.Cancel = true;
            }
        }

        // Nút quản lý Nhân viên, khi ấn vào thì thay container = form quản lý Nhân viên
        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            Qly_NhanVien ls = new Qly_NhanVien();
            ls.FormBorderStyle = FormBorderStyle.None;
            ls.TopLevel = false;
            container.Controls.Clear();
            container.Controls.Add(ls);
            ls.Show();
            ls.Dock = DockStyle.Fill;
        }

        // Nút quản lý đặt phòng, khi ấn vào thì thay container = form quản lý đặt phòng
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            QuanLyDatPhong ls = new QuanLyDatPhong();
            ls.FormBorderStyle = FormBorderStyle.None;
            ls.TopLevel = false;
            container.Controls.Clear();
            container.Controls.Add(ls);
            ls.Show();
            ls.Dock = DockStyle.Fill;
        }


        // Nút đăng xuất
        private void guna2GradientButton9_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Nút thanh toán để test, sau này sẽ thay đổi lại
        private void guna2GradientButton7_Click(object sender, EventArgs e)
        {
            //ThanhToan ls = new ThanhToan();
            //ls.FormBorderStyle = FormBorderStyle.None;
            //ls.TopLevel = false;
            //container.Controls.Clear();
            //container.Controls.Add(ls);
            //ls.Show();
            //ls.Dock = DockStyle.Fill;
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        // Nút mở form thông tin khách hàng
        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            ThongTinKH ls = new ThongTinKH();
            ls.FormBorderStyle = FormBorderStyle.None;
            ls.TopLevel = false;
            container.Controls.Clear();
            container.Controls.Add(ls);
            ls.Show();
            ls.Dock = DockStyle.Fill;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        // Nút mở báo cáo tài chính
        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
            TaiChinh ls = new TaiChinh();
            ls.FormBorderStyle = FormBorderStyle.None;
            ls.TopLevel = false;
            container.Controls.Clear();
            container.Controls.Add(ls);
            ls.Show();
            ls.Dock = DockStyle.Fill;
        }

        // Nút mở cài đặt
        private void guna2GradientButton8_Click(object sender, EventArgs e)
        {
            FrmSettings ls = new FrmSettings();
            ls.FormBorderStyle = FormBorderStyle.None;
            ls.TopLevel = false;
            container.Controls.Clear();
            container.Controls.Add(ls);
            ls.Show();
            ls.Dock = DockStyle.Fill;
        }



        #region khu vực test code
        // Bắt đầu phần testcode
        // Những code dưới đây để test, không có động gì vào sql và tác động lên form
        // Code chạy trong Trangchu();





        public Form_test formtest;
        int dem = 0;
        public void guna2GradientButton11_Click(object sender, EventArgs e)
        {
            if (formtest == null || formtest.IsDisposed)
            {
                formtest = new Form_test(tangdang);
                formtest.Show();
            }
            else if (!formtest.Visible) // formtest.hide() == true -> show lại
            {
                formtest.Show();
            }
        }
        private void okem(object sender, FormClosedEventArgs e)
        {
            // Đặt formtest về null khi Form_test đã đóng
            formtest = null;
        }

        //private bool isButtonEnabled = true;

        public void tangdang()
        {
            labeltest5.Text = dem++.ToString();
        }


        private void btntest3_Click_1(object sender, EventArgs e)
        {
            int soluong = formtest.listBox1.Items.Count;
            formtest.listBox1.Items.Add("Thành viên " + soluong.ToString());
        }

        private void btntest2_Click(object sender, EventArgs e)
        {
            int soluong = formtest.listBox1.Items.Count;
            formtest.listBox1.Items.Add("Thành viên " + soluong.ToString());
        }

        int tonghd = 0;
        private void btntest4_Click(object sender, EventArgs e)
        {
            int currentCount = hdButtons.Count + 1; // Số thứ tự mới

            Button hdmoi = new Button();
            hdmoi.AutoSize = false;
            hdmoi.Cursor = Cursors.Hand;
            hdmoi.Text = $"HDC {currentCount}";
            hdmoi.Name = $"btnHDC{currentCount}"; // Đặt tên cho button để dễ dàng xác định

            hdmoi.MouseDown += (a, b) =>
            {
                // Kiểm tra nếu là chuột phải
                if (b.Button == MouseButtons.Right)
                {
                    if (MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn này hay không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // Lấy số thứ tự của button bằng cách parse tên button
                        int index = int.Parse(((Button)a).Name.Replace("btnHDC", ""));

                        // Xóa button và cập nhật Dictionary
                        HoaDonCho.Controls.Remove(hdButtons[index]);
                        hdButtons.Remove(index);

                        MessageBox.Show("Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            };

            hdmoi.Click += (a, b) =>
            {
                MessageBox.Show($"Đây là nút thứ: {hdmoi.Text}");
            };

            // Thêm button vào Dictionary và FlowLayoutPanel
            hdButtons.Add(currentCount, hdmoi);
            HoaDonCho.Controls.Add(hdmoi);

        }


        private Dictionary<int, Button> hdButtons = new Dictionary<int, Button>();
        private List<Form_test> listform = new List<Form_test>();
        public void hienthiform(int formcanhienthi)
        {
            // Ẩn tất cả các form
            foreach (var form in listform)
            {
                form.Hide();
            }

            // Hiển thị form được chọn
            listform[formcanhienthi].Show();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(listform.Count.ToString());
        }











        // Kết thúc phần test code
        #endregion

        private void guna2GradientButton10_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void container_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}