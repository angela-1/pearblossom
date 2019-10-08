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
    public partial class Form4 : Form
    {
        private bool withBookmark = false;
        private readonly string[] filePaths;

        private readonly Form1 parentForm;
        public Form4(Form1 form, string[] paths)
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
            parentForm.ShowStatus("处理中");
            Close();
            string target = await MergeTaskAsync();
            parentForm.ShowStatus("完成");
            parentForm.ShowContent(@"目标文件：
" + target);

            

        }

        private async Task<string> MergeTaskAsync()
        {
            return await MergeTask();
        }

        private Task<string> MergeTask()
        {
            var task = Task.Run(() =>
            {
                string target = null;
                if (Directory.Exists(filePaths[0])) // is folder
                {
                    target = MergeDocumentUtil.Run(filePaths[0], withBookmark);
                } else // is files 
                {
                    target = MergeDocumentUtil.Run(filePaths, withBookmark);
                }
                
                return target;
            });

            return task;
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
