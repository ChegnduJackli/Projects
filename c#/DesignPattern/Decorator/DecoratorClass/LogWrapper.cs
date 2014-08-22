using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecoratorClass
{
    //装饰模式进行包装
    public class LogWrapper:Log
    {
        private Log _log;
        public LogWrapper(Log log)
        {
            this._log = log;
            Console.WriteLine("LogWrapper Constructor call");
        }
        public override void Write(string logMessage)
        {
            _log.Write(logMessage);
        }
    }
}
