namespace SQLTableBackup
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
            this.listSourceTable = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDBName = new System.Windows.Forms.Label();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.listTargetTable = new System.Windows.Forms.ListBox();
            this.btnToTarget = new System.Windows.Forms.Button();
            this.btnRemoveTarget = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.btnAddAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listSourceTable
            // 
            this.listSourceTable.FormattingEnabled = true;
            this.listSourceTable.HorizontalScrollbar = true;
            this.listSourceTable.Location = new System.Drawing.Point(24, 75);
            this.listSourceTable.Name = "listSourceTable";
            this.listSourceTable.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listSourceTable.Size = new System.Drawing.Size(174, 212);
            this.listSourceTable.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "All table list:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Database:";
            // 
            // lblDBName
            // 
            this.lblDBName.AutoSize = true;
            this.lblDBName.Location = new System.Drawing.Point(87, 13);
            this.lblDBName.Name = "lblDBName";
            this.lblDBName.Size = new System.Drawing.Size(52, 13);
            this.lblDBName.TabIndex = 3;
            this.lblDBName.Text = "TaskTest";
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(191, 320);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(75, 23);
            this.btnBackup.TabIndex = 4;
            this.btnBackup.Text = "Backup";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(308, 320);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(75, 23);
            this.btnRestore.TabIndex = 5;
            this.btnRestore.Text = "Restore";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // listTargetTable
            // 
            this.listTargetTable.FormattingEnabled = true;
            this.listTargetTable.HorizontalScrollbar = true;
            this.listTargetTable.Location = new System.Drawing.Point(308, 75);
            this.listTargetTable.Name = "listTargetTable";
            this.listTargetTable.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listTargetTable.Size = new System.Drawing.Size(174, 212);
            this.listTargetTable.TabIndex = 6;
            // 
            // btnToTarget
            // 
            this.btnToTarget.Location = new System.Drawing.Point(215, 137);
            this.btnToTarget.Name = "btnToTarget";
            this.btnToTarget.Size = new System.Drawing.Size(75, 23);
            this.btnToTarget.TabIndex = 7;
            this.btnToTarget.Text = "Add";
            this.btnToTarget.UseVisualStyleBackColor = true;
            this.btnToTarget.Click += new System.EventHandler(this.btnToTarget_Click);
            // 
            // btnRemoveTarget
            // 
            this.btnRemoveTarget.Location = new System.Drawing.Point(215, 197);
            this.btnRemoveTarget.Name = "btnRemoveTarget";
            this.btnRemoveTarget.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveTarget.TabIndex = 8;
            this.btnRemoveTarget.Text = "Remove";
            this.btnRemoveTarget.UseVisualStyleBackColor = true;
            this.btnRemoveTarget.Click += new System.EventHandler(this.btnRemoveTarget_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(305, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Operation table list:";
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Location = new System.Drawing.Point(215, 249);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveAll.TabIndex = 10;
            this.btnRemoveAll.Text = "Clear";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // btnAddAll
            // 
            this.btnAddAll.Location = new System.Drawing.Point(215, 74);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(75, 23);
            this.btnAddAll.TabIndex = 11;
            this.btnAddAll.Text = "Add All";
            this.btnAddAll.UseVisualStyleBackColor = true;
            this.btnAddAll.Click += new System.EventHandler(this.btnAddAll_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 370);
            this.Controls.Add(this.btnAddAll);
            this.Controls.Add(this.btnRemoveAll);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnRemoveTarget);
            this.Controls.Add(this.btnToTarget);
            this.Controls.Add(this.listTargetTable);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.lblDBName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listSourceTable);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Table Management";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listSourceTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDBName;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.ListBox listTargetTable;
        private System.Windows.Forms.Button btnToTarget;
        private System.Windows.Forms.Button btnRemoveTarget;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.Button btnAddAll;
    }
}

