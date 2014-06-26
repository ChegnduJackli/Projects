using System;
using System.Collections.Generic;

//栈跟队列类似，但是是先进后出
namespace Wrox.ProCSharp.Collections
{
    class Program
    {
        static void Main()
        {
            var alphabet = new Stack<char>();
            alphabet.Push('A');
            alphabet.Push('B');
            alphabet.Push('C');

            Console.Write("First iteration: ");
            foreach (char item in alphabet)
            {
                Console.Write(item);
            }
            Console.WriteLine();

            Console.Write("Second iteration: ");
            while (alphabet.Count > 0)
            {
                //使用pop方法会从栈中取出元素，然后删除它们。
                Console.Write(alphabet.Pop());
            }
            //现在就没有元素了
            foreach (char item in alphabet)
            {
                Console.Write(item);
            }
            Console.WriteLine();
            Console.ReadKey();

        }
    }
}
