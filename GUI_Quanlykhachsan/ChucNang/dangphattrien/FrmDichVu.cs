using BUS_Quanly.Services.QuanLyDatPhong.ThanhToan_DV;
using DTO_Quanly;
using DTO_Quanly.Model.DB;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GUI_Quanlykhachsan.ChucNang.dangphattrien
{
    public partial class FrmDichVu : Form
    {
        TTDichVu _dv = new TTDichVu();
        private readonly int IDCin;
        private readonly int IDKh;

        public FrmDichVu(int idcheckin, int idkh)
        {
            InitializeComponent();
            IDCin = idcheckin;
            IDKh = idkh;

            loaddv();
            loaddvgview();
        }

        public void loaddv()
        {
            foreach (var item in _dv.hienthidv().ToList())
            {
                LsDichVu.Items.Add(item.tendv);
            }
        }
        public void loaddvgview()
        {
            gview1.Columns.Clear();
            var list = _dv.GetCheckinDichVuList(IDCin);
            gview1.DataSource = list;

            decimal tienDichVu = _dv.TinhTongTienDichVu(list);
            txttiendv.Text = tienDichVu.ToString();
        }

        private void BtnThanhToanSau_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (LsDichVu.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn dịch vụ cần thêm!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (SlgDV.Value <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int checkdvtontai = (from a in DTODB.db.checkin_dichvu
                                     join b in DTODB.db.dichvus on a.iddv equals b.id
                                     where a.idcheckin == IDCin && b.tendv == LsDichVu.SelectedItem.ToString()
                                     select (int)b.id).FirstOrDefault();

                int dichvu = (from a in DTODB.db.dichvus.ToList()
                              where a.tendv == LsDichVu.SelectedItem.ToString() && a.tt == false
                              select a.id).FirstOrDefault();

                if (DTODB.db.dichvus.Find(dichvu).soluongton < SlgDV.Value)
                {
                    MessageBox.Show("Kho không đủ số lượng");
                    return;
                }
                else
                {
                    DTODB.db.dichvus.Find(dichvu).soluongton -= (int)SlgDV.Value;
                    DTODB.db.SaveChanges();
                }

                if (checkdvtontai != 0)
                {
                    checkin_dichvu dvcansua = DTODB.db.checkin_dichvu.FirstOrDefault(x => x.iddv == checkdvtontai && x.idcheckin == IDCin);
                    dvcansua.soluong += (int)SlgDV.Value;

                    DTODB.db.SaveChanges();
                    loaddvgview();
                    MessageBox.Show("Thêm thành công!");
                }
                else
                {
                    checkin_dichvu dvmoi = new checkin_dichvu()
                    {
                        idcheckin = IDCin,
                        iddv = dichvu,
                        soluong = (int)SlgDV.Value
                    };

                    DTODB.db.checkin_dichvu.Add(dvmoi);
                    DTODB.db.SaveChanges();
                    loaddvgview();
                    MessageBox.Show("Thêm thành công!");
                }


            }
        }
        private string dichvucanxoa;
        private int slgdv;
        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            if (gview1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dịch vụ cần xoá!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (dichvucanxoa != "" && slgdv != 0)
                {
                    var listtinhtien = from cd in DTODB.db.checkin_dichvu
                                       join dv in DTODB.db.dichvus on cd.iddv equals dv.id
                                       where cd.idcheckin == IDCin
                                       select new
                                       {
                                           cd.idcheckin,
                                           cd.soluong,
                                           dv.tendv,
                                           iddichvu = dv.id,
                                           GiaTien = dv.gia * cd.soluong
                                       };

                    int dichvu = (from a in DTODB.db.dichvus.ToList()
                                  where a.tendv == dichvucanxoa && a.tt == false
                                  select a.id).FirstOrDefault();

                    DTODB.db.dichvus.Find(dichvu).soluongton += slgdv;
                    DTODB.db.SaveChanges();


                    DTODB.db.checkin_dichvu.Remove(DTODB.db.checkin_dichvu.FirstOrDefault(p => p.idcheckin == IDCin && p.soluong == slgdv && p.iddv == dichvu));

                    DTODB.db.SaveChanges();
                    loaddvgview();
                }

            }
        }

        private void SlgDV_ValueChanged(object sender, EventArgs e)
        {

        }

        private void gview1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dong = gview1.Rows[e.RowIndex];

            dichvucanxoa = dong.Cells["TenDV"].Value.ToString();
            slgdv = (int)dong.Cells["SoLuong"].Value;

        }

        private void btnreload_Click(object sender, EventArgs e)
        {
            loaddvgview();
            LsDichVu.SelectedIndex = -1;
            SlgDV.Value = 0;
        }
    }
}
