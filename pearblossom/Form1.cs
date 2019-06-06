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
        public String srcFile;
        public String[] files;

        public Form1()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            srcFile = "";
            showStatus("选择文件或拖放文件到此界面");
        }


        public void showContent(String content)
        {
            textBox1.Text = content;
        }

        public void showFiles()
        {
            String s = String.Join("\r\n", this.files);
            textBox1.Text = "文件列表：\r\n" + s;
        }

        public void showStatus(String status)
        {
            toolStripStatusLabel1.Text = status;
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
            openFileDialog.Filter = "PDF 文件(*.pdf)|*.pdf|所有文件(*.*)|*.*";
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
            this.files = (String[])e.Data.GetData(DataFormats.FileDrop);

            //String path = ((Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();

            srcFile = this.files[0];
            showStatus("已选文件");
            showFiles();
        }

        private void docxToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (srcFile != "")
            {
                DocxToc docxToc = new DocxToc(srcFile);
                String dst_file = docxToc.Output();
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
                String dst_file = docxToc.Output();
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
            String url = "https://github.com/angela-1/pearblossom";

            // Open Internet Explorer to the correct url.
            System.Diagnostics.Process.Start("IExplore.exe", url);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            if (this.srcFile != "")
            {
                List<String> dst_file = new List<String>();
                foreach (var f in this.files)
                {
                    dst_file.Add(EvenPage.AddEvenPage(f));
                }
                showStatus("添加偶数页成功");
            }
            else
            {
                showStatus("请选择文件");
            }

        }

        private void MergeStripButton_Click(object sender, EventArgs e)
        {
            if (this.srcFile != "")
            {
                String folderPath = Path.GetDirectoryName(this.srcFile);
                this.showContent(@"源文件夹：
" + folderPath);
                Form form4 = new Form4(this, folderPath);
                form4.Show();

                showStatus("合并文件成功");
            }
            else
            {
                showStatus("请选择文件");
            }


            //FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            //folderBrowser.Description = "请选择要合并文件夹";
            //if (folderBrowser.ShowDialog() == DialogResult.OK)
            //{
            //    if (String.IsNullOrEmpty(folderBrowser.SelectedPath))
            //    {
            //        MessageBox.Show(this, "文件夹路径不能为空", "提示");
            //        return;
            //    }

            //    Form form4 = new Form4(this, folderBrowser.SelectedPath);
            //    form4.Show();

            //    showStatus("合并文件成功");
            //}
            ////String[] temArr = { "d:\\a.pdf", "d:\\b.pdf", "d:\\c.docx" };
            //String[] temArr = { "d:\\a.pdf", "d:\\b.pdf" };
            //List<String> testList = new List<String>(temArr);
            //MergeDocumentUtil.MergePdfs(testList, "d:\\cc.pdf");


            //MergeDocumentUtil.filterDocx(testList);
        }
    }
}
