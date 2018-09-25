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
        private string _src_file;

        public Form1()
        {
            InitializeComponent();
            _init();
        }

        private void _init()
        {
            _src_file = "";
            _show_tip("点击“打开”或拖放带有目录的 PDF 文件。");
        }

        private void _show_tip(string v)
        {
            tiplabel.Text = v;
        }

        private void pageNumberToolStripButton_Click(object sender, EventArgs e)
        {
            if (_src_file != "")
            {
                PageNumber pageNumber = new PageNumber(_src_file);
                string dst_file = pageNumber.Add();
                _show_tip("添加页码成功。\n目标文件：\n" + dst_file);

            }
            else
            {
                _show_tip("请选择文件。");
            }
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.InitialDirectory = "c:\\"; // 不设置默认打开桌面
            openFileDialog.Filter = "PDF 文件|*.pdf";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                _src_file = path;
                _show_tip("已选：\n" + path + "\n" + "点击“提取目录”选择格式生成目录文件。");
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            _src_file = path;
            _show_tip("已选：\n" + path + "\n" + "点击“提取目录”选择格式生成目录文件。");
        }

        private void docxToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (_src_file != "")
            {
                DocxToc docxToc = new DocxToc(_src_file);
                string dst_file = docxToc.Output();
                _show_tip("导出目录成功。\n目标文件：\n" + dst_file);

            }
            else
            {
                _show_tip("请选择文件。");
            }

        }

        private void txtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_src_file != "")
            {
                TxtToc docxToc = new TxtToc(_src_file);
                string dst_file = docxToc.Output();
                _show_tip("导出目录成功。\n目标文件：\n" + dst_file);
            }
            else
            {
                _show_tip("请选择文件。");
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
            if (_src_file != "")
            {
                string dst_file = EvenPage.AddEvenPage(_src_file);
                _show_tip("导出目录成功。\n目标文件：\n" + dst_file);
            }
            else
            {
                _show_tip("请选择文件。");
            }

        }
    }
}
