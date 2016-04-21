using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;
using Ionic.Zip;

namespace FileMigration
{
    class FileHelper
    {
        /// <summary>
        /// copy an existing file to a new file,overwriting file of the same name is allowed
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
                //FileAttributes attr = File.GetAttributes(fileName);
                //if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                //{
                //    return true;
                //}
                if (fileName.IndexOf(".") < 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// get file name without directory
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetFileName(string fileFullName)
        {
            try
            {
                return Path.GetFileName(fileFullName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// get the directory with fileName.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetDirectoryName(string fileName)
        {
            string dirName = string.Empty;

            try
            {
                if (FileHelper.IsDirectory(fileName))
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
        /// if file exist,return true, otherwise return false.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool IsFileExist(string fileName)
        {
            try
            {
                return File.Exists(fileName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// delete the file 
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
        /// Zip a folder to zipPath
        /// </summary>
        /// <param name="folderName"></param>
        /// <param name="zipPath"></param>
        public static void ZipFolder(string folderName, string zipPath,string zipPassword)
        {
            if (File.Exists(zipPath)) File.Delete(zipPath);

            using (ZipFile zip = new ZipFile())
            {
                zip.Password = zipPassword;
                zip.AddDirectory(folderName,"");
                zip.Save(zipPath);
            }
        }
        /// <summary>
        /// Zip a file to zipPath.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="zipPath"></param>
        public static void ZipFile(string fileName, string zipPath,string zipPassword)
        {
            if (File.Exists(zipPath)) File.Delete(zipPath);

            using (ZipFile zip = new ZipFile())
            {
                zip.Password = zipPassword;
                zip.AddFile(fileName,"");

                zip.Save(zipPath);
            }
        }
       
    }
}
