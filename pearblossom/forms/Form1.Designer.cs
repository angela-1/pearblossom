namespace pearblossom
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.mergeStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toDocxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toPdfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toTxtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getTocToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.docxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xlsxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pageNumberToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.githubToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(36, 36);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripButton,
            this.mergeStripButton,
            this.toolStripDropDownButton1,
            this.getTocToolStripDropDownButton,
            this.pageNumberToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.MinimumSize = new System.Drawing.Size(0, 48);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(730, 48);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(79, 45);
            this.openToolStripButton.Text = "打开";
            this.openToolStripButton.ToolTipText = "选择文件或文件夹，拖放到窗口也可选择";
            this.openToolStripButton.Click += new System.EventHandler(this.OpenToolStripButton_Click);
            // 
            // mergeStripButton
            // 
            this.mergeStripButton.Image = global::pearblossom.Properties.Resources.merge;
            this.mergeStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mergeStripButton.Name = "mergeStripButton";
            this.mergeStripButton.Size = new System.Drawing.Size(109, 45);
            this.mergeStripButton.Text = "合并文件";
            this.mergeStripButton.ToolTipText = "合并一个文件夹下的文件";
            this.mergeStripButton.Click += new System.EventHandler(this.MergeStripButton_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toDocxToolStripMenuItem,
            this.toPdfToolStripMenuItem,
            this.toTxtToolStripMenuItem});
            this.toolStripDropDownButton1.Image = global::pearblossom.Properties.Resources.transform;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(119, 45);
            this.toolStripDropDownButton1.Tag = "";
            this.toolStripDropDownButton1.Text = "转换格式";
            // 
            // toDocxToolStripMenuItem
            // 
            this.toDocxToolStripMenuItem.Name = "toDocxToolStripMenuItem";
            this.toDocxToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.toDocxToolStripMenuItem.Text = ".docx";
            this.toDocxToolStripMenuItem.Click += new System.EventHandler(this.ToDocxToolStripMenuItem_Click);
            // 
            // toPdfToolStripMenuItem
            // 
            this.toPdfToolStripMenuItem.Name = "toPdfToolStripMenuItem";
            this.toPdfToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.toPdfToolStripMenuItem.Text = ".pdf";
            this.toPdfToolStripMenuItem.Click += new System.EventHandler(this.ToPdfToolStripMenuItem_Click);
            // 
            // toTxtToolStripMenuItem
            // 
            this.toTxtToolStripMenuItem.Name = "toTxtToolStripMenuItem";
            this.toTxtToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.toTxtToolStripMenuItem.Text = ".txt";
            this.toTxtToolStripMenuItem.Click += new System.EventHandler(this.ToTxtToolStripMenuItem_Click);
            // 
            // getTocToolStripDropDownButton
            // 
            this.getTocToolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.docxToolStripMenuItem,
            this.txtToolStripMenuItem,
            this.xlsxToolStripMenuItem});
            this.getTocToolStripDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("getTocToolStripDropDownButton.Image")));
            this.getTocToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.getTocToolStripDropDownButton.Name = "getTocToolStripDropDownButton";
            this.getTocToolStripDropDownButton.Size = new System.Drawing.Size(119, 45);
            this.getTocToolStripDropDownButton.Text = "提取目录";
            // 
            // docxToolStripMenuItem
            // 
            this.docxToolStripMenuItem.Name = "docxToolStripMenuItem";
            this.docxToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.docxToolStripMenuItem.Text = "*.docx";
            this.docxToolStripMenuItem.Click += new System.EventHandler(this.DocxToolStripMenuItem_Click);
            // 
            // txtToolStripMenuItem
            // 
            this.txtToolStripMenuItem.Name = "txtToolStripMenuItem";
            this.txtToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.txtToolStripMenuItem.Text = "*.txt";
            this.txtToolStripMenuItem.Click += new System.EventHandler(this.TxtToolStripMenuItem_Click);
            // 
            // xlsxToolStripMenuItem
            // 
            this.xlsxToolStripMenuItem.Name = "xlsxToolStripMenuItem";
            this.xlsxToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.xlsxToolStripMenuItem.Text = "*.xlsx";
            this.xlsxToolStripMenuItem.Click += new System.EventHandler(this.XlsxToolStripMenuItem_Click);
            // 
            // pageNumberToolStripButton
            // 
            this.pageNumberToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pageNumberToolStripButton.Image")));
            this.pageNumberToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pageNumberToolStripButton.Name = "pageNumberToolStripButton";
            this.pageNumberToolStripButton.Size = new System.Drawing.Size(109, 45);
            this.pageNumberToolStripButton.Text = "添加页码";
            this.pageNumberToolStripButton.Click += new System.EventHandler(this.PageNumberToolStripButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel4,
            this.githubToolStripStatusLabel,
            this.toolStripStatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 242);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(730, 26);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(332, 20);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(332, 20);
            this.toolStripStatusLabel4.Spring = true;
            // 
            // githubToolStripStatusLabel
            // 
            this.githubToolStripStatusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.githubToolStripStatusLabel.Image = global::pearblossom.Properties.Resources.github;
            this.githubToolStripStatusLabel.IsLink = true;
            this.githubToolStripStatusLabel.Name = "githubToolStripStatusLabel";
            this.githubToolStripStatusLabel.Size = new System.Drawing.Size(20, 20);
            this.githubToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.githubToolStripStatusLabel.ToolTipText = "打开项目GitHub页面";
            this.githubToolStripStatusLabel.Click += new System.EventHandler(this.GithubToolStripStatusLabel_Click);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Image = global::pearblossom.Properties.Resources.help;
            this.toolStripStatusLabel3.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(20, 21);
            this.toolStripStatusLabel3.ToolTipText = "查看使用手册";
            this.toolStripStatusLabel3.Click += new System.EventHandler(this.ToolStripStatusLabel3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(12, 51);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(706, 176);
            this.textBox1.TabIndex = 6;
            this.textBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(730, 268);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 220);
            this.Name = "Form1";
            this.Text = "梨花-文档处理工具集";
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripDropDownButton getTocToolStripDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem docxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem txtToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton pageNumberToolStripButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel githubToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripButton mergeStripButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem toDocxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toPdfToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toTxtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xlsxToolStripMenuItem;
    }
}

