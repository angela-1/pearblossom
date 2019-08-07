﻿using System;
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
    public partial class Form4 : Form
    {
        private Boolean withBookmark = false;
        private readonly string folderPath;

        private readonly Form1 parentForm;
        public Form4(Form1 form, string path)
        {
            parentForm = form;
            folderPath = path;
            InitializeComponent();
        }
        private void WithBookmarkCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            withBookmark = ((CheckBox)sender).Checked;
        }

        private async void OkButton_Click(object sender, EventArgs e)
        {
            Hide();
            parentForm.ShowStatus("处理中");

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
                string target = MergeDocumentUtil.Run(folderPath, withBookmark);
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
