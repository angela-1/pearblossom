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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.getTocToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.docxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pageNumberToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.tiplabel = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.githubToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(36, 36);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripButton,
            this.getTocToolStripDropDownButton,
            this.pageNumberToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.MinimumSize = new System.Drawing.Size(0, 48);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(582, 48);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(92, 45);
            this.openToolStripButton.Text = "打开";
            this.openToolStripButton.Click += new System.EventHandler(this.openToolStripButton_Click);
            // 
            // getTocToolStripDropDownButton
            // 
            this.getTocToolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.docxToolStripMenuItem,
            this.txtToolStripMenuItem});
            this.getTocToolStripDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("getTocToolStripDropDownButton.Image")));
            this.getTocToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.getTocToolStripDropDownButton.Name = "getTocToolStripDropDownButton";
            this.getTocToolStripDropDownButton.Size = new System.Drawing.Size(119, 45);
            this.getTocToolStripDropDownButton.Text = "提取目录";
            // 
            // docxToolStripMenuItem
            // 
            this.docxToolStripMenuItem.Name = "docxToolStripMenuItem";
            this.docxToolStripMenuItem.Size = new System.Drawing.Size(131, 26);
            this.docxToolStripMenuItem.Text = "*.docx";
            this.docxToolStripMenuItem.Click += new System.EventHandler(this.docxToolStripMenuItem_Click);
            // 
            // txtToolStripMenuItem
            // 
            this.txtToolStripMenuItem.Name = "txtToolStripMenuItem";
            this.txtToolStripMenuItem.Size = new System.Drawing.Size(131, 26);
            this.txtToolStripMenuItem.Text = "*.txt";
            this.txtToolStripMenuItem.Click += new System.EventHandler(this.txtToolStripMenuItem_Click);
            // 
            // pageNumberToolStripButton
            // 
            this.pageNumberToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pageNumberToolStripButton.Image")));
            this.pageNumberToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pageNumberToolStripButton.Name = "pageNumberToolStripButton";
            this.pageNumberToolStripButton.Size = new System.Drawing.Size(109, 45);
            this.pageNumberToolStripButton.Text = "添加页码";
            this.pageNumberToolStripButton.Click += new System.EventHandler(this.pageNumberToolStripButton_Click);
            // 
            // tiplabel
            // 
            this.tiplabel.AutoSize = true;
            this.tiplabel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tiplabel.Location = new System.Drawing.Point(13, 52);
            this.tiplabel.Name = "tiplabel";
            this.tiplabel.Size = new System.Drawing.Size(92, 27);
            this.tiplabel.TabIndex = 3;
            this.tiplabel.Text = "提示信息";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel2,
            this.githubToolStripStatusLabel,
            this.toolStripStatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 150);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(582, 25);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 19);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(138, 20);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(138, 20);
            this.toolStripStatusLabel4.Spring = true;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(138, 20);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // githubToolStripStatusLabel
            // 
            this.githubToolStripStatusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.githubToolStripStatusLabel.Image = global::pearblossom.Properties.Resources.mark_github;
            this.githubToolStripStatusLabel.IsLink = true;
            this.githubToolStripStatusLabel.Name = "githubToolStripStatusLabel";
            this.githubToolStripStatusLabel.Size = new System.Drawing.Size(20, 20);
            this.githubToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.githubToolStripStatusLabel.Click += new System.EventHandler(this.githubToolStripStatusLabel_Click);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Image = global::pearblossom.Properties.Resources.help;
            this.toolStripStatusLabel3.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(20, 20);
            this.toolStripStatusLabel3.Click += new System.EventHandler(this.toolStripStatusLabel3_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(582, 175);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tiplabel);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 220);
            this.Name = "Form1";
            this.Text = "梨花-材料汇编工具";
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
        private System.Windows.Forms.Label tiplabel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel githubToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
    }
}

