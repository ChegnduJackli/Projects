using System;
using System.Threading;
using System.Threading.Tasks;

namespace Wrox.ProCSharp.Threading
{

    class Program
    {
        static void Main()
        {
            //lock语句会解析成使用Monitor类
            object obj = new object();
            bool lockTaken = false;
            Monitor.TryEnter(obj, 500, ref lockTaken);//500 miliseconds。设置超时
            if (lockTaken) //如果被锁定
            {
                try
                {
                    // acquired the lock
                    // synchronized region for obj
                }
                finally
                {
                    Monitor.Exit(obj);
                }

            }
            else
            {
                // didn't get the lock, do something else
            }

            int numTasks = 20;
            var state = new SharedState();
            var tasks = new Task[numTasks];
         

            for (int i = 0; i < numTasks; i++)
            {
                tasks[i] = new Task(new Job(state).DoTheJob);
                tasks[i].Start();
            }


            for (int i = 0; i < numTasks; i++)
            {
                tasks[i].Wait();//waiting for thread finished.
            }


            Console.WriteLine("summarized {0}", state.State);
            Console.ReadLine();
        }
    }
}
