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
            Email_Investor inv1=new Email_Investor("Jom", ms);
            //添加投资者
            ms.AddObserver(inv1);
            Email_Investor inv2=new Email_Investor("TerryLee", ms);
            //添加投资者
            ms.AddObserver(inv2);

            ms.Update();

            ms.RemoveObserver(inv1);
            ms.RemoveObserver(inv2);

            Console.WriteLine("移除微软公司的股票");
            Console.WriteLine("添加谷歌公司的股票");

            Stock google = new Google("Google", 230.00);
            inv1 = new Email_Investor("Jom", google);
            //添加投资者
            ms.AddObserver(inv1);
            inv2 = new Email_Investor("TerryLee", google);
            ms.AddObserver(inv2);
            ms.Update();

            Console.WriteLine("use mobile to send notification");
            //手机观察者
            Mobile_Investor mobile = new Mobile_Investor("138808456", google);
            ms.AddObserver(mobile);
            ms.Update();
            Console.ReadLine();
        }
    }
}
