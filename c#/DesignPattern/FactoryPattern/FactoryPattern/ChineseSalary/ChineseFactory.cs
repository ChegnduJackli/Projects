using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractClass;

namespace ChineseSalary
{
    /// <summary>
    /// ChineseFactory类
    /// </summary>
    public class ChineseFactory : AbstractFactory
    {
        public override Tax CreateTax()
        {
            return new ChineseTax();
        }

        public override Bonus CreateBonus()
        {
            return new ChineseBonus();
        }
    }
}
