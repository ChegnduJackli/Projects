using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Log
{
    public abstract class LogFactory
    {
        public abstract Log Create();
    }
}
