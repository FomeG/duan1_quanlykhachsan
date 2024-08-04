using DTO_Quanly;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GUI_Quanlykhachsan.ChucNang.Test
{
    public partial class Form_test : Form
    {

        public Form_test()
        {
            InitializeComponent();
        }

        public void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void listBox1_DataSourceChanged(object sender, EventArgs e)
        {
            label1.Text = "ok";
        }

        private void Form_test_Load(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = "ok";
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void guna2GradientButton1_Click_1(object sender, EventArgs e)
        {
        }

        int sl = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("OK " + sl++.ToString());
        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            InvoiceGenerator generator = new InvoiceGenerator();
            generator.GenerateInvoice("hoadon");
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            var hoadontemp = (from p in DTODB.db.phongs.ToList()
                              join cp in DTODB.db.checkin_phong on p.idphong equals cp.idphong
                              join c in DTODB.db.checkins on cp.idcheckin equals c.id
                              join tk in DTODB.db.tempkhachhangs on c.id equals tk.idcheckin
                              join kh in DTODB.db.khachhangs on tk.idkh equals kh.id
                              join lp in DTODB.db.loaiphongs on p.loaiphong equals lp.idloaiphong
                              join kv in DTODB.db.khuvucs on p.khuvuc equals kv.id
                              where p.idphong == 8 && c.id == 1
                              select new
                              {
                                  kh.ten,
                                  kh.diachi,
                                  tk.ngayvao,
                                  tk.ngayra,
                                  lp.giaphong,
                                  tk.tienkhachtra,

                                  p.tenphong,
                                  lp.loaiphong1,
                                  lp.mota,
                                  kv.tenkhuvuc,

                              }).FirstOrDefault();

            MessageBox.Show(hoadontemp != null ? "Có dữ liệu" : "Không có dữ liệu");
            MessageBox.Show(hoadontemp.ToString());
        }
    }
}
