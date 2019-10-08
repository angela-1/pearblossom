using pearblossom.merge;
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
    public partial class KeepBookmarkForm : Form
    {
        private bool withBookmark = false;
        private readonly string[] filePaths;

        private readonly MainForm parentForm;
        public KeepBookmarkForm(MainForm form, string[] paths)
        {
            parentForm = form;
            filePaths = paths;
            InitializeComponent();
        }
        private void WithBookmarkCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            withBookmark = ((CheckBox)sender).Checked;
        }

        private async void OkButton_Click(object sender, EventArgs e)
        {
            Hide();
            parentForm.ShowStatus("处理中...");
            MergedDocument mergedDocument = new MergedDocument(withBookmark, filePaths);
            string target = await mergedDocument.Run();
            parentForm.ShowStatus("完成");
            parentForm.ShowContent(@"目标文件：
" + target);
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void WithBookmarkCheckBox_MouseHover(object sender, EventArgs e)
        {
            //toolTip1.ToolTipTitle = "保留书签";
            toolTip1.UseFading = true;
            toolTip1.Show(@"若勾选，则合并各 pdf 文件书签
若不勾选，则以文件夹名为书签
", withBookmarkCheckBox);
        }
    }
}
