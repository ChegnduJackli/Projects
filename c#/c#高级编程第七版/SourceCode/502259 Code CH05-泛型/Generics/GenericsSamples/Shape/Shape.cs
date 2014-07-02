using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shape
{
    //out 支持协变（子类可以赋给父类）
    public interface ICovariant<in T>
    {
    }

    public class Sharp : ICovariant<Sharp>
    {
    }

    public class Rectange : Sharp, ICovariant<Rectange>
    {
    } 
}
