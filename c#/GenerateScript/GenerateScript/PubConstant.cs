using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Configuration;

namespace GenerateScript
{
   public  class PubConstant
    {
       public static readonly string FilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
       public static readonly string FileExtension = "*.xls";
       public static readonly string FieldSeperator = "@#@";
       public static readonly string FieldSingleQuote = "#&#";

       public static readonly string Database_MSSql = "Sql";
       public static readonly string Database_Oracle = "Oracle";
       public static readonly string Database_MySql = "mysql";

       public static readonly string Database = ConfigurationManager.AppSettings["Database"];
       public static readonly string Script_Template = ConfigurationManager.AppSettings["ScriptTemplate"];
       
    }
}
