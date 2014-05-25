using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//建立一个抽象的操作类
namespace Log
{
    public abstract class Log
    {
        public abstract void Write(string sMessage);
    }
}
