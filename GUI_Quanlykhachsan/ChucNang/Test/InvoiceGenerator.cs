using iText.IO.Font;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Windows.Forms;

public class InvoiceGenerator
{
    public void GenerateInvoice(string invoiceId)
    {
        SaveFileDialog saveFileDialog = new SaveFileDialog
        {
            Filter = "PDF files (*.pdf)|*.pdf",
            FilterIndex = 2,
            RestoreDirectory = true,
            FileName = $"HoaDon_{invoiceId}.pdf"
        };

        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            string filePath = saveFileDialog.FileName;

            // Khởi tạo writer với file path đã chọn
            PdfWriter writer = new PdfWriter(filePath);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);

            // Thêm font chữ hỗ trợ tiếng Việt
            string fontPath = @"C:\Windows\Fonts\arial.ttf"; // Đường dẫn đến font Arial
            PdfFont font = PdfFontFactory.CreateFont(fontPath, PdfEncodings.IDENTITY_H, PdfFontFactory.EmbeddingStrategy.FORCE_EMBEDDED);
            PdfFont boldFont = PdfFontFactory.CreateFont(fontPath, PdfEncodings.IDENTITY_H, PdfFontFactory.EmbeddingStrategy.FORCE_EMBEDDED);

            // Tiêu đề
            document.Add(new Paragraph("HÓA ĐƠN")
                .SetFont(boldFont)
                .SetFontSize(20)
                .SetTextAlignment(TextAlignment.CENTER));

            // Thông tin công ty
            Table infoTable = new Table(2).UseAllAvailableWidth();
            infoTable.AddCell(CreateCell("Công ty TNHH ABC", boldFont, TextAlignment.LEFT));
            infoTable.AddCell(CreateCell($"Số hóa đơn: {invoiceId}", font, TextAlignment.RIGHT));
            infoTable.AddCell(CreateCell("123 Đường XYZ, Quận 1, TP.HCM", font, TextAlignment.LEFT));
            infoTable.AddCell(CreateCell("Ngày: " + DateTime.Now.ToString("dd/MM/yyyy"), font, TextAlignment.RIGHT));
            infoTable.AddCell(CreateCell("SĐT: 0123456789", font, TextAlignment.LEFT));
            infoTable.AddCell(CreateCell("", font, TextAlignment.RIGHT));
            document.Add(infoTable);

            document.Add(new Paragraph("\n"));

            // Thông tin khách hàng
            document.Add(new Paragraph("Thông tin khách hàng:").SetFont(boldFont));
            Table customerTable = new Table(2).UseAllAvailableWidth();
            customerTable.AddCell(CreateCell("Tên:", boldFont, TextAlignment.LEFT));
            customerTable.AddCell(CreateCell("Nguyễn Văn A", font, TextAlignment.LEFT));
            customerTable.AddCell(CreateCell("Địa chỉ:", boldFont, TextAlignment.LEFT));
            customerTable.AddCell(CreateCell("456 Đường DEF, Quận 2, TP.HCM", font, TextAlignment.LEFT));
            customerTable.AddCell(CreateCell("SĐT:", boldFont, TextAlignment.LEFT));
            customerTable.AddCell(CreateCell("0987654321", font, TextAlignment.LEFT));
            document.Add(customerTable);

            document.Add(new Paragraph("\n"));

            // Bảng sản phẩm
            Table productTable = new Table(5).UseAllAvailableWidth();
            string[] headers = { "STT", "Sản phẩm", "Số lượng", "Đơn giá", "Thành tiền" };
            foreach (string header in headers)
            {
                productTable.AddHeaderCell(CreateCell(header, boldFont, TextAlignment.CENTER)
                    .SetBackgroundColor(ColorConstants.LIGHT_GRAY));
            }

            AddProductRow(productTable, "1", "Sản phẩm A", "2", "100,000", "200,000", font);
            AddProductRow(productTable, "2", "Sản phẩm B", "1", "150,000", "150,000", font);
            AddProductRow(productTable, "3", "Sản phẩm C", "3", "80,000", "240,000", font);

            document.Add(productTable);

            // Tổng cộng
            Table totalTable = new Table(2).UseAllAvailableWidth();
            totalTable.AddCell(CreateCell("Tổng cộng:", boldFont, TextAlignment.LEFT));
            totalTable.AddCell(CreateCell("590,000 VNĐ", boldFont, TextAlignment.RIGHT));
            document.Add(totalTable);

            // Chữ ký
            Table signatureTable = new Table(2).UseAllAvailableWidth();
            signatureTable.AddCell(CreateCell("Người mua hàng", boldFont, TextAlignment.CENTER));
            signatureTable.AddCell(CreateCell("Người bán hàng", boldFont, TextAlignment.CENTER));
            signatureTable.AddCell(CreateCell("(Ký, ghi rõ họ tên)", font, TextAlignment.CENTER));
            signatureTable.AddCell(CreateCell("(Ký, ghi rõ họ tên)", font, TextAlignment.CENTER));
            document.Add(signatureTable);

            document.Close();

            MessageBox.Show($"Hóa đơn đã được lưu tại:\n{filePath}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private static Cell CreateCell(string text, PdfFont font, TextAlignment alignment)
    {
        return new Cell().Add(new Paragraph(text).SetFont(font)).SetTextAlignment(alignment).SetBorder(Border.NO_BORDER);
    }

    private static void AddProductRow(Table table, string stt, string product, string quantity, string price, string total, PdfFont font)
    {
        table.AddCell(CreateCell(stt, font, TextAlignment.CENTER));
        table.AddCell(CreateCell(product, font, TextAlignment.LEFT));
        table.AddCell(CreateCell(quantity, font, TextAlignment.CENTER));
        table.AddCell(CreateCell(price, font, TextAlignment.RIGHT));
        table.AddCell(CreateCell(total, font, TextAlignment.RIGHT));
    }
}