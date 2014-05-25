using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecoratorClass
{
    public class LogErrorWrapper:LogWrapper
    {
        public LogErrorWrapper(Log _log):base(_log)
        {
            Console.WriteLine("LogError 构造函数调用");
        }
        public override void Write(string logMessage)
        {
            SetError(); //......功能扩展

            base.Write(logMessage);
        }
        public void SetError()
        {
            Console.WriteLine("错误级别");
            //......实现了记录错误严重级别
        }
    }
}
