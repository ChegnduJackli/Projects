using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Strategy
{
    public class SortedList
    {
        private SortStrategy sortsStrategy;
        private ArrayList list = new ArrayList();

        public void SetStrategy(SortStrategy strategy)
        {
            this.sortsStrategy = strategy;
        }
        public void Sort()
        {
            sortsStrategy.Sort(list);
        }

        public void Add(string name)
        {
            list.Add(name);
        }

        public void Display()
        {
            foreach (string name in list)
                Console.WriteLine(" " + name);
        }
    }
}
