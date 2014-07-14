using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

//适合小任务，时间短的，时间长的还是用Thread来创建
namespace ThreadPoolExample
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
