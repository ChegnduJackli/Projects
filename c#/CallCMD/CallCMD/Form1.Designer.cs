namespace CallCMD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDisableProxy = new System.Windows.Forms.Button();
            this.btnEnableProxy = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancelShutdown = new System.Windows.Forms.Button();
            this.btnRestartPC = new System.Windows.Forms.Button();
            this.btnShutdownPC = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labMessage = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listBoxURL = new System.Windows.Forms.ListBox();
            this.btnOpenURL = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chkListAllBrowsers = new System.Windows.Forms.CheckedListBox();
            this.chkAutoStart = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDisableProxy);
            this.groupBox1.Controls.Add(this.btnEnableProxy);
            this.groupBox1.Location = new System.Drawing.Point(21, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Proxy";
            // 
            // btnDisableProxy
            // 
            this.btnDisableProxy.Location = new System.Drawing.Point(119, 41);
            this.btnDisableProxy.Name = "btnDisableProxy";
            this.btnDisableProxy.Size = new System.Drawing.Size(75, 23);
            this.btnDisableProxy.TabIndex = 1;
            this.btnDisableProxy.Text = "Disable";
            this.btnDisableProxy.UseVisualStyleBackColor = true;
            this.btnDisableProxy.Click += new System.EventHandler(this.btnDisableProxy_Click);
            // 
            // btnEnableProxy
            // 
            this.btnEnableProxy.Location = new System.Drawing.Point(15, 41);
            this.btnEnableProxy.Name = "btnEnableProxy";
            this.btnEnableProxy.Size = new System.Drawing.Size(75, 23);
            this.btnEnableProxy.TabIndex = 0;
            this.btnEnableProxy.Text = "Enable";
            this.btnEnableProxy.UseVisualStyleBackColor = true;
            this.btnEnableProxy.Click += new System.EventHandler(this.btnEnableProxy_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCancelShutdown);
            this.groupBox2.Controls.Add(this.btnRestartPC);
            this.groupBox2.Controls.Add(this.btnShutdownPC);
            this.groupBox2.Location = new System.Drawing.Point(255, 26);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(262, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Shutdown";
            // 
            // btnCancelShutdown
            // 
            this.btnCancelShutdown.Location = new System.Drawing.Point(181, 41);
            this.btnCancelShutdown.Name = "btnCancelShutdown";
            this.btnCancelShutdown.Size = new System.Drawing.Size(75, 23);
            this.btnCancelShutdown.TabIndex = 2;
            this.btnCancelShutdown.Text = "Cancel";
            this.btnCancelShutdown.UseVisualStyleBackColor = true;
            this.btnCancelShutdown.Click += new System.EventHandler(this.btnCancelShutdown_Click);
            // 
            // btnRestartPC
            // 
            this.btnRestartPC.Location = new System.Drawing.Point(94, 41);
            this.btnRestartPC.Name = "btnRestartPC";
            this.btnRestartPC.Size = new System.Drawing.Size(75, 23);
            this.btnRestartPC.TabIndex = 1;
            this.btnRestartPC.Text = "Restart";
            this.btnRestartPC.UseVisualStyleBackColor = true;
            this.btnRestartPC.Click += new System.EventHandler(this.btnRestartPC_Click);
            // 
            // btnShutdownPC
            // 
            this.btnShutdownPC.Location = new System.Drawing.Point(6, 41);
            this.btnShutdownPC.Name = "btnShutdownPC";
            this.btnShutdownPC.Size = new System.Drawing.Size(75, 23);
            this.btnShutdownPC.TabIndex = 0;
            this.btnShutdownPC.Text = "Shutdown";
            this.btnShutdownPC.UseVisualStyleBackColor = true;
            this.btnShutdownPC.Click += new System.EventHandler(this.btnShutdownPC_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(168, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Message:";
            // 
            // labMessage
            // 
            this.labMessage.AutoSize = true;
            this.labMessage.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.labMessage.Location = new System.Drawing.Point(236, 9);
            this.labMessage.Name = "labMessage";
            this.labMessage.Size = new System.Drawing.Size(32, 13);
            this.labMessage.TabIndex = 3;
            this.labMessage.Text = "show";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listBoxURL);
            this.groupBox3.Location = new System.Drawing.Point(21, 155);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(403, 199);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "URL Link";
            // 
            // listBoxURL
            // 
            this.listBoxURL.FormattingEnabled = true;
            this.listBoxURL.HorizontalScrollbar = true;
            this.listBoxURL.Location = new System.Drawing.Point(7, 20);
            this.listBoxURL.Name = "listBoxURL";
            this.listBoxURL.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxURL.Size = new System.Drawing.Size(370, 173);
            this.listBoxURL.TabIndex = 0;
            // 
            // btnOpenURL
            // 
            this.btnOpenURL.Location = new System.Drawing.Point(430, 325);
            this.btnOpenURL.Name = "btnOpenURL";
            this.btnOpenURL.Size = new System.Drawing.Size(75, 23);
            this.btnOpenURL.TabIndex = 5;
            this.btnOpenURL.Text = "OpenURL";
            this.btnOpenURL.UseVisualStyleBackColor = true;
            this.btnOpenURL.Click += new System.EventHandler(this.btnOpenURL_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chkListAllBrowsers);
            this.groupBox5.Location = new System.Drawing.Point(430, 155);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(116, 164);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Browser";
            // 
            // chkListAllBrowsers
            // 
            this.chkListAllBrowsers.CausesValidation = false;
            this.chkListAllBrowsers.CheckOnClick = true;
            this.chkListAllBrowsers.FormattingEnabled = true;
            this.chkListAllBrowsers.HorizontalScrollbar = true;
            this.chkListAllBrowsers.Location = new System.Drawing.Point(0, 20);
            this.chkListAllBrowsers.Name = "chkListAllBrowsers";
            this.chkListAllBrowsers.Size = new System.Drawing.Size(116, 124);
            this.chkListAllBrowsers.TabIndex = 0;
            // 
            // chkAutoStart
            // 
            this.chkAutoStart.AutoSize = true;
            this.chkAutoStart.Location = new System.Drawing.Point(456, 9);
            this.chkAutoStart.Name = "chkAutoStart";
            this.chkAutoStart.Size = new System.Drawing.Size(73, 17);
            this.chkAutoStart.TabIndex = 6;
            this.chkAutoStart.Text = "Auto Start";
            this.chkAutoStart.UseVisualStyleBackColor = true;
            this.chkAutoStart.CheckedChanged += new System.EventHandler(this.chkAutoStart_CheckedChanged_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 379);
            this.Controls.Add(this.chkAutoStart);
            this.Controls.Add(this.btnOpenURL);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.labMessage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CMD Entrance";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDisableProxy;
        private System.Windows.Forms.Button btnEnableProxy;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnShutdownPC;
        private System.Windows.Forms.Button btnRestartPC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labMessage;
        private System.Windows.Forms.Button btnCancelShutdown;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox listBoxURL;
        private System.Windows.Forms.Button btnOpenURL;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckedListBox chkListAllBrowsers;
        private System.Windows.Forms.CheckBox chkAutoStart;
    }
}

