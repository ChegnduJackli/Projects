using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Reflection;

namespace LogWrite
{
    class Program
    {
        static void Main(string[] args)
        {
         //   LogFactory factory = new EventFactory();
           //LogFactory factory = new FileFactory();
           // Log log = factory.Create();
           // log.Write();
           // Console.ReadLine();



            string dllName = ConfigurationSettings.AppSettings["factoryName"];
            //spacename + className
            string spaceName = ConfigurationSettings.AppSettings["factorySPaceName"];
            LogFactory factory;
            Assembly ass;
            string sDllPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dllName);
            //加载dll 文件
            ass = System.Reflection.Assembly.LoadFrom(sDllPath);
            //获取dll文件的实例
            //if (dllName.Length > 0 && spaceName.Length > 0)
            //    factory = (LogFactory)ass.CreateInstance(spaceName);
            //else
            //    factory = null;

            factory = (LogFactory)Assembly.LoadFrom(sDllPath).CreateInstance(spaceName);

            Log log = factory.Create();
            log.Write();
            Console.ReadLine();
        }
    }
}
