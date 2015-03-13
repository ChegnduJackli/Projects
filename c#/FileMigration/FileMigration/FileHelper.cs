using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

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
    }
}
