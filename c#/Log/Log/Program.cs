using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Log4;
namespace Log
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime begin = DateTime.Now;
            //ILog log = new FileLog();
            for (int i = 0; i < 1000; i++)
            {
                 Log4.LogInstance.FileLogInstance().WriteLog("good work" + i.ToString());
                 Log4.LogInstance.FileLogInstance().ErrorLog("bad work"+i.ToString());
             
                //log.WriteLog("good work"+i.ToString());
                //log.ErrorLog("bad work" + i.ToString());
            }
            
            DateTime end = DateTime.Now;
            TimeSpan timespan = end.Subtract(begin);
            Console.WriteLine(timespan.Seconds);
            Console.ReadKey();

        }
    }
}
