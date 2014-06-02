using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace GenerateScript
{
    public class Context
    {
        Strategy strategy;

        public void SetStrategy()
        {
            this.strategy = LoadClassInstance();
        }

        public void GenereateScript(string filePath)
        {
             this.strategy.GenerateScripts(filePath);
        }

        public Strategy LoadClassInstance()
        {
            Strategy strategy;
            string assembleType = GetStrategy();

            Type type = Type.GetType(assembleType, true);
            strategy = (Strategy)Activator.CreateInstance(type);
            return strategy;
        }

        private string GetStrategy()
        {
            string databaseName = PubConstant.Database;
            string assembly = "GenerateScript."+databaseName;
            //if every time add new function ,need add else if, sometime it's fatal

            //string assembly = "";
            //switch (databaseName.ToUpper())
            //{
            //    case "MISSQL":
            //        assembly = "GenerateScript.SQLStrategy";
            //        break;
            //    case "ORACLE":
            //        assembly = "GenerateScript.OracleStrategy";
            //        break;
            //    case "MYSQL":
            //        assembly = "GenerateScript.MySqlStrategy";
            //        break;
            //    default:
            //        throw new ApplicationException("Database not supported");
            //}
            return assembly;
        }
    }

}
