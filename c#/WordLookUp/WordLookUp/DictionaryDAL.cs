using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

namespace WordLookUp
{
    public class DictionaryDAL
    {
        string fileDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        Dictionary<int, string> stuDictionAry = new Dictionary<int, string>();

        public Dictionary<int, string> GetStuList(string fileName)
        {
            try
            {
                stuDictionAry.Clear();
                string filePath = Path.Combine(fileDir, fileName);
                string[] stuLines = FileUtil.FileDAL.ReadFileAllLines(filePath);
                int key = 0;
                string value = string.Empty;
                foreach (string stuInfo in stuLines)
                {
                    if (stuInfo.IndexOf("=") > 0)
                    {
                        string[] sArr = stuInfo.Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                        key = Convert.ToInt32(sArr[0]);
                        value = sArr[1];
                        if (!stuDictionAry.ContainsKey(key))
                        {
                            stuDictionAry.Add(key, value);
                        }
                    }
                }
                return stuDictionAry;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
