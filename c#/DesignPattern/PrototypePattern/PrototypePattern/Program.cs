using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * 意图

　　用原型实例指定创建对象的种类，并且通过拷贝这些原型创建新的对象。

　　场景

　　游戏场景中的有很多相似的敌人，它们的技能都一样，但是随着敌人出现的位置不同，这些人的能力不太一样。假设，我们现在需要把三个步兵组成一队，其中还有一个精英步兵，能力特别高。那么，你或许可以创建一个敌人抽象类，然后对于不同能力的步兵创建不同的子类。然后，使用工厂方法等设计模式让调用方依赖敌人抽象类。

　　问题来了，如果有无数种能力不同步兵，难道需要创建无数子类吗?还有，步兵模型的初始化工作是非常耗时的，创建这么多步兵对象可能还会浪费很多时间。我们是不是可以通过只创建一个步兵原型，然后复制出多个一摸一样的步兵呢?复制后，只需要调整一下这些对象在地图上出现的位置，或者调整一下它们的能力即可。原型模式就是用来解决这个问题的。
 */
namespace ColorPrototype
{
    class Program
    {
        static void Main(string[] args)
        {
            ColorManager colormanager = new ColorManager();
            //初始化颜色
            colormanager["red"] = new ConcteteColorPrototype(255, 0, 0);
            colormanager["green"] = new ConcteteColorPrototype(0, 255, 0);
            colormanager["blue"] = new ConcteteColorPrototype(0, 0, 255);
            colormanager["angry"] = new ConcteteColorPrototype(255, 54, 0);
            colormanager["peace"] = new ConcteteColorPrototype(128, 211, 128);
            colormanager["flame"] = new ConcteteColorPrototype(211, 34, 20);
            //使用颜色
            string colorName = "red";
            ConcteteColorPrototype c1 = (ConcteteColorPrototype)colormanager[colorName].Clone();
            c1.Display(colorName);
            colorName = "peace";
            ConcteteColorPrototype c2 = (ConcteteColorPrototype)colormanager[colorName].Clone();
            c2.Display(colorName);
            colorName = "flame";
            ConcteteColorPrototype c3 = (ConcteteColorPrototype)colormanager[colorName].Clone();
            c3.Display(colorName);
            Console.ReadLine();
        }
    }
}
