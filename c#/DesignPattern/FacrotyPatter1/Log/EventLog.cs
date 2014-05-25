using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Log
{
    public class EventLog:Log
    {
        public override void Write(string sMessage)
        {
            Console.WriteLine("EventLog Write Success : " +sMessage);
        }
    }
}
