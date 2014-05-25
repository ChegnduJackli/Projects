using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Strategy
{
    public class MergeSort : SortStrategy //这里是算法类
    {

        public override void Sort(ArrayList list)
        {
            list.Sort();
            Console.WriteLine("MergeSorted  list");
        }
    }
}
