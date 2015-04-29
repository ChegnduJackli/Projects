using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Configuration;

namespace JobSample
{
    class Common
    {
        public static readonly string Mail_Host = ConfigurationManager.AppSettings["Host"];
        public static readonly string Mail_From = ConfigurationManager.AppSettings["MailFrom"];
        public static readonly string Mail_Port = ConfigurationManager.AppSettings["Port"];
        public static readonly string Mail_To = ConfigurationManager.AppSettings["MailTo"];
        public static readonly string Mail_CC_To = ConfigurationManager.AppSettings["MailCCTo"];
        public static readonly string Mail_BCC_To = ConfigurationManager.AppSettings["MailBCCTo"];
        public static readonly string Mail_TimeOut = ConfigurationManager.AppSettings["TimeOut"];
        public static readonly string Mail_Subject = ConfigurationManager.AppSettings["MailSubject"];
        public static readonly string Mail_To_ShowName = ConfigurationManager.AppSettings["MailToShowName"];

      
        //do some clean up when first time to run 
        static Common()
        {

        }

        public static List<string> GetAttachment()
        {
            List<string> attachments = new List<string>();
            return attachments;
        }
    }
}
