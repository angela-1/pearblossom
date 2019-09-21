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

using Microsoft.Office.Interop.Word;

namespace pearblossom
{
    class DocxToc:Toc
    {
        public DocxToc(string filepath)
        {
            _src_file = filepath;
            ParseToc();
        }

        public override string Output()
        {
            Application word = new ApplicationClass
            {
                Visible = false
            };
            Document doc = word.Documents.Add();

            doc.PageSetup.TopMargin = word.CentimetersToPoints(3.7F);
            doc.PageSetup.BottomMargin = word.CentimetersToPoints(3.5F);
            doc.PageSetup.LeftMargin = word.CentimetersToPoints(2.8F);
            doc.PageSetup.RightMargin = word.CentimetersToPoints(2.6F);


            doc.Paragraphs.Last.Range.Text = "目  录";

            foreach (var item in _outline)
            {
                doc.Paragraphs.Last.Range.Text += item.title + '\t' + item.page;
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

            //将wordDoc文档对象的内容保存为DOCX文档
            string dst_filepath = GetTocName("docx");
            doc.SaveAs2(dst_filepath);

            doc.Close();
            //关闭wordApp组件对象
            word.Quit();

            return dst_filepath;
        }
    }
}
