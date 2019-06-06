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
        private Form1 parentForm;

        public Form3(Form1 form)
        {
            this.parentForm = form;
            InitializeComponent();
        }


        public void AllRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (!((RadioButton)sender).Checked)
            {
                return;
            }
            String sText = String.Empty;
            
            switch (((RadioButton)sender).Name)
            {
                case "normalStyle":
                    pageNumberStyle = PageNumberStyle.Normal;
                    break;
                case "collectionStyle":
                    pageNumberStyle = PageNumberStyle.Collection;
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
                PageNumber pageNumber = new PageNumber(parentForm.srcFile, pageNumberStyle);
                String dst_file = pageNumber.AddPageNumber();

                parentForm.showStatus("添加页码成功");
                parentForm.showFiles();

            }
            else
            {
                parentForm.showStatus("请选择文件");
            }
            Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
