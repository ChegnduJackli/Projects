using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;

namespace FileMigration
{
    class Common
    {
        public static readonly string SERVER_NAME = ConfigurationManager.AppSettings["ServerName"];

        public static readonly string Local_Path_AGDAPP01P = ConfigurationManager.AppSettings["AGDAPP01P_Local_Path"];
        public static readonly string Local_Path_AGDAPP02P = ConfigurationManager.AppSettings["AGDAPP02P_Local_Path"];
        public static readonly string Local_Path_AGDAPP03P = ConfigurationManager.AppSettings["AGDAPP03P_Local_Path"];
        public static readonly string Local_Path_AGDAPP04P = ConfigurationManager.AppSettings["AGDAPP04P_Local_Path"];

        public static readonly string Server_Name_AGDAPP01P = "AGDAPP01P";
        public static readonly string Server_Name_AGDAPP02P = "AGDAPP02P";
        public static readonly string Server_Name_AGDAPP03P= "AGDAPP03P";
        public static readonly string Server_Name_AGDAPP04P = "AGDAPP04P";

        public static readonly string BackUp_Folder_Name = "backup";

        public static StringBuilder Migrate_Description = new StringBuilder();

        public IMigration GetInstance()
        {
            IMigration migration = null;

            Common.Migrate_Description.AppendLine("Server Name :" + Common.SERVER_NAME);

            if (Common.SERVER_NAME == Common.Server_Name_AGDAPP01P)
            {
                migration = new AGDAPP01PCLS();
            }
            else if (Common.SERVER_NAME == Common.Server_Name_AGDAPP02P)
            {
                migration = new AGDAPP02PCLS();
            }
            else if (Common.SERVER_NAME == Common.Server_Name_AGDAPP03P)
            {
                migration = new AGDAPP03PCLS();
            }
            else if (Common.SERVER_NAME == Common.Server_Name_AGDAPP04P)
            {
                migration = new AGDAPP04PCLS();
            }
            return migration;
        }

        public string GetDateFormat()
        {
            return DateTime.Now.ToString("ddMMyyyy");
        }

        public void DoFileMigration(string local_FileName, string PRD_FileName, string local_Path)
        {
            try
            {
                //get PRD foder name
                string PRD_Dir = System.IO.Path.GetDirectoryName(PRD_FileName);

                //to genereate PRD backup folder
                string PRD_BackUp_Path = System.IO.Path.Combine(PRD_Dir, Common.BackUp_Folder_Name);

                //get the filename
                string PRD_Properties_File = System.IO.Path.GetFileName(PRD_FileName);

                //to back up PRD file to backup folder
                BackUp(PRD_BackUp_Path, PRD_Properties_File, PRD_FileName);

                //get local file name
                string Local_File_FullPath = System.IO.Path.Combine(local_Path, local_FileName);

                //begin to migrate from local to PRD
                FileHelper.FileCopy(Local_File_FullPath, PRD_FileName);

                Common.Migrate_Description.AppendLine("Copy local file from :" + Local_File_FullPath);
                Common.Migrate_Description.AppendLine("To PRD file path :" + PRD_FileName);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }

        }
        public void BackUp(string backupFolderName, string fileName,string prdFileName)
        {
            Common common = new Common();
            if (!Directory.Exists(backupFolderName))
            {
                Directory.CreateDirectory(backupFolderName);
            }
            string fileNameWithoutExt = FileHelper.GetFileNameWithOutExtesion(fileName);
            string fileExtension = FileHelper.GetFileExtension(fileName);
            string newFileName = fileNameWithoutExt + "_" + common.GetDateFormat() + fileExtension;

            string backupFilePath = Path.Combine(backupFolderName, newFileName);

            FileHelper.FileCopy(prdFileName, backupFilePath);

            Common.Migrate_Description.AppendLine("Back up PRD File :" + prdFileName);
            Common.Migrate_Description.AppendLine("To PRD backup folder :" + backupFilePath);
        }
    }
}
