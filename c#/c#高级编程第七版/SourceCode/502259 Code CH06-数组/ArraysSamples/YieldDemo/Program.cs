using System;
using System.Collections;
using System.Collections.Generic;

//要想使用Foreach语句，必须返回IEnumerator接口
//Foreach语句使用IEnumerator接口的方法和属性
//foreach语句并不针真的需要在集合类中实现这个接口，有一个名为GetEnumerator()的方法
//它返回实现了IEnumerator接口的对象就足够了
namespace Wrox.ProCSharp.Arrays
{
    public class HelloCollection
    {
        public IEnumerator<string> GetEnumerator()
        {
            yield return "Hello";
            yield return "World";
        }
    }


    class Program
    {
        static void Main()
        {
            HelloWorld();
            MusicTitles();

            var game = new GameMoves();


            IEnumerator enumerator = game.Cross();
            while (enumerator.MoveNext())
            {
                enumerator = enumerator.Current as IEnumerator;
            }
            Console.ReadKey();


        }

        static void MusicTitles()
        {
            var titles = new MusicTitles();
            foreach (var title in titles)
            {
                Console.WriteLine(title);
            }
            Console.WriteLine();

            Console.WriteLine("reverse");
            foreach (var title in titles.Reverse())
            {
                Console.WriteLine(title);
            }
            Console.WriteLine();

            Console.WriteLine("subset");
            foreach (var title in titles.Subset(2, 2))
            {
                Console.WriteLine(title);
            }

        }

        static void HelloWorld()
        {
            var helloCollection = new HelloCollection();
            foreach (string s in helloCollection)
            {
                Console.WriteLine(s);
            }
        }
    }
}
