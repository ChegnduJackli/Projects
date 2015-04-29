using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JobSample
{
    class SendEmail
    {
        /// <summary>
        /// send email, the email other parameters from common class
        /// </summary>
        /// <param name="body"></param>
        public static void Send(string body)
        {
            try
            {
                EmailHelper.EmailEntity entity = new EmailHelper.EmailEntity();

                entity.MailTo = Common.Mail_To;

                entity.MailFrom = Common.Mail_From;

                entity.Host = Common.Mail_Host;

                if (Common.Mail_Port != null && Common.Mail_Port.Length > 0)
                {
                    entity.Port = Convert.ToInt32(Common.Mail_Port);
                }

                if (Common.Mail_TimeOut != null && Common.Mail_TimeOut.Length > 0)
                {
                    entity.TimeOut = Convert.ToInt32(Common.Mail_TimeOut);
                }

                if (Common.Mail_Subject != null && Common.Mail_Subject.Length > 0)
                {
                    entity.Subject = Common.Mail_Subject;
                }

                if (Common.Mail_CC_To != null && Common.Mail_CC_To.Length > 0)
                {
                    entity.MailCCTo = Common.Mail_CC_To;
                }

                if (Common.Mail_BCC_To != null && Common.Mail_BCC_To.Length > 0)
                {
                    entity.MailBCCTo = Common.Mail_BCC_To;
                }

                if (Common.GetAttachment() != null)
                {
                    entity.Email_Attachments = Common.GetAttachment();
                }

                entity.Body = body;

                EmailHelper.EmailHelper.Send(entity);
            }
            catch (Exception ex)
            {
                Log.LogHelper.WriteLog(ex);
            }
        }
    }
}
