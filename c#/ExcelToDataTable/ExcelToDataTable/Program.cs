using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ExcelToDataTable
{
    class Program
    {
        static void Main(string[] args)
        {
            FileOperation fileOper=new FileOperation ();
            ExcelOperation excelOper = new ExcelOperation();
            List<string> fileList = fileOper.GetFileList();
            foreach (string fileName in fileList)
            {
              excelOper.ReadExcel(fileName);
            }
        }
    }
}
