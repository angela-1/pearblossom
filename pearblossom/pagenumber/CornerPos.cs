using iText.Kernel.Geom;
using iText.Kernel.Pdf;

namespace pearblossom.pagenumber
{
    class CornerPos : IPagenumberPos
    {
        public string GetName()
        {
            return "角落";
        }

        public Rec GetPos(int currentPage, PdfPage pdfPage)
        {
            Rectangle pageRec = pdfPage.GetPageSizeWithRotation();
            float pageWidth = pageRec.GetWidth();

            float pointX;
            float pointY = 30.0f;

            if (currentPage % 2 == 0)
            {
                pointX = pageWidth * 0.1f;
            }
            else
            {
                pointX = pageWidth * 0.9f;
            }

            float whiteWidth = 80f;
            float whiteHeight = 30f;
            float whiteX = pointX - whiteWidth / 2;
            float whiteY = pointY - whiteHeight / 2;

            Rec rec = new Rec(whiteX, whiteY, whiteWidth, whiteHeight);
            return rec;
        }
    }
}
