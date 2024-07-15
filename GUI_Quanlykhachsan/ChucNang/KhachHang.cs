using System;
using System.Windows.Forms;

namespace GUI_Quanlykhachsan.ChucNang
{
    public partial class KhachHang : Form
    {
        public Action dattruoc;
        public Action nhanphong;
        public KhachHang(/*Action nhanphong, Action dattruoc*/)
        {
            InitializeComponent();
            this.dattruoc = dattruoc;
            this.nhanphong = nhanphong;
        }

        private void KhachHang_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            dattruoc?.Invoke();
            Close();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            nhanphong?.Invoke();
            Close();
        }
        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog lam = new OpenFileDialog();
            if (lam.ShowDialog() == DialogResult.OK)
            {
                anhkh.Image = System.Drawing.Image.FromFile(lam.FileName);
            }
        }

    }
}
