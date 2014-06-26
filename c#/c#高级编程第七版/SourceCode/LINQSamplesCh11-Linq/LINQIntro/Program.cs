using System;
using System.Collections.Generic;
using System.Linq;

namespace Wrox.ProCSharp.LINQ
{
    class Program
    {
        static void Main()
        {
            LINQQuery();
            ExtensionMethods();
            DeferredQuery();
            Query();
            Console.ReadKey();
        }   
        static void Query()
        {
            //迭代在查询定义时不会进行，而是在执行每个foreach语句时进行
            Console.WriteLine("----------Use ToList-------------");
            var names = new List<string> { "Nino", "Alberto", "Juan", "Mike", "Phil" };
            var namesWithJ = (from n in names
                              where n.StartsWith("J")
                              orderby n
                              //select n); //第一次和第二次不一样
                             select n).ToList();  //第一次和第二次结果一样
            Console.WriteLine();
            Console.WriteLine("First iteration");
            foreach (string name in namesWithJ)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();

            names.Add("John");
            names.Add("Jim");
            names.Add("Jack");
            names.Add("Denny");

            Console.WriteLine("Second iteration");
            foreach (string name in namesWithJ)
            {
                Console.WriteLine(name);
            }
        }
        static void DeferredQuery()
        {
            var names = new List<string> { "Nino", "Alberto", "Juan", "Mike", "Phil" };

            var namesWithJ = from n in names
                             where n.StartsWith("J")
                             orderby n
                             select n;
            
            Console.WriteLine("First iteration");
            foreach (string name in namesWithJ)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();

            names.Add("John");
            names.Add("Jim");
            names.Add("Jack");
            names.Add("Denny");

            Console.WriteLine("Second iteration");
            foreach (string name in namesWithJ)
            {
                Console.WriteLine(name);
            }

        }
        //扩展方法
        static void ExtensionMethods()
        {
            var champions = new List<Racer>(Formula1.GetChampions());
            IEnumerable<Racer> brazilChampions =
                champions.Where(r => r.Country == "Brazil").    //and use &&
                        OrderByDescending(r => r.Wins).
                        Select(r => r);

            foreach (Racer r in brazilChampions)
            {
                Console.WriteLine("{0:A}", r);
            }
        }


        static void LINQQuery()
        {
            var query = from r in Formula1.GetChampions()
                        where r.Country == "Brazil"  //and use &&
                        orderby r.Wins descending
                        select r;
            foreach (var r in query)
            {
                Console.WriteLine("{0:A}", r);
            }

        }
    }
}
