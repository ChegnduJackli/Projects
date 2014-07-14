using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

//类似于c#的for循环，也是多次执行一个任务，迭代的顺序没有定义 
//前2个参数定义了循环的开头和结束，第三个参数是Action<int> 委托
namespace ParallelSample
{
    class Program
    {
        static void Main(string[] args)
        {
            ParallelLoopResult result = Parallel.For(0, 10,i =>
                {
                    Console.WriteLine("{0},task:{1}, thread:{2}",i,Task.CurrentId,Thread.CurrentThread.ManagedThreadId);
                    Thread.Sleep(1000);
                });
            Console.WriteLine(result.IsCompleted);

            ParallelLoopResult result1 =
                Parallel.For(10, 40, (int i, ParallelLoopState pls) =>
                    {
                        Console.WriteLine("i: {0} task {1}", i, Task.CurrentId);
                        Thread.Sleep(10);
                        if (i > 15)
                            pls.Break();
                    });
            Console.WriteLine(result1.IsCompleted);
            Console.WriteLine("lowest break iteration:{0}",result1.LowestBreakIteration);

            Parallel.For(0, 1000, (i, loopstate) =>
                {
                    Console.WriteLine(i);
                    if (i == 100)
                    {
                        loopstate.Stop();
                    }
                });
            Console.ReadLine();
            
        }
    }
}
