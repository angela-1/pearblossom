using pearblossom;
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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private string src_filepath;

        public Form1()
        {
            InitializeComponent();
            tXTToolStripMenuItem.Checked = true;

            this.show_tip("点击“打开”或拖放带有目录的 PDF 文件。");


            //            label3.Text = @"资料汇编目录生成工具

            //1. 用 Acrobat 编辑好 PDF 文件中的书签。
            //2. 用此工具导出文件中的书签。
            //3. 复制文本格式的目录到 Word 文件中。
            //4. 设置各级标题的制表位为右侧页码处，中间使用点分隔。";
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            // choose file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.InitialDirectory = "c:\\"; // 不设置默认打开桌面
            openFileDialog.Filter = "PDF 文件|*.pdf";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                src_filepath = path;
                this.show_tip("已选：\n" + path + "\n" + "点击“提取”生成目录文件，默认为 docx 格式。");
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            src_filepath = path;
            this.show_tip("已选：\n" + path + "\n" + "点击“提取”生成目录文件，默认为 docx 格式。");
        }

        private void dOCXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (src_filepath != null)
            {
                WordToc a = new WordToc(src_filepath);
                string dst_filepath = a.output();
                this.show_tip("导出目录成功。\n目标文件：\n" + dst_filepath);

            }
            else
            {
                this.show_tip("未选择 PDF 文件。");
            }
        }

        private void tXTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (src_filepath != null)
            {
                Toc a = new Toc(src_filepath);
                if (a.ReadToc())
                {
                    string dst_filepath = a.WriteToc();
                    this.show_tip("导出目录成功。\n目标文件：\n" + dst_filepath);
                }
                else
                {
                    this.show_tip("该文件没有书签。");
                }
            }
            else
            {
                this.show_tip("未选择 PDF 文件。");

            }
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            this.dOCXToolStripMenuItem_Click(null, null);
        }



        private void show_tip(string tip)
        {
            label2.Text = tip;
        }


    }
}

