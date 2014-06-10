using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*
 
 动机(Motivate):
    组合模式有时候又叫做部分-整体模式，它使我们树型结构的问题中，模糊了简单元素和复杂元素的概念，客户程序可以向处理简单元素一样来处理复杂元素,
   从而使得客户程序与复杂元素的内部结构解耦。
意图(Intent):
    将对象组合成树形结构以表示“部分-整体”的层次结构。Composite模式使得用户对单个对象和组合对象的使用具有一致性。
 */
namespace CompositePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Picture root = new Picture("Root");
            root.Add(new Line("Line"));
            root.Add(new Circle("Circle"));
            Rectangle r = new Rectangle("Rectangle");
            root.Add(r);
            root.Draw();
            root.Controls.Add(r);
            
        }
    }
}
