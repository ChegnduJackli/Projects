using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.OleDb;
using System.Data;

namespace GenerateScript
{
    public class FileOpers
    {
        public virtual List<string> GetFiles()
        {
            List<string> files = new List<string>();

            try
            {
                string path = PubConstant.FilePath;
                string fileExtension = PubConstant.FileExtension;

                foreach (string f in Directory.GetFiles(path,fileExtension))
                {
                    if (!files.Contains(f))
                    {
                        files.Add(f);
                    }
                }
                return files;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void WriteFile(string fileName,string scripts)
        {
            try
            {
                fileName = Path.GetFileNameWithoutExtension(fileName) + PubConstant.ScriptExtension;
                string filePath = Path.Combine(PubConstant.FilePath, fileName);

                using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(scripts);
                        sw.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      
    }
}
