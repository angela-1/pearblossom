using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pearblossom
{
    class EvenPage
    {
        public static String AddEvenPage(String src_file)
        {
            int ind = src_file.LastIndexOf('\\');
            String filename = System.IO.Path.GetFileNameWithoutExtension(src_file);
            String dst_file = src_file.Substring(0, ind + 1) + filename + "_even.pdf";

            PdfReader reader = new PdfReader(src_file);
            FileStream dstFile = new FileStream(dst_file, FileMode.OpenOrCreate);
            PdfStamper stamper = new PdfStamper(reader, dstFile);

            int pages = reader.NumberOfPages;
            if (pages % 2 == 1)
            {
                stamper.InsertPage(reader.NumberOfPages + 1, reader.GetPageSizeWithRotation(1));
            }
            stamper.Close();
            reader.Close();
            dstFile.Close();
            return dst_file;
        }
    }
}
