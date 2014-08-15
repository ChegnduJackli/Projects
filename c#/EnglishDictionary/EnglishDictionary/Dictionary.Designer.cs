namespace EnglishDictionary
{
    partial class Dictionary
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtWords = new System.Windows.Forms.TextBox();
            this.rtbContent = new System.Windows.Forms.RichTextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.背单词ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.文章ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.词库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.背单词ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.文章库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(321, 46);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtWords
            // 
            this.txtWords.Location = new System.Drawing.Point(39, 48);
            this.txtWords.Name = "txtWords";
            this.txtWords.Size = new System.Drawing.Size(276, 20);
            this.txtWords.TabIndex = 1;
            // 
            // rtbContent
            // 
            this.rtbContent.Location = new System.Drawing.Point(37, 105);
            this.rtbContent.Name = "rtbContent";
            this.rtbContent.Size = new System.Drawing.Size(438, 283);
            this.rtbContent.TabIndex = 2;
            this.rtbContent.Text = "";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(402, 46);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.背单词ToolStripMenuItem,
            this.文章ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(535, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 背单词ToolStripMenuItem
            // 
            this.背单词ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.词库ToolStripMenuItem,
            this.背单词ToolStripMenuItem1});
            this.背单词ToolStripMenuItem.Name = "背单词ToolStripMenuItem";
            this.背单词ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.背单词ToolStripMenuItem.Text = "词典";
            // 
            // 文章ToolStripMenuItem
            // 
            this.文章ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文章库ToolStripMenuItem});
            this.文章ToolStripMenuItem.Name = "文章ToolStripMenuItem";
            this.文章ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.文章ToolStripMenuItem.Text = "文章";
            // 
            // 词库ToolStripMenuItem
            // 
            this.词库ToolStripMenuItem.Name = "词库ToolStripMenuItem";
            this.词库ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.词库ToolStripMenuItem.Text = "词库";
            this.词库ToolStripMenuItem.Click += new System.EventHandler(this.词库ToolStripMenuItem_Click);
            // 
            // 背单词ToolStripMenuItem1
            // 
            this.背单词ToolStripMenuItem1.Name = "背单词ToolStripMenuItem1";
            this.背单词ToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.背单词ToolStripMenuItem1.Text = "背单词";
            this.背单词ToolStripMenuItem1.Click += new System.EventHandler(this.背单词ToolStripMenuItem1_Click);
            // 
            // 文章库ToolStripMenuItem
            // 
            this.文章库ToolStripMenuItem.Name = "文章库ToolStripMenuItem";
            this.文章库ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.文章库ToolStripMenuItem.Text = "文章库";
            this.文章库ToolStripMenuItem.Click += new System.EventHandler(this.文章库ToolStripMenuItem_Click);
            // 
            // Dictionary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 400);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.rtbContent);
            this.Controls.Add(this.txtWords);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Dictionary";
            this.ShowIcon = false;
            this.Text = "Dictionary";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtWords;
        private System.Windows.Forms.RichTextBox rtbContent;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 背单词ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 文章ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 词库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 背单词ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 文章库ToolStripMenuItem;
    }
}

