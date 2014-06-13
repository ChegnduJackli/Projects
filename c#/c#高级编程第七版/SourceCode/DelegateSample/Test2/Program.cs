using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//委托不考虑静态方法还是实例方法，它们不关心在什么类型的对象上调用该方法。
namespace Test2
{
    class Program
    {
        private delegate string GetAString();

        static void Main(string[] args)
        {
            int x = 40;
            GetAString firstStringMethod = x.ToString;
            Console.WriteLine("string is {0}", firstStringMethod());

            Currenty cc = new Currenty(34, 50);
            firstStringMethod = cc.ToString;
            Console.WriteLine("string is {0}", firstStringMethod());

            firstStringMethod = new GetAString(Currenty.GetCurrencyUnit);
            Console.WriteLine("string is {0}", firstStringMethod());
            Console.ReadKey();
        }
    }
    struct Currenty
    {
        public int Dollars;
        public ushort Cents;

        public Currenty(int dollars, ushort cents)
        {
            this.Dollars = dollars;
            this.Cents = cents;
        }
        public override string ToString()
        {
            return string.Format("${0}.{1,2:00}",Dollars,Cents);
        }
        public static string GetCurrencyUnit()
        {
            return "Dollar";
        }


    }
}
