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

using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Events;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace pearblossom
{
    class PageNumber
    {
        private readonly string _src_file;
        private readonly string _dst_file;
        private readonly PageNumberStyle _pageNumberStyle;
        private readonly PageNumberPos _pageNumberPos;

        public PageNumber(string src_file, PageNumberStyle pageNumberStyle)
        {
            _src_file = src_file;
            _pageNumberStyle = pageNumberStyle;
            int ind = _src_file.LastIndexOf('\\');
            string filename = System.IO.Path.GetFileNameWithoutExtension(_src_file);
            _dst_file = _src_file.Substring(0, ind + 1) + filename + "_" + _pageNumberStyle.ToString()
                + "_" + _pageNumberPos.ToString() + "_pagenumber.pdf";
        }

        public PageNumber(string src_file, PageNumberStyle pageNumberStyle, PageNumberPos pageNumberPos)
        {
            _src_file = src_file;
            _pageNumberStyle = pageNumberStyle;
            _pageNumberPos = pageNumberPos;
            int ind = _src_file.LastIndexOf('\\');
            string filename = System.IO.Path.GetFileNameWithoutExtension(_src_file);
            _dst_file = _src_file.Substring(0, ind + 1) + filename + "_" + _pageNumberStyle.ToString()
                + "_" + _pageNumberPos.ToString() + "_pagenumber.pdf";
        }

        private string GetPageNumber(int page, int totalPage)
        {
            string StringPage = string.Empty;
            switch (_pageNumberStyle)
            {
                case PageNumberStyle.Normal:
                    StringPage = page.ToString();
                    break;
                case PageNumberStyle.Collection:
                    int len = Larger(totalPage.ToString().Length, 2);
                    StringPage = string.Format("{0:D" + len + "}", page);
                    break;
                case PageNumberStyle.Total:
                    StringPage = page + "/" + totalPage;
                    break;
                default:
                    break;
            }
            return StringPage;
        }

        private static int Larger(int number1, int number2)
        {
            return number1 > number2 ? number1 : number2;
        }


        public void AddFormatedNumber(int totalPage, Document doc, PdfFont font, PageNumberPos pos = PageNumberPos.Corner)
        {
            for (int i = 1; i <= totalPage; i++)
            {
                //PageSize pageSize = doc.GetPdfDocument().GetDefaultPageSize();
                PdfPage page = doc.GetPdfDocument().GetPage(i);
                int a = page.GetRotation();
                //page.SetRotation(0);
                //Rectangle bb = page.GetPageSize();
                Rectangle pageRec = page.GetPageSize();
                page.SetMediaBox(pageRec);

                float pageWidth = pageRec.GetWidth();

                float pointX;
                float pointY = 30.0f;

                switch (pos)
                {
                    case PageNumberPos.Center:
                        pointX = pageWidth / 2;
                        break;
                    case PageNumberPos.Corner:
                        if (i % 2 == 0)
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

                // 画白色背景，遮住原来的内容
                PdfCanvas canvas = new PdfCanvas(page);
                DrawWhiteBack(canvas, whiteX, whiteY, whiteWidth, whiteHeight);

                canvas.SetFillColor(ColorConstants.BLACK);

                doc.ShowTextAligned(new Paragraph(GetPageNumber(i, totalPage)).SetFont(font).SetFontSize(18f),
                        pointX, pointY, i, TextAlignment.CENTER, VerticalAlignment.MIDDLE, 0);
            }
            doc.Close();

        }


        private void DrawWhiteBack(PdfCanvas canvas, float whiteX, float whiteY, float whiteWidth, float whiteHeight)
        {
            canvas.SetFillColor(ColorConstants.ORANGE);
            canvas.Rectangle(whiteX, whiteY, whiteWidth, whiteHeight);
            canvas.Fill();
        }

        public string AddPageNumber()
        {

            PdfDocument pdfDoc = new PdfDocument(new PdfReader(_src_file), new PdfWriter(_dst_file));
            Document doc = new Document(pdfDoc);
            int totalPage = pdfDoc.GetNumberOfPages();

            PdfFont numberFont;
            switch (_pageNumberStyle)
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

            AddFormatedNumber(totalPage, doc, numberFont, _pageNumberPos);

            return _dst_file;
        }


    }
}
