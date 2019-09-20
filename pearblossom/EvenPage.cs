using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using System.IO;

namespace pearblossom
{
    class EvenPage
    {
        public static string AddEvenPage(string src_file)
        {
            int ind = src_file.LastIndexOf('\\');
            string filename = System.IO.Path.GetFileNameWithoutExtension(src_file);
            string dst_file = src_file.Substring(0, ind + 1) + filename + "_even.pdf";

            PdfDocument pdfDoc = new PdfDocument(new PdfReader(src_file), new PdfWriter(dst_file));
            Document doc = new Document(pdfDoc);

            //PdfReader reader = new PdfReader(src_file);
            //FileStream dstFile = new FileStream(dst_file, FileMode.OpenOrCreate);

            //PdfStamper stamper = new PdfStamper(reader, dstFile);

            int pageNumber = pdfDoc.GetNumberOfPages();
            if (pageNumber % 2 == 1)
            {
                pdfDoc.AddNewPage(pageNumber, PageSize.A4);
            }
            doc.Close();
            return dst_file;
        }
    }
}
