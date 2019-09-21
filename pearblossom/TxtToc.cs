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

using System.IO;

namespace pearblossom
{
    class TxtToc : Toc
    {
        public TxtToc(string filepath)
        {
            _src_file = filepath;
            ParseToc();
        }

        public override string Output()
        {
            string dst_filepath = GetTocName("txt");
            FileStream fs = new FileStream(dst_filepath, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            foreach (var line in _outline)
            {
                sw.WriteLine(line.title + '\t' + line.page);
            }

            sw.Flush();
            sw.Close();
            fs.Close();
            return dst_filepath;
        }
    }
}
