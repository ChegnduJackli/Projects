using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractClass;
namespace AmericalSalary
{
    /// <summary>
    /// 计算美国奖金
    /// </summary>
    public class AmericanBonus : Bonus
    {
        public override double Calculate()
        {
            return Constant.BASE_SALARY * 0.1;
        }
    }
}
