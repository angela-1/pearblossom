using iText.Kernel.Pdf;

namespace pearblossom.pagenumber
{

    struct Rec
    {
        public readonly float x;
        public readonly float y;
        public readonly float width;
        public readonly float height;
        public readonly float pointX;
        public readonly float pointY;

        public Rec(float x, float y, float width, float height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.pointX = x + width / 2;
            this.pointY = y + height / 2;
        }
    }
    interface IPagenumberPos
    {
        public Rec GetPos(int currentPage, PdfPage pdfPage);
        public string GetName();

    }
}
