using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace EmailHelper
{
    public class EmailHelper
    {
        /// <summary>
        /// Mandatory parameters: Host,MailFrom,MailTo
        /// Optional  parameters: Email_Recipient,TimeOut,Subject,Body,Email_Attachments,Port,MailCCTo,MailBCCTo
        /// </summary>
        /// <param name="entity"></param>
        public static void Send(EmailEntity entity)
        {
            try
            {
                SmtpClient smtp = new SmtpClient();
                smtp.Host = entity.Host;
                smtp.Port = entity.Port;
                smtp.Timeout = entity.TimeOut;

                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();

                message.From = new MailAddress(entity.MailFrom, "", System.Text.Encoding.UTF8);
                message.Subject = entity.Subject;
                message.SubjectEncoding = System.Text.Encoding.UTF8;
                message.Body = entity.Body;

                foreach (var address in entity.MailTo.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    message.To.Add(address);
                }

                foreach (var address in entity.MailCCTo.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    message.CC.Add(address);
                }

                foreach (var address in entity.MailBCCTo.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    message.Bcc.Add(address);
                }

                if (entity.Email_Attachments != null && entity.Email_Attachments.Count > 0)
                {
                    System.Net.Mail.Attachment attachment;
                    foreach (var attch in entity.Email_Attachments)
                    {
                        if (attch != null)
                        {
                            attachment = new System.Net.Mail.Attachment(attch);
                            message.Attachments.Add(attachment);
                        }
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
    public class EmailEntity
    {
        /// <summary>
        /// this is email host, it's mondatory.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// this is email port, it's optional,default value:25.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// this is timeout, it's optional,default value:1200.
        /// </summary>
        public int TimeOut { get; set; }

        /// <summary>
        /// this is email from, it's mondatory.
        /// </summary>
        public string MailFrom { get; set; }

        /// <summary>
        ///Email send to, if have multiply ,then split by ;
        /// </summary>
        public string MailTo { get; set; }

        /// <summary>
        ///Email CC to, if have multiply ,then split by ";" ,it's optional
        /// </summary>
        public string MailCCTo { get; set; }

        /// <summary>
        ///Email BCC to, if have multiply ,then split by ";" ,it's optional
        /// </summary>
        public string MailBCCTo { get; set; }

        /// <summary>
        /// this is optional,default value is null.
        /// </summary>
        public List<string> Email_Attachments { get; set; }

        /// <summary>
        /// this is email subject,it's optional
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// this is email body, it's optional
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// default value, TimeOut:1200, Port:25,Subject:"",body:""
        /// MailCCTo:"", MailBCCTo:""
        /// </summary>
        public EmailEntity()
        {
            this.TimeOut = 1200;
            this.Email_Attachments = null;
            this.Port = 25;
            this.Subject = string.Empty;
            this.Body = string.Empty;
            this.MailCCTo = string.Empty;
            this.MailBCCTo = string.Empty;
        }

    }
}
