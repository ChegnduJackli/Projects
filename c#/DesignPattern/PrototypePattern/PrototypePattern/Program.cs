using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
