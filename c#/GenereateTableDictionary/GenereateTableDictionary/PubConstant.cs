using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Configuration;

namespace GenereateTableDictionary
{
    public class PubConstant
    {
        public static readonly string ConnectString = ConfigurationManager.AppSettings["ConnectionString"].ToString();

        public static readonly string fileSuffix = @".xlsx";
        public static readonly string FilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static readonly string FileName = ConfigurationManager.AppSettings["FileName"].ToString();
        public static readonly string TableColumnFilePath = Path.Combine(FilePath, FileName+"_Table" + fileSuffix);
        public static readonly string TableIndexFilePath = Path.Combine(FilePath, FileName + "_Index" + fileSuffix);
        public static readonly string TriggerFilePath = Path.Combine(FilePath, FileName + "_Trigger" + fileSuffix);
        public static readonly string TableViewFilePath = Path.Combine(FilePath, FileName + "_View" + fileSuffix);
        public static readonly string FunctionFilePath = Path.Combine(FilePath, FileName + "_Function" + fileSuffix);
        public static readonly string SPFilePath = Path.Combine(FilePath, FileName + "_SP" + fileSuffix);
        public static readonly string SequenceFilePath = Path.Combine(FilePath, FileName + "_Sequence" + fileSuffix);
        public static readonly string DataCountFilePath = Path.Combine(FilePath, FileName + "_DataCount" + fileSuffix);
    }
}
