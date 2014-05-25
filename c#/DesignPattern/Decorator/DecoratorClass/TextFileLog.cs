using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecoratorClass
{
    public class TextFileLog : Log
    {
        public override void Write(string log)
        {
            Console.WriteLine("TextFile Writes");
        }
    }
}
