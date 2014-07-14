using System;
using System.Threading;

//线程池的所有线程都是后台线程
//不能给入池的线程设置优先级
//入池的线程只能用于时间较短的任务，如果线程一直运行，就应使用Thread来创建一个新线程
namespace Wrox.ProCSharp.Threading
{


    class Program
    {
        static void Main()
        {
            int nWorkerThreads;
            int nCompletionPortThreads;
            ThreadPool.GetMaxThreads(out nWorkerThreads, out nCompletionPortThreads);
            Console.WriteLine("Max worker threads: {0}, I/O completion threads: {1}", nWorkerThreads, nCompletionPortThreads);

            for (int i = 0; i < 5; i++)
            {
                ThreadPool.QueueUserWorkItem(JobForAThread);

            }

            Thread.Sleep(3000);
            Console.ReadLine();
        }


        static void JobForAThread(object state)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("loop {0}, running inside pooled thread {1}", i,
                   Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(50);
            }

        }
    }
}
