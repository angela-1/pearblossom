/*
  Copyright 2018 Angela <ruoshui_engr@163.com>

  Licensed under the Apache License, Version 2.0 (the "License");
  you may not use this file except in compliance with the License.
  You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

  Unless required by applicable law or agreed to in writing, software
  distributed under the License is distributed on an "AS IS" BASIS,
  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
  See the License for the specific language governing permissions and
  limitations under the License.
 */

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
    class PageNumber
    {
        private string _src_file;
        private string _dst_file;

        public PageNumber(string src_file)
        {
            _src_file = src_file;
            int ind = _src_file.LastIndexOf('\\');
            string filename = System.IO.Path.GetFileNameWithoutExtension(_src_file);
            _dst_file = _src_file.Substring(0, ind + 1) + filename + "_pagenumber.pdf";
        }

        internal string Add()
        {

            PdfReader reader = new PdfReader(_src_file);
            FileStream dstFile = new FileStream(_dst_file, FileMode.OpenOrCreate);

            PdfStamper stamper = new PdfStamper(reader, dstFile);

            int n = stamper.Reader.NumberOfPages;
            
            //BaseFont bf = BaseFont.CreateFont(@"C:\Windows\Fonts\cour.ttf", BaseFont.IDENTITY_H, false);
            Font courierFont = new Font(Font.FontFamily.COURIER, 20);

            for (int i = 1; i <= n; i++)
            {
                Rectangle rect = stamper.Reader.GetPageSizeWithRotation(i);
                float xp = rect.Width / 2;
                float yp = 30.0f;
                //System.Windows.Forms.MessageBox.Show("x:" + rect.Width.ToString() + " y:" + rect.Height.ToString());

                PdfContentByte canvas = stamper.GetOverContent(i);
                
                ColumnText.ShowTextAligned(canvas,
                Element.ALIGN_CENTER, new Phrase(i.ToString(), courierFont), xp, yp, 0);
                //draw(canvas, 20, 20, 40, 40, 10);
            }

            stamper.Close();

            reader.Close();
            dstFile.Close();

            return _dst_file;

            //    PdfReader reader = new PdfReader(_src_file);

            //    // 创建文件流用来保存填充模板后的文件
            //    FileStream dstFile = new FileStream(_dst_file, FileMode.OpenOrCreate);
            //    PdfWriter writer = new PdfWriter(dstFile);

            //    PdfDocument pdfDoc = new PdfDocument(reader, writer);
            //    Document document = new Document(pdfDoc);

            //    Rectangle pageSize;
            //    PdfCanvas canvas;
            //    int n = pdfDoc.GetNumberOfPages();
            //    for (int i = 1; i <= n; i++)
            //    {
            //        PdfPage page = pdfDoc.GetPage(i);
            //        pageSize = page.GetPageSize();
            //        canvas = new PdfCanvas(page);

            //        canvas.SetStrokeColor(iText.Kernel.Colors.ColorConstants.BLACK)
            //.SetLineWidth(.2f)
            //.MoveTo(pageSize.GetWidth() / 2 - 30, 60)
            //.LineTo(pageSize.GetWidth() / 2 + 30, 60).Stroke();

            //        canvas.BeginText().SetFontAndSize(PdfFontFactory.CreateFont(StandardFonts.COURIER_BOLD), 12)
            //.MoveText(pageSize.GetWidth() / 2 - 20, 40)
            //.ShowText(i.ToString())
            //.ShowText(" of ")
            //.ShowText(n.ToString())
            //.EndText();

            //        // add new content

            //    }

            //    // add content
            //    pdfDoc.Close();


        }

        public void draw(PdfContentByte canvas, float llx, float lly,
            float urx, float ury, float y)
        {
            canvas.SetColorStroke(BaseColor.BLACK);
            canvas.SetLineWidth(2);
            canvas.MoveTo(136, 100);
            canvas.LineTo(180, 30);
            canvas.Stroke();

            //canvas.BeginText();
            //BaseFont bf = null;
            //bf = BaseFont.CreateFont(BaseFont.ZAPFDINGBATS, "", BaseFont.EMBEDDED);
           
            //canvas.SetFontAndSize(bf, 12);

            

            //// LEFT  
            //canvas.ShowTextAligned(Element.ALIGN_CENTER, "A", llx - 10, y, 0);
            //// RIGHT  
            //canvas.ShowTextAligned(Element.ALIGN_CENTER,"B", urx + 10, y + 8, 180);

            //canvas.EndText();
        }
    }
}
