using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace AbstractClass
{
    /// <summary>
    /// 公用的常量
    /// </summary>
    public class Constant
    {
        public static double BASE_SALARY = 4000;

        public static string dllName = "ChineseSalary.dll";
        public static string dllNamespaceName = "ChineseSalary.ChineseFactory";

        //public static string dllName = ConfigurationSettings.AppSettings["DllName"];
        //public static string dllNamespaceName = ConfigurationSettings.AppSettings["DllSpaceName"];
    }
}
