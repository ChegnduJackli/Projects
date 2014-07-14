using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SimpleStart
{
    class Program
    {
        int interval = 20;
        static void Main(string[] args)
        {
            Program p = new Program();
        
            Thread nonParameterThread = new Thread(new ThreadStart(p.NonParameterRun));
            //给委托赋值有多种方式
            ThreadStart t = new ThreadStart(p.NonParameterRun);
            ThreadStart t1 = p.NonParameterRun;
            Thread nonParameterThread1 = new Thread(t1);
            //Thread nonParameterThread = new Thread((p.NonParameterRun));
            
            nonParameterThread.Start();
           
            Thread parameterThread = new Thread(new ParameterizedThreadStart(p.ParameterRun));
            parameterThread.Start(30);

            MyThreadParameter myParameterThread = new MyThreadParameter(20, 20);
            myParameterThread.Start();

            Console.ReadLine();
        }
        public void NonParameterRun()
        {
            for (int i = 0; i < 10; i++)
            {
               // Console.WriteLine("----------No parameters-----------");
                Console.WriteLine("The system current milliiseconds ："+DateTime.Now.Millisecond.ToString());
                Thread.Sleep(interval);
            }
        }

        public void ParameterRun(object ms)
        {
            int j = 10;
            int.TryParse(ms.ToString(), out j);
            for (int i = 0; i < 10; i++)
            {
              //  Console.WriteLine("----------Has parameters now-----------");
                Console.WriteLine("Parameter The system current milliiseconds ：" + DateTime.Now.Millisecond.ToString());
                Thread.Sleep(j);
            }
        }
    }
    //这种方式比较推荐，便于维护
    class MyThreadParameter
    {
        private int interval;
        private int loopCount;
        private Thread thread;

        /// <summary>  
        /// 构造函数  
        /// </summary>  
        /// <param name="interval">线程的暂停间隔</param>  
        /// <param name="loopCount">循环次数</param>  
        public MyThreadParameter(int interval, int loopCount)
        {
            this.interval = interval;
            this.loopCount = loopCount;
            thread = new Thread(new ThreadStart(Run));
        }

        public void Start()
        {
            if (thread != null)
            {
                thread.Start();
            }
        }

        private void Run()
        {
            for (int i = 0; i < loopCount; i++)
            {
                Console.WriteLine("Class parameters system current milliiseconds ：" + DateTime.Now.Millisecond.ToString());
                Thread.Sleep(interval);//让线程暂停  
            }
        }
    }  
}
