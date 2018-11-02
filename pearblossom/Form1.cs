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
            init();
        }

        private void init()
        {
            srcFile = "";
            showStatus("选择或拖放 PDF 文件。");
        }

        public void showFiles()
        {
            string s = string.Join("\r\n", this.files);
            textBox1.Text = "文件列表：\r\n" + s;
        }

        public void showStatus(string v)
        {
            toolStripStatusLabel1.Text = v;
        }

        private void pageNumberToolStripButton_Click(object sender, EventArgs e)
        {
            if (srcFile != "")
            {
                Form form3 = new Form3(this);
                form3.Show();
            }
            else
            {
                showStatus("请选择文件");
            }
            
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.InitialDirectory = "c:\\"; // 不设置默认打开桌面
            openFileDialog.Filter = "PDF 文件|*.pdf";
            openFileDialog.Multiselect = true;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.files = openFileDialog.FileNames;
                srcFile = this.files[0];
                showStatus("已选文件");
                showFiles();
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            this.files = (string[])e.Data.GetData(DataFormats.FileDrop);

            //string path = ((Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();

            srcFile = this.files[0];
            showStatus("已选文件");
            showFiles();
        }

        private void docxToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (srcFile != "")
            {
                DocxToc docxToc = new DocxToc(srcFile);
                string dst_file = docxToc.Output();
                showStatus("导出目录成功");

            }
            else
            {
                showStatus("请选择文件");
            }

        }

        private void txtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (srcFile != "")
            {
                TxtToc docxToc = new TxtToc(srcFile);
                string dst_file = docxToc.Output();
                showStatus("导出目录成功");
            }
            else
            {
                showStatus("请选择文件");
            }
        }





        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {
            Form form2 = new Form2();
            form2.Show();

        }

        private void githubToolStripStatusLabel_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/angela-1/pearblossom";

            // Open Internet Explorer to the correct url.
            System.Diagnostics.Process.Start("IExplore.exe", url);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            if (this.files.Length > 0)
            {
                List<string> dst_file = new List<string>();
                foreach (var f in this.files)
                {
                    dst_file.Add(EvenPage.AddEvenPage(f));
                }
                showStatus("添加偶数页成功");
            }
            else
            {
                showStatus("请选择文件。");
            }

        }
    }
}
