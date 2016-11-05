using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MianShi
{
    class Testfinally
    {
        public static void Run()
        {
          // Console.WriteLine( Test1());
           List<string> strList = GetList();
           foreach (string s in strList)
           {
               Console.WriteLine("s:" + s);
           }
        }
        public int GetNumber()
        {
            int i = 10;
            try
            {
                return i;
            }

            catch (Exception ex)
            {
            }
            finally
            {
                i = 100;
               // return i;
            }
            return i;
                
        }

        public static string Test1()
        {
            try
            {
                Console.WriteLine("try block");
                return Test2();
            }
            finally
            {
                Console.WriteLine("finally block");
            }
        }
        public static string Test2()
        {
            Console.WriteLine("Test 2 bock");
            return "after return";
        }

        public static List<string> GetList()
        {
            List<string> strList = new List<string>();
            try
            {
                strList.Add("1");
                strList.Add("2");
                strList.Add("3");
            
            }
            finally
            {
                strList.Add("4");
                //引用类型返回改变后的值，因为地址不变，而对象的值改变了。
            }
            return strList;

        }
    }
}
