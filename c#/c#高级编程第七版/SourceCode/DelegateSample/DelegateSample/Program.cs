using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegateSample
{
    //定义委托，它定义了可以代表的方法的类型
    //理解委托的好方式是把委托当成这样一件事情，给方法的签名和返回类型指定名称
    //定义一个委托，其实就是定义一个新类，委托最终派生自System.Delegate.
    //委托和委托的实例都叫委托，不像类和实例有2个名字
    public delegate void GreetingDelegate(string name);

    class Program
    {
        static void Main(string[] args)
        {
            //第一种
            GreetPeople("Jack", EnglishGreeting);
            GreetPeople("哎哟", ChineseGreeting);
            //第二种
            GreetingDelegate greet;
            greet = EnglishGreeting;
            greet += ChineseGreeting;
            greet("Jack");
            //第三种
            GreetingDelegate gr = new GreetingDelegate(EnglishGreeting);
            gr += ChineseGreeting;
            gr("Rose");

            //添加greetmanager 类封装后.
            GreetManager gm = new GreetManager();
            gm.delegate1 = EnglishGreeting;
            gm.delegate1 += ChineseGreeting;
            gm.GreetPeople("Adi");

            Console.ReadKey();
        }

        private static void EnglishGreeting(string name)
        {
            Console.WriteLine("Morning, " + name);
        }
        private static void ChineseGreeting(string name)
        {
            Console.WriteLine("早上好, " + name);
        }
        //委托传递的是方法。
        private static void GreetPeople(string name, GreetingDelegate makeGreeting)
        {
            makeGreeting(name);
        }
    }
    class GreetManager
    {
        public GreetingDelegate delegate1;
        public void GreetPeople(string name)
        {
            if (delegate1 != null)
            {
                delegate1(name);
            }
        }
    }

    //class GreetManager1
    //{
    //    public event GreetingDelegate MakeGreet;
    //    public void GreetPeople(string name)
    //    {
    //        MakeGreet(name);
    //    }
    //}
}
