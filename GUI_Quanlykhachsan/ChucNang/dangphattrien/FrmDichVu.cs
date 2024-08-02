using BUS_Quanly.Services.QuanLyDatPhong.ThanhToan_DV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_Quanlykhachsan.ChucNang.dangphattrien
{
    public partial class FrmDichVu : Form
    {
        private readonly TTDichVu _dv;
        private readonly int IDCin;
        private readonly int IDKh;

        public FrmDichVu(TTDichVu dv)
        {
            _dv = dv;
        }

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

        }
    }
}
