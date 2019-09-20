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
using System.IO;

namespace pearblossom
{
    abstract class Toc
    {
        protected List<string> _outline;
        protected string _src_file;

        protected int ParseToc()
        {
            _outline = new List<string>();
            PdfReader reader = new PdfReader(_src_file);
            IList<Dictionary<string, object>> outline_list = SimpleBookmark.GetBookmark(reader);

            if (outline_list != null)
            {
                foreach (var level1 in outline_list)
                {
                    string s = GetBookmark(level1);
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

        protected string GetBookmark(Dictionary<string, object> section)
        {
            string page = "Page";
            if (section.ContainsKey(page))
            {
                string num_page = (string)section[page];
                string one_line = section["Title"] + "\t" + num_page.Split(' ')[0];
                if (section.ContainsKey("Kids"))
                {
                    List<Dictionary<String, object>> kids = (List<Dictionary<string, object>>)section["Kids"];
                    foreach (var kid in kids)
                    {
                        one_line += "\n";
                        one_line += GetBookmark(kid);
                    }
                }
                return one_line;
            }
            else
            {
                return "书签无Pages";
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
