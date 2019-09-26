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

using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Navigation;
using iText.Layout;
using System;
using System.Collections.Generic;
using System.IO;

namespace pearblossom
{

    public struct BookItem
    {
        public string title;
        public string page;
    }

    abstract class BaseToc
    {
        protected List<BookItem> _outline;
        protected string _src_file;

        protected int ParseToc()
        {
            _outline = new List<BookItem>();
            PdfDocument pdfDoc = new PdfDocument(new PdfReader(_src_file));

            PdfOutline pdfOutline = pdfDoc.GetOutlines(false);

            PdfNameTree destsTree = pdfDoc.GetCatalog().GetNameTree(PdfName.Dests);

            GetBookmark(pdfOutline, destsTree.GetNames(), pdfDoc);

            pdfDoc.Close();
            return 0;
        }

        protected void GetBookmark(PdfOutline outline, IDictionary<string, PdfObject> names, PdfDocument pdfDoc)
        {

            if (outline.GetDestination() != null)
            {
                BookItem bookItem;
                bookItem.title = outline.GetTitle();
                PdfObject pageNumber = outline.GetDestination()
                    .GetDestinationPage(names);
                bookItem.page = pdfDoc.GetPageNumber(pdfDoc.GetPage((PdfDictionary)pageNumber)).ToString();
                _outline.Add(bookItem);
            }

            foreach (PdfOutline child in outline.GetAllChildren())
            {
                GetBookmark(child, names, pdfDoc);
            }
        }

        protected string GetTocName(string ext)
        {
            int ind = _src_file.LastIndexOf('\\');
            string toc_name = Path.GetFileNameWithoutExtension(_src_file);
            string toc_filepath = _src_file.Substring(0, ind + 1) + toc_name + "_toc." + ext;
            return toc_filepath;
        }
        public abstract string Output();

    }
}
