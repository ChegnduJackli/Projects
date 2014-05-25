using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DecoratorClass;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Log log = new DatabaseLog();
            LogWrapper lew1 = new LogErrorWrapper(log);
            //扩展了记录错误严重级别
            lew1.Write("Log Message");

            LogPriorityWrapper lpw1 = new LogPriorityWrapper(log);
            //扩展了记录优先级别
            lpw1.Write("Log Message");

            LogWrapper lew2 = new LogErrorWrapper(log);
            LogPriorityWrapper lpw2 = new LogPriorityWrapper(lew2); //这里是lew2
            //同时扩展了错误严重级别和优先级别
            lpw2.Write("Log Message");
        }
    }
}
