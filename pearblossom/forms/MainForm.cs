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
    public partial class MainForm : Form
    {
        public string srcFile;
        public string[] files;

        public MainForm()
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

        public void ShowProgress(bool show)
        {
            toolStripProgressBar1.Visible = show;
            toolStripProgressBar1.Style = show ?
                ProgressBarStyle.Marquee : ProgressBarStyle.Blocks;
        }
        public void ShowContent(string title, string content = null)
        {
            string str = string.Concat(title, "\r\n", content);
            textBox1.Text = str;
        }

        public string AssembleFilesString()
        {
            string s = "";
            for (int i = 0; i < files.Length; i++)
            {
                s += (i + 1).ToString() + ". " + files[i] + "\r\n";
            }
            return s;
        }

        public void ShowStatus(string status)
        {
            toolStripStatusLabel1.Text = status;
        }

        private void PageNumberToolStripButton_Click(object sender, EventArgs e)
        {
            if (srcFile != "")
            {
                Form form3 = new PagenumberForm(this);
                form3.ShowDialog();
                form3.Dispose();
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
                Filter = "所有文件(*.*)|*.*|PDF 文件(*.pdf)|*.pdf|Word 文件(*.docx)|*.docx|Word 文件(*.doc)|*.doc",
                Multiselect = true,
                RestoreDirectory = true,
                FilterIndex = 1
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                files = openFileDialog.FileNames;
                srcFile = files[0];
                ShowStatus("就绪");
                ShowContent("源文件", AssembleFilesString());
            }
            openFileDialog.Dispose();
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            files = (string[])e.Data.GetData(DataFormats.FileDrop);
            srcFile = files[0];
            ShowStatus("已选文件");
            ShowContent("源文件", AssembleFilesString());
        }

        private void ExportTocToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (srcFile != "")
            {
                string name = ((ToolStripMenuItem)sender).Name;
                switch (name)
                {
                    case "docxToolStripMenuItem":
                        DocxToc docxToc = new DocxToc(srcFile);
                        docxToc.Output();
                        break;
                    case "xlsxToolStripMenuItem":
                        XlsxToc xlsxToc = new XlsxToc(srcFile);
                        xlsxToc.Output();
                        break;
                    case "txtToolStripMenuItem":
                        TxtToc txtToc = new TxtToc(srcFile);
                        txtToc.Output();
                        break;
                    default:
                        break;
                }
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
            form2.ShowDialog();
            form2.Dispose();
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
            if (srcFile != "")
            {
                string[] filePaths = files;
                ShowContent("结果", AssembleFilesString());
                Form form4 = new KeepBookmarkForm(this, filePaths);
                form4.ShowDialog();
                form4.Dispose();
            }
            else
            {
                ShowStatus("请选择文件");
            }

        }


        private void Convert(string[] fileOrPath, string format)
        {
            if (srcFile != "")
            {
                string dest = "";
                ShowStatus("处理中...");
                ShowProgress(true);
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
                ShowProgress(false);
                ShowStatus("完成");
            }
            else
            {
                ShowStatus("请选择文件");
            }
        }



        private void ConvertToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (srcFile != "")
            {
                string name = ((ToolStripMenuItem)sender).Name;
                switch (name)
                {
                    case "toDocxToolStripMenuItem":
                        Convert(files, "docx");
                        break;
                    case "toPdfToolStripMenuItem":
                        Convert(files, "pdf");
                        break;
                    case "toTxtToolStripMenuItem":
                        Convert(files, "txt");
                        break;
                    default:
                        break;
                }
                ShowStatus("转换成功");
            }
            else
            {
                ShowStatus("请选择文件");
            }

        }

       
    }
}
