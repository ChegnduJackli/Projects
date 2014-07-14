using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskSample1
{
    class Program
    {
        static void Main(string[] args)
        {
            //TaskFactory tf = new TaskFactory();
            ////立即启动任务
            //Task t1 = tf.StartNew(DoGood);

            //Task t2 = Task.Factory.StartNew(BadGood);

            //Task t3 = new Task(NormalGood);
            ////t3.Start();
            //t3.RunSynchronously();

           //连续的任务
            //Task t1 = new Task(DoOnFirst);
            //Task t2 = t1.ContinueWith(DoOnSecond);
            //Task t3 = t1.ContinueWith(DoOnSecond);
            //Task t4 = t2.ContinueWith(DoOnSecond);
            //Task t5 = t1.ContinueWith(DoOnError, TaskContinuationOptions.OnlyOnFaulted);
            //t1.Start();

            //父子任务
            ParentAndChild();
            Console.ReadLine();

        }
        static void DoGood()
        {
            Console.WriteLine("Really do a good job.");
        }
        static void BadGood()
        {
            Console.WriteLine("Really do a bad job.");
        }
        static void NormalGood()
        {
            Console.WriteLine("Really do a normal job.");
        }

        static void DoOnFirst()
        {
            Console.WriteLine("Doing some taks {0}",Task.CurrentId);
            Thread.Sleep(3000);
        }

        static void DoOnSecond(Task t)
        {
            Console.WriteLine("task {0} finished", t.Id);
            Console.WriteLine("this task is {0}", Task.CurrentId);
            Console.WriteLine("do some clean up");
            Thread.Sleep(3000);
        }

        static void DoOnError(Task t)
        {
            Console.WriteLine("task {0} had an error!", t.Id);
            Console.WriteLine("my id {0}", Task.CurrentId);
            Console.WriteLine("do some cleanup");
        }

        //父任务，启动子任务
        //子任务结束时，父任务的状态就变为RanToCompletion
        static void ParentAndChild()
        {
            Task parent = new Task(ParentTask);
            parent.Start();
            Thread.Sleep(2000);
            Console.WriteLine(parent.Status);
            Thread.Sleep(4000);
            Console.WriteLine(parent.Status);

        }
        static void ParentTask()
        {
            Console.WriteLine("task id {0}", Task.CurrentId);
            Task child = new Task(ChildTask, TaskCreationOptions.AttachedToParent);
            child.Start();
            Thread.Sleep(1000);
            Console.WriteLine("parent started child");
            // Thread.Sleep(3000);
        }
        static void ChildTask()
        {
            // Console.WriteLine("task id {0}, parent: {1}", Task.Current.Id, Task.Current.Parent.Id);
            Console.WriteLine("child");
            Thread.Sleep(5000);
            Console.WriteLine("child finished");
        }
    }

}
