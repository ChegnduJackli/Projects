using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BridgePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //.NET平台下的Database Log

            Log dblog = new DatabaseLog();

            dblog.PlateForm = new NetPlatform();

            dblog.Write("net good job");



            //Java平台下的Text File Log

            Log txtlog = new TextFileLog();

            txtlog.PlateForm = new JavaPlatform();

            txtlog.Write("java bad job");

            Console.ReadKey();
        }
    }
}
