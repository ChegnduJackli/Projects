using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MianShi
{
    class AbstractClass
    {
        public static void Run()
        {
            C c = new C();
            c.Test();
            c.Test1();
            c.G();


            A a = new C();
            a.Test();
            a.Test1();

            B b = new C();
            b.G();
            b.Test1();
            b.Test();
           
        }
    }
    abstract class A
    {
        public abstract void Test();
      
        public void Test1()
        {
            Console.WriteLine("A:Test1.");
        }
    }
    abstract class B : A  //类 B 引入另一个方法 G，但由于它不提供 F 的实现，B 也必须声明为抽象类
    {
        public virtual void G()
        {
            Console.WriteLine("B.G");
        }
    }
    class C : B
    {
        public override void Test()
        {
            Console.WriteLine("C:Test1.");
        }
        public override  void G()
        {
            Console.WriteLine("C.G");
        }
    }
}
