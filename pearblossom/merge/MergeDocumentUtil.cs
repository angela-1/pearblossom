using iTextPageSize = iText.Kernel.Geom.PageSize;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Action;
using iText.Kernel.Pdf.Navigation;
using iText.Kernel.Utils;
using iText.Layout;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using MSWord = Microsoft.Office.Interop.Word;
using iText.Pdfa;
using iText.IO.Image;
using iText.Layout.Element;

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
                //filesList.Remove(docxFile);
                int ind = filesList.FindIndex(f => f == docxFile);
                string pdfFile = DocxToPdf(docxFile, withBookmark);
                filesList[ind] = pdfFile;
                //filesList.Add(pdfFile);
                tmpPdfFiles.Add(pdfFile);
            }

            List<string> imgFiles = Filters(filesList, ".jpg");
            foreach (var img in imgFiles)
            {
                int ind = filesList.FindIndex(f => f == img);
                string pdfFile = ImgToPdf(img);
                filesList[ind] = pdfFile;
                tmpPdfFiles.Add(pdfFile);
            }

            List<string> pdfFiles = FilterPdf(filesList);
            //pdfFiles.Sort((x1, x2) =>
            //{
            //    bool hasNumber = Regex.IsMatch(Path.GetFileNameWithoutExtension(x1), @"\d+")
            //      && Regex.IsMatch(Path.GetFileNameWithoutExtension(x2), @"\d+");
            //    if (hasNumber)
            //    {
            //        return int.Parse(Regex.Match(Path.GetFileNameWithoutExtension(x1), @"\d+").Value)
            //    .CompareTo(int.Parse(Regex.Match(Path.GetFileNameWithoutExtension(x2), @"\d+").Value));
            //    }
            //    else
            //    {
            //        return -1;
            //    }

            //});

            string targetFolder = Path.GetDirectoryName(Path.GetDirectoryName(filePaths[0]));

            string outFile = Path.GetFileName(Path.GetDirectoryName(filePaths[0]));
            string target = Path.Combine(targetFolder, outFile + ".pdf");

            if (withBookmark)
            {
                MergePdfsWithBookmarks(pdfFiles, target);
            }
            else
            {
                MergePdfs(pdfFiles, target);
            }

            //Clean(tmpPdfFiles);

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


        private static List<string> Filters(List<string> filePaths, string extensionWithDot)
        {
            List<string> result = new List<string>();
            foreach (var item in filePaths)
            {
                string ext = Path.GetExtension(item);
                if (ext == extensionWithDot)
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
                if (ext == ".pdf" || ext == ".jpg")
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


        private static string ImgToPdf(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("文件" + filePath + "不存在");
                return null;
            }

            string dest = GetDestFilename(filePath);

            PdfDocument pdfDoc = new PdfDocument(new PdfWriter(dest));
            Image image = new Image(ImageDataFactory.Create(filePath));
            pdfDoc.AddNewPage(iTextPageSize.A4);

            Document doc = new Document(pdfDoc, iTextPageSize.A4);
            doc.Add(image);

            doc.Close();
            return dest;
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
            PdfDocument pdfDoc = new PdfDocument(new PdfWriter(OutFile));
            pdfDoc.InitializeOutlines();

            //PdfMerger merger = new PdfMerger(pdfDoc, false, false);

            PdfOutline rootOutline = pdfDoc.GetOutlines(true);
            string parentTitle = Path.GetFileNameWithoutExtension(OutFile);
            PdfOutline parent = rootOutline.AddOutline(parentTitle);


            //parent.AddAction(PdfAction.CreateGoTo(
            //        PdfExplicitRemoteGoToDestination.CreateFit(1)));





            int pageNumber = 0;

            foreach (var srcFile in InFiles)
            {
                string title = Path.GetFileNameWithoutExtension(srcFile);

                PdfDocument firstSourcePdf = new PdfDocument(new PdfReader(srcFile));

                int pageCount = firstSourcePdf.GetNumberOfPages();
                for (int i = 1; i < pageCount + 1; i++)
                {
                    var page = firstSourcePdf.GetPage(i);
                    int pageRotate = page.GetRotation();
                    if (pageRotate != 0)
                    {
                        page.SetRotation(0);
                    }
                    PdfPage newPage = firstSourcePdf.GetPage(i).CopyTo(pdfDoc);
                    pdfDoc.AddPage(newPage);
                }

                //merger.Merge(firstSourcePdf, 1, firstSourcePdf.GetNumberOfPages());

                //firstSourcePdf.CopyPagesTo(1, firstSourcePdf.GetNumberOfPages(), pdfDoc);
                //int all = pdfDoc.GetNumberOfPages();

                PdfExplicitDestination dd = PdfExplicitDestination.CreateFit(pdfDoc.GetPage(pageNumber + 1));
                string tt = Guid.NewGuid().ToString();
                pdfDoc.AddNamedDestination(tt, dd.GetPdfObject());

                PdfOutline kid = parent.AddOutline(title);
                kid.AddAction(PdfAction.CreateGoTo(new PdfStringDestination(tt)));
                //kid.AddAction(PdfAction.CreateGoTo(
                //PdfExplicitRemoteGoToDestination.CreateFit(pageNumber)));

                var bb = parent.GetAllChildren();

                pageNumber += firstSourcePdf.GetNumberOfPages();
                firstSourcePdf.Close();
            }



            PdfExplicitDestination destToPage3 = PdfExplicitDestination.CreateFit(pdfDoc.GetFirstPage());
            string stringDest = Guid.NewGuid().ToString();
            pdfDoc.AddNamedDestination(stringDest, destToPage3.GetPdfObject());
            parent.AddAction(PdfAction.CreateGoTo(new PdfStringDestination(stringDest)));

            if (pdfDoc.GetNumberOfPages() % 2 == 1)
            {
                pdfDoc.AddNewPage(pageNumber, iTextPageSize.A4);
            }

            pdfDoc.Close();
        }

        private static void MergePdfsWithBookmarks(List<string> InFiles, string OutFile)
        {
            PdfDocument pdfDoc = new PdfDocument(new PdfWriter(OutFile));
            pdfDoc.InitializeOutlines();

            PdfMerger merger = new PdfMerger(pdfDoc, true, true);




            List<PdfOutline> listItem = new List<PdfOutline>();

            InFiles.ForEach(srcFile =>
            {
                PdfDocument firstSourcePdf = new PdfDocument(new PdfReader(srcFile));
                merger.Merge(firstSourcePdf, 1, firstSourcePdf.GetNumberOfPages());

                firstSourcePdf.GetOutlines(false).GetDestination();
                firstSourcePdf.Close();
            });

            PdfOutline rootOutline = pdfDoc.GetOutlines(false);

            listItem.AddRange(rootOutline.GetAllChildren());

            rootOutline.GetAllChildren().Clear();

            string parentTitle = Path.GetFileNameWithoutExtension(OutFile);
            PdfOutline parent = rootOutline.AddOutline(parentTitle);

            foreach (var item in listItem)
            {
                parent.AddOutline(item);
            }

            PdfExplicitDestination destToPage3 = PdfExplicitDestination.CreateFit(pdfDoc.GetFirstPage());
            string stringDest = Guid.NewGuid().ToString();
            pdfDoc.AddNamedDestination(stringDest, destToPage3.GetPdfObject());
            parent.AddAction(PdfAction.CreateGoTo(new PdfStringDestination(stringDest)));

            int pageNumber = pdfDoc.GetNumberOfPages();
            if (pdfDoc.GetNumberOfPages() % 2 == 1)
            {
                pdfDoc.AddNewPage(pageNumber, iTextPageSize.A4);
            }

            pdfDoc.Close();
        }
    }
}
