using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecoratorClass
{
  public class LogPriorityWrapper:LogWrapper
    {
      public LogPriorityWrapper(Log _log)
          : base(_log)
      {
        Console.WriteLine("Priority 构造函数调用");
      }

      public override void Write(string logMessage)
      {
          SetPriority(); //......功能扩展
          base.Write(logMessage);
      }
      public void SetPriority()
      {
          Console.WriteLine("优先级别");
      }
    }

}
