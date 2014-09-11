using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BridgePattern
{
    public class TextFileLog : Log
    {
        public override void Write(string log)
        {
           // Console.WriteLine("Text File write log");
            plateForm.Execute(log);
        }
    }
}
