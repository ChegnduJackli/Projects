using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractClass;

namespace AmericalSalary
{
    /// <summary>
    /// 计算美国个人所得税
    /// </summary>
    public class AmericanTax : Tax
    {
        public override double Calculate()
        {
            return (Constant.BASE_SALARY + (Constant.BASE_SALARY * 0.1)) * 0.4;
        }
    }
}
