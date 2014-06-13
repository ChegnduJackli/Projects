using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LambdaSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Sample();
            Console.ReadKey();
        }
        static void Sample()
        {
            Func<string, string> oneParam = s => string.Format("change  upper {0}", s.ToUpper());
            Console.WriteLine(oneParam("good job"));

            Func<double, double, double> twoParam = (x, y) => x * y;
            Console.WriteLine(twoParam(12, 22));

            //为了方便，可以给变量名加上参数类型。
            Func<double, double, double> twoParamWithType = (double x, double y) => x * y;

            int someVal = 5;
            //如果只有一行代码，方法块不需要花括号和添加return 语句。因为编译器会自动添加一条隐私的return 语句.
            Func<int, int> f = x => x + someVal;
            Console.WriteLine(f(5));

            //添加花括号和return语句更加容易阅读，推荐添加.
            Func<int, int> Square = x =>
                {
                    return x * x;
                };
            Console.WriteLine(Square(5));
        }
    }
}
