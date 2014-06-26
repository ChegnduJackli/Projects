using System;
using System.Collections.Generic;
using System.Linq;

namespace Wrox.ProCSharp.Collections
{
    class Program
    {
        static void Main()
        {
            var racers = new List<Racer>();
            racers.Add(new Racer(26, "Jacques", "Villeneuve", "Canada", 11));
            racers.Add(new Racer(18, "Alan", "Jones", "Australia", 12));
            racers.Add(new Racer(11, "Jackie", "Stewart", "United Kingdom", 27));
            racers.Add(new Racer(15, "James", "Hunt", "United Kingdom", 10));
            racers.Add(new Racer(5, "Jack", "Brabham", "Australia", 14));
            racers.Add(new Racer(25, "Adi", "ADDD", "Australia", 28));

            var lookupRacers = racers.ToLookup(r => r.Country);

            foreach (Racer r in lookupRacers["Australia"])
            {
                Console.WriteLine(r);
            }
            // public delegate bool Predicate<T>(T obj);
            int index = racers.FindIndex(new FindCountry("Australia").FindCountryPredicate);
            Console.WriteLine("index:{0}",index);
            //下面是等价的
            int index2 = racers.FindIndex(r => r.Country == "Australia");
            Console.WriteLine("index2:{0}", index2);
            //返回第一个匹配的
            //FindLast 最后一个匹配的
            Console.WriteLine("Find get first match object");
            Racer racerFirst = racers.Find(c => c.Country == "Australia");
            Console.WriteLine(racerFirst.FirstName);
            Console.WriteLine(racerFirst.LastName);

            Console.WriteLine("FindLast get last match object");
            Racer racerLast = racers.FindLast(c => c.Country == "Australia");
            Console.WriteLine(racerLast.FirstName);
            Console.WriteLine(racerLast.LastName);

            Console.WriteLine("FindAll get All match object");
            List<Racer> racerAll = racers.FindAll(r => r.Wins > 20);
            foreach (Racer r in racerAll)
            {
                Console.WriteLine("{0:A}",r);
            }
            Console.ReadKey();
            
        }
    }
}
