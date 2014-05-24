using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ExcelToDataTable
{
    public class FileOperation
    {
        public List<string> GetFileList()
        {
            string fileExtension = PubConstant.FileExtension;
            string filePath = PubConstant.FileDir;
            List<string> fileList = new List<string>();
            try
            {
                foreach (string fileName in Directory.GetFiles(filePath, fileExtension))
                {
                    fileList.Add(fileName);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return fileList;
        }
        public void WriteFile(string name,string script)
        {
            try
            {
                string fileDir = PubConstant.FileDir;
                name =Path.GetFileNameWithoutExtension(name);
                string fileName = Path.Combine(fileDir, name + PubConstant.ScriptExtension);
                
                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    sw.WriteLine(script);
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
