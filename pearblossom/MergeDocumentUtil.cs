using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using MSWord = Microsoft.Office.Interop.Word;

namespace pearblossom
{
    class MergeDocumentUtil
    {
        public static string Run(string[] filePaths, bool withBookmark)
        {
            List<string> filesList = new List<string>(filePaths);
            if (filesList.Count() == 0)
            {
                return null;
            }
            List<string> docxFiles = FilterDocx(filesList);
            List<string> tmpPdfFiles = new List<string>();
            foreach (var docxFile in docxFiles)
            {
                filesList.Remove(docxFile);
                string pdfFile = DocxToPdf(docxFile, withBookmark);
                filesList.Add(pdfFile);
                tmpPdfFiles.Add(pdfFile);
            }

            List<string> pdfFiles = FilterPdf(filesList);
            pdfFiles.Sort((x1, x2) =>
            {
                bool hasNumber = Regex.IsMatch(Path.GetFileNameWithoutExtension(x1), @"\d+")
                  && Regex.IsMatch(Path.GetFileNameWithoutExtension(x2), @"\d+");
                if (hasNumber)
                {
                    return int.Parse(Regex.Match(Path.GetFileNameWithoutExtension(x1), @"\d+").Value)
                .CompareTo(int.Parse(Regex.Match(Path.GetFileNameWithoutExtension(x2), @"\d+").Value));
                }
                else
                {
                    return -1;
                }

            });

            string targetFolder = Path.GetDirectoryName(filePaths[0]);
            string outFile = Path.GetFileName(targetFolder);
            string target = Path.Combine(targetFolder, outFile + ".pdf");

            if (withBookmark)
            {
                MergePdfsWithBookmarks(pdfFiles, target);
            }
            else
            {
                MergePdfs(pdfFiles, target);
            }

            Clean(tmpPdfFiles);

            return target;

        }

        public static string Run(string folderPath, bool withBookmark)
        {
            string[] filesList = Directory.GetFiles(folderPath);
            if (filesList.Count() == 0)
            {
                return null;
            }
            string target = Run(filesList, withBookmark);
            return target;
        }

        private static void Clean(List<string> filepaths)
        {
            foreach (var item in filepaths)
            {
                File.Delete(item);
            }
        }
        private static List<string> FilterDocx(List<string> filepaths)
        {
            List<string> result = new List<string>();
            foreach (var item in filepaths)
            {
                string ext = Path.GetExtension(item);
                if (ext == ".docx" || ext == ".doc")
                {
                    result.Add(item);
                }
            }
            return result;
        }

        private static List<string> FilterPdf(List<string> filepaths)
        {
            List<string> result = new List<string>();
            foreach (var item in filepaths)
            {
                string ext = Path.GetExtension(item);
                if (ext == ".pdf")
                {
                    result.Add(item);
                }
            }
            return result;
        }
        private static string GetDestFilename(string filePath)
        {
            string newFile = Path.GetFileNameWithoutExtension(filePath) + ".pdf";
            string dest = Path.GetDirectoryName(filePath);
            return Path.Combine(dest, newFile);
        }

        private static string DocxToPdf(string filePath, bool withBookmark)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("文件" + filePath + "不存在");
                return null;
            }

            MSWord.Application app = new MSWord.Application
            {
                Visible = false
            };

            MSWord.Document doc = app.Documents.Open(filePath);
            string dest = GetDestFilename(filePath);
            doc.ExportAsFixedFormat(dest, MSWord.WdExportFormat.wdExportFormatPDF,
                        CreateBookmarks: withBookmark ?
                        MSWord.WdExportCreateBookmarks.wdExportCreateHeadingBookmarks :
                        MSWord.WdExportCreateBookmarks.wdExportCreateNoBookmarks);

            doc.Close();
            app.Quit();
            return dest;
        }
        private static void MergePdfs(List<string> InFiles, string OutFile)
        {
            using (FileStream stream = new FileStream(OutFile, FileMode.Create))
            using (Document doc = new Document())
            using (PdfCopy pdf = new PdfSmartCopy(doc, stream))
            {
                doc.Open();

                PdfReader reader = null;
                PdfImportedPage page = null;

                var bookmarks = new List<Dictionary<string, object>>();
                var rootBookmark = new Dictionary<string, object>();
                var level1 = Path.GetFileNameWithoutExtension(OutFile);

                rootBookmark.Add("Action", "GoTo");
                rootBookmark.Add("Title", level1);
                rootBookmark.Add("Page", "1 FitH 842"); // use height of 1st page

                var kids = new List<Dictionary<string, object>>();






                //fixed typo
                InFiles.ForEach(file =>
                {
                    var title = Path.GetFileNameWithoutExtension(file);

                    var kk = new Dictionary<string, object>
                    {
                        { "Action", "GoTo" },
                        { "Title", title },
                        { "Page", pdf.PageNumber + " FitH 842" }
                    };
                    kids.Add(kk);

                    reader = new PdfReader(file);

                    for (int i = 0; i < reader.NumberOfPages; i++)
                    {
                        page = pdf.GetImportedPage(reader, i + 1);
                        pdf.AddPage(page);

                    }


                    int pages = reader.NumberOfPages;
                    if (pages % 2 == 1)
                    {
                        pdf.AddPage(PageSize.A4, 0);
                    }

                    IList<Dictionary<string, object>> outline_list = SimpleBookmark.GetBookmark(reader);




                    pdf.FreeReader(reader);
                    reader.Close();
                });


                rootBookmark.Add("Kids", kids);

                bookmarks.Add(rootBookmark);


                pdf.Outlines = bookmarks;




            }
        }

        private static void MergePdfsWithBookmarks(List<string> InFiles, string OutFile)
        {
            using (FileStream stream = new FileStream(OutFile, FileMode.Create))
            using (Document doc = new Document())
            using (PdfCopy pdf = new PdfSmartCopy(doc, stream))
            {
                doc.Open();

                PdfReader reader = null;
                PdfImportedPage page = null;

                var bookmarks = new List<Dictionary<string, object>>();
                var rootBookmark = new Dictionary<string, object>();
                var level1 = Path.GetFileNameWithoutExtension(OutFile);

                rootBookmark.Add("Action", "GoTo");
                rootBookmark.Add("Title", level1);
                rootBookmark.Add("Page", "1 FitH 842"); // use height of 1st page

                var kids = new List<Dictionary<string, object>>();

                //fixed typo
                InFiles.ForEach(file =>
                {
                    var title = Path.GetFileNameWithoutExtension(file);

                    reader = new PdfReader(file);

                    var ks = SimpleBookmark.GetBookmark(reader);
                    SimpleBookmark.ShiftPageNumbers(ks, pdf.PageNumber - 1, null);
                    if (ks != null)
                    {
                        kids.AddRange(ks);
                    }

                    for (int i = 0; i < reader.NumberOfPages; i++)
                    {
                        page = pdf.GetImportedPage(reader, i + 1);
                        pdf.AddPage(page);

                    }


                    int pages = reader.NumberOfPages;
                    if (pages % 2 == 1)
                    {
                        pdf.AddPage(PageSize.A4, 0);
                    }

                    IList<Dictionary<string, object>> outline_list = SimpleBookmark.GetBookmark(reader);




                    pdf.FreeReader(reader);
                    reader.Close();
                });


                rootBookmark.Add("Kids", kids);

                bookmarks.Add(rootBookmark);

                pdf.Outlines = kids;




            }
        }
    }
}
