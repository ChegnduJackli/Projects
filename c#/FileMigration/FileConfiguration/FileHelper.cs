using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace FileConfiguration
{
    class FileHelper
    {
        public static void WriteFile(object obj)
        {
            try
            {
                using (FileStream fs = new FileStream(Common.CONFIG_FILE_PATH, FileMode.Append))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(obj);
                        sw.Close();
                    }
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static AutoCompleteStringCollection ReadFileByLine(string fileName)
        {

            AutoCompleteStringCollection dirList = new AutoCompleteStringCollection();
            string line;
            using (System.IO.StreamReader file = new System.IO.StreamReader(fileName, Encoding.UTF8))
            {
                while ((line = file.ReadLine()) != null)
                {
                    dirList.Add(line.Trim());
                }
            }
            return dirList;
        }
    }
}
