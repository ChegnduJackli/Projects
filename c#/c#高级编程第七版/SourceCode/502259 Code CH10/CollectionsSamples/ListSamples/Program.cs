using System.Collections.Generic;
using System;
namespace Wrox.ProCSharp.Collections
{
    class Program
    {
        static void Main()
        {
            var graham = new Racer(7, "Graham", "Hill", "UK", 14);
            var emerson = new Racer(13, "Emerson", "Fittipaldi", "Brazil", 14);
            var mario = new Racer(16, "Mario", "Andretti", "USA", 12);

            var racers = new List<Racer>(20) { graham, emerson, mario };

            racers.Add(new Racer(24, "Michael", "Schumacher", "Germany", 91));
            racers.Add(new Racer(27, "Mika", "Hakkinen", "Finland", 20));
            racers.Add(new Racer(17, "Jack", "ss", "Austria", 22));

            racers.AddRange(new Racer[] {
               new Racer(14, "Niki", "Lauda", "Austria", 25),
               new Racer(21, "Alain", "Prost", "France", 51)});

            var racers2 = new List<Racer>(new Racer[] {
               new Racer(12, "Jochen", "Rindt", "Austria", 6),
               new Racer(14, "Jack", "dd", "Austria", 63),
               new Racer(22, "Ayrton", "Senna", "Brazil", 41) });

            //这个比较实用
            racers.ForEach(r=>Console.WriteLine("{0:A}",r));
            racers.ForEach(r => Console.WriteLine("{0}", r.FirstName));
            racers.ForEach(ActionHandler);
            //排序
            Console.WriteLine("-----------Order---------");
            racers.Sort(new RacerComparer(CompareType.Country));
            racers.ForEach(ActionHandler);
            Console.WriteLine("-----------OverLoad Order---------");
            racers.Sort((r1, r2) => r2.Wins.CompareTo(r1.Wins));
            racers.ForEach(r=>Console.WriteLine("{0}",r.Wins));
            Console.ReadKey();

        }
        //List.ForEach()
        //Action 无返回类型的委托，参数是Racer类型
        public static void ActionHandler(Racer obj)
        {
            Console.WriteLine("Country:{0}, LastName:{1}",obj.Country,obj.LastName);
        }
    }
}
