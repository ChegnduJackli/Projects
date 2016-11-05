using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MianShi
{
    class AsorIs
    {
        public static void Test()
        {
            /*
1, AS在转换的同事兼判断兼容性，如果无法进行转换，则 as 返回 null（没有产生新的对象）而不是引发异常。有了AS我想以后就不要再用try-catch来做类型转换的判断了。因此as转换成功要判断是否为null。
2、AS是引用类型类型的转换或者装箱转换，不能用与值类型的转换。如果是值类型只能结合is来强制转换
            */
            object objTest = 11;
            if (objTest is Int32)
            {
                int nValue = (int)objTest;
                Console.WriteLine("convert success");
            }
            //值类型不可以用as做转换
            //int x = objTest as Int32;
        }
    }
}
