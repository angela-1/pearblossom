using pearblossom.pagenumber;
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
    public partial class PagenumberForm : Form
    {
        private PageNumberStyle pageNumberStyle = PageNumberStyle.Normal;
        private PageNumberPos pageNumberPos = PageNumberPos.Center;
        private readonly MainForm parentForm;

        public PagenumberForm(MainForm form)
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

        private async void Button2_Click(object sender, EventArgs e)
        {

            if (parentForm.srcFile != "")
            {
                Hide();
                parentForm.ShowStatus("处理中...");
                parentForm.ShowProgress(true);
                PagenumberDocument pagenumberDocument = new PagenumberDocument(parentForm.srcFile, pageNumberStyle, pageNumberPos);
                await pagenumberDocument.Run();
                parentForm.ShowStatus("完成");
                parentForm.ShowProgress(false);
                parentForm.ShowContent("结果", parentForm.AssembleFilesString());

            }
            else
            {
                parentForm.ShowStatus("请选择文件");
            }
            Close();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
