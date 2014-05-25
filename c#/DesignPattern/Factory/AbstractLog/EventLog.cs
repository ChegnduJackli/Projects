using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogWrite
{
    public class EventLog : Log
    {
        public override void Write()
        {
            Console.WriteLine("EventLog Write Success!");
        }
    }
}
