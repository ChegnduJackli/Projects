using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MianShi
{
    static class StaticClass
    {
        /*
1：静态类可以有静态构造函数，静态构造函数不可继承；
2：静态构造函数可以用于静态类，也可用于非静态类；
3：静态构造函数无访问修饰符、无参数，只有一个 static 标志；
4：静态构造函数不可被直接调用，当创建类实例或引用任何静态成员之前，静态构造函数被自动执行，并且只执行一次。
         */
        static StaticClass()
        {
            Console.WriteLine("Static Class Constructor.");
        }
        public static void Test1()
        {
            Console.WriteLine("Test1");
        }
        public static void Test2()
        {
            Console.WriteLine("Test2");
        }
        //静态类不能包含实例方法
        //public void Test2()
        //{
        //    Console.WriteLine("Test2");
        //}
        //静态类不可以包括实例构造函数
        //public StaticClass()
        //{
 
        //}
    }
    //静态类是密封的，不可以被继承
    //class Static2 : StaticClass
    //{
 
    //}
}
