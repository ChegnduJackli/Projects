using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecoratorClass
{
    public class DatabaseLog : Log
    {
        public override void Write(string log)
        {
            Console.WriteLine("Write DataBase :" +log);
        }
    }
}
