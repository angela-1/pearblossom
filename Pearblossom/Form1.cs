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
        public Form1()
        {
            InitializeComponent();
            label1.Text = "请拖放或选择PDF文件：";
            label2.Text = "就绪";
            button2.Text = "选择";
            button1.Text = "导出书签";
            label3.Text = @"资料汇编目录生成工具

1. 用 Acrobat 编辑好 PDF 文件中的书签。
2. 用此工具导出文件中的书签。
3. 复制文本格式的目录到 Word 文件中。
4. 设置各级标题的制表位为右侧页码处，中间使用点分隔。";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // choose file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";//注意这里写路径时要用c:\\而不是c:\
            openFileDialog.Filter = "PDF文件|*.pdf|所有文件|*.*";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fName = openFileDialog.FileName;

                textBox1.Text = fName;

                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text  != "")
            {
                Toc a = new Toc(textBox1.Text);
                if (a.ReadToc())
                {
                    a.WriteToc();
                    label2.Text = "导出目录成功。";
                } else
                {
                    label2.Text = "该文件没有书签。";

                }


            } else
            {
                label2.Text = "未输入PDF文件路径。";
            }
           

        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            textBox1.Text = path;
            label2.Text = "已选择：" + path;
        }


    }
}

