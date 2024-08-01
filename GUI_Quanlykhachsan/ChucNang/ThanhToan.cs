using BUS_Quanly.Services.QuanLyDatPhong.ThanhToan_DV;
using DTO_Quanly;
using DTO_Quanly.Model.DB;
using DTO_Quanly.Transfer;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GUI_Quanlykhachsan.ChucNang
{
    public partial class ThanhToan : Form
    {
        private readonly TTDichVu _dv;
        public Action traphong;
        private TTDichVu _truyvan;
        private readonly int IDCin;
        private readonly int IDKh;
        private readonly int idnv;
        private readonly int IDPhong;
        public ThanhToan(Action traphong, int idcheckin, int idkh, int idphong)
        {
            InitializeComponent();
            this.traphong = traphong;
            this.IDCin = idcheckin;
            this.IDKh = idkh;
            this.idnv = TDatPhong.IDNV;
            this.IDPhong = idphong;

            LoadDV();
            loadtt();
            loaddvgview();

            this.MouseDown += new MouseEventHandler(Form_MouseDown);
        }

        public ThanhToan(TTDichVu dv)
        {
            _dv = dv;
        }

        #region Kéo thả form
        // Dùng WinAPI để di chuyển form
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            // Nếu nhấn nút chuột trái
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion


        #region LOAD DỮ LIỆU TRÊN FORM, VÀ DỊCH VỤ

        public void LoadDV()
        {
            foreach (var item in _dv.hienthidv().ToList())
            {
                LsDichVu.Items.Add(item.tendv);
            }
        }

        public void loadtt()
        {
            var hoadontemp = (from p in DTODB.db.phongs
                              join cp in DTODB.db.checkin_phong on p.idphong equals cp.idphong
                              join c in DTODB.db.checkins on cp.idcheckin equals c.id
                              join tk in DTODB.db.tempkhachhangs on c.id equals tk.idcheckin
                              join kh in DTODB.db.khachhangs on tk.idkh equals kh.id
                              join lp in DTODB.db.loaiphongs on p.loaiphong equals lp.idloaiphong
                              where p.idphong == TDatPhong.IdPhong
                              select new
                              {
                                  kh.ten,
                                  kh.diachi,
                                  tk.ngayvao,
                                  tk.ngayra,
                                  lp.giaphong,
                                  tk.tienkhachtra
                              }).FirstOrDefault();

            txttenkh.Text = hoadontemp.ten;
            txtngayvao.Text = hoadontemp.ngayvao.ToString();
            txtngayradk.Text = hoadontemp.ngayra.ToString();
            txtngayrathucte.Text = DateTime.Now.Date.ToString();
            txttienphong.Text = hoadontemp.giaphong.ToString();
            txttientratruoc.Text = hoadontemp.tienkhachtra.ToString();
        }

        public void loaddvgview()
        {
            gview1.Columns.Clear();
            var list = _dv.GetCheckinDichVuList(IDCin);
            gview1.DataSource = list;

            decimal tienDichVu = _dv.TinhTongTienDichVu(list);
            txttiendv.Text = tienDichVu.ToString();

            decimal.TryParse(txttienphong.Text, out decimal tienPhong);
            decimal tongThanhToan = _dv.TinhTongThanhToan(tienDichVu, tienPhong);
            tongTT.Text = tongThanhToan.ToString();
        }

        #endregion


        #region Lấy dữ liệu để lập hoá đơn (code quan trọng)


        #endregion

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ThanhToan_Load(object sender, EventArgs e)
        {

        }

        private void guna2CustomCheckBox1_Click(object sender, EventArgs e)
        {

        }

        private void LsDichVu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (LsDichVu.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn dịch vụ cần thêm!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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



        /* Nút trả phòng và thanh toán, luồng hoạt động:
           1.  Sau khi trả phòng và thanh toán thì khách hàng đang sử dụng phòng trong bảng temp sẽ không còn nữa.
           2.  Insert checkout
           3.  Lập hoá đơn và hoá đơn chi tiết
           4.  Chuyển trạng thái những phòng khách hàng đã thuê về trống
       */
        private void BtnTraPhong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn thực hiện hành động này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var listThongTin = from cd in DTODB.db.checkin_dichvu
                                   join dv in DTODB.db.dichvus on cd.iddv equals dv.id
                                   where cd.idcheckin == IDCin
                                   select new
                                   {
                                       IDdv = cd.id
                                   };
                using (var transaction = DTODB.db.Database.BeginTransaction())
                {
                    try
                    {

                        // Cập nhật thông tin vào trong checkout
                        checkout checkoutmoi = new checkout()
                        {
                            idkh = IDKh,
                            idnv = TDatPhong.IDNV,
                            ngaycheckout = DateTime.Now.Date,
                            trangthai = txtGhiChu.Text
                        };
                        DTODB.db.checkouts.Add(checkoutmoi);
                        DTODB.db.SaveChanges();

                        // Trả phòng xong thì sẽ xoá hết dữ liệu trong bảng temp
                        DTODB.db.tempkhachhangs.Remove(DTODB.db.tempkhachhangs.FirstOrDefault(p => p.idcheckin == IDCin && p.idkh == IDKh));
                        DTODB.db.SaveChanges();


                        // Chốt hoá đơn, dv_trunggian và phong_trunggian (nếu có)
                        decimal.TryParse(tongTT.Text, out decimal tongtien);
                        hoadon hoadonmoi = new hoadon()
                        {
                            idkh = IDKh,
                            idnv = TDatPhong.IDNV,
                            ngaytao = DateTime.Now.Date,
                            tongtien = tongtien,
                            songuoi = 1,
                            trangthai = "Đã thanh toán"

                        };
                        DTODB.db.hoadons.Add(hoadonmoi);
                        DTODB.db.SaveChanges();

                        foreach (var item in listThongTin)
                        {
                            dv_trunggian dvtrunggianmoi = new dv_trunggian()
                            {
                                iddv = item.IDdv,
                                idhd = hoadonmoi.idhoadon
                            };

                            DTODB.db.dv_trunggian.Add(dvtrunggianmoi);
                            DTODB.db.SaveChanges();
                        };

                        //phong_trunggian ptrunggianmoi = new phong_trunggian()
                        //{
                        //    idp = IDPhong,
                        //    idhd = hoadonmoi.idhoadon
                        //};
                        //DTODB.db.phong_trunggian.Add(ptrunggianmoi);
                        //DTODB.db.SaveChanges();


                        // Chuyển trạng thái phòng về trống (dựa vào temp khách hàng đã bị xoá trước đó)
                        traphong.Invoke();
                        MessageBox.Show("Cập nhật thành công!");
                        transaction.Commit();
                    }
                    catch (Exception a)
                    {
                        transaction.Rollback(); // Ko ổn thì rollback lại tránh việc dữ liệu xảy ra xung đột
                        MessageBox.Show("Đã có lỗi xảy ra!");
                        MessageBox.Show(a.ToString());
                    }
                }
                Close();
            }
        }

        // Nút thanh toán sau, vê căn bản là thoát form thanh toán và không làm gì CSDL cả.
        private void BtnThanhToanSau_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn thực hiện hành động này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}