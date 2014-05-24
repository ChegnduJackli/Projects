using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace ExcelToDataTable
{
    public class PubConstant
    {
        public static readonly string FileDir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static readonly string FileExtension = "*.xls";
        public static readonly string ScriptExtension = ".txt";
        public static readonly string Field_Seperator = "@#@";
    }
}
