using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BridgePattern
{
    public class NetPlatform : Platform
    {
        public override void Execute(string msg)
        {
          //.net 平台
            Console.WriteLine(".net platform run");
        }
    }
}
