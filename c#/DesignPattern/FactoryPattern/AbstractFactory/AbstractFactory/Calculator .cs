
using System;

namespace AbstractFactory
{
	/// <summary>
	/// 客户端程序调用
	/// </summary>
	public class Calculator 
	{
		public static void Main(string[] args) 
		{
            //AbstractFactory af;
            //AbstractFactory abs = af.GetInstance();
            //abs.CreateBonus();
            AbstractFactory af = new CommonFactory();
           AbstractFactory afc = af.GetInstance();
           Bonus bonus = af.CreateBonus();
           double bonusValue = bonus.Calculate();
            //Bonus bonus = new ChineseBonus();
            //double bonusValue  = bonus.Calculate();

            Tax tax = af.CreateTax();
            double taxValue = tax.Calculate();
	
			double salary = Constant.BASE_SALARY + bonusValue - taxValue; 

			Console.WriteLine("Salary is：" + salary);
			Console.ReadLine();
		}
	}
}
