using BUS_Quanly.Services.QuanLyDatPhong.ThanhToan_DV;
using DTO_Quanly;
using DTO_Quanly.Model.DB;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GUI_Quanlykhachsan.ChucNang.dangphattrien
{
    public partial class frmQuanlyDV : Form
    {
        TTDichVu _dv = new TTDichVu();
        public frmQuanlyDV()
        {
            InitializeComponent();
            loadtt();
        }

        private int madvDYNAMIC;
        public void loadtt()
        {
            gview1.DataSource = _dv.hienthidv().ToList();
            gview1.Columns[gview1.Columns.Count - 1].Visible = false;
        }

        public void reload()
        {
            txtgiadv.Text = txttendv.Text = txtmota.Text = txttimkiem.Text = "";
            slgdv.Value = 0;
            btnXoa.Enabled = btnSua.Enabled = false;

            loadtt();
        }

        // Nút reload
        public void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            reload();
        }

        private void gview1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dong = gview1.Rows[e.RowIndex];

            txttendv.Text = dong.Cells[0].Value.ToString();
            txtgiadv.Text = dong.Cells[2].Value.ToString();
            slgdv.Value = (int)dong.Cells[1].Value;
            txtmota.Text = dong.Cells[3].Value.ToString();
            madvDYNAMIC = (int)dong.Cells[4].Value;


            btnXoa.Enabled = btnSua.Enabled = true;
        }


        public bool check()
        {
            if (txttendv.Text == "" || txtgiadv.Text == "")
            {
                MessageBox.Show("Không được để trống !");
                return false;
            }

            if (!decimal.TryParse(txtgiadv.Text, out decimal giadv))
            {
                MessageBox.Show("Giá phải là 1 số!");
                return false;
            }

            if (slgdv.Value <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0!");
                return false;
            }


            return true;
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (check())
            {
                if (MessageBox.Show("Bạn chắc chắn có muốn thêm không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    decimal.TryParse(txtgiadv.Text, out decimal giadv);
                    dichvu dvmoi = new dichvu()
                    {
                        tendv = txttendv.Text,
                        soluongton = (int)slgdv.Value,
                        gia = giadv,
                        mota = txtmota.Text,
                        tt = false
                    };

                    DTODB.db.dichvus.Add(dvmoi);
                    DTODB.db.SaveChanges();

                    reload();
                    MessageBox.Show("Thêm thành công!");
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (gview1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Vui lòng chọn dòng cần xoá!");
                return;
            }

            var dvcanxoa = (from dv in DTODB.db.dichvus.ToList()
                            join cdv in DTODB.db.checkin_dichvu on dv.id equals cdv.iddv
                            join ci in DTODB.db.checkins on cdv.idcheckin equals ci.id
                            join tempkh in DTODB.db.tempkhachhangs on ci.id equals tempkh.idcheckin
                            where dv.id == madvDYNAMIC
                            select dv).ToList();
            if (dvcanxoa.Count() != 0)
            {
                MessageBox.Show("Dịch vụ này đang được sử dụng nên chưa thể xoá");
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xoá?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DTODB.db.dichvus.Find(madvDYNAMIC).tt = true;
                DTODB.db.SaveChanges();

                reload();
                MessageBox.Show("Xoá thành công!");
            }
        }


        // Nút sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (check())
            {
                if (MessageBox.Show("Bạn chắc chắn có muốn sửa không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    decimal.TryParse(txtgiadv.Text, out decimal giadv);


                    var dvcansua = DTODB.db.dichvus.Find(madvDYNAMIC);
                    dvcansua.tendv = txttendv.Text;
                    dvcansua.gia = (decimal)giadv;
                    dvcansua.soluongton = (int)slgdv.Value;
                    dvcansua.mota = txtmota.Text;

                    DTODB.db.SaveChanges();

                    reload();
                    MessageBox.Show("Thành công!");
                }
            }
        }

        private void txttimkiem_TextChanged(object sender, EventArgs e)
        {
            var listtimkiem = _dv.hienthidv().Where(x => x.tendv.ToLower().Contains(txttimkiem.Text.ToLower()) || x.mota.ToLower().Contains(txttimkiem.Text.ToLower())).ToList();
            if (listtimkiem != null)
            {
                gview1.DataSource = listtimkiem;
            }
        }
    }
}
