using System;
using System.Collections.Generic;
using System.IO;
using MSWord = Microsoft.Office.Interop.Word;


namespace pearblossom
{
    class DocumentConverterUtils
    {
        private static OutputFormat GetFormatType(string format)
        {
            OutputFormat formatType = OutputFormat.PDF;
            switch (format)
            {
                case "pdf":
                    formatType = OutputFormat.PDF;
                    break;
                case "docx":
                    formatType = OutputFormat.DOCX;
                    break;
                case "txt":
                    formatType = OutputFormat.TXT;
                    break;
                default:
                    break;
            }
            return formatType;
        }

        private static List<string> FilterDocx(List<string> filepaths)
        {
            List<string> result = new List<string>();
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

        public static string Convert(string filePath, string format)
        {
            bool isFolder = Directory.Exists(filePath);
            string formatString = format ?? "docx";
            OutputFormat outputFormat = GetFormatType(formatString);
            string dest;
            if (isFolder)
            {
                string[] filePaths = Directory.GetFiles(filePath);
                List<string> docxFiles = FilterDocx(new List<string>(filePaths));
                foreach (var docx in docxFiles)
                {
                    DocxToOther(docx, outputFormat);
                }
                dest = filePath;
            }
            else
            {
                string ext = Path.GetExtension(filePath);
                if (ext != ".docx" && ext != ".doc")
                {
                    Console.WriteLine($"Not support {ext} format");
                    return null;
                }
                dest = DocxToOther(filePath, outputFormat);
            }
            return dest;
        }


        private static string DocxToOther(string filePath, OutputFormat outputFormat)
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
            string dest = GetDestFilename(filePath, outputFormat);
            switch (outputFormat)
            {
                case OutputFormat.PDF:
                    doc.ExportAsFixedFormat(dest, MSWord.WdExportFormat.wdExportFormatPDF,
                        CreateBookmarks: MSWord.WdExportCreateBookmarks.wdExportCreateHeadingBookmarks);
                    break;
                case OutputFormat.DOCX:
                    doc.SaveAs2(dest, MSWord.WdSaveFormat.wdFormatDocumentDefault);
                    break;
                case OutputFormat.TXT:
                    doc.SaveAs2(dest, MSWord.WdSaveFormat.wdFormatText);
                    break;
                default:
                    break;
            }

            doc.Close();
            app.Quit();
            return dest;
        }

        private static string GetExtension(OutputFormat formatType)
        {
            Dictionary<OutputFormat, string> dict = new Dictionary<OutputFormat, string>
            {
                { OutputFormat.PDF, "pdf" },
                { OutputFormat.DOCX, "docx" },
                { OutputFormat.TXT, "txt" }
            };
            return dict[formatType];
        }
        private static string GetDestFilename(string filePath, OutputFormat formatType)
        {
            string newFile = Path.GetFileNameWithoutExtension(filePath) + "." + GetExtension(formatType);
            string dest = Path.GetDirectoryName(filePath);
            return Path.Combine(dest, newFile);
        }
    }
}
