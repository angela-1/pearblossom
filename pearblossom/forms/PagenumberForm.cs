using iText.IO.Font.Constants;
using iText.Kernel.Font;
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
        private PagenumberStyle pageNumberStyle = PagenumberStyle.Normal;
        private PagenumberPos pageNumberPos = PagenumberPos.Center;
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

            pageNumberPos = ((RadioButton)sender).Name switch
            {
                "posCenter" => PagenumberPos.Center,
                "posCorner" => PagenumberPos.Corner,
                _ => PagenumberPos.Center,
            };
        }

        private PdfFont GetFont()
        {
            PdfFont numberFont;
            switch (pageNumberStyle)
            {
                case PagenumberStyle.Normal:
                    numberFont = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);
                    break;
                case PagenumberStyle.Collection:
                case PagenumberStyle.Total:
                    numberFont = PdfFontFactory.CreateFont(StandardFonts.COURIER);
                    break;
                default:
                    numberFont = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);
                    break;
            }
            return numberFont;
        }

        public void PageStyleRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (!((RadioButton)sender).Checked)
            {
                return;
            }

            pageNumberStyle = ((RadioButton)sender).Name switch
            {
                "normalStyle" => PagenumberStyle.Normal,
                "collectionStyle" => PagenumberStyle.Collection,
                "totalStyle" => PagenumberStyle.Total,
                "decorateStyle" => PagenumberStyle.Decorate,
                _ => PagenumberStyle.Normal,
            };
        }

        private IPagenumberStyle GetPagenumberStyle()
        {
            IPagenumberStyle pagenumberStyle = pageNumberStyle switch
            {
                PagenumberStyle.Normal => new NormalPagenumber(),
                PagenumberStyle.Collection => new CollectionPagenumber(),
                PagenumberStyle.Total => new TotalPagenumber(),
                PagenumberStyle.Decorate => new DecorateNumber(),
                _ => new NormalPagenumber()

            };
            return pagenumberStyle;
        }

        private IPagenumberPos GetPos()
        {
            IPagenumberPos pagenumberPos = pageNumberPos switch
            {
                PagenumberPos.Center => new CenterPos(),
                PagenumberPos.Corner => new CornerPos(),
                _ => new CenterPos()

            };
            return pagenumberPos;
        }
        private async void Button2_Click(object sender, EventArgs e)
        {

            if (parentForm.srcFile != "")
            {
                Hide();
                parentForm.ShowStatus("处理中...");
                parentForm.ShowProgress(true);
                IPagenumberPos pos = GetPos();
                IPagenumberStyle style = GetPagenumberStyle();
                PdfFont font = GetFont();
                PagenumberTask task = new PagenumberTask(parentForm.srcFile, style, pos, font);
                await task.Run();
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
