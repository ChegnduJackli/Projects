using System;

namespace AbstractFactory
{
	/// <summary>
	/// AmericanFactory¿‡
	/// </summary>
	public class AmericanFactory:AbstractFactory
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
