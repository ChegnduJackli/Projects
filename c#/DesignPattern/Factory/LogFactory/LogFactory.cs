using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogWrite
{
    public abstract class LogFactory
    {
        public abstract Log Create();
    }
}
