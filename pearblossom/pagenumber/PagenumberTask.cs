using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace pearblossom.pagenumber
{

    class PagenumberTask : MyAsyncTask
    {
        private readonly string srcFile;
        private readonly IPagenumberStyle style;
        private readonly IPagenumberPos pos;
        private readonly PdfFont font;

        public PagenumberTask(string srcFile, IPagenumberStyle style, IPagenumberPos pos, PdfFont font)
        {
            this.srcFile = srcFile;
            this.style = style;
            this.pos = pos;
            this.font = font;
        }

        protected override string MyTask()
        {
            return AddPageNumber();
        }

        private string GetDstFile()
        {
            string dir = System.IO.Path.GetDirectoryName(srcFile);
            string filename = System.IO.Path.GetFileNameWithoutExtension(srcFile);
            string dstFile = System.IO.Path.Combine(dir, filename + "_" + style.GetName()
                + "_" + pos.GetName() + "_pagenumber.pdf");
            return dstFile;
        }


        private void DrawWhiteBack(PdfCanvas canvas, Rec rec)
        {
            canvas.SetFillColor(ColorConstants.WHITE);
            canvas.Rectangle(rec.x, rec.y, rec.width, rec.height);
            canvas.Fill();
        }

        private void DrawNumber(PdfCanvas canvas, int currentPage, int totalPage, Document doc, PdfFont font, float x, float y)
        {
            canvas.SetFillColor(ColorConstants.BLACK);
            doc.ShowTextAligned(
                new Paragraph(style.GetPagenumberString(currentPage, totalPage))
                .SetFont(font).SetFontSize(18f),
                    x, y, currentPage, TextAlignment.CENTER, VerticalAlignment.MIDDLE, 0);
        }

        public string AddPageNumber()
        {
            string dstFile = GetDstFile();
            PdfDocument pdfDoc = new PdfDocument(new PdfReader(srcFile), new PdfWriter(dstFile));
            Document doc = new Document(pdfDoc);
            int totalPage = pdfDoc.GetNumberOfPages();

            for (int i = 1; i <= totalPage; i++)
            {
                PdfPage page = doc.GetPdfDocument().GetPage(i);
                Rec rec = pos.GetPos(i, page);
                PdfCanvas canvas = new PdfCanvas(page);
                DrawWhiteBack(canvas, rec);
                DrawNumber(canvas, i, totalPage, doc, font, rec.pointX, rec.pointY);
            }
            doc.Close();
            return dstFile;
        }
    }
}
