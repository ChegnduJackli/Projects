using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProxyPattern
{
     /*
     * 现在可以说我们已经实现了对Math类的代理，存在的一个问题是我们在MathProxy类中调用了原实现类Math的方法
     * 但是Math并不一定实现了所有的方法，为了强迫Math类实现所有的方法，另一方面，为了我们更加透明的去操作对象，
     * 我们在Math类和MathProxy类的基础上加上一层抽象，即它们都实现与IMath接口
     */
    public class MathProxy : IMath.IMath
    {
        private Math.Math math = new Math.Math();

        // 以下的方法中，可能不仅仅是简单的调用Math类的方法

        public double Add(double x, double y)
        {
            return math.Add(x, y);
        }

        public double Sub(double x, double y)
        {
            return math.Sub(x, y);
        }

        public double Mul(double x, double y)
        {
            return math.Mul(x, y);
        }

        public double Dev(double x, double y)
        {
            return math.Dev(x, y);
        }
    }
}
