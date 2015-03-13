using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileMigration
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.rtbDesc.Text = GetDesc();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure to migrate?", "Infomation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    //do something
                    FileMigration();

                    LogHelper.WriteLog(Common.Migrate_Description.ToString());

                    MessageBox.Show("Migration done", "Infomation");
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog(ex);
                    MessageBox.Show("Migration failed as get error,please check the log", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void FileMigration()
        {
            Common common = new Common();

            IMigration migration = common.GetInstance();

            migration.DoMigration();
        }

        public string GetDesc()
        {
            StringBuilder sbDesc = new StringBuilder();
            sbDesc.AppendLine("Before click the button, please confirm all migrated files is in right place.");
            sbDesc.AppendLine("");
            sbDesc.AppendLine("Server Name :" + Common.SERVER_NAME);
            sbDesc.AppendLine("");
            sbDesc.AppendLine("The applicaition will do the following things;");
            sbDesc.AppendLine("1,Back up PRD file to PRD backup folder.");
            sbDesc.AppendLine("2,Copy or replace local file to PRD.");
            sbDesc.AppendLine("");
            sbDesc.AppendLine("After run this, please check the log.");
            return sbDesc.ToString();
        }

    }
}
