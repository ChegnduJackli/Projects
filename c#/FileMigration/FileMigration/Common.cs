using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;

namespace FileMigration
{
    public static class Common
    {
        public static readonly string SERVER_NAME = ConfigurationManager.AppSettings["ServerName"];
        public static readonly string ROOT_BIN_PATH = AppDomain.CurrentDomain.BaseDirectory;

        public static readonly string Indicator_Upload_Flag = "@UPLOAD";
        public static readonly string Indicator_Download_Flag = "@DOWNLOAD";

        public static readonly string Mail_Host = ConfigurationManager.AppSettings["Host"];
        public static readonly string Mail_From = ConfigurationManager.AppSettings["MailFrom"];
        public static readonly string Mail_Port = ConfigurationManager.AppSettings["Port"];
        public static readonly string Mail_To = ConfigurationManager.AppSettings["MailTo"];
        public static readonly string Mail_TimeOut = ConfigurationManager.AppSettings["TimeOut"];
        public static readonly string Mail_Subject = ConfigurationManager.AppSettings["Subject"];
        public static readonly string Mail_Body = ConfigurationManager.AppSettings["Body"];

        public static readonly string Config_FileName = ConfigurationManager.AppSettings["ConfigFile"];

        public static readonly string Upload_Before_Folder = Path.Combine(ROOT_BIN_PATH, @"Upload\Before\");
        public static readonly string Upload_After_Folder = Path.Combine(ROOT_BIN_PATH, @"Upload\After\");
        public static readonly string Upload_Source_Folder = Path.Combine(ROOT_BIN_PATH, @"Upload\Source\");
        public static readonly string Download_Folder = Path.Combine(ROOT_BIN_PATH, @"Download");
        public static readonly string Log_File = Path.Combine(ROOT_BIN_PATH,@"Logs", DateTime.Now.ToString("yyyyMMdd") + ".log");

        public static readonly string Zip_Upload_Before_FolderName = Path.Combine(ROOT_BIN_PATH, @"Upload\Before.zip");
        public static readonly string Zip_Upload_After_FolderName = Path.Combine(ROOT_BIN_PATH, @"Upload\After.zip");
        public static readonly string Zip_Download_FolderName = Path.Combine(ROOT_BIN_PATH, @"Download.zip");
        public static readonly string Zip_Logs_FolderName = Path.Combine(ROOT_BIN_PATH,@"Logs.zip");
        public static readonly string Zip_Password = @"password";

        public static StringBuilder Migrate_Description = new StringBuilder();
        public static List<string> Attachment_List = new List<string>();

        //clear the folder and files
        static Common()
        {
           EmptyFolder(new System.IO.DirectoryInfo(Upload_Before_Folder));

           EmptyFolder(new System.IO.DirectoryInfo(Upload_After_Folder));

           EmptyFolder(new System.IO.DirectoryInfo(Download_Folder));

            FileHelper.DeleteFile(Zip_Upload_Before_FolderName);
            FileHelper.DeleteFile(Zip_Upload_After_FolderName);
            FileHelper.DeleteFile(Zip_Download_FolderName);
            FileHelper.DeleteFile(Zip_Logs_FolderName);
            
        }

        /// <summary>
        /// delete the files in folder,include sub directory.
        /// </summary>
        /// <param name="directory"></param>
        public static void EmptyFolder(this System.IO.DirectoryInfo directory)
        {
            foreach (System.IO.FileInfo file in directory.GetFiles()) file.Delete();
            foreach (System.IO.DirectoryInfo subDirectory in directory.GetDirectories()) subDirectory.Delete(true);
        }

        public static List<string> GetEmailRecipient()
        {
            string[] stringSeparators = new string[] { ";" };

            List<string> emailRecipient = new List<string>();
            string email = string.Empty;

            try
            {
                email = Common.Mail_To;
                string[] emailArray = email.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                foreach (string e in emailArray)
                {
                    emailRecipient.Add(e);
                }
                return emailRecipient;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
