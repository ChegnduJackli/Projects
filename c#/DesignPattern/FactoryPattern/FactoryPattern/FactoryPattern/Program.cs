using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractClass;
using System.Configuration;

namespace FactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
           // string dllName = ConfigurationSettings.AppSettings["DllName"];
           // string dllNamespaceName = ConfigurationSettings.AppSettings["DllSpaceName"];
            AbstractFactory af = new CommonFactory();
            
            AbstractFactory afc = af.GetInstance();
            Bonus bonus = af.CreateBonus();
            double bonusValue = bonus.Calculate();

            Tax tax = af.CreateTax();
            double taxValue = tax.Calculate();

            double salary = Constant.BASE_SALARY + bonusValue - taxValue;

            Console.WriteLine("Salary is：" + salary);
            Console.ReadLine();
        }
    }
}
