using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DecoratorClass;
using System.IO;

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
            Console.Read();

            /*
              注意在上面程序中的第三段装饰才真正体现出了Decorator模式的精妙所在，这里总共包装了两次：第一次对log对象进行错误严重级别的装饰，变成了lew2对象，
              第二次再对lew2对象进行装饰，于是变成了lpw2对象，此时的lpw2对象同时扩展了错误严重级别和优先级别的功能。
              也就是说我们需要哪些功能，就可以这样继续包装下去。到这里也许有人会说LogPriorityWrapper类的构造函数接收的是一个Log对象，
              为什么这里可以传入LogErrorWrapper对象呢？通过类结构图就能发现，LogErrorWrapper类其实也是Log类的一个子类。

              我们分析一下这样会带来什么好处？首先对于扩展功能已经实现了真正的动态增加，只在需要某种功能的时候才进行包装；
              其次，如果再出现一种新的扩展功能，只需要增加一个对应的包装子类（注意：这一点任何时候都是避免不了的），
              而无需再进行很多子类的继承，不会出现子类的膨胀，同时Decorator模式也很好的符合了面向对象设计原则中的“优先使用对象组合而非继承”和“开放-封闭”原则。
             */
        }
    }
}
