using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//具体迭代器，实现了抽象迭代器中的四个方法，在它的构造函数中需要接受一个具体聚集类型的参数，在这里面我们可以根据实际的情况去编写不同的迭代方式。
namespace IteratorPattern
{
    public class ConcreteIterator : IIterator
    {
        private ConcreteList list;
        private int index;

        public ConcreteIterator(ConcreteList list)
        {
            this.list = list;
            index = 0;
        }
        public bool MoveNext()
        {
            if (index < list.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public object CurrentItem()
        {
            return list.GetElement(index);
        }

        public void First()
        {
            index = 0;
        }

        public void Next()
        {
            if (index < list.Length)
            {
                index++;
            }
        }
    }
}
