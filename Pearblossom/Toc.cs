using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections.Generic;
using System.IO;

namespace WindowsFormsApp1
{
    class Toc
    {
        private string outline;
        private string filepath;
        public Toc(string filepath)
        {
            this.filepath = filepath;
        }

        private void _write_toc(string content)
        {
            var ind = this.filepath.LastIndexOf('\\');
            var toc_name = System.IO.Path.GetFileNameWithoutExtension(this.filepath);
            string toc_filepath = this.filepath.Substring(0, ind+1) + toc_name +"_toc.txt";
            FileStream fs = new FileStream(toc_filepath, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(content);     
            sw.Flush();     
            sw.Close();
            fs.Close();
        }

        private string _show_oneline(Dictionary<string, object> section)
        {
            string kk = "Page";
            if (section.ContainsKey(kk))
            {
                string num_page = (string)section[kk];
                string one_line = section["Title"] + "\t" + num_page.Split(' ')[0];
                if (section.ContainsKey("Kids"))
                {
                    List<Dictionary<string, object>> kids = (List<Dictionary<string, object>>)section["Kids"];
                    foreach (var kid in kids)
                    {
                        one_line += "\n";
                        one_line += _show_oneline(kid);
                    }
                }
                return one_line;

            } else
            {
                return "书签无Pages";
            }

            


        }

        public bool ReadToc()
        {

            PdfReader reader = new PdfReader(this.filepath);
            IList<Dictionary<string, object>> outline_list = SimpleBookmark.GetBookmark(reader);

            if (outline_list != null)
            {
                foreach (var level1 in outline_list)
                {
                    string tt = _show_oneline(level1);
                    outline += "\n";
                    outline += tt;
                    //Debug.WriteLine(tt);

                }
                return true;
            } else
            {
                return false;
            }



  


        }

        public void WriteToc()
        {
            this._write_toc(this.outline);
        }

        public void write_outline()
        {
            BaseFont bfchinese = BaseFont.CreateFont(@"c:\windows\fonts\simfang.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            Font ChFont = new Font(bfchinese, 12);
            Font ChFont_blue = new Font(bfchinese, 40, Font.NORMAL, new BaseColor(51, 0, 153));
            Font ChFont_msg = new Font(bfchinese, 12, Font.ITALIC, BaseColor.RED);

            Document document = new Document();
            PdfWriter.GetInstance(document, new FileStream("Chap0101.pdf", FileMode.Create));
            document.Open();
            document.Add(new Paragraph("Hello中文PDF你说 World", ChFont_blue));
            document.Close();


        }
    }
}
