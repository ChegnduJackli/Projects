using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //var state = new ShareState();
            //var job = new Job(state);
            //同步执行
            //job.DoTheJob();
            //Console.WriteLine(state.State);
            //异步执行
            int numTask = 20;
            var state = new ShareState();
            var tasks = new Task[numTask];
            for (int i = 0; i < numTask; i++)
            {
                tasks[i] = new Task(new Job(state).DoTheJob);
                tasks[i].Start();
            }

            for (int i = 0; i < numTask; i++)
            {
                tasks[i].Wait(); //等待线程完成
            }
            Console.WriteLine("Summarized {0} ",state.State);
            Console.ReadLine();
        }
    }
    class ShareState
    {
        public int State { get; set; }
    }
    class Job
    {
        ShareState sharedState;
        private object objLock = new object();

        public Job(ShareState sharedState)
        {
            this.sharedState = sharedState;
        }
        public void DoTheJob()
        {

            for (int i = 0; i < 50000; i++)
            {
                lock (sharedState)
                {
                    sharedState.State += 1;
                }
            }
        }
    }
}
