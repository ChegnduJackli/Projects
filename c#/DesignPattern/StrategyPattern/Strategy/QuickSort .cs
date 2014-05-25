using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strategy
{
    public class QuickSort : SortStrategy //这里是算法类 
    {
        public override void Sort(System.Collections.ArrayList list)
        {
            list.Sort();
            Console.WriteLine("QuickSorted  list");
        }
    }
}
