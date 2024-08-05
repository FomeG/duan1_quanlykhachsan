using DTO_Quanly;
using DTO_Quanly.Model.DB;
using DTO_Quanly.Transfer;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GUI_Quanlykhachsan.ChucNang
{
    public partial class Voucher : Form
    {
        public Voucher()
        {
            InitializeComponent();
            loadtt();
            nhethan.Value = DateTime.Now;
        }


        public void loadtt()
        {
            gview1.ClearSelection();
            var listvoucher = from a in DTODB.db.vouchers.ToList()
                              join nv in DTODB.db.nhanviens on a.idnv equals nv.idnv
                              select new
                              {
                                  a.MaVoucher,
                                  Nguoitao = nv.ten,
                                  a.soluong,
                                  a.ngaylap,
                                  a.ngayhethan,
                                  a.giamgia,
                                  Trangthai = a.trangthai == false ? "Còn" : "Hết hạn"
                              };
            gview1.DataSource = listvoucher.ToList();
        }

        public void reload()
        {
            maV.Enabled = true;
            btnSua.Enabled = btnXoa.Enabled = false;
            maV.Text = "";
            giamg.Value = slg.Value = 0;
            nhethan.Value = DateTime.Now;
            loadtt();
        }



        // Nút tải lại
        private void guna2GradientButton4_Click(object sender, System.EventArgs e)
        {
            reload();
        }


        public bool check()
        {
            if (maV.Text == "")
            {
                MessageBox.Show("Không được dể trống dữ liệu");
                return false;
            }


            if (giamg.Value <= 0 || slg.Value <= 0)
            {
                MessageBox.Show("Vui lòng nhập giảm giá và số lượng");
                return false;
            }

            if (nhethan.Value.Date < DateTime.Now)
            {
                MessageBox.Show("Ngày hết hạn không được nhỏ hơn ngày hiện tại");
                return false;
            }
            return true;
        }

        // Nút thêm mới
        private void guna2GradientButton1_Click(object sender, System.EventArgs e)
        {
            if (check())
            {
                if (MessageBox.Show("Bạn chắc chắn có muốn thêm không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    voucher vouchermoi = new voucher()
                    {
                        MaVoucher = maV.Text,
                        idnv = TDatPhong.IDNV,
                        soluong = (int)slg.Value,
                        ngaylap = DateTime.Now,
                        ngayhethan = nhethan.Value.Date,
                        giamgia = (int)giamg.Value,
                        trangthai = false
                    };

                    DTODB.db.vouchers.Add(vouchermoi);
                    DTODB.db.SaveChanges();

                    reload();
                    MessageBox.Show("Thêm thành công!");
                }
            }
        }

        private string maVoucherDYNAMIC;
        // Nút xoá
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (gview1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Vui lòng chọn voucher cần xoá!");
                return;
            }
            if (MessageBox.Show("Bạn chắc chắn có muốn xoá không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DTODB.db.vouchers.Remove(DTODB.db.vouchers.Find(maVoucherDYNAMIC));
                DTODB.db.SaveChanges();

                reload();
                MessageBox.Show("Xoá thành công!");
            }
        }

        private void gview1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dong = gview1.Rows[e.RowIndex];

            maV.Text = dong.Cells["Mavoucher"].Value.ToString();
            maVoucherDYNAMIC = dong.Cells["Mavoucher"].Value.ToString();
            giamg.Value = (int)dong.Cells["giamgia"].Value;

            slg.Value = (int)dong.Cells["soluong"].Value;

            nhethan.Value = (DateTime)dong.Cells["ngayhethan"].Value;

            maV.Enabled = false;
            btnSua.Enabled = btnXoa.Enabled = true;
        }


        // Nút Sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (check())
            {
                if (MessageBox.Show("Bạn chắc chắn có muốn sửa không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var vouchercansua = DTODB.db.vouchers.Find(maVoucherDYNAMIC);
                    vouchercansua.idnv = TDatPhong.IDNV;
                    vouchercansua.soluong = (int)slg.Value;
                    vouchercansua.ngaylap = DateTime.Now;
                    vouchercansua.ngayhethan = nhethan.Value.Date;
                    vouchercansua.giamgia = (int)giamg.Value;
                };
                DTODB.db.SaveChanges();

                reload();
                MessageBox.Show("Sửa thành công!");
            }
        }

        private void txttimkiem_TextChanged(object sender, EventArgs e)
        {
            decimal.TryParse(txttimkiem.Text, out decimal giam);

            var listvoucher = from a in DTODB.db.vouchers.ToList()
                              join nv in DTODB.db.nhanviens on a.idnv equals nv.idnv
                              where a.MaVoucher.ToLower().Contains(txttimkiem.Text.ToLower()) || a.giamgia == giam
                              select new
                              {
                                  a.MaVoucher,
                                  Nguoitao = nv.ten,
                                  a.soluong,
                                  a.ngaylap,
                                  a.ngayhethan,
                                  a.giamgia,
                                  Trangthai = a.trangthai == false ? "Còn" : "Hết hạn"
                              };
            if (listvoucher != null)
            {
                gview1.DataSource = listvoucher.ToList();
            }
        }
    }
}

