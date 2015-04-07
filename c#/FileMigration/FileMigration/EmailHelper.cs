using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace FileMigration
{
    class EmailHelper
    {
        public static void Send(EmailEntity entity)
        {
            try
            {
                SmtpClient smtp = new SmtpClient();
                smtp.Host = entity.Host;
                smtp.Port = entity.Port;
                smtp.Timeout = entity.TimeOut;

                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
                foreach (string email in entity.Email_Recipient)
                {
                    message.To.Add(email);
                }
                message.From = new MailAddress(Common.Mail_From, "", System.Text.Encoding.UTF8);
                message.Subject = entity.Subject;
                message.SubjectEncoding = System.Text.Encoding.UTF8;
                message.Body = entity.Body;

                System.Net.Mail.Attachment attachment;
                foreach (var attch in entity.Email_Attachments)
                {
                    if (attch != null)
                    {
                        attachment = new System.Net.Mail.Attachment(attch);
                        message.Attachments.Add(attachment);
                    }
                }
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.IsBodyHtml = true;
                message.Priority = MailPriority.Normal;

                smtp.Send(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    class EmailEntity
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public int TimeOut { get; set; }
        public List<string> Email_Recipient { get; set; }
        public List<string> Email_Attachments { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

    }
}
