using DTO_Quanly;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_Quanlykhachsan.ChucNang.dangphattrien
{
    public partial class frmHuyPhong : Form
    {
        private DateTime ngayden;
        private DateTime ngaydi;
        private int idphong;
        public frmHuyPhong(DateTime ngayden, DateTime ngaydi, int idphong)
        {
            InitializeComponent();
            this.ngayden = ngayden;
            this.ngaydi = ngaydi;
            this.idphong = idphong;
            load();
        }


        public void load()
        {
            gview1.DataSource = DTODB.db.kiemtra_dsdattruoc_chitiet(ngayden.ToString("yyyy-MM-dd HH:mm:ss"), ngaydi.ToString("yyyy-MM-dd HH:mm:ss"), idphong).ToList();
        }
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (gview1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dòng cần huỷ?", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn huỷ phòng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    DTODB.db.dsdattruocs.Remove(DTODB.db.dsdattruocs.FirstOrDefault(ds => ds.ngayden == GngayDen && ds.ngaydi == GngayDi));
                    DTODB.db.SaveChanges();

                    MessageBox.Show("Huỷ phòng thành công!");
                    load();
                }
            }
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private DateTime GngayDen;
        private DateTime GngayDi;

        private void gview1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dong = gview1.Rows[e.RowIndex];


            GngayDen = (DateTime)dong.Cells["ngayden"].Value;
            GngayDi = (DateTime)dong.Cells["ngaydi"].Value;
        }
    }
}
