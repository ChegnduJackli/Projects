using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdapterPattern
{
    /*
     * 实现要点

1．Adapter模式主要应用于“希望复用一些现存的类，但是接口又与复用环境要求不一致的情况”，在遗留代码复用、类库迁移等方面非常有用。

2．Adapter模式有对象适配器和类适配器两种形式的实现结构，但是类适配器采用“多继承”的实现方式，带来了不良的高耦合，所以一般不推荐使用。对象适配器采用“对象组合”的方式，更符合松耦合精神。

3．Adapter模式的实现可以非常的灵活，不必拘泥于GOF23中定义的两种结构。例如，完全可以将Adapter模式中的“现存对象”作为新的接口方法参数，来达到适配的目的。

4．Adapter模式本身要求我们尽可能地使用“面向接口的编程”风格，这样才能在后期很方便的适配。[以上几点引用自MSDN WebCast]
     */
    public abstract class LogAdaptee
    {
        public abstract void WriteLog();
    }

  
    
    public class DatabaseLog : LogAdaptee
    {
        public override void WriteLog()
        {

            Console.WriteLine("Called DatabaseLog WriteLog Method");

        }
    }


    public class FileLog : LogAdaptee
    {

        public override void WriteLog()
        {
            Console.WriteLine("Called FileLog WriteLog Method");
        }

    }
    //抽象适配器模式
    public interface ILogTarget
    {

        void Write();

    }
    public class LogAdapter : ILogTarget
    {

        private LogAdaptee _adaptee;



        public LogAdapter(LogAdaptee adaptee)
        {

            this._adaptee = adaptee;

        }

        public void Write()
        {

            _adaptee.WriteLog();

        }


    }
   
    
}
