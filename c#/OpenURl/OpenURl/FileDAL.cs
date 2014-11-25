using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

namespace OpenURl
{
    public class FileDAL
    {
        public static readonly string FilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static readonly string FileName = "URL.txt";
        public static readonly string Seperator = @"===";

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
        public static Dictionary<string, string> GetUrlAndDesc()
        {
            Dictionary<string, string> urlDic = new Dictionary<string, string>();
            try
            {
                string filePath = Path.Combine(FileDAL.FilePath, FileDAL.FileName);
                string[] lines = System.IO.File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string url=line;
                    string desc=string.Empty;
                    if (line.IndexOf(Seperator) > 0)
                    {
                        string[] arr = line.Split(new string[] { (Seperator) }, StringSplitOptions.RemoveEmptyEntries);
                        //url = line.Substring(0, line.IndexOf(Seperator)).Trim();
                        //desc = line.Substring(line.IndexOf(Seperator) + Seperator.Length);
                        url = arr[0];
                        desc = arr[1];
                    }
                    if (!urlDic.ContainsKey(url))
                    {
                        urlDic.Add(url, desc);
                    }
                }
                return urlDic;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<string> GetUrlList()
        {
            List<string> urlList = new List<string>();
            try
            {
                GetUrlAndDesc();
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
