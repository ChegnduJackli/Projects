using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.CompilerServices;
using Ionic.Zip;

namespace FileUtil
{
    public class FileDAL
    {
        /// <summary>
        /// write message to specified path.
        /// if append is true ,then append to the end, otherwise,every time overwrited.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="message"></param>
        public static void WriteToFile(string fileName, object message, bool append = true)
        {
            try
            {
                if (append)
                {
                    WriteToFile(fileName, message, FileMode.Append);
                }
                else
                {
                    WriteToFile(fileName, message, FileMode.OpenOrCreate);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// if file not exist, then create file and parent directory.
        /// </summary>
        /// <param name="fileName"></param>
        public static void CreateFile(string fileName)
        {
            string directoryName = GetDirectoryName(fileName);

            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }
            if (!File.Exists(fileName))
            {
                File.Create(fileName).Close();
            }
        }
        /// <summary>
        /// write message to file by different FileMode
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="message"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void WriteToFile(string fileName, object message, FileMode mode)
        {
            try
            {
                CreateFile(fileName);

                using (FileStream fs = new FileStream(fileName, mode))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(message);
                        sw.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// read all text from file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string ReadFileAllText(string fileName)
        {
            try
            {
                string fileContent = System.IO.File.ReadAllText(fileName);
                return fileContent;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// read all line from text file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>return string []</returns>
        public static string[] ReadFileAllLines(string fileName)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(fileName);
                return lines;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// get file extension like .txt, .jpg
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetFileExtension(string fileName)
        {
            try
            {
                return Path.GetExtension(fileName);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// get file name without extension
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetFileNameWithOutExtesion(string fileName)
        {
            try
            {
                return Path.GetFileNameWithoutExtension(fileName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// check the file path is the directory or file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool IsDirectory(string fileName)
        {
            try
            {
                FileAttributes attr = File.GetAttributes(fileName);
                if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// get the directory with fileName.
        /// the fileName maybe a directory or file path
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetDirectoryName(string fileName)
        {
            string dirName = string.Empty;

            try
            {
                if ((fileName.IndexOf(".") < 0) && IsDirectory(fileName))
                {
                    dirName = fileName;
                    if (!dirName.EndsWith(Path.DirectorySeparatorChar.ToString()))
                    {
                        dirName += Path.DirectorySeparatorChar;
                    }
                }
                else
                {
                    dirName = Path.GetDirectoryName(fileName);
                    if (!dirName.EndsWith(Path.DirectorySeparatorChar.ToString()))
                    {
                        dirName += Path.DirectorySeparatorChar;
                    }
                }
                return dirName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// copy file to new path, 
        /// if the file exists already, then overwrite the file.
        /// </summary>
        /// <param name="originFile"></param>
        /// <param name="newFile"></param>
        public static void FileCopy(string originFile, string newFile)
        {
            try
            {
                File.Copy(originFile, newFile, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// delete specified file
        /// </summary>
        /// <param name="fileName"></param>
        public static void DeleteFile(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// delete all in specified folder,include all sub folders and all files
        /// </summary>
        /// <param name="dir"></param>
        public static void DeleteFolder(string dir)
        {
            try
            {
                if (Directory.Exists(dir)) //if folder exis,then delete
                {
                    foreach (string d in Directory.GetFileSystemEntries(dir))
                    {
                        if (File.Exists(d))
                            File.Delete(d); //delete file
                        else
                            //DeleteFolder(d); //delete sub folder
                            Directory.Delete(d, true);
                    }
                    //Directory.Delete(dir); //delete already empty folder
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void CheckFilePath(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ApplicationException("File is empty.");
            }
            if (!File.Exists(fileName))
            {
                throw new ApplicationException("File does not exist.");
            }
        }

        protected virtual bool IsFileLocked(string filePath)
        {
            FileStream stream = null;
            FileInfo file = new FileInfo(filePath);

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }

        /// <summary>
        /// Zip a file to zipPath.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="zipPath"></param>
        public static void ZipFileWithPassword(string fileName, string zipPath,string zipPassword)
        {
            if (File.Exists(zipPath)) File.Delete(zipPath);

            using (ZipFile zip = new ZipFile())
            {
                zip.Password = zipPassword;
                zip.AddFile(fileName, "");
                zip.Save(zipPath);
            }
        }

        /// <summary>
        /// Zip a file to zipPath.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="zipPath"></param>
        public static void ZipFile(string fileName, string zipPath)
        {
            if (File.Exists(zipPath)) File.Delete(zipPath);

            using (ZipFile zip = new ZipFile())
            {
                //zip.Password = zipPassword;
                zip.AddFile(fileName, "");
                zip.Save(zipPath);
            }
        }
    }


}
