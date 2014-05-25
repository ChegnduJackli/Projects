using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractClass;

namespace AmericalSalary
{
    /// <summary>
    /// AmericanFactory类
    /// </summary>
    public class AmericanFactory : AbstractFactory
    {
        public override Tax CreateTax()
        {
            return new AmericanTax();
        }

        public override Bonus CreateBonus()
        {
            return new AmericanBonus();
        }
    }
}
