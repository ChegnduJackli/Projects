using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateScript
{
    public class SQLStrategy : Strategy
    {
        public override void GenerateScripts(string filePath="")
        {
            Console.WriteLine("generate sql scripts");
        }
    }
}
