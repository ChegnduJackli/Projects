using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//委托是类型安全的。
namespace Test1
{
    class Program
    {
        private delegate string GetAString();

        static void Main(string[] args)
        {
            int x = 40;
            //委托在语法上总是接受一个参数的构造函数，这个参数就是委托引用的方法。这个方法必须匹配最初定义委托时的签名。
            GetAString firstStringMethod = new GetAString(x.ToString);
            Console.WriteLine("string is {0}", firstStringMethod());
            //下面跟上面效果一样
            Console.WriteLine("string is {0}", firstStringMethod.Invoke());

            //把方法传递给委托变量也可以
            GetAString secondString = GoodJob;
            Console.WriteLine("second string is {0}", secondString());

            //这样两个方法都会执行，这个叫多播委托
            secondString += BadJob;
            Console.WriteLine("third string is {0}", secondString());

            secondString -= BadJob;
            Console.WriteLine("fourth string is {0}", secondString());


            GetAString Money1 = Money.GetMoney;
            Console.WriteLine("get money is {0}", Money1());

            Money m = new Money();
            Money1 = m.SendMoney;
            Console.WriteLine("send money is {0}", Money1());

            Console.ReadKey();
        }
        static string GoodJob()
        {
            Console.WriteLine("do a good job");
            return "good job";
        }
        static string BadJob()
        {
            Console.WriteLine("do a bad job");
            return "Bad job";
        }
    }

    public class Money
    {
        public static string GetMoney()
        {
            return "So many money";
        }
        public string SendMoney()
        {
            return "Come to get money";
        }
    }
}

