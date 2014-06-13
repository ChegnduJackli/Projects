using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//一旦定义了委托类，基本上就可以实例化他的实例，就像处理一般的类那样
//所以把一些委托类的实例放在数组中是可以的。
namespace Test3
{
    delegate double DoubleOp(double x);
    class Program
    {
        static void Main(string[] args)
        {
            DoubleOp[] operations = { MathOperations.MultiplyByTwo,
                                    MathOperations.Square};
            for (int i = 0; i < operations.Length; i++)
            {
                Console.WriteLine("using operations[{0}]", i);
                ProcessAndDisplayNumber(operations[i], 2.0);
                ProcessAndDisplayNumber(operations[i], 7.94);
                ProcessAndDisplayNumber(operations[i], 1.414);
                Console.WriteLine();
            }
            //另外一种方式
            //调用带返回类型的方法，Action<T>不带返回类型
            Func<double, double>[] Oper = { MathOperations.MultiplyByTwo,
                                    MathOperations.Square};

            for (int i = 0; i < Oper.Length; i++)
            {
                Console.WriteLine("using Oper[{0}]", i);
                Process(Oper[i], 2.0);
                Process(Oper[i], 7.94);
                Process(Oper[i], 1.414);
                Console.WriteLine();
            }

            Console.ReadKey();
        }
        static void ProcessAndDisplayNumber(DoubleOp action, double value)
        {
            double result = action(value);
            Console.WriteLine("value is {0},result of operation is {1}", value, result);
        }
        static void Process(Func<double, double> action, double value)
        {
            double result = action(value);
            Console.WriteLine("value is {0},result of operation is {1}", value, result);
        }
    }
    class MathOperations
    {
        public static double MultiplyByTwo(double value)
        {
            return value * 2;
        }
        public static double Square(double value)
        {
            return value * value;
        }
    }
}
