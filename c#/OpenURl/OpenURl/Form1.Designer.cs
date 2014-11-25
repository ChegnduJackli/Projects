namespace OpenURl
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtbDesc = new System.Windows.Forms.RichTextBox();
            this.listboxUrl = new System.Windows.Forms.ListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chkListAllBrowsers = new System.Windows.Forms.CheckedListBox();
            this.btnOpenURL = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtbDesc);
            this.groupBox1.Controls.Add(this.listboxUrl);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(337, 436);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "URL";
            // 
            // rtbDesc
            // 
            this.rtbDesc.Location = new System.Drawing.Point(6, 381);
            this.rtbDesc.Name = "rtbDesc";
            this.rtbDesc.Size = new System.Drawing.Size(331, 49);
            this.rtbDesc.TabIndex = 1;
            this.rtbDesc.Text = "";
            // 
            // listboxUrl
            // 
            this.listboxUrl.FormattingEnabled = true;
            this.listboxUrl.HorizontalScrollbar = true;
            this.listboxUrl.Location = new System.Drawing.Point(7, 20);
            this.listboxUrl.Name = "listboxUrl";
            this.listboxUrl.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listboxUrl.Size = new System.Drawing.Size(324, 342);
            this.listboxUrl.TabIndex = 0;
            this.listboxUrl.SelectedIndexChanged += new System.EventHandler(this.listboxUrl_SelectedIndexChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chkListAllBrowsers);
            this.groupBox5.Location = new System.Drawing.Point(355, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(116, 164);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Browser";
            // 
            // chkListAllBrowsers
            // 
            this.chkListAllBrowsers.CausesValidation = false;
            this.chkListAllBrowsers.CheckOnClick = true;
            this.chkListAllBrowsers.FormattingEnabled = true;
            this.chkListAllBrowsers.HorizontalScrollbar = true;
            this.chkListAllBrowsers.Location = new System.Drawing.Point(0, 19);
            this.chkListAllBrowsers.Name = "chkListAllBrowsers";
            this.chkListAllBrowsers.Size = new System.Drawing.Size(116, 124);
            this.chkListAllBrowsers.TabIndex = 0;
            // 
            // btnOpenURL
            // 
            this.btnOpenURL.Location = new System.Drawing.Point(373, 419);
            this.btnOpenURL.Name = "btnOpenURL";
            this.btnOpenURL.Size = new System.Drawing.Size(75, 23);
            this.btnOpenURL.TabIndex = 6;
            this.btnOpenURL.Text = "OpenURL";
            this.btnOpenURL.UseVisualStyleBackColor = true;
            this.btnOpenURL.Click += new System.EventHandler(this.btnOpenURL_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 459);
            this.Controls.Add(this.btnOpenURL);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "URL List";
            this.groupBox1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listboxUrl;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckedListBox chkListAllBrowsers;
        private System.Windows.Forms.Button btnOpenURL;
        private System.Windows.Forms.RichTextBox rtbDesc;
    }
}

