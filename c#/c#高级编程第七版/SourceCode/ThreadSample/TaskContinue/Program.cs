using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TaskContinue
{
    class Program
    {
        static int Total = 0;
        static void Main(string[] args)
        {
            Task t1 = new Task(DoFirst);
            Task t2 = t1.ContinueWith(DoSecond);
            t1.Start();
            Console.WriteLine("total:{0}", Total);
            Console.ReadLine();
        }
        static void DoFirst()
        {
            Console.WriteLine("doing some task {0}", Task.CurrentId);
            for (int i = 0; i < 10; i++)
            {
                Total += i;
                Console.WriteLine("i:{0},total:{0}", i, Total);
            }
            Thread.Sleep(3000);
        }
        static void DoSecond(Task t)
        {
            Console.WriteLine("task {0} finished", t.Id);
            Console.WriteLine("this task id {0}", Task.CurrentId);
            Console.WriteLine("do some cleanup");
            for (int i = 0; i < 10; i++)
            {
                Total = Total - i;
                Console.WriteLine("i:{0},total:{0}", i, Total);
            }
            Thread.Sleep(3000);
        }
    }
}
