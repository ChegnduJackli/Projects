using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

namespace CallCMD
{
    public class FileDAL
    {
        public static readonly string FilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static readonly string FileName = "URL.txt";

        public virtual void WriteFile(string fileName, string txt)
        {
            try
            {
                string filePath = Path.Combine(FileDAL.FilePath, FileDAL.FileName);

                using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(txt);
                        sw.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<string> GetURL()
        {
            List<string> urlList = new List<string>();
            try
            {
                string filePath = Path.Combine(FileDAL.FilePath, FileDAL.FileName);
                string[] lines = System.IO.File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    urlList.Add(line);
                }
                return urlList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
