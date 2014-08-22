using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace IteratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            IIterator iterator;
            IList list = new ConcreteList();
            iterator = list.GetIterator();
            while (iterator.MoveNext())
            {
                int i = (int)iterator.CurrentItem();
                Console.WriteLine(i.ToString());

                iterator.Next();
            }

            Persons arrPersons = new Persons("Michel", "Christine", "Mathieu", "Julien");

            foreach (string s in arrPersons)
            {
                Console.WriteLine(s);
            }
            Console.Read();
        }
    }
}
