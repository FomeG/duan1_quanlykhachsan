using DTO_Quanly;
using DTO_Quanly.Model.DB;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GUI_Quanlykhachsan.ChucNang.dangphattrien
{
    public partial class frmPhong : Form
    {
        public frmPhong()
        {
            InitializeComponent();
            loaddulieu();
        }


        public void loaddulieu()
        {
            gview1.ClearSelection();
            cbloaiphong.Items.Clear();
            cbkhuvuc.Items.Clear();
            foreach (var item in DTODB.db.loaiphongs)
            {
                cbloaiphong.Items.Add(item.loaiphong1);
            }

            foreach (var item in DTODB.db.khuvucs)
            {
                cbkhuvuc.Items.Add(item.tenkhuvuc);
            }

            var dsphong = (from p in DTODB.db.phongs.ToList()
                           join kv in DTODB.db.khuvucs on p.khuvuc equals kv.id
                           join lp in DTODB.db.loaiphongs on p.loaiphong equals lp.idloaiphong
                           where p.tt == false
                           select new
                           {
                               p.tenphong,
                               kv.tenkhuvuc,
                               TenLoaiPhong = lp.loaiphong1,
                               lp.giaphong,
                               p.ghichu,
                               p.idphong
                           }).ToList();

            gview1.DataSource = dsphong;
            gview1.Columns[gview1.Columns.Count - 1].Visible = false;
        }

        public void reload()
        {
            txttenphong.Text = txtghichu.Text = txtgiaphong.Text = txttimkiem.Text = "";
            cbkhuvuc.SelectedIndex = cbloaiphong.SelectedIndex = -1;
            btnXoa.Enabled = btnSua.Enabled = false;

            var dsphong = (from p in DTODB.db.phongs.ToList()
                           join kv in DTODB.db.khuvucs on p.khuvuc equals kv.id
                           join lp in DTODB.db.loaiphongs on p.loaiphong equals lp.idloaiphong
                           where p.tt == false
                           select new
                           {
                               p.tenphong,
                               kv.tenkhuvuc,
                               TenLoaiPhong = lp.loaiphong1,
                               lp.giaphong,
                               p.ghichu,
                               p.idphong
                           }).ToList();

            gview1.DataSource = dsphong;
            gview1.Columns[gview1.Columns.Count - 1].Visible = false;
        }

        // Nút tải lại
        private void guna2GradientButton4_Click(object sender, System.EventArgs e)
        {
            reload();
        }

        private void gview1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dong = gview1.Rows[e.RowIndex];

            txttenphong.Text = dong.Cells[0].Value.ToString();
            tenphongGOC = dong.Cells[0].Value.ToString();
            txtghichu.Text = dong.Cells["ghichu"].Value.ToString();
            txtgiaphong.Text = dong.Cells["giaphong"].Value.ToString();

            cbkhuvuc.SelectedItem = dong.Cells["tenkhuvuc"].Value.ToString();
            cbloaiphong.SelectedItem = dong.Cells["TenLoaiPhong"].Value.ToString();
            idphongDYNAMIC = (int)dong.Cells["idphong"].Value;
            btnXoa.Enabled = btnSua.Enabled = true;
        }

        private void txttimkiem_TextChanged(object sender, System.EventArgs e)
        {
            decimal.TryParse(txttimkiem.Text, out decimal gia);

            var dsphong = (from p in DTODB.db.phongs.ToList()
                           join kv in DTODB.db.khuvucs on p.khuvuc equals kv.id
                           join lp in DTODB.db.loaiphongs on p.loaiphong equals lp.idloaiphong
                           where p.tt == false && (p.tenphong.ToLower().Contains(txttimkiem.Text.ToLower())
                            || lp.giaphong == gia || lp.loaiphong1.ToLower().Contains(txttimkiem.Text.ToLower()))
                           select new
                           {
                               p.tenphong,
                               kv.tenkhuvuc,
                               TenLoaiPhong = lp.loaiphong1,
                               lp.giaphong,
                               p.ghichu,
                               p.idphong
                           }).ToList();
            if (dsphong != null)
            {
                gview1.DataSource = dsphong;
            }

        }

        public bool check()
        {
            if (txttenphong.Text.Trim() == "" || cbkhuvuc.SelectedIndex == -1 || cbloaiphong.SelectedIndex == -1)
            {
                MessageBox.Show("Không để trống dữ liệu!");
                return false;
            }
            return true;
        }
        private void guna2GradientButton1_Click(object sender, System.EventArgs e)
        {
            if (check())
            {
                if (!DTODB.db.phongs.Any(a => a.tenphong == txttenphong.Text))
                {
                    if (MessageBox.Show("Bạn chắc chắn có muốn thêm không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        phong phongmoi = new phong()
                        {
                            tenphong = txttenphong.Text,
                            loaiphong = cbloaiphong.SelectedIndex + 1,
                            khuvuc = cbkhuvuc.SelectedIndex + 1,
                            ghichu = txtghichu.Text,
                            tt = false
                        };

                        DTODB.db.phongs.Add(phongmoi);
                        DTODB.db.SaveChanges();

                        reload();
                        MessageBox.Show("Thành công!");
                    }

                }
                else
                {
                    MessageBox.Show("Tên phòng đã tồn tại rồi!");
                }
            };
        }

        private void cbloaiphong_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (cbloaiphong.SelectedIndex != -1)
            {
                txtgiaphong.Text = DTODB.db.loaiphongs.Find(cbloaiphong.SelectedIndex + 1).giaphong.ToString();
            }
        }


        public bool checkxoa(string TenP)
        {
            var isexists = (from a in DTODB.db.view_trangthai_phong_hientai.ToList()
                            join ds in DTODB.db.dsdattruocs on a.idphong equals ds.idphong
                            where a.tenphong == TenP
                            select a).ToList();
            if (isexists.Count() != 0)
            {
                MessageBox.Show("Phòng này đang được sử dụng!");
                return false;
            }
            return true;
        }


        // Nút xoá
        private void btnXoa_Click(object sender, System.EventArgs e)
        {
            if (gview1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Vui lòng chọn dữ liệu cần xoá!");
            }
            else
            {
                if (checkxoa(txttenphong.Text))
                {
                    if (MessageBox.Show("Bạn chắc chắn có muốn Xoá không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        DTODB.db.phongs.SingleOrDefault(x => x.tenphong == txttenphong.Text).tt = true;
                        DTODB.db.SaveChanges();

                        reload();
                        MessageBox.Show("Thành công!");
                    }
                }
            }
        }

        private int idphongDYNAMIC;
        private string tenphongGOC;

        // Nút sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!check()) return;

            var phongcansua = DTODB.db.phongs.SingleOrDefault(a => a.idphong == idphongDYNAMIC);

            if (phongcansua == null || (phongcansua.tenphong != txttenphong.Text && DTODB.db.phongs.Any(a => a.tenphong == txttenphong.Text)))
            {
                MessageBox.Show(phongcansua == null ? "Phòng không tồn tại." : "Tên phòng này đã tồn tại rồi!");
                return;
            }

            if (MessageBox.Show("Bạn chắc chắn có muốn sửa không?", "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            phongcansua.tenphong = txttenphong.Text;
            phongcansua.loaiphong = cbloaiphong.SelectedIndex + 1;
            phongcansua.khuvuc = cbkhuvuc.SelectedIndex + 1;
            phongcansua.ghichu = txtghichu.Text;
            phongcansua.tt = false;

            DTODB.db.SaveChanges();
            reload();
            MessageBox.Show("Thành công!");
        }







    }
}
