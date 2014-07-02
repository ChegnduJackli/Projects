using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//和所有类类型一样，当加载引用静态类的程序时，.NET Framework 公共语言运行时 (CLR) 将加载该静态类的类型信息。
//程序不能指定加载静态类的确切时间。 但是，可以保证在程序中首次引用该类前加载该类，并初始化该类的字段并调用其静态构造函数。
//静态构造函数仅调用一次，在程序驻留的应用程序域的生存期内，静态类一直保留在内存中。
namespace StringExtension
{
    public static class StringExtension
    {
        public static bool IsNullOrEmpty(this string s)
        {
            return s == null || s.Length == 0;
        }

        public static bool IsInt(this string s)
        {
            int i;
            return int.TryParse(s, out i);
        }

        public static int ToInt(this string s)
        {
            return int.Parse(s);
        }

    }
}
