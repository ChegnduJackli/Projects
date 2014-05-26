using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace GenerateScript
{
   public  class PubConstant
    {
       public static readonly string FilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
       public static readonly string FileExtension = "*.xls";
       public static readonly string FieldSeperator = "@#@";
       
    }
}
