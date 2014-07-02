using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//below is good article
//http://blog.csdn.net/sudazf/article/details/17148971
namespace Shape
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            ICovariant<Sharp> isharp = new Sharp();
            ICovariant<Rectange> irect = new Rectange();

            //要使下面的语句成立，需要将接口声明为Out
            //如果一个泛型接口IFoo<T>，IFoo<TSub>可以转换为IFoo<TParent>的话，我们称这个过程为协变，而且说“这个泛型接口支持对T的协变”。
            isharp = irect;
            */

            //那我如果反过来呢，考虑如下代码：
            ICovariant<Sharp> isharp = new Sharp();
            ICovariant<Rectange> irect = new Rectange();
            //要使下面的语句成立，需要将接口声明为In
            //如果一个泛型接口IFoo<T>，IFoo<TParent>可以转换为IFoo<TSub>的话，我们称这个过程为抗变（contravariant），而且说“这个泛型接口支持对T的抗变”！
            irect = isharp;
            Console.ReadLine();
        }
    }
}
