using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * 总结
   在软件系统中，增加一个中间层是我们解决问题的常见手法，这方面Proxy模式给了我们很好的实现。
 *     代理模式是常用的结构型设计模式之一，当无法直接访问某个对象或访问某个对象存在困难时可以通过一个代理对象来间接访问，
 *     为了保证客户端使用的透明性，所访问的真实对象与代理对象需要实现相同的接口。
 *     根据代理模式的使用目的不同，代理模式又可以分为多种类型，例如保护代理、远程代理、虚拟代理、缓冲代理等，
 *     它们应用于不同的场合，满足用户的不同需求。
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
