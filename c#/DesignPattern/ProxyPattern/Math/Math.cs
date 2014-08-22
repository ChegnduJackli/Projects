using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Math
{
    public class Math : IMath.IMath
    {
        public double Add(double x, double y)
        {
            return x + y;
        }

        public double Sub(double x, double y)
        {
            return x - y;
        }

        public double Mul(double x, double y)
        {
            return x * y;
        }

        public double Dev(double x, double y)
        {
            return x / y;
        }
    }
}
