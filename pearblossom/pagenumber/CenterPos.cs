using iText.Kernel.Geom;
using iText.Kernel.Pdf;

namespace pearblossom.pagenumber
{
    class CenterPos : IPagenumberPos
    {
        public string GetName()
        {
            return "居中";
        }

        public Rec GetPos(int currentPage, PdfPage pdfPage)
        {
            Rectangle pageRec = pdfPage.GetPageSizeWithRotation();
            float pageWidth = pageRec.GetWidth();

            float pointX = pageWidth / 2;
            float pointY = 30.0f;

            float whiteWidth = 80f;
            float whiteHeight = 30f;
            float whiteX = pointX - whiteWidth / 2;
            float whiteY = pointY - whiteHeight / 2;

            Rec rec = new Rec(whiteX, whiteY, whiteWidth, whiteHeight);
            return rec;
        }
    }
}
