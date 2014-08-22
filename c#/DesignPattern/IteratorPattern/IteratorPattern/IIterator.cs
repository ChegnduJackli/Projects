using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

 //抽象的迭代器，它是用来访问聚集的类，封装了一些方法，用来把聚集中的数据按顺序读取出来。
 //通常会有MoveNext()、CurrentItem()、Fisrt()、Next()等几个方法让子类去实现。
namespace IteratorPattern
{
   public interface IIterator
    {
        bool MoveNext();

        Object CurrentItem();

        void First();

        void Next();
    }
}
