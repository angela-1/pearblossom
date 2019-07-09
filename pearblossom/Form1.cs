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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pearblossom
{
    public partial class Form1 : Form
    {
        public string srcFile;
        public string[] files;

        public Form1()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            srcFile = "";
            ShowStatus("选择文件或拖放文件到此界面");
        }


        public void ShowContent(string content)
        {
            textBox1.Text = content;
        }

        public void ShowFiles()
        {
            string s = string.Join("\r\n", this.files);
            textBox1.Text = "文件列表：\r\n" + s;
        }

        public void ShowStatus(string status)
        {
            toolStripStatusLabel1.Text = status;
        }

        private void PageNumberToolStripButton_Click(object sender, EventArgs e)
        {
            if (srcFile != "")
            {
                Form form3 = new Form3(this);
                form3.Show();
            }
            else
            {
                ShowStatus("请选择文件");
            }

        }

        private void OpenToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                //openFileDialog.InitialDirectory = "c:\\"; // 不设置默认打开桌面
                Filter = "PDF 文件(*.pdf)|*.pdf|所有文件(*.*)|*.*",
                Multiselect = true,
                RestoreDirectory = true,
                FilterIndex = 1
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.files = openFileDialog.FileNames;
                srcFile = this.files[0];
                ShowStatus("已选文件");
                ShowFiles();
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            this.files = (string[])e.Data.GetData(DataFormats.FileDrop);

            //string path = ((Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).Tostring();

            srcFile = this.files[0];
            ShowStatus("已选文件");
            ShowFiles();
        }

        private void DocxToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (srcFile != "")
            {
                DocxToc docxToc = new DocxToc(srcFile);
                docxToc.Output();
                ShowStatus("导出目录成功");

            }
            else
            {
                ShowStatus("请选择文件");
            }

        }

        private void TxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (srcFile != "")
            {
                TxtToc docxToc = new TxtToc(srcFile);
                docxToc.Output();
                ShowStatus("导出目录成功");
            }
            else
            {
                ShowStatus("请选择文件");
            }
        }





        private void ToolStripStatusLabel3_Click(object sender, EventArgs e)
        {
            Form form2 = new Form2();
            form2.Show();

        }

        private void GithubToolStripStatusLabel_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/angela-1/pearblossom";

            // Open Internet Explorer to the correct url.
            System.Diagnostics.Process.Start("IExplore.exe", url);
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            if (this.srcFile != "")
            {
                List<string> dst_file = new List<string>();
                foreach (var f in this.files)
                {
                    dst_file.Add(EvenPage.AddEvenPage(f));
                }
                ShowStatus("添加偶数页成功");
            }
            else
            {
                ShowStatus("请选择文件");
            }

        }

        private void MergeStripButton_Click(object sender, EventArgs e)
        {
            if (srcFile != "" && Directory.Exists(srcFile))
            {
                string folderPath = srcFile;
                this.ShowContent(@"源文件夹：
" + folderPath);
                Form form4 = new Form4(this, folderPath);
                form4.Show();

                ShowStatus("合并文件成功");
            }
            else
            {
                ShowStatus("请选择文件夹");
            }
        }
    }
}
