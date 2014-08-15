using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TimersTimer
{
    class Program
    {
        static void Main(string[] args)
        {
            //TimersTimer();
            ThreadingTimer();
            Console.ReadLine();
        }
        private static void TimersTimer()
        {
            var t1 = new System.Timers.Timer(1000);
            t1.AutoReset = true;  //为false,只执行一次Elapse事件
            t1.Elapsed += TimeAction;
            t1.Start();

            //t1.Stop();
        }

        private static void ThreadingTimer()
        {
            var t1 = new System.Threading.Timer(
               TimeAction, null, TimeSpan.FromSeconds(2),
               TimeSpan.FromSeconds(3));

            Thread.Sleep(15000);

            t1.Dispose();
        }

        static void TimeAction(object o)
        {
            Console.WriteLine("System.Threading.Timer {0:T}", DateTime.Now);
        }

        static void TimeAction(object sender, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine("System.Timers.Timer {0:T}", e.SignalTime);
        }
    }
}
