using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MianShi
{
    public class AdapterTest
    {
        public static void Test()
        {
            Targetable t = new Adapter();
            t.Method1();
            t.Method2();
        }
    }

	public class Adapter : Source, Targetable
	{
        public void Method2()
        {
            Console.WriteLine("This is the adapter Method2. ");
        }

        public  void Method1()
        {
            Console.WriteLine("Adapter Method1");
        }
	}

    public class Source
    {
        public void Method1()
        {
            Console.WriteLine("this is original method1.");
        }
    }

    public interface Targetable
    {
         void Method1();
         void Method2();
    }

   
}
