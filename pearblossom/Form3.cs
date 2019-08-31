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
    public partial class Form3 : Form
    {
        private PageNumberStyle pageNumberStyle = PageNumberStyle.Normal;
        private PageNumberPos pageNumberPos = PageNumberPos.Center;
        private Form1 parentForm;

        public Form3(Form1 form)
        {
            this.parentForm = form;
            InitializeComponent();
        }


        public void PagePosRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (!((RadioButton)sender).Checked)
            {
                return;
            }

            switch (((RadioButton)sender).Name)
            {
                case "posCenter":
                    pageNumberPos = PageNumberPos.Center;
                    break;
                case "posCorner":
                    pageNumberPos = PageNumberPos.Corner;
                    break;
                default:
                    pageNumberPos = PageNumberPos.Center;
                    break;
            }
        }


        public void PageStyleRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (!((RadioButton)sender).Checked)
            {
                return;
            }
            
            switch (((RadioButton)sender).Name)
            {
                case "normalStyle":
                    pageNumberStyle = PageNumberStyle.Normal;
                    break;
                case "collectionStyle":
                    pageNumberStyle = PageNumberStyle.Collection;
                    break;
                case "totalStyle":
                    pageNumberStyle = PageNumberStyle.Total;
                    break;
                default:
                    pageNumberStyle = PageNumberStyle.Normal;
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Console.WriteLine("style" + this.pageNumberStyle);
            if (parentForm.srcFile != "")
            {
                PageNumber pageNumber = new PageNumber(parentForm.srcFile, pageNumberStyle, pageNumberPos);
                pageNumber.AddPageNumber();

                parentForm.ShowStatus("添加页码成功");
                parentForm.ShowFiles();

            }
            else
            {
                parentForm.ShowStatus("请选择文件");
            }
            Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
