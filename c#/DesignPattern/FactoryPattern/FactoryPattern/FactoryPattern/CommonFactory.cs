using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractClass;

namespace FactoryPattern
{
    public class CommonFactory : AbstractFactory
    {
        public override Tax CreateTax()
        {
            return GetInstance().CreateTax();
        }

        public override Bonus CreateBonus()
        {
            return GetInstance().CreateBonus();
        }
    }
}
