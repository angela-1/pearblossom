using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace pearblossom
{
    class XlsxToc : Toc
    {
        public XlsxToc(string filepath)
        {
            _src_file = filepath;
            ParseToc();
        }

        private ExcelWorksheet AddSheet(ExcelWorksheet sheet, List<string> lines, string[] items)
        {
            int colWidth = items.Length; // 标题行

            string tableTitle = Path.GetFileNameWithoutExtension(_src_file) + "目录";

            // 标题行格式
            sheet.Cells[1, 1, 1, colWidth].Merge = true;
            sheet.Cells["A1"].Value = tableTitle;
            sheet.Cells["A1"].Style.Font.Size = 26;
            sheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            sheet.Cells["A1"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            sheet.Row(1).Height = 50;
            sheet.Cells[1, 1].Style.Font.Name = "宋体";

            int dataRowStart = 2;
            int i = 1;
            foreach (var item in items)
            {
                sheet.Cells[dataRowStart, i].Value = item;
                ++i;
            }

            int row = dataRowStart + 1;
            foreach (var l in lines)
            {
                string[] oneLine = l.Split("\t.".ToCharArray());
                if (oneLine.Length == 3)
                {
                    sheet.Cells[row, 1].Value = oneLine[0];
                    sheet.Cells[row, 2].Value = oneLine[1];
                    sheet.Cells[row, 3].Value = oneLine[2];
                    ++row;
                }
            }


            sheet.Cells[dataRowStart, 1, lines.Count + dataRowStart, colWidth]
                .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            sheet.Cells[dataRowStart, 1, lines.Count + dataRowStart, colWidth]
                .Style.VerticalAlignment = ExcelVerticalAlignment.Center;


            // 序号 姓名列固定宽
            sheet.Column(1).Width = 10;
            sheet.Column(2).Width = 50;
            sheet.Column(3).Width = 10;


            //for (i = dataRowStart; i < lines.Count + 3; i++)
            //{
            //    sheet.Row(i).Height = 50;
            //    for (int j = 1; j < colWidth + 1; j++)
            //    {
            //        if (j > 2)
            //        {
            //            sheet.Column(j).Width = 15;
            //        }

            //        sheet.Cells[i, j].Style.Font.Size = 16;

            //        if (i > 2 && j == 2)
            //        {
            //            sheet.Cells[i, j].Style.Font.Size = 26;
            //        }

            //        sheet.Cells[i, j].Style.Font.Name = "宋体";
            //        sheet.Cells[i, j].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
            //    }
            //}

            // 列标题

            sheet.Row(2).Style.Font.Bold = true;
            sheet.Row(2).Style.WrapText = true;
            sheet.Row(2).Height = 50;

            // 打印设置
            sheet.PrinterSettings.FitToPage = true;
            sheet.PrinterSettings.FitToWidth = 1;
            sheet.PrinterSettings.FitToHeight = 0;
            sheet.PrinterSettings.RepeatRows = sheet.Cells["1:2"];
            return sheet;

        }
        public override string Output()
        {
            string dst_filepath = GetTocName("xlsx");
            FileStream fs = new FileStream(dst_filepath, FileMode.Create);
            ExcelPackage package = new ExcelPackage(fs);

            var sheet = package.Workbook.Worksheets.Add("Sheet1");
            sheet.PrinterSettings.PaperSize = ePaperSize.A4;

            string[] items = { "序号", "资料名称", "页码" };
            List<string> lines = _outline[0].Split('\n').ToList<string>();
            AddSheet(sheet, lines, items);
            package.Save();
            package.Dispose();
            fs.Close();
            return dst_filepath;
        }
    }
}
