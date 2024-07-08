using System;
using System.Windows.Forms;

namespace GUI_Quanlykhachsan.ChucNang
{
    public partial class ThanhToan : Form
    {
        public Action traphong;
        public ThanhToan(Action traphong)
        {
            InitializeComponent();
            this.traphong = traphong;
        }

        // Nút thanh toán sau, vê căn bản là thoát form thanh toán và không làm gì CSDL cả.
        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn thực hiện hành động này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /* Nút trả phòng và thanh toán, luồng hoạt động
            1.  Sau khi trả phòng và thanh toán thì khách hàng đang sử dụng phòng trong bảng temp sẽ không còn nữa.
            2.  Insert checkout
            3.  Lập hoá đơn và hoá đơn chi tiết
            4.  Chuyển trạng thái những phòng khách hàng đã thuê về trống

        */

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            traphong?.Invoke();
            Close();
        }
    }
}
