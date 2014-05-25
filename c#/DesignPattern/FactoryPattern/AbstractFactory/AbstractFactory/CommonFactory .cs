using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory
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