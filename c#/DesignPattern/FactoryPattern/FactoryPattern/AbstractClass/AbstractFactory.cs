using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using AbstractClass;

namespace AbstractClass
{
    /// <summary>
     /// AbstractFactory类
     /// </summary>
     public abstract class AbstractFactory
    {
        public  AbstractFactory GetInstance()
        {
            try
            {
                string dllName = Constant.dllName.ToString();
                string spaceName = Constant.dllNamespaceName.ToString();
                AbstractFactory instance;
                Assembly ass;
                string sDllPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dllName);
                //加载dll 文件
                ass = System.Reflection.Assembly.LoadFrom(sDllPath);
                //获取dll文件的实例
                if (dllName.Length > 0 && spaceName.Length > 0)
                    instance = (AbstractFactory)ass.CreateInstance(spaceName);
                else
                    instance = null;
                return instance;

            }
            catch
            {
                return null;
            }
        }

        public abstract Tax CreateTax();

        public abstract Bonus CreateBonus();
    }
}