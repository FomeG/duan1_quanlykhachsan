using System;
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
            this.Hide();
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
            generator.GenerateInvoice();
        }
    }
}
