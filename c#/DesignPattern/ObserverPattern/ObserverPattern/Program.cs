using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObserverPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Stock ms = new Microsoft("Microsoft", 120.00);
            Investor inv1=new Investor("Jom", ms);
            //添加投资者
            ms.AddObserver(inv1);
            Investor inv2=new Investor("TerryLee", ms);
            //添加投资者
            ms.AddObserver(inv2);

            ms.Update();

            ms.RemoveObserver(inv1);
            ms.RemoveObserver(inv2);

            Console.WriteLine("移除微软公司的股票");
            Console.WriteLine("添加谷歌公司的股票");

            Stock google = new Google("Google", 230.00);
            inv1 = new Investor("Jom", google);
            //添加投资者
            ms.AddObserver(inv1);
            inv2 = new Investor("TerryLee", google);
            ms.AddObserver(inv2);
            ms.Update();
            Console.ReadLine();
        }
    }
}
