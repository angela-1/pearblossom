using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MSWord = Microsoft.Office.Interop.Word;

namespace pearblossom
{
    class MergeDocumentUtil
    {
        public static void run(String folderPath, Boolean withBookmark)
        {
            string[] filesList = Directory.GetFiles(folderPath);
            if (filesList.Count() == 0)
            {
                return;
            }
            List<String> docxFiles = filterDocx(new List<String>(filesList));
            foreach (var docxFile in docxFiles)
            {
                docx2pdf(docxFile);
            }

            string[] allFilesList = Directory.GetFiles(folderPath);
            List<String> pdfFiles = filterPdf(new List<String>(allFilesList));
            pdfFiles.Sort((x1, x2) =>
            {
                return int.Parse(Regex.Match(Path.GetFileNameWithoutExtension(x1), @"\d+").Value)
                .CompareTo(int.Parse(Regex.Match(Path.GetFileNameWithoutExtension(x2), @"\d+").Value));
            });

            String targetFolder = Path.GetDirectoryName(folderPath);
            String outFile = Path.GetFileName(folderPath);
            String target = Path.Combine(targetFolder, outFile + ".pdf");

            if (withBookmark)
            {
                MergePdfsWithBookmarks(pdfFiles, target);
            } else
            {
                MergePdfs(pdfFiles, target);
            }


            foreach (string item in pdfFiles)
            {
                //字符串截取，指定字符串出现‘.’+1的转换小写==“txt”的时候
                if (item.Substring(item.LastIndexOf('.') + 1).ToLower() == "txt")
                {
                    //richbox控件.追加显示文本（数组集合）
                }
            }


        }
        public static List<String> filterDocx(List<String> filepaths)
        {
            List<String> result = new List<string>();
            foreach (var item in filepaths)
            {
                String ext = Path.GetExtension(item);
                if (ext == ".docx" || ext == ".doc")
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public static List<String> filterPdf(List<String> filepaths)
        {
            List<String> result = new List<string>();
            foreach (var item in filepaths)
            {
                String ext = Path.GetExtension(item);
                if (ext == ".pdf")
                {
                    result.Add(item);
                }
            }
            return result;
        }
        private static string getDestFilename(string filePath)
        {
            string newFile = Path.GetFileNameWithoutExtension(filePath) + ".pdf";
            string dest = Path.GetDirectoryName(filePath);
            return Path.Combine(dest, newFile);
        }

        private static String docx2pdf(String filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("文件" + filePath + "不存在");
                return null;
            }

            MSWord.Application app = new MSWord.Application();
            app.Visible = false;

            MSWord.Document doc = app.Documents.Open(filePath);
            string dest = getDestFilename(filePath);
            doc.ExportAsFixedFormat(dest, MSWord.WdExportFormat.wdExportFormatPDF,
                        CreateBookmarks: MSWord.WdExportCreateBookmarks.wdExportCreateNoBookmarks);

            doc.Close();
            app.Quit();
            return dest;
        }
        private static void MergePdfs(List<String> InFiles, String OutFile)
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

                    var kk = new Dictionary<string, object>();
                    kk.Add("Action", "GoTo");
                    kk.Add("Title", title);
                    kk.Add("Page", pdf.PageNumber + " FitH 842");
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

        private static void MergePdfsWithBookmarks(List<String> InFiles, String OutFile)
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
                    kids.AddRange(ks);


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
