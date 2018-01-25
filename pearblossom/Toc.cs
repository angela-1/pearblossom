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

using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pearblossom
{
    abstract class Toc 
    {
        protected List<string> _outline;
        protected string _src_file;

        protected int _parse_toc()
        {
            _outline = new List<string>();
            PdfReader reader = new PdfReader(_src_file);
            IList<Dictionary<string, object>> outline_list = SimpleBookmark.GetBookmark(reader);

            if (outline_list != null)
            {
                foreach (var level1 in outline_list)
                {
                    string s = _get_bookmark(level1);
                    _outline.Add(s);
                }
                reader.Close();
                return 0;
            }
            else
            {
                return -1;
            }
        }

        protected string _get_bookmark(Dictionary<string, object> section)
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

        protected abstract string _get_toc_name();
        public abstract string Output();

    }
}
