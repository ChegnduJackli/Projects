using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Log
{
    public class FileLog:Log
    {
        public override void Write(string sMessage)
        {
            Console.WriteLine("FileLog write Success :" +sMessage);
        }
    }
}
