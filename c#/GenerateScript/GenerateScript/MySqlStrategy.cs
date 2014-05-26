using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateScript
{
    public class MySqlStrategy: Strategy
    {
        public override void GenerateScripts(string filePath="")
        {
            Console.WriteLine("Generate Mysql scripts");
        }
    }
}
