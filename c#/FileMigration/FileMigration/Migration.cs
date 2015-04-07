using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileMigration
{
    public class Migration
    {
        private bool hasUpload = false;
        private bool hasDownload = false;
        private string beforeMigration = string.Empty;
        private string afterMigration = string.Empty;

        private IEnumerable<LineInfo> lineInfoList;

        public Migration(string fileName)
        {
            this.lineInfoList = ReadAllLinesFromFile(fileName);
        }

        private IEnumerable<LineInfo> ReadAllLinesFromFile(string fileName)
        {
            string logLine;
            var lineParser = new LineParser();
            List<LineInfo> lineInfoList = new List<LineInfo>();
            const Int32 BufferSize = 4096;

            using (System.IO.StreamReader file = new System.IO.StreamReader(fileName, Encoding.UTF8, true, BufferSize))
            {
                while ((logLine = file.ReadLine()) != null)
                {
                    var lineInfo = lineParser.ParseLine(logLine);
                    if (lineInfo != null)
                    {
                        lineInfoList.Add(lineInfo);
                    }
                }
            }
            return lineInfoList;
        }

        //Do the migration process
        public void DoMigration()
        {
            foreach (var line in this.lineInfoList)
            {
                FileMigration(line);
            }

            if (hasUpload)
            {
                Common.Migrate_Description.AppendLine("Zip before folder: " + Common.Upload_Before_Folder);
                FileHelper.ZipFolder(Common.Upload_Before_Folder, Common.Zip_Upload_Before_FolderName, Common.Zip_Password);

                Common.Migrate_Description.AppendLine("Zip after folder :" + Common.Upload_After_Folder);
                FileHelper.ZipFolder(Common.Upload_After_Folder, Common.Zip_Upload_After_FolderName, Common.Zip_Password);

                Common.Attachment_List.Add(Common.Zip_Upload_Before_FolderName);
                Common.Attachment_List.Add(Common.Zip_Upload_After_FolderName);
            }
            if (hasDownload)
            {
                Common.Migrate_Description.AppendLine("Zip download folder :" + Common.Download_Folder);
                FileHelper.ZipFolder(Common.Download_Folder, Common.Zip_Download_FolderName, Common.Zip_Password);
                Common.Attachment_List.Add(Common.Zip_Download_FolderName);
            }

            Common.Migrate_Description.AppendLine("Zip log file :" + Common.Log_File);
            LogHelper.WriteLog(Common.Migrate_Description.ToString());

            FileHelper.ZipFile(Common.Log_File, Common.Zip_Logs_FolderName, Common.Zip_Password);
            Common.Attachment_List.Add(Common.Zip_Logs_FolderName);
        }

        //process to upload file one by one line in configure file
        private void FileMigration(LineInfo line)
        {
            try
            {
                string indicator = line.Indicator.Trim().ToUpper();

                if (indicator.Equals(Common.Indicator_Upload_Flag, StringComparison.OrdinalIgnoreCase))
                {
                    hasUpload = true;

                    string localFileFullName = System.IO.Path.Combine(Common.Upload_Source_Folder, line.LocalFile);
                    string prdFile = line.PRDFile;
                    string backUpFile = line.BackUpFile.Replace("@Date@", DateTime.Now.ToString("yyyyMMdd"));

                    if (localFileFullName.IndexOf("*.*") > 0)
                    {
                        //upload the configure path include "*.*"
                        StarFileUplod(localFileFullName, prdFile, backUpFile);
                    }
                    else
                    {
                        //upload the configure path include fileName
                        NormalFileUplod(localFileFullName, prdFile, backUpFile, line);
                    }
                }
                //download file
                else if (indicator.Equals(Common.Indicator_Download_Flag, StringComparison.OrdinalIgnoreCase))
                {
                    hasDownload = true;
                    DownloadFile(line);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex);
            }
        }
        //upload configure path include "*.*" one.
        private void StarFileUplod(string localFileFullName, string prdFile, string backUpFile)
        {
            string localDirName = FileHelper.GetDirectoryName(localFileFullName);
            string prdDirName = FileHelper.GetDirectoryName(prdFile);
            string backupDir = FileHelper.GetDirectoryName(backUpFile);

            string[] fileEntries = Directory.GetFiles(localDirName);
            foreach (string file in fileEntries)
            {
                FileInfo fi = new FileInfo(file);

                localFileFullName = Path.Combine(localDirName, fi.Name);
                prdFile = Path.Combine(prdDirName, fi.Name);

                string relatedDir = localDirName.Replace(Common.Upload_Source_Folder, "").Trim();

                beforeMigration = Path.Combine(Common.Upload_Before_Folder, relatedDir, fi.Name);
                afterMigration = Path.Combine(Common.Upload_After_Folder, relatedDir, fi.Name);
                //for upload "*.*" format file, the backup folder,will add the parent directory, for example
                //@Upload == bin\*.* ==E:\agdhelpdesk\scripts\agd_helpdesk\bin\ ==E:\agdhelpdesk\scripts\agd_helpdesk\backup\@Date@\
                //then backup fold should be: E:\agdhelpdesk\scripts\agd_helpdesk\backup\@Date@\bin\<filename>,  add "bin\" here
                backUpFile = Path.Combine(backupDir, relatedDir, fi.Name);

                FileUploadMigration(beforeMigration, afterMigration, backUpFile, localFileFullName, prdFile);
            }
        }

        //the configure path include the fileName one.
        private void NormalFileUplod(string localFileFullName, string prdFile, string backUpFile, LineInfo line)
        {
            //check if back up file forget include the fileName
            string backUpFileName = backUpFile;
            if (FileHelper.IsDirectory(backUpFile))
            {
                backUpFileName = Path.Combine(backUpFile, FileHelper.GetFileName(localFileFullName));
            }

            string prdFileName = prdFile;
            if (FileHelper.IsDirectory(prdFile))
            {
                prdFileName = Path.Combine(prdFile, FileHelper.GetFileName(localFileFullName));
            }

            beforeMigration = System.IO.Path.Combine(Common.Upload_Before_Folder, line.LocalFile);
            afterMigration = System.IO.Path.Combine(Common.Upload_After_Folder, line.LocalFile);

            FileUploadMigration(beforeMigration, afterMigration, backUpFileName, localFileFullName, prdFileName);
        }
        //download the file from configure path
        private void DownloadFile(LineInfo line)
        {
            string prdDir = FileHelper.GetDirectoryName(line.PRDFile);
            string tempDir = string.Empty;
            if (prdDir.IndexOf(":") > 0)
            {
                tempDir = prdDir.Replace(":", "").Trim();
            }
            Common.Migrate_Description.AppendLine("Starting move PRD file to DOWNLOAD folder");

            if (FileHelper.IsDirectory(line.PRDFile) || line.PRDFile.IndexOf("*.*") > 0) //download all files in the directory
            {
                string[] fileEntries = Directory.GetFiles(prdDir);

                foreach (string file in fileEntries)
                {
                    FileInfo fi = new FileInfo(file);
                    string prdFile = fi.Name;

                    string downloadFile = System.IO.Path.Combine(Common.Download_Folder, tempDir, FileHelper.GetFileName(prdFile));
                    
                    FileMove(fi.FullName, downloadFile);
                }  
            }
            else  //download the specific file
            {
                string prdFile = line.PRDFile;
                string downloadFile = System.IO.Path.Combine(Common.Download_Folder, tempDir, FileHelper.GetFileName(prdFile));
                FileMove(prdFile, downloadFile);
            }
        }
        /// <summary>
        /// Do the File Migration.
        /// Move prd file to before folder, 
        /// Move prd file to backup folder,
        /// Move local file to prd folder,
        /// Move prd file to after folder,
        /// </summary>
        /// <param name="beforeMigrationFolder"></param>
        /// <param name="afterMigrationFolder"></param>
        /// <param name="backUpFile"></param>
        /// <param name="localFile"></param>
        /// <param name="prdFile"></param>
        private void FileUploadMigration(string beforeMigrationFolder, string afterMigrationFolder, string backUpFile, string localFile, string prdFile)
        {
            //may upload new file to prd, so prd don't have the new file
            if (FileHelper.IsFileExist(prdFile))
            {
                //before migration, move prd file to before folder.(for compare with later migration)
                Common.Migrate_Description.AppendLine("Starting move PRD file to BEFORE folder");
                FileMove(prdFile, beforeMigrationFolder);
                //move prd to back up folder
                Common.Migrate_Description.AppendLine("Starting move PRD file to BACKUP folder");
                FileMove(prdFile, backUpFile);
            }
            //do the migration
            Common.Migrate_Description.AppendLine("Starting migrate LOCAL file to PRD folder");
            FileMove(localFile, prdFile);
            //after migration, move prd file to after folder
            Common.Migrate_Description.AppendLine("Starting move PRD file to AFTER folder");
            FileMove(prdFile, afterMigrationFolder);
        }
  

        /// <summary>
        /// move file from source file to target file
        /// </summary>
        /// <param name="PRD_BackUp_File_FullName">target file</param>
        /// <param name="prdFileFullName">orginal file</param>
        private void FileMove(string sourceFileName, string destFileName)
        {
            string destDir = System.IO.Path.GetDirectoryName(destFileName);
            if (!Directory.Exists(destDir))
            {
                Directory.CreateDirectory(destDir);
            }

            FileHelper.FileCopy(sourceFileName, destFileName);

            Common.Migrate_Description.AppendLine("Move source File from :" + sourceFileName);
            Common.Migrate_Description.AppendLine("To destination folder :" + destFileName);
        }
    }
}
