using System;

namespace FactorySalary
{
	/// <summary>
	/// 个人所得税抽象类
	/// </summary>
	public abstract class Tax
	{
		public abstract double Calculate();
	}
}
