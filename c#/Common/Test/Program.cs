using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            FileUtil.FileDAL.WriteToFile("D:\\test1\\test1.txt","test messsage");

            //Thread th1 = new Thread(new ThreadStart(Beta));
            //Thread th2 = new Thread(new ThreadStart(Beta));
            //Thread th3 = new Thread(new ThreadStart(Beta));
            //th1.Start();
            //th2.Start();
            //th3.Start();
        }
        public static void Beta()
        {
            string logDir = "C:\\";
            for (int i = 0; i < 1000; i++)
            {
                Log.LogHelper.LogInfo(logDir, "tesstasdf: " + i);
                Log.LogHelper.LogInfo(logDir, "tesstasdf: " + i * i);
                Log.LogHelper.LogError(logDir, "erroreor: " + i * i);
                Log.LogHelper.LogError(logDir, "erroreor+" + i * i + 123);
            }
        }
    }
}
