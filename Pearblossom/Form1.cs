using pearblossom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.util;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private string src_filepath;
        private string format;

        public Form1()
        {
            InitializeComponent();

            this.format = "dOCXToolStripMenuItem";
            dOCXToolStripMenuItem.Checked = true;
            dOCXToolStripMenuItem.Image = global::pearblossom.Properties.Resources.dot;

            this.show_tip("点击“打开”或拖放带有目录的 PDF 文件。");
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
            if (!dOCXToolStripMenuItem.Checked)
            {
                this.single_checked(sender);
            }
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
            if (!tXTToolStripMenuItem.Checked)
            {
                this.single_checked(sender);
            }
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
            switch (this.format)
            {
                case "dOCXToolStripMenuItem":
                    this.dOCXToolStripMenuItem_Click(dOCXToolStripMenuItem, null);
                    break;
                case "tXTToolStripMenuItem":
                    this.tXTToolStripMenuItem_Click(tXTToolStripMenuItem, null);
                    break;
                default:
                    this.dOCXToolStripMenuItem_Click(dOCXToolStripMenuItem, null);
                    break;
            }
        }



        private void show_tip(string tip)
        {
            label2.Text = tip;
        }

        private void single_checked(object sender)
        {

            this.format = ((ToolStripMenuItem)sender).Name;

            dOCXToolStripMenuItem.Checked = false;
            tXTToolStripMenuItem.Checked = false;
            dOCXToolStripMenuItem.Image = null;
            tXTToolStripMenuItem.Image = null;

            ((ToolStripMenuItem)sender).Checked = true;
            ((ToolStripMenuItem)sender).Image = global::pearblossom.Properties.Resources.dot;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form form2 = new Form2();
            form2.Show();
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://github.com/angela-1/pearblossom";

            // Open Internet Explorer to the correct url.
            System.Diagnostics.Process.Start("IExplore.exe", url);

        }
    }
}

