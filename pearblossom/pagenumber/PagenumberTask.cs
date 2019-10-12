using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pearblossom.pagenumber
{
    struct Rec
    {
        public readonly float x;
        public readonly float y;
        public readonly float width;
        public readonly float height;

        public Rec(float x, float y, float width, float height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }
    }
    class PagenumberTask : MyAsyncTask
    {
        private readonly string srcFile;
        private readonly PageNumberStyle style;
        private readonly PageNumberPos pos;

        public PagenumberTask(string srcFile, PageNumberStyle style, PageNumberPos pos)
        {
            this.srcFile = srcFile;
            this.style = style;
            this.pos = pos;
        }

        protected override string MyTask()
        {
            return AddPageNumber();
        }

        private string GetDstFile()
        {
            string dir = System.IO.Path.GetDirectoryName(srcFile);
            string filename = System.IO.Path.GetFileNameWithoutExtension(srcFile);
            string dstFile = System.IO.Path.Combine(dir, filename + "_" + style.ToString()
                + "_" + pos.ToString() + "_pagenumber.pdf");
            return dstFile;
        }

        private string GetNumberString(int page, int totalPage)
        {
            string numberString = string.Empty;
            switch (style)
            {
                case PageNumberStyle.Normal:
                    numberString = page.ToString();
                    break;
                case PageNumberStyle.Collection:
                    int len = Math.Max(totalPage.ToString().Length, 2);
                    numberString = string.Format("{0:D" + len + "}", page);
                    break;
                case PageNumberStyle.Total:
                    numberString = page + "/" + totalPage;
                    break;
                default:
                    break;
            }
            return numberString;
        }

        private Rec GetPos(int currentPage, PageNumberPos pos, PdfPage pdfPage)
        {
            Rectangle pageRec = pdfPage.GetPageSizeWithRotation();
            float pageWidth = pageRec.GetWidth();

            float pointX;
            float pointY = 30.0f;

            switch (pos)
            {
                case PageNumberPos.Center:
                    pointX = pageWidth / 2;
                    break;
                case PageNumberPos.Corner:
                    if (currentPage % 2 == 0)
                    {
                        pointX = pageWidth * 0.1f;
                    }
                    else
                    {
                        pointX = pageWidth * 0.9f;
                    }
                    break;
                default:
                    pointX = pageWidth / 2;
                    break;
            }

            float whiteWidth = 80f;
            float whiteHeight = 30f;
            float whiteX = pointX - whiteWidth / 2;
            float whiteY = pointY - whiteHeight / 2;

            Rec rec = new Rec(whiteX, whiteY, whiteWidth, whiteHeight);
            return rec;
        }

        private PdfFont GetFont(PageNumberStyle style)
        {
            PdfFont numberFont;
            switch (style)
            {
                case PageNumberStyle.Normal:
                    numberFont = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);
                    break;
                case PageNumberStyle.Collection:
                case PageNumberStyle.Total:
                    numberFont = PdfFontFactory.CreateFont(StandardFonts.COURIER);
                    break;
                default:
                    numberFont = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);
                    break;
            }
            return numberFont;
        }

        private void DrawWhiteBack(PdfCanvas canvas, float whiteX, float whiteY, float whiteWidth, float whiteHeight)
        {
            canvas.SetFillColor(ColorConstants.WHITE);
            canvas.Rectangle(whiteX, whiteY, whiteWidth, whiteHeight);
            canvas.Fill();
        }

        private void DrawNumber(PdfCanvas canvas,)
        {
            canvas.SetFillColor(ColorConstants.BLACK);

            doc.ShowTextAligned(new Paragraph(GetPageNumber(i, totalPage)).SetFont(font).SetFontSize(18f),
                    pointX, pointY, i, TextAlignment.CENTER, VerticalAlignment.MIDDLE, 0);
        }

        public string AddPageNumber()
        {
            PdfDocument pdfDoc = new PdfDocument(new PdfReader(srcFile), new PdfWriter(GetDstFile()));
            Document doc = new Document(pdfDoc);
            int totalPage = pdfDoc.GetNumberOfPages();

            for (int i = 1; i <= totalPage; i++)
            {
                PdfPage page = doc.GetPdfDocument().GetPage(i);
                Rec rec = GetPos(i, pos, page);
                PdfCanvas canvas = new PdfCanvas(page);
                DrawWhiteBack(canvas, rec.x, rec.y, rec.width, rec.height);


            }
            return "";
        }




    }
}
