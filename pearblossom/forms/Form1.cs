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
using System.IO;
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
            ShowContent("欢迎使用");
        }


        public void ShowContent(string content)
        {
            textBox1.Text = content;
        }

        public void ShowFiles()
        {
            string s = string.Join("\r\n", files);
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
                Filter = "PDF 文件(*.pdf)|*.pdf|Word 文件(*.docx)|*.docx|Word 文件(*.doc)|*.doc|所有文件(*.*)|*.*",
                Multiselect = true,
                RestoreDirectory = true,
                FilterIndex = 1
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                files = openFileDialog.FileNames;
                srcFile = files[0];
                ShowStatus("已选文件");
                ShowFiles();
            }
            openFileDialog.Dispose();
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            files = (string[])e.Data.GetData(DataFormats.FileDrop);

            //string path = ((Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).Tostring();

            srcFile = files[0];
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



        private void XlsxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (srcFile != "")
            {
                XlsxToc docxToc = new XlsxToc(srcFile);
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
            if (srcFile != "")
            {
                List<string> dst_file = new List<string>();
                foreach (var f in files)
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
            bool isFolder = Directory.Exists(srcFile);
            if (isFolder || files.Length > 1)
            {
                string[] filePaths = files;
                ShowFiles();
                Form form4 = new Form4(this, filePaths);
                form4.Show();
                ShowStatus("合并文件成功");
            }
            else
            {
                MessageBox.Show("只支持文件夹或多个文件。若要转换格式请使用转换格式功能。");
                ShowStatus("请选择文件夹或多个文件");
            }
        }


        private void Convert(string[] fileOrPath, string format)
        {
            if (srcFile != "")
            {
                string dest = "";
                ShowStatus("处理中...");
                foreach (var f in fileOrPath)
                {
                    dest = DocumentConverterUtils.Convert(f, format);
                }
                if (files.Length > 1)
                {
                    dest = Path.GetDirectoryName(dest);
                }
                ShowContent(@"结果：
" + dest);
                ShowStatus("转换完成");
            }
            else
            {
                ShowStatus("请选择文件");
            }
        }

        private void ToDocxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Convert(files, "docx");
        }

        private void ToPdfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Convert(files, "pdf");
        }

        private void ToTxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Convert(files, "txt");
        }


    }
}
