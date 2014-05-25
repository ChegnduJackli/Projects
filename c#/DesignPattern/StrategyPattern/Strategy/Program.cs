using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//策略模式的用意是针对一组算法，将每一个算法封装到具有共同接口的独立的类中，
//从而使得它们可以相互替换。策略模式使得算法可以在不影响到客户端的情况下发生变化。
namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedList sortList = new SortedList();
            sortList.Add("A");
            sortList.Add("B");
            sortList.Add("V");
            sortList.Add("S");
            sortList.SetStrategy(new ShellSort());
            sortList.Sort();
            sortList.Display();
            Console.ReadKey();
        }
    }
}
