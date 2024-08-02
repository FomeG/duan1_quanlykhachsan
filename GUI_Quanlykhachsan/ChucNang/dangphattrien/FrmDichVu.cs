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
            this.IDCin = idcheckin;
            this.IDKh = idkh;

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
                checkin_dichvu dvmoi = new checkin_dichvu()
                {
                    idcheckin = IDCin,
                    iddv = LsDichVu.SelectedIndex + 1,
                    soluong = (int)SlgDV.Value
                };
                DTODB.db.checkin_dichvu.Add(dvmoi);
                DTODB.db.SaveChanges();
                loaddvgview();
                MessageBox.Show("Thêm thành công!");
            }
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            if (gview1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dịch vụ cần xoá!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
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
                int iddichvu = listtinhtien.ToList()[gview1.CurrentCell.RowIndex].iddichvu;
                int slgdichvu = (int)listtinhtien.ToList()[gview1.CurrentCell.RowIndex].soluong;
                DTODB.db.checkin_dichvu.Remove(DTODB.db.checkin_dichvu.FirstOrDefault(p => p.idcheckin == IDCin && p.soluong == slgdichvu && p.iddv == iddichvu));
                DTODB.db.SaveChanges();
                loaddvgview();
            }
        }

        private void SlgDV_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
