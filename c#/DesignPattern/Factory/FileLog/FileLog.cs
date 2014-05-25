using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogWrite
{
    public class FileLog:Log
    {
        public override void Write()
        {
            Console.WriteLine("FileLog write Success");
        }
    }
}
