using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdapterPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //用write方法调用writeLog方法的包装
            ILogTarget dbLog = new LogAdapter(new DatabaseLog());
            dbLog.Write();
            ILogTarget fileLog = new LogAdapter(new FileLog());
            fileLog.Write();
            //fileLog
            LogAdaptee fileLog1 = new FileLog();
            fileLog1.WriteLog();
            Console.ReadLine();
        }
    }
}
