using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLAViaCSharp.chapter9
{
    public class swap
    {
        public string Name { get; }

        public void Set()
        {
            //this.Name = "1";
        }
        public static void Swap(ref object a, ref object b)
        {
            object t = b;
            b = a;
            a = t;
        }

        public static void Swap1<T>(ref T a, ref T b)
        {
            T t = b;
            b = a;
            a = t;
        }

        static Int32 Add(params Int32[] values)
        {
            Int32 sum = 0;
           
            if (values != null)
            {
                for (Int32 x = 0; x < values.Length; x++)
                {
                    sum += values[x];
                }
            }
            return sum;
        }
        public static void Test()
        {
            string s1 = "abc";
            string s2 = "def";
            //Swap(ref s1, ref s2);  //无法将ref string 转换为ref object
            object o1 = s1;
            object o2 = s2;
            Swap(ref o1, ref o2);
            Console.WriteLine(o1.ToString() +" : "+o2.ToString());

           // Swap1<string>(ref s1, ref s2); //跟下面一样
            Swap1(ref s1, ref s2);
            Console.WriteLine(s1 + " : " + s2);

            Console.WriteLine(Add(new Int32[] { 1, 2, 3, 4 }));
            Console.WriteLine(Add(1,2,3,4));
        }
    }

}
