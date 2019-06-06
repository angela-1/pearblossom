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
    public partial class Form4 : Form
    {
        private Boolean withBookmark = false;
        private String folderPath;

        private Form1 parentForm;
        public Form4(Form1 form, String folderPath)
        {
            this.parentForm = form;
            this.folderPath = folderPath;
            InitializeComponent();
        }

        private void WithBookmarkCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.withBookmark = ((CheckBox)sender).Checked;
        }

        private async void OkButton_Click(object sender, EventArgs e)
        {
            Hide();
            this.parentForm.showStatus("处理中");

            String target = await mergeTaskAsync();
            this.parentForm.showStatus("完成");
            this.parentForm.showContent(@"目标文件：
" + target);
        }

        private async Task<String> mergeTaskAsync()
        {
            return await mergeTask();
        }

        private Task<String> mergeTask()
        {
            var task = Task.Run(() =>
            {
                String target = MergeDocumentUtil.run(this.folderPath, this.withBookmark);
                return target;
            });

            return task;
        }
    }
}
