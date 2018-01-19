using iTextSharp.text.pdf;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pearblossom
{
    class WordToc
    {
        private List<string> outline;
        private string src_filepath;
        
        public WordToc(string filepath)
        {
            this.src_filepath = filepath;
            this._parse_toc();
        }

        private int _parse_toc()
        {
            this.outline = new List<string>();
            PdfReader reader = new PdfReader(this.src_filepath);
            IList<Dictionary<string, object>> outline_list = SimpleBookmark.GetBookmark(reader);

            if (outline_list != null)
            {
                foreach (var level1 in outline_list)
                {
                    string s = _get_bookmark(level1);
                    this.outline.Add(s);
                }
                return 0;
            }
            else
            {
                return -1;
            }
        }

        private string _get_bookmark(Dictionary<string, object> section)
        {
            string page = "Page";
            if (section.ContainsKey(page))
            {
                string num_page = (string)section[page];
                string one_line = section["Title"] + "\t" + num_page.Split(' ')[0];
                if (section.ContainsKey("Kids"))
                {
                    List<Dictionary<string, object>> kids = (List<Dictionary<string, object>>)section["Kids"];
                    foreach (var kid in kids)
                    {
                        one_line += "\n";
                        one_line += _get_bookmark(kid);
                    }
                }
                return one_line;
            }
            else
            {
                return "书签无Pages";
            }
        }

        private string _get_toc_name()
        {
            int ind = this.src_filepath.LastIndexOf('\\');
            string toc_name = System.IO.Path.GetFileNameWithoutExtension(this.src_filepath);
            string toc_filepath = this.src_filepath.Substring(0, ind + 1) + toc_name + "_toc.docx";
            return toc_filepath;
        }

        public void output()
        {
            Application word = new ApplicationClass();
            word.Visible = false;
            Document doc = word.Documents.Add();

            //word.Selection.ParagraphFormat.LineSpacing = 28f;//设置文档的行间距
            //word.Selection.ParagraphFormat.FirstLineIndent = 0;//首行缩进的长度
            //写入普通文本
            float k = doc.PageSetup.PageWidth - doc.PageSetup.LeftMargin - doc.PageSetup.RightMargin;

            doc.PageSetup.TopMargin = word.CentimetersToPoints(3.7F);
            doc.PageSetup.BottomMargin = word.CentimetersToPoints(3.5F);
            doc.PageSetup.LeftMargin = word.CentimetersToPoints(2.8F);
            doc.PageSetup.RightMargin = word.CentimetersToPoints(2.6F);


            doc.Paragraphs.Last.Range.Text = "目  录";

            foreach (string item in this.outline)
            {
                doc.Paragraphs.Last.Range.Text += item;
            }


            Selection cursor = word.Selection;

            cursor.WholeStory();

            cursor.ParagraphFormat.SpaceBeforeAuto = 0;
            cursor.ParagraphFormat.SpaceAfterAuto = 0;
            cursor.ParagraphFormat.LeftIndent = 0;
            cursor.ParagraphFormat.FirstLineIndent = 0;
            cursor.ParagraphFormat.CharacterUnitFirstLineIndent = 0;
            cursor.ParagraphFormat.WordWrap = 0;

            cursor.ParagraphFormat.FirstLineIndent = 0;

            cursor.ParagraphFormat.TabStops.ClearAll();
            cursor.ParagraphFormat.TabStops.Add(Position: word.CentimetersToPoints(14.6F),
                Alignment: WdHorizontalLineAlignment.wdHorizontalLineAlignLeft,
                Leader: WdTabLeader.wdTabLeaderDots);



            object format = WdSaveFormat.wdFormatDocument;// office 2007就是wdFormatDocumentDefault
            //将wordDoc文档对象的内容保存为DOCX文档
            doc.SaveAs2(this._get_toc_name());

            doc.Close();
            //关闭wordApp组件对象
            word.Quit();

        }


    }
}
