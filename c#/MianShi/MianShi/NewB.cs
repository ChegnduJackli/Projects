using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MianShi
{
    class NewB
    {
        public void Test() 
        {
            new B1().PrintFields();
        }
    }

    public class A1
    {
        public A1()
        {
            PrintFields();
        }
        public virtual void PrintFields() { }
    }
    public class B1 : A1
    {
        int x = 1;
        int y;
        public B1()
        {
            y = -1;
        }
        public override void PrintFields()
        {
            Console.WriteLine("x={0},y={1}", x, y);
        }
    }
}