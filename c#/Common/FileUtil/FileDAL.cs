using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

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
        public static void WriteToFile(string fileName, string message, bool append = true)
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
        /// write message to file by different FileMode
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="message"></param>
        public static void WriteToFile(string fileName, string message,FileMode mode)
        {
            try
            {
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
        /// copy file to new path
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
    }


}
