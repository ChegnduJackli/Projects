using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BridgePattern
{
    public abstract class Platform
    {
        public abstract void Execute(string msg);
    }
}
