using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Reflection;

namespace Log
{
    class Program
    {
        static void Main(string[] args)
        {
            LogFactory factory = new EventFactory();
            // LogFactory factory = new FileFactory();
            Log log = factory.Create();
            log.Write("Jack create it");
            Console.ReadLine();

            //如果需要使用反射，则必须是在单独的dll文件中，也就是独立的类中
            

        }
    }
}
