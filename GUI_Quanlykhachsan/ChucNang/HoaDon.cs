using DTO_Quanly;
using GUI_Quanlykhachsan.ChucNang.dangphattrien;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GUI_Quanlykhachsan.ChucNang
{
    public partial class HoaDon : Form
    {
        public HoaDon()
        {
            InitializeComponent();
            loaddl();

            int totalColumns = gview1.Columns.Count;
            if (gview1.DataSource != null)
            {
                gview1.Columns[totalColumns - 1].Visible = false;
                gview1.Columns[totalColumns - 2].Visible = false;
                gview1.Columns[totalColumns - 3].Visible = false;
            }
        }

        private void HoaDon_Load(object sender, System.EventArgs e)
        {

        }

        public void loaddl()
        {
            var listhd = DTODB.db.viewhoadons.ToList();
            gview1.DataSource = listhd;

        }
        public bool checkkiemtra()
        {
            if (NgayDi.Value.Date <= NgayDen.Value.Date)
            {
                MessageBox.Show("Ngày đi không được nhỏ hơn ngày đến!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        // Nút kiểm tra
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {

            if (checkkiemtra())
            {
                if (txttenkh.Text == "" && txtsophong.Text != "")
                {
                    var listhd = DTODB.db.viewhoadons.Where(x => x.ngaytao > NgayDen.Value && x.ngaytao < NgayDi.Value && x.tenphong.ToLower().Contains(txtsophong.Text.ToLower())).ToList();
                    gview1.DataSource = listhd;

                }
                else if (txttenkh.Text != "" && txtsophong.Text == "")
                {
                    var listhd = DTODB.db.viewhoadons.Where(x => x.ngaytao > NgayDen.Value && x.ngaytao < NgayDi.Value && x.ten.ToLower().Contains(txttenkh.Text.ToLower())).ToList();
                    gview1.DataSource = listhd;
                }
                else if (txttenkh.Text != "" && txtsophong.Text != "")
                {
                    var listhd = DTODB.db.viewhoadons.Where(x => x.ngaytao > NgayDen.Value && x.ngaytao < NgayDi.Value && x.ten.ToLower().Contains(txttenkh.Text.ToLower()) && x.tenphong.ToLower().Contains(txtsophong.Text.ToLower())).ToList();
                    gview1.DataSource = listhd;
                }
                else
                {
                    var listhd = DTODB.db.viewhoadons.Where(x => x.ngaytao > NgayDen.Value && x.ngaytao < NgayDi.Value).ToList();
                    gview1.DataSource = listhd;
                }
            }
        }


        private int idcheckin;
        private int idphong;
        private int idhoadon;
        private string tenkh;
        private DateTime ngayvao;
        private DateTime ngayra;
        private decimal? tientra;
        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            if (gview1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Vui lòng chọn hoá đơn");
            }
            else
            {
                HDTemp hdchitiet = new HDTemp(idcheckin, idphong, idhoadon, tenkh, ngayvao, ngayra, tientra);
                hdchitiet.Show();
            }

        }

        private void NgayDen_ValueChanged(object sender, EventArgs e)
        {

        }

        private void NgayDi_ValueChanged(object sender, EventArgs e)
        {

        }


        // Nút tải lại
        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            txttenkh.Text = txtsophong.Text = "";
            loaddl();
            cbsapxep.SelectedIndex = -1;
        }




        private void gview1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dong = gview1.Rows[e.RowIndex];
            if (dong != null)
            {
                idcheckin = (int)dong.Cells["idcheckin"].Value;
                idphong = (int)dong.Cells["idphong"].Value;
                idhoadon = (int)dong.Cells["idhoadon"].Value;
                tenkh = dong.Cells["ten"].Value.ToString();
                ngayvao = (DateTime)dong.Cells["ngaycheckin"].Value;
                ngayra = (DateTime)dong.Cells["ngaycheckout"].Value;
                tientra = (decimal)dong.Cells["tienkhachtra"].Value;
            }
        }

        private void cbsapxep_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbsapxep.SelectedItem == "Ngày tạo")
            {
                if (txttenkh.Text != "" || txtsophong.Text != null)
                {
                    if (checkkiemtra())
                    {
                        if (txttenkh.Text == "" && txtsophong.Text != "")
                        {
                            var listhd = DTODB.db.viewhoadons.Where(x => x.ngaytao > NgayDen.Value && x.ngaytao < NgayDi.Value && x.tenphong.ToLower().Contains(txtsophong.Text.ToLower())).OrderByDescending(x => x.ngaytao).ToList();
                            gview1.DataSource = listhd;

                        }
                        else if (txttenkh.Text != "" && txtsophong.Text == "")
                        {
                            var listhd = DTODB.db.viewhoadons.Where(x => x.ngaytao > NgayDen.Value && x.ngaytao < NgayDi.Value && x.ten.ToLower().Contains(txttenkh.Text.ToLower())).OrderByDescending(x => x.ngaytao).ToList();
                            gview1.DataSource = listhd;
                        }
                        else if (txttenkh.Text != "" && txtsophong.Text != "")
                        {
                            var listhd = DTODB.db.viewhoadons.Where(x => x.ngaytao > NgayDen.Value && x.ngaytao < NgayDi.Value && x.ten.ToLower().Contains(txttenkh.Text.ToLower()) && x.tenphong.ToLower().Contains(txtsophong.Text.ToLower())).OrderByDescending(x => x.ngaytao).ToList();
                            gview1.DataSource = listhd;
                        }
                        else
                        {
                            var listhd = DTODB.db.viewhoadons.Where(x => x.ngaytao > NgayDen.Value && x.ngaytao < NgayDi.Value).OrderByDescending(x => x.ngaytao).ToList();
                            gview1.DataSource = listhd;
                        }
                    }
                }
                else if (txttenkh.Text != "" && txtsophong.Text != "")
                {
                    var listhd = DTODB.db.viewhoadons.Where(x => x.ngaytao > NgayDen.Value && x.ngaytao < NgayDi.Value).OrderByDescending(x => x.ngaytao).ToList();
                    gview1.DataSource = listhd;
                }

            }
        }



    }
}
