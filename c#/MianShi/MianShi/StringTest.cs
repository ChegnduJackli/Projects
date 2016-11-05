using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MianShi
{
    class StringTest
    {
        public static void Test()
        {
            string a = "hello";
            string b = "h";
            // Append to contents of 'b'
            b += "ello";
            Console.WriteLine(a == b);//定义相等运算符（== 和 !=）是为了比较 string 对象（而不是引用）的值, return true
            Console.WriteLine((object)a == (object)b); //return false

        }
    }
}
