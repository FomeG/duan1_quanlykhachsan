using BUS_Quanly.Services.QuanLyDatPhong.ThanhToan_DV;
using DTO_Quanly;
using DTO_Quanly.Transfer;
using iText.IO.Font;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GUI_Quanlykhachsan.ChucNang.dangphattrien
{
    public partial class HDTemp : Form
    {
        private int IdCin;
        private int idp;


        private int Idhd;
        private string Tenkh;

        private DateTime Nvao;
        private DateTime Nra;
        private decimal? Tientra;

        TTDichVu _dv = new TTDichVu();

        public HDTemp(int idcheckin, int idphong, int idhoadon, string tenkh, DateTime ngayvao, DateTime ngayra, decimal? tientra)
        {
            InitializeComponent();
            Idhd = idhoadon;
            Tenkh = tenkh;
            Nvao = ngayvao;
            Nra = ngayra;
            Tientra = tientra;
            IdCin = idcheckin;
            idp = idphong;


            MaHD.Text = idhoadon.ToString();
            ngaytaoHD.Text = DateTime.Now.ToString();
        }
        public void loadtt()
        {
            var ttp = (from p in DTODB.db.phongs
                       join lp in DTODB.db.loaiphongs on p.loaiphong equals lp.idloaiphong
                       join kv in DTODB.db.khuvucs on p.khuvuc equals kv.id
                       where p.idphong == idp
                       select new
                       {
                           p,
                           lp,
                           kv
                       }).FirstOrDefault();



            txttenkh.Text = Tenkh;
            txtngayvao.Text = Nvao.ToString();
            txtngayradk.Text = Nra.ToString();
            txtngayrathucte.Text = DateTime.Now.Date.ToString();
            txttienphong.Text = ttp.lp.giaphong.ToString();
            txttientratruoc.Text = Tientra.ToString();

            tenphong.Text = ttp.p.tenphong.ToString();
            loaiphong.Text = ttp.lp.mota.ToString();
            giaphong.Text = ttp.lp.giaphong.ToString();
            khuvuc.Text = ttp.kv.tenkhuvuc.ToString();


            gview1.Columns.Clear();
            var list = _dv.GetCheckinDichVuList(IdCin);
            gview1.DataSource = list;


            tennv.Text = DTODB.db.nhanviens.Find(TDatPhong.IDNV).ten;
        }

        private void guna2GradientButton1_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            GenerateInvoicePDF();
        }

        private void HDTemp_Load(object sender, EventArgs e)
        {
            loadtt();
        }

        private void gview1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MaHD_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }



        private void GenerateInvoicePDF()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                FilterIndex = 2,
                RestoreDirectory = true,
                FileName = $"HoaDon_{Idhd}.pdf"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                PdfWriter writer = new PdfWriter(filePath);
                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf);

                string fontPath = @"C:\Windows\Fonts\arial.ttf";
                PdfFont font = PdfFontFactory.CreateFont(fontPath, PdfEncodings.IDENTITY_H, PdfFontFactory.EmbeddingStrategy.FORCE_EMBEDDED);
                PdfFont boldFont = PdfFontFactory.CreateFont(fontPath, PdfEncodings.IDENTITY_H, PdfFontFactory.EmbeddingStrategy.FORCE_EMBEDDED);

                // Tiêu đề
                document.Add(new Paragraph("HÓA ĐƠN")
                    .SetFont(boldFont)
                    .SetFontSize(20)
                    .SetTextAlignment(TextAlignment.CENTER));

                // Thông tin công ty
                Table infoTable = new Table(2).UseAllAvailableWidth();
                infoTable.AddCell(CreateCell("Khách sạn Mường Thanh Luxury", boldFont, TextAlignment.LEFT));
                infoTable.AddCell(CreateCell($"Số hóa đơn: {Idhd}", font, TextAlignment.RIGHT));
                infoTable.AddCell(CreateCell("Địa chỉ: Thanh Trì, Hà Nội", font, TextAlignment.LEFT));
                infoTable.AddCell(CreateCell($"Ngày: {ngaytaoHD.Text}", font, TextAlignment.RIGHT));
                document.Add(infoTable);

                document.Add(new Paragraph("\n"));

                // Thông tin khách hàng
                document.Add(new Paragraph("Thông tin khách hàng:").SetFont(boldFont));
                Table customerTable = new Table(2).UseAllAvailableWidth();
                customerTable.AddCell(CreateCell("Tên:", boldFont, TextAlignment.LEFT));
                customerTable.AddCell(CreateCell(Tenkh, font, TextAlignment.LEFT));
                customerTable.AddCell(CreateCell("Ngày vào:", boldFont, TextAlignment.LEFT));
                customerTable.AddCell(CreateCell(Nvao.ToString("dd/MM/yyyy"), font, TextAlignment.LEFT));
                customerTable.AddCell(CreateCell("Ngày ra:", boldFont, TextAlignment.LEFT));
                customerTable.AddCell(CreateCell(Nra.ToString("dd/MM/yyyy"), font, TextAlignment.LEFT));
                document.Add(customerTable);

                document.Add(new Paragraph("\n"));

                // Thông tin phòng
                document.Add(new Paragraph("Thông tin phòng:").SetFont(boldFont));
                Table roomTable = new Table(2).UseAllAvailableWidth();
                roomTable.AddCell(CreateCell("Tên phòng:", boldFont, TextAlignment.LEFT));
                roomTable.AddCell(CreateCell(tenphong.Text, font, TextAlignment.LEFT));
                roomTable.AddCell(CreateCell("Loại phòng:", boldFont, TextAlignment.LEFT));
                roomTable.AddCell(CreateCell(loaiphong.Text, font, TextAlignment.LEFT));
                roomTable.AddCell(CreateCell("Giá phòng:", boldFont, TextAlignment.LEFT));
                roomTable.AddCell(CreateCell(giaphong.Text, font, TextAlignment.LEFT));
                roomTable.AddCell(CreateCell("Khu vực:", boldFont, TextAlignment.LEFT));
                roomTable.AddCell(CreateCell(khuvuc.Text, font, TextAlignment.LEFT));
                document.Add(roomTable);

                document.Add(new Paragraph("\n"));

                // Bảng dịch vụ
                document.Add(new Paragraph("Dịch vụ sử dụng:").SetFont(boldFont));
                Table serviceTable = new Table(5).UseAllAvailableWidth();
                string[] headers = { "STT", "Dịch vụ", "Số lượng", "Đơn giá" };
                foreach (string header in headers)
                {
                    serviceTable.AddHeaderCell(CreateCell(header, boldFont, TextAlignment.CENTER)
                        .SetBackgroundColor(ColorConstants.LIGHT_GRAY));
                }

                var list = _dv.GetCheckinDichVuList(IdCin);
                int stt = 1;
                decimal totalServiceCost = 0;
                foreach (var item in list)
                {
                    serviceTable.AddCell(CreateCell(stt.ToString(), font, TextAlignment.CENTER));
                    serviceTable.AddCell(CreateCell(item.TenDV, font, TextAlignment.LEFT));
                    serviceTable.AddCell(CreateCell(item.SoLuong.ToString(), font, TextAlignment.CENTER));
                    serviceTable.AddCell(CreateCell(item.GiaTien.ToString("N0"), font, TextAlignment.RIGHT));
                    totalServiceCost += item.GiaTien;
                    stt++;
                }
                document.Add(serviceTable);
                document.Add(new Paragraph("\n"));

                // Tổng cộng
                Table totalTable = new Table(2).UseAllAvailableWidth();
                decimal roomCost = decimal.Parse(giaphong.Text) * (Nra - Nvao).Days;
                decimal totalCost = roomCost + totalServiceCost;
                totalTable.AddCell(CreateCell("Tiền phòng:", boldFont, TextAlignment.LEFT));
                totalTable.AddCell(CreateCell(roomCost.ToString("N0") + " VNĐ", font, TextAlignment.RIGHT));
                totalTable.AddCell(CreateCell("Ngày ở:", boldFont, TextAlignment.LEFT));
                totalTable.AddCell(CreateCell((Nra - Nvao).Days.ToString("N0") + " VNĐ", font, TextAlignment.RIGHT));
                totalTable.AddCell(CreateCell("Tổng tiền dịch vụ:", boldFont, TextAlignment.LEFT));
                totalTable.AddCell(CreateCell(totalServiceCost.ToString("N0") + " VNĐ", font, TextAlignment.RIGHT));
                totalTable.AddCell(CreateCell("Tổng cộng:", boldFont, TextAlignment.LEFT));
                totalTable.AddCell(CreateCell(totalCost.ToString("N0") + " VNĐ", boldFont, TextAlignment.RIGHT));
                totalTable.AddCell(CreateCell("Tiền trả trước:", boldFont, TextAlignment.LEFT));
                totalTable.AddCell(CreateCell(Tientra?.ToString("N0") + " VNĐ", font, TextAlignment.RIGHT));
                totalTable.AddCell(CreateCell("Còn lại:", boldFont, TextAlignment.LEFT));
                totalTable.AddCell(CreateCell((totalCost - (Tientra ?? 0)).ToString("N0") + " VNĐ", boldFont, TextAlignment.RIGHT));
                document.Add(totalTable);

                // Chữ ký
                Table signatureTable = new Table(2).UseAllAvailableWidth();
                signatureTable.AddCell(CreateCell("Khách hàng", boldFont, TextAlignment.CENTER));
                signatureTable.AddCell(CreateCell("Nhân viên", boldFont, TextAlignment.CENTER));
                signatureTable.AddCell(CreateCell("(Ký, ghi rõ họ tên)", font, TextAlignment.CENTER));
                signatureTable.AddCell(CreateCell("(Ký, ghi rõ họ tên)", font, TextAlignment.CENTER));
                signatureTable.AddCell(CreateCell("", font, TextAlignment.CENTER));
                signatureTable.AddCell(CreateCell(tennv.Text, font, TextAlignment.CENTER));
                document.Add(signatureTable);

                document.Close();

                MessageBox.Show($"Hóa đơn đã được lưu tại:\n{filePath}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private static Cell CreateCell(string text, PdfFont font, TextAlignment alignment)
        {
            return new Cell().Add(new Paragraph(text).SetFont(font)).SetTextAlignment(alignment).SetBorder(Border.NO_BORDER);
        }

    }
}
