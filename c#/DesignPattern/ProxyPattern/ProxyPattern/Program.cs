using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * 总结
   在软件系统中，增加一个中间层是我们解决问题的常见手法，这方面Proxy模式给了我们很好的实现。
 */
namespace ProxyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            MathProxy proxy = new MathProxy();

            double addresult = proxy.Add(2, 3);
            Console.WriteLine(addresult);

            double subresult = proxy.Sub(2, 3);
            Console.WriteLine(subresult);

            double mulresult = proxy.Mul(2, 3);
            Console.WriteLine(mulresult);

            double devresult = proxy.Dev(2, 3);
            Console.WriteLine(devresult);

            Console.Read();
        }
    }
}
