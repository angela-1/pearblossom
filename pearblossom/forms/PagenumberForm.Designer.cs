﻿namespace pearblossom
{
    partial class PagenumberForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.collectionStyle = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.totalStyle = new System.Windows.Forms.RadioButton();
            this.normalStyle = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.posCorner = new System.Windows.Forms.RadioButton();
            this.posCenter = new System.Windows.Forms.RadioButton();
            this.decorateStyle = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // collectionStyle
            // 
            this.collectionStyle.AutoSize = true;
            this.collectionStyle.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.collectionStyle.Location = new System.Drawing.Point(271, 35);
            this.collectionStyle.Name = "collectionStyle";
            this.collectionStyle.Size = new System.Drawing.Size(179, 24);
            this.collectionStyle.TabIndex = 1;
            this.collectionStyle.Text = "汇编（001,002,003）";
            this.collectionStyle.UseVisualStyleBackColor = true;
            this.collectionStyle.CheckedChanged += new System.EventHandler(this.PageStyleRadio_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.decorateStyle);
            this.groupBox1.Controls.Add(this.totalStyle);
            this.groupBox1.Controls.Add(this.normalStyle);
            this.groupBox1.Controls.Add(this.collectionStyle);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(547, 129);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "页码样式";
            // 
            // totalStyle
            // 
            this.totalStyle.AutoSize = true;
            this.totalStyle.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.totalStyle.Location = new System.Drawing.Point(30, 77);
            this.totalStyle.Name = "totalStyle";
            this.totalStyle.Size = new System.Drawing.Size(197, 24);
            this.totalStyle.TabIndex = 2;
            this.totalStyle.Text = "总数（1/20,2/20,3/20）";
            this.totalStyle.UseVisualStyleBackColor = true;
            this.totalStyle.CheckedChanged += new System.EventHandler(this.PageStyleRadio_CheckedChanged);
            // 
            // normalStyle
            // 
            this.normalStyle.AutoSize = true;
            this.normalStyle.Checked = true;
            this.normalStyle.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.normalStyle.Location = new System.Drawing.Point(30, 35);
            this.normalStyle.Name = "normalStyle";
            this.normalStyle.Size = new System.Drawing.Size(125, 24);
            this.normalStyle.TabIndex = 0;
            this.normalStyle.TabStop = true;
            this.normalStyle.Text = "普通（1,2,3）";
            this.normalStyle.UseVisualStyleBackColor = true;
            this.normalStyle.CheckedChanged += new System.EventHandler(this.PageStyleRadio_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(485, 277);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 32);
            this.button1.TabIndex = 2;
            this.button1.Text = "取消";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(404, 277);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 32);
            this.button2.TabIndex = 3;
            this.button2.Text = "好";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.posCorner);
            this.groupBox2.Controls.Add(this.posCenter);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(13, 148);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(547, 72);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "页码位置";
            // 
            // posCorner
            // 
            this.posCorner.AutoSize = true;
            this.posCorner.Location = new System.Drawing.Point(271, 36);
            this.posCorner.Name = "posCorner";
            this.posCorner.Size = new System.Drawing.Size(135, 24);
            this.posCorner.TabIndex = 1;
            this.posCorner.Text = "奇偶页左右角落";
            this.posCorner.UseVisualStyleBackColor = true;
            this.posCorner.CheckedChanged += new System.EventHandler(this.PagePosRadio_CheckedChanged);
            // 
            // posCenter
            // 
            this.posCenter.AutoSize = true;
            this.posCenter.Checked = true;
            this.posCenter.Location = new System.Drawing.Point(30, 36);
            this.posCenter.Name = "posCenter";
            this.posCenter.Size = new System.Drawing.Size(90, 24);
            this.posCenter.TabIndex = 0;
            this.posCenter.TabStop = true;
            this.posCenter.Text = "页脚居中";
            this.posCenter.UseVisualStyleBackColor = true;
            this.posCenter.CheckedChanged += new System.EventHandler(this.PagePosRadio_CheckedChanged);
            // 
            // decorateStyle
            // 
            this.decorateStyle.AutoSize = true;
            this.decorateStyle.Location = new System.Drawing.Point(271, 77);
            this.decorateStyle.Name = "decorateStyle";
            this.decorateStyle.Size = new System.Drawing.Size(253, 24);
            this.decorateStyle.TabIndex = 3;
            this.decorateStyle.TabStop = true;
            this.decorateStyle.Text = "装饰（— 1 —, — 2 —, — 3 —）";
            this.decorateStyle.UseVisualStyleBackColor = true;
            this.decorateStyle.CheckedChanged += new System.EventHandler(this.PageStyleRadio_CheckedChanged);
            // 
            // PagenumberForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 321);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Name = "PagenumberForm";
            this.Text = "Form3";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton collectionStyle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton normalStyle;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton totalStyle;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton posCorner;
        private System.Windows.Forms.RadioButton posCenter;
        private System.Windows.Forms.RadioButton decorateStyle;
    }
}