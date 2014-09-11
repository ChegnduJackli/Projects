using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BridgePattern
{
    public class JavaPlatform:Platform
    {
        public override void Execute(string msg)
        {
            Console.WriteLine("Java platform run");
        }
    }
}
