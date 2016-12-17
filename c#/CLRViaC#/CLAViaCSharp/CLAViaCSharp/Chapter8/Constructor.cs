using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLAViaCSharp
{
    class Constructor
    {
        private Int32 m_x = 5;
        public void Test()
        {
            Rectangle t = new Rectangle();

            SomeType st = new SomeType();
            st.run1();
            st.run2();
            SomeType.run3();
        }
    }
    internal struct Point
    {
        public int m_x, m_y;
        //结构中不能有实例字段初始值设定项
        //private int m_z = 10;
        public Point(int x, int y)
        {
            m_x = x;
            m_y = y;
            Console.WriteLine("m_x: " + m_x + " m_y:" + m_y);
        }
        //结构体不能包括无参构造器
        //public Point()
        //{
        //    m_x = m_x = m_y = 5;
        //}
    }

    internal sealed class Rectangle
    {
        public Point m_topLeft, m_bottomRight;
        public Rectangle()
        {
        }
    }

    //静态构造器，类型构造器
    internal class SomeType
    {
        //类型构造器是线程安全的，所以非常适合在类型构造器中初始化类型需要的任何单实例对象
        static SomeType()
        {
            Console.WriteLine("Static sometype executed");
        }

        public void run1()
        {
            Console.WriteLine("SomeType.run1");
        }
        public void run2()
        {
            Console.WriteLine("SomeType.run2");
        }
        public static void run3()
        {
            Console.WriteLine("SomeType.run3");
        }
    }
}
