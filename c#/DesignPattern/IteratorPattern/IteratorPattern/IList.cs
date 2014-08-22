using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//首先有一个抽象的聚集，所谓的聚集就是就是数据的集合，可以循环去访问它。它只有一个方法GetIterator()让子类去实现，用来获得一个迭代器对象。
namespace IteratorPattern
{
    public interface IList
    {
        IIterator GetIterator();
    }
}
