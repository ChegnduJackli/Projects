using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//具体的聚集，它实现了抽象聚集中的唯一的方法，同时在里面保存了一组数据，这里我们加上Length属性和GetElement()方法是为了便于访问聚集中的数据。
namespace IteratorPattern
{
    public class ConcreteList : IList
    {
        int[] list;

        public ConcreteList()
        {
            list = new int[] {1,2,3,4,5,6 };
        }
        public IIterator GetIterator()
        {
            return new ConcreteIterator(this);
        }
        public int Length
        {
            get { return list.Length; }
        }

        public int GetElement(int index)
        {
            return list[index];
        }
    }
}
