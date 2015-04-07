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
            try
            {
                LogHelper.WriteLog("ServerName:" + Common.SERVER_NAME);
                this.btnOK.Enabled = false;
                string fileName = System.IO.Path.Combine(Common.ROOT_BIN_PATH, Common.Config_FileName);

                Migration migration = new Migration(fileName);

                migration.DoMigration();

                SendEmail();

                MessageBox.Show("Migration done", "Infomation");
                this.btnOK.Enabled = true ;
                Application.Exit();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
                MessageBox.Show("Migration failed as get error,please check the log", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SendEmail()
        {
            EmailEntity entity = new EmailEntity();
            entity.Body = Common.Mail_Body;
            entity.Subject = Common.Mail_Subject;
            entity.Email_Recipient = Common.GetEmailRecipient();
            entity.Email_Attachments = Common.Attachment_List;
            entity.Host = Common.Mail_Host;
            entity.Port = Convert.ToInt32(Common.Mail_Port);
            entity.TimeOut = Convert.ToInt32(Common.Mail_TimeOut);

            EmailHelper.Send(entity);
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
            sbDesc.AppendLine("2,copy PRD file to before folder.");
            sbDesc.AppendLine("3,Copy or replace local file to PRD.");
            sbDesc.AppendLine("4,Copy PRD file to after folder.");
            sbDesc.AppendLine("5,zip the before and afte folder send via email.");
            sbDesc.AppendLine("6,zip the logs send via email.");
            sbDesc.AppendLine("");
            sbDesc.AppendLine("After run this, please check the log.");
            return sbDesc.ToString();
        }

    }
}
