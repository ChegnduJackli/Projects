using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Log4
{
    public interface ILog
    {
        void WriteLog(string message);
        void ErrorLog(string message);
    }
}
