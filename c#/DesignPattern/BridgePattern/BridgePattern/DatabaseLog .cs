using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BridgePattern
{
    public class DatabaseLog:Log
    {
        public override void Write(string log)
        {
           // Console.WriteLine("Database write log");
            plateForm.Execute(log);
        }
    }
}
